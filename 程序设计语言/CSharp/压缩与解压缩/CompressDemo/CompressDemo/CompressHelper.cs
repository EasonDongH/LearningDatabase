using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CompressDemo
{
    public class CompressHelper
    {
        public static bool Decompress(string sourcePath, string targetDir)
        {
            if (Directory.Exists(targetDir) == false)
                Directory.CreateDirectory(targetDir);
            bool result = true;
            try
            {
                if (sourcePath.ToLower().EndsWith("rar"))
                {
                    result = DecompressRar(sourcePath, targetDir);
                }
                else if (sourcePath.ToLower().EndsWith("zip"))
                {
                    result = DecompressZIP(sourcePath, targetDir);
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        private static bool DecompressRar(string sourcePath, string targetDir)
        {
            bool result = true;
            try
            {
                result = SharpCompressHelper.Decompress(sourcePath, targetDir);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Invalid Rar Header: 223")
                {
                    result = WinRARHelper.DecompressedFile(sourcePath, targetDir, true, string.Empty);
                }
            }
            return true;
        }

        private static bool DecompressZIP(string sourcePath, string targetDir)
        {
            try
            {
                return SharpCompressHelper.Decompress(sourcePath, targetDir);
            }
            catch (Exception)
            {

            }
            return true;
        }
    }
}
