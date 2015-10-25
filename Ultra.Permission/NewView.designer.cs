using DevExpress.XtraEditors;
namespace Ultra.Permission
{
    partial class NewView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnRightAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnRight = new DevExpress.XtraEditors.SimpleButton();
            this.btnleftall = new DevExpress.XtraEditors.SimpleButton();
            this.btnLeft = new DevExpress.XtraEditors.SimpleButton();
            this.roleGridEdit2 = new Ultra.Permission.RoleGridEdit();
            this.roleGridEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridalloc = new DevExpress.XtraGrid.GridControl();
            this.gvalloc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridunalloc = new DevExpress.XtraGrid.GridControl();
            this.gvunalloc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roleGridEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleGridEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridalloc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvalloc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridunalloc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvunalloc)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(3127, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3034, 6);
            this.btnOK.Text = "保存(&S)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(612, 460);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.gridunalloc);
            this.pnlFill.Controls.Add(this.gridalloc);
            this.pnlFill.Controls.Add(this.labelControl1);
            this.pnlFill.Controls.Add(this.btnRightAll);
            this.pnlFill.Controls.Add(this.btnRight);
            this.pnlFill.Controls.Add(this.btnleftall);
            this.pnlFill.Controls.Add(this.btnLeft);
            this.pnlFill.Controls.Add(this.roleGridEdit2);
            this.pnlFill.Size = new System.Drawing.Size(612, 414);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 414);
            this.pnlBottom.Size = new System.Drawing.Size(612, 46);
            // 
            // btnRightAll
            // 
            this.btnRightAll.Location = new System.Drawing.Point(271, 241);
            this.btnRightAll.Name = "btnRightAll";
            this.btnRightAll.Size = new System.Drawing.Size(75, 23);
            this.btnRightAll.TabIndex = 9;
            this.btnRightAll.Text = ">>";
            this.btnRightAll.Click += new System.EventHandler(this.btnRightAll_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(271, 203);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 10;
            this.btnRight.Text = ">";
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnleftall
            // 
            this.btnleftall.Location = new System.Drawing.Point(271, 165);
            this.btnleftall.Name = "btnleftall";
            this.btnleftall.Size = new System.Drawing.Size(75, 23);
            this.btnleftall.TabIndex = 11;
            this.btnleftall.Text = "<<";
            this.btnleftall.Click += new System.EventHandler(this.btnleftall_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(271, 127);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 12;
            this.btnLeft.Text = "<";
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // roleGridEdit2
            // 
            this.roleGridEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roleGridEdit2.ClearButtonText = "清除所选";
            this.roleGridEdit2.ColumnCaption = "名称";
            this.roleGridEdit2.DisplayMember = "Name";
            this.roleGridEdit2.EditValue = "";
            this.roleGridEdit2.Location = new System.Drawing.Point(73, 12);
            this.roleGridEdit2.Name = "roleGridEdit2";
            this.roleGridEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "清除所选", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "清除所选", null, null, true)});
            this.roleGridEdit2.Properties.DisplayMember = "Name";
            this.roleGridEdit2.Properties.NullText = "";
            this.roleGridEdit2.Properties.ValueMember = "Guid";
            this.roleGridEdit2.Properties.View = this.roleGridEdit2View;
            this.roleGridEdit2.SelectedValue = null;
            this.roleGridEdit2.ShowClearButton = true;
            this.roleGridEdit2.Size = new System.Drawing.Size(524, 20);
            this.roleGridEdit2.TabIndex = 6;
            this.roleGridEdit2.ValueMember = "Guid";
            this.roleGridEdit2.EditValueChanged += new System.EventHandler(this.roleGridEdit2_EditValueChanged);
            // 
            // roleGridEdit2View
            // 
            this.roleGridEdit2View.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.roleGridEdit2View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.roleGridEdit2View.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.roleGridEdit2View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.roleGridEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.roleGridEdit2View.Name = "roleGridEdit2View";
            this.roleGridEdit2View.OptionsBehavior.AutoPopulateColumns = false;
            this.roleGridEdit2View.OptionsBehavior.Editable = false;
            this.roleGridEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.roleGridEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "角色名称";
            // 
            // gridalloc
            // 
            this.gridalloc.Location = new System.Drawing.Point(19, 38);
            this.gridalloc.MainView = this.gvalloc;
            this.gridalloc.Name = "gridalloc";
            this.gridalloc.Size = new System.Drawing.Size(245, 370);
            this.gridalloc.TabIndex = 14;
            this.gridalloc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvalloc});
            // 
            // gvalloc
            // 
            this.gvalloc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn5});
            this.gvalloc.GridControl = this.gridalloc;
            this.gvalloc.Name = "gvalloc";
            this.gvalloc.OptionsBehavior.Editable = false;
            this.gvalloc.OptionsSelection.MultiSelect = true;
            this.gvalloc.OptionsView.ColumnAutoWidth = false;
            this.gvalloc.OptionsView.ShowAutoFilterRow = true;
            this.gvalloc.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "已分配用户";
            this.gridColumn1.FieldName = "UserName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "分组";
            this.gridColumn3.FieldName = "GroupName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "部门";
            this.gridColumn5.FieldName = "DepartmentName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridunalloc
            // 
            this.gridunalloc.Location = new System.Drawing.Point(352, 38);
            this.gridunalloc.MainView = this.gvunalloc;
            this.gridunalloc.Name = "gridunalloc";
            this.gridunalloc.Size = new System.Drawing.Size(245, 370);
            this.gridunalloc.TabIndex = 15;
            this.gridunalloc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvunalloc});
            // 
            // gvunalloc
            // 
            this.gvunalloc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn6,
            this.gridColumn4});
            this.gvunalloc.GridControl = this.gridunalloc;
            this.gvunalloc.Name = "gvunalloc";
            this.gvunalloc.OptionsBehavior.Editable = false;
            this.gvunalloc.OptionsSelection.MultiSelect = true;
            this.gvunalloc.OptionsView.ColumnAutoWidth = false;
            this.gvunalloc.OptionsView.ShowAutoFilterRow = true;
            this.gvunalloc.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "未分配用户";
            this.gridColumn2.FieldName = "UserName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "分组";
            this.gridColumn6.FieldName = "GroupName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "部门";
            this.gridColumn4.FieldName = "DepartmentName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // NewView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 460);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewView";
            this.Text = "编辑角色用户关联";
            this.Load += new System.EventHandler(this.NewView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.pnlFill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roleGridEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleGridEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridalloc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvalloc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridunalloc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvunalloc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleButton btnRightAll;
        private SimpleButton btnRight;
        private SimpleButton btnleftall;
        private SimpleButton btnLeft;
        private RoleGridEdit roleGridEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView roleGridEdit2View;
        private LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridalloc;
        private DevExpress.XtraGrid.Views.Grid.GridView gvalloc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.GridControl gridunalloc;
        private DevExpress.XtraGrid.Views.Grid.GridView gvunalloc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}