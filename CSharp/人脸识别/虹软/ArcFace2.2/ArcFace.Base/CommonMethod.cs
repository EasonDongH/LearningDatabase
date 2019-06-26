using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ArcFace.Base
{
    public class CommonMethod
    {
        /// <summary>
        /// WIN32接口 复制内存句柄handle
        /// </summary>
        /// <param name="Destination"></param>
        /// <param name="Source"></param>
        /// <param name="Length"></param>
        [DllImport("kernel32.dll")]
        public static extern void CopyMemory(IntPtr Destination, IntPtr Source, int Length);
        /// <summary>
        /// 将毫秒转化为“H时M分S秒MS毫秒”的格式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ConvertTime(double time)
        {
            int S = 1000; // 1秒的毫秒数
            int M = S*60;
            int H = M*60;

            int h, m, s, ms;
            int time1 = Convert.ToInt32(time); // 去掉微妙部分
            h = time1 / H;
            time1 -= h * H;
            m = time1 / M;
            time1 -= m * M;
            s = time1 / S;
            time1 -= s * S;
            ms = time1;

            return string.Format("{0}秒{1}毫秒", s, ms);
            //return string.Format("{0}时{1}分{2}秒{3}毫秒",h,m,s,ms);
        }

        //byte[]转换为Intptr
        public static IntPtr BytesToIntptr(byte[] bytes)
        {
            int size = bytes.Length;
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, 0, buffer, size);
                return buffer;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
    }
}
