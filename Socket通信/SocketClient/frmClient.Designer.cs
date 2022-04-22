namespace SocketClient
{
    partial class frmClient
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientIp = new System.Windows.Forms.TextBox();
            this.txtClientPoint = new System.Windows.Forms.TextBox();
            this.btnContent = new System.Windows.Forms.Button();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.txtSendMes = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnChose = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务端IP：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "客户端端口：";
            // 
            // txtClientIp
            // 
            this.txtClientIp.Location = new System.Drawing.Point(79, 15);
            this.txtClientIp.Name = "txtClientIp";
            this.txtClientIp.Size = new System.Drawing.Size(131, 21);
            this.txtClientIp.TabIndex = 2;
            this.txtClientIp.Text = "192.168.30.21";
            this.txtClientIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClientPoint
            // 
            this.txtClientPoint.Enabled = false;
            this.txtClientPoint.Location = new System.Drawing.Point(296, 15);
            this.txtClientPoint.Name = "txtClientPoint";
            this.txtClientPoint.Size = new System.Drawing.Size(70, 21);
            this.txtClientPoint.TabIndex = 1;
            this.txtClientPoint.Text = "50000";
            this.txtClientPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnContent
            // 
            this.btnContent.Location = new System.Drawing.Point(380, 14);
            this.btnContent.Name = "btnContent";
            this.btnContent.Size = new System.Drawing.Size(158, 23);
            this.btnContent.TabIndex = 0;
            this.btnContent.Text = "连接";
            this.btnContent.UseVisualStyleBackColor = true;
            this.btnContent.Click += new System.EventHandler(this.btnContent_Click);
            // 
            // txtMes
            // 
            this.txtMes.Location = new System.Drawing.Point(15, 43);
            this.txtMes.Multiline = true;
            this.txtMes.Name = "txtMes";
            this.txtMes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMes.Size = new System.Drawing.Size(524, 128);
            this.txtMes.TabIndex = 3;
            // 
            // txtSendMes
            // 
            this.txtSendMes.Location = new System.Drawing.Point(15, 177);
            this.txtSendMes.Multiline = true;
            this.txtSendMes.Name = "txtSendMes";
            this.txtSendMes.Size = new System.Drawing.Size(524, 81);
            this.txtSendMes.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(391, 264);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(148, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "向服务端发消息";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(15, 292);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(312, 21);
            this.txtFilePath.TabIndex = 6;
            // 
            // btnChose
            // 
            this.btnChose.Location = new System.Drawing.Point(333, 291);
            this.btnChose.Name = "btnChose";
            this.btnChose.Size = new System.Drawing.Size(89, 23);
            this.btnChose.TabIndex = 7;
            this.btnChose.Text = "选择文件路径";
            this.btnChose.UseVisualStyleBackColor = true;
            this.btnChose.Click += new System.EventHandler(this.btnChose_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(428, 291);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(111, 23);
            this.btnSendFile.TabIndex = 8;
            this.btnSendFile.Text = "向服务端发送文件";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "未连接";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "本机状态:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "服务端状态:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "未连接";
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 324);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnChose);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSendMes);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.btnContent);
            this.Controls.Add(this.txtClientPoint);
            this.Controls.Add(this.txtClientIp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClient";
            this.Text = "客户端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClient_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClientIp;
        private System.Windows.Forms.TextBox txtClientPoint;
        private System.Windows.Forms.Button btnContent;
        private System.Windows.Forms.TextBox txtMes;
        private System.Windows.Forms.TextBox txtSendMes;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnChose;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}