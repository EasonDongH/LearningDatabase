using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace VoiceBoxDemo
{
    public class SerialPortHelper
    {
        private static readonly object locker = new object();

        private SerialPort _serialPort = null;

        public Action<byte[]> HasReceivedData = null;

        public SerialPortHelper(string portName, int baudRate = 9600, int dataBits = 8, Parity parity = Parity.None, StopBits stopBits = StopBits.One)
        {
            this._serialPort = new SerialPort();
            this._serialPort.PortName = portName;
            this._serialPort.BaudRate = baudRate;
            this._serialPort.DataBits = dataBits;
            this._serialPort.Parity = parity;
            this._serialPort.StopBits = stopBits;

            this._serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
        }

        /// <summary>
        /// 这里没有处理串口被占用的情况
        /// </summary>
        public void Open()
        {
            if (this._serialPort.IsOpen == false)
                this._serialPort.Open();
        }

        public void Close()
        {
            if (this._serialPort.IsOpen)
                this._serialPort.Close();
        }

        public void SendData(byte[] datas)
        {
            lock (locker)
            {
                if (this._serialPort.IsOpen)
                    this._serialPort.Write(datas, 0, datas.Length);
            }
        }

        /// <summary>
        /// 该方法默认使用Unicode编码解析字符串
        /// </summary>
        /// <param name="msg"></param>
        public void SendData(string msg)
        {
            Encoding ecoding = Encoding.Unicode;
            SendData(msg, ecoding);
        }

        public void SendData(string msg, Encoding ecoding)
        {
            byte[] datas = ecoding.GetBytes(msg);
            SendData(datas);
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] datas = new byte[this._serialPort.BytesToRead];
            this._serialPort.Read(datas, 0, datas.Length);
            if (this.HasReceivedData != null)
                this.HasReceivedData(datas);
        }

        /// <summary>
        /// 获取当前计算机所有可用的串口
        /// </summary>
        /// <returns></returns>
        public static string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }
    }
}
