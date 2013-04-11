namespace RemoteControlPC
{
    partial class Form1
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
            this.bstart = new System.Windows.Forms.Button();
            this.bstop = new System.Windows.Forms.Button();
            this.IPBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PCPort = new System.Windows.Forms.TextBox();
            this.SCPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bstart
            // 
            this.bstart.Location = new System.Drawing.Point(24, 187);
            this.bstart.Name = "bstart";
            this.bstart.Size = new System.Drawing.Size(75, 23);
            this.bstart.TabIndex = 0;
            this.bstart.Text = "Connect";
            this.bstart.UseVisualStyleBackColor = true;
            this.bstart.Click += new System.EventHandler(this.button1_Click);
            // 
            // bstop
            // 
            this.bstop.Location = new System.Drawing.Point(154, 187);
            this.bstop.Name = "bstop";
            this.bstop.Size = new System.Drawing.Size(75, 23);
            this.bstop.TabIndex = 1;
            this.bstop.Text = "Stop";
            this.bstop.UseVisualStyleBackColor = true;
            this.bstop.Click += new System.EventHandler(this.bstop_Click);
            // 
            // IPBox
            // 
            this.IPBox.FormattingEnabled = true;
            this.IPBox.Location = new System.Drawing.Point(71, 31);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(158, 20);
            this.IPBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP:";
            // 
            // PCPort
            // 
            this.PCPort.Location = new System.Drawing.Point(71, 80);
            this.PCPort.Name = "PCPort";
            this.PCPort.Size = new System.Drawing.Size(158, 21);
            this.PCPort.TabIndex = 4;
            // 
            // SCPort
            // 
            this.SCPort.Location = new System.Drawing.Point(71, 128);
            this.SCPort.Name = "SCPort";
            this.SCPort.Size = new System.Drawing.Size(158, 21);
            this.SCPort.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "PCPort";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "SCPort";
            // 
            // lstatus
            // 
            this.lstatus.AutoSize = true;
            this.lstatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lstatus.Location = new System.Drawing.Point(22, 228);
            this.lstatus.Name = "lstatus";
            this.lstatus.Size = new System.Drawing.Size(0, 12);
            this.lstatus.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lstatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SCPort);
            this.Controls.Add(this.PCPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IPBox);
            this.Controls.Add(this.bstop);
            this.Controls.Add(this.bstart);
            this.Name = "Form1";
            this.Text = "RemoteControlServent";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bstart;
        private System.Windows.Forms.Button bstop;
        private System.Windows.Forms.ComboBox IPBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PCPort;
        private System.Windows.Forms.TextBox SCPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lstatus;
    }
}

