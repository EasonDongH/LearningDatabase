using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class Modbus
    {
        //定义串口类对象
        private SerialPort MyCom;
        //定义CRC校验高低位
        private byte ucCRCHi = 0xFF;
        private byte ucCRCLo = 0xFF;
        //定义接收字节数组
        byte[] bData = new byte[1024];
        byte mReceiveByte;
        int mReceiveByteCount = 0;
        //定义设备地址
        int CurrentAddr;
        int iMWordLen;
        int iMBitLen;
        //定义返回报文
        string strUpData;
        public Modbus()
        {
            MyCom = new SerialPort();
        }

        #region 打开关闭串口方法
        /// <summary>
        /// 打开串口方法【9600 N 8 1】
        /// </summary>
        /// <param name="iBaudRate">波特率</param>
        /// <param name="iPortNo">端口号</param>
        /// <param name="iDataBits">数据位</param>
        /// <param name="iParity">校验位</param>
        /// <param name="iStopBits">停止位</param>
        /// <returns></returns>
        public bool OpenMyComm(int iBaudRate, string iPortNo, int iDataBits, Parity iParity, StopBits iStopBits)
        {
            try
            {
                //关闭已打开串口
                if (MyCom.IsOpen)
                {
                    MyCom.Close();
                }
                //设置串口属性
                MyCom.BaudRate = iBaudRate;
                MyCom.PortName = iPortNo;
                MyCom.DataBits = iDataBits;
                MyCom.Parity = iParity;
                MyCom.StopBits = iStopBits;
                MyCom.ReceivedBytesThreshold = 1;
                MyCom.DataReceived += new SerialDataReceivedEventHandler(MyCom_DataReceived);

                MyCom.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 关闭串口方法
        /// </summary>
        /// <returns></returns>
        public bool ClosePort()
        {
            if (MyCom.IsOpen)
            {
                MyCom.Close();
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region 串口接受数据事件
        /// <summary>
        /// 串口接受数据事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MyCom_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (MyCom.BytesToRead > 0)
            {
                mReceiveByte = (byte)MyCom.ReadByte();
                bData[mReceiveByteCount] = mReceiveByte;
                mReceiveByteCount += 1;
                if (mReceiveByteCount >= 1024)
                {
                    mReceiveByteCount = 0;
                    //清除输入缓存区
                    MyCom.DiscardInBuffer();
                    return;
                }
            }
            //读取保持型寄存器 功能码0x03
            if (bData[0] == (byte)CurrentAddr && bData[1] == 0x03 && mReceiveByteCount >= (iMWordLen * 2 + 5))
            {
                strUpData = "";
                for (int i = 0; i < iMWordLen * 2 + 5; i++)
                {
                    strUpData = strUpData + " " + bData[i].ToString("X2");
                }
                MyCom.DiscardInBuffer();
            }
            //预置单字保持型寄存器  功能码0x06
            if (bData[0] == (byte)CurrentAddr && bData[1] == 0x06 && mReceiveByteCount >= 8)
            {
                strUpData = "";
                for (int i = 0; i < 8; i++)
                {
                    strUpData = strUpData + " " + bData[i].ToString("X2");
                }
                MyCom.DiscardInBuffer();
            }
            //预置双字保持型寄存器  功能码0x10
            if (bData[0] == (byte)CurrentAddr && bData[1] == 0x10 && mReceiveByteCount >= 8)
            {
                strUpData = "";
                for (int i = 0; i < 8; i++)
                {
                    strUpData = strUpData + " " + bData[i].ToString("X2");
                }
                MyCom.DiscardInBuffer();

            }
            //读取输出线圈  功能码0x01
            if (bData[0] == (byte)CurrentAddr && bData[1] == 0x01 && mReceiveByteCount >= iMBitLen + 5)
            {
                strUpData = "";
                for (int i = 0; i < iMBitLen + 5; i++)
                {
                    strUpData = strUpData + " " + bData[i].ToString("X2");
                }
                MyCom.DiscardInBuffer();

            }

            //读取输入线圈  功能码0x02
            if (bData[0] == (byte)CurrentAddr && bData[1] == 0x02 && mReceiveByteCount >= iMBitLen + 5)
            {
                strUpData = "";
                for (int i = 0; i < iMBitLen + 5; i++)
                {
                    strUpData = strUpData + " " + bData[i].ToString("X2");
                }
                MyCom.DiscardInBuffer();
            }

            //强制单线圈 功能码0x05
            if (bData[0] == (byte)CurrentAddr && bData[1] == 0x05 && mReceiveByteCount >=8)
            {
                strUpData = "";
                for (int i = 0; i < 8; i++)
                {
                    strUpData = strUpData + " " + bData[i].ToString("X2");
                }
                MyCom.DiscardInBuffer();
            }

        }
        #endregion

        #region 读取保持型寄存器 功能码0x03
        /// <summary>
        /// 读取保持型寄存器 功能码0x03
        /// </summary>
        /// <param name="iDevAdd">从站地址</param>
        /// <param name="iAddress">起始地址</param>
        /// <param name="iLength">长度</param>
        /// <returns></returns>
        public byte[] ReadKeepReg(int iDevAdd, int iAddress, int iLength)
        {
            byte[] ResByte = null;
            iMWordLen = iLength;
            CurrentAddr = iDevAdd;
            //第一步：拼接报文
            byte[] SendCommand = new byte[8];
            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x03;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = (byte)((iLength - iLength % 256) / 256);
            SendCommand[5] = (byte)(iLength % 256);
            Crc16(SendCommand, 6);
            SendCommand[6] = ucCRCLo;
            SendCommand[7] = ucCRCHi;

            //第二步：发送报文
            try
            {
                MyCom.Write(SendCommand, 0, 8);
            }
            catch (Exception)
            {
                return null;
            }
            //第三步：解析报文
            mReceiveByteCount = 0;
            Thread.Sleep(100);

            ResByte = HexStringToByteArray(this.strUpData, 3, 2);

            return ResByte;

        }
        #endregion

        #region 预置单字保持型寄存器 功能码0x06
        /// <summary>
        /// 预置单字保持型寄存器  功能码0x06
        /// </summary>
        /// <param name="iDevAdd"></param>
        /// <param name="iAddress"></param>
        /// <param name="SetValue"></param>
        /// <returns></returns>
        public bool PreSetKeepReg(int iDevAdd, int iAddress, int SetValue)
        {
            byte[] ResByte;
            byte[] SendCommand = new byte[8];
            CurrentAddr = iDevAdd;
            //第一步：拼接报文
            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x06;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = (byte)((SetValue - SetValue % 256) / 256);
            SendCommand[5] = (byte)(SetValue % 256);
            Crc16(SendCommand, 6);
            SendCommand[6] = ucCRCLo;
            SendCommand[7] = ucCRCHi;
            try
            {
                //第二步：发送报文
                MyCom.Write(SendCommand, 0, 8);
            }
            catch (Exception)
            {
                return false;
            }
            mReceiveByteCount = 0;
            Thread.Sleep(100);
            //第三步：解析报文
            ResByte = HexStringToByteArray(this.strUpData, 0, 0);
            return ByteArrayEquals(SendCommand, ResByte);
        }
        #endregion

        #region 预置双字保持型寄存器 功能码0x10
        /// <summary>
        /// 预置双字保持型寄存器 功能码0x10
        /// </summary>
        /// <param name="iDevAdd"></param>
        /// <param name="iAddress"></param>
        /// <param name="SetValue"></param>
        /// <returns></returns>
        public bool PreSetFloatKeepReg(int iDevAdd, int iAddress, float SetValue)
        {
            byte[] ResByte;
            byte[] SendCommand = new byte[13];
            CurrentAddr = iDevAdd;
            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x10;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = 0x00;
            SendCommand[5] = 0x02;
            SendCommand[6] = 0x04;
            byte[] bSetValue = BitConverter.GetBytes(SetValue);
            SendCommand[7] = bSetValue[3];
            SendCommand[8] = bSetValue[2];
            SendCommand[9] = bSetValue[1];
            SendCommand[10] = bSetValue[0];
            Crc16(SendCommand, 11);
            SendCommand[11] = ucCRCLo;
            SendCommand[12] = ucCRCHi;
            try
            {
                MyCom.Write(SendCommand, 0, 13);
            }
            catch (Exception)
            {
                return false;
            }
            mReceiveByteCount = 0;
            Thread.Sleep(100);
            ResByte = HexStringToByteArray(this.strUpData, 0, 0);

            byte[] byteTemp = GetByteArray(ResByte, 0, 6);
            Crc16(byteTemp, 6);
            byte[] bytecrc = GetByteArray(ResByte, 6, 2);
            if (ByteArrayEquals(GetByteArray(SendCommand, 0, 6), byteTemp) && bytecrc[0] == ucCRCLo && bytecrc[1] == ucCRCHi)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region 读取输出线圈  功能码0x01
        /// <summary>
        /// 读取输出线圈  功能码0x01
        /// </summary>
        /// <param name="iDevAdd"></param>
        /// <param name="iAddress"></param>
        /// <param name="iLength"></param>
        /// <returns></returns>
        public byte[] ReadOutputStatus(int iDevAdd, int iAddress, int iLength)
        {
            byte[] SendCommand = new byte[8];
            CurrentAddr = iDevAdd;
            if (iLength % 8 == 0)
            {
                iMBitLen = iLength / 8;
            }
            else
            {
                iMBitLen = iLength / 8 + 1;
            }

            //第一步：拼接报文
            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x01;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = (byte)((iLength - iLength % 256) / 256);
            SendCommand[5] = (byte)(iLength % 256);
            Crc16(SendCommand, 6);
            SendCommand[6] = ucCRCLo;
            SendCommand[7] = ucCRCHi;
            try
            {
                MyCom.Write(SendCommand, 0, 8);
            }
            catch (Exception)
            {
                return null;
            }
            mReceiveByteCount = 0;
            Thread.Sleep(100);
            return HexStringToByteArray(this.strUpData, 3, 2);
        }
        #endregion

        #region 读取输入线圈  功能码0x02
        /// <summary>
        /// 读取输入线圈  功能码0x02
        /// </summary>
        /// <param name="iDevAdd"></param>
        /// <param name="iAddress"></param>
        /// <param name="iLength"></param>
        /// <returns></returns>
        public byte[] ReadInputStatus(int iDevAdd, int iAddress, int iLength)
        {
            byte[] SendCommand = new byte[8];
            CurrentAddr = iDevAdd;
            if (iLength % 8 == 0)
            {
                iMBitLen = iLength / 8;
            }
            else
            {
                iMBitLen = iLength / 8 + 1;
            }

            //第一步：拼接报文
            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x02;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            SendCommand[4] = (byte)((iLength - iLength % 256) / 256);
            SendCommand[5] = (byte)(iLength % 256);
            Crc16(SendCommand, 6);
            SendCommand[6] = ucCRCLo;
            SendCommand[7] = ucCRCHi;
            try
            {
                MyCom.Write(SendCommand, 0, 8);
            }
            catch (Exception)
            {
                return null;
            }
            mReceiveByteCount = 0;
            Thread.Sleep(100);
            return HexStringToByteArray(this.strUpData, 3, 2);
        }
        #endregion

        #region 强制单线圈  功能码0x05
        /// <summary>
        /// 强制单线圈  功能码0x05
        /// </summary>
        /// <param name="iDevAdd"></param>
        /// <param name="iAddress"></param>
        /// <param name="SetValue"></param>
        /// <returns></returns>
        public bool ForceCoil(int iDevAdd,int iAddress,bool SetValue)
        {
            byte[] ResByte;
            byte[] SendCommand = new byte[8];
            CurrentAddr = iDevAdd;
            SendCommand[0] = (byte)iDevAdd;
            SendCommand[1] = 0x05;
            SendCommand[2] = (byte)((iAddress - iAddress % 256) / 256);
            SendCommand[3] = (byte)(iAddress % 256);
            if (SetValue)
            {
                SendCommand[4] = 0xFF;
            }
            else
            {
                SendCommand[4] = 0x00;
            }
            SendCommand[5] = 0x00;
            Crc16(SendCommand, 6);
            SendCommand[6] = ucCRCLo;
            SendCommand[7] = ucCRCHi;

            try
            {
                MyCom.Write(SendCommand, 0, 8);
            }
            catch (Exception)
            {
                return false;
            }
            mReceiveByteCount = 0;
            Thread.Sleep(100);
            ResByte = HexStringToByteArray(this.strUpData,0,0);
            return ByteArrayEquals(SendCommand, ResByte);
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 报文转换字节数组（自定义截取）
        /// </summary>
        /// <param name="S"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private byte[] HexStringToByteArray(string S, int start, int end)
        {
            byte[] Res = null;
            if (S != null && S.Length > start + end)
            {
                string[] str = S.Trim().Split(' ');
                string[] Result = new string[str.Length - start - end];
                for (int i = 0; i < Result.Length; i++)
                {
                    Result[i] = str[i + start];
                }
                Res = new byte[Result.Length];
                for (int i = 0; i < Result.Length; i++)
                {
                    Res[i] = Convert.ToByte(Result[i], 16);
                }
            }
            return Res;
        }

        /// <summary>
        /// 判断两个字节数组是否完全一致
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        private bool ByteArrayEquals(byte[] b1, byte[] b2)
        {
            if (b1.Length != b2.Length) return false;
            if (b1 == null || b2 == null) return false;
            for (int i = 0; i < b1.Length; i++)
                if (b1[i] != b2[i])
                    return false;
            return true;
        }

        /// <summary>
        /// 自定义截取字节数组
        /// </summary>
        /// <param name="byteArr"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private byte[] GetByteArray(byte[] byteArr, int start, int length)
        {
            byte[] Res = new byte[length];
            if (byteArr != null && byteArr.Length > length)
            {
                for (int i = 0; i < length; i++)
                {
                    Res[i] = byteArr[i + start];
                }

            }
            return Res;
        }
        #endregion

        #region  CRC校验
        private static readonly byte[] aucCRCHi = {
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
             0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
             0x00, 0xC1, 0x81, 0x40
         };
        private static readonly byte[] aucCRCLo = {
             0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7,
             0x05, 0xC5, 0xC4, 0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E,
             0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09, 0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9,
             0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC,
             0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
             0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32,
             0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D,
             0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A, 0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 
             0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF,
             0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
             0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1,
             0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4,
             0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F, 0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 
             0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA,
             0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
             0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0,
             0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97,
             0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C, 0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E,
             0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89,
             0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
             0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83,
             0x41, 0x81, 0x80, 0x40
         };
        private void Crc16(byte[] pucFrame, int usLen)
        {
            int i = 0;
            ucCRCHi = 0xFF;
            ucCRCLo = 0xFF;
            UInt16 iIndex = 0x0000;

            while (usLen-- > 0)
            {
                iIndex = (UInt16)(ucCRCLo ^ pucFrame[i++]);
                ucCRCLo = (byte)(ucCRCHi ^ aucCRCHi[iIndex]);
                ucCRCHi = aucCRCLo[iIndex];
            }

        }

        #endregion

    }
}
