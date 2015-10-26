/*****************************************************************
 * Copyright (C) Knights Warrior Corporation. All rights reserved.
 * 
 * Author:   圣殿骑士（Knights Warrior） 
 * Email:    KnightsWarrior@msn.com
 * Website:  http://www.cnblogs.com/KnightsWarrior/       http://knightswarrior.blog.51cto.com/
 * Create Date:  5/8/2010 
 * Usage:
 *
 * RevisionHistory
 * Date         Author               Description
 * 
*****************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoUpdater
{
    public partial class DownloadConfirm : Form
    {
        #region The private fields
        List<DownloadFileInfo> downloadFileList = null;
        #endregion

        #region The constructor of DownloadConfirm
        public DownloadConfirm(string appName) {
            InitializeComponent();

            int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int ScreenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            //计算窗体显示的坐标值，可以根据需要微调几个像素
            int x = ScreenWidth - this.Width ;
            int y = ScreenHeight - this.Height ;

            this.Location = new Point(x, y);

            lblAppName.Text = string.Format("{0}",appName);
        }

        public DownloadConfirm(List<DownloadFileInfo> downloadfileList)
        {
            InitializeComponent();
            downloadFileList = downloadfileList;
        }
        #endregion

        //#region The private method
        //private void OnLoad(object sender, EventArgs e)
        //{
        //    foreach (DownloadFileInfo file in this.downloadFileList)
        //    {
        //        ListViewItem item = new ListViewItem(new string[] { file.FileName,file.MD5, file.Size.ToString() });
        //    }

        //    this.Activate();
        //    this.Focus();
        //}
        //#endregion
    }
}