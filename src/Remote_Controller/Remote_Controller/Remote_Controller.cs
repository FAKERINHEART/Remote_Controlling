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
using System.Drawing.Drawing2D;
using System.Timers;


namespace Remote_Controller
{
    public partial class Remote_Controller : Form
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
        private const int COMMAND_SCREENPROJECTINGACK = 6;//屏幕投影同意
        private const int COMMAND_SCREENPROKECTINGTIMERTIC = 7;//屏幕投影开启时钟
        private const int COMMAND_CONTROLLINGACK = 8;//屏幕控制同意
        private const int COMMAND_CONTROLLINGEND = 9;//屏幕控制结束
        private const int COMMAND_CONTROLLINGDECLINE = 10;//屏幕控制请求拒绝
        private const int COMMAND_MOUSEMOVE = 11;//鼠标移动
        private const int COMMAND_MOUSELEFTDOUBLECLICK = 12;//鼠标左键双击
        private const int COMMAND_MOUSELEFTCLICK = 13;//鼠标左键单击
        private const int COMMADN_MOUSERIGHTCLICK = 14;//鼠标右键单击
        private const int COMMAND_FILESENDINGBEGIN = 15;//文件传送开始
        private const int COMMAND_FILESENDINGACK = 16;//文件传送同意
        private const int COMMAND_FILESENDINGDECLINE = 17;//文件传送请求拒绝
        private const int COMMAND_FILESENDINGEND = 18;//文件传送结束
        private const int COMMAND_FILESENDINGREQUESTPORT = 19;//文件传输请求新端口

        private const int COMMAND_NUM = 1000;//COMMAND命令总数不会超过1000个

        /////////////////////////////////////////////////////////////////////////////////////
        ///////////////结束
        /////////////////////////////////////////////////////////////////////////////////////
        
        private bool bool_MainMenuStripIsHidden;//菜单是否隐藏
        private Socket SocketController;//本控制程序的发送socket变量
        private IPEndPoint RemoteIP;//远端IP地址
        private bool bool_SocketControllerIsExisted;//SocketController是否存在
        
        private static NetworkInterface[] NIS = NetworkInterface.GetAllNetworkInterfaces();//本地网络适配器数组变量
        private bool bool_AvailableNetExisting;//本地是否有可用的网络存在
        private bool bool_AvailableAdapterExisting;//本地是否有可用的网络适配器存在
        private Thread Thread_TestingAvailableNet;//线程,用来时刻检查本机是否有网络适配器以及可用网络
        private Thread Thread_TestingSocketConnected;//线程,用来时刻检查本机socket是否连通
        private bool bool_SocketConnected;//本机socket是否连通


        private Byte[] Byte_BufferReceive;//接受数据的缓冲区大小
        private Thread Thread_ReceiveSocket;//线程,用来收socket消息
        private ManualResetEvent ManualResetEvent_Thread_ReceiveSocketSuspend;//线程Thread_ReceiveSocket是否挂起
        private bool bool_Thread_ReceiveSocketIsExisted;//线程Thread_ReceiveSocketIsExisted是否存在
        private MemoryStream MS_ScreenProjecting;//ScreenProjecting的MemoryStream


        private Bitmap Bt_BackGround;//窗口背景图片
        private Bitmap Bt_NotProjectingBackGround;//非投影时大小时窗口的背景图片
        private Bitmap Bt_ProjectingBackGround;//Projecting时窗口的背景图片
        private double double_RemotePCScreenWidth;//远程PC的屏幕宽度
        private double double_RemotePCScreenHeight;//远程PC的屏幕高度
        private double double_ScaledRemotePCScreenWidth;//调整后的远程PC的屏幕宽度
        private double double_ScaledRemotePCScreenHeight;//调整后的远程PC的屏幕高度
        private Size Size_NotProjectingClientSize;//非投影时客户区的大小
        private Size Size_ProjectingClientSize;//投影时客户区的大小
        private Point Point_NotProjectingClientSize;//非投影时客户区的左上角的位置
        private Point Point_ProjectingClientSize;//投影时客户区的左上角的位置
        private bool bool_BeScreenProjecting;//是否正在进行屏幕投射
        private bool bool_BeControlling;//是否正在进行屏幕控制
        private int int_OldMousePointX;//鼠标移动前的窗口坐标X
        private int int_OldMousePointY;//鼠标移动前的窗口坐标Y

        private System.Timers.Timer TIMERMainFormVerticalMove;//窗口垂直移动的计时器

        private Socket SocketFileSending;//用于文件传递的Socket
        private IPEndPoint RemoteIPFileSending;//文件传递的远端目的IP
        private FileInfo FI_SocketFileSending;//所要传递的文件信息
        private FileSending FS;//用于文件传递的窗口
        private Thread thread_FileSendingForm;//用于创建文件传递窗口的线程

        //private static int index = 0;

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
        public static extern bool GetCursorPos(out Point P);

        public Remote_Controller()
        {
            InitializeComponent();
        }

        public IPEndPoint SetRemoteIP
        {
            set { RemoteIP = value; }
        }

        public NetworkInterface[] GetNIS
        {
            get { return NIS; }
        }

        public Byte[] SetByte_BufferReceive
        {
            set { Byte_BufferReceive = value; }
        }

        public Socket GetSocketFileSending
        {
            get { return SocketFileSending; }
        }

        public IPEndPoint GetRemoteIPFileSending
        {
            get { return RemoteIPFileSending; }
        }

        public FileInfo GetFI_SocketFileSending
        {
            get { return this.FI_SocketFileSending; }
        }

        private void Remote_Controller_MouseMove(object sender, MouseEventArgs e)
        {
            this.toolStripStatusLabel1.Text = /*index.ToString() + " " + */e.X.ToString() + " " + e.Y.ToString();
            //index++;
            if (this.bool_BeScreenProjecting)
            {
                if (e.Y <= 0)
                {
                    this.MenuStrip.Visible = true;
                    this.Mini.Visible = true;
                    this.Close.Visible = true;
                    this.bool_MainMenuStripIsHidden = false;
                }
                else
                {
                    if (!this.bool_MainMenuStripIsHidden)
                    {
                        this.MenuStrip.Visible = false;
                        this.Mini.Visible = false;
                        this.Close.Visible = false;
                        this.bool_MainMenuStripIsHidden = true;
                    }
                }
            }

            if (this.bool_BeControlling)
            { 
                //////////////////////////////////////////////////////////////////////////////
                if (e.X != this.int_OldMousePointX || e.Y != this.int_OldMousePointY)
                {
                    this.function_SendOrder((int)(e.Y / this.double_ScaledRemotePCScreenHeight * this.double_RemotePCScreenHeight) * (long)Math.Pow(10, 11) + (int)(e.X / this.double_ScaledRemotePCScreenWidth * this.double_RemotePCScreenWidth) * 10000 + COMMAND_MOUSEMOVE);
                    //MessageBox.Show(((int)(e.Y / this.double_ScaledRemotePCScreenHeight * this.double_RemotePCScreenHeight) * (long)Math.Pow(10, 11) + (int)(e.X / this.double_ScaledRemotePCScreenWidth * this.double_RemotePCScreenWidth) * 10000 + COMMAND_MOUSEMOVE).ToString());
                    this.int_OldMousePointX = e.X;
                    this.int_OldMousePointY = e.Y;
                }
            }
        }

        private void Remote_Controller_Load(object sender, EventArgs e)
        {
            //设置窗口显示的位置
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Size.Height) / 2);

            //初始化非投影时客户区的大小
            this.Size_NotProjectingClientSize = this.Size;

            //初始化非投影时客户区的左上角的位置
            this.Point_NotProjectingClientSize = this.Location;

            //设置菜单栏的隐藏判断变量为"否"
            this.bool_MainMenuStripIsHidden = false;
            
            //建立一个线程时刻检查本机是否有网络适配器以及可用网络
            this.Thread_TestingAvailableNet = new Thread(new ThreadStart(threadfunction_TestingAvailableNet));
            this.Thread_TestingAvailableNet.Start();
            
            //建立一个线程时刻检查本机socket是否连通
            this.Thread_TestingSocketConnected = new Thread(new ThreadStart(threadfunction_TestingSocketConnected));
            this.Thread_TestingSocketConnected.Start();
            
            //加载非投影时大小时窗口的背景图片
            this.Bt_NotProjectingBackGround = new Bitmap(Properties.Resources.BGI, this.ClientRectangle.Width, this.ClientRectangle.Height - this.StatusStrip.Height);

            this.Bt_BackGround = this.Bt_NotProjectingBackGround;

            //设置SocketController不存在
            this.bool_SocketControllerIsExisted = false;

            //线程Thread_ReceiveSocketIsExisted不存在
            this.bool_Thread_ReceiveSocketIsExisted = false;

            //现在没有进行屏幕投射
            this.bool_BeScreenProjecting = false;

            //现在没有在进行屏幕控制
            this.bool_BeControlling = false;

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

            //初始化ScreenProjecting的MemoryStream
            this.MS_ScreenProjecting = new MemoryStream();

            //加载鼠标
            this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Cursor.GetHicon());
            this.MenuStrip.Cursor = this.ContextMenuStrip.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Cursor.GetHicon());
            this.ContextMenuStrip.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Cursor.GetHicon());

            //初始化缓冲区大小
            InputingTheSizeOfBufferReceiving ITSOBR = new InputingTheSizeOfBufferReceiving();
            ITSOBR.ShowDialog(this);
            (new Notification("您的缓冲区被设置为了: " + (Byte_BufferReceive.Length / 1024).ToString() + "KB")).ShowDialog(this);
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 最小化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Remote_Controller_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseWindow Dialog_CloseWindow = new CloseWindow();
            DialogResult result = Dialog_CloseWindow.ShowDialog(this);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void 制作信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information Inf = new Information();
            Inf.ShowDialog();
        }

        private void 直接IP设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectInputingIP DII = new DirectInputingIP();
            DialogResult result =  DII.ShowDialog(this);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.开始连接ToolStripMenuItem.Enabled = true;
            }
        }

        private void 说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instruction instruction = new Instruction();
            instruction.ShowDialog();
        }

        private void 本机联网情况IPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfOfLocalHostNet IOLHN = new InfOfLocalHostNet();
            IOLHN.ShowDialog(this);
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
                this.SocketController.Send(temp, 0, 0);
                this.SocketConnectedStatusLabel.Text = "Socket is connected";
                bool_SocketConnected = true;
            }
            catch (SocketException e)
            {
                if (e.NativeErrorCode.Equals(10035))
                {
                    this.SocketConnectedStatusLabel.Text = "Socket is connected, but the Send will be blocked";
                    bool_SocketConnected = true;
                    this.bool_SocketControllerIsExisted = true;
                }
                else
                {
                    this.SocketConnectedStatusLabel.Text = "Socket is not connected,错误代码:" + e.NativeErrorCode.ToString();
                    bool_SocketConnected = false;
                    this.bool_SocketControllerIsExisted = false;
                }
            }
            catch (Exception)
            {
                this.SocketConnectedStatusLabel.Text = "Socket is not existed";
                bool_SocketConnected = false;
                this.bool_SocketControllerIsExisted = false;
            }
            
            while (true)
            {
                if (this.SocketController != null)
                {
                    if (SocketController.Connected)
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

        private void Remote_Controller_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.bool_Thread_ReceiveSocketIsExisted) this.Thread_ReceiveSocket.Abort();
            this.Thread_TestingSocketConnected.Abort();
            this.Thread_TestingAvailableNet.Abort();
        }

        private void 开始连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.SocketController = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
                
                this.bool_SocketControllerIsExisted = true;
                
                SocketController.BeginConnect(RemoteIP, new AsyncCallback(CallBack_Connect), SocketController);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "Socket准备连接时,未设置的Socket错误!";
                if (this.bool_SocketControllerIsExisted) this.SocketController.Close();
                this.bool_SocketControllerIsExisted = false;
            }
        }

        private void CallBack_Connect(IAsyncResult IAR)
        {
            try
            {
                Socket S = (Socket)IAR.AsyncState;
                S.EndConnect(IAR);
                
                this.直接IP设置ToolStripMenuItem.Enabled = false;
                this.开始连接ToolStripMenuItem.Enabled = false;
                this.断开连接ToolStripMenuItem.Enabled = true;
                if(this.Byte_BufferReceive.Length / 1024 != 1) this.开始投射ToolStripMenuItem.Enabled = true;
                this.文件传输ToolStripMenuItem.Enabled = true;
                this.SocketConnetingProcessStatusLabel.Text = "Socket成功连接!";

                //以下开始创建线程接受Socket消息
                this.SocketController.SendBufferSize = 40 * 1024;
                this.SocketController.ReceiveBufferSize = 40 * 1024;
                this.Thread_ReceiveSocket = new Thread(new ThreadStart(threadfunction_ReceiveSocket));
                this.ManualResetEvent_Thread_ReceiveSocketSuspend = new ManualResetEvent(false);

                this.bool_Thread_ReceiveSocketIsExisted = true;
                
                this.Thread_ReceiveSocket.Start();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "Socket完成连接时,未设置的Socket错误!";
                if (this.bool_SocketControllerIsExisted) this.SocketController.Close();
                this.bool_SocketControllerIsExisted = false;
            }

        }

        private void threadfunction_ReceiveSocket()
        {
            //以下开始无限循环接受Socket消息
            while (true)
            {
                try
                {
                    this.SocketController.BeginReceive(Byte_BufferReceive, 0, Byte_BufferReceive.Length, SocketFlags.None, new AsyncCallback(CallBack_Receive), this.SocketController);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    this.SocketConnetingProcessStatusLabel.Text = "Socket开始接受消息时,未设置的socket错误!";
                }
                this.ManualResetEvent_Thread_ReceiveSocketSuspend.Reset();
                this.ManualResetEvent_Thread_ReceiveSocketSuspend.WaitOne();
            }
        }

        private void CallBack_Receive(IAsyncResult IAR)
        {
            try
            {
                if (!this.bool_SocketControllerIsExisted || !this.bool_Thread_ReceiveSocketIsExisted) return;

                Socket S = (Socket)IAR.AsyncState;
                int int_NumHaveBeenReceived = S.EndReceive(IAR);
                
                Byte[] Byte_Receive = new Byte[int_NumHaveBeenReceived];
                Array.Copy(Byte_BufferReceive, 0, Byte_Receive, 0, int_NumHaveBeenReceived);
                this.SocketConnetingProcessStatusLabel.Text = "Socket消息成功接受!";

                if (int_NumHaveBeenReceived == 0)
                {
                    this.bool_BeControlling = false;
                    this.bool_BeScreenProjecting = false;

                    if (this.bool_Thread_ReceiveSocketIsExisted) this.Thread_ReceiveSocket.Abort();
                    this.bool_Thread_ReceiveSocketIsExisted = false;

                    this.SocketController.Shutdown(SocketShutdown.Both);
                    this.SocketController.Close();
                    this.bool_SocketControllerIsExisted = false;

                    this.SocketConnetingProcessStatusLabel.Text = "Socket成功断开!";
                    this.直接IP设置ToolStripMenuItem.Enabled = true;
                    this.断开连接ToolStripMenuItem.Enabled = false;
                    this.开始投射ToolStripMenuItem.Enabled = false;
                    this.结束投射ToolStripMenuItem.Enabled = false;
                    this.开始控制ToolStripMenuItem.Enabled = false;
                    this.结束控制ToolStripMenuItem.Enabled = false;
                    this.开始控制ToolStripMenuItem.Enabled = false;
                    this.结束控制ToolStripMenuItem.Enabled = false;
                    this.MenuStrip.Visible = true;
                    this.Mini.Visible = true;
                    this.Close.Visible = true;

                    this.Bt_BackGround = this.Bt_NotProjectingBackGround;
                    Invalidate();

                    this.Location = this.Point_NotProjectingClientSize;
                    this.Size = this.Size_NotProjectingClientSize;
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
                                break;
                            case COMMAND_CONTROLLINGBEGIN: //1
                                break;
                            case COMMAND_SCREENPROJECTINGDECLINE: //2
                                (new Notification("对面拒绝您屏幕投射的请求")).ShowDialog(this);
                                
                                this.开始投射ToolStripMenuItem.Enabled = true;
                                this.结束投射ToolStripMenuItem.Enabled = false;
                                break;
                            case COMMAND_TEST: //3
                                (new Notification("TEST")).ShowDialog(this);
                                break;
                            case COMMAND_SCREENPROJECTINGEND: //4
                                (new Notification("屏幕投射结束")).ShowDialog(this);
                                break;
                            case COMMAND_SCREENSIZE://5
                                //MessageBox.Show("5");
                                this.double_RemotePCScreenHeight = temp / (long)Math.Pow(10, 11);
                                this.double_RemotePCScreenWidth = temp % (long)Math.Pow(10, 11) / 10000;
                                //index++;

                                //MessageBox.Show(this, this.double_RemotePCScreenWidth.ToString() + this.double_RemotePCScreenHeight.ToString());
                                //设置屏幕投射时(窗口客户区-窗口状态栏)的大小
                                if (this.double_RemotePCScreenWidth > Screen.PrimaryScreen.WorkingArea.Width || (this.double_RemotePCScreenHeight + this.StatusStrip.Height) > Screen.PrimaryScreen.WorkingArea.Height)
                                {
                                    if (this.double_RemotePCScreenWidth / Screen.PrimaryScreen.WorkingArea.Width >= (this.double_RemotePCScreenHeight + this.StatusStrip.Height) / Screen.PrimaryScreen.WorkingArea.Height)
                                    {
                                        this.double_ScaledRemotePCScreenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                                        this.double_ScaledRemotePCScreenHeight = this.double_ScaledRemotePCScreenWidth / this.double_RemotePCScreenWidth * this.double_RemotePCScreenHeight;
                                    }
                                    else
                                    {
                                        this.double_ScaledRemotePCScreenHeight = Screen.PrimaryScreen.WorkingArea.Height - this.StatusStrip.Height;
                                        this.double_ScaledRemotePCScreenWidth = this.double_ScaledRemotePCScreenHeight / this.double_RemotePCScreenHeight * this.double_RemotePCScreenWidth;
                                    }
                                }
                                else
                                {
                                    this.double_ScaledRemotePCScreenWidth = this.double_RemotePCScreenWidth;
                                    this.double_ScaledRemotePCScreenHeight = this.double_RemotePCScreenHeight;
                                }    

                                this.Bt_ProjectingBackGround = new Bitmap(Properties.Resources.BGI, (int)(this.double_ScaledRemotePCScreenWidth), (int)(this.double_ScaledRemotePCScreenHeight));
                                this.Size_ProjectingClientSize = new Size((int)(this.double_ScaledRemotePCScreenWidth), (int)(this.double_ScaledRemotePCScreenHeight) + this.StatusStrip.Height);
                                this.Point_ProjectingClientSize = new Point((int)(Screen.PrimaryScreen.WorkingArea.Width - this.double_ScaledRemotePCScreenWidth) / 2, (int)(Screen.PrimaryScreen.WorkingArea.Height - this.double_ScaledRemotePCScreenHeight - this.StatusStrip.Height) / 2);
                                    
                                this.Bt_BackGround = this.Bt_ProjectingBackGround;
                                this.Invalidate();
                                this.Size = this.Size_ProjectingClientSize;
                                this.Location = this.Point_ProjectingClientSize;
                                this.MenuStrip.Visible = false;
                                this.Mini.Visible = false;
                                this.Close.Visible = false;

                                this.function_SendOrder(COMMAND_SCREENPROKECTINGTIMERTIC);//发送屏幕投影开启时钟命令
                                //MessageBox.Show("2");
                                this.开始投射ToolStripMenuItem.Enabled = false;
                                this.结束投射ToolStripMenuItem.Enabled = true;
                                this.bool_BeScreenProjecting = true;
                                this.开始控制ToolStripMenuItem.Enabled = true;
                                break;
                            case COMMAND_SCREENPROJECTINGACK://6
                                //发送一条COMMAND_SCREENSIZE询问对方PC屏幕的宽度与高度
                                //MessageBox.Show("6");
                                this.function_SendOrder(COMMAND_SCREENSIZE);
                                break;
                            case COMMAND_SCREENPROKECTINGTIMERTIC://7
                                break;
                            case COMMAND_CONTROLLINGACK://8
                                this.开始控制ToolStripMenuItem.Enabled = false;
                                this.结束控制ToolStripMenuItem.Enabled = true;
                                this.bool_BeControlling = true;
                                //初始化鼠标坐标
                                this.int_OldMousePointX = 0;
                                this.int_OldMousePointY = 0;
                                break;
                            case COMMAND_CONTROLLINGEND://9
                                //MessageBox.Show("屏幕控制结束", "通知", MessageBoxButtons.OK);
                                break;
                            case COMMAND_CONTROLLINGDECLINE://10
                                (new Notification("对面拒绝您屏幕控制的请求")).ShowDialog(this);
                                break;
                            case COMMAND_MOUSEMOVE://11
                                break;
                            case COMMAND_MOUSELEFTDOUBLECLICK://12
                                break;
                            case COMMAND_MOUSELEFTCLICK://13
                                break;
                            case COMMADN_MOUSERIGHTCLICK://14
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
                                this.SocketFileSending = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
                                this.RemoteIPFileSending = new IPEndPoint(this.RemoteIP.Address, (int)(temp / 1000));
                                this.thread_FileSendingForm = new Thread(new ThreadStart(threadfunction_FileSendingForm));
                                this.thread_FileSendingForm.SetApartmentState(ApartmentState.STA);
                                this.thread_FileSendingForm.Start();
                                break;
                        }
                    }
                    else
                    {
                        if (this.bool_BeScreenProjecting)
                        {
                            //MessageBox.Show("1");
                            this.MS_ScreenProjecting.WriteAsync(Byte_Receive, 0, Byte_Receive.Length);
                            try
                            {
                                this.Bt_ProjectingBackGround = new Bitmap((Bitmap)Image.FromStream(MS_ScreenProjecting), (int)this.double_ScaledRemotePCScreenWidth, (int)this.double_ScaledRemotePCScreenHeight);
                                this.Bt_BackGround = this.Bt_ProjectingBackGround;
                                this.Invalidate();
                                MS_ScreenProjecting.Seek(0, SeekOrigin.Begin);
                            }
                            catch
                            {
                                MS_ScreenProjecting.Close();
                                this.MS_ScreenProjecting = new MemoryStream();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "Socket完成接受消息时,错误!";
            }
        }

        private void threadfunction_FileSendingForm()
        {
            this.FS = new FileSending();
            this.FS.ShowDialog(this);
        }

        private void 断开连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult DR = (new Notification("您确定要关闭Socket连接吗？")).ShowDialog(this);
            if (DR == DialogResult.Yes)
            {
                try
                {
                    this.SocketController.Shutdown(SocketShutdown.Both);
                    this.SocketController.BeginDisconnect(false, new AsyncCallback(CallBack_DisConnect), this.SocketController);
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.ToString());
                    this.SocketConnetingProcessStatusLabel.Text = "Socket准备断开连接时,未设置的Socket错误!";
                }
            }
        }

        private void CallBack_DisConnect(IAsyncResult IAR)
        {
            try
            {
                Socket S = (Socket)IAR.AsyncState;
                S.EndDisconnect(IAR);

                this.SocketConnetingProcessStatusLabel.Text = "Socket成功断开!";

                if (this.bool_Thread_ReceiveSocketIsExisted) this.Thread_ReceiveSocket.Abort();
                this.bool_Thread_ReceiveSocketIsExisted = false;

                if (this.bool_SocketControllerIsExisted) this.SocketController.Close();
                this.bool_SocketControllerIsExisted = false;

                this.bool_BeControlling = false;
                this.bool_BeScreenProjecting = false;

                if (this.bool_BeScreenProjecting) this.Bt_ProjectingBackGround = new Bitmap(Properties.Resources.BGI, (int)(this.double_ScaledRemotePCScreenWidth), (int)(this.double_ScaledRemotePCScreenHeight));

                this.Bt_BackGround = this.Bt_NotProjectingBackGround;
                Invalidate();
     

                this.直接IP设置ToolStripMenuItem.Enabled = true;
                this.断开连接ToolStripMenuItem.Enabled = false;
                this.开始投射ToolStripMenuItem.Enabled = false;
                this.结束投射ToolStripMenuItem.Enabled = false;
                this.开始控制ToolStripMenuItem.Enabled = false;
                this.结束控制ToolStripMenuItem.Enabled = false;
                this.MenuStrip.Visible = true;
                this.Mini.Visible = true;
                this.Close.Visible = true;

                if (this.bool_BeScreenProjecting)
                {
                    this.Size = this.Size_NotProjectingClientSize;
                    this.Location = this.Point_NotProjectingClientSize;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "Socket完成断开连接时,错误!";
            }                           
        }

        private void function_SendOrder(long command)
        {
            string stringTemp = command.ToString();
            Byte[] byte_SendOrder = System.Text.Encoding.Default.GetBytes(stringTemp);
            try
            {
                this.SocketController.BeginSend(byte_SendOrder, 0, byte_SendOrder.Length, SocketFlags.None, new AsyncCallback(CallBack_Send), this.SocketController);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "开始发送Socket时,错误!";
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
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "完成发送Socket时,错误!";
            }
        }

        private void Remote_Controller_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && !this.bool_BeControlling)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE | HTCAPTION, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            return;
        }

        private void Remote_Controller_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Bt_BackGround, 0, 0, this.Bt_BackGround.Size.Width, this.Bt_BackGround.Size.Height);
        }

        private void 开始投射ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.function_SendOrder(COMMAND_SCREENPROJECTINGBEGIN);
        }

        private void 结束投射ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.bool_BeControlling = false;
            this.bool_BeScreenProjecting = false;

            this.function_SendOrder(COMMAND_SCREENPROJECTINGEND);

            this.Size = this.Size_NotProjectingClientSize;
            this.Location = this.Point_NotProjectingClientSize;

            this.开始投射ToolStripMenuItem.Enabled = true;
            this.结束投射ToolStripMenuItem.Enabled = false;
            this.开始控制ToolStripMenuItem.Enabled = false;
            this.结束控制ToolStripMenuItem.Enabled = false;

            this.Bt_ProjectingBackGround = new Bitmap(Properties.Resources.BGI, (int)(this.double_ScaledRemotePCScreenWidth), (int)(this.double_ScaledRemotePCScreenHeight));
            this.Bt_BackGround = this.Bt_NotProjectingBackGround;
            Invalidate();
        }

        private void 结束控制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.bool_BeControlling = false;
            this.function_SendOrder(COMMAND_CONTROLLINGEND);
            this.开始控制ToolStripMenuItem.Enabled = true;
            this.结束控制ToolStripMenuItem.Enabled = false;
        }

        private void 开始控制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.function_SendOrder(COMMAND_CONTROLLINGBEGIN);
        }

        private void Remote_Controller_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.bool_BeControlling)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    this.function_SendOrder(COMMAND_MOUSELEFTCLICK);
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this.function_SendOrder(COMMADN_MOUSERIGHTCLICK);
                }
            }
            else
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
        }

        private void Remote_Controller_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.bool_BeControlling)
            {
                //////////////////////////////////////////////////////////////////////////////////////////
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    this.function_SendOrder(COMMAND_MOUSELEFTDOUBLECLICK);
                }
            }
        }

        private void Remote_Controller_Resize(object sender, EventArgs e)
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
                if (this.Location.Y <= 0 && this.Location.Y >= -10000)//this.Location.Y >= -10000 是为了屏蔽最小化
                {
                    if (this.Location.Y - 40 >= -(this.Height - 2)) this.Location = new Point(this.Location.X, this.Location.Y - 40);
                    else this.Location = new Point(this.Location.X, -(this.Height - 2));
                }
            }
        }

        private void Remote_Controller_LocationChanged(object sender, EventArgs e)
        {
            if (this.Location.Y > 0 && this.Location.Y < 30) this.Location = new Point(this.Location.X, 0);
        }

        private void 文件传输ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.InitialDirectory = @"C:\Users\Administrator\Desktop\";
            OFD.Filter = @"所有文件|*.*";
            OFD.FilterIndex = 1;
            OFD.RestoreDirectory = true;
            OFD.Multiselect = false;
            OFD.Title = "选择文件夹|文件";
            if(OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.FI_SocketFileSending = new FileInfo(OFD.FileName);
                this.function_SendOrder(COMMAND_FILESENDINGREQUESTPORT);
            }
        }
    }
}
