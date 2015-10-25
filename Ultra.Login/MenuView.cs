using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Web.Core.Common;
using DbEntity;
using PetaPoco;

namespace Ultra.Login {
    public partial class MenuView : BaseSurface {

        public MenuView() {
            InitializeComponent();
        }

        private void MenuView_Load(object sender, EventArgs e) {
            treeCtl1.ClearNodes();
            
            var menu = Db.FirstOrDefault<t_menu>(" where version='1.0'");
            if (string.IsNullOrEmpty(menu.MenuJson))
                return;
            //解析菜单Json
            var menus = ObjectHelper.DeSerialize<List<MenuData>>(menu.MenuJson);
            ExtractMenu(menus);
        }

        private void treeCtl1_MouseUp(object sender, MouseEventArgs e) {
            try {
                Point pt = treeCtl1.PointToClient(MousePosition);
                TreeListHitInfo info = treeCtl1.CalcHitInfo(pt);
                if (info.HitInfoType == HitInfoType.Cell)
                    treeCtl1.FocusedNode = info.Node;
            } finally { }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                this.popMenuCtl1.ShowPopup(Control.MousePosition);
        }

        private void barbtnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (this.treeCtl1.FocusedNode == null)
                return;
            if (MsgBox.ShowYesNoMessage(null, "确定要删除吗?") == System.Windows.Forms.DialogResult.No)
                return;
            treeCtl1.Nodes.Remove(treeCtl1.FocusedNode);
        }

        private void barbtnMnuGrp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var md = new MenuData {
                IsUsing = true,
                MenuGrpName = "新建菜单组",
                MenuItems = null
            };
            var nd = this.treeCtl1.Nodes.Add(new object[] { "新建菜单组", md });
            nd.Tag = md;
            this.treeCtl1.FocusedNode = nd;
        }

        private void barbtnMnuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var nd = this.treeCtl1.FocusedNode;
            var pnd = nd.ParentNode == null ? nd : nd.ParentNode;
            var md = new MenuData {
                IsUsing = true,
                MenuGrpName = pnd.GetValue(0).ToString(),
                MenuItems = null
            };
            var md2 = new MenuData {
                IsUsing = true,
                MenuGrpName = pnd.GetValue(0).ToString(),
                MenuItems = new List<MenuItemData>{ 
                    new MenuItemData {
                        IsUsing = true,
                        MenuName = "新建菜单项",
                        MenuClsName = string.Empty,
                        MenuAsmName = string.Empty
                    }
                }
            };
            var tnd = pnd.Nodes.Add(new object[] { "新建菜单项", md2 });
            tnd.Tag = md2;
            this.treeCtl1.FocusedNode = tnd;
        }

        private void treeCtl1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e) {
            if (e.Node == null)
                return;
            var pnd = e.Node.ParentNode;
            btnSaveMnuItem.Enabled = pnd != null;
            btnSaveMnuGrp.Enabled = pnd == null;
            txtmnuGrp.Text = pnd == null ? e.Node.GetValue(0).ToString() : pnd.GetValue(0).ToString();

            var tg = e.Node.Tag as MenuItemData;
            if (pnd != null)//菜单项
            {
                txtmnuName.Text = e.Node.GetValue(0).ToString();
                if (null != tg) {
                    txtmnuAsmName.Text = tg.MenuAsmName;
                    txtmnuClassName.Text = tg.MenuClsName;
                    chkUsing.Checked = tg.IsUsing;
                }
            } else {
                txtmnuName.Text = string.Empty;
                txtmnuAsmName.Text = string.Empty;
                txtmnuClassName.Text = string.Empty;
                chkUsing.Checked = null == tg ? chkUsing.Checked : tg.IsUsing;
            }
        }

        private void btnSaveMnuGrp_Click(object sender, EventArgs e) {
            var nd = treeCtl1.FocusedNode;
            if (nd.ParentNode != null)
                return;
            var tg = nd.Tag as MenuData;
            tg = tg == null ? new MenuData {
                MenuItems = null,
                IsUsing = true,
                MenuGrpName = nd.GetValue(0).ToString()
            } : tg;
            tg.MenuGrpName = txtmnuGrp.Text;
            nd.Tag = tg;
            nd.SetValue(0, txtmnuGrp.Text);
        }

        private void btnSaveMnuItem_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtmnuName.Text)) {
                return;
            }
            var nd = treeCtl1.FocusedNode;
            if (nd.ParentNode == null)
                return;
            var tg = nd.Tag as MenuItemData;
            tg = tg == null ? new MenuItemData {
                IsUsing = true,
                MenuName = nd.GetValue(0).ToString()
            } : tg;
            tg.MenuClsName = txtmnuClassName.Text;
            tg.MenuAsmName = txtmnuAsmName.Text;
            tg.MenuName = txtmnuName.Text;
            tg.IsUsing = chkUsing.Checked;
            nd.SetValue(0, txtmnuName.Text);
            nd.Tag = tg;
        }

        private void ExtractMenu(List<MenuData> menus) {
            if (menus == null || menus.Count < 1)
                return;
            foreach (var g in menus) {
                var td = treeCtl1.Nodes.Add(new object[] { g.MenuGrpName, g });
                td.Tag = g;
                foreach (var m in g.MenuItems) {
                    var tsd = td.Nodes.Add(new object[] { 
                        m.MenuName,m
                    });
                    tsd.Tag = m;
                }
            }
        }

        private List<MenuData> BuildMenuList() {
            if (treeCtl1.Nodes.Count < 1)
                return null;
            var menus = new List<MenuData>();
            foreach (TreeListNode xd in treeCtl1.Nodes) {
                var menuGrp = xd.Tag as MenuData;
                menuGrp.MenuItems = new List<MenuItemData>();
                menus.Add(menuGrp);
                foreach (TreeListNode nd in xd.Nodes) {
                    menuGrp.MenuItems.Add(nd.Tag as MenuItemData);
                }
            }
            return menus;
        }

        private void btnSaveToSvr_Click(object sender, EventArgs e) {
            if (MsgBox.ShowYesNoMessage("", "确定要保存菜单至服务器?") == System.Windows.Forms.DialogResult.No)
                return;
            var menus = BuildMenuList();
            try {
                Db.Execute("delete t_menu where Version = '1.0'");
                var menu = new t_menu {
                    CreateDate = TimeSync.Default.CurrentSyncTime,
                    MenuJson = ObjectHelper.SerializeJson(menus),
                    Version = "1.0",
                };
                Db.Insert(menu);
                MsgBox.ShowMessage("", "保存成功!");
            } catch (Exception) {
                throw;
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (MsgBox.ShowYesNoMessage(null, "重新加载菜单，有可能丢失当前的更改，是否继续?") ==
                 System.Windows.Forms.DialogResult.No)
                return;
            var menu = Db.FirstOrDefault<t_menu>(" where version='1.0'");
            if (string.IsNullOrEmpty(menu.MenuJson))
                return;
            //解析菜单Json
            var menus = ObjectHelper.DeSerialize<List<MenuData>>(menu.MenuJson);
            treeCtl1.ClearNodes();
            ExtractMenu(menus);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (fdlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                //File.WriteAllText(fdlg.FileName,BuildMenuList());
                if (MsgBox.ShowYesNoMessage(null, "导出成功，是否立即打开?") == System.Windows.Forms.DialogResult.Yes) {
                    SystemInvoke.OpenFile(fdlg.FileName);
                }
            }
        }
    }
}
