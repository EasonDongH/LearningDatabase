using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SerialPortHelperDemo
{
    /// <summary>
    /// 16进制使用的隔离符枚举
    /// </summary>
    public enum Enum16Hex
    {
        None,//无
        Blank,//空格
        OX,  //OX
        Ox   //Ox
    }

    /// <summary>
    /// 计算进制类助手
    /// </summary>
    public class AlgorithmHelper
    {
        #region 十进制转十六进制
        public string From10To16(int d)
        {
            string hex = "";
            if (d < 16)
            {
                hex = BeginChange(d);
            }
            else
            {
                int c;
                int s = 0;
                int n = d;
                int temp = d;
                while (n >= 16)
                {
                    s++;
                    n = n / 16;
                }
                string[] m = new string[s];
                int i = 0;
                do
                {
                    c = d / 16;
                    m[i++] = BeginChange(d % 16);//判断是否大于10，如果大于10，则转换为A~F的格式
                    d = c;
                } while (c >= 16);
                hex = BeginChange(d);
                for (int j = m.Length - 1; j >= 0; j--)
                {
                    hex += m[j];
                }
            }
            return hex;
        }
        //判断是否为10~15之间的数，如果是则进行转换
        public string BeginChange(int d)
        {
            string hex = "";
            switch (d)
            {
                case 10:
                    hex = "A";
                    break;
                case 11:
                    hex = "B";
                    break;
                case 12:
                    hex = "C";
                    break;
                case 13:
                    hex = "D";
                    break;
                case 14:
                    hex = "E";
                    break;
                case 15:
                    hex = "F";
                    break;
                default:
                    hex = d.ToString();
                    break;
            }
            return hex;
        }
        #endregion

        #region 其他函数【16进制中的隔离符处理】

        /// <summary>
        /// 把16进制隔离符转换成实际的字符串
        /// </summary>
        /// <param name="enum16">16进制隔离符枚举</param>
        /// <returns></returns>
        private string AddSplitString(Enum16Hex enum16)
        {
            switch (enum16)
            {
                case Enum16Hex.None:
                    return "";
                case Enum16Hex.Ox:
                    return "0x";
                case Enum16Hex.OX:
                    return "0X";
                case Enum16Hex.Blank:
                    return " ";
                default:
                    return "";
            }
        }
        /// <summary>
        /// 去掉16进制字符串中的隔离符【 如：" ", "0x", "0X"】
        /// </summary>
        /// <param name="inString">需要转换的字符串数据</param>
        /// <returns></returns>
        private string DeleteSplitString(string inString)
        {
            string outString = string.Empty;
            string[] delArray = { " ", "0x", "0X" };
            if (inString.Contains(" ") || inString.Contains("0x") || inString.Contains("0X"))//存在隔离符
            {
                string[] str = inString.Split(delArray,
                    System.StringSplitOptions.RemoveEmptyEntries);//以隔离符进行转换数组，去掉隔离符，去掉空格。
                for (int i = 0; i < str.Length; i++)
                {
                    outString += str[i].ToString();
                }
                return outString;
            }
            else//不存在隔离符就直接返回
            {
                return inString;
            }
        }
        #endregion

        #region 汉字、英文、纯16进制数、byte[]之间的各种转换方法

        /// <summary>
        /// 字符串转换成16进制
        /// </summary>
        /// <param name="inSting"></param>
        /// <param name="enum16"></param>
        /// <returns></returns>
        public string StringTo16(string inSting, Enum16Hex enum16)
        {
            string outString = "";
            byte[] bytes = Encoding.Default.GetBytes(inSting);
            for (int i = 0; i < bytes.Length; i++)
            {
                int strInt = Convert.ToInt16(bytes[i] - '\0');
                string s = strInt.ToString("X");
                if (s.Length == 1)
                {
                    s = "0" + s;
                }
                s = s + AddSplitString(enum16);
                outString += s;
            }
            return outString;
        }
        /// <summary>
        /// 字符串转换成byte[]
        /// </summary>
        /// <param name="inSting"></param>
        /// <returns></returns>
        public byte[] StringToBtyes(string inSting)
        {
            inSting = StringTo16(inSting, Enum16Hex.None);//把字符串转换成16进制数
            return From16ToBtyes(inSting);//把16进制数转换成byte[]
        }
        /// <summary>
        /// 把16进制字符串转换成byte[]
        /// </summary>
        /// <param name="inSting"></param>
        /// <returns></returns>
        public byte[] From16ToBtyes(string inSting)
        {
            inSting = DeleteSplitString(inSting);//去掉16进制中的隔离符
            byte[] stringByte = new byte[inSting.Length / 2];
            for (int a = 0, b = 0; a < inSting.Length; a = a + 2, b++)
            {
                try
                {
                    string str = inSting.Substring(a, 2);
                    stringByte[b] = (byte)Convert.ToInt16(str, 16);
                }
                catch (Exception ex)
                {
                    throw new Exception("输入的数据不是纯16进制数!  参考错误信息：" + ex.Message);
                }
            }
            return stringByte;
        }
        /// <summary>
        /// 把16进制字符串转换成英文数字和汉字混合格式
        /// </summary>
        /// <param name="inSting">需要转换的16进制字符串</param>
        /// <returns></returns>
        public string From16ToString(string inSting)
        {
            inSting = DeleteSplitString(inSting);
            return Encoding.Default.GetString(From16ToBtyes(inSting));
        }
        /// <summary>
        /// 把byte[]转换成String
        /// </summary>
        /// <param name="bytes">需要转换的byte[]</param>
        /// <param name="enum16">隔离符</param>
        /// <returns></returns>
        public string BytesToString(byte[] bytes, Enum16Hex enum16)
        {
            return From16ToString(BytesTo16(bytes, enum16));
        }
        /// <summary>
        /// byte[]转换成16进制字符串
        /// </summary>
        /// <param name="bytes">需要转换的byte[]</param>
        /// <param name="enum16"></param>
        /// <returns></returns>
        public string BytesTo16(byte[] bytes, Enum16Hex enum16)
        {
            string outString = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i].ToString("X").Length < 2)//16进制数为一位时前面填充0
                {
                    outString += "0" + bytes[i].ToString("X") + AddSplitString(enum16);//转成16进制数据
                }
                else
                {
                    outString += bytes[i].ToString("X") + AddSplitString(enum16);//转成16进制数据
                }
            }
            return outString;
        }
        /// <summary>
        /// 把byte[]直接转换成字符串，直接以2进制形式显示出来。
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public string BytesTo2String(byte[] bytes, Enum16Hex enum16)
        {
            string outString = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                string tempString = Convert.ToString(bytes[i], 2);
                if (tempString.Length != 8)
                {
                    string add0 = "";
                    for (int j = 0; j < 8 - tempString.Length; j++)
                    {
                        add0 += "0";
                    }
                    outString += add0 + tempString + AddSplitString(enum16);
                }
                else
                {
                    outString += tempString + AddSplitString(enum16);
                }
            }
            return outString;
        }

        /// <summary>
        /// 把字符串传进来，输出一个byte数组【可以把此byte数组直接发送到串口中】
        /// </summary>
        /// <param name="inString">要转换的字符串</param>
        /// <param name="is16">是否已经是16进制数据，true时已经是(已经转换好的数据)，false时不是(需要内部转换)</param>
        /// <returns>输出一个byte数组</returns>
        public byte[] StringToBytes(string inString, bool is16)
        {
            if (is16)
            {
                return From16ToBtyes(inString);
            }
            else
            {
                return StringToBtyes(inString);
            }
        }

        #endregion
    }
}
