
namespace MQTTClient
{
    partial class frmMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtReceiveMessage = new System.Windows.Forms.RichTextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tbReceiveTopic = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labProcessName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rtbUpdateFiles = new System.Windows.Forms.RichTextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.CpuVale = new System.Windows.Forms.Label();
            this.labUpdateTime = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsStop = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowWin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsStop = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.cmsStop.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtReceiveMessage);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(385, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(611, 221);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接受数据";
            // 
            // txtReceiveMessage
            // 
            this.txtReceiveMessage.Location = new System.Drawing.Point(17, 32);
            this.txtReceiveMessage.Name = "txtReceiveMessage";
            this.txtReceiveMessage.ReadOnly = true;
            this.txtReceiveMessage.Size = new System.Drawing.Size(565, 178);
            this.txtReceiveMessage.TabIndex = 0;
            this.txtReceiveMessage.Text = "";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(402, 116);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "重新连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(907, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "订阅";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(907, 102);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "退订";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tbReceiveTopic
            // 
            this.tbReceiveTopic.Location = new System.Drawing.Point(488, 116);
            this.tbReceiveTopic.Name = "tbReceiveTopic";
            this.tbReceiveTopic.ReadOnly = true;
            this.tbReceiveTopic.Size = new System.Drawing.Size(413, 21);
            this.tbReceiveTopic.TabIndex = 8;
            this.tbReceiveTopic.Text = "/rpc/ems202300001/ems/strategy/request";
            this.tbReceiveTopic.TextChanged += new System.EventHandler(this.tbReceiveTopic_TextChanged);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(385, 423);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(94, 28);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(151, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ver:20240430";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(86)))), ((int)(((byte)(93)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 73);
            this.panel1.TabIndex = 24;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(210, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(153, 29);
            this.textBox1.TabIndex = 24;
            this.textBox1.Text = "mqtt240502_G.2.3";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnMin);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(819, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 71);
            this.panel2.TabIndex = 23;
            // 
            // btnMin
            // 
            this.btnMin.Location = new System.Drawing.Point(160, 11);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(84, 54);
            this.btnMin.TabIndex = 23;
            this.btnMin.Text = "最小化";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(250, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 54);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(205, 72);
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labProcessName);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 737);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1182, 42);
            this.panel3.TabIndex = 25;
            // 
            // labProcessName
            // 
            this.labProcessName.AutoSize = true;
            this.labProcessName.ForeColor = System.Drawing.Color.White;
            this.labProcessName.Location = new System.Drawing.Point(43, 21);
            this.labProcessName.Name = "labProcessName";
            this.labProcessName.Size = new System.Drawing.Size(71, 12);
            this.labProcessName.TabIndex = 14;
            this.labProcessName.Text = "MQTT Client";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(385, 457);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 224);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发送数据";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(17, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(565, 178);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rtbUpdateFiles);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(23, 116);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(340, 565);
            this.panel4.TabIndex = 27;
            // 
            // rtbUpdateFiles
            // 
            this.rtbUpdateFiles.Location = new System.Drawing.Point(22, 99);
            this.rtbUpdateFiles.Name = "rtbUpdateFiles";
            this.rtbUpdateFiles.Size = new System.Drawing.Size(300, 447);
            this.rtbUpdateFiles.TabIndex = 1;
            this.rtbUpdateFiles.Text = "";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.CpuVale);
            this.panel5.Controls.Add(this.labUpdateTime);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(340, 78);
            this.panel5.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(58, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "cpu:";
            // 
            // CpuVale
            // 
            this.CpuVale.AutoSize = true;
            this.CpuVale.ForeColor = System.Drawing.Color.White;
            this.CpuVale.Location = new System.Drawing.Point(87, 50);
            this.CpuVale.Name = "CpuVale";
            this.CpuVale.Size = new System.Drawing.Size(23, 12);
            this.CpuVale.TabIndex = 16;
            this.CpuVale.Text = "cpu";
            // 
            // labUpdateTime
            // 
            this.labUpdateTime.AutoSize = true;
            this.labUpdateTime.ForeColor = System.Drawing.Color.White;
            this.labUpdateTime.Location = new System.Drawing.Point(58, 38);
            this.labUpdateTime.Name = "labUpdateTime";
            this.labUpdateTime.Size = new System.Drawing.Size(71, 12);
            this.labUpdateTime.TabIndex = 15;
            this.labUpdateTime.Text = "MQTT Client";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "云数据传输系统";
            this.notifyIcon1.BalloonTipTitle = "云数据传输系统";
            this.notifyIcon1.ContextMenuStrip = this.cmsStop;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "云数据传输系统";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // cmsStop
            // 
            this.cmsStop.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmsStop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowWin,
            this.toolStripMenuItem1,
            this.tsStop});
            this.cmsStop.Name = "cmsStop";
            this.cmsStop.Size = new System.Drawing.Size(125, 54);
            this.cmsStop.Text = "退出系统";
            this.cmsStop.Opening += new System.ComponentModel.CancelEventHandler(this.cmsStop_Opening);
            // 
            // tsmShowWin
            // 
            this.tsmShowWin.Name = "tsmShowWin";
            this.tsmShowWin.Size = new System.Drawing.Size(124, 22);
            this.tsmShowWin.Text = "显示窗体";
            this.tsmShowWin.Click += new System.EventHandler(this.tsmShowWin_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
            // 
            // tsStop
            // 
            this.tsStop.Name = "tsStop";
            this.tsStop.Size = new System.Drawing.Size(124, 22);
            this.tsStop.Text = "退出系统";
            this.tsStop.Click += new System.EventHandler(this.tsStop_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1053, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "test0";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1182, 779);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.tbReceiveTopic);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "云数据客户端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.cmsStop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tbReceiveTopic;
        private System.Windows.Forms.RichTextBox txtReceiveMessage;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labProcessName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labUpdateTime;
        private System.Windows.Forms.RichTextBox rtbUpdateFiles;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip cmsStop;
        private System.Windows.Forms.ToolStripMenuItem tsmShowWin;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsStop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label CpuVale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

