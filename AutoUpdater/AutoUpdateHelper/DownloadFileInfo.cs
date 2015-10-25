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
using System.Text;
using System.IO;

namespace AutoUpdater
{
    public class DownloadFileInfo
    {
        private string fileName;

        #region The public property
        public string DownloadUrl { get; set; }
        public string MD5 { get; set; }
        public long Size { get; set; }
        public string FileName { get { return fileName; } }
        #endregion

        #region The constructor of DownloadFileInfo
        public DownloadFileInfo(string url, string name,string md5,long size)
        {
            this.DownloadUrl = url;
            this.fileName = name;
            this.MD5 = md5;
            this.Size = size;
        }
        #endregion
    }
}
