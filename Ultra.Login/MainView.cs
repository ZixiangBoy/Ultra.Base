using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraNavBar;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Web.Core.Common;
using Ultra.Surface.Lanuch;
using System.Xml.Linq;
using PetaPoco;
using DbEntity;
using System.Threading.Tasks;
using DevExpress.XtraTabbedMdi;
using System.Reflection;
using DevExpress.XtraGrid.Columns;

namespace Ultra.Login {
    public partial class MainView : BaseSurface {
        public MainView() {
            InitializeComponent();
            this.navMenu.Groups.Clear();
            barStaticItem2.Caption =
            barStaticItem3.Caption = string.Empty;
            xtraTabbedMdiManager1.MouseDown += xtraTabbedMdiManager1_MouseDown;
        }

        DateTime d = DateTime.Now;
        void xtraTabbedMdiManager1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                var date = DateTime.Now;
                var span = date.Subtract(d);
                if (span.TotalMilliseconds < 300 && this.MdiChildren.Length > 0) {
                    if ((xtraTabbedMdiManager1.SelectedPage != null) && (xtraTabbedMdiManager1.SelectedPage.MdiChild != null) &&
                        xtraTabbedMdiManager1.SelectedPage == xtraTabbedMdiManager1.CalcHitInfo(new Point(e.X, e.Y)).Page as XtraMdiTabPage &&
                        this.ActiveMdiChild == xtraTabbedMdiManager1.SelectedPage.MdiChild)
                        this.ActiveMdiChild.Close();
                } else {
                    d = date;
                }
            }
        }

        private bool? IsLogOff = null;

        private void MainView_Load(object sender, EventArgs e) {
            Common.GetMACs(out LocalMAC);
            Common.GetLocalIpv4(out LocalIP);
            //try { RemoteIP = Common.GetRemoteIP(); } catch { RemoteIP = string.Empty; }
            RemoteIP = string.Empty;
            //检查登录是否是被授权的
            
            if ((this.CurUser.IgnoreCaseEqual("admin"))) {
                barBtnSysMnu.Visibility = BarItemVisibility.Always;
            } else { 
                barBtnSysMnu.Visibility = BarItemVisibility.Never; 
            }
            this.barLabel.Caption = this.CurUser;
            var skinGallery = new DevExpress.XtraBars.Ribbon.GalleryDropDown();
            skinGallery.Manager = this.barManager1;
            this.barSkin.ButtonStyle = BarButtonStyle.DropDown;
            this.barSkin.DropDownControl = skinGallery;
            this.barSkin.ActAsDropDown = true;
            skinGallery.Gallery.ItemClick += (obj, se) => {
                this.OptConfig.Set<string>("SkinName", se.Item.Caption);
                Lanucher.ReLoadSkinName();
            };
            SkinHelper.InitSkinGalleryDropDown(skinGallery);
            var mnustyle = OptConfig.Get<string>("Menu");
            if (mnustyle == "Taobao") {
                barChkTaobao.Checked = true;
            } else
                barChkSys.Checked = true;
            SqlConnectionStringBuilder bld = new SqlConnectionStringBuilder(ConnString);
            barStaticItem2.Caption = string.Format("{0} {1}", bld.DataSource.ToString(), bld.InitialCatalog);
            barStaticItem2.Caption += " " + RemoteIP;

            //同步服务器时间
            var serverTime = (DateTime)SqlHelper.ExecuteScalar(ConnString,CommandType.Text,"select getdate()");
            TimeSync.Default.StartSync(serverTime);

            //var t = new Thread(() => {
            //    while (true) {
            //        Thread.Sleep(1000);
            //        if (this.IsDisposed)
            //            return;
            //        while (!this.IsHandleCreated) { }
            //        this.Invoke(new Action(() => {
            //            barStaticItem3.Caption = TimeSync.Default.CurrentSyncTime.ToString("yyyy-MM-dd HH:mm:ss");
            //        }));
            //    }
            //});
            //t.IsBackground = true;
            //t.Start();

            //加载菜单
            LoadMenu();
            if (string.Compare(OptConfig.Get<string>("Menu"), "taobao", true) == 0) {
                barChkTaobao.Checked = true;
                barChkSys.Checked = false;
                foreach (NavBarGroup gp in navMenu.Groups)
                    gp.Expanded = true;
            } else { barChkSys.Checked = true; barChkTaobao.Checked = false; }
            var w = OptConfig.Get<int>("MenuWidth");
            if (w > 0)
                this.navMenu.Width = w;

            try {
                var mpv = Lanucher.Start("Ultra.MainPage.MainView");
                if (null != mpv) {
                    mpv.MdiParent = this;
                    mpv.Show();
                }
            } catch { }
            var threg = new Thread(() => { RegSelfLogin(); });
            threg.IsBackground = true;
            threg.Start();
        }

        private string LocalIP = string.Empty;
        private string RemoteIP = string.Empty;
        private string LocalMAC = string.Empty;

        private string Sql_AddLogin {
            get {
                StringBuilder sb = new StringBuilder();
                sb.Append("update t_logincur                                                    \n");
                sb.Append("	set                                                   \n");
                sb.Append("	ExternalIP=@ExternalIP                                                 \n");
                sb.Append("	,LocalIP=@LocalIP                                                       \n");
                sb.Append("	,LastUpdateTime=getdate()                                       \n");
                sb.Append("	where UserName=@UserName and LoginMAC=@LoginMAC;                                                \n");
                sb.Append("	insert t_logincur(Creator,Guid,UserName,LoginMAC,ExternalIP,LocalIP,LoginTime,LastUpdateTime)        \n");
                sb.Append("	select top 1  'SYS',newid(),@UserName,@LoginMAC,@ExternalIP,@LocalIP,getdate(),getdate()               \n");
                sb.Append("	from t_user where not exists(select 1 from t_logincur where UserName=@UserName and LoginMAC=@LoginMAC) \n");
                return sb.ToString();
            }
        }

        private bool IsAllowLogin() {
            using (var db = new Database()) {
                var macs = db.Fetch<t_mac>("select * from t_mac");
                var c = macs.Count();
                if (c < 1)
                    return true;
                var ks = macs.Where(k => string.Compare(k.Mac, LocalMAC, true) == 0).ToList();
                return ks != null && ks.Count > 0;
            }
        }

        private void RegSelfLogin() {
            try {
                SqlHelper.ExecuteNonQuery(ConnString, CommandType.Text, Sql_AddLogin,
                    new SqlParameter("@LoginMAC", LocalMAC),
                    new SqlParameter("@ExternalIP", RemoteIP),
                    new SqlParameter("@LocalIP", LocalIP),
                    new SqlParameter("@UserName", CurUser)
                    );
                var talive = new Thread(() => { RegSelfAlive(); });
                talive.IsBackground = true;
                talive.Start();
            }
#if !DEBUG
            catch { }
#else
 catch (Exception) { throw; }
#endif
        }

        private void RegSelfAlive() {
            try {
                while (true) {
                    Thread.Sleep(1000 * 60 * 2);
                    SqlHelper.ExecuteNonQuery(ConnString, CommandType.Text, Sql_AddLogin,
                        new SqlParameter("@LoginMAC", LocalMAC),
                        new SqlParameter("@ExternalIP", RemoteIP),
                        new SqlParameter("@LocalIP", LocalIP),
                        new SqlParameter("@UserName", CurUser)
                        );
                }
            } catch {
            }
        }

        private void barChkSys_CheckedChanged(object sender, ItemClickEventArgs e) {
            barChkTaobao.Checked = !this.barChkSys.Checked;
            if (barChkTaobao.Checked) {
                this.navMenu.PaintStyleKind = NavBarViewKind.ExplorerBar;
                navMenu.SkinExplorerBarViewScrollStyle = SkinExplorerBarViewScrollStyle.ScrollBar;
                spliter.Visible = true;
                foreach (NavBarGroup gp in navMenu.Groups)
                    gp.Expanded = true;
                OptConfig.Set<string>("Menu", "Taobao");
            }
        }

        private void barChkTaobao_CheckedChanged(object sender, ItemClickEventArgs e) {
            barChkSys.Checked = !this.barChkTaobao.Checked;
            if (barChkSys.Checked) {
                spliter.Visible = false;
                this.navMenu.PaintStyleKind = NavBarViewKind.NavigationPane;
                OptConfig.Set<string>("Menu", "System");
            }
        }

        private void barBtnSysInfo_ItemClick(object sender, ItemClickEventArgs e) {
            //关于
            Ultra.Surface.Lanuch.Lanucher.Start("Ultra.Login.SysInfoView").ShowDialog();
        }

        private void barBtnExit_ItemClick(object sender, ItemClickEventArgs e) {
            IsLogOff = false;
            Close();
        }

        private void barBtnLogoff_ItemClick(object sender, ItemClickEventArgs e) {
            IsLogOff = true;
            Close();
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e) {
            if (IsLogOff == null)
                IsLogOff = false;
            if (IsLogOff.Value) {
                //if (MsgBox.ShowYesNoMessage("注销确认", "确定要注销吗?") == System.Windows.Forms.DialogResult.No) {
                //    IsLogOff = false;
                //    e.Cancel = true;
                //    return;
                //}
                DialogResult = System.Windows.Forms.DialogResult.No;
            } else {
                if (MsgBox.ShowYesNoMessage("退出确认", "确定要退出吗?") == System.Windows.Forms.DialogResult.No) { e.Cancel = true; IsLogOff = false; }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void barBtnSysMnu_ItemClick(object sender, ItemClickEventArgs e) {
            var vw = new MenuView();
            vw.MdiParent = this;
            vw.Show();
        }

        private void LoadMenu() {
            this.navMenu.Groups.Clear();
            var menu = Db.FirstOrDefault<t_menu>(" where version='1.0'");
            if (string.IsNullOrEmpty(menu.MenuJson))
                return;
            //解析菜单Json
            var menus = ObjectHelper.DeSerialize<List<MenuData>>(menu.MenuJson);
            if (menus == null || menus.Count < 1)
                return;
            foreach (var g in menus) {
                var gp = this.navMenu.Groups.Add();
                gp.Caption = g.MenuGrpName;
                gp.Tag = g;
                CanAddMenuGrp(gp);
                if (g.MenuItems == null)
                    continue;
                foreach (var m in g.MenuItems) {
                    var lnk = new DevExpress.XtraNavBar.NavBarItem(m.MenuName);
                    gp.ItemLinks.Add(lnk);
                    lnk.Visible = CanAddLink(m);
                    lnk.Tag = m;
                }
            }
        }

        private void navMenu_SizeChanged(object sender, EventArgs e) {

        }

        private void spliter_SplitterMoved(object sender, SplitterEventArgs e) {
            OptConfig.Set<int>("MenuWidth", navMenu.Width);
        }

        private void navMenu_LinkClicked(object sender, NavBarLinkEventArgs e) {
            var md = e.Link.Item.Tag as MenuItemData;
            if (null == md)
                return;
            if (null == md)
                return;
            var vw = this.Cacher.Get<BaseSurface>(md.MenuClsName + "-" + md.MenuAsmName);
            if (null != vw && !vw.IsDisposed) {
                vw.Activate();
                return;
            }
            vw = Lanucher.Start(md.MenuClsName, md.MenuAsmName);
            if (null == vw)
                return;
            vw.Text = md.MenuName;
            vw.MdiParent = this;
            this.Cacher.Put<BaseSurface>(md.MenuClsName + "-" + md.MenuAsmName, vw);
            vw.Show();
            vw.Activate();
        }

        private List<t_rolepermit> MCD = null;

        private bool CanAddMenuGrp(NavBarGroup grp) {
            var mcd = null != MCD ? MCD : (MCD = this.Cacher.Get<List<t_rolepermit>>("Permission"));
            if ("admin".EqualIgnorCase(CurUser))
                return grp.Visible = true;
            if (null == mcd || mcd.Count < 1)
                return grp.Visible = false;
            return grp.Visible = mcd.Where(k => k.MenuGrpName == grp.Caption && k.IsEnabled).Count() > 0;
        }

        private bool CanAddLink(MenuItemData lnkmd) {
            if ("admin".EqualIgnorCase(CurUser))
                return true;
            if (MCD == null)
                return false;
            return MCD.Where(k => k.ClsName == lnkmd.MenuClsName && k.AsmName == lnkmd.MenuAsmName
                && k.IsEnabled).Count() > 0;
        }

        private void barBtnEditPassword_ItemClick(object sender, ItemClickEventArgs e) {
            var vw = new EditPassWord();
            Lanucher.InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                MsgBox.ShowMessage("", "密码修改成功,需要重新登录!");
                barBtnLogoff_ItemClick(null, null);
            }
        }

    }
}
