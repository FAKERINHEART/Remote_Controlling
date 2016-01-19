namespace Remote_Controller
{
    partial class Remote_Controller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Remote_Controller));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.直接IP设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.断开连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.本机联网情况ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.屏幕投射ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始投射ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束投射ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.屏幕控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件传输ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最小化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.制作信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.最小化窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.AvailableNetStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SocketConnectedStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SocketConnetingProcessStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Mini = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.完全屏幕控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始完全控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束完全控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.ContextMenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.Transparent;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配置ToolStripMenuItem,
            this.功能ToolStripMenuItem,
            this.窗口ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(909, 25);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连接ToolStripMenuItem,
            this.本机联网情况ToolStripMenuItem});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.配置ToolStripMenuItem.Text = "配置";
            // 
            // 连接ToolStripMenuItem
            // 
            this.连接ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.连接ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.直接IP设置ToolStripMenuItem,
            this.开始连接ToolStripMenuItem,
            this.断开连接ToolStripMenuItem});
            this.连接ToolStripMenuItem.Name = "连接ToolStripMenuItem";
            this.连接ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.连接ToolStripMenuItem.Text = "连接";
            // 
            // 直接IP设置ToolStripMenuItem
            // 
            this.直接IP设置ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.直接IP设置ToolStripMenuItem.Name = "直接IP设置ToolStripMenuItem";
            this.直接IP设置ToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.直接IP设置ToolStripMenuItem.Text = "直接IP设置";
            this.直接IP设置ToolStripMenuItem.Click += new System.EventHandler(this.直接IP设置ToolStripMenuItem_Click);
            // 
            // 开始连接ToolStripMenuItem
            // 
            this.开始连接ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.开始连接ToolStripMenuItem.Enabled = false;
            this.开始连接ToolStripMenuItem.Name = "开始连接ToolStripMenuItem";
            this.开始连接ToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.开始连接ToolStripMenuItem.Text = "开始连接";
            this.开始连接ToolStripMenuItem.Click += new System.EventHandler(this.开始连接ToolStripMenuItem_Click);
            // 
            // 断开连接ToolStripMenuItem
            // 
            this.断开连接ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.断开连接ToolStripMenuItem.Enabled = false;
            this.断开连接ToolStripMenuItem.Name = "断开连接ToolStripMenuItem";
            this.断开连接ToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.断开连接ToolStripMenuItem.Text = "断开连接";
            this.断开连接ToolStripMenuItem.Click += new System.EventHandler(this.断开连接ToolStripMenuItem_Click);
            // 
            // 本机联网情况ToolStripMenuItem
            // 
            this.本机联网情况ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.本机联网情况ToolStripMenuItem.Name = "本机联网情况ToolStripMenuItem";
            this.本机联网情况ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.本机联网情况ToolStripMenuItem.Text = "本机联网情况";
            this.本机联网情况ToolStripMenuItem.Click += new System.EventHandler(this.本机联网情况IPToolStripMenuItem_Click);
            // 
            // 功能ToolStripMenuItem
            // 
            this.功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.屏幕投射ToolStripMenuItem,
            this.屏幕控制ToolStripMenuItem,
            this.完全屏幕控制ToolStripMenuItem,
            this.文件传输ToolStripMenuItem});
            this.功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            this.功能ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.功能ToolStripMenuItem.Text = "功能";
            // 
            // 屏幕投射ToolStripMenuItem
            // 
            this.屏幕投射ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.屏幕投射ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始投射ToolStripMenuItem,
            this.结束投射ToolStripMenuItem});
            this.屏幕投射ToolStripMenuItem.Name = "屏幕投射ToolStripMenuItem";
            this.屏幕投射ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.屏幕投射ToolStripMenuItem.Text = "屏幕投射";
            // 
            // 开始投射ToolStripMenuItem
            // 
            this.开始投射ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.开始投射ToolStripMenuItem.Enabled = false;
            this.开始投射ToolStripMenuItem.Name = "开始投射ToolStripMenuItem";
            this.开始投射ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.开始投射ToolStripMenuItem.Text = "开始投射";
            this.开始投射ToolStripMenuItem.Click += new System.EventHandler(this.开始投射ToolStripMenuItem_Click);
            // 
            // 结束投射ToolStripMenuItem
            // 
            this.结束投射ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.结束投射ToolStripMenuItem.Enabled = false;
            this.结束投射ToolStripMenuItem.Name = "结束投射ToolStripMenuItem";
            this.结束投射ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.结束投射ToolStripMenuItem.Text = "结束投射";
            this.结束投射ToolStripMenuItem.Click += new System.EventHandler(this.结束投射ToolStripMenuItem_Click);
            // 
            // 屏幕控制ToolStripMenuItem
            // 
            this.屏幕控制ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.屏幕控制ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始控制ToolStripMenuItem,
            this.结束控制ToolStripMenuItem});
            this.屏幕控制ToolStripMenuItem.Name = "屏幕控制ToolStripMenuItem";
            this.屏幕控制ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.屏幕控制ToolStripMenuItem.Text = "屏幕控制";
            // 
            // 开始控制ToolStripMenuItem
            // 
            this.开始控制ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.开始控制ToolStripMenuItem.Enabled = false;
            this.开始控制ToolStripMenuItem.Name = "开始控制ToolStripMenuItem";
            this.开始控制ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.开始控制ToolStripMenuItem.Text = "开始控制";
            this.开始控制ToolStripMenuItem.Click += new System.EventHandler(this.开始控制ToolStripMenuItem_Click);
            // 
            // 结束控制ToolStripMenuItem
            // 
            this.结束控制ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.结束控制ToolStripMenuItem.Enabled = false;
            this.结束控制ToolStripMenuItem.Name = "结束控制ToolStripMenuItem";
            this.结束控制ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.结束控制ToolStripMenuItem.Text = "结束控制";
            this.结束控制ToolStripMenuItem.Click += new System.EventHandler(this.结束控制ToolStripMenuItem_Click);
            // 
            // 文件传输ToolStripMenuItem
            // 
            this.文件传输ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.文件传输ToolStripMenuItem.Enabled = false;
            this.文件传输ToolStripMenuItem.Name = "文件传输ToolStripMenuItem";
            this.文件传输ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.文件传输ToolStripMenuItem.Text = "文件传输";
            this.文件传输ToolStripMenuItem.Click += new System.EventHandler(this.文件传输ToolStripMenuItem_Click);
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
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // StatusStrip
            // 
            this.StatusStrip.BackColor = System.Drawing.Color.Transparent;
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.AvailableNetStatusLabel,
            this.SocketConnectedStatusLabel,
            this.SocketConnetingProcessStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 303);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StatusStrip.Size = new System.Drawing.Size(909, 22);
            this.StatusStrip.TabIndex = 0;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // AvailableNetStatusLabel
            // 
            this.AvailableNetStatusLabel.Name = "AvailableNetStatusLabel";
            this.AvailableNetStatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
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
            this.Mini.Image = global::Remote_Controller.Properties.Resources.MINI;
            this.Mini.Location = new System.Drawing.Point(814, 0);
            this.Mini.Name = "Mini";
            this.Mini.Size = new System.Drawing.Size(38, 23);
            this.Mini.TabIndex = 3;
            this.Mini.UseVisualStyleBackColor = true;
            this.Mini.Click += new System.EventHandler(this.Mini_Click);
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.Image = ((System.Drawing.Image)(resources.GetObject("Close.Image")));
            this.Close.Location = new System.Drawing.Point(850, 0);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(39, 23);
            this.Close.TabIndex = 2;
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // 完全屏幕控制ToolStripMenuItem
            // 
            this.完全屏幕控制ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.完全屏幕控制ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始完全控制ToolStripMenuItem,
            this.结束完全控制ToolStripMenuItem});
            this.完全屏幕控制ToolStripMenuItem.Name = "完全屏幕控制ToolStripMenuItem";
            this.完全屏幕控制ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.完全屏幕控制ToolStripMenuItem.Text = "完全屏幕控制";
            // 
            // 开始完全控制ToolStripMenuItem
            // 
            this.开始完全控制ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.开始完全控制ToolStripMenuItem.Enabled = false;
            this.开始完全控制ToolStripMenuItem.Name = "开始完全控制ToolStripMenuItem";
            this.开始完全控制ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.开始完全控制ToolStripMenuItem.Text = "开始完全控制";
            // 
            // 结束完全控制ToolStripMenuItem
            // 
            this.结束完全控制ToolStripMenuItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.结束完全控制ToolStripMenuItem.Enabled = false;
            this.结束完全控制ToolStripMenuItem.Name = "结束完全控制ToolStripMenuItem";
            this.结束完全控制ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.结束完全控制ToolStripMenuItem.Text = "结束完全控制";
            // 
            // Remote_Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(909, 325);
            this.Controls.Add(this.Mini);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.Name = "Remote_Controller";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Romte_Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Remote_Controller_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Remote_Controller_FormClosed);
            this.Load += new System.EventHandler(this.Remote_Controller_Load);
            this.LocationChanged += new System.EventHandler(this.Remote_Controller_LocationChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Remote_Controller_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Remote_Controller_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Remote_Controller_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Remote_Controller_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Remote_Controller_MouseMove);
            this.Resize += new System.EventHandler(this.Remote_Controller_Resize);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ContextMenuStrip.ResumeLayout(false);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最小化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 制作信息ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem 连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 直接IP设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 说明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 断开连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 本机联网情况ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel AvailableNetStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem 开始连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel SocketConnectedStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel SocketConnetingProcessStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem 屏幕投射ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始投射ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束投射ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 屏幕控制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始控制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束控制ToolStripMenuItem;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button Mini;
        private System.Windows.Forms.ToolStripMenuItem 文件传输ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 隐藏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最小化窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 隐藏窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭窗口ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 完全屏幕控制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始完全控制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束完全控制ToolStripMenuItem;


    }
}

