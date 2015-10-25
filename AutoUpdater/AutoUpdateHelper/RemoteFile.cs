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
using System.Xml;

namespace AutoUpdater
{
    public class RemoteFile
    {
        public string FileName { get; set; }
        public string MD5 { get; set; }
        public string Url { get; set; }
        public long Size { get; set; }
    }
}
