using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ultra.Login {
    public partial class SetConfigView : Form {
        public SetConfigView() {
            InitializeComponent();
        }

        private void SetConfigView_Load(object sender, EventArgs e) {

        }

        private void btnOK_Click(object sender, EventArgs e) {
            ChangeConfiguration();
            MessageBox.Show("应用程序配置，保存成功!");
            //重启程序
            Process.Start(Application.ExecutablePath);
            Environment.Exit(0);
        }

        private void ChangeConfiguration() {
            //读取程序集的配置文件
            string assemblyConfigFile = Assembly.GetEntryAssembly().Location;

            Configuration config = ConfigurationManager.OpenExeConfiguration(assemblyConfigFile);
            //获取ConnectionStrings节点
            var connStrings = config.ConnectionStrings;
            connStrings.ConnectionStrings.Remove("dbconstr");

            connStrings.ConnectionStrings.Add(new ConnectionStringSettings("dbconstr",dataBaseConfigWizard1.ConnectionString));

            ////获取appSettings节点
            //AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");

            ////删除name，然后添加新值
            //appSettings.Settings.Remove("name");
            //appSettings.Settings.Add("name", "new");

            //保存配置文件
            config.Save();
        }

    }
}
