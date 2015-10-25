using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
namespace Ultra.Surface.Controls {

    partial class PagerControl {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblResult = new DevExpress.XtraEditors.LabelControl();
            this.lblFirst = new System.Windows.Forms.LinkLabel();
            this.lblPrev = new System.Windows.Forms.LinkLabel();
            this.lblNext = new System.Windows.Forms.LinkLabel();
            this.lblLast = new System.Windows.Forms.LinkLabel();
            this.comPageSize = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labTo = new System.Windows.Forms.LinkLabel();
            this.txtTo = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comPageSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 12;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblResult, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFirst, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPrev, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNext, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLast, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.comPageSize, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.labTo, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTo, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 10, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(806, 26);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // lblResult
            // 
            this.lblResult.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblResult.Location = new System.Drawing.Point(649, 6);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(154, 14);
            this.lblResult.TabIndex = 15;
            this.lblResult.Text = "当前页数：0/0页  总数：0条";
            // 
            // lblFirst
            // 
            this.lblFirst.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFirst.AutoSize = true;
            this.lblFirst.Enabled = false;
            this.lblFirst.LinkColor = System.Drawing.Color.Black;
            this.lblFirst.Location = new System.Drawing.Point(3, 7);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(29, 12);
            this.lblFirst.TabIndex = 3;
            this.lblFirst.TabStop = true;
            this.lblFirst.Text = "首页";
            this.lblFirst.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFirst_LinkClicked);
            // 
            // lblPrev
            // 
            this.lblPrev.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPrev.AutoSize = true;
            this.lblPrev.Enabled = false;
            this.lblPrev.LinkColor = System.Drawing.Color.Black;
            this.lblPrev.Location = new System.Drawing.Point(38, 7);
            this.lblPrev.Name = "lblPrev";
            this.lblPrev.Size = new System.Drawing.Size(41, 12);
            this.lblPrev.TabIndex = 4;
            this.lblPrev.TabStop = true;
            this.lblPrev.Text = "上一页";
            this.lblPrev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPrev_LinkClicked);
            // 
            // lblNext
            // 
            this.lblNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNext.AutoSize = true;
            this.lblNext.Enabled = false;
            this.lblNext.LinkColor = System.Drawing.Color.Black;
            this.lblNext.Location = new System.Drawing.Point(85, 7);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(41, 12);
            this.lblNext.TabIndex = 5;
            this.lblNext.TabStop = true;
            this.lblNext.Text = "下一页";
            this.lblNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNext_LinkClicked);
            // 
            // lblLast
            // 
            this.lblLast.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLast.AutoSize = true;
            this.lblLast.Enabled = false;
            this.lblLast.LinkColor = System.Drawing.Color.Black;
            this.lblLast.Location = new System.Drawing.Point(132, 7);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(29, 12);
            this.lblLast.TabIndex = 6;
            this.lblLast.TabStop = true;
            this.lblLast.Text = "尾页";
            this.lblLast.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLast_LinkClicked);
            // 
            // comPageSize
            // 
            this.comPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comPageSize.EditValue = "50";
            this.comPageSize.Location = new System.Drawing.Point(189, 3);
            this.comPageSize.Name = "comPageSize";
            this.comPageSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comPageSize.Properties.Items.AddRange(new object[] {
            "50",
            "100",
            "200",
            "500",
            "1000",
            "最大值"});
            this.comPageSize.Size = new System.Drawing.Size(74, 20);
            this.comPageSize.TabIndex = 10;
            this.comPageSize.SelectedIndexChanged += new System.EventHandler(this.comPageSize_SelectedIndexChanged);
            // 
            // labTo
            // 
            this.labTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labTo.AutoSize = true;
            this.labTo.Enabled = false;
            this.labTo.LinkColor = System.Drawing.Color.Black;
            this.labTo.Location = new System.Drawing.Point(299, 7);
            this.labTo.Name = "labTo";
            this.labTo.Size = new System.Drawing.Size(29, 12);
            this.labTo.TabIndex = 7;
            this.labTo.TabStop = true;
            this.labTo.Text = "转至";
            // 
            // txtTo
            // 
            this.txtTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTo.Enabled = false;
            this.txtTo.Location = new System.Drawing.Point(334, 3);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(42, 20);
            this.txtTo.TabIndex = 15;
            this.txtTo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTo_KeyUp);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(382, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "页";
            // 
            // PagerControl
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PagerControl";
            this.Size = new System.Drawing.Size(806, 26);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comPageSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private TableLayoutPanel tableLayoutPanel1;
        private LabelControl lblResult;
        public LinkLabel lblFirst;
        public LinkLabel lblPrev;
        public LinkLabel lblNext;
        public LinkLabel lblLast;
        private ComboBoxEdit comPageSize;
        public LinkLabel labTo;
        private TextEdit txtTo;
        private Label label2;

        #endregion
    }
}
