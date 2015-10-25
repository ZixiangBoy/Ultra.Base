using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Ultra.Controls {
    public partial class FileBrowser : ButtonEdit {
        public FileBrowser()
            : base() {
            FileButton = new EditorButton(ButtonPredefines.Glyph);
            FileButton.Caption = "浏览...";
            base.Properties.Buttons.Add(FileButton);
            OFDlg = new OpenFileDialog();
            Properties.ReadOnly = true;
            AllowDrop = true;
            DragEnter += FileBrowser_DragEnter;
            DragDrop += FileBrowser_DragDrop;
        }

        void FileBrowser_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (null != files && files.Length > 0)
                Text = files[0];
        }

        void FileBrowser_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// 文件打开对话框
        /// </summary>
        [Description("文件打开对话框"),
        Browsable(true),
        Category("Ultra")]
        public OpenFileDialog OFDlg { get; set; }

        protected void Properties_ButtonClick(object sender, ButtonPressedEventArgs e) {
            if (e.Button.Caption == FileButton.Caption) {
                if (OFDlg.ShowDialog() == DialogResult.OK)
                    Text = OFDlg.FileName;
            }
        }

        protected EditorButton FileButton { get; set; }
    }
}
