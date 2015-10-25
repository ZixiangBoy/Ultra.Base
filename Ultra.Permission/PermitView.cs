using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.XtraTreeList.Nodes;
using DbEntity;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using Ultra.Surface.Lanuch;
using Ultra.Web.Core.Common;
using PetaPoco;

namespace Ultra.Permission {
    public partial class PermitView : DialogViewEx {
        public PermitView() {
            InitializeComponent();
            //Visible = false;
        }
        DevExpress.Utils.WaitDialogForm dlg;
        private void PermitView_Load(object sender, EventArgs e) {
            this.btnClose.Left = this.Width - this.btnClose.Width - 30;
            this.btnOK.Left = this.btnClose.Left - this.btnOK.Width - 10;
            roleGridEdit1.LoadData();
            treeCtl1.AfterCheckNode += treeCtl1_AfterCheckNode;
            treeCtl1.Enabled = false;
            var menu = Db.FirstOrDefault<t_menu>(" where version='1.0'");
            //解析菜单Json
            var menus = ObjectHelper.DeSerialize<List<MenuData>>(menu.MenuJson);
            treeCtl1.ClearNodes();
            ExtractMenu(menus);
            dlg = new DevExpress.Utils.WaitDialogForm("正在加载权限设置信息 ...",
                "数据加载中");
            var t = new Thread(() => {
                //加载菜单
                this.Invoke(new Action(() => {
                    BuildlRoleTree();
                    Visible = true;
                }));
                this.Invoke(new Action(() => dlg.Close()));
            });
            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();
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

        private void Refc(string cls, string mod, TreeListNode mnu) {
            try {
                var pth = Path.Combine(Lanucher.AppDir, mod);
                var md5 = string.Empty;
                if (File.Exists(pth)) {
                    md5 = ByteStringUtil.ByteArrayToHexStr(HashDigest.FileDigest(pth));
                }
                var m = Lanucher.Start(cls, mod);
                var ip = m as ISurfacePermission;
                if (null == ip)
                    return;
                var toolbar = ip.ToolBarItems;
                var grids = ip.Grids;
                var btns = ip.ButtonItems;
                if (null != toolbar && toolbar.Count > 0) {
                    var td = mnu.Nodes.Add(new object[] { "主按钮" });
                    foreach (var ti in toolbar) {
                        var tds = td.Nodes.Add(new object[] { ti.Caption });
                        tds.Tag = new t_rolepermit {
                            ControlName = ti.Name,
                            TextName = ti.Caption,
                            CtlType = (int)EnCtlType.ToolBarItems,
                            IsEnabled = false,
                            ClsName = cls,
                            AsmName = mod,
                            AsmMD5 = md5
                        };
                    }
                }
                if (null != grids && grids.Count > 0) {
                    foreach (var ti in grids) {
                        var td = mnu.Nodes.Add(new object[] { ti.Name });
                        td.Tag = new t_rolepermit {
                            ControlName = ti.Gv.Name,
                            TextName = ti.Name,
                            CtlType = (int)EnCtlType.Grids,
                            IsEnabled = false,
                            ClsName = cls,
                            AsmName = mod,
                            AsmMD5 = md5
                        };
                        foreach (DevExpress.XtraGrid.Columns.GridColumn col in ti.Gv.Columns) {
                            var tdc = td.Nodes.Add(new object[] { col.Caption });

                            tdc.Tag = new t_rolepermit {
                                ControlName = col.Name,
                                ParentCtlName = ti.Gv.Name,
                                TextName = col.Caption,
                                CtlType = (int)EnCtlType.GridCol,
                                IsEnabled = false,
                                ClsName = cls,
                                AsmName = mod,
                                AsmMD5 = md5
                            };
                        }
                    }
                }
                if (null != btns && btns.Count > 0) {
                    var td = mnu.Nodes.Add(new object[] { "自定义按钮" });
                    foreach (var ti in btns) {
                        var tds = td.Nodes.Add(new object[] { string.IsNullOrEmpty(ti.Text) ? ti.Name : ti.Text/*ti.Name*/ });
                        tds.Tag = new t_rolepermit {
                            ControlName = ti.Name,
                            TextName = ti.Text,
                            CtlType = (int)EnCtlType.ButtonItems,
                            IsEnabled = false,
                            ClsName = cls,
                            AsmName = mod,
                            AsmMD5 = md5
                        };
                    }
                }
            } catch //(Exception)
            {

                //throw;
            }
        }

        private void BuildlRoleTree() {
            foreach (TreeListNode td in treeCtl1.Nodes) {
                foreach (TreeListNode tm in td.Nodes) {
                    var md = tm.Tag as MenuItemData;
                    if (null == md )
                        continue;
                    Refc(md.MenuClsName, md.MenuAsmName, tm);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs ea) {
            var role = roleGridEdit1.GetSelectedValue();
            if (null == role)
                return;
            var lst = new List<t_rolepermit>(100);
            foreach (TreeListNode td in treeCtl1.Nodes) {
                var mnugrp = td.GetValue(0).ToString();
                foreach (TreeListNode tds in td.Nodes) {
                    var mnuname = tds.GetValue(0).ToString();
                    foreach (TreeListNode tmd in tds.Nodes) {
                        var mcd = tmd.Tag as t_rolepermit;
                        if (null != mcd) {
                            mcd.IsEnabled = tmd.Checked;
                            mcd.MenuGrpName = mnugrp;
                            mcd.MenuName = mnuname;
                            lst.Add(mcd);
                        }
                        foreach (TreeListNode tkd in tmd.Nodes) {
                            var md = tkd.Tag as t_rolepermit;
                            if (null == md)
                                continue;
                            md.IsEnabled = tkd.Checked;
                            md.MenuGrpName = mnugrp;
                            md.MenuName = mnuname;
                            lst.Add(md);
                        }
                    }
                }
            }
            var usr = GetCurUser<t_user>();

            Db.Execute("delete t_rolepermit where RoleId=@0", role.Id);
            lst.ForEach(k => {
                k.CreateDate = TimeSync.Default.CurrentSyncTime;
                k.Guid = Guid.NewGuid();
                k.Creator=usr.UserName;
                k.RoleName = role.Name;
                k.RoleId = role.Id;
            });
            Db.Insert(lst);
            MsgBox.ShowMessage(null, "保存成功!");
        }

        private void ClearNodeCheck() {
            foreach (TreeListNode td in treeCtl1.Nodes) {
                td.Checked = false;
                foreach (TreeListNode tds in td.Nodes) {
                    tds.Checked = false;
                    foreach (TreeListNode tmd in tds.Nodes) {
                        tmd.Checked = false;
                        foreach (TreeListNode tkd in tmd.Nodes) {
                            tkd.Checked = false;
                        }
                    }
                }
            }
        }

        private void SetNodeRole(List<t_rolepermit> roledata) {
            foreach (TreeListNode td in treeCtl1.Nodes) {
                foreach (TreeListNode tds in td.Nodes) {
                    foreach (TreeListNode tmd in tds.Nodes) {
                        var md = tmd.Tag as t_rolepermit;
                        if (null != md) {
                            var et = roledata.Where(k => k.ClsName == md.ClsName && k.AsmName == md.AsmName &&
                                md.ControlName == k.ControlName).FirstOrDefault();
                            if (null == et) {
                                tmd.Checked = false;
                                NodeNext(tmd);
                                NodePrev(tmd);
                            } else {
                                tmd.Checked = et.IsEnabled;
                                NodeNext(tmd);
                                NodePrev(tmd);
                            }
                        }
                        foreach (TreeListNode tkd in tmd.Nodes) {
                            var mdt = tkd.Tag as t_rolepermit;
                            if (null == mdt)
                                continue;
                            var et = roledata.Where(k => k.ClsName == mdt.ClsName
                                && k.AsmName == mdt.AsmName &&
                               mdt.ControlName == k.ControlName).FirstOrDefault();
                            if (null == et) {
                                tkd.Checked = false;
                                NodeNext(tkd);
                                NodePrev(tkd);
                            } else {
                                tkd.Checked = et.IsEnabled;
                                NodeNext(tkd);
                                NodePrev(tkd);
                            }
                        }
                    }
                }
            }
        }

        private void roleGridEdit1_EditValueChanged(object sender, EventArgs e) {
            var m = roleGridEdit1.SelectedValue;
            if (null == m) { treeCtl1.Enabled = false; return; }
            treeCtl1.Enabled = true;

            var rolesets = Db.Fetch<t_rolepermit>(" where RoleId=@0", m.Id);

            if (null == rolesets) {
                ClearNodeCheck();
            } else {
                SetNodeRole(rolesets);
            }
        }

        void treeCtl1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e) {
            NodeNext(e.Node);
            NodePrev(e.Node);
        }

        void CollectNode(TreeListNode tdk, ref List<TreeListNode> lsttd) {
            if (null == lsttd)
                lsttd = new List<TreeListNode>(100);
            var tds = null == tdk ? treeCtl1.Nodes : tdk.Nodes;
            foreach (TreeListNode td in tds) {
                if (td.Nodes != null)
                    CollectNode(td, ref lsttd);
                else {
                    if (td.Checked)
                        lsttd.Add(td);
                    CollectNode(td, ref lsttd);
                }

            }
            lsttd.ForEach(k => {
                NodeNext(k);
                NodePrev(k);
            });
        }

        private void NodePrev(TreeListNode td) {
            if (td.ParentNode != null) {
                if (td.Checked)
                    td.ParentNode.Checked = true;
                else {
                    var flg = false;
                    foreach (TreeListNode tnd in td.ParentNode.Nodes) {
                        if (tnd.Checked) {
                            flg = true;
                            break;
                        }
                    }

                    td.ParentNode.Checked = flg;
                }
                NodePrev(td.ParentNode);
            } else {
                if (!td.Checked) {
                    foreach (TreeListNode tkd in td.Nodes) {
                        if (tkd.Checked) { td.Checked = true; break; }
                    }
                }
            }
        }

        private void NodeNext(TreeListNode td) {
            foreach (TreeListNode tnd in td.Nodes) {
                tnd.Checked = td.Checked;
                if (tnd.Nodes != null)
                    NodeNext(tnd);
            }

        }
    }
}
