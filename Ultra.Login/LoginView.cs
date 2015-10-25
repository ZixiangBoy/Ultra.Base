using DbEntity;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Web.Core.Common;

namespace Ultra.Login {
    public partial class LoginView : BaseSurface {
        public LoginView() {
            InitializeComponent();
        }

        private void LoginView_Load(object sender, EventArgs e) {
            var lstlgn = this.OptConfig.Get<string>("LastLogin");
            if (!string.IsNullOrEmpty(lstlgn))
                txtAct.Text = lstlgn;
            txtpwd.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private string LocalIP = string.Empty;
        private string RemoteIP = string.Empty;
        private string LocalMAC = string.Empty;
        private void btnOK_Click(object sender, EventArgs e) {
            if (!dxValidationProvider1.Validate())
                return;
            //获取本地mac地址
            Common.GetMACs(out LocalMAC);
            //获取本地ip地址
            Common.GetLocalIpv4(out LocalIP);
            //获取外网ip地址
            //try { RemoteIP = Common.GetRemoteIP(); }
            //catch { RemoteIP = string.Empty; }
            RemoteIP = string.Empty;

            var pwd = Util.EncryptPwd(txtpwd.Text);
            //如果没有admin  就添加admin为默认管理员用户  密码:888
            Db.Execute(Sql_AddDefUser);

            var kt = Db.FirstOrDefault<t_user>(" where username=@0 and pwd=@1 and IsUsing=1", txtAct.Text.Trim(), pwd);
            if (null == kt) {
                MsgBox.ShowMessage("登录无效", "无效的登录名或密码不正确");
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Cacher.Put<t_user>("CurrentUser", kt);
            this.Cacher.Put<string>("CurUser", kt.UserName);
            if (!"admin".EqualIgnorCase(kt.UserName)) {
                //读取权限信息
                var rolepremts = Db.Fetch<t_rolepermit>("SELECT distinct MenuGrpName,CtlType,MenuName,ControlName,ClsName,AsmName,AsmMD5,ParentCtlName,TextName,IsEnabled FROM t_rolepermit where RoleId in (select RoleId from t_roleuser a join t_role b on a.roleid=b.id and b.isusing=1 where a.userId=@0)", kt.Id);
                var rlet = rolepremts.Where(j => j.IsEnabled).ToList();
                this.Cacher.Put<List<t_rolepermit>>("Permission", rlet);
            }
            //记录最后一次登录的用户名
            this.OptConfig.Set<string>("LastLogin", txtAct.Text.Trim());
            Close();
        }

        //private bool IsAllowLogin() {
        //    var macs = Db.Fetch<t_mac>(string.Empty);
        //    var c = macs.Count();
        //    if (c < 1)
        //        return true;
        //    var ks = macs.Where(k => string.Compare(k.Mac, LocalMAC, true) == 0).ToList();
        //    return ks != null && ks.Count > 0;
        //}

        private string Sql_AddDefUser {
            get {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert t_user(guid,username,Pwd)                                           \n");
                sb.Append("	select newid(),'admin','97E5F9C5EAA6EDEE98559C877DCEC1B8'                          \n");
                sb.Append("	from t_user where not exists(select 1 from t_user where username='admin') \n");
                return sb.ToString();
            }
        }

        private void txtpwd_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                btnOK_Click(sender, e);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override void WndProc(ref Message message) {
            base.WndProc(ref message);
            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT) {
                message.Result = (IntPtr)HTCAPTION;
            }
        }
    }
}
