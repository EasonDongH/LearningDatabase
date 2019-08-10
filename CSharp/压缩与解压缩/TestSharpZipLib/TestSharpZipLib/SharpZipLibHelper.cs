using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;

namespace TestSharpZipLib
{
    public class SharpZipLibHelper
    {
        /// <summary>
        /// 解压缩ZIP压缩包
        /// </summary>
        /// <param name="sourceDir">压缩包所在文件夹</param>
        /// <param name="zipFileName">要解压的压缩包名，必须以.zip为后缀</param>
        /// <param name="targetDir">解压文件放置的文件夹</param>
        public static bool ZipDecompress(string sourceDir, string zipFileName, string targetDir)
        {
            zipFileName = zipFileName.ToLower();
            if (zipFileName.EndsWith(".zip") == false)
                return false;
            #region 判断参数
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
            CheckDirectory(ref sourceDir);
            CheckDirectory(ref targetDir);
            if (!File.Exists(sourceDir + zipFileName))
            {
                throw new FileNotFoundException(string.Format("未能找到文件 '{0}' ", sourceDir));
            }
            #endregion
            string searchPattern = zipFileName.Substring(0, zipFileName.LastIndexOf('.')) + "*";
            // 搜索与指定压缩包同名的分割包
            string[] fileNames = Directory.GetFiles(sourceDir, searchPattern);
            if (fileNames == null || fileNames.Length == 0)
            {
                throw new Exception("压缩文件异常");
            }
            //将所有文件读取出来,然后放到内存流中
            using (System.IO.MemoryStream mStream = new MemoryStream())
            {
                byte[] tBytes = null;
                //循环读取所有文件
                string tfileName = null;
                foreach (var fileItem in fileNames)
                {
                    tfileName = System.IO.Path.GetFileName(fileItem).ToLower();
                    //排除zip指定文件,让其最后加载
                    if (zipFileName == tfileName)
                        continue;
                    tBytes = File.ReadAllBytes(fileItem);
                    mStream.Write(tBytes, 0, tBytes.Length);
                }
                tBytes = File.ReadAllBytes(sourceDir + zipFileName);
                mStream.Write(tBytes, 0, tBytes.Length);
                mStream.Position = 0;//注意必须设置Pos=0,否则会报EOF异常
                using (ZipInputStream s = new ZipInputStream(mStream))
                {
                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        string directorName = Path.Combine(targetDir, Path.GetDirectoryName(theEntry.Name));// 拼接压缩包内的子文件夹路径
                        string fileName = Path.Combine(directorName, Path.GetFileName(theEntry.Name));
                        if (directorName.Length > 0 && Directory.Exists(directorName) == false)
                        {
                            Directory.CreateDirectory(directorName);
                        }
                        if (fileName == string.Empty)
                            continue;
                        using (FileStream streamWriter = File.Create(fileName))
                        {
                            int size = 4096;
                            byte[] data = new byte[4 * 1024];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else break;
                            }
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 压缩文件为ZIP，会将文件的整条路径添加压缩，不支持文件夹
        /// </summary>
        /// <param name="sourcePaths">要压缩的文件路径</param>
        /// <param name="targetDir">压缩包文件路径</param>
        /// <returns></returns>
        public static bool ZipCompress(string[] sourcePaths, string targetPath)
        {
            if (targetPath.ToLower().EndsWith(".zip") == false)
            {
                targetPath += ".zip";
            }

            using (ZipFile zip = ZipFile.Create(targetPath))
            {
                zip.BeginUpdate();
                foreach (var item in sourcePaths)
                {
                    if (File.Exists(item))
                        zip.Add(item);
                }
                zip.CommitUpdate();
            }

            return true;
        }

        /// <summary>
        /// 压缩文件为ZIP，包括子文件夹
        /// </summary>
        /// <param name="sourceDir">被压缩的文件夹</param>
        /// <param name="targetPath">压缩文件路径</param>
        /// <returns></returns>
        public static bool ZipCompress(string sourceDir, string targetPath)
        {
            if (targetPath.ToLower().EndsWith(".zip") == false)
            {
                targetPath += ".zip";
            }
            var fa = new FastZip();
            fa.CreateZip(targetPath, sourceDir, true, "");
            return true;
        }

        private static void CheckDirectory(ref string dir)
        {
            const string ENDPATHFLG = "\\";
            if (dir.EndsWith(ENDPATHFLG) == false)
            {
                dir += ENDPATHFLG;
            }
        }
    }
}
