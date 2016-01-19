using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows;
using System.Runtime.InteropServices;
using System.IO;
using System.Timers;
using System.Drawing.Drawing2D;

namespace Remote_Client
{
    public partial class Remote_Client : Form
    {
        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////以下区域是定义的一些控制消息以及常用的常量,开始
        //////////////////////////////////////////////////////////////////////////////////
        private const int COMMAND_SCREENPROJECTINGBEGIN = 0;//屏幕投射开始
        private const int COMMAND_CONTROLLINGBEGIN = 1;//屏幕控制开始
        private const int COMMAND_SCREENPROJECTINGDECLINE = 2;//屏幕投射请求拒绝
        private const int COMMAND_TEST = 3;//消息测试
        private const int COMMAND_SCREENPROJECTINGEND = 4;//屏幕投射结束
        private const int COMMAND_SCREENSIZE = 5;//发送屏幕宽度和高度
        private const int COMMAND_SCREENPROJECTINGACK = 6;//屏幕投影同意private const int COMMAND_SCREENPROJECTINGACK = 6;//屏幕投影同意
        private const int COMMAND_SCREENPROKECTINGTIMERTIC = 7;//屏幕投影开启时钟
        private const int COMMAND_CONTROLLINGACK = 8;//屏幕控制同意
        private const int COMMAND_CONTROLLINGEND = 9;//屏幕控制结束
        private const int COMMAND_CONTROLLINGDECLINE = 10;//屏幕控制请求拒绝
        private const int COMMAND_MOUSEMOVE = 11;//鼠标移动
        private const int COMMAND_MOUSELEFTDOUBLECLICK = 12;//鼠标左键双击
        private const int COMMAND_MOUSELEFTCLICK = 13;//鼠标左键单击
        private const int COMMAND_MOUSERIGHTCLICK = 14;//鼠标右键单击
        private const int COMMAND_FILESENDINGBEGIN = 15;//文件传送开始
        private const int COMMAND_FILESENDINGACK = 16;//文件传送同意
        private const int COMMAND_FILESENDINGDECLINE = 17;//文件传送请求拒绝
        private const int COMMAND_FILESENDINGEND = 18;//文件传送结束
        private const int COMMAND_FILESENDINGREQUESTPORT = 19;//文件传输请求

        private const int COMMAND_NUM = 1000;//COMMAND命令总数不会超过1000个

        /////////////////////////////////////////////////////////////////////////////////////
        ///////////////结束
        /////////////////////////////////////////////////////////////////////////////////////
      
        private Socket SocketListening;//本客户端程序的侦听socket变量
        private Socket SocketClient;//本客户端程序的socket变量
        private bool bool_SocketListeningIsExisted;//侦听socket变量是否存在
        private bool bool_SocketClientIsExisted;//客户端程序的socket变量是否存在

        private static NetworkInterface[] NIS = NetworkInterface.GetAllNetworkInterfaces();//本地网络适配器数组变量
        private bool bool_AvailableNetExisting;//本地是否有可用的网络存在
        private bool bool_AvailableAdapterExisting;//本地是否有可用的网络适配器存在
        private Thread Thread_TestingAvailableNet;//线程,用来时刻检查本机是否有网络适配器以及可用网络
        private Thread Thread_TestingSocketConnected;//线程,用来时刻检查本机socket是否连通
        private bool bool_SocketConnected;//本机socket是否连通

        private Thread Thread_AccpetSocket;//线程,用来接受socket
        private ManualResetEvent ManualResetEvent_Thread_AccpetSocketSuspend;//线程Thread_AccpetSocket是否挂起
        private int int_NumAvailableSocket;//可以用的Socket数目
        private int int_NumSumSocket;//总共的Socket数目
        private bool bool_Thread_AccpetSocketIsExisted;//线程Thread_AccpetSocketIsExisted是否存在

        private static Byte[] Byte_BufferReceive = new Byte[1024];//接受数据的缓冲区大小为1K
        private Thread Thread_ReceiveSocket;//线程,用来收socket消息
        private ManualResetEvent ManualResetEvent_Thread_ReceiveSocketSuspend;//线程Thread_ReceiveSocket是否挂起
        private bool bool_Thread_ReceiveSocketIsExisted;//线程Thread_ReceiveSocketIsExisted是否存在
        private System.Timers.Timer TIMERSCREENPROJECTING;

        private Bitmap Bt_BackGround;//背景图片

        private System.Timers.Timer TIMERMainFormVerticalMove;//窗口垂直移动的计时器

        private Socket SocketFileAccepting;//用于文件接受连接的Socket
        private FileReceiving FR;//用于文件接受的窗口
        private Thread thread_FileReceivingForm;//用于创建文件接受窗口的线程

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern IntPtr SetCapture(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;
        //private static int index = 0;
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_WHEEL = 0x0800;
        private const int MOUSEEVENTF_XDOWN = 0x0080;
        private const int MOUSEEVENTF_XUP = 0x0100;
        private const int MOUSEEVENTF_HWHEEL = 0x01000;

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point P);

        [DllImport("user32.dll")]
        public static extern IntPtr GetCursor();

        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public Point ptScreenPos;
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);
        
        public Remote_Client()
        {
            InitializeComponent();
        }
        
        public NetworkInterface[] GetNIS
        {
            get { return NIS; }
        }

        public Socket GetSocketFileAccepting
        {
            get { return this.SocketFileAccepting; }
        }

        private void 说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instruction instruction = new Instruction();
            instruction.ShowDialog();
        }

        private void 制作信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information Inf = new Information();
            Inf.ShowDialog();
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Remote_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseWindow Dialog_CloseWindow = new CloseWindow();
            DialogResult result = Dialog_CloseWindow.ShowDialog(this);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void 最小化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Remote_Client_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && this.WindowState == FormWindowState.Normal)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE | HTCAPTION, 0);
            }
        }

        private void Remote_Client_MouseMove(object sender, MouseEventArgs e)
        {
            this.toolStripStatusLabel1.Text = /*index.ToString() + " " + */e.X.ToString() + " " + e.Y.ToString();
            //index++;
        }

        private void Remote_Client_Load(object sender, EventArgs e)
        {
            //建立一个线程时刻检查本机是否有网络适配器以及可用网络
            this.Thread_TestingAvailableNet = new Thread(new ThreadStart(threadfunction_TestingAvailableNet));
            this.Thread_TestingAvailableNet.Start();

            //建立一个线程时刻检查本机socket是否连通
            this.Thread_TestingSocketConnected = new Thread(new ThreadStart(threadfunction_TestingSocketConnected));
            this.Thread_TestingSocketConnected.Start();

            //设置可接受连接的Socket数目
            this.int_NumSumSocket = 1;
            this.int_NumAvailableSocket = this.int_NumSumSocket;

            //设置SocketListening不存在
            this.bool_SocketListeningIsExisted = false;

            //设置SocketClient不存在
            this.bool_SocketClientIsExisted = false;
            
            //设置Thread_AccpetSocketIsExisted不存在
            this.bool_Thread_AccpetSocketIsExisted = false;

            //设置Thread_ReceiveSocketIsExisted不存在
            this.bool_Thread_ReceiveSocketIsExisted = false;

            //建立计时器
            TIMERSCREENPROJECTING = new System.Timers.Timer(500);
            TIMERSCREENPROJECTING.Elapsed += new ElapsedEventHandler(TIMERSCREENPROJECTING_TIC);

            //加载背景图片
            this.Bt_BackGround = new Bitmap(Properties.Resources.BGI, this.ClientRectangle.Width, this.ClientRectangle.Height);

            //加载菜单与状态栏的颜色
            this.MenuStrip.BackColor = Color.FromArgb(10, 133, 194);
            this.StatusStrip.BackColor = Color.FromArgb(166, 210, 233);

            //加载并初始化NotifyIcon
            this.NotifyIcon.Icon = Properties.Resources.HEARTONE;
            this.NotifyIcon.Text = this.AvailableNetStatusLabel.Text + "\n" + this.SocketConnectedStatusLabel.Text + "\n" + this.SocketConnetingProcessStatusLabel.Text;

            //加载窗口图标
            this.Icon = Properties.Resources.ICO;

            //加载主窗口垂直运动的计时器
            this.TIMERMainFormVerticalMove = new System.Timers.Timer(30);
            this.TIMERMainFormVerticalMove.Elapsed += new ElapsedEventHandler(TIMERMainFormVerticalMove_TIC);
            this.TIMERMainFormVerticalMove.Enabled = true;

            //加载鼠标
            this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Cursor.GetHicon());
            this.MenuStrip.Cursor = this.ContextMenuStrip.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Cursor.GetHicon());
            this.ContextMenuStrip.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Cursor.GetHicon());
        }

        private void threadfunction_TestingAvailableNet()
        {
            //预先假设本机没有可用的网络适配器以及没有可用的网络
            this.AvailableNetStatusLabel.Text = "本机没有可用的网络适配器,没有可用的网络！";
            this.bool_AvailableAdapterExisting = false;
            this.bool_AvailableNetExisting = false;
            //线程循环正式开始
            while (true)
            {
                if (NIS == null || NIS.Length < 1)
                {
                    if (this.bool_AvailableAdapterExisting)
                    {
                        this.AvailableNetStatusLabel.Text = "本机没有可用的网络适配器,没有可用的网络！";
                        this.bool_AvailableAdapterExisting = false;
                        this.bool_AvailableNetExisting = false;
                    }
                }
                else
                {
                    if (!this.bool_AvailableAdapterExisting) this.bool_AvailableAdapterExisting = true;

                    if (NetworkInterface.GetIsNetworkAvailable())
                    {
                        if (!this.bool_AvailableNetExisting)
                        {
                            this.bool_AvailableNetExisting = true;
                            this.AvailableNetStatusLabel.Text = "本机有可用的网络适配器,有可用的网络连接！";
                        }
                    }
                    else
                    {
                        if (this.bool_AvailableNetExisting)
                        {
                            this.bool_AvailableNetExisting = false;
                            this.AvailableNetStatusLabel.Text = "本机有可用的网络适配器,没有可用的网络连接！";
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private void threadfunction_TestingSocketConnected()
        {
            try
            {
                byte[] temp = new byte[1];
                this.SocketClient.Send(temp, 0, 0);
                this.SocketConnectedStatusLabel.Text = "Socket is connected";
                bool_SocketConnected = true;
            }
            catch (SocketException e)
            {
                if (e.NativeErrorCode.Equals(10035))
                {
                    this.SocketConnectedStatusLabel.Text = "Socket is connected, but the Send will be blocked";
                    bool_SocketConnected = true;
                }
                else
                {
                    this.SocketConnectedStatusLabel.Text = "Socket is not connected,错误代码:" + e.NativeErrorCode.ToString();
                    bool_SocketConnected = false;
                }
            }
            catch (Exception)
            {
                this.SocketConnectedStatusLabel.Text = "Socket is not existed";
                bool_SocketConnected = false;
            }

            while (true)
            {
                if (SocketClient != null)
                {
                    if (SocketClient.Connected)
                    {
                        if (!bool_SocketConnected)
                        {
                            this.SocketConnectedStatusLabel.Text = "Socket is connected";
                            bool_SocketConnected = true;
                        }

                    }
                    else
                    {
                        if (bool_SocketConnected)
                        {
                            this.SocketConnectedStatusLabel.Text = "Socket is not connected";
                            bool_SocketConnected = false;
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private void Remote_Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.bool_Thread_AccpetSocketIsExisted) this.Thread_AccpetSocket.Abort();
            if (this.bool_Thread_ReceiveSocketIsExisted) this.Thread_ReceiveSocket.Abort();
            this.Thread_TestingSocketConnected.Abort();
            this.Thread_TestingAvailableNet.Abort();
        }

        private void 本机联机情况ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfOfLocalHostNet IOLHN = new InfOfLocalHostNet();
            IOLHN.ShowDialog(this);
        }

        private void 开始侦听ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.SocketListening = new Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
                
                this.bool_SocketListeningIsExisted = true;
                
                this.SocketListening.Bind(new IPEndPoint(IPAddress.Any, 1000));
                this.SocketListening.Listen(this.int_NumSumSocket);
                this.SocketConnetingProcessStatusLabel.Text = "Socket正在监听...";
                this.开始侦听ToolStripMenuItem.Enabled = false;
                this.结束侦听ToolStripMenuItem.Enabled = true;

                this.Thread_AccpetSocket = new Thread(new ThreadStart(threadfunction_AccpetSocket));
                this.ManualResetEvent_Thread_AccpetSocketSuspend = new ManualResetEvent(false);

                this.bool_Thread_AccpetSocketIsExisted = true;

                this.Thread_AccpetSocket.Start();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "Socket侦听时,错误!";
                if (this.bool_SocketListeningIsExisted) this.SocketListening.Close();
                this.bool_SocketListeningIsExisted = false;
            }
        }

        private void threadfunction_AccpetSocket()
        {
            while (true)
            {
                try
                {
                    if (this.int_NumAvailableSocket > 0)
                    {
                        this.int_NumAvailableSocket--;
                        this.SocketListening.BeginAccept(new AsyncCallback(CallBack_Accpet), this.SocketListening);
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.ToString());
                    this.SocketConnetingProcessStatusLabel.Text = "Socket准备接受连接时,错误!";
                    this.int_NumAvailableSocket++;
                }
                if (this.int_NumAvailableSocket == 0)
                {
                    this.ManualResetEvent_Thread_AccpetSocketSuspend.Reset();
                    this.ManualResetEvent_Thread_AccpetSocketSuspend.WaitOne();
                }
            }
        }
        
        private void CallBack_Accpet(IAsyncResult IAR)
        {
            try
            {
                if (!this.bool_SocketListeningIsExisted || !this.bool_Thread_AccpetSocketIsExisted) return;

                Socket S = (Socket)IAR.AsyncState;
                this.SocketClient = S.EndAccept(IAR);

                this.bool_SocketClientIsExisted = true;

                this.开始侦听ToolStripMenuItem.Enabled = false;
                this.断开连接ToolStripMenuItem.Enabled = true;
                this.SocketConnetingProcessStatusLabel.Text = "Socket成功接受连接!";

                //以下开始创建线程接受Socket消息
                SocketClient.SendBufferSize = 40 * 1024;
                SocketClient.ReceiveBufferSize = 40 * 1024;
                this.Thread_ReceiveSocket = new Thread(new ThreadStart(threadfunction_ReceiveSocket));
                this.ManualResetEvent_Thread_ReceiveSocketSuspend = new ManualResetEvent(false);

                this.bool_Thread_ReceiveSocketIsExisted = true;

                this.Thread_ReceiveSocket.Start();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "Socket完成接受连接时,错误!";
                if (this.bool_SocketClientIsExisted) this.SocketClient.Close();
                this.bool_SocketClientIsExisted = false;
                this.int_NumAvailableSocket++;
                if (this.int_NumAvailableSocket == 1) this.ManualResetEvent_Thread_AccpetSocketSuspend.Set();
            }
        }

        private void threadfunction_ReceiveSocket()
        {
            //以下开始无限循环接受Socket消息
            while (true)
            {
                try
                {
                    this.SocketClient.BeginReceive(Byte_BufferReceive, 0, Byte_BufferReceive.Length, SocketFlags.None, new AsyncCallback(CallBack_Receive), this.SocketClient);
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.ToString());
                    this.SocketConnetingProcessStatusLabel.Text = "Socket开始接受消息时,错误!";
                }
                this.ManualResetEvent_Thread_ReceiveSocketSuspend.Reset();
                this.ManualResetEvent_Thread_ReceiveSocketSuspend.WaitOne();
            }
        
        }

        private void CallBack_Receive(IAsyncResult IAR)
        {
            try
            {
                if (!this.bool_SocketClientIsExisted || !this.bool_Thread_ReceiveSocketIsExisted) return;
                
                Socket S = (Socket)IAR.AsyncState;
                int int_NumHaveBeenReceived = S.EndReceive(IAR);
                Byte[] Byte_Receive = new Byte[int_NumHaveBeenReceived];
                Array.Copy(Byte_BufferReceive, 0, Byte_Receive, 0, int_NumHaveBeenReceived);
                this.SocketConnetingProcessStatusLabel.Text = "Socket消息成功接受!";
                if (int_NumHaveBeenReceived == 0)
                {
                    this.TIMERSCREENPROJECTING.Enabled = false;

                    if (this.bool_Thread_ReceiveSocketIsExisted) this.Thread_ReceiveSocket.Abort();
                    this.bool_Thread_ReceiveSocketIsExisted = false;

                    this.SocketClient.Shutdown(SocketShutdown.Both);
                    this.SocketClient.Close();
                    this.bool_SocketClientIsExisted = false;

                    this.SocketConnetingProcessStatusLabel.Text = "Socket成功断开,并继续侦听!";
                    this.断开连接ToolStripMenuItem.Enabled = false;
                    this.int_NumAvailableSocket++;
                    if (this.int_NumAvailableSocket == 1) this.ManualResetEvent_Thread_AccpetSocketSuspend.Set();
                }
                else
                {
                    this.ManualResetEvent_Thread_ReceiveSocketSuspend.Set();

                    long temp;
                    if(Int64.TryParse(System.Text.Encoding.Default.GetString(Byte_Receive), out temp))
                    {
                        switch (temp % COMMAND_NUM)
                        {
                            case COMMAND_SCREENPROJECTINGBEGIN: //0
                                DialogResult DR = (new Notification("对方想监视您的屏幕,同意吗？")).ShowDialog(this);
                                if (DR == System.Windows.Forms.DialogResult.Yes) this.function_SendOrder(COMMAND_SCREENPROJECTINGACK);
                                else this.function_SendOrder(COMMAND_SCREENPROJECTINGDECLINE);
                                break;
                            case COMMAND_CONTROLLINGBEGIN: //1
                                DialogResult dr = (new Notification("对方想控制您的屏幕,同意吗？")).ShowDialog(this);
                                if (dr == System.Windows.Forms.DialogResult.Yes) this.function_SendOrder(COMMAND_CONTROLLINGACK);
                                else this.function_SendOrder(COMMAND_CONTROLLINGDECLINE);
                                break;
                            case COMMAND_SCREENPROJECTINGDECLINE: //2
                                break;
                            case COMMAND_TEST: //3
                                break;
                            case COMMAND_SCREENPROJECTINGEND: //4
                                this.TIMERSCREENPROJECTING.Enabled = false;
                                (new Notification("屏幕投射结束")).ShowDialog(this);
                                break;
                            case COMMAND_SCREENSIZE://5
                                this.function_SendOrder(Screen.PrimaryScreen.Bounds.Height * (long)Math.Pow(10, 11) + Screen.PrimaryScreen.Bounds.Width * 10000 + COMMAND_SCREENSIZE);
                                break;
                            case COMMAND_SCREENPROJECTINGACK://6
                                break;
                            case COMMAND_SCREENPROKECTINGTIMERTIC://7
                                TIMERSCREENPROJECTING.Enabled = true;
                                //MessageBox.Show("111", "");
                                break;
                            case COMMAND_CONTROLLINGACK://8
                                break;
                            case COMMAND_CONTROLLINGEND://9
                                this.function_SendOrder(COMMAND_CONTROLLINGEND);
                                (new Notification("屏幕控制结束")).ShowDialog(this);
                                break;
                            case COMMAND_CONTROLLINGDECLINE://10
                                break;
                            case COMMAND_MOUSEMOVE://11
                                SetCursorPos((int)(temp % (long)Math.Pow(10, 11) / 10000), (int)(temp / (long)Math.Pow(10, 11)));
                                //MessageBox.Show(((int)(temp % (long)Math.Pow(10, 11) / 10000)).ToString());
                                break;
                            case COMMAND_MOUSELEFTDOUBLECLICK://12
                                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                                break;
                            case COMMAND_MOUSELEFTCLICK://13
                                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                                break;
                            case COMMAND_MOUSERIGHTCLICK://14
                                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                                break;
                            case COMMAND_FILESENDINGBEGIN://15
                                break;
                            case COMMAND_FILESENDINGACK://16
                                break;
                            case COMMAND_FILESENDINGDECLINE://17
                                break;
                            case COMMAND_FILESENDINGEND://18
                                break;
                            case COMMAND_FILESENDINGREQUESTPORT://19
                                this.SocketFileAccepting = new Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
                                this.SocketFileAccepting.Bind(new IPEndPoint(IPAddress.Any, 0));
                                this.function_SendOrder(((IPEndPoint)this.SocketFileAccepting.LocalEndPoint).Port * 1000 + COMMAND_FILESENDINGREQUESTPORT);
                                this.thread_FileReceivingForm = new Thread(new ThreadStart(functionthread_FileReceivingForm));
                                this.thread_FileReceivingForm.SetApartmentState(ApartmentState.STA);
                                this.thread_FileReceivingForm.Start();
                                break;
                        }
                    }
                }               
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "Socket完成接受消息时,错误!";
            }
        }

        private void functionthread_FileReceivingForm()
        {
            this.FR = new FileReceiving();
            this.FR.ShowDialog(this);
        }

        private void TIMERSCREENPROJECTING_TIC(object source, ElapsedEventArgs e)
        {
            this.function_ScreenProjecting();
        }

        private void function_ScreenProjecting()
        {
            Bitmap Bm_temp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g_temp = Graphics.FromImage(Bm_temp);
            MemoryStream MS_temp = new MemoryStream();

            g_temp.CopyFromScreen(0, 0, 0, 0, Bm_temp.Size);

            CURSORINFO CRS;
            CRS.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
            GetCursorInfo(out CRS);
            Cursor cur = new Cursor(CRS.hCursor);
            //MessageBox.Show(this, cur.Size.ToString());
            cur.Draw(g_temp, new Rectangle(CRS.ptScreenPos.X - (Cursors.Arrow.Size.Width - cur.Size.Width), CRS.ptScreenPos.Y - (Cursors.Arrow.Size.Height - cur.Size.Height), cur.Size.Width, cur.Size.Height));

            Bm_temp.Save(MS_temp, System.Drawing.Imaging.ImageFormat.Jpeg);
            //Bm_temp.Save("111.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            

            Byte[] byte_temp = MS_temp.GetBuffer();

            //MessageBox.Show(byte_temp.Length.ToString(), "");

            try
            {
                this.SocketClient.BeginSend(byte_temp, 0, byte_temp.Length, SocketFlags.None, new AsyncCallback(CallBack_Send), this.SocketClient);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "开始发送Socket消息时,错误!";
            }

            MS_temp.Close();
            g_temp.Dispose();
            Bm_temp.Dispose();
        }

        private void function_SendOrder(long command)
        {
            string stringTemp = command.ToString();
            Byte[] byte_SendOrder = System.Text.Encoding.Default.GetBytes(stringTemp);
            try
            {
                this.SocketClient.BeginSend(byte_SendOrder, 0, byte_SendOrder.Length, SocketFlags.None, new AsyncCallback(CallBack_Send), this.SocketClient);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "开始发送Socket消息时,错误!";
            }
        }

        private void CallBack_Send(IAsyncResult IAR)
        {
            try
            {
                Socket S = (Socket)IAR.AsyncState;
                int int_NumHaveBeenSend = S.EndSend(IAR);
                this.SocketConnetingProcessStatusLabel.Text = "成功发送Socket消息!";
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "完成发送Socket消息时,错误!";
            }
        }

        private void 断开连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult DR = (new Notification("您确定要关闭Socket连接吗？")).ShowDialog(this);
            if (DR == DialogResult.Yes)
            {
                try
                {
                    this.SocketClient.Shutdown(SocketShutdown.Both);
                    this.SocketClient.BeginDisconnect(false, new AsyncCallback(CallBack_DisConnect), this.SocketClient);

                }
                catch (Exception E)
                {
                    MessageBox.Show(E.ToString());
                    this.SocketConnetingProcessStatusLabel.Text = "Socket准备断开连接时,错误!";
                }
            }
        }

        private void CallBack_DisConnect(IAsyncResult IAR)
        {
            try
            {
                Socket S = (Socket)IAR.AsyncState;
                S.EndDisconnect(IAR);
                this.SocketConnetingProcessStatusLabel.Text = "Socket成功断开,并继续侦听!";

                this.TIMERSCREENPROJECTING.Enabled = false;
                
                if (this.bool_Thread_ReceiveSocketIsExisted) this.Thread_ReceiveSocket.Abort();
                this.bool_Thread_ReceiveSocketIsExisted = false;

                if(this.bool_SocketClientIsExisted)this.SocketClient.Close();
                this.bool_SocketClientIsExisted = false;

                this.断开连接ToolStripMenuItem.Enabled = false;
                this.int_NumAvailableSocket++;
                if (this.int_NumAvailableSocket == 1) this.ManualResetEvent_Thread_AccpetSocketSuspend.Set();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "Socket完成断开连接时,错误!";
            }
        }

        private void 结束侦听ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult DR = (new Notification("您确定要关闭Socket连接吗？这将会同时关闭正在连接的Socket。")).ShowDialog(this);
            if (DR == DialogResult.Yes)
            {
                this.开始侦听ToolStripMenuItem.Enabled = true;
                this.结束侦听ToolStripMenuItem.Enabled = false;
                this.断开连接ToolStripMenuItem.Enabled = false;
                this.SocketConnetingProcessStatusLabel.Text = "Socket结束侦听!";

                this.TIMERSCREENPROJECTING.Enabled = false;
                this.TIMERSCREENPROJECTING.Close();
                
                if (this.bool_Thread_ReceiveSocketIsExisted) this.Thread_ReceiveSocket.Abort();
                this.bool_Thread_ReceiveSocketIsExisted = false;

                if (this.bool_SocketClientIsExisted)
                {
                    this.SocketClient.Shutdown(SocketShutdown.Both);
                    this.SocketClient.Close();
                }
                this.bool_SocketClientIsExisted = false;

                if (this.bool_Thread_AccpetSocketIsExisted) this.Thread_AccpetSocket.Abort();
                this.bool_Thread_AccpetSocketIsExisted = false;

                if (this.bool_SocketListeningIsExisted)
                {
                    this.SocketListening.Close();
                }
                this.bool_SocketListeningIsExisted = false;

                this.int_NumAvailableSocket = this.int_NumSumSocket;
            }
        }

        private void tESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.function_SendOrder(COMMAND_TEST);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            return;
        }
        
        

        private void Remote_Client_Resize(object sender, EventArgs e)
        {
            int radius = 20;
            Rectangle R = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath GP = new GraphicsPath();
            GP.AddArc(R.X, R.Y, radius * 2, radius * 2, 180, 90);
            GP.AddLine(R.X + radius, R.Y, R.Right - radius, R.Y);
            GP.AddArc(R.Right - radius * 2, R.Y, radius * 2, radius * 2, 270, 90);
            GP.AddLine(R.Right, R.Y + radius, R.Right, R.Bottom - radius);
            GP.AddArc(R.Right - radius * 2, R.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            GP.AddLine(R.Right - radius, R.Bottom, R.X + radius, R.Bottom);
            GP.AddArc(R.X, R.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            GP.AddLine(R.X, R.Y + radius, R.X, R.Bottom - radius);
            GP.CloseFigure();
            this.Region = new Region(GP);
        }

        private void Mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.ShowInTaskbar = true;
                }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.最小化窗口ToolStripMenuItem.Enabled = false;
                    if (this.ShowInTaskbar == false) this.隐藏窗口ToolStripMenuItem.Enabled = false;
                }
                else
                {
                    this.最小化窗口ToolStripMenuItem.Enabled = true;
                    this.隐藏窗口ToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void 隐藏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.NotifyIcon.ShowBalloonTip(500, "通知", "您的窗口已经被隐藏到这里\n单击图标可恢复您的窗口", ToolTipIcon.None);
        }

        private void Remote_Client_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Bt_BackGround, 0, 0, this.Bt_BackGround.Size.Width, this.Bt_BackGround.Size.Height);
        }

        private void Remote_Client_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.最小化窗口ToolStripMenuItem.Enabled = true;
                this.隐藏窗口ToolStripMenuItem.Enabled = true;
                Point P;
                GetCursorPos(out P);
                this.ContextMenuStrip.Show(P);
            }
        }

        private void 最小化窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void 隐藏窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.NotifyIcon.ShowBalloonTip(500, "通知", "您的窗口已经被隐藏到这里\n单击图标可恢复您的窗口", ToolTipIcon.None);
        }

        private void 关闭窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TIMERMainFormVerticalMove_TIC(object source, ElapsedEventArgs e)
        {
            if (this.Bounds.Contains(Cursor.Position))
            {
                if (this.Location.Y < 0)
                {
                    if (this.Location.Y + 40 <= 0) this.Location = new Point(this.Location.X, this.Location.Y + 40);
                    else this.Location = new Point(this.Location.X, 0);
                }
            }
            else
            {
                if (this.Location.Y <= 0 && this.Location.Y >= -10000)//为了屏蔽最小化
                {
                    if (this.Location.Y - 40 >= -(this.Height - 2)) this.Location = new Point(this.Location.X, this.Location.Y - 40);
                    else this.Location = new Point(this.Location.X, -(this.Height - 2));
                }
            }
        }

        private void Remote_Client_LocationChanged(object sender, EventArgs e)
        {
            if (this.Location.Y > 0 && this.Location.Y < 30) this.Location = new Point(this.Location.X, 0);
        }
    }
}
