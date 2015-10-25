using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
namespace Ultra.Permission
{
    partial class PermitView
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
            this.groupPanel1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.roleGridEdit1 = new Ultra.Permission.RoleGridEdit();
            this.roleGridEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupPanel2 = new DevExpress.XtraEditors.GroupControl();
            this.treeCtl1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roleGridEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleGridEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel2)).BeginInit();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeCtl1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(648, 5);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(563, 5);
            this.btnOK.Text = "保存(&E)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(562, 461);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.groupPanel2);
            this.pnlFill.Controls.Add(this.groupPanel1);
            this.pnlFill.Size = new System.Drawing.Size(562, 415);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 415);
            this.pnlBottom.Size = new System.Drawing.Size(562, 46);
            // 
            // groupPanel1
            // 
            this.groupPanel1.Controls.Add(this.labelControl1);
            this.groupPanel1.Controls.Add(this.roleGridEdit1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(2, 2);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(558, 61);
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "角色";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "角色名称";
            // 
            // roleGridEdit1
            // 
            this.roleGridEdit1.ClearButtonText = "清除所选";
            this.roleGridEdit1.ColumnCaption = "名称";
            this.roleGridEdit1.DisplayMember = "Name";
            this.roleGridEdit1.EditValue = "";
            this.roleGridEdit1.Location = new System.Drawing.Point(64, 31);
            this.roleGridEdit1.Name = "roleGridEdit1";
            this.roleGridEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "清除所选", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "清除所选", null, null, true)});
            this.roleGridEdit1.Properties.DisplayMember = "Name";
            this.roleGridEdit1.Properties.NullText = "";
            this.roleGridEdit1.Properties.ValueMember = "Guid";
            this.roleGridEdit1.Properties.View = this.roleGridEdit1View;
            this.roleGridEdit1.SelectedValue = null;
            this.roleGridEdit1.Size = new System.Drawing.Size(237, 20);
            this.roleGridEdit1.TabIndex = 0;
            this.roleGridEdit1.ValueMember = "Guid";
            this.roleGridEdit1.EditValueChanged += new System.EventHandler(this.roleGridEdit1_EditValueChanged);
            // 
            // roleGridEdit1View
            // 
            this.roleGridEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.roleGridEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
            this.roleGridEdit1View.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.roleGridEdit1View.Appearance.SelectedRow.Options.UseBackColor = true;
            this.roleGridEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.roleGridEdit1View.Name = "roleGridEdit1View";
            this.roleGridEdit1View.OptionsBehavior.AutoPopulateColumns = false;
            this.roleGridEdit1View.OptionsBehavior.Editable = false;
            this.roleGridEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.roleGridEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // groupPanel2
            // 
            this.groupPanel2.Controls.Add(this.treeCtl1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(2, 63);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(558, 350);
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "权限";
            // 
            // treeCtl1
            // 
            this.treeCtl1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeCtl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCtl1.HorzScrollVisibility = DevExpress.XtraTreeList.ScrollVisibility.Always;
            this.treeCtl1.Location = new System.Drawing.Point(2, 22);
            this.treeCtl1.Name = "treeCtl1";
            this.treeCtl1.BeginUnboundLoad();
            this.treeCtl1.AppendNode(new object[] {
            "1"}, -1);
            this.treeCtl1.AppendNode(new object[] {
            "11"}, 0);
            this.treeCtl1.AppendNode(new object[] {
            "2"}, -1);
            this.treeCtl1.AppendNode(new object[] {
            "22"}, 2);
            this.treeCtl1.AppendNode(new object[] {
            "222"}, 3);
            this.treeCtl1.AppendNode(new object[] {
            "3"}, -1);
            this.treeCtl1.EndUnboundLoad();
            this.treeCtl1.OptionsBehavior.Editable = false;
            this.treeCtl1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treeCtl1.OptionsSelection.InvertSelection = true;
            this.treeCtl1.OptionsView.ShowCheckBoxes = true;
            this.treeCtl1.OptionsView.ShowColumns = false;
            this.treeCtl1.OptionsView.ShowFocusedFrame = false;
            this.treeCtl1.OptionsView.ShowHorzLines = false;
            this.treeCtl1.OptionsView.ShowIndicator = false;
            this.treeCtl1.OptionsView.ShowVertLines = false;
            this.treeCtl1.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
            this.treeCtl1.Size = new System.Drawing.Size(554, 326);
            this.treeCtl1.TabIndex = 1;
            this.treeCtl1.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.MinWidth = 86;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 91;
            // 
            // PermitView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 461);
            this.Name = "PermitView";
            this.Text = "角色权限";
            this.Load += new System.EventHandler(this.PermitView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFill)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roleGridEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleGridEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPanel2)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeCtl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupControl groupPanel2;
        private GroupControl groupPanel1;
        private RoleGridEdit roleGridEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView roleGridEdit1View;
        private TreeList treeCtl1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private LabelControl labelControl1;
    }
}