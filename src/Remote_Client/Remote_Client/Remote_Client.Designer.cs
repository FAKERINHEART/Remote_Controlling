namespace Remote_Client
{
    partial class Remote_Client
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Remote_Client));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始侦听ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束侦听ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.断开连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.本机联机情况ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tESTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最小化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.制作信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.AvailableNetStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SocketConnectedStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SocketConnetingProcessStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Mini = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.最小化窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.Transparent;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配置ToolStripMenuItem,
            this.窗口ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(797, 25);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连接ToolStripMenuItem,
            this.本机联机情况ToolStripMenuItem,
            this.tESTToolStripMenuItem});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.配置ToolStripMenuItem.Text = "配置";
            // 
            // 连接ToolStripMenuItem
            // 
            this.连接ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.连接ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始侦听ToolStripMenuItem,
            this.结束侦听ToolStripMenuItem,
            this.断开连接ToolStripMenuItem});
            this.连接ToolStripMenuItem.Name = "连接ToolStripMenuItem";
            this.连接ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.连接ToolStripMenuItem.Text = "连接";
            // 
            // 开始侦听ToolStripMenuItem
            // 
            this.开始侦听ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.开始侦听ToolStripMenuItem.Name = "开始侦听ToolStripMenuItem";
            this.开始侦听ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.开始侦听ToolStripMenuItem.Text = "开始侦听";
            this.开始侦听ToolStripMenuItem.Click += new System.EventHandler(this.开始侦听ToolStripMenuItem_Click);
            // 
            // 结束侦听ToolStripMenuItem
            // 
            this.结束侦听ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.结束侦听ToolStripMenuItem.Enabled = false;
            this.结束侦听ToolStripMenuItem.Name = "结束侦听ToolStripMenuItem";
            this.结束侦听ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.结束侦听ToolStripMenuItem.Text = "结束侦听";
            this.结束侦听ToolStripMenuItem.Click += new System.EventHandler(this.结束侦听ToolStripMenuItem_Click);
            // 
            // 断开连接ToolStripMenuItem
            // 
            this.断开连接ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.断开连接ToolStripMenuItem.Enabled = false;
            this.断开连接ToolStripMenuItem.Name = "断开连接ToolStripMenuItem";
            this.断开连接ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.断开连接ToolStripMenuItem.Text = "断开连接";
            this.断开连接ToolStripMenuItem.Click += new System.EventHandler(this.断开连接ToolStripMenuItem_Click);
            // 
            // 本机联机情况ToolStripMenuItem
            // 
            this.本机联机情况ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.本机联机情况ToolStripMenuItem.Name = "本机联机情况ToolStripMenuItem";
            this.本机联机情况ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.本机联机情况ToolStripMenuItem.Text = "本机联机情况";
            this.本机联机情况ToolStripMenuItem.Click += new System.EventHandler(this.本机联机情况ToolStripMenuItem_Click);
            // 
            // tESTToolStripMenuItem
            // 
            this.tESTToolStripMenuItem.Name = "tESTToolStripMenuItem";
            this.tESTToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.tESTToolStripMenuItem.Text = "TEST";
            this.tESTToolStripMenuItem.Click += new System.EventHandler(this.tESTToolStripMenuItem_Click);
            // 
            // 窗口ToolStripMenuItem
            // 
            this.窗口ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.最小化ToolStripMenuItem,
            this.隐藏ToolStripMenuItem,
            this.关闭ToolStripMenuItem});
            this.窗口ToolStripMenuItem.Name = "窗口ToolStripMenuItem";
            this.窗口ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.窗口ToolStripMenuItem.Text = "窗口";
            // 
            // 最小化ToolStripMenuItem
            // 
            this.最小化ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.最小化ToolStripMenuItem.Name = "最小化ToolStripMenuItem";
            this.最小化ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.最小化ToolStripMenuItem.Text = "最小化";
            this.最小化ToolStripMenuItem.Click += new System.EventHandler(this.最小化ToolStripMenuItem_Click);
            // 
            // 隐藏ToolStripMenuItem
            // 
            this.隐藏ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.隐藏ToolStripMenuItem.Name = "隐藏ToolStripMenuItem";
            this.隐藏ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.隐藏ToolStripMenuItem.Text = "隐藏";
            this.隐藏ToolStripMenuItem.Click += new System.EventHandler(this.隐藏ToolStripMenuItem_Click);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.关闭ToolStripMenuItem.Text = "关闭";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.说明ToolStripMenuItem,
            this.制作信息ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 说明ToolStripMenuItem
            // 
            this.说明ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.说明ToolStripMenuItem.Name = "说明ToolStripMenuItem";
            this.说明ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.说明ToolStripMenuItem.Text = "说明";
            this.说明ToolStripMenuItem.Click += new System.EventHandler(this.说明ToolStripMenuItem_Click);
            // 
            // 制作信息ToolStripMenuItem
            // 
            this.制作信息ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.制作信息ToolStripMenuItem.Name = "制作信息ToolStripMenuItem";
            this.制作信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.制作信息ToolStripMenuItem.Text = "制作信息";
            this.制作信息ToolStripMenuItem.Click += new System.EventHandler(this.制作信息ToolStripMenuItem_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.BackColor = System.Drawing.Color.Transparent;
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.AvailableNetStatusLabel,
            this.SocketConnectedStatusLabel,
            this.SocketConnetingProcessStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 274);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(797, 22);
            this.StatusStrip.TabIndex = 1;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // AvailableNetStatusLabel
            // 
            this.AvailableNetStatusLabel.Name = "AvailableNetStatusLabel";
            this.AvailableNetStatusLabel.Size = new System.Drawing.Size(80, 17);
            this.AvailableNetStatusLabel.Text = "当前网络状况";
            // 
            // SocketConnectedStatusLabel
            // 
            this.SocketConnectedStatusLabel.Name = "SocketConnectedStatusLabel";
            this.SocketConnectedStatusLabel.Size = new System.Drawing.Size(95, 17);
            this.SocketConnectedStatusLabel.Text = "Socket是否连通";
            // 
            // SocketConnetingProcessStatusLabel
            // 
            this.SocketConnetingProcessStatusLabel.Name = "SocketConnetingProcessStatusLabel";
            this.SocketConnetingProcessStatusLabel.Size = new System.Drawing.Size(95, 17);
            this.SocketConnetingProcessStatusLabel.Text = "Socket连接过程";
            // 
            // Mini
            // 
            this.Mini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Mini.BackgroundImage = global::Remote_Client.Properties.Resources.MINI;
            this.Mini.Location = new System.Drawing.Point(702, 0);
            this.Mini.Name = "Mini";
            this.Mini.Size = new System.Drawing.Size(38, 23);
            this.Mini.TabIndex = 5;
            this.Mini.UseVisualStyleBackColor = true;
            this.Mini.Click += new System.EventHandler(this.Mini_Click);
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.Image = ((System.Drawing.Image)(resources.GetObject("Close.Image")));
            this.Close.Location = new System.Drawing.Point(738, 0);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(39, 23);
            this.Close.TabIndex = 4;
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.BalloonTipText = "您的窗口已经被隐藏到这里\r\n单击图标可恢复您的窗口";
            this.NotifyIcon.BalloonTipTitle = "通知";
            this.NotifyIcon.ContextMenuStrip = this.ContextMenuStrip;
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.最小化窗口ToolStripMenuItem,
            this.隐藏窗口ToolStripMenuItem,
            this.关闭窗口ToolStripMenuItem});
            this.ContextMenuStrip.Name = "FormContextMenuStrip";
            this.ContextMenuStrip.Size = new System.Drawing.Size(137, 70);
            // 
            // 最小化窗口ToolStripMenuItem
            // 
            this.最小化窗口ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.最小化窗口ToolStripMenuItem.Name = "最小化窗口ToolStripMenuItem";
            this.最小化窗口ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.最小化窗口ToolStripMenuItem.Text = "最小化窗口";
            this.最小化窗口ToolStripMenuItem.Click += new System.EventHandler(this.最小化窗口ToolStripMenuItem_Click);
            // 
            // 隐藏窗口ToolStripMenuItem
            // 
            this.隐藏窗口ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.隐藏窗口ToolStripMenuItem.Name = "隐藏窗口ToolStripMenuItem";
            this.隐藏窗口ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.隐藏窗口ToolStripMenuItem.Text = "隐藏窗口";
            this.隐藏窗口ToolStripMenuItem.Click += new System.EventHandler(this.隐藏窗口ToolStripMenuItem_Click);
            // 
            // 关闭窗口ToolStripMenuItem
            // 
            this.关闭窗口ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.关闭窗口ToolStripMenuItem.Name = "关闭窗口ToolStripMenuItem";
            this.关闭窗口ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.关闭窗口ToolStripMenuItem.Text = "关闭窗口";
            this.关闭窗口ToolStripMenuItem.Click += new System.EventHandler(this.关闭窗口ToolStripMenuItem_Click);
            // 
            // Remote_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 296);
            this.Controls.Add(this.Mini);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "Remote_Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remote_Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Remote_Client_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Remote_Client_FormClosed);
            this.Load += new System.EventHandler(this.Remote_Client_Load);
            this.LocationChanged += new System.EventHandler(this.Remote_Client_LocationChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Remote_Client_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Remote_Client_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Remote_Client_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Remote_Client_MouseMove);
            this.Resize += new System.EventHandler(this.Remote_Client_Resize);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最小化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 制作信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 说明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始侦听ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 断开连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 本机联机情况ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel AvailableNetStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel SocketConnectedStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel SocketConnetingProcessStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem 结束侦听ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tESTToolStripMenuItem;
        private System.Windows.Forms.Button Mini;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem 隐藏ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 最小化窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 隐藏窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭窗口ToolStripMenuItem;
    }
}

