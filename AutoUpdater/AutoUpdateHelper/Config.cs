/*****************************************************************
 * Copyright (C) Knights Warrior Corporation. All rights reserved.
 * 
 * Author:    •µÓ∆Ô ø£®Knights Warrior£© 
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
using System.Xml.Serialization;
using System.IO;

namespace AutoUpdater
{
    public class Config
    {
        public string ServerUrl {
            get;
            set;
        }

        #region The public method
        public static Config LoadConfig(string file) {
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            using (StreamReader sr = new StreamReader(file)) {
                Config config = xs.Deserialize(sr) as Config;
                return config;
            }
        }

        public void SaveConfig(string file) {
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            using (StreamWriter sw = new StreamWriter(file)) {
                xs.Serialize(sw, this);
            }
        }
        #endregion

    }

}
