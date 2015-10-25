using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PetaPoco;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Web.Core.Common;
using DbEntity;

namespace Ultra.User {
    public partial class NewView : DialogView {
        public NewView() {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (!dxValidationProvider1.Validate())
                return;

            if (MsgBox.ShowYesNoMessage(null, "确定要保存修改吗?") == System.Windows.Forms.DialogResult.No)
                return;
            if (txtpwd.Text != txtrepwd.Text) {
                MsgBox.ShowMessage("", "两次输入的密码不一致!");
                txtpwd.Select();
                return;
            }
            var pwd = string.IsNullOrEmpty(txtpwd.Text) ? "888" : txtpwd.Text;
            var pwde = Util.EncryptPwd(pwd);
            if (EditMode == Ultra.Web.Core.Enums.EnViewEditMode.New) {
                using (var db = new Database()) {
                    //检查用户名唯一性
                    var kt = db.FirstOrDefault<t_user>("select * from t_user where UserName=@0", txtusr.Text);
                    if (null != kt) {
                        MsgBox.ShowMessage("用户已存在", "用户已存在!");
                        txtusr.Select();
                        return;
                    }
                    db.Save(new t_user() {
                        Guid = Guid.NewGuid(),
                        UserName = txtusr.Text,
                        Pwd = pwde,
                        CreateDate = TimeSync.Default.CurrentSyncTime,
                        Creator=this.CurUser,
                        IsUsing=chk.Checked,
                        Remark=string.Empty
                    });
                }
            } else if (EditMode == Ultra.Web.Core.Enums.EnViewEditMode.Edit) {
                using (var db = new Database()) {
                    var et = db.FirstOrDefault<t_user>("where Guid=@0", GuidKey);
                    if (null != et) {
                        et.Guid = Guid.NewGuid();
                        et.UserName = txtusr.Text;
                        et.Pwd = pwde;
                        et.CreateDate = TimeSync.Default.CurrentSyncTime;
                        et.Creator=this.CurUser;
                        et.IsUsing=chk.Checked;
                        et.Remark = string.Empty;
                    }
                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void NewView_Load(object sender, EventArgs e) {
            if (EditMode == Ultra.Web.Core.Enums.EnViewEditMode.Edit) {
                using (var db = new Database()) {
                    try {
                        var et = db.FirstOrDefault<t_user>("where Guid=@0", GuidKey);
                        if (null != et) {
                            txtusr.Text = et.UserName;
                            chk.Checked = et.IsUsing;
                        }
                    } catch (Exception ex) {
                        throw ex;
                    }
                }
                txtusr.Properties.ReadOnly = true;
            }
        }
    }
}
