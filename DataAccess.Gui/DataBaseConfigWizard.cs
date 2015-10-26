using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess.Util;
using System.Threading;

namespace DataAccess.Gui
{
    public partial class DataBaseConfigWizard : UserControl
    {
        public DataBaseConfigWizard()
        {
            InitializeComponent();
            cmbValidType.SelectedIndex = 0;
            txtpwd.Text = cmbuid.Text = string.Empty;
            txtpwd.Enabled = cmbuid.Enabled = true;
        }

        #region [ Variables ]

        /// <summary>
        /// KEY:服务器实例名
        /// Value:此服务器实例下的所有数据库名称列表
        /// </summary>
        private Dictionary<string, List<string>> dicHostDataBaseNameList = new Dictionary<string, List<string>>(256);

        #endregion

        #region [ Properties ]

        /// <summary>
        /// 是否自动枚举网络上的可用SQL SERVER实例
        /// </summary>
        [Description("是否自动枚举网络上的可用SQL SERVER实例")]
        [Browsable(true)]
        public bool AutoEnumServer
        {
            get { return this.waittingPanel1.AutoMarquee; }
            set { this.waittingPanel1.AutoMarquee = value; this.waittingPanel1.Visible = value; }
        }

        [Description("当枚举服务器资源完成后触发")]
        [Browsable(true)]
        public event EventHandler OnEnumCompleted;

        /// <summary>
        /// 配置所得的连接字符串
        /// PS:不保证使用此字符串能正常连接至服务器,要检查是否正常连接以获得
        /// 经验证的连接字符串请使用 TryConnect 方法
        /// </summary>
        public string ConnectionString
        {
            get
            {
                SQLConnStringConfig connStrCfg = new SQLConnStringConfig();
                connStrCfg.ServerIP = cmbsvr.Text;
                connStrCfg.DataBaseName = cmbDataBase.Text;
                connStrCfg.ConnectionType = (EnConnectionType)(cmbValidType.SelectedIndex);
                connStrCfg.UserName = cmbuid.Text;
                connStrCfg.PassWord = txtpwd.Text;
                return connStrCfg.ConnectionString;
            }
        }

        #endregion

        private void DataBaseConfigWizard_Load(object sender, EventArgs e)
        {
            if (!AutoEnumServer || !Enabled) return;
            try
            {
                this.waittingPanel1.Visible =
                this.waittingPanel1.AutoMarquee = true;
                this.waittingPanel1.Message = "正在列举可用服务器列表...";
                //
                this.cmbsvr.Enabled = this.cmbuid.Enabled = this.cmbValidType.Enabled =
                    this.cmbDataBase.Enabled = this.txtpwd.Enabled = false;
                ThreadPool.QueueUserWorkItem(new WaitCallback(x =>
                {
                    List<SQLInstance> lst = SQLInstanceEnumrator.Enum();
                    this.Invoke(new MethodInvoker(() =>
                    {
                        if (null == lst || lst.Count < 1) return;
                        cmbsvr.Items.Clear();
                        //得到服务器名称列表
                        List<string> lstIns =
                            (from itm in lst
                             where !string.IsNullOrEmpty(itm.ServerName)
                             select itm.ServerName
                             ).Distinct().ToList();
                        //添加枚举到的服务器列表至控件
                        foreach (string str in lstIns)
                        {
                            cmbsvr.Items.Add(str);
                            if (!dicHostDataBaseNameList.ContainsKey(str))
                                dicHostDataBaseNameList.Add(str, new List<string>(10));
                        }
                        if (!cmbsvr.Items.Contains("."))
                        {
                            cmbsvr.Items.Add(".");
                            if (!dicHostDataBaseNameList.ContainsKey("."))
                                dicHostDataBaseNameList.Add(".", new List<string>(10));
                        }
                        //选取中第一项
                        cmbsvr.SelectedIndex = 0;
                        this.waittingPanel1.Visible = false;
                        this.cmbsvr.Enabled = this.cmbuid.Enabled = this.cmbValidType.Enabled =
                    this.cmbDataBase.Enabled = this.txtpwd.Enabled = true;
                        if (this.OnEnumCompleted != null)
                            this.OnEnumCompleted(this, new EventArgs());
                    }));
                }));
                //List<SQLInstance> lst = SQLInstanceEnumrator.Enum();

                //if (null == lst || lst.Count < 1) return;
                //cmbsvr.Items.Clear();
                ////得到服务器名称列表
                //List<string> lstIns =
                //    (from itm in lst
                //     where !string.IsNullOrEmpty(itm.ServerName)
                //     select itm.ServerName
                //     ).Distinct().ToList();
                ////添加枚举到的服务器列表至控件
                //foreach (string str in lstIns)
                //{
                //    cmbsvr.Items.Add(str);
                //    if (!dicHostDataBaseNameList.ContainsKey(str))
                //        dicHostDataBaseNameList.Add(str, new List<string>(10));
                //}
                //if (!cmbsvr.Items.Contains("."))
                //{
                //    cmbsvr.Items.Add(".");
                //    if (!dicHostDataBaseNameList.ContainsKey("."))
                //        dicHostDataBaseNameList.Add(".", new List<string>(10));
                //}
                ////选取中第一项
                //cmbsvr.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#else
#endif
            }
        }

        private void cmbValidType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbValidType.Text == cmbValidType.Items[0].ToString())
            {
               txtpwd.Enabled = cmbuid.Enabled = true;
            }
            else
            {
                txtpwd.Text = cmbuid.Text = string.Empty;
                txtpwd.Enabled = cmbuid.Enabled = false;
            }
        }

        /// <summary>
        /// 显示组合框下拉部分时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDataBase_DropDown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbsvr.Text))
                return;
            //先前已读取到此实例的数据库列表,则直接从缓存中加载
            if (dicHostDataBaseNameList.ContainsKey(cmbsvr.Text) && dicHostDataBaseNameList[cmbsvr.Text].Count > 0)
            {
                cmbDataBase.Items.Clear();
                cmbDataBase.Items.AddRange(dicHostDataBaseNameList[cmbsvr.Text].ToArray());
                cmbDataBase.SelectedIndex = 0;
                return;
            }
            //清空原始数据
            cmbDataBase.Text = string.Empty;
            cmbDataBase.Items.Clear();

            EnConnectionType enType = EnConnectionType.None;
            switch (cmbValidType.SelectedIndex)
            {
                case 0:
                    enType = EnConnectionType.DataBaseAccount;//SQL Server身份认证
                    break;
                case 1:
                    enType = EnConnectionType.Integrated;//集成身份认证
                    break;
            }
            List<string> lstDBName;
            Cursor = Cursors.WaitCursor;
            //连接服务器获取数据库名称列表
            if (!GetCurrentServerDataBaseList(cmbsvr.Text, enType, cmbuid.Text, txtpwd.Text, out lstDBName))
            {
                Cursor = Cursors.Default;
                MessageBox.Show("无法连接至服务器!", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!dicHostDataBaseNameList.ContainsKey(cmbsvr.Text))
                dicHostDataBaseNameList.Add(cmbsvr.Text, new List<string>(lstDBName.Count));
            //加入集合
            dicHostDataBaseNameList[cmbsvr.Text].AddRange(lstDBName);
            //添加到控件
            cmbDataBase.Text = string.Empty;
            cmbDataBase.Items.Clear();
            cmbDataBase.Items.AddRange(lstDBName.ToArray());
            cmbDataBase.SelectedIndex = 0;
            Cursor = Cursors.Default;
            if (!cmbsvr.Items.Contains(cmbsvr.Text))
                cmbsvr.Items.Add(cmbsvr.Text);
        }

        /// <summary>
        /// 连接至指定服务器以获取数据库名称列表
        /// </summary>
        /// <param name="serverName">服务器名</param>
        /// <param name="enType">论证方式</param>
        /// <param name="uid">用户ID(仅当认证方式为SQL帐户时)</param>
        /// <param name="pwd">用户密码(仅当认证方式为SQL帐户时)</param>
        /// <param name="lstDBName">成功获取到的数据库名称列表</param>
        /// <returns>成功获取返回true,否则为false</returns>
        private bool GetCurrentServerDataBaseList(
                                                    string serverName,
                                                    EnConnectionType enType,
                                                    string uid,
                                                    string pwd,
                                                    out List<string> lstDBName
                                                 )
        {
            lstDBName = null;
            //未读取过当前选择的实例下的数据库列表
            SQLServerMeta meta = new SQLServerMeta();
            SQLConnStringConfig connStrCfg = new SQLConnStringConfig();
            connStrCfg.ServerIP = serverName;//服务器名称/IP
            //connStrCfg.DataBaseName = "master";
            switch (enType)
            {
                case EnConnectionType.Integrated://集成身份认证
                    connStrCfg.ConnectionType = EnConnectionType.Integrated;
                    break;
                case EnConnectionType.DataBaseAccount://SQL Server 认证
                    connStrCfg.ConnectionType = EnConnectionType.DataBaseAccount;
                    connStrCfg.UserName = uid;//用户名
                    connStrCfg.PassWord = pwd;//密码
                    break;
            }
            //尝试连接至服务器
            if (!connStrCfg.TryConnect())
                return false;//无法连接至服务器

            meta.ConnStrCfg = connStrCfg;
            lstDBName = meta.GetAllDataBaseName();
            //无法枚举到任何数据库
            if (null == lstDBName || lstDBName.Count < 1)
                return false;
            return true;
        }

        #region [ Public Methods ]

        /// <summary>
        /// 判断当前数据库的配置是否能正常连接上
        /// </summary>
        /// <returns></returns>
        public bool TryConnect(out string connStr)
        {
            connStr = string.Empty;
            //判断数据库名称是否有选择
            if (string.IsNullOrEmpty(cmbDataBase.Text))
                return false;
            //判断服务器是否有设定
            if (string.IsNullOrEmpty(cmbsvr.Text))
                return false;
            //判断验证类型是否有设定
            if (string.IsNullOrEmpty(cmbValidType.Text))
                return false;
            EnConnectionType enType = EnConnectionType.None;
            switch (cmbValidType.SelectedIndex)
            {
                case 0:
                    enType = EnConnectionType.DataBaseAccount;//SQL Server身份认证
                    break;
                case 1:
                    enType = EnConnectionType.Integrated;//集成身份认证
                    break;
            }
            if (enType == EnConnectionType.DataBaseAccount)//若为SQL论证但无用户ID则返回错误
                if (string.IsNullOrEmpty(cmbuid.Text)) return false;

            SQLConnStringConfig connStrCfg = new SQLConnStringConfig();
            connStrCfg.ServerIP = cmbsvr.Text;
            connStrCfg.DataBaseName = cmbDataBase.Text;
            connStrCfg.ConnectionType = enType;
            connStrCfg.UserName = cmbuid.Text;
            connStrCfg.PassWord = txtpwd.Text;
            bool bOk = connStrCfg.TryConnect();
            if (bOk) connStr = connStrCfg.ConnectionString;
            return bOk;
        }

        #endregion
    }
}
