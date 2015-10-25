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
using System.Linq;
using System.Text;

namespace AutoUpdater
{
    public class ConstFile
    {
        public const string TEMPFOLDERNAME = "TempFolder";
        public const string CONFIGFILEKEY = "config_";
        public const string FILENAME = "AutoUpdater.xml";
        public const string CHECKUPDATEFILE = "UpdateFileList.xml";
        public const string MESSAGETITLE = "自动更新程序";
        public const string CANCELORNOT = "程序正在更新... 确定要取消更新?";
        public const string APPLYTHEUPDATE = "您必须重启程序完成本次更新!";
        public const string NOTNETWORK = "程序更新失败.请重新启动程序,再次更新!";
    }
}
