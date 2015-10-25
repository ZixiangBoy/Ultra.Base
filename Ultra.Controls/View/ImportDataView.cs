using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.Surface.Common;
using Ultra.Surface.Extend;

namespace Ultra.Controls.View {
    public partial class ImportDataView : DialogViewEx {
        public ImportDataView() {
            InitializeComponent();
            this.fileBrowser1.OFDlg.Filter = FileFilter;
        }

        [Browsable(true)]
        [Category("Ultra")]
        [Description("加载导入数据的Grid")]
        public Ultra.Surface.Controls.GridControlEx GridControl { get; set; }


        [Browsable(true)]
        [Category("Ultra")]
        [Description("验证数据按钮按下时触发事件")]
        public event EventHandler<EventArgs> CheckImportData;

        [Browsable(true)]
        [Category("Ultra")]
        [Description("导入按钮按下时触发事件")]
        public event EventHandler<EventArgs> ImportData;

        [Browsable(true)]
        [Category("Ultra")]
        [Description("右键菜单移除选所选行完成后触发事件")]
        public event EventHandler<EventArgs> AfterRemoveFocusRow;

        private string _ExportTemplateCol = "验证结果";

        [Browsable(true)]
        [Category("Ultra")]
        [Description("生成模板时不导出的列的列Caption,多列请用，号隔开")]
        public string ExportTemplateCol { get { return _ExportTemplateCol; } set { _ExportTemplateCol = value; } }

        private string _FileFilter = "*.xls|*.xls|*.xlsx|*.xlsx";

        [Browsable(true)]
        [Category("Ultra")]
        [Description("打开文件对话框的Filter设置")]
        public string FileFilter { get { return _FileFilter; } set { _FileFilter = value; } }

        /// <summary>
        /// 获取数据导入时的名称和FieldName集
        /// </summary>
        public Dictionary<string, string> FieldsMapper {
            get {
                if (GridControl == null)
                    return null;
                DevExpress.XtraGrid.Views.Grid.GridView gv = GridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                if (null == gv)
                    return null;
                var strs = ExportTemplateCol.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                List<DevExpress.XtraGrid.Columns.GridColumn> gcEx = new List<DevExpress.XtraGrid.Columns.GridColumn>(gv.Columns.Count);
                bool b = strs != null && strs.Count > 0;
                Dictionary<string, string> dic = new Dictionary<string, string>(gv.Columns.Count);
                foreach (DevExpress.XtraGrid.Columns.GridColumn gc in gv.Columns) {
                    if (!gc.Visible)
                        continue;
                    if (b && strs.Where(j => j.Equals(gc.Caption)).Count() > 0)
                        continue;
                    if (!dic.ContainsKey(gc.Caption))
                        dic.Add(gc.FieldName,gc.Caption);
                }
                return dic;
            }
        }

        /// <summary>
        /// 生成导出模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCtl1_Click(object sender, EventArgs e) {
            if (GridControl == null)
                return;
            var strs = ExportTemplateCol.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<DevExpress.XtraGrid.Columns.GridColumn> gcEx = new List<DevExpress.XtraGrid.Columns.GridColumn>(5);
            if (strs != null || strs.Length > 0) {
                DevExpress.XtraGrid.Views.Grid.GridView gv = this.GridControl.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                if (null != gv)
                    foreach (var str in strs)
                        foreach (DevExpress.XtraGrid.Columns.GridColumn gc in gv.Columns)
                            if (gc.Caption.Equals(str) && gc.Visible) {
                                gc.Visible = false;
                                gcEx.Add(gc);
                            }
            }
            var ds = GridControl.DataSource;
            GridControl.DataSource = null;
            GridControl.GridExportXls();
            gcEx.ForEach(j => j.Visible = true);
            GridControl.DataSource = ds;
        }

        /// <summary>
        /// 验证数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChk_Click(object sender, EventArgs e) {
            if (null != CheckImportData)
                CheckImportData(sender, e);
        }

        /// <summary>
        /// 导出当前数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExp_Click(object sender, EventArgs e) {
            if (GridControl == null)
                return;
            GridControl.GridExportXls();
        }

        private void btnImp_Click(object sender, EventArgs e) {
            if (null != ImportData)
                ImportData(sender, e);
        }

        private void barBtnDelFocus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (null == GridControl)
                return;
            if (MsgBox.ShowYesNoMessage("","确定要移除所选行吗?") == System.Windows.Forms.DialogResult.Yes) {
                GridControl.RemoveSelected();
                GridControl.RefreshDataSource();
                if (null != AfterRemoveFocusRow)
                    AfterRemoveFocusRow(sender, e);
            }
        }


        protected EnImportDataMode _ImportMode = EnImportDataMode.AddNoExists;

        /// <summary>
        /// 导入模式
        /// </summary>
        public EnImportDataMode ImportMode { get { return _ImportMode; } set { _ImportMode = value; } }

        /// <summary>
        /// 导入模式
        /// </summary>
        public enum EnImportDataMode : int {
            /// <summary>
            /// 替换模式
            /// </summary>
            ReplaceMode = 1,

            /// <summary>
            /// 追加模式
            /// </summary>
            AddNoExists = 2,
        }

    }
}
