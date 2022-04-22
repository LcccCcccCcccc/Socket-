namespace SocketService
{
    partial class frmService
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
            this.txtHostIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHostPoint = new System.Windows.Forms.TextBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.cmbClientList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShowMes = new System.Windows.Forms.TextBox();
            this.txtSendMes = new System.Windows.Forms.TextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnSendToClient = new System.Windows.Forms.Button();
            this.btnChose = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnShaken = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtHostIp
            // 
            this.txtHostIp.Enabled = false;
            this.txtHostIp.Location = new System.Drawing.Point(85, 15);
            this.txtHostIp.Name = "txtHostIp";
            this.txtHostIp.Size = new System.Drawing.Size(112, 21);
            this.txtHostIp.TabIndex = 2;
            this.txtHostIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务端ip：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "服务端端口：";
            // 
            // txtHostPoint
            // 
            this.txtHostPoint.Enabled = false;
            this.txtHostPoint.Location = new System.Drawing.Point(294, 15);
            this.txtHostPoint.Name = "txtHostPoint";
            this.txtHostPoint.Size = new System.Drawing.Size(49, 21);
            this.txtHostPoint.TabIndex = 1;
            this.txtHostPoint.Text = "50000";
            this.txtHostPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(358, 13);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(61, 23);
            this.btnListen.TabIndex = 0;
            this.btnListen.Text = "开始监听";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // cmbClientList
            // 
            this.cmbClientList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClientList.FormattingEnabled = true;
            this.cmbClientList.Location = new System.Drawing.Point(515, 16);
            this.cmbClientList.Name = "cmbClientList";
            this.cmbClientList.Size = new System.Drawing.Size(150, 20);
            this.cmbClientList.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "客户端列表：";
            // 
            // txtShowMes
            // 
            this.txtShowMes.Location = new System.Drawing.Point(20, 46);
            this.txtShowMes.Multiline = true;
            this.txtShowMes.Name = "txtShowMes";
            this.txtShowMes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtShowMes.Size = new System.Drawing.Size(645, 115);
            this.txtShowMes.TabIndex = 4;
            // 
            // txtSendMes
            // 
            this.txtSendMes.Location = new System.Drawing.Point(20, 167);
            this.txtSendMes.Multiline = true;
            this.txtSendMes.Name = "txtSendMes";
            this.txtSendMes.Size = new System.Drawing.Size(645, 55);
            this.txtSendMes.TabIndex = 5;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(20, 257);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(399, 21);
            this.txtFilePath.TabIndex = 6;
            // 
            // btnSendToClient
            // 
            this.btnSendToClient.Location = new System.Drawing.Point(237, 228);
            this.btnSendToClient.Name = "btnSendToClient";
            this.btnSendToClient.Size = new System.Drawing.Size(125, 23);
            this.btnSendToClient.TabIndex = 7;
            this.btnSendToClient.Text = "向客户端发消息";
            this.btnSendToClient.UseVisualStyleBackColor = true;
            this.btnSendToClient.Click += new System.EventHandler(this.btnSendToClient_Click);
            // 
            // btnChose
            // 
            this.btnChose.Location = new System.Drawing.Point(425, 255);
            this.btnChose.Name = "btnChose";
            this.btnChose.Size = new System.Drawing.Size(96, 23);
            this.btnChose.TabIndex = 8;
            this.btnChose.Text = "选择文件路径";
            this.btnChose.UseVisualStyleBackColor = true;
            this.btnChose.Click += new System.EventHandler(this.btnChose_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(541, 255);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(124, 23);
            this.btnSendFile.TabIndex = 9;
            this.btnSendFile.Text = "向客户端发送文件";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnShaken
            // 
            this.btnShaken.Location = new System.Drawing.Point(383, 228);
            this.btnShaken.Name = "btnShaken";
            this.btnShaken.Size = new System.Drawing.Size(131, 23);
            this.btnShaken.TabIndex = 10;
            this.btnShaken.Text = "向客户端发震动";
            this.btnShaken.UseVisualStyleBackColor = true;
            this.btnShaken.Click += new System.EventHandler(this.btnShaken_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(532, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "断开当前客户端";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 287);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnShaken);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnChose);
            this.Controls.Add(this.btnSendToClient);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.txtSendMes);
            this.Controls.Add(this.txtShowMes);
            this.Controls.Add(this.cmbClientList);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.txtHostPoint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHostIp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmService_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHostIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHostPoint;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.ComboBox cmbClientList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtShowMes;
        private System.Windows.Forms.TextBox txtSendMes;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnSendToClient;
        private System.Windows.Forms.Button btnChose;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnShaken;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}