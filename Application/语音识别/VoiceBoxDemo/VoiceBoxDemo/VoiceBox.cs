using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading;

namespace VoiceBoxDemo
{
    /// <summary>
    /// 语音盒的回传信息
    /// </summary>
    public enum VoiceBoxBackInfo
    {
        /// <summary>
        /// 初始化成功回传：上电芯片初始化成功后，芯片自动发送回传
        /// </summary>
        InitSuccess = 0x4A,
        /// <summary>
        /// 收到正确的命令帧回传
        /// </summary>
        ReceiveSuccess = 0x41,
        /// <summary>
        /// 收到不能识别命令帧回传
        /// </summary>
        ReceiveUnidentifiable = 0x45,
        /// <summary>
        /// 芯片忙碌状态回传：芯片处在正在合成状态，收到状态查询命令帧
        /// </summary>
        Status_Busy = 0x4E,
        /// <summary>
        /// 芯片空闲状态回传：芯片处在空闲状态，收到状态查询命令帧；或一帧数据合成结束，芯片处于空闲状态
        /// </summary>
        Status_Free = 0x4F,
        /// <summary>
        /// 这不是芯片恢复的指令，其表示当前语音合成被暂停
        /// </summary>
        Status_Pause = 0xFF,
    }

    /// <summary>
    /// 语音盒命令字，放在数据区第一个字节
    /// </summary>
    public enum VoiceBoxCommondWord
    {
        /// <summary>
        /// 语音合成命令
        /// </summary>
        StartCompound = 0x01,
        /// <summary>
        /// 停止合成命令，没有参数
        /// </summary>
        StopCompound = 0x02,
        /// <summary>
        /// 暂停合成命令，没有参数
        /// </summary>
        PauseCompound = 0x03,
        /// <summary>
        /// 恢复合成命令，没有参数
        /// </summary>
        RestoreCompund = 0x04,
        /// <summary>
        /// 芯片状态查询命令
        /// </summary>
        QueryStatus = 0x21,
        /// <summary>
        /// 芯片进入省电模式
        /// </summary>
        EnterPowerSavingMode = 0x88,
        /// <summary>
        /// 芯片从省电模式返回正常工作模式
        /// </summary>
        EnterNormalMode = 0xFF,
        /// <summary>
        /// 开始语音编码的命令
        /// </summary>
        StartSpeechCoding = 0x41,
        /// <summary>
        /// 开始语音解码的命令
        /// </summary>
        StartSpeechDecoding = 0x42,
        /// <summary>
        /// 解码帧数据发送
        /// </summary>
        SendDecodingData = 0x43,
        /// <summary>
        /// 停止录音或解码命令
        /// </summary>
        StopRecordAndDecoding = 0x44
    }

    public enum TextEncoding
    {
        GB2312 = 0x00,
        GBK = 0x01,
        BIG5 = 0x02,
        UNICODE = 0x03
    }

    public class VoiceBox
    {
        /// <summary>
        /// 固定帧头
        /// </summary>
        private const byte frameHeader = 0xFD;
        /// <summary>
        /// 每个包的最大字节数
        /// </summary>
        private const int cntEachPackage = 50;
        /// <summary>
        /// 停止合成语音
        /// </summary>
        private static readonly byte[] stopCompoundCmd = { frameHeader, 0x00, 0x01, (byte)VoiceBoxCommondWord.StopCompound };
        /// <summary>
        /// 暂停合成语音，可用【恢复】指令恢复合成
        /// </summary>
        private static readonly byte[] pauseCompoundCmd = { frameHeader, 0x00, 0x01, (byte)VoiceBoxCommondWord.PauseCompound };
        /// <summary>
        /// 恢复被暂停的语音合成
        /// </summary>
        private static readonly byte[] restoreCompoundCmd = { frameHeader, 0x00, 0x1, (byte)VoiceBoxCommondWord.RestoreCompund };
        /// <summary>
        /// 查询状态指令
        /// </summary>
        private static readonly byte[] queryStatusCmd = { frameHeader, 0x00, 0x01, (byte)VoiceBoxCommondWord.QueryStatus };
        /// <summary>
        /// 写【状态】锁对象
        /// </summary>
        private static readonly object locker = new object();

        private VoiceBoxBackInfo _status = VoiceBoxBackInfo.Status_Free;

        private SerialPortHelper _serialProtHelper = null;

        private bool _isPause = false, _isCancel = false, _isEmergency = false;

        /// <summary>
        /// 线程安全的语音播报队列
        /// </summary>
        private ConcurrentQueue<string> _compoundQueue = new ConcurrentQueue<string>();
        /// <summary>
        /// 线程安全的语音插播队列，其在当前语音播报完成后立即播报
        /// </summary>
        private ConcurrentQueue<string> _intercutQueue = new ConcurrentQueue<string>();

        private CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        public TextEncoding TextEncoding { get; set; }

        public Action<string> ReportReceivedData = null;

        public VoiceBox()
        {
            this.TextEncoding = TextEncoding.GB2312;
        }

        /// <summary>
        /// 未处理串口占用的异常
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        public void OpenSerialPort(string portName, int baudRate = 9600)
        {
            this._serialProtHelper = new SerialPortHelper(portName, baudRate);
            this._serialProtHelper.HasReceivedData = HasReceivedData;
            this._serialProtHelper.Open();
            this._cancelTokenSource = new CancellationTokenSource();
            StartCompound();
        }

        /// <summary>
        /// 关闭串口时将会调用CancelTokenSource.Cancel()将线程退出
        /// </summary>
        public void CloseSerialPort()
        {
            if (this._serialProtHelper != null)
                this._serialProtHelper.Close();
            this._cancelTokenSource.Cancel();
        }

        /// <summary>
        /// 排队等待播放
        /// </summary>
        /// <param name="msg"></param>
        public void QueueCompound(string msg)
        {
            this._compoundQueue.Enqueue(msg);
            Console.WriteLine("_compoundQueue:" + this._compoundQueue.Count + "    " + "_intercutQueue:" + this._intercutQueue.Count + "    " + this._status.ToString());
        }

        /// <summary>
        /// 在当前播报的语音结束后立即播报
        /// </summary>
        /// <param name="msg"></param>
        public void CommonIntercut(string msg)
        {
            this._intercutQueue.Enqueue(msg);
            Console.WriteLine("_compoundQueue:" + this._compoundQueue.Count + "    " + "_intercutQueue:" + this._intercutQueue.Count + "    " + this._status.ToString());
        }

        /// <summary>
        /// 立即播放紧急文本，注意：下一条紧急文本可以覆盖正在播放的紧急文本
        /// </summary>
        /// <param name="msg"></param>
        public void EmergencyIntercut(string msg)
        {
            SetStatus(VoiceBoxBackInfo.Status_Busy);
            Compound(msg);
            Console.WriteLine(msg + "    " + this._status.ToString());
        }

        /// <summary>
        /// 暂停当前正在播放的文本，并且不会播放下一条语音，直到恢复播放
        /// </summary>
        public void PauseCurrentCompound()
        {
            this._serialProtHelper.SendData(pauseCompoundCmd);
            SetStatus(VoiceBoxBackInfo.Status_Pause);
            SetPause(true);
        }

        /// <summary>
        /// 恢复被暂停的文本，恢复后做一次查询以确定当前状态
        /// </summary>
        public void RestoreCompound()
        {
            SetPause(false);
            this._serialProtHelper.SendData(restoreCompoundCmd);
            QueryStatus();
        }

        /// <summary>
        /// 取消当前语音，如果有下一条语音，则播放
        /// </summary>
        public void StopCurrentCompound()
        {
            SetCancel(true);
            this._serialProtHelper.SendData(stopCompoundCmd);
            SetStatus(VoiceBoxBackInfo.Status_Free);
        }

        /// <summary>
        /// 停止播放当前语音，并清空排队、插队的所有语音信息
        /// </summary>
        public void StopAllCompound()
        {
            SetCancel(true);
            this._serialProtHelper.SendData(stopCompoundCmd);
            SetStatus(VoiceBoxBackInfo.Status_Busy);
            string msg = string.Empty;
            Task.Factory.StartNew(() =>
            {
                while (this._compoundQueue.IsEmpty == false)
                    this._compoundQueue.TryDequeue(out msg);
                while (this._intercutQueue.IsEmpty == false)
                    this._intercutQueue.TryDequeue(out msg);
                SetStatus(VoiceBoxBackInfo.Status_Free);
            });
        }

        /// <summary>
        /// 将要发送的字节数组分割为每个不超过4k字节的包，备注：暂定每个包最大3k
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        private List<byte[]> SplitCompoundDatas(byte[] datas)
        {
            int dataCnt = datas.Length, offset = 0;
            List<byte> source = datas.ToList();
            List<byte[]> dest = new List<byte[]>();

            while (offset < dataCnt)
            {
                int cnt = dataCnt - offset;
                if (cnt > cntEachPackage)
                    cnt = cntEachPackage;
                byte[] tmp = new byte[cnt];
                source.CopyTo(offset, tmp, 0, cnt);
                dest.Add(tmp);
                offset += cnt;
            }
            return dest;
        }

        /// <summary>
        /// 查询当前语音盒状态，将会将查询线程阻塞50ms以保证得到查询结果
        /// </summary>
        private void QueryStatus()
        {
            this._serialProtHelper.SendData(queryStatusCmd);
            Thread.Sleep(50);
        }

        /// <summary>
        /// 语音合成
        /// </summary>
        /// <param name="msg"></param>
        private void Compound(string msg)
        {
            if (this._serialProtHelper == null)
                return;
            byte[] tmp = VoiceBox.GetEncoding(this.TextEncoding).GetBytes(msg);
            Compound(tmp);
        }

        /// <summary>
        /// 所有指令都通过这里完成传送
        /// </summary>
        /// <param name="datas"></param>
        private void Compound(byte[] datas)
        {
            SetStatus(VoiceBoxBackInfo.Status_Busy);
            if (datas.Length <= cntEachPackage)
            {
                byte[] tmp = GetInstructionByteArray(datas, VoiceBoxCommondWord.StartCompound);
                this._serialProtHelper.SendData(tmp);
            }
            else
            {
                SetPause(false); SetCancel(false);
                List<byte[]> list = SplitCompoundDatas(datas);
                foreach (var item in list)
                {
                    while (this._isPause) ;
                    while (this._status == VoiceBoxBackInfo.Status_Busy)
                        QueryStatus();
                    if (this._isCancel)
                        break;
                    byte[] tmp = GetInstructionByteArray(item, VoiceBoxCommondWord.StartCompound);
                    SetStatus(VoiceBoxBackInfo.Status_Busy);
                    this._serialProtHelper.SendData(tmp);
                }
            }
        }

        /// <summary>
        /// 启动线程播放语音，从队列中依次取出文本进行播放
        /// </summary>
        private void StartCompound()
        {
            string msg = string.Empty;
            SetStatus(VoiceBoxBackInfo.Status_Free);
            Task task = Task.Factory.StartNew(() =>
            {
                while (this._cancelTokenSource.IsCancellationRequested == false)
                {
                    WaitFree();

                    // 【插播队列】出队成功后不会执行【排队队列】出队
                    if (this._intercutQueue.TryDequeue(out msg) == false && this._compoundQueue.TryDequeue(out msg) == false)
                        continue;

                    Compound(msg);
                    Console.WriteLine(msg);
                }
            }, this._cancelTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        /// <summary>
        /// 阻塞，直到得到cnt次查询结果为free
        /// </summary>
        /// <param name="cnt"></param>
        private void WaitFree(int cnt = 15)
        {
            for (int i = 0; i < cnt; )
            {
                QueryStatus();
                if (this._status == VoiceBoxBackInfo.Status_Free)
                {
                    i += 1;
                    SetStatus(VoiceBoxBackInfo.Status_Busy);
                }
                //i = this._status == VoiceBoxBackInfo.Status_Free ? i + 1 : 0;
            }
        }

        /// <summary>
        /// 设置当前语音盒状态，加锁保证串行赋值
        /// </summary>
        /// <param name="status"></param>
        private void SetStatus(VoiceBoxBackInfo status)
        {
            lock (locker)
            {
                this._status = status;
            }
        }

        /// <summary>
        /// 设置语音盒播放状态，加锁保证串行赋值
        /// </summary>
        /// <param name="status"></param>
        private void SetCancel(bool isCancel)
        {
            lock (locker)
            {
                this._isCancel = isCancel;
            }
        }

        /// <summary>
        /// 设置语音盒播放状态，加锁保证串行赋值
        /// </summary>
        /// <param name="status"></param>
        private void SetPause(bool isPause)
        {
            lock (locker)
            {
                this._isPause = isPause;
            }
        }

        private byte lastStatus = 0;
        private void HasReceivedData(byte[] datas)
        {
            string info = string.Empty;
            if (datas.Length == 1)
            {
                switch ((VoiceBoxBackInfo)datas[0])
                {
                    case VoiceBoxBackInfo.InitSuccess:
                        SetStatus(VoiceBoxBackInfo.Status_Busy);
                        info = "初始化成功";
                        break;
                    case VoiceBoxBackInfo.ReceiveSuccess:
                        info = "收到正确指令";
                        break;
                    case VoiceBoxBackInfo.ReceiveUnidentifiable:
                        info = "收到错误指令";
                        break;
                    case VoiceBoxBackInfo.Status_Busy:
                        SetStatus(VoiceBoxBackInfo.Status_Busy);
                        info = "当前忙碌";
                        break;
                    case VoiceBoxBackInfo.Status_Free:
                        SetStatus(VoiceBoxBackInfo.Status_Free);
                        info = "当前空闲";
                        break;
                }

                if (datas[0] != lastStatus && this.ReportReceivedData != null)
                {
                    lastStatus = datas[0];
                    string msg = string.Empty;
                    foreach (var item in datas)
                    {
                        msg += item.ToString("X") + " ";
                    }
                    this.ReportReceivedData(msg + info);
                }
            }

            
        }

        /// <summary>
        /// 获取指令字节数组
        /// </summary>
        /// <returns></returns>
        private byte[] GetInstructionByteArray(string msg, VoiceBoxCommondWord cmdWord)
        {
            byte[] tmp = VoiceBox.GetEncoding(this.TextEncoding).GetBytes(msg);
            return GetInstructionByteArray(tmp, cmdWord);
        }

        private byte[] GetInstructionByteArray(byte[] msg, VoiceBoxCommondWord cmdWord)
        {
            List<byte> datas = new List<byte>();
            datas.Add(frameHeader);// 帧头
            datas.AddRange(VoiceBox.GetArrayLength(msg.Length + 2));// 数据包长度 = 数据长度 + 一个字节的命令字 + 一个字节的编码格式
            datas.Add((byte)cmdWord);// 命令字
            datas.Add((byte)this.TextEncoding);// 编码格式
            datas.AddRange(msg);// 数据包
            return datas.ToArray();
        }

        /// <summary>
        /// 根据TextEncoding获取具体的编码格式
        /// </summary>
        /// <param name="txtEncoding"></param>
        /// <returns></returns>
        private static Encoding GetEncoding(TextEncoding txtEncoding)
        {
            Encoding encoding = Encoding.Unicode;
            switch (txtEncoding)
            {
                case TextEncoding.GB2312:
                    encoding = Encoding.GetEncoding("GB2312");
                    break;
                case TextEncoding.GBK:
                    encoding = Encoding.GetEncoding("GBK");
                    break;
                case TextEncoding.BIG5:
                    encoding = Encoding.GetEncoding("BIG5");
                    break;
                case TextEncoding.UNICODE:
                    encoding = Encoding.Unicode;
                    break;
            }
            return encoding;
        }

        /// <summary>
        /// 将长度分解为两个字节，高字节在前，低字节在后
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private static byte[] GetArrayLength(int length)
        {
            byte[] ans = new byte[2];
            ans[0] = (byte)((length & 0xFF00) >> 8);
            ans[1] = (byte)(length & 0xFF);
            return ans;
        }
    }
}
