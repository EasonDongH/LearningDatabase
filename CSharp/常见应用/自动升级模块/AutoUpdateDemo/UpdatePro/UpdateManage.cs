using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;
using System.IO;
using System.Net;
using System.Windows.Forms;

using System.Xml;

namespace UpdatePro
{
    public delegate void ReportDownLoadProgress(int fileIndex, int percent);
    class UpdateManage
    {
        public VersionInfo UpdateInfo { get; }// 用于展示需要更新的文件

        public ReportDownLoadProgress reportDownLoadProgress;

        public UpdateManage(ReportDownLoadProgress reportDownLoadProgress = null)
        {
            this.UpdateInfo = new VersionInfo();
            string remoteXMLTempPath = UpdateInfo.TempFilePath + UpdateInfo.RemoteVersionInfoURL.Substring(UpdateInfo.RemoteVersionInfoURL.LastIndexOf('/') + 1);
            this.UpdateInfo.ReadRemoteVersion(remoteXMLTempPath);
            this.reportDownLoadProgress = reportDownLoadProgress;
        }

        public bool DownloadFile()
        {
            for (int fileIndex = 0; fileIndex < this.UpdateInfo.RemoteUpdateFiles.Count; ++fileIndex)
            {
                var file = this.UpdateInfo.RemoteUpdateFiles[fileIndex];
                //将服务器更新文件下载至本地临时文件夹：需要“异步”显示下载进度
                WebRequest webRequest = WebRequest.Create(file.URL);
                WebResponse webResponse = webRequest.GetResponse();
                Stream stream = webResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream);

                long fileLength = webResponse.ContentLength;// 获取实际下载文件的字节数
                byte[] bufferByte = new byte[fileLength];
                int remainByteCnt = bufferByte.Length, startByteIndex = 0, currentDownLoadByte = 0;// 如果fileLength大于int，这里会溢出
                while (startByteIndex < fileLength)
                {
                    currentDownLoadByte = stream.Read(bufferByte, startByteIndex, remainByteCnt);
                    startByteIndex += currentDownLoadByte;
                    remainByteCnt -= currentDownLoadByte;

                    if (this.reportDownLoadProgress != null)
                    {
                        Application.DoEvents();// 保证将“reportDownLoadProgress”发送出去
                        int downLoad_Percent = (int)((double)startByteIndex / bufferByte.Length * 100);
                        reportDownLoadProgress(fileIndex, downLoad_Percent);
                    }
                }

                //将已下载的文件保存至临时文件夹
                FileStream fileStream = new FileStream(UpdateInfo.TempFilePath + file.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                fileStream.Write(bufferByte, 0, bufferByte.Length);
                fileStream.Close();
                stream.Close();
                webResponse.Close();
            }

            // 这里是本地拷贝，速度应该较快
            // 这里应该再次确认是否所有需要更新的文件都移动至执行文件根目录
            string[] fileNames = Directory.GetFiles(this.UpdateInfo.TempFilePath);
            foreach (var file in this.UpdateInfo.RemoteUpdateFiles)
            {
                string tmpPath = this.UpdateInfo.TempFilePath + file.FileName;
                if (fileNames.Contains(tmpPath))
                {
                    if (File.Exists(file.FileName))
                        File.Delete(file.FileName);
                    File.Copy(tmpPath, file.FileName);// 默认移动到执行文件根目录
                }
            }

            RewriteAppVerionInfo();
            System.Diagnostics.Process.Start("AutoUpdateDemo.exe");
            return true;
        }

        public void RewriteAppVerionInfo()
        {
            XmlTextWriter myXmlTextWriter = new XmlTextWriter(@"AppVersionInfo.xml", Encoding.UTF8);
            //使用 Formatting 属性指定希望将 XML 设定为何种格式。 这样，子元素就可以通过使用 Indentation 和 IndentChar 属性来缩进。
            myXmlTextWriter.Formatting = Formatting.Indented;

            myXmlTextWriter.WriteStartDocument(false);
            myXmlTextWriter.WriteStartElement("AutoUpdater");

            myXmlTextWriter.WriteStartElement("RemoteVersionInfoURL");
            myXmlTextWriter.WriteAttributeString("URL", this.UpdateInfo.RemoteVersionInfoURL);
            myXmlTextWriter.WriteEndElement();

            myXmlTextWriter.WriteStartElement("VersionInfo");
                myXmlTextWriter.WriteStartElement("LastUpdateTime");
                    myXmlTextWriter.WriteAttributeString("Date", this.UpdateInfo.RemoteLastUpdateTime.ToString("yyyy/MM/dd hh:mm:ss"));
               myXmlTextWriter.WriteEndElement();
               myXmlTextWriter.WriteStartElement("CurrentVersion");
                    myXmlTextWriter.WriteAttributeString("Version", this.UpdateInfo.RemoteVersion);
                myXmlTextWriter.WriteEndElement();
            myXmlTextWriter.WriteEndElement();
            myXmlTextWriter.WriteEndElement();

            myXmlTextWriter.Flush();
            myXmlTextWriter.Close();
        }
    }
}
