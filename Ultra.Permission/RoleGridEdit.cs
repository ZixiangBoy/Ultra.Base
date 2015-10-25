using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbEntity;
using System.ComponentModel;
using System.Drawing.Design;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Drawing;
using Ultra.Surface.Controls;

namespace Ultra.Permission
{
    public class RoleGridEdit : EntityGridEdit<t_role>
    {
        protected override List<t_role> GetData()
        {
            using (var db = new PetaPoco.Database())
            {
                return db.Fetch<t_role>("where IsUsing=1");
            }
        }

        public override t_role GetSelectedValue()
        {
            if (base.EditValue == null || string.IsNullOrEmpty(base.EditValue.ToString()) ||
               base.Properties.View.FocusedRowHandle < 0
               ) return null;
            var ds = base.Properties.DataSource as List<t_role>;
            if (null == ds) return base.GetSelectedValue();
            return ds.Where(k => k.Guid ==Guid.Parse(base.EditValue.ToString())).SingleOrDefault();
        }

        public override t_role SetSelectedValue(t_role vl)
        {
            if (null == vl) return base.SetSelectedValue(vl);
            this.EditValue = vl.Guid;

            var kt = base.SetSelectedValue(vl);
            var ds = base.Properties.DataSource as List<t_role>;
            if (null != ds)
            {
                var mtch = ds.Where(k => k.Guid == kt.Guid).SingleOrDefault();
                if (null == mtch)
                    base.Properties.View.FocusedRowHandle = -99997;
            }
            return kt;
        }

        public RoleGridEdit() : base() {
            base.DisplayMember = "Name";
            base.ValueMember = "Guid";
        }
    } 

}
