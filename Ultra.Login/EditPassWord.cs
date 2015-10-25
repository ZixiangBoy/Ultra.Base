using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ultra.Surface.Form;
using Ultra.Surface.Common;
using PetaPoco;
using Ultra.Web.Core.Common;
using Ultra.Web.Core.Interface;

namespace Ultra.Login {
    public partial class EditPassWord : BaseSurface {
        public EditPassWord() {
            InitializeComponent();
        }

        private void EditPassWord_Load(object sender, EventArgs e) {
            txtUserName.Text = this.CurUser;
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (!dxValidationProvider1.Validate()) { return; }

            if (txtPassword.Text != txtComfirmPassword.Text) {
                MsgBox.ShowMessage("","两次输入的密码不一致!");
                return;
            }

            try {
                using (var db = new Database()) {
                    db.Execute("update t_user set Pwd=@0 where Username=@1", Ultra.Surface.Common.Util.EncryptPwd(txtPassword.Text), this.CurUser);
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            } catch (Exception ex) {          
                throw ex;
            }

        }
    }
}