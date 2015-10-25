using DbEntity;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Web.Core.Common;

namespace Ultra.Role
{
    public partial class NewView : DialogViewEx
    {
        public NewView()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            if (EditMode == Ultra.Web.Core.Enums.EnViewEditMode.New)
            {
                using (var db = new Database())
                {
                    var et = db.FirstOrDefault<t_role>("where Name=@0", txtname.Text.Trim());
                    if (null != et)
                    {
                        MsgBox.ShowMessage(null, "名称已存在，不可重复添加!");
                        return;
                    }
                    db.Save(new t_role
                    {
                        Guid = Guid.NewGuid(),
                        IsUsing = chk.Checked,
                        Name = txtname.Text.Trim(),     
                        Creator = this.CurUser,
                        Desc=txtdesc.Text.Trim(),
                        CreateDate=TimeSync.Default.CurrentSyncTime,
                        Remark=string.Empty
                    });
                }
            } else if (EditMode == Ultra.Web.Core.Enums.EnViewEditMode.Edit)
            {
                using (var db = new Database())
                {
                    var et = db.FirstOrDefault<t_role>(" where guid=@0", GuidKey);
                    if (et != null)
                    {
                        db.Update<t_role>(" set isusing=@0,[desc]=@1 where guid=@2", chk.Checked, txtdesc.Text.Trim(), et.Guid);
                    }
                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void NewView_Load(object sender, EventArgs e)
        {
            if (EditMode == Ultra.Web.Core.Enums.EnViewEditMode.Edit)
            {
                txtname.Properties.ReadOnly = true;
                using (var db = new Database())
                {
                    var et = db.FirstOrDefault<t_role>(" where guid=@0", GuidKey);
                    if (null != et)
                    {
                        txtname.Text = et.Name;
                        txtdesc.Text = et.Desc;
                        chk.Checked = et.IsUsing;
                    }
                }
            }
        }
    }
}
