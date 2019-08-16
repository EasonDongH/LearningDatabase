using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SharpCompress.Common;
using SharpCompress.Archive;
using SharpCompress.Reader;
using SharpCompress.Writer;

namespace CompressDemo
{
    public class SharpCompressHelper
    { 
        /// <summary>
        /// 解压缩，仅支持zip、rar4格式的压缩包；不支持解压缩分卷压缩
        /// </summary>
        /// <param name="sourceDir"></param>
        /// <param name="sourceFileName"></param>
        /// <param name="targetDir"></param>
        /// <returns></returns>
        public static bool Decompress(string sourceDir, string sourceFileName, string targetDir)
        {
            if (sourceDir.EndsWith("\\") == false) sourceDir += "\\";
            if (targetDir.EndsWith("\\") == false) targetDir += "\\";
            if (Directory.Exists(targetDir) == false) Directory.CreateDirectory(targetDir);

            string sourcePath = sourceDir + sourceFileName;
            using (Stream stream = File.OpenRead(sourcePath))
            {
                var reader = ReaderFactory.Open(stream);
                while(reader.MoveToNextEntry())
                {
                    if (reader.Entry.IsDirectory) continue;
                    reader.WriteEntryToDirectory(targetDir, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                }
            }
            return true;
        }

        /// <summary>
        /// 压缩zip包
        /// </summary>
        /// <param name="sourceDir">要被压缩的文件夹</param>
        /// <param name="targetDir">压缩包放置的文件夹</param>
        /// <param name="targetFileName">压缩包名称，需要以.zip为类型</param>
        /// <returns></returns>
        public static bool Compress(string sourceDir, string targetDir, string targetFileName)
        {
            if (targetFileName.EndsWith(".zip") == false)
                throw new Exception("仅支持zip格式压缩");
            if (sourceDir.EndsWith("\\") == false) sourceDir += "\\";
            if (targetDir.EndsWith("\\") == false) targetDir += "\\";
            if (Directory.Exists(targetDir) == false) Directory.CreateDirectory(targetDir);

            using (var zip = File.OpenWrite(targetDir + targetFileName))
            {
                using (var zipWriter = WriterFactory.Open(zip, ArchiveType.Zip, CompressionType.None))
                {
                    zipWriter.WriteAll(sourceDir, "*", SearchOption.AllDirectories);
                }
            }
            return true;
        }
    }
}
