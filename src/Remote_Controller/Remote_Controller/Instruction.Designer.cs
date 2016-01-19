namespace Remote_Controller
{
    partial class Instruction
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
            this.PortInstruction = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PortInstruction
            // 
            this.PortInstruction.BackColor = System.Drawing.Color.Transparent;
            this.PortInstruction.Font = new System.Drawing.Font("宋体", 10F);
            this.PortInstruction.Location = new System.Drawing.Point(12, 40);
            this.PortInstruction.Name = "PortInstruction";
            this.PortInstruction.Size = new System.Drawing.Size(230, 47);
            this.PortInstruction.TabIndex = 0;
            this.PortInstruction.Text = "控制端程序默认端口为随机端口。\r\n\r\n客户端程序默认端口为:1000。";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Remote_Controller.Properties.Resources.CLOSE;
            this.button1.Location = new System.Drawing.Point(193, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Instruction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 104);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PortInstruction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Instruction";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Instruction";
            this.Load += new System.EventHandler(this.Instruction_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Instruction_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Instruction_MouseDown);
            this.Resize += new System.EventHandler(this.Instruction_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label PortInstruction;
        private System.Windows.Forms.Button button1;
    }
}