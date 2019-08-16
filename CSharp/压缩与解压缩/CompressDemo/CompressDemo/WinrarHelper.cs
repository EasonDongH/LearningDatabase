using System.Diagnostics;
using System.IO;

namespace CompressDemo
{
    /// <summary>
    /// 需要在执行文件目录放置winrar.exe文件
    /// </summary>
    public class WinRARHelper
    {
        /// <summary>
        /// 解压RAR和ZIP文件
        /// </summary>
        /// <param name="UnPath">解压后文件保存目录</param>
        /// <param name="rarPathName">待解压文件存放绝对路径（包括文件名称）</param>
        /// <param name="IsCover">所解压的文件是否会覆盖已存在的文件(如果不覆盖,所解压出的文件和已存在的相同名称文件不会共同存在,只保留原已存在文件)</param>
        /// <param name="PassWord">解压密码(如果不需要密码则为空)</param>
        /// <returns>true(解压成功);false(解压失败)</returns>
        public static bool DecompressedFile(string rarPathName, string UnPath, bool IsCover, string PassWord)
        {
            if (!Directory.Exists(UnPath))
                Directory.CreateDirectory(UnPath);

            string cmd = "";
            if (!string.IsNullOrEmpty(PassWord) && IsCover)//解压加密文件且覆盖已存在文件( -p密码 )
                cmd = string.Format(" x -p{0} -o+ {1} {2} -y", PassWord, rarPathName, UnPath);
            else if (!string.IsNullOrEmpty(PassWord) && !IsCover)//解压加密文件且不覆盖已存在文件( -p密码 )
                cmd = string.Format(" x -p{0} -o- {1} {2} -y", PassWord, rarPathName, UnPath);
            else if (IsCover) //覆盖命令( x -o+ 代表覆盖已存在的文件)
                cmd = string.Format(" x -o+ {0} {1} -y", rarPathName, UnPath);
            else//不覆盖命令( x -o- 代表不覆盖已存在的文件)
                cmd = string.Format(" x -o- {0} {1} -y", rarPathName, UnPath);

            return ExecuteCmd(cmd);
        }

        /// <summary>
        /// 压缩文件成RAR或ZIP文件
        /// </summary>
        /// <param name="filesPath">将要压缩的文件夹或文件的绝对路径</param>
        /// <param name="rarPathName">压缩后的压缩文件保存绝对路径，需带文件名、后缀名，以后缀zip、rar来决定压缩包类型</param>
        /// <param name="IsCover">所压缩文件是否会覆盖已有的压缩文件(如果不覆盖,所压缩文件和已存在的相同名称的压缩文件不会共同存在,只保留原已存在压缩文件)</param>
        /// <param name="PassWord">压缩密码(如果不需要密码则为空)</param>
        /// <returns>true(压缩成功);false(压缩失败)</returns>
        public static bool CompressedFile(string filesPath, string rarPathName, bool IsCover, string PassWord)
        {
            string rarPath = Path.GetDirectoryName(rarPathName);
            if (!Directory.Exists(rarPath))
                Directory.CreateDirectory(rarPath);

            string cmd = "";
            if (!string.IsNullOrEmpty(PassWord) && IsCover)//压缩加密文件且覆盖已存在压缩文件( -p密码 -o+覆盖 )
                cmd = string.Format(" a -ep1 -p{0} -o+ {1} {2} -r", PassWord, rarPathName, filesPath);
            else if (!string.IsNullOrEmpty(PassWord) && !IsCover)//压缩加密文件且不覆盖已存在压缩文件( -p密码 -o-不覆盖 )
                cmd = string.Format(" a -ep1 -p{0} -o- {1} {2} -r", PassWord, rarPathName, filesPath);
            else if (string.IsNullOrEmpty(PassWord) && IsCover) //压缩且覆盖已存在压缩文件( -o+覆盖 )
                cmd = string.Format(" a -ep1 -o+ {0} {1} -r", rarPathName, filesPath);
            else //压缩且不覆盖已存在压缩文件( -o-不覆盖 )
                cmd = string.Format(" a -ep1 -o- {0} {1} -r", rarPathName, filesPath);

            return ExecuteCmd(cmd);
        }

        /// <summary>
        /// 分卷压缩，默认覆盖已有文件
        /// </summary>
        /// <param name="filesPath">需要压缩的文件或文件夹</param>
        /// <param name="packetSize">每个包的大小：数字+单位，单位为：b、k、m、g，如1k则每个包1KB</param>
        /// <param name="rarPathName">压缩文件的路径，需带文件名、后缀名，以后缀zip、rar来决定压缩包类型</param>
        /// <param name="IsCover"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public static bool CompressedFile(string filesPath, string packetSize, string rarPathName)
        {
            string rarPath = Path.GetDirectoryName(rarPathName);
            if (!Directory.Exists(rarPath))
                Directory.CreateDirectory(rarPath);
            string cmd = string.Format("a -ep1 -o+ -v{0} {1} {2} -r", packetSize, rarPathName, filesPath);
            return ExecuteCmd(cmd);
        }

        private static bool ExecuteCmd(string cmd)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = "Winrar.exe";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.Arguments = cmd;
                process.Start();
                process.WaitForExit();//无限期等待进程 winrar.exe 退出
                return process.ExitCode == 0;// ExitCode==0指正常执行，Process1.ExitCode==1则指不正常执行
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                process.Close();
                process.Dispose();
            }
        }
    }
}
