using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//引入串口使用的命名空间
using System.IO.Ports;

namespace SerialPortHelperDemo
{
    /// <summary>
    /// 串口助手通用类
    /// </summary>
    public class SerialPortHelper
    {
        #region 相关属性

        /// <summary>
        /// 创建一个串口操作对象
        /// </summary>
        private SerialPort serialPort = null;
        public SerialPort SerialPortObject
        {
            get { return serialPort; }
        }

        /// <summary>
        /// 获取当前计算机上可用的端口列表【只读】
        /// </summary>
        public string[] PortNames
        {
            get { return System.IO.Ports.SerialPort.GetPortNames(); }
        }

        /// <summary>
        /// 进制转换对象属性
        /// </summary>
        private AlgorithmHelper algorithmHelper = null;
        public AlgorithmHelper AlgorithmHelperObject
        {
            get { return algorithmHelper; }
        }

        /// <summary>
        /// 构造方法中初始化相关数据
        /// </summary>
        public SerialPortHelper()
        {
            this.serialPort = new SerialPort();
            this.algorithmHelper = new AlgorithmHelper();

            //串口基本参数初始化
            this.serialPort.BaudRate = 9600;
            this.serialPort.Parity = System.IO.Ports.Parity.None;//校验位默认NONE
            this.serialPort.DataBits = 8;//数据位默认8位
            this.serialPort.StopBits = System.IO.Ports.StopBits.One;//停止位默认1位

        }

        #endregion

        #region 打开或关闭端口

        /// <summary>
        /// 根据端口名称打开端口或关闭端口
        /// </summary>
        /// <param name="portName">端口名称</param>
        /// <param name="status">操作状态：1表示打开，0表示关闭</param>
        /// <returns>返回当前端口的打开状态true或false</returns>
        public bool OpenSerialPort(string portName, int status)
        {
            if (status == 1)
            {
                this.serialPort.PortName = portName;//只有在端口没有打开的时候，才能设置名称。
                this.serialPort.Open();
            }
            else
            {
                this.serialPort.Close();
            }
            return this.serialPort.IsOpen;//返回串口打开的状态
        }


        #endregion

        #region 发送数据

        /// <summary>
        /// 判断十六进制字符串hex是否正确
        /// </summary>
        /// <param name="hex">十六进制字符串</param>
        /// <returns>true：正确，false：不正确<returns>
        private bool IsIIlegalHex(string hex)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(hex, @"([^A-Fa-f0-9]|\s+?)+");
        }
        /// <summary>
        /// 发送数据（可以是16进制，也可以是字符串）
        /// </summary>
        /// <param name="data">要发送的数据</param>
        /// <param name="format">发送的数据格式</param>
        public void SendData(string data, SendFormat format)
        {
            if (!this.serialPort.IsOpen)
            {
                throw new Exception("端口未打开！请打开相关端口！");//让调用者处理
            }
            else
            {
                byte[] byteData;

                if (format == SendFormat.Hex)//如果是16进制
                {
                    if (this.IsIIlegalHex(data))
                    {
                        byteData = algorithmHelper.From16ToBtyes(data);//将16进制转换成byte[]数组
                    }
                    else
                    {
                        throw new Exception("数据不是16进制格式！");
                    }
                }
                else  //发送字符串
                {
                    byteData = algorithmHelper.StringToBytes(data, false);
                }
                this.serialPort.Write(byteData, 0, byteData.Length);//发送数据（数据，从0开始，结束位置）
            }
        }

        #endregion

        #region 接收数据

        /// <summary>
        /// 串口接收数据
        /// </summary>
        /// <returns></returns>
        public byte[] ReceiveData()
        {
            //定义一个接收数组，获取接收缓冲区数据的字节数
            byte[] byteData = new byte[this.serialPort.BytesToRead];
            //读取数据
            this.serialPort.Read(byteData, 0, serialPort.BytesToRead);
            return byteData;
        }

        #endregion
    }

    #region 发送格式选择枚举

    /// <summary>
    /// 发送格式选择
    /// </summary>
    public enum SendFormat
    {
        Hex,//十六进制
        String
    }

    #endregion
}
