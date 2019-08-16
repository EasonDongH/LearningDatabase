using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SevenZip;

namespace CompressDemo
{
    /// <summary>
    /// 需要在执行文件目录下放置7z.dll文件
    /// </summary>
    public class SevenZipHelper
    {
        public static void DecompressedFile(string inFile, string directory)
        {
            using (var tmp = new SevenZipExtractor(inFile))
            { //7z文件路径
                for (int i = 0; i < tmp.ArchiveFileData.Count; i++)
                {
                    tmp.ExtractFiles(directory, tmp.ArchiveFileData[i].Index); //解压文件路径
                }
            }
        }
    }
}
