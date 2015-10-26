namespace Ultra.Login {
    partial class SetConfigView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dataBaseConfigWizard1 = new DataAccess.Gui.DataBaseConfigWizard();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dataBaseConfigWizard1
            // 
            this.dataBaseConfigWizard1.AutoEnumServer = false;
            this.dataBaseConfigWizard1.Location = new System.Drawing.Point(1, 1);
            this.dataBaseConfigWizard1.Name = "dataBaseConfigWizard1";
            this.dataBaseConfigWizard1.Size = new System.Drawing.Size(413, 193);
            this.dataBaseConfigWizard1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(329, 200);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SetConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 243);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dataBaseConfigWizard1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetConfigView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "程序设置";
            this.Load += new System.EventHandler(this.SetConfigView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DataAccess.Gui.DataBaseConfigWizard dataBaseConfigWizard1;
        private System.Windows.Forms.Button btnOK;
    }
}