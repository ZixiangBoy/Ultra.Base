using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Handlers;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Ultra.Web.Core.Common;

namespace RemoteFileJsn {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        List<RemoteFile> UpdFiles = null;
        const string ServerUrl = "http://localhost:30000/api/Web/";

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e) {
            if (UpdFiles == null || UpdFiles.Count < 1)
                return;

            if (string.IsNullOrEmpty(txtSvrDir.Text)) {
                MessageBox.Show("请输入要上传的服务器文件目录");
                return;
            }

            btnGenUpdateConfig.Enabled = false;

            UpdFiles.Where(k => k.Status != "上传完成").ToList().ForEach(j => {
                if (DoUpLoad(j.FullName, txtSvrDir.Text.Trim())) {
                    SetLstItemStatus(j,true);
                } else {
                    SetLstItemStatus(j, false);
                }
            });

            if (UpdFiles.All(k => k.Status == "上传完成")) {
                btnGenUpdateConfig_Click(null, null);
            }

            btnGenUpdateConfig.Enabled = true;
        }

        private void SetLstItemStatus(RemoteFile j, bool isSuccess) {
            foreach (ListViewItem li in lstFile.Items) {
                if (li.Text != j.FileName) {
                    continue;
                }
                li.Selected = true;
                foreach (System.Windows.Forms.ListViewItem.ListViewSubItem sub in li.SubItems) {
                    if (sub.Name == "Status") {
                        j.Status = sub.Text = isSuccess ? "上传完成" : "上传失败";
                    }
                }
            }
        }


        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="fis"></param>
        /// <param name="dbdir"></param>
        /// <returns></returns>
        public static bool DoUpLoad(string fis, string dbdir) {
            int BufferSize = 1024;

            //HttpClientHandler hand = new HttpClientHandler();
            //ProgressMessageHandler processMessageHander = new ProgressMessageHandler(hand);
            HttpClient client = new HttpClient();

            var _filename = fis;
            using (FileStream fileStream = new FileStream(_filename, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize, useAsync: true)) {
                // Create a stream content for the file
                StreamContent content = new StreamContent(fileStream, BufferSize);
                content.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Octet);
                // Create Multipart form data content, add our submitter data and our stream content
                MultipartFormDataContent formData = new MultipartFormDataContent();
                formData.Add(new StringContent(dbdir), "ServerDir");//DataBase
                formData.Add(content, "filename", _filename);

                // Post the MIME multipart form data upload with the file
                var rm = client.PostAsync(ServerUrl, formData).Result;

                if (rm.IsSuccessStatusCode) {
                    try {
                        var dret = rm.Content.ReadAsAsync<string>().Result;
                        return string.IsNullOrEmpty(dret);
                    } catch (Exception ex) {
                        throw new Exception(ServerUrl);
                        throw;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 生成更新文件列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenUpdateConfig_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtSvrDir.Text.Trim()))
                return;
            if (MessageBox.Show("上传前请先确保DLL文件已上传至服务器,是否继续?", "确认", MessageBoxButtons.YesNo
                , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                return;
            var fi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UpdateFileList.xml");
            File.WriteAllText(fi,richTextBox1.Text, Encoding.UTF8);
            if (!DoUpLoad(fi, txtSvrDir.Text.Trim()))
                MessageBox.Show("上传失败，请重试！", "重试",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("上传成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 选择目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowers_Click(object sender, EventArgs e) {
            if (fdlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                txtFileDir.Text = fdlg.SelectedPath;

                lstFile.Items.Clear();
                var fis = Directory.GetFiles(txtFileDir.Text.Trim(), "*.*", SearchOption.TopDirectoryOnly);
                if (null == fis || fis.Length < 1)
                    return;
                var lst = new List<RemoteFile>(fis.Length);
                foreach (var fi in fis) {
                    if (checkBox1.Checked && Path.GetFileName(fi).StartsWith("DevExpress", StringComparison.OrdinalIgnoreCase))
                        continue;
                    if (Path.GetFileName(fi).EndsWith("pdb", StringComparison.OrdinalIgnoreCase))
                        continue;
                    if (string.Compare(Path.GetFileName(fi), "SvcUpdate.exe", true) == 0)
                        continue;
                    lst.Add(new RemoteFile {
                        FileName = Path.GetFileName(fi),
                        FullName=fi,
                        MD5 = ByteStringUtil.ByteArrayToHexStr(HashDigest.FileDigest(fi)),
                        Url = "http://localhost/UpdateApp/ttt/" + Path.GetFileName(fi),
                        Size=new FileInfo(fi).Length,
                        Status=string.Empty
                    });
                }
                lst = lst.OrderBy(j => j.FileName).ToList();
                lst.ForEach(j => {
                    var li = lstFile.Items.Add(j.FileName);
                    var sub=li.SubItems.Add(j.MD5);
                    sub=li.SubItems.Add(j.Status);
                    sub.Name = "Status";
                });
                XmlSerializer xs = new XmlSerializer(typeof(List<RemoteFile>));
                StringWriter sw = new StringWriter();
                xs.Serialize(sw,lst);
                sw.Close();
                richTextBox1.Text = sw.ToString();  //Common.SerializeJson(lst);
                UpdFiles = lst;
            }
        }
    }
}
