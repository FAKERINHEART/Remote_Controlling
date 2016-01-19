namespace Remote_Controller
{
    partial class DirectInputingIP
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
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TextIP = new System.Windows.Forms.TextBox();
            this.IP地址 = new System.Windows.Forms.Label();
            this.确定 = new System.Windows.Forms.Button();
            this.取消 = new System.Windows.Forms.Button();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.BackColor = System.Drawing.Color.Transparent;
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 85);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(284, 22);
            this.StatusStrip.TabIndex = 0;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(91, 17);
            this.StatusLabel.Text = "直接IP连接状态";
            // 
            // TextIP
            // 
            this.TextIP.Location = new System.Drawing.Point(59, 29);
            this.TextIP.Name = "TextIP";
            this.TextIP.Size = new System.Drawing.Size(125, 21);
            this.TextIP.TabIndex = 1;
            this.TextIP.Text = "127.0.0.1";
            // 
            // IP地址
            // 
            this.IP地址.AutoSize = true;
            this.IP地址.BackColor = System.Drawing.Color.Transparent;
            this.IP地址.Location = new System.Drawing.Point(12, 32);
            this.IP地址.Name = "IP地址";
            this.IP地址.Size = new System.Drawing.Size(41, 12);
            this.IP地址.TabIndex = 2;
            this.IP地址.Text = "IP地址";
            // 
            // 确定
            // 
            this.确定.Location = new System.Drawing.Point(197, 12);
            this.确定.Name = "确定";
            this.确定.Size = new System.Drawing.Size(75, 23);
            this.确定.TabIndex = 3;
            this.确定.Text = "确定";
            this.确定.UseVisualStyleBackColor = true;
            this.确定.Click += new System.EventHandler(this.确定_Click);
            // 
            // 取消
            // 
            this.取消.Location = new System.Drawing.Point(197, 50);
            this.取消.Name = "取消";
            this.取消.Size = new System.Drawing.Size(75, 23);
            this.取消.TabIndex = 4;
            this.取消.Text = "取消";
            this.取消.UseVisualStyleBackColor = true;
            this.取消.Click += new System.EventHandler(this.取消_Click);
            // 
            // DirectInputingIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 107);
            this.Controls.Add(this.取消);
            this.Controls.Add(this.确定);
            this.Controls.Add(this.IP地址);
            this.Controls.Add(this.TextIP);
            this.Controls.Add(this.StatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "DirectInputingIP";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DirectInputingIP";
            this.Load += new System.EventHandler(this.DirectInputingIP_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DirectInputingIP_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DirectInputingIP_MouseDown);
            this.Resize += new System.EventHandler(this.DirectInputingIP_Resize);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.TextBox TextIP;
        private System.Windows.Forms.Label IP地址;
        private System.Windows.Forms.Button 确定;
        private System.Windows.Forms.Button 取消;
    }
}