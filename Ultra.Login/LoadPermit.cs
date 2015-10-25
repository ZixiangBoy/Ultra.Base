using DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ultra.Surface.Common;
using Ultra.Surface.Interfaces;

namespace Ultra.Login {
    public static class LoadPermit {
        /// <summary>
        /// 加载权限
        /// </summary>
        /// <param name="vw"></param>
        public static void RequestPermit(this Ultra.Surface.Form.BaseSurface vw) {
            if (null == vw)
                return;
            var fulclsname = vw.GetType().FullName;
            var cur = vw.GetCurUser<t_user>();
            var mcd = vw.Cacher.Get<List<t_rolepermit>>("Permission");

            if (null == mcd && !cur.UserName.Equals("admin"))
                return;
            var isp = vw as ISurfacePermission;
            if (null == isp)
                return;
            try {
                try {
                    var tbi = isp.ToolBarItems;
                    if (null != tbi && tbi.Count > 0) {
                        if (!cur.UserName.Equals("admin")) {
                            var mc = mcd.Where(k => k.CtlType == (int)EnCtlType.ToolBarItems && k.ClsName ==
                                 vw.GetType().FullName
                                 );
                            var tbis = tbi.Where(j => mc.Any(k => k.ControlName == j.Name)).ToList();
                            tbis.ForEach
                            (j => {
                                j.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            });
                            tbi.Where(k => !mc.Any(j => j.ControlName == k.Name)).ToList().ForEach(k => {
                                k.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            });
                        } else {
                            tbi.ForEach(k => k.Visibility = DevExpress.XtraBars.BarItemVisibility.Always);
                        }
                    }
                } catch { }
                try {
                    var tbi = isp.Grids;
                    if (null != tbi && tbi.Count > 0) {
                        if (!cur.UserName.Equals("admin")) {
                            var mc = mcd.Where(k => k.CtlType == (int)EnCtlType.Grids && k.ClsName ==
                                 vw.GetType().FullName
                                 );//gridview
                            var mch = tbi.Where(j => mc.Any(k => k.ControlName == j.Gv.Name));//gridview
                            var cols = mcd.Where(k => mch.Any(j => k.ParentCtlName != null && j.Gv.Name == k.ParentCtlName)).ToList();

                            var mcol = cols.Where(k => k.CtlType == (int)EnCtlType.GridCol && k.IsEnabled).ToList();//gridcolumn

                            var kts = mch.ToList();
                            foreach (var k in kts) {
                                foreach (DevExpress.XtraGrid.Columns.GridColumn col in k.Gv.Columns) {
                                    var ktmch = mcol.Where(t => t.ControlName == col.Name && t.ClsName == fulclsname && t.IsEnabled).FirstOrDefault();
                                    col.Visible = null != ktmch;
                                }
                            }
                        } else {
                            //tbi.ForEach(k => { 

                            //});
                        }
                    }
                } catch { }
                try {

                    var tbn = isp.ButtonItems;
                    if (null != tbn && tbn.Count > 0) {
                        if (!cur.UserName.Equals("admin")) {
                            var mc = mcd.Where(k => k.CtlType == (int)EnCtlType.ButtonItems && k.ClsName == vw.GetType().FullName
                                && k.IsEnabled);
                            tbn.Where(k => mc.Any(j => j.ControlName == k.Name)).ToList().ForEach
                                (k => {
                                    k.Visible = true;
                                });
                            tbn.Where(k => !mc.Any(j => j.ControlName == k.Name)).ToList().ForEach
                                (k => {
                                    k.Visible = false;
                                });
                        }
                    }
                } catch { }

            } catch { }
        }
    }
}
