using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using FTP.Model;
using System.Threading.Tasks;

namespace FTP.Base
{
    public class FtpClient
    {
        private const int BUFFSIZE = 1024 * 2;

        public string ServerIP { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string URI { get; set; }

        public Action CompleteDownload = null;

        public Action CompleteUpload = null;

        public Action<string> FailDownload = null;

        public Action<string> FailUpload = null;

        /// <summary>
        /// 设置FTP属性
        /// </summary>
        /// <param name="FtpServerIP">FTP连接地址</param>
        /// <param name="this.UserName">用户名</param>
        /// <param name="Password">密码</param>
        public FtpClient(string serverIP, string userName, string passwordName)
        {
            this.ServerIP = serverIP;
            this.UserName = userName;
            this.Password = passwordName;
            this.URI = "ftp://" + this.ServerIP + "/";
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="relativePath">服务器的相对路径</param>
        /// <param name="localPath">本地文件的绝对路径</param>
        public void Upload(string relativePath, string localPath)
        {
            try
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    UploadFile(relativePath, localPath);
                });
                task.ContinueWith(t =>
                {
                    if (task.Exception == null)
                    {
                        if (this.CompleteUpload != null)
                            this.CompleteUpload();
                    }
                    else if (this.FailUpload != null)
                    {
                        this.FailUpload(task.Exception.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                if (this.FailUpload != null)
                    this.FailUpload(ex.Message);
            }
            finally
            {

            }
        }

        private void UploadFile(string relativePath, string localPath)
        {
            FtpWebRequest reqFTP = null;
            FileStream fs = null;
            Stream strm = null;
            try
            {
                FileInfo fileInf = new FileInfo(localPath);
                string uri = this.URI + relativePath + "/" + Path.GetFileName(localPath);
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                reqFTP.Credentials = new NetworkCredential(this.UserName, Password);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = false;
                reqFTP.ContentLength = fileInf.Length;
                byte[] buff = new byte[BUFFSIZE];
                int contentLen = 0;
                fs = fileInf.OpenRead();
                strm = reqFTP.GetRequestStream();
                while ((contentLen = fs.Read(buff, 0, buff.Length)) != 0)
                {
                    strm.Write(buff, 0, contentLen);
                }

                if (this.CompleteUpload != null)
                    this.CompleteUpload();
            }
            finally
            {
                if (reqFTP != null)
                    reqFTP.Abort();
                if (fs != null)
                    fs.Close();
                if (strm != null)
                    strm.Close();
            }
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="filePath">本地保存路径</param>
        /// <param name="fileName">需要下载的FTP服务器路径上的文件名，同时也是本地保存的文件名</param>
        public void Download(string filePath, string serverPath, string fileName)
        {
            try
            {
                Task task = Task.Factory.StartNew(() =>
                    {
                        DownloadFile(filePath, serverPath, fileName);
                    });
                task.ContinueWith(t =>
                {
                    if (task.Exception == null)
                    {
                        if (this.CompleteDownload != null)
                            this.CompleteDownload();
                    }
                    else if (this.FailDownload != null)
                    {
                        List<string> ex = new List<string>();
                        foreach (var item in t.Exception.InnerExceptions)
                        {
                            ex.Add(item.Message);
                        }
                        this.FailDownload(string.Join("\n", ex));
                    }
                });
            }
            catch (Exception ex)
            {
                if (this.FailDownload != null)
                    this.FailDownload(ex.Message);
            }
            finally
            {

            }
        }

        private void DownloadFile(string filePath, string serverPath, string fileName)
        {
            FtpWebRequest ftpRequest = null;
            FileStream outputStream = null;
            FtpWebResponse response = null;
            Stream ftpStream = null;

            try
            {
                outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);
                string uri = this.URI + serverPath + "/" + fileName;
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = false;
                ftpRequest.Proxy = null;
                ftpRequest.Credentials = new NetworkCredential(this.UserName, this.Password);
                response = (FtpWebResponse)ftpRequest.GetResponse();
                ftpStream = response.GetResponseStream();
                //long needRead = response.ContentLength, realRead = 0; // 出现response.ContentLength=-1但仍能下载的情况，原因？
                int readCount = 0;
                byte[] buffer = new byte[BUFFSIZE];

                while ((readCount = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    //realRead += readCount;
                }
            }
            finally
            {
                if (ftpRequest != null)
                    ftpRequest.Abort();
                if (ftpStream != null)
                    ftpStream.Close();
                if (response != null)
                    response.Close();
                if (outputStream != null)
                    outputStream.Close();
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName"></param>
        public void Delete(string fileName)
        {
            try
            {
                string uri = this.URI + fileName;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

                reqFTP.Credentials = new NetworkCredential(this.UserName, Password);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                reqFTP.UsePassive = false;

                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("FtpHelper Delete Error --> " + ex.Message + "  文件名:" + fileName);
            }
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="folderName"></param>
        public void RemoveDirectory(string folderName)
        {
            try
            {
                string uri = this.URI + folderName;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

                reqFTP.Credentials = new NetworkCredential(this.UserName, Password);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.RemoveDirectory;
                reqFTP.UsePassive = false;

                string result = String.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                long size = response.ContentLength;
                Stream datastream = response.GetResponseStream();
                StreamReader sr = new StreamReader(datastream);
                result = sr.ReadToEnd();
                sr.Close();
                datastream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("FtpHelper Delete Error --> " + ex.Message + "  文件名:" + folderName);
            }
        }

        /// <summary>
        /// 获取当前目录下明细(包含文件和文件夹)，并按文件种类排序（文件在前，文件夹在后）
        /// </summary>
        /// <param name="path">相对FTP根目录的路径</param>
        /// <returns></returns>
        public List<FtpFileModel> GetFilesDetailList(string path = "")
        {
            Console.WriteLine(path);
            FtpWebRequest ftp = null;
            WebResponse response = null;
            StreamReader reader = null;
            List<FtpFileModel> fileList = new List<FtpFileModel>();
            try
            {
                StringBuilder result = new StringBuilder();
                ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.URI + path));
                ftp.Credentials = new NetworkCredential(this.UserName, Password);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                ftp.UsePassive = false;
                response = ftp.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), Encoding.Default);

                string line = string.Empty;// 读取的首行内容为"total 0"，剔除
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        fileList.Add(new FtpFileModel(line, path));
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (response != null)
                    response.Close();
                if (ftp != null)
                    ftp.Abort();
            }

            return fileList.OrderBy(f => f.FileType).ToList();
        }

        /// <summary>
        /// 获取当前目录下文件列表(仅文件)
        /// </summary>
        /// <returns></returns>
        public string[] GetFileList(string mask)
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.URI));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(this.UserName, Password);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.UsePassive = false;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (mask.Trim() != string.Empty && mask.Trim() != "*.*")
                    {
                        string mask_ = mask.Substring(0, mask.IndexOf("*"));
                        if (line.Substring(0, mask_.Length) == mask_)
                        {
                            result.Append(line);
                            result.Append("\n");
                        }
                    }
                    else
                    {
                        result.Append(line);
                        result.Append("\n");
                    }
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                downloadFiles = null;
                if (ex.Message.Trim() != "远程服务器返回错误: (550) 文件不可用(例如，未找到文件，无法访问文件)。")
                {
                    throw new Exception("FtpHelper GetFileList Error --> " + ex.Message.ToString());
                }
                return downloadFiles;
            }
        }

        /// <summary>
        /// 获取当前目录下所有的文件夹列表(仅文件夹)
        /// </summary>
        /// <returns></returns>
        //public string[] GetDirectoryList()
        //{
        //    string[] drectory = GetFilesDetailList();
        //    string m = string.Empty;
        //    foreach (string str in drectory)
        //    {
        //        int dirPos = str.IndexOf("<DIR>");
        //        if (dirPos > 0)
        //        {
        //            /*判断 Windows 风格*/
        //            m += str.Substring(dirPos + 5).Trim() + "\n";
        //        }
        //        else if (str.Trim().Substring(0, 1).ToUpper() == "D")
        //        {
        //            /*判断 Unix 风格*/
        //            string dir = str.Substring(54).Trim();
        //            if (dir != "." && dir != "..")
        //            {
        //                m += dir + "\n";
        //            }
        //        }
        //    }

        //    char[] n = new char[] { '\n' };
        //    return m.Split(n);
        //}

        /// <summary>
        /// 判断当前目录下指定的子目录是否存在
        /// </summary>
        /// <param name="RemoteDirectoryName">指定的目录名</param>
        //public bool DirectoryExist(string RemoteDirectoryName)
        //{
        //    string[] dirList = GetDirectoryList();
        //    foreach (string str in dirList)
        //    {
        //        if (str.Trim() == RemoteDirectoryName.Trim())
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        /// <summary>
        /// 判断当前目录下指定的文件是否存在
        /// </summary>
        /// <param name="RemoteFileName">远程文件名</param>
        public bool FileExist(string RemoteFileName)
        {
            string[] fileList = GetFileList("*.*");
            foreach (string str in fileList)
            {
                if (str.Trim() == RemoteFileName.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="dirName"></param>
        public void MakeDir(string dirName)
        {
            FtpWebRequest reqFTP;
            try
            {
                // dirName = name of the directory to create.
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.URI + dirName));
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = false;
                reqFTP.Credentials = new NetworkCredential(this.UserName, Password);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("FtpHelper MakeDir Error --> " + ex.Message);
            }
        }

        /// <summary>
        /// 获取指定文件大小
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public long GetFileSize(string filename)
        {
            FtpWebRequest reqFTP;
            long fileSize = 0;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.URI + filename));
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = false;
                reqFTP.Credentials = new NetworkCredential(this.UserName, Password);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                fileSize = response.ContentLength;

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("FtpHelper GetFileSize Error --> " + ex.Message);
            }
            return fileSize;
        }

        /// <summary>
        /// 改名
        /// </summary>
        /// <param name="currentFilename"></param>
        /// <param name="newFilename"></param>
        public void ReName(string currentFilename, string newFilename)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.URI + currentFilename));
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = false;
                reqFTP.Credentials = new NetworkCredential(this.UserName, Password);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("FtpHelper ReName Error --> " + ex.Message);
            }
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="currentFilename"></param>
        /// <param name="newFilename"></param>
        public void MovieFile(string currentFilename, string newDirectory)
        {
            ReName(currentFilename, newDirectory);
        }
    }
}
