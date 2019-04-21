using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;
using System.Net;

namespace Models
{
    public class FileInfo
    {
        public string Version { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string URL { get; set; }
    }
    public class VersionInfo
    {
        public string RemoteVersionInfoURL { get; set; }
        public DateTime LocalLastUpdateTime { get; set; }
        public string LocalVersion { get; set; }

        public DateTime remoteLastUpdateTime;
        public DateTime RemoteLastUpdateTime { get { return this.remoteLastUpdateTime; } }

        public string remoteVersion;
        public string RemoteVersion { get { return this.remoteVersion; } }

        private List<FileInfo> remoteUpdateFiles;
        public List<FileInfo> RemoteUpdateFiles { get { return this.remoteUpdateFiles; } }
        public string TempFilePath { get; } = System.Configuration.ConfigurationManager.AppSettings["TempFilePath"];

        public bool NeedUpdate
        {
            get
            {
                return this.LocalLastUpdateTime < this.remoteLastUpdateTime;
            }
        }

        private void ReadLoaclVersion()
        {
            FileStream file = new FileStream(@"AppVersionInfo.xml", FileMode.Open);
            XmlTextReader xmlTextReader = new XmlTextReader(file);
            while (xmlTextReader.Read())
            {
                switch (xmlTextReader.Name)
                {
                    case "RemoteVersionInfoURL":
                        this.RemoteVersionInfoURL = xmlTextReader.GetAttribute("URL");
                        break;
                    case "LastUpdateTime":
                        this.LocalLastUpdateTime = Convert.ToDateTime(xmlTextReader.GetAttribute("Date"));
                        break;
                    case "CurrentVersion":
                        this.LocalVersion = xmlTextReader.GetAttribute("Version");
                        break;
                }
            }
            xmlTextReader.Close();
        }

        public void ReadRemoteVersion(string remoteXMLTempPath=null)
        {
            if (remoteXMLTempPath == null || !File.Exists(remoteXMLTempPath))
            {
                remoteXMLTempPath = this.TempFilePath + this.RemoteVersionInfoURL.Substring(this.RemoteVersionInfoURL.LastIndexOf('/') + 1);
                WebClient webClient = new WebClient();
                webClient.DownloadFile(this.RemoteVersionInfoURL, remoteXMLTempPath);
            }
            FileStream file = new FileStream(remoteXMLTempPath, FileMode.Open);
            XmlTextReader xmlTextReader = new XmlTextReader(file);
            this.remoteUpdateFiles = new List<FileInfo>();
            while (xmlTextReader.Read())
            {
                switch (xmlTextReader.Name)
                {
                    case "LastUpdateTime":
                        this.remoteLastUpdateTime = Convert.ToDateTime(xmlTextReader.GetAttribute("Date"));
                        break;
                    case "CurrentVersion":
                        this.remoteVersion = xmlTextReader.GetAttribute("Version");
                        break;
                    case "UpdateFile":
                        this.RemoteUpdateFiles.Add(new FileInfo
                        {
                            Version = xmlTextReader.GetAttribute("Version"),
                            FileName = xmlTextReader.GetAttribute("FileName"),
                            FileSize = xmlTextReader.GetAttribute("FileSize"),
                            URL = xmlTextReader.GetAttribute("URL")
                        });
                        break;
                }
            }
            xmlTextReader.Close();
        }

        public VersionInfo(string remoteXMLTempPath = null)
        {
            ReadLoaclVersion();
        }
    }
}
