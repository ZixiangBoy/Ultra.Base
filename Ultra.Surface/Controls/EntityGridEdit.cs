using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Drawing;

namespace Ultra.Surface.Controls {

    public class ReturnDataEventArg<T> : EventArgs {
        /// <summary>
        /// 入参
        /// </summary>
        public virtual List<T> InData { get; set; }
        /// <summary>
        /// 出参
        /// </summary>
        public virtual List<T> OutData { get; set; }
    }

    //[Serializable]
    [ToolboxItem(false)]//设置此类在工具箱中不可见
    [DesignTimeVisible(false)]//设置设计时此类不可见
    public class LabelGridEditColItemEx : Component {
        public string Caption { get; set; }
        public string FieldName { get; set; }
    }

    //[Serializable]
    public class NameFieldCollection : System.Collections.CollectionBase//从集合基类继
    {
        public LabelGridEditColItemEx this[int index] {
            get { return List[index] as LabelGridEditColItemEx; }
            set { List[index] = value; }
        }
        public int Add(object value) {
            return this.List.Add(value);
        }
    }

    [Serializable]
    public class LabelGridEditColItem {
        public string Caption { get; set; }
        public string FieldName { get; set; }
    }

    public class LabelGridEdit : GridLookUpEdit {
        public LabelGridEdit()
            : base() {
            base.EditValue = null;
            base.Text = string.Empty;
            base.Properties.TextEditStyle =
                DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            base.Properties.View.OptionsBehavior.Editable = false;
            base.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            base.Properties.View.Appearance.SelectedRow.BackColor = Color.FromArgb(70, 80, 20, 20);
            base.Properties.View.Appearance.FocusedRow.BackColor = Color.FromArgb(70, 80, 20, 20);
            base.Properties.NullText = string.Empty;
            base.Properties.Buttons.Clear();
            //LabelButton = new EditorButton(ButtonPredefines.Glyph);
            //LabelButton.IsLeft = true;
            //LabelButton.Visible = true;
            //LabelButton.Width = 50;
            //LabelButton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            //base.Properties.Buttons.Add(LabelButton);
            base.Properties.Buttons.Add(new EditorButton {
                Kind = ButtonPredefines.Combo
            });

            base.Properties.Buttons.Add(_ClearButton = new DevExpress.XtraEditors.Controls.EditorButton {
                Caption = ClearButtonText
                                                                                                            ,
                Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete
                                                                                                            ,
                ToolTip = ClearButtonText
                                                                                                            ,
                Visible = ShowClearButton
            });

            base.Text = string.Empty;
            base.Properties.ButtonClick += Properties_ButtonClick;
        }


        void Properties_ButtonClick(object sender, ButtonPressedEventArgs e) {
            //if (e.Button.Caption == LabelButton.Caption)
            //    this.SelectAll();
            if (e.Button.Caption == ClearButtonText) {
                Text = string.Empty;
                base.EditValue = null;
                base.Properties.View.FocusedRowHandle = -99997;
            } else {
                base.ShowPopup();
            }
        }

        private string _ClearButtonText = "清除所选";
        private bool _ShowClearButton = false;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit fProperties;
        private DevExpress.XtraGrid.Views.Grid.GridView fPropertiesView;


        /// <summary>
        /// 绑定用于显示的字段
        /// </summary>
        [
        Description("绑定用于显示的字段")
        , Browsable(true)
        , Category("Ultra")
        ]
        public virtual string DisplayMember {
            get { return base.Properties.DisplayMember; }
            set { base.Properties.DisplayMember = value; }
        }

        protected List<LabelGridEditColItem> _ColItems = new List<LabelGridEditColItem>();

        /// <summary>
        /// 绑定用于显示的字段与列名称列表
        /// </summary>
        [
           Description("绑定用于显示的字段与列名称列表")
           , Browsable(true)
           , Category("Ultra"), Obsolete("不再建议使用，请换用ColumnItemsEx")
        ]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        public virtual List<LabelGridEditColItem> ColumnItems {
            get { return _ColItems; }
            set { _ColItems = value; }
        }

        protected System.Collections.ObjectModel.Collection<LabelGridEditColItemEx> _ColItemsEx =
            new System.Collections.ObjectModel.Collection<LabelGridEditColItemEx>();

        /// <summary>
        /// 绑定用于显示的字段与列名称列表
        /// </summary>
        [
           Description("绑定用于显示的字段与列名称列表")
           , Browsable(true)
           , Category("Ultra")
        , Editor(typeof(CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))
        ]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        public virtual System.Collections.ObjectModel.Collection<LabelGridEditColItemEx> ColumnItemsEx {
            get { return _ColItemsEx; }
            set { _ColItemsEx = value; }
        }

        /// <summary>
        /// 绑定用于表示值的字段
        /// </summary>
        [
        Description("绑定用于表示值的字段")
        , Browsable(true)
        , Category("Ultra")
        ]
        public virtual string ValueMember {
            get { return base.Properties.ValueMember; }
            set { base.Properties.ValueMember = value; }
        }


        /// <summary>
        /// 列显示名称
        /// </summary>
        [
        Description("列显示名称")
        , Browsable(true)
        , Category("Ultra")
        ]
        public virtual string ColumnCaption { get; set; }

        /// <summary>
        /// 清除所选按钮显示的文字
        /// </summary>
        [
        Description("是否显示清除所选按钮")
        , DefaultValue(false)
        , Browsable(true)
        , Category("Ultra")
        ]
        public bool ShowClearButton {
            get { return _ShowClearButton; }
            set { _ShowClearButton = value; _ClearButton.Visible = value; }
        }

        /// <summary>
        /// 清除所选按钮显示的文字
        /// </summary>
        [
        Description("清除所选按钮显示的文字")
        , Browsable(true)
        , Category("Ultra")
        ]
        public virtual string ClearButtonText {
            get { return _ClearButtonText; }
            set { _ClearButtonText = value; }
        }

        private DevExpress.XtraEditors.Controls.EditorButton _ClearButton = null;

        /// <summary>
        /// 清除所选按钮按下时触发事件
        /// </summary>
        [
        Description("清除所选按钮按下时触发事件")
        , Browsable(true)
        , Category("Ultra")
        ]
        public event EventHandler OnClearButtonClick;

        ///// <summary>
        ///// 标签按钮
        ///// </summary>
        //[Description("标签按钮"),
        //Browsable(true),
        //Category("Ultra")]
        //public EditorButton LabelButton {
        //    get;
        //    private set;
        //}

        ///// <summary>
        ///// 标签文本
        ///// </summary>
        //[Description("标签文本"),
        //Browsable(true),
        //Category("Ultra")]
        //public string LabelText {
        //    get { return null == LabelButton ? string.Empty : LabelButton.Caption; }
        //    set {
        //        if (null != LabelButton) {
        //            LabelButton.Caption = value;
        //        }
        //        base.Invalidate();
        //    }
        //}

    }

    public class EntityGridEditventArg<T> : EventArgs {
        public virtual T Value { get; set; }
    }

    public class EntityGridEdit<T> : LabelGridEdit where T : class {
        public EntityGridEdit()
            : base() {
            base.EditValueChanged += BaseGridLookUpEditAdv_EditValueChanged;
        }

        void BaseGridLookUpEditAdv_EditValueChanged(object sender, EventArgs e) {
            RaiseSelectedValueChanged();
        }

        public virtual void RaiseSelectedValueChanged() {
            if (null != OnSelectedValueChanged)
                OnSelectedValueChanged(this, new EntityGridEditventArg<T> {
                    Value = GetSelectedValue()
                });
        }

        /// <summary>
        /// 当当前选中的项发生改变时触发事件,事件参数Value包含当前选中的项
        /// </summary>
        [
        Description("当当前选中的项发生改变时触发事件,事件参数Value包含当前选中的项")
        , Browsable(true)
        , Category("Ultra")
        ]
        public event EventHandler<EntityGridEditventArg<T>> OnSelectedValueChanged;


        /// <summary>
        /// 获取选中项
        /// </summary>
        /// <returns></returns>
        public virtual T GetSelectedValue() { return default(T); }

        /// <summary>
        /// 设置选中项
        /// </summary>
        /// <param name="vl"></param>
        /// <returns></returns>
        public virtual T SetSelectedValue(T vl) {
            if (null == vl) {
                base.EditValue = null;
                base.Text = string.Empty;
                base.Properties.View.FocusedRowHandle = -99997;
                return vl;
            }
            return vl;
        }

        #region Design

        /// <summary>
        /// 获取、设置 选中的项
        /// </summary>
        [
        Description("获取、设置 选中的项")
        , Browsable(true)
        , Category("Ultra")
        ]
        public T SelectedValue {
            get {
                return GetSelectedValue();
            }
            set {
                if (null == value) {
                    base.EditValue = null;
                    base.Text = string.Empty;
                    base.Properties.View.FocusedRowHandle = -99997;
                    return;
                } else
                    SetSelectedValue(value);
            }
        }

        #endregion

        /// <summary>
        /// 子类实现的获取数据的方法
        /// </summary>
        /// <returns></returns>
        protected virtual List<T> GetData() {
            return null;
        }

        /// <summary>
        /// 加载、绑定数据
        /// </summary>
        /// <returns></returns>
        public virtual List<T> LoadData() {
            var ets = GetData();
            base.Properties.DataSource = ets;
            base.Properties.View.FocusedRowHandle = -99997;
            AfterLoadData(ets);
            return ets;
        }

        /// <summary>
        /// 自定义过滤
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public virtual List<T> FilterData(IEnumerable<T> ds) {
            return ds.ToList();
        }

        public virtual void AfterLoadData(List<T> ds) {
            base.Properties.View.Columns.Clear();
            if (null == ColumnItemsEx || ColumnItemsEx.Count < 1) {
                if (ColumnItems == null || ColumnItems.Count < 1) {
                    DevExpress.XtraGrid.Columns.GridColumn gridColumn1 =
                        new DevExpress.XtraGrid.Columns.GridColumn();
                    gridColumn1.Caption = base.ColumnCaption;
                    gridColumn1.FieldName = base.DisplayMember;

                    gridColumn1.OptionsColumn.AllowEdit = false;
                    gridColumn1.Visible = true;
                    gridColumn1.VisibleIndex = 0;

                    base.Properties.View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { 
                gridColumn1
            });
                } else {
                    var cols = new DevExpress.XtraGrid.Columns.GridColumn[ColumnItems.Count];
                    for (int i = 0; i < ColumnItems.Count; i++) {
                        var gridColumn1 =
                         new DevExpress.XtraGrid.Columns.GridColumn();
                        gridColumn1.Caption = ColumnItems[i].Caption;
                        gridColumn1.FieldName = ColumnItems[i].FieldName;

                        gridColumn1.OptionsColumn.AllowEdit = false;
                        gridColumn1.Visible = true;
                        gridColumn1.VisibleIndex = 0;
                        cols[i] = gridColumn1;
                    }
                    base.Properties.View.Columns.AddRange(cols);
                }
            } else {
                var cols = new DevExpress.XtraGrid.Columns.GridColumn[ColumnItems.Count];
                for (int i = 0; i < ColumnItemsEx.Count; i++) {
                    var gridColumn1 =
                     new DevExpress.XtraGrid.Columns.GridColumn();
                    gridColumn1.Caption = ColumnItems[i].Caption;
                    gridColumn1.FieldName = ColumnItems[i].FieldName;

                    gridColumn1.OptionsColumn.AllowEdit = false;
                    gridColumn1.Visible = true;
                    gridColumn1.VisibleIndex = 0;
                    cols[i] = gridColumn1;
                }
                base.Properties.View.Columns.AddRange(cols);
            }

            base.Properties.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            base.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            base.Properties.View.OptionsBehavior.Editable = false;
            base.Properties.View.OptionsSelection.EnableAppearanceFocusedCell = false;
            base.Properties.View.OptionsView.ShowGroupPanel = false;
            base.Properties.View.OptionsView.ShowAutoFilterRow = true;
        }
    }

    public class EntityGridEditEx<T> : EntityGridEdit<T> where T : class {
        public EntityGridEditEx()
            : base() {
            base.DisplayMember = string.Empty;
            base.ValueMember = "Guid";
        }
        public override T GetSelectedValue() {
            try {
                if (base.EditValue == null || string.IsNullOrEmpty(base.EditValue.ToString())
                   )
                    return null;
                var ds = base.Properties.DataSource as List<T>;
                if (null == ds)
                    return base.GetSelectedValue();
                return ds.Where(k => k.GetType().GetProperty("Guid").GetValue(k, null).ToString() == (base.EditValue).ToString()).SingleOrDefault();
            } catch { return default(T); }
        }

        public override T SetSelectedValue(T vl) {
            try {
                if (null == vl)
                    return base.SetSelectedValue(vl);
                this.EditValue = vl.GetType().GetProperty("Guid").GetValue(vl, null);

                var kt = base.SetSelectedValue(vl);
                var ds = base.Properties.DataSource as List<T>;
                if (null != ds) {
                    var mtch = ds.Where(k => k.GetType().GetProperty("Guid").GetValue(k, null).ToString() ==
                        k.GetType().GetProperty("Guid").GetValue(kt, null).ToString()).SingleOrDefault();
                    base.EditValue = null == mtch ? null :
                        mtch.GetType().GetProperty(base.ValueMember.ToString()).GetValue(mtch, null);
                    return mtch;
                }
                return kt;
            } catch { return default(T); }
        }
    }
}
