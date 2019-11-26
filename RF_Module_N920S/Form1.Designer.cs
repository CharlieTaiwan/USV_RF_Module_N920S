namespace RF_Module_N920S
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Connect_btu = new System.Windows.Forms.Button();
            this.Control = new System.Windows.Forms.GroupBox();
            this.Connect = new System.Windows.Forms.GroupBox();
            this.SEND_btu = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Disconnect_btu = new System.Windows.Forms.Button();
            this.ComPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BaudRate = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.bgWorker_Read = new System.ComponentModel.BackgroundWorker();
            this.bgWorker_Write = new System.ComponentModel.BackgroundWorker();
            this.Control.SuspendLayout();
            this.Connect.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 98);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(691, 449);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 12);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(691, 80);
            this.textBox2.TabIndex = 1;
            // 
            // Connect_btu
            // 
            this.Connect_btu.Location = new System.Drawing.Point(6, 79);
            this.Connect_btu.Name = "Connect_btu";
            this.Connect_btu.Size = new System.Drawing.Size(160, 40);
            this.Connect_btu.TabIndex = 2;
            this.Connect_btu.Text = "Connect";
            this.Connect_btu.UseVisualStyleBackColor = true;
            this.Connect_btu.Click += new System.EventHandler(this.Connect_btu_Click);
            // 
            // Control
            // 
            this.Control.Controls.Add(this.Connect);
            this.Control.Location = new System.Drawing.Point(709, 12);
            this.Control.Name = "Control";
            this.Control.Size = new System.Drawing.Size(355, 535);
            this.Control.TabIndex = 3;
            this.Control.TabStop = false;
            this.Control.Text = "Control";
            // 
            // Connect
            // 
            this.Connect.Controls.Add(this.SEND_btu);
            this.Connect.Controls.Add(this.label6);
            this.Connect.Controls.Add(this.label5);
            this.Connect.Controls.Add(this.Disconnect_btu);
            this.Connect.Controls.Add(this.ComPort);
            this.Connect.Controls.Add(this.Connect_btu);
            this.Connect.Controls.Add(this.label1);
            this.Connect.Controls.Add(this.BaudRate);
            this.Connect.Location = new System.Drawing.Point(6, 21);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(341, 171);
            this.Connect.TabIndex = 4;
            this.Connect.TabStop = false;
            this.Connect.Text = "Connect";
            // 
            // SEND_btu
            // 
            this.SEND_btu.Location = new System.Drawing.Point(6, 125);
            this.SEND_btu.Name = "SEND_btu";
            this.SEND_btu.Size = new System.Drawing.Size(326, 40);
            this.SEND_btu.TabIndex = 5;
            this.SEND_btu.Text = "SEND";
            this.SEND_btu.UseVisualStyleBackColor = true;
            this.SEND_btu.Click += new System.EventHandler(this.SEND_btu_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Com Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 12);
            this.label5.TabIndex = 9;
            // 
            // Disconnect_btu
            // 
            this.Disconnect_btu.Location = new System.Drawing.Point(172, 79);
            this.Disconnect_btu.Name = "Disconnect_btu";
            this.Disconnect_btu.Size = new System.Drawing.Size(160, 40);
            this.Disconnect_btu.TabIndex = 3;
            this.Disconnect_btu.Text = "Disconnect";
            this.Disconnect_btu.UseVisualStyleBackColor = true;
            this.Disconnect_btu.Click += new System.EventHandler(this.Disconnect_btu_Click);
            // 
            // ComPort
            // 
            this.ComPort.FormattingEnabled = true;
            this.ComPort.Location = new System.Drawing.Point(148, 27);
            this.ComPort.Name = "ComPort";
            this.ComPort.Size = new System.Drawing.Size(184, 20);
            this.ComPort.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Baud Rate";
            // 
            // BaudRate
            // 
            this.BaudRate.FormattingEnabled = true;
            this.BaudRate.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "28800"});
            this.BaudRate.Location = new System.Drawing.Point(148, 53);
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(184, 20);
            this.BaudRate.TabIndex = 0;
            // 
            // bgWorker_Read
            // 
            this.bgWorker_Read.WorkerReportsProgress = true;
            this.bgWorker_Read.WorkerSupportsCancellation = true;
            this.bgWorker_Read.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.bgWorker_Read.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.bgWorker_Read.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // bgWorker_Write
            // 
            this.bgWorker_Write.WorkerReportsProgress = true;
            this.bgWorker_Write.WorkerSupportsCancellation = true;
            this.bgWorker_Write.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_write_DoWork);
            this.bgWorker_Write.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_write_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 559);
            this.Controls.Add(this.Control);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Control.ResumeLayout(false);
            this.Connect.ResumeLayout(false);
            this.Connect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Connect_btu;
        private System.Windows.Forms.GroupBox Control;
        private System.Windows.Forms.GroupBox Connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BaudRate;
        private System.Windows.Forms.Button Disconnect_btu;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button SEND_btu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComPort;
        private System.ComponentModel.BackgroundWorker bgWorker_Read;
        private System.ComponentModel.BackgroundWorker bgWorker_Write;
    }
}

