using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Ultra.Surface.Extend;
using Ultra.Surface.Common;
using System.Data;

namespace Ultra.Surface.Controls
{
    public class GridControlEx : GridControl
    {
        public GridControlEx()
            : base()
        {
            base.DataSourceChanged += UltraGirdControl_DataSourceChanged;
            ShowRowNumber = true;
            base.MouseDoubleClick += new MouseEventHandler(GridControlEx_MouseDoubleClick);
        }

        private GridView gridView1;

        protected int defaultIndicatorWidth = Int32.MinValue;

        void UltraGirdControl_DataSourceChanged(object sender, EventArgs e)
        {
            if (null == DefGridView) return;
            if (null != base.DataSource)
            {
                IList ListDataSource = base.DataSource as IList;
                if (null != ListDataSource) {
                    if (defaultIndicatorWidth == Int32.MinValue)
                        defaultIndicatorWidth = DefGridView.IndicatorWidth;//保存原始的指示器宽度
                    if (this.ShowIndicator && this.ShowRowNumber) {
                        DefGridView.IndicatorWidth = TextRenderer.MeasureText(ListDataSource.Count.ToString(), this.Font).Width + 30;
                    } else
                        DefGridView.IndicatorWidth = defaultIndicatorWidth;
                } else {
                    DataTable DataSource = base.DataSource as DataTable;
                    if (DataSource != null) {
                        if (defaultIndicatorWidth == Int32.MinValue)
                            defaultIndicatorWidth = DefGridView.IndicatorWidth;//保存原始的指示器宽度
                        if (this.ShowIndicator && this.ShowRowNumber) {
                            DefGridView.IndicatorWidth = TextRenderer.MeasureText(DataSource.Rows.Count.ToString(), this.Font).Width + 30;
                        } else
                            DefGridView.IndicatorWidth = defaultIndicatorWidth;
                    }
                }
            }
            DefGridView.BestFitColumns();
        }

        #region Public Methods

        /// <summary>
        /// 不选中任何行
        /// </summary>
        public void ReleaseFocusedRow()
        {
            if (null != DefGridView)
                DefGridView.ReleaseFocusedRow();
        }

        #endregion

        #region Desinger

        /// <summary>
        /// 是否显示分组面板
        /// </summary>
        [
        Description("是否显示分组面板"),
        DefaultValue(false),
        Browsable(true),
        Category("Ultra")
        ]
        public bool ShowGroupPanel
        {
            get
            {
                if (null == DefGridView) return false;
                return DefGridView.OptionsView.ShowGroupPanel;
            }
            set
            {
                if (null == DefGridView) return;
                DefGridView.OptionsView.ShowGroupPanel = value;
            }
        }

        [
        Description("行背景色自动套用字段名称"),
        DefaultValue(""),
        Browsable(true),
        Category("Ultra")
        ]
        public string ColorFieldName { get; set; }

        /// <summary>
        /// 是否显示行指示器
        /// </summary>
        [
        Description("是否显示行指示器"),
        DefaultValue(false),
        Browsable(true),
        Category("Ultra")
        ]
        public bool ShowIndicator
        {
            get
            {
                if (null == DefGridView) return false;
                return DefGridView.OptionsView.ShowIndicator;
            }
            set
            {
                if (null == DefGridView) return;
                DefGridView.OptionsView.ShowIndicator = value;
            }
        }

        /// <summary>
        /// 是否显示号,要显示行号首先要求 ShowIndicator为true
        /// </summary>
        [
        Description("是否显示号,要显示行号首先要求 ShowIndicator为true"),
        DefaultValue(false),
        Browsable(true),
        Category("Ultra")
        ]
        public bool ShowRowNumber { get; set; }


        /// <summary>
        /// 双击单元格时触发事件
        /// </summary>
        [Category("DoubleBullet")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("双击单元格时触发事件")]
        public event EventHandler<MouseEventArgs> RowCellDoubleClick;

        #endregion

        protected DevExpress.XtraGrid.Views.Grid.GridView DefGridView { get; set; }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            var vw = DefGridView = base.DefaultView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (null != vw)
            {
                vw.OptionsView.ShowGroupPanel = false;// this.ShowGroupPanel;
                vw.OptionsView.ColumnAutoWidth = false;
                vw.OptionsView.ShowIndicator = this.ShowIndicator;
                vw.PopupMenuShowing -= vw_PopupMenuShowing;
                vw.PopupMenuShowing += vw_PopupMenuShowing;
                vw.CustomDrawRowIndicator -= vw_CustomDrawRowIndicator;
                vw.CustomDrawRowIndicator += vw_CustomDrawRowIndicator;
                vw.RowStyle -= vw_RowStyle; vw.RowStyle += vw_RowStyle;
                vw.OptionsView.ShowAutoFilterRow = true;
                vw.MouseDown += vw_MouseDown;
                vw.KeyDown += vw_KeyDown;
                vw.Appearance.SelectedRow.BackColor = Color.FromArgb(70, 80, 20, 20);
                vw.Appearance.FocusedRow.BackColor = Color.FromArgb(70, 80, 20, 20);
                vw.FocusedRowHandle = -1;

                DefGridView.BestFitColumns();
            }
        }

        void vw_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (string.IsNullOrEmpty(ColorFieldName)) return;
            if (e.RowHandle < 0) return;
            if (DefGridView.GetRowCellValue(e.RowHandle, ColorFieldName) == null) return;
            e.Appearance.BackColor = DefGridView.GetRowCellValue(e.RowHandle, ColorFieldName).ToString().ToColor();
        }

        void vw_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control) & e.KeyCode == Keys.C)
            {
                GridView gridView = (GridView)sender;
                var value = gridView.GetFocusedRowCellValue(gridView.FocusedColumn);
                Clipboard.SetDataObject(value == null ? "" : value.ToString());
                e.Handled = true;
            }
        }

        void vw_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                GridViewColumnMenu menu = e.Menu as GridViewColumnMenu;
                if (menu != null)
                {
                    foreach (DevExpress.Utils.Menu.DXMenuItem item in menu.Items)
                    {
                        //禁止显示隐藏列
                        if (item.Caption ==
                            GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnColumnCustomization))
                            item.Enabled = false;
                        //禁止GridStringId.MenuColumnGroup=根据此列分组
                        if (item.Caption ==
                            GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnGroup))
                            item.Enabled = false;
                        //禁止GridStringId.MenuColumnGroupBox=分组依据框
                        if (item.Caption ==
                            GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnGroupBox))
                            item.Enabled = false;
                        //禁止GridStringId.MenuColumnRemoveColumn=移除列
                        if (item.Caption ==
                            GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnRemoveColumn))
                            item.Enabled = false;
                        //禁止Show Group By Box
                        if (0 == string.Compare(
                            item.Caption,
                            GridLocalizer.Active.GetLocalizedString(GridStringId.MenuGroupPanelShow), true
                            ))
                            item.Visible = item.Enabled = false;
                        //Show Auto Filter Row
                        if (0 == string.Compare(item.Caption,
                            GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnAutoFilterRowShow), true))
                            item.Caption = "显示查询行";
                        if (0 == string.Compare(item.Caption,
                            GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnAutoFilterRowHide), true))
                            item.Caption = "隐藏查询行";
                        //禁止Show Find Panel
                        if (0 == string.Compare(item.Caption,
                            GridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnFindFilterShow), true))
                            item.Visible = item.Enabled = false;
                    }
                }
            }
        }

        void vw_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!ShowIndicator) return;
            if (!ShowRowNumber) return;
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {

                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        [
        Description("GridView双击事件"),
        Category("Ultra"),
        Browsable(true)
        ]
        public event EventHandler<System.Windows.Forms.MouseEventArgs> ViewMouseDoubleClick;

        void vw_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo ghi = gv.CalcHitInfo(e.X, e.Y);
            if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 2)
            {
                if (ghi.InRow)
                {
                    if (null != ViewMouseDoubleClick)
                        ViewMouseDoubleClick(sender, e);
                }
            }
        }


        void GridControlEx_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridHitInfo info = base.MainView.CalcHitInfo(e.X, e.Y) as GridHitInfo;
            if (null == info) return;
            if (((e.Button == MouseButtons.Left) && (e.Clicks == 2)) && info.InRow && (null != this.RowCellDoubleClick))
                this.RowCellDoubleClick(sender, e);
        }

        /// <summary>
        /// 根据列值条件设置行颜色
        /// </summary>
        /// <param name="color"></param>
        /// <param name="fieldName"></param>
        /// <param name="matchVlu"></param>
        private void SetRowBackColor(Color color, string fieldName, object matchVlu)
        {
            if (null == DefGridView) return;
            DevExpress.XtraGrid.Columns.GridColumn col = null;
            foreach (DevExpress.XtraGrid.Columns.GridColumn item in DefGridView.Columns)
            {
                if (string.Compare(fieldName, item.FieldName) == 0)
                {
                    col = item;
                    break;
                }
            }
            if (col == null) return;

            DevExpress.XtraGrid.StyleFormatCondition[] formats = new DevExpress.XtraGrid.StyleFormatCondition[1];
            DevExpress.XtraGrid.StyleFormatCondition format = new DevExpress.XtraGrid.StyleFormatCondition();
            format.Appearance.Options.UseBackColor = true;
            format.Appearance.BackColor = color;
            format.ApplyToRow = true;
            format.Column = col;
            format.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            format.Value1 = matchVlu;
            formats[0] = format;
            DefGridView.FormatConditions.AddRange(formats);
        }

        private void InitializeComponent()
        {
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this;
            this.gridView1.Name = "gridView1";
            // 
            // GridControlEx
            // 
            this.MainView = this.gridView1;
            this.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
