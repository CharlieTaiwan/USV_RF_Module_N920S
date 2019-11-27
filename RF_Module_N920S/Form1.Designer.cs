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
            this.Configurtion_btu = new System.Windows.Forms.Button();
            this.Data_btu = new System.Windows.Forms.Button();
            this.Command_btu = new System.Windows.Forms.Button();
            this.Connect = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Disconnect_btu = new System.Windows.Forms.Button();
            this.ComPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BaudRate = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.bgWorker_Read = new System.ComponentModel.BackgroundWorker();
            this.bgWorker_Write = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RE_btu = new System.Windows.Forms.Button();
            this.Control.SuspendLayout();
            this.Connect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 21);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(623, 368);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 21);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(367, 62);
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
            this.Control.Controls.Add(this.Configurtion_btu);
            this.Control.Controls.Add(this.Data_btu);
            this.Control.Controls.Add(this.Command_btu);
            this.Control.Controls.Add(this.Connect);
            this.Control.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Control.Location = new System.Drawing.Point(653, 12);
            this.Control.Name = "Control";
            this.Control.Size = new System.Drawing.Size(355, 490);
            this.Control.TabIndex = 3;
            this.Control.TabStop = false;
            this.Control.Text = "Control";
            // 
            // Configurtion_btu
            // 
            this.Configurtion_btu.Location = new System.Drawing.Point(14, 201);
            this.Configurtion_btu.Name = "Configurtion_btu";
            this.Configurtion_btu.Size = new System.Drawing.Size(160, 40);
            this.Configurtion_btu.TabIndex = 7;
            this.Configurtion_btu.Text = "Configuration";
            this.Configurtion_btu.UseVisualStyleBackColor = true;
            this.Configurtion_btu.Click += new System.EventHandler(this.Configurtion_btu_Click);
            // 
            // Data_btu
            // 
            this.Data_btu.Location = new System.Drawing.Point(180, 155);
            this.Data_btu.Name = "Data_btu";
            this.Data_btu.Size = new System.Drawing.Size(160, 40);
            this.Data_btu.TabIndex = 6;
            this.Data_btu.Text = "Data Mode";
            this.Data_btu.UseVisualStyleBackColor = true;
            this.Data_btu.Click += new System.EventHandler(this.Data_btu_Click);
            // 
            // Command_btu
            // 
            this.Command_btu.Location = new System.Drawing.Point(14, 155);
            this.Command_btu.Name = "Command_btu";
            this.Command_btu.Size = new System.Drawing.Size(160, 40);
            this.Command_btu.TabIndex = 5;
            this.Command_btu.Text = "Command Mode";
            this.Command_btu.UseVisualStyleBackColor = true;
            this.Command_btu.Click += new System.EventHandler(this.Command_btu_Click);
            // 
            // Connect
            // 
            this.Connect.Controls.Add(this.RE_btu);
            this.Connect.Controls.Add(this.label6);
            this.Connect.Controls.Add(this.label5);
            this.Connect.Controls.Add(this.Disconnect_btu);
            this.Connect.Controls.Add(this.ComPort);
            this.Connect.Controls.Add(this.Connect_btu);
            this.Connect.Controls.Add(this.label1);
            this.Connect.Controls.Add(this.BaudRate);
            this.Connect.Location = new System.Drawing.Point(8, 21);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(341, 128);
            this.Connect.TabIndex = 4;
            this.Connect.TabStop = false;
            this.Connect.Text = "Connect";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Com Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 30);
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
            this.ComPort.Location = new System.Drawing.Point(113, 27);
            this.ComPort.Name = "ComPort";
            this.ComPort.Size = new System.Drawing.Size(184, 20);
            this.ComPort.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 56);
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
            this.BaudRate.Location = new System.Drawing.Point(113, 53);
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
            this.bgWorker_Read.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_Read_RunWorkerCompleted);
            // 
            // bgWorker_Write
            // 
            this.bgWorker_Write.WorkerReportsProgress = true;
            this.bgWorker_Write.WorkerSupportsCancellation = true;
            this.bgWorker_Write.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_write_DoWork);
            this.bgWorker_Write.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_write_ProgressChanged);
            this.bgWorker_Write.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_Write_RunWorkerCompleted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 89);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(635, 395);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // RE_btu
            // 
            this.RE_btu.Location = new System.Drawing.Point(303, 27);
            this.RE_btu.Name = "RE_btu";
            this.RE_btu.Size = new System.Drawing.Size(29, 20);
            this.RE_btu.TabIndex = 6;
            this.RE_btu.Text = "R";
            this.RE_btu.UseVisualStyleBackColor = true;
            this.RE_btu.Click += new System.EventHandler(this.RE_btu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1018, 509);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Control);
            this.Name = "Form1";
            this.Text = "N920S Interface";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Control.ResumeLayout(false);
            this.Connect.ResumeLayout(false);
            this.Connect.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComPort;
        private System.ComponentModel.BackgroundWorker bgWorker_Read;
        private System.ComponentModel.BackgroundWorker bgWorker_Write;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Data_btu;
        private System.Windows.Forms.Button Command_btu;
        private System.Windows.Forms.Button Configurtion_btu;
        private System.Windows.Forms.Button RE_btu;
    }
}

