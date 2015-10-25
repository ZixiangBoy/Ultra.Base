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
using Ultra.Web.Core.Common;

namespace Ultra.LoginBind
{
    public partial class EditView : DialogViewEx
    {
        public EditView()
        {
            InitializeComponent();
        }

        List<t_mac> LstMac;

        private void EditView_Load(object sender, EventArgs e)
        {
            using (var db = new Database())
            {
                LstMac =db.Fetch<t_mac>("select * from t_mac");
                memedt.Lines = LstMac.Select(k => k.Mac).ToArray();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowYesNoMessage(null, "确定要保存吗?") == System.Windows.Forms.DialogResult.No)
                return;
            var usr = GetCurUser<t_user>();
            for (int i = 0; i < memedt.Lines.Length; i++)
            {
                memedt.Lines[i] = memedt.Lines[i].Replace("-", string.Empty);
            }
            var exp = memedt.Lines.ToList().Where(k=>!string.IsNullOrEmpty(k.Trim().Replace("\r",string.Empty).Replace("\n",string.Empty))).Except(LstMac.Select(k => k.Mac).ToList()).ToList();
            var ndel = LstMac.Select(k => k.Mac).ToList().Except(memedt.Lines.ToList().Where(k => !string.IsNullOrEmpty(k.Trim().Replace("\r", string.Empty).Replace("\n", string.Empty))).ToList()).ToList();
            if (null != exp && exp.Count > 0)
            {
                using (var db = new Database())
                {
                    exp.ForEach(k =>
                    {

                        db.Save(new t_mac
                        {
                            Guid = Guid.NewGuid(),
                            IsUsing = true,
                            Mac = k,
                            Creator = usr.UserName,
                            CreateDate=TimeSync.Default.CurrentSyncTime
                        });
                    });
                }
            }
            if (null != ndel && ndel.Count > 0)
            {
                var ins = ndel.Select(k=>"'"+k+"'").Aggregate((s1,s2)=>  s1+","+s2).ToString();
                SqlHelper.ExecuteNonQuery(ConnString,CommandType.Text,
                    string.Format("delete from t_mac where mac in ({0})", ins));
            }
            //MsgBox.ShowMessage(null, "保存成功!");
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
