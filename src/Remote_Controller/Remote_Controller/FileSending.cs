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
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Timers;

namespace Remote_Controller
{
    public partial class FileSending : Form
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
        private const int COMMAND_FILESENDINGERROR = 20;//文件传输错误

        private const int COMMAND_NUM = 1000;//COMMAND命令总数不会超过1000个

        /////////////////////////////////////////////////////////////////////////////////////
        ///////////////结束
        /////////////////////////////////////////////////////////////////////////////////////

        private Bitmap Bt_BackGround;//窗口背景图片

        private Socket SocketFileSending;//用于文件传递的Socket
        private IPEndPoint RemoteIPFileSending;//文件传递的远端目的IP
        private bool bool_SocketFileSendingIsExisted;//用于文件传递的Socket是否存在
        private Byte[] Byte_BufferReceive = new Byte[4096];//缓冲为4KB
        private Byte[] Byte_BufferSend = new Byte[4096];//缓冲为4KB
        private FileInfo FI;
        private long long_HaveBeenSendedFileSize;//已经被发送了的文件大小
        private DateTime DT_StartSending;//文件开始发送的时间
        private System.Timers.Timer Timer_Speed;//文件传递计时器

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern IntPtr SetCapture(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;

        public FileSending()
        {
            InitializeComponent();
        }

        private void FileSending_Shown(object sender, EventArgs e)
        {
            this.SocketFileSending = ((Remote_Controller)this.Owner).GetSocketFileSending;
            this.RemoteIPFileSending = ((Remote_Controller)this.Owner).GetRemoteIPFileSending;
            this.FI = ((Remote_Controller)this.Owner).GetFI_SocketFileSending;
            this.bool_SocketFileSendingIsExisted = true;

            this.Timer_Speed = new System.Timers.Timer(30);
            this.Timer_Speed.Elapsed += new ElapsedEventHandler(Timer_Speed_Tick);

            try
            {
                this.SocketFileSending.BeginConnect(this.RemoteIPFileSending, new AsyncCallback(CallBack_Connect), this.SocketFileSending);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "Socket准备连接时,错误!";
                if (this.bool_SocketFileSendingIsExisted) this.SocketFileSending.Close();
                this.bool_SocketFileSendingIsExisted = false;
                this.Close();
            }
        }
        
        private void CallBack_Connect(IAsyncResult IAR)
        {
            try
            {
                Socket S = (Socket)IAR.AsyncState;
                S.EndConnect(IAR);

                this.SocketConnetingProcessStatusLabel.Text = "Socket成功连接!";

                this.SocketFileSending.SendBufferSize = 4096;
                this.SocketFileSending.ReceiveBufferSize = 4096;

                if(FI.Name.Length <= 20) this.文件名.Text = this.文件名.Text + FI.Name;
                else this.文件名.Text = this.文件名.Text + FI.Name.Substring(0, 20) + "...";
                this.文件大小.Text = this.文件大小.Text + ((long)(1.0 * FI.Length / 1024)).ToString() + "KB";
                this.function_SendString(FI.Name + " " + FI.Length.ToString());

                //以下开始接受Socket消息
                while (true)
                {
                    try
                    {
                        if (!this.bool_SocketFileSendingIsExisted) return;

                        int int_NumHaveBeenReceived = this.SocketFileSending.Receive(Byte_BufferReceive, 0, Byte_BufferReceive.Length, SocketFlags.None);
                        Byte[] Byte_Receive = new Byte[int_NumHaveBeenReceived];
                        Array.Copy(Byte_BufferReceive, 0, Byte_Receive, 0, int_NumHaveBeenReceived);
                        this.SocketConnetingProcessStatusLabel.Text = "Socket消息成功接受!";

                        long temp;
                        if (Int64.TryParse(System.Text.Encoding.Default.GetString(Byte_Receive), out temp))
                        {
                            switch (temp % COMMAND_NUM)
                            {
                                case COMMAND_FILESENDINGBEGIN://15
                                    FileStream FS_SEND;
                                    try
                                    {
                                        FS_SEND = new FileStream(this.FI.FullName, FileMode.Open, FileAccess.Read);
                                        this.long_HaveBeenSendedFileSize = 0;
                                        long NumDividedTCP = this.FI.Length / 4096;

                                        DT_StartSending = DateTime.Now;
                                        this.Timer_Speed.Enabled = true;
                                        long i = 0;
                                        for (i = 0; i < NumDividedTCP; i++)
                                        {
                                            FS_SEND.Read(this.Byte_BufferSend, 0, 4096);
                                            this.SocketFileSending.Send(this.Byte_BufferSend, 4096, SocketFlags.None);
                                            this.long_HaveBeenSendedFileSize += 4096;
                                            this.ProgressBar.Value = (int)(1.0 * this.long_HaveBeenSendedFileSize / this.FI.Length * 100);
                                            this.Percent.Text = this.ProgressBar.Value.ToString() + "%";
                                        }
                                        if (this.FI.Length % 4096 != 0)
                                        {
                                            FS_SEND.Read(this.Byte_BufferSend, 0, (int)(this.FI.Length - i * 4096));
                                            this.SocketFileSending.Send(this.Byte_BufferSend, (int)(this.FI.Length - i * 4096), SocketFlags.None);
                                            this.long_HaveBeenSendedFileSize += (this.FI.Length - i * 4096);
                                            this.ProgressBar.Value = (int)(1.0 * this.long_HaveBeenSendedFileSize / this.FI.Length * 100);
                                            this.Percent.Text = this.ProgressBar.Value.ToString() + "%";
                                        }
                                        this.Timer_Speed.Enabled = false;
                                        FS_SEND.Close();
                                        (new Notification("发送文件完毕")).ShowDialog(this);
                                        this.StatusStrip.Text = "发送完毕！";
                                    }
                                    catch(Exception e)
                                    {
                                        this.function_SendOrder(COMMAND_FILESENDINGERROR);
                                        MessageBox.Show(e.ToString());
                                        this.StatusStrip.Text = "发送错误！";
                                    }
                                    finally
                                    {
                                        if (this.bool_SocketFileSendingIsExisted) this.SocketFileSending.Shutdown(SocketShutdown.Both);
                                        this.SocketFileSending.Close();
                                        this.bool_SocketFileSendingIsExisted = false;
                                        this.Close();
                                    }
                                    break;
                                case COMMAND_FILESENDINGACK://16
                                    break;
                                case COMMAND_FILESENDINGDECLINE://
                                    if (this.bool_SocketFileSendingIsExisted) this.SocketFileSending.Shutdown(SocketShutdown.Both);
                                    this.SocketFileSending.Close();
                                    this.bool_SocketFileSendingIsExisted = false;
                                    (new Notification("对面取消了您的文件传输")).ShowDialog(this);
                                    this.Close();
                                    break;
                                case COMMAND_FILESENDINGEND://18
                                    break;
                                case COMMAND_FILESENDINGREQUESTPORT://19
                                    break;
                                case COMMAND_FILESENDINGERROR://20
                                    this.function_SendOrder(COMMAND_FILESENDINGERROR);
                                    (new Notification("对面文件接受错误")).ShowDialog(this);
                                    this.StatusStrip.Text = "对面文件接受错误！";
                                    if (this.bool_SocketFileSendingIsExisted) this.SocketFileSending.Shutdown(SocketShutdown.Both);
                                    this.SocketFileSending.Close();
                                    this.bool_SocketFileSendingIsExisted = false;
                                    this.Close();
                                    break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        this.SocketConnetingProcessStatusLabel.Text = "Socket接受消息时,错误!";
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "Socket完成连接时,未设置的Socket错误!";
                if (this.bool_SocketFileSendingIsExisted) this.SocketFileSending.Close();
                this.bool_SocketFileSendingIsExisted = false;
                this.Close();
            }
        }
        private void function_SendOrder(long command)
        {
            string stringTemp = command.ToString();
            Byte[] byte_SendOrder = System.Text.Encoding.Default.GetBytes(stringTemp);
            try
            {
                this.SocketFileSending.Send(byte_SendOrder, 0, byte_SendOrder.Length, SocketFlags.None);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "发送Socket时,错误!";
            }
        }

        private void function_SendString(String command)
        {
            Byte[] byte_SendOrder = System.Text.Encoding.Default.GetBytes(command);
            try
            {
                this.SocketFileSending.Send(byte_SendOrder, 0, byte_SendOrder.Length, SocketFlags.None);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "发送Socket时,错误!";
            }
        }

        private void FileSending_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.bool_SocketFileSendingIsExisted) this.SocketFileSending.Close();
            this.bool_SocketFileSendingIsExisted = false;
        }

        private void 取消_Click(object sender, EventArgs e)
        {
            this.function_SendOrder(COMMAND_FILESENDINGDECLINE);
            if(this.bool_SocketFileSendingIsExisted) this.SocketFileSending.Shutdown(SocketShutdown.Both);
            this.SocketFileSending.Close();
            this.bool_SocketFileSendingIsExisted = false;
            (new Notification("您取消了文件传输")).ShowDialog(this);
            this.Close();
        }

        private void FileSending_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE | HTCAPTION, 0);
            }
        }

        private void FileSending_Load(object sender, EventArgs e)
        {
            this.Bt_BackGround = new Bitmap(Properties.Resources.BGI, this.ClientRectangle.Width, this.ClientRectangle.Height);
            //加载鼠标
            this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Cursor.GetHicon());
        }

        private void FileSending_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Bt_BackGround, 0, 0, this.Bt_BackGround.Size.Width, this.Bt_BackGround.Size.Height);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            return;
        }

        private void FileSending_Resize(object sender, EventArgs e)
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

        private void Timer_Speed_Tick(object sender, EventArgs e)
        {
            this.Speed.Text = "传输速度:" + ((int)(1.0 * this.long_HaveBeenSendedFileSize / 1024 / 1024 / ((DateTime.Now - this.DT_StartSending).TotalMilliseconds / 1000))).ToString() + "MB/S";
        }
    }
}
