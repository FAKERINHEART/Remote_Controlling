﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Remote_Controller
{
    public partial class InfOfLocalHostNet : Form
    {
        public InfOfLocalHostNet()
        {
            InitializeComponent();
        }
        private Bitmap Bt_BackGround;//窗口背景图片

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern IntPtr SetCapture(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;

        private void InfOfLocalHostNet_Load(object sender, EventArgs e)
        {          
            this.InfOfLocalHostNetLabel.Text = "本机共有网络适配器" + ((Remote_Controller)this.Owner).GetNIS.Length.ToString() + "个:" + "\n";
            int index1 = 0;
            foreach (NetworkInterface NI in ((Remote_Controller)this.Owner).GetNIS)
            {
                this.InfOfLocalHostNetLabel.Text += (++index1).ToString() + "." + NI.Name + ":\n";
                IPInterfaceProperties IPIPS = NI.GetIPProperties();
                UnicastIPAddressInformationCollection UIPAIC = IPIPS.UnicastAddresses;
                int index2 = 0;
                foreach (UnicastIPAddressInformation UIPAI in UIPAIC)
                {
                    this.InfOfLocalHostNetLabel.Text += "(" + (++index2).ToString() + ")" + "." + UIPAI.Address.ToString() + "\n";
                }
            }

            this.Bt_BackGround = new Bitmap(Properties.Resources.BGI, this.ClientRectangle.Width, this.ClientRectangle.Height);
            //加载鼠标
            this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.Cursor.GetHicon());
        }

        private void InfOfLocalHostNet_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE | HTCAPTION, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            return;
        }

        private void InfOfLocalHostNet_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Bt_BackGround, 0, 0, this.Bt_BackGround.Size.Width, this.Bt_BackGround.Size.Height);
        }

        private void InfOfLocalHostNet_Resize(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}