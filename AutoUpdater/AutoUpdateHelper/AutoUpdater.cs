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
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.Http;

namespace AutoUpdater {
    #region The delegate
    public delegate void ShowHandler();
    #endregion

    public class AutoUpdater : IAutoUpdater {
        #region The private fields
        private Config config = null;
        private bool bNeedRestart = true;
        List<DownloadFileInfo> downloadFileListTemp = null;
        #endregion

        #region The public event
        //public event ShowHandler OnShow;
        #endregion

        #region The constructor of AutoUpdater
        public AutoUpdater() {
            config = Config.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.FILENAME));
        }
        #endregion

        #region The public method
        public void CheckUpdate() {
            var localFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.CHECKUPDATEFILE);
            var remoteFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,ConstFile.TEMPFOLDERNAME, ConstFile.CHECKUPDATEFILE);
            var localFileMD5 = ByteStringUtil.ByteArrayToHexStr(HashDigest.FileDigest(localFileName));
            using (WebClient client = new WebClient()) {
                client.DownloadFile(new Uri(config.ServerUrl.Replace(ConstFile.FILENAME, ConstFile.CHECKUPDATEFILE)), remoteFileName);
            }
            var remoteFileMD5 = ByteStringUtil.ByteArrayToHexStr(HashDigest.FileDigest(remoteFileName));
            if (!localFileMD5.Equals(remoteFileMD5)) {
                var dc = new DownloadConfirm(config.AppName);
                if (dc.ShowDialog() == DialogResult.OK) {
                    Update();
                    File.Copy(remoteFileName, localFileName, true);
                }
            }
        }

        public void Update() {
            var listRemotFile = ParseRemoteXml(config.ServerUrl);
            var downloadList = new List<DownloadFileInfo>();

            foreach (RemoteFile file in listRemotFile.Values) {
                downloadList.Add(new DownloadFileInfo(file.Url, file.FileName, file.MD5, file.Size));
            }

            downloadFileListTemp = downloadList;
            StartDownload(downloadList);


            //DownloadConfirm dc = new DownloadConfirm(downloadList);
            //if (this.OnShow != null)
            //    this.OnShow();

            //if (DialogResult.OK == dc.ShowDialog()) {
            //    StartDownload(downloadList);
            //}
        }

        public void RollBack() {
            foreach (DownloadFileInfo file in downloadFileListTemp) {
                var backupPath = Path.Combine(CommonUnitity.SystemBinUrl, ConstFile.BACKUPFOLDERNAME, file.FileName);
                var appExecPath = Path.Combine(CommonUnitity.SystemBinUrl, file.FileName);
                try {
                    if (File.Exists(backupPath))
                        MoveFolderToOld(backupPath, appExecPath);
                } catch (Exception ex) {
                    //log the error message,you can use the application's log code
                }
            }
        }


        #endregion

        #region The private method
        string newfilepath = string.Empty;
        private void MoveFolderToOld(string oldPath, string newPath) {
            if (File.Exists(oldPath) && File.Exists(newPath)) {
                System.IO.File.Copy(oldPath, newPath, true);
            }
        }

        private void StartDownload(List<DownloadFileInfo> downloadList) {
            DownloadProgress dp = new DownloadProgress(downloadList,config.AppName);
            if (dp.ShowDialog() == DialogResult.OK) {
                //
                if (DialogResult.Cancel == dp.ShowDialog()) {
                    return;
                }
                //更新成功
                config.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.FILENAME));

                if (bNeedRestart) {
                    //删除临时文件(下载)文件夹
                    //Directory.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConstFile.TEMPFOLDERNAME), true);

                    MessageBox.Show(ConstFile.APPLYTHEUPDATE, ConstFile.MESSAGETITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CommonUnitity.StartMainApplication(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,config.AppName));
                }
            }
        }

        /// <summary>
        /// 读取服务器所有需要更新的文件列表
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private Dictionary<string, RemoteFile> ParseRemoteXml(string xml) {
            var xmlStr = new WebClient().DownloadString(xml);
            Dictionary<string, RemoteFile> list = new Dictionary<string, RemoteFile>();
            var remots = new List<RemoteFile>();
            XmlSerializer xs = new XmlSerializer(typeof(List<RemoteFile>));
            using (StringReader sr = new StringReader(xmlStr)) {
                remots = xs.Deserialize(sr) as List<RemoteFile>;
            }
            foreach (var item in remots) {
                list.Add(item.FileName, item);
            }
            return list;
        }
        #endregion
    }

}
