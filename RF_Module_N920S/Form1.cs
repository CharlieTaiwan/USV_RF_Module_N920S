using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;


namespace RF_Module_N920S
{
    public partial class Form1 : Form
    {
        string tx = "";
        string rx = "";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComPort.Items.AddRange(SerialPort.GetPortNames());
            ComPort.SelectedIndex = 0;
            BaudRate.SelectedIndex = 0;
            Connect_btu.Enabled = true;
            Disconnect_btu.Enabled = true;
        }

        private void Connect_btu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = ComPort.Text;
                    serialPort1.BaudRate = Int32.Parse(BaudRate.Text);
                    serialPort1.Open();
                }
            }
            finally
            {
                if (!bgWorker_Read.IsBusy)
                {
                    bgWorker_Read.RunWorkerAsync();
                    bgWorker_Write.RunWorkerAsync();
                }
                else
                {
                    bgWorker_Read.CancelAsync();
                    bgWorker_Read.RunWorkerAsync();

                    bgWorker_Write.CancelAsync();
                    bgWorker_Write.RunWorkerAsync();
                }
            }
            Connect_btu.Enabled = false;
            Disconnect_btu.Enabled = true;
        }

        private void Disconnect_btu_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                bgWorker_Read.CancelAsync();
                bgWorker_Write.CancelAsync();
                serialPort1.Close();
            }
            Connect_btu.Enabled = true;
            Disconnect_btu.Enabled = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (bgWorker_Read.CancellationPending != true)
            {
                //Thread.Sleep(100);
                if (serialPort1.BytesToRead != 0)
                {

                    rx = serialPort1.ReadExisting();
                    bgWorker_Read.ReportProgress(0);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //textBox1.AppendText(rx + Environment.NewLine);
            textBox1.AppendText(rx);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void SEND_btu_Click(object sender, EventArgs e)
        {

        }

        private void bgWorker_write_DoWork(object sender, DoWorkEventArgs e)
        {
            while (bgWorker_Write.CancellationPending != true)
            {
                //Thread.Sleep(100);
                tx = textBox2.Text;
                serialPort1.Write(tx);
                bgWorker_Write.ReportProgress(0);
            }
        }

        private void bgWorker_write_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //textBox2.Clear();
        }
    }
}
