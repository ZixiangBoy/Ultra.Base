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
using DbEntity;
using Ultra.Surface.Extend;
using Ultra.Web.Core.Common;

namespace Ultra.Permission {
    public partial class NewView : DialogViewEx {
        public NewView() {
            InitializeComponent();
        }

        private List<t_user> AllUser { get; set; }

        private void NewView_Load(object sender, EventArgs e) {
            roleGridEdit2.LoadData();
            using (var db = new Database()) {
                AllUser = db.Fetch<t_user>("select * from t_user where isusing=1");
            }
        }

        private void roleGridEdit2_EditValueChanged(object sender, EventArgs e) {
            if (roleGridEdit2.EditValue == null) {
                gridunalloc.DataSource = gridalloc.DataSource = null;
                gridunalloc.RefreshDataSource();
                gridalloc.RefreshDataSource();
                return;
            }
            var re = roleGridEdit2.GetSelectedValue();
            if (re == null)
                return;
            using (var db = new Database()) {
                var ur = db.Query<t_user>("select * from t_user")
                    .Join(db.Query<t_roleuser>("select * from t_roleuser where RoleId=@0", re.Id),
                    o => o.Id, k => k.UserId, (o, k) => new { o, k }
                    ).Select(z => z.o).OrderBy(k => k.UserName).ToList();
                this.gridalloc.DataSource = ur;
                this.gridunalloc.DataSource = AllUser.Where(k => !ur.Any(j => j.UserName == k.UserName)).Where(k => k.UserName != "admin").OrderBy(k => k.UserName).ToList();
                return;
            }
        }

        private void btnLeft_Click(object sender, EventArgs e) {
            var rows = gvunalloc.GetSelectedRows();
            if (rows.Length < 1)
                return;
            var selectedItems = new List<t_user>();
            foreach (var row in rows) {
                selectedItems.Add(gvunalloc.GetRow(row) as t_user);
            }
            //var kts = lstunalloc.DataSource as List<t_user>;
            //var ks = lstalloc.DataSource as List<t_user>;
            var kts = gridunalloc.GetDataSource<t_user>();
            var ks = gridalloc.GetDataSource<t_user>();
            ks = ks ?? new List<t_user>();
            foreach (var k in selectedItems) {
                if (null == k)
                    continue;
                kts.Remove(k);
                ks.Add(k);
            }
            gridalloc.RefreshDataSource();
            gridunalloc.RefreshDataSource();
            gvalloc.FocusedRowHandle = gridalloc.GetDataSource<t_user>().Count > 0 ?
                gridalloc.GetDataSource<t_user>().Count - 1 : -1;
            gvunalloc.FocusedRowHandle = gridunalloc.GetDataSource<t_user>().Count > 0 ?
                gridunalloc.GetDataSource<t_user>().Count - 1 : -1;
        }

        private void btnRight_Click(object sender, EventArgs e) {
            var rows = gvalloc.GetSelectedRows();
            if (rows.Length < 1)
                return;
            var selectedItems = new List<t_user>();
            foreach (var row in rows) {
                selectedItems.Add(gvalloc.GetRow(row) as t_user);
            }
            var kts = gridalloc.DataSource as List<t_user>;
            var ks = gridunalloc.DataSource as List<t_user>;
            ks = ks ?? new List<t_user>();
            foreach (var k in selectedItems) {
                if (null == k)
                    continue;
                kts.Remove(k);
                ks.Add(k);
            }
            gridalloc.RefreshDataSource();
            gridunalloc.RefreshDataSource();
            gvalloc.FocusedRowHandle = gridalloc.GetDataSource<t_user>().Count > 0 ?
                gridalloc.GetDataSource<t_user>().Count - 1 : -1;
            gvunalloc.FocusedRowHandle = gridunalloc.GetDataSource<t_user>().Count > 0 ?
                gridunalloc.GetDataSource<t_user>().Count - 1 : -1;
        }

        private void btnRightAll_Click(object sender, EventArgs e) {
            var kts = gridalloc.GetDataSource<t_user>();
            if (kts == null || kts.Count < 1)
                return;
            var ks = gridunalloc.GetDataSource<t_user>();
            ks = ks ?? new List<t_user>();

            foreach (var k in kts) {
                ks.Add(k);
            }
            kts.Clear();
            gridalloc.RefreshDataSource();
            gridunalloc.RefreshDataSource();
        }

        private void btnleftall_Click(object sender, EventArgs e) {
            var kts = gridunalloc.GetDataSource<t_user>();
            if (kts == null || kts.Count < 1)
                return;
            var ks = gridalloc.GetDataSource<t_user>();
            ks = ks ?? new List<t_user>();

            foreach (var k in kts) {
                ks.Add(k);
            }
            kts.Clear();
            gridalloc.RefreshDataSource();
            gridunalloc.RefreshDataSource();
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if (MsgBox.ShowYesNoMessage(null, string.Format("确定要保存对角色：{0} 的修改吗?", roleGridEdit2.SelectedValue.Name))
                == System.Windows.Forms.DialogResult.No)
                return;
            var role = roleGridEdit2.SelectedValue;
            using (var db = new Database()) {
                try {
                    db.BeginTransaction();
                    db.Execute("delete from t_roleuser where RoleId=@0", role.Id);
                    var ets = gridalloc.GetDataSource<t_user>();
                    if (null != ets && ets.Count > 0)
                        foreach (var k in ets)//.ForEach(k =>
                        {
                            db.Insert(new t_roleuser {
                                Guid = Guid.NewGuid(),
                                RoleId = role.Id,
                                UserId = k.Id,
                                IsUsing = true,
                                Creator = this.CurUser,
                                CreateDate = TimeSync.Default.CurrentSyncTime
                            });
                        };
                    db.CompleteTransaction();
                } catch (Exception ex) {
                    db.AbortTransaction();
                    throw;
                }
            }
            MsgBox.ShowMessage(null, "保存成功!");
        }
    }
}
