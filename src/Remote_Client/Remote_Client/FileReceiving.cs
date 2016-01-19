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
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Timers;

namespace Remote_Client
{
    public partial class FileReceiving : Form
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
        
        private Socket SocketFileAccepting;//用于文件接受连接的Socket
        private Socket SocketFileReceiving;//用于文件接受数据的Socket
        private bool bool_SocketFileAcceptingIsExisted;//用于文件接受连接的Socket是否存在
        private bool bool_SocketFileReceivingIsExisted;//用于文件接受数据的Socket是否存在
        private Byte[] Byte_BufferReceive = new Byte[4096];//缓冲为4KB
        private Byte[] Byte_BufferSend = new Byte[4096];//缓冲为4KB
        private bool bool_ReceivingFile;//是否正在接受文件数据
        private bool bool_WaitingForFileName;//是否正在等待文件名字
        private string string_ReceivingFileName;//接受文件的名字
        private long long_ReceivingFileSize;//接受文件的大小
        private long long_HaveBeenReceivedFileSize;//已经接受的文件大小
        private FileStream FS_FileReceiving;//文件接受写入流
        private DateTime DT_StartReceiving;//文件开始接受的时间
        private System.Timers.Timer Timer_Speed;//文件接受计时器

        private Bitmap Bt_BackGround;//背景图片

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern IntPtr SetCapture(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;

        public FileReceiving()
        {
            InitializeComponent();
        }

        private void FileReceiving_Shown(object sender, EventArgs e)
        {
            this.bool_WaitingForFileName = false;
            this.bool_ReceivingFile = false;

            this.SocketFileAccepting = ((Remote_Client)this.Owner).GetSocketFileAccepting;
            this.bool_SocketFileAcceptingIsExisted = true;

            this.SocketFileAccepting.Listen(1);
            this.SocketConnetingProcessStatusLabel.Text = "Socket正在监听...";

            this.Timer_Speed = new System.Timers.Timer(30);
            this.Timer_Speed.Elapsed += new ElapsedEventHandler(Timer_Speed_Tick);

            try
            {
                this.SocketFileAccepting.BeginAccept(new AsyncCallback(CallBack_Accpet), this.SocketFileAccepting);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "Socket准备接受连接时,错误!";
                this.Close();
            }
        }

        private void CallBack_Accpet(IAsyncResult IAR)
        {
            try
            {
                if (!this.bool_SocketFileAcceptingIsExisted) return;

                Socket S = (Socket)IAR.AsyncState;
                this.SocketFileReceiving = S.EndAccept(IAR);

                this.bool_SocketFileReceivingIsExisted = true;

                this.SocketConnetingProcessStatusLabel.Text = "Socket成功接受连接!";

                this.SocketFileReceiving.SendBufferSize = 4096;
                this.SocketFileReceiving.ReceiveBufferSize = 4096;

                this.bool_WaitingForFileName = true;
                
                while (true)
                {
                    try
                    {
                        if (!this.bool_SocketFileAcceptingIsExisted || !this.bool_SocketFileReceivingIsExisted) return;

                        int int_NumHaveBeenReceived = this.SocketFileReceiving.Receive(Byte_BufferReceive, SocketFlags.None);
                        Byte[] Byte_Receive = new Byte[int_NumHaveBeenReceived];
                        Array.Copy(Byte_BufferReceive, 0, Byte_Receive, 0, int_NumHaveBeenReceived);
                        this.SocketConnetingProcessStatusLabel.Text = "Socket消息成功接受!";

                        long temp;
                        if (Int64.TryParse(System.Text.Encoding.Default.GetString(Byte_Receive), out temp))
                        {
                            switch (temp % COMMAND_NUM)
                            {
                                case COMMAND_FILESENDINGBEGIN://15
                                    break;
                                case COMMAND_FILESENDINGACK://16
                                    break;
                                case COMMAND_FILESENDINGDECLINE://17
                                    (new Notification("对面取消了您的文件传输")).ShowDialog(this);
                                    if (this.bool_ReceivingFile)
                                    {
                                        this.FS_FileReceiving.Close();
                                        FileInfo FI = new FileInfo(this.string_ReceivingFileName);
                                        FI.Delete();
                                    }
                                    if(this.bool_SocketFileReceivingIsExisted) this.SocketFileReceiving.Shutdown(SocketShutdown.Both);
                                    this.SocketFileReceiving.Close();
                                    this.bool_SocketFileReceivingIsExisted = false;
                                    this.bool_SocketFileAcceptingIsExisted = false;
                                    this.SocketFileAccepting.Close();
                                    this.Close();
                                    break;
                                case COMMAND_FILESENDINGEND://18
                                    break;
                                case COMMAND_FILESENDINGREQUESTPORT://19
                                    break;
                                case COMMAND_FILESENDINGERROR://20
                                    (new Notification("对面文件传输错误")).ShowDialog(this);
                                    if (this.bool_ReceivingFile)
                                    {
                                        this.FS_FileReceiving.Close();
                                        FileInfo FI = new FileInfo(this.string_ReceivingFileName);
                                        FI.Delete();
                                    }
                                    if(this.bool_SocketFileReceivingIsExisted) this.SocketFileReceiving.Shutdown(SocketShutdown.Both);
                                    this.SocketFileReceiving.Close();
                                    this.bool_SocketFileReceivingIsExisted = false;
                                    this.bool_SocketFileAcceptingIsExisted = false;
                                    this.SocketFileAccepting.Close();
                                    this.Close();
                                    break;
                            }
                        }
                        else
                        {
                            if (this.bool_WaitingForFileName)
                            {
                                string string_temp = System.Text.Encoding.Default.GetString(Byte_Receive);
                                int int_temp = string_temp.LastIndexOf(" ");
                                this.string_ReceivingFileName = string_temp.Substring(0, int_temp);
                                this.long_ReceivingFileSize = Int64.Parse(string_temp.Substring(int_temp + 1));
                                if (this.string_ReceivingFileName.Length <= 20) this.文件名.Text = this.文件名.Text + this.string_ReceivingFileName;
                                else this.文件名.Text += this.文件名.Text + this.string_ReceivingFileName.Substring(0, 20) + "...";
                                this.文件大小.Text +=  ((long)(1.0 * this.long_ReceivingFileSize / 1024)).ToString() + "KB";
                                this.bool_WaitingForFileName = false;
                            }
                            if (this.bool_ReceivingFile)
                            {
                                try
                                {
                                    this.DT_StartReceiving = DateTime.Now;
                                    this.Timer_Speed.Enabled = true;
                                    if (this.long_ReceivingFileSize - this.long_HaveBeenReceivedFileSize < 4096)
                                    {
                                        this.FS_FileReceiving.Write(Byte_Receive, 0, (int)(this.long_ReceivingFileSize - this.long_HaveBeenReceivedFileSize));
                                        this.long_HaveBeenReceivedFileSize = this.long_ReceivingFileSize; 
                                    }
                                    else
                                    {
                                        this.FS_FileReceiving.Write(Byte_Receive, 0, Byte_Receive.Length);
                                        this.long_HaveBeenReceivedFileSize += Byte_BufferReceive.Length;
                                    }


                                    this.ProgressBar.Value = (int)(1.0 * this.long_HaveBeenReceivedFileSize / this.long_ReceivingFileSize * 100);
                                    this.Percent.Text = this.ProgressBar.Value.ToString() + "%";
                                    if (this.long_HaveBeenReceivedFileSize == this.long_ReceivingFileSize)
                                    {
                                        this.bool_ReceivingFile = false;
                                        this.StatusStrip.Text = "接受完毕！";
                                        (new Notification("接受文件完毕")).ShowDialog(this);
                                        if (this.bool_SocketFileReceivingIsExisted) this.SocketFileReceiving.Shutdown(SocketShutdown.Both);
                                        this.SocketFileReceiving.Close();
                                        this.bool_SocketFileReceivingIsExisted = false;
                                        this.bool_SocketFileAcceptingIsExisted = false;
                                        this.SocketFileAccepting.Close();
                                        this.Close();
                                    }
                                    this.Timer_Speed.Enabled = false;
                                }
                                catch(Exception e)
                                {
                                    this.function_SendOrder(COMMAND_FILESENDINGERROR);
                                    this.SocketConnetingProcessStatusLabel.Text = "Socket接受文件时,发生错误!";
                                    MessageBox.Show(e.ToString());
                                    if (this.bool_ReceivingFile)
                                    {
                                        this.FS_FileReceiving.Close();
                                        FileInfo FI = new FileInfo(this.string_ReceivingFileName);
                                        FI.Delete();
                                    }
                                    if (this.bool_SocketFileReceivingIsExisted) this.SocketFileReceiving.Shutdown(SocketShutdown.Both);
                                    this.SocketFileReceiving.Close();
                                    this.bool_SocketFileReceivingIsExisted = false;
                                    this.bool_SocketFileAcceptingIsExisted = false;
                                    this.SocketFileAccepting.Close();
                                    this.Close();

                                }
                            }
                        }
                    
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        this.SocketConnetingProcessStatusLabel.Text = "Socket接受消息时,未设置的socket错误!";
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "Socket完成接受连接时,Socket非法操作!";
                if (this.bool_SocketFileReceivingIsExisted) this.SocketFileReceiving.Close();
                this.bool_SocketFileReceivingIsExisted = false;
                this.Close();
            }
        }

        private void 另存为_Click(object sender, EventArgs e)
        {
            SaveFileDialog SF = new SaveFileDialog();
            SF.InitialDirectory = @"C:\Users\Administrator\Desktop\";
            SF.Filter = @"所有文件|*.*";
            SF.FilterIndex = 1;
            SF.RestoreDirectory = true;
            SF.Title = "另存为";
            SF.FileName = this.string_ReceivingFileName;
            if (SF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.string_ReceivingFileName = SF.FileName;
                this.bool_ReceivingFile = true;
                this.FS_FileReceiving = new FileStream(this.string_ReceivingFileName, FileMode.Append, FileAccess.Write);
                this.long_HaveBeenReceivedFileSize = 0;
                this.function_SendOrder(COMMAND_FILESENDINGBEGIN);
            }
        }

        private void 取消_Click(object sender, EventArgs e)
        {
            this.function_SendOrder(COMMAND_FILESENDINGDECLINE);

            if (this.bool_ReceivingFile)
            {
                this.FS_FileReceiving.Close();
                FileInfo FI = new FileInfo(this.string_ReceivingFileName);
                FI.Delete();
            }

            if(this.bool_SocketFileReceivingIsExisted) this.SocketFileReceiving.Shutdown(SocketShutdown.Both);
            this.SocketFileReceiving.Close();
            this.bool_SocketFileReceivingIsExisted = false;
            this.bool_SocketFileAcceptingIsExisted = false;
            this.SocketFileAccepting.Close();
            (new Notification("您取消了文件传输")).ShowDialog(this);
            this.Close();
        }

        private void function_SendOrder(int command)
        {
            string stringTemp = command.ToString();
            Byte[] byte_SendOrder = System.Text.Encoding.Default.GetBytes(stringTemp);
            try
            {
                this.SocketFileReceiving.Send(byte_SendOrder, 0, byte_SendOrder.Length, SocketFlags.None);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                this.SocketConnetingProcessStatusLabel.Text = "发送Socket时,未设置的错误!";
            }
        }

        private void FileReceiving_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.bool_SocketFileReceivingIsExisted) this.SocketFileReceiving.Close();
            this.bool_SocketFileReceivingIsExisted = false;
            if (this.bool_SocketFileAcceptingIsExisted) this.SocketFileAccepting.Close();
            this.bool_SocketFileAcceptingIsExisted = false;
        }

        private void FileReceiving_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE | HTCAPTION, 0);
            }
        }

        private void FileReceiving_Load(object sender, EventArgs e)
        {
            this.Bt_BackGround = new Bitmap(Properties.Resources.BGI, this.ClientRectangle.Width, this.ClientRectangle.Height);
            //加载鼠标
            this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Cursor.GetHicon());
        }

        private void FileReceiving_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Bt_BackGround, 0, 0, this.Bt_BackGround.Size.Width, this.Bt_BackGround.Size.Height);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            return;
        }

        private void FileReceiving_Resize(object sender, EventArgs e)
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
            this.Speed.Text = "传输速度:" + ((int)(1.0 * this.long_HaveBeenReceivedFileSize / 1024 / 1024 / ((DateTime.Now - this.DT_StartReceiving).TotalMilliseconds / 1000))).ToString() + "MB/S";
        }
    }
}
