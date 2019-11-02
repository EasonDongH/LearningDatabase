using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FTP.Model
{
    public enum FileType
    {
        FILE = 0,
        FOLDER = 1
    }

    public class FtpFileModel
    {
        public FileType  FileType {get; set;}

        public int FileSize { get; set; }

        public string ParentPath { get; set; }

        public string ModifyTime { get; set; }

        public string FileName { get; set; }

        public FtpFileModel(string ftpStr, string parentPath = "")
        {
            string[] info = ftpStr.Split(" ".ToArray(), StringSplitOptions.RemoveEmptyEntries);
            if (info.Length == 9)
            {
                FileType = info[0].StartsWith("drw")? FileType.FOLDER : FileType.FILE;
                FileSize = Convert.ToInt32(info[4]);
                ModifyTime = string.Join(" ", info, 5, 3);
                ParentPath = parentPath;
                FileName = info[8];
            }
            else
            {
                throw new Exception("FTP文件字符串解析失败！");
            }
        }
    }
}
