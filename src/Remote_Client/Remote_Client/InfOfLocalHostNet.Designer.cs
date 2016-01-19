namespace Remote_Client
{
    partial class InfOfLocalHostNet
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
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.InfOfLocalHostNetPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.InfOfLocalHostNetLabel = new System.Windows.Forms.Label();
            this.InfOfLocalHostNetPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfOfLocalHostNetPanel
            // 
            this.InfOfLocalHostNetPanel.AutoScroll = true;
            this.InfOfLocalHostNetPanel.BackColor = System.Drawing.Color.Transparent;
            this.InfOfLocalHostNetPanel.Controls.Add(this.InfOfLocalHostNetLabel);
            this.InfOfLocalHostNetPanel.Location = new System.Drawing.Point(12, 42);
            this.InfOfLocalHostNetPanel.Name = "InfOfLocalHostNetPanel";
            this.InfOfLocalHostNetPanel.Size = new System.Drawing.Size(260, 168);
            this.InfOfLocalHostNetPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Remote_Client.Properties.Resources.CLOSE;
            this.button1.Location = new System.Drawing.Point(249, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 23);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InfOfLocalHostNetLabel
            // 
            this.InfOfLocalHostNetLabel.BackColor = System.Drawing.Color.Transparent;
            this.InfOfLocalHostNetLabel.Location = new System.Drawing.Point(0, 0);
            this.InfOfLocalHostNetLabel.Name = "InfOfLocalHostNetLabel";
            this.InfOfLocalHostNetLabel.Size = new System.Drawing.Size(262, 182);
            this.InfOfLocalHostNetLabel.TabIndex = 3;
            // 
            // InfOfLocalHostNet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 231);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InfOfLocalHostNetPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "InfOfLocalHostNet";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InfOfLocalHostNet";
            this.Load += new System.EventHandler(this.InfOfLocalHostNet_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.InfOfLocalHostNet_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InfOfLocalHostNet_MouseDown);
            this.Resize += new System.EventHandler(this.InfOfLocalHostNet_Resize);
            this.InfOfLocalHostNetPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Panel InfOfLocalHostNetPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label InfOfLocalHostNetLabel;




    }
}