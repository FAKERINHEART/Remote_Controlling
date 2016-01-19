namespace Remote_Client
{
    partial class FileReceiving
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.SocketConnetingProcessStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.TextLabel = new System.Windows.Forms.Label();
            this.Percent0 = new System.Windows.Forms.Label();
            this.Percent100 = new System.Windows.Forms.Label();
            this.文件名 = new System.Windows.Forms.Label();
            this.另存为 = new System.Windows.Forms.Button();
            this.取消 = new System.Windows.Forms.Button();
            this.文件大小 = new System.Windows.Forms.Label();
            this.Percent = new System.Windows.Forms.Label();
            this.Speed = new System.Windows.Forms.Label();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.BackColor = System.Drawing.Color.Transparent;
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SocketConnetingProcessStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 195);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(414, 22);
            this.StatusStrip.TabIndex = 1;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // SocketConnetingProcessStatusLabel
            // 
            this.SocketConnetingProcessStatusLabel.Name = "SocketConnetingProcessStatusLabel";
            this.SocketConnetingProcessStatusLabel.Size = new System.Drawing.Size(95, 17);
            this.SocketConnetingProcessStatusLabel.Text = "Socket连接过程";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(12, 144);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(385, 23);
            this.ProgressBar.TabIndex = 2;
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.BackColor = System.Drawing.Color.Transparent;
            this.TextLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextLabel.Location = new System.Drawing.Point(9, 24);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(119, 14);
            this.TextLabel.TabIndex = 3;
            this.TextLabel.Text = "对方想向您传送：";
            // 
            // Percent0
            // 
            this.Percent0.AutoSize = true;
            this.Percent0.BackColor = System.Drawing.Color.Transparent;
            this.Percent0.Location = new System.Drawing.Point(12, 173);
            this.Percent0.Name = "Percent0";
            this.Percent0.Size = new System.Drawing.Size(17, 12);
            this.Percent0.TabIndex = 4;
            this.Percent0.Text = "0%";
            // 
            // Percent100
            // 
            this.Percent100.AutoSize = true;
            this.Percent100.BackColor = System.Drawing.Color.Transparent;
            this.Percent100.Location = new System.Drawing.Point(368, 173);
            this.Percent100.Name = "Percent100";
            this.Percent100.Size = new System.Drawing.Size(29, 12);
            this.Percent100.TabIndex = 5;
            this.Percent100.Text = "100%";
            // 
            // 文件名
            // 
            this.文件名.AutoSize = true;
            this.文件名.BackColor = System.Drawing.Color.Transparent;
            this.文件名.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.文件名.Location = new System.Drawing.Point(10, 54);
            this.文件名.Name = "文件名";
            this.文件名.Size = new System.Drawing.Size(56, 14);
            this.文件名.TabIndex = 6;
            this.文件名.Text = "文件名:";
            // 
            // 另存为
            // 
            this.另存为.Location = new System.Drawing.Point(241, 20);
            this.另存为.Name = "另存为";
            this.另存为.Size = new System.Drawing.Size(75, 23);
            this.另存为.TabIndex = 7;
            this.另存为.Text = "另存为";
            this.另存为.UseVisualStyleBackColor = true;
            this.另存为.Click += new System.EventHandler(this.另存为_Click);
            // 
            // 取消
            // 
            this.取消.Location = new System.Drawing.Point(322, 20);
            this.取消.Name = "取消";
            this.取消.Size = new System.Drawing.Size(75, 23);
            this.取消.TabIndex = 8;
            this.取消.Text = "取消";
            this.取消.UseVisualStyleBackColor = true;
            this.取消.Click += new System.EventHandler(this.取消_Click);
            // 
            // 文件大小
            // 
            this.文件大小.AutoSize = true;
            this.文件大小.BackColor = System.Drawing.Color.Transparent;
            this.文件大小.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.文件大小.Location = new System.Drawing.Point(10, 84);
            this.文件大小.Name = "文件大小";
            this.文件大小.Size = new System.Drawing.Size(70, 14);
            this.文件大小.TabIndex = 9;
            this.文件大小.Text = "文件大小:";
            // 
            // Percent
            // 
            this.Percent.AutoSize = true;
            this.Percent.BackColor = System.Drawing.Color.Transparent;
            this.Percent.Location = new System.Drawing.Point(193, 174);
            this.Percent.Name = "Percent";
            this.Percent.Size = new System.Drawing.Size(17, 12);
            this.Percent.TabIndex = 10;
            this.Percent.Text = "0%";
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.BackColor = System.Drawing.Color.Transparent;
            this.Speed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Speed.Location = new System.Drawing.Point(9, 116);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(70, 14);
            this.Speed.TabIndex = 11;
            this.Speed.Text = "传输速度:";
            // 
            // FileReceiving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 217);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.Percent);
            this.Controls.Add(this.文件大小);
            this.Controls.Add(this.取消);
            this.Controls.Add(this.另存为);
            this.Controls.Add(this.文件名);
            this.Controls.Add(this.Percent100);
            this.Controls.Add(this.Percent0);
            this.Controls.Add(this.TextLabel);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.StatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FileReceiving";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "文件接收";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FileReceiving_FormClosed);
            this.Load += new System.EventHandler(this.FileReceiving_Load);
            this.Shown += new System.EventHandler(this.FileReceiving_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FileReceiving_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FileReceiving_MouseDown);
            this.Resize += new System.EventHandler(this.FileReceiving_Resize);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel SocketConnetingProcessStatusLabel;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label TextLabel;
        private System.Windows.Forms.Label Percent0;
        private System.Windows.Forms.Label Percent100;
        private System.Windows.Forms.Label 文件名;
        private System.Windows.Forms.Button 另存为;
        private System.Windows.Forms.Button 取消;
        private System.Windows.Forms.Label 文件大小;
        private System.Windows.Forms.Label Percent;
        private System.Windows.Forms.Label Speed;
    }
}