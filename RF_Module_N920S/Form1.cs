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
using System.IO;


namespace RF_Module_N920S
{
    public partial class Form1 : Form
    {
        //---傳送變數---
        string tx = "";
        byte[] file_bytes;
        string Read_All, Read_Name, Read_file_Length, Time_show;
        
        //---接收變數---
        string rx = "";
        byte[] file_rx = new byte[2048];
        int num = 100; //超出時間的等待次數
        string file_name, file_length, file_time;

        List<byte> rx_Lists = new List<byte>();

        //----路徑變數---
        string load_file_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\ABC.txt";
        string creat_file_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tb_Load_Path.Text = load_file_path;
            tb_Save_Path.Text = creat_file_path + @"\";

            ComPort.Items.AddRange(SerialPort.GetPortNames());

            if (ComPort.Items.Count > 0)
            {
                ComPort.SelectedIndex = 0;
                Connect_btu.Enabled = true;
            }
            else
            {
                Connect_btu.Enabled = false;
            }

            BaudRate.SelectedIndex = 0;

            Disconnect_btu.Enabled = false;
            Load_file.Enabled = false;
            Send_btu.Enabled = false;
            Command_btu.Enabled = false;
            Data_btu.Enabled = false;
            Configurtion_btu.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                Environment.Exit(Environment.ExitCode);
            }
        }

        private void Connect_btu_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = ComPort.Text;
                serialPort1.BaudRate = Int32.Parse(BaudRate.Text);
                try
                {
                    serialPort1.Open();
                }
                catch
                {
                    var result = MessageBox.Show("串列埠已經被占用，請重新選擇串列埠!!!","無法建立連線",MessageBoxButtons.AbortRetryIgnore);

                    if (result == DialogResult.Abort)
                    {
                        Close();
                    }
                    else if (result == DialogResult.Ignore)
                    {
                        MessageBox.Show("程式繼續執行但未與裝置建立連線，建議重新執行程式!!!", "無法建立連線");
                    }
                    else if (result == DialogResult.Retry)
                    {
                        try
                        {
                            serialPort1.Open();
                        }
                        catch
                        {
                            MessageBox.Show("無法建立連線，程式即將關閉!!", "無法建立連線");
                            Close();
                        }
                    }
                }
                
            }
            finally
            {
                if (!bgWorker_Read.IsBusy & !bgWorker_Write.IsBusy)
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

            Command_btu.Enabled = true;
            Data_btu.Enabled = false;
            Configurtion_btu.Enabled = false;
            Load_file.Enabled = true;
            Send_btu.Enabled = false;
            Connect_btu.Enabled = false;
            Disconnect_btu.Enabled = true;
        }

        private void Disconnect_btu_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                bgWorker_Read.CancelAsync();
                bgWorker_Write.CancelAsync();
                bgWorker_Writerestatus.CancelAsync();
                bgWorker_Writetomofile.CancelAsync();
                serialPort1.Close();
            }
            else
            {
                bgWorker_Read.CancelAsync();
                bgWorker_Write.CancelAsync();
                bgWorker_Writerestatus.CancelAsync();
                bgWorker_Writetomofile.CancelAsync();
            }

            Command_btu.Enabled = false;
            Data_btu.Enabled = false;
            Configurtion_btu.Enabled = false;
            Load_file.Enabled = false;
            Send_btu.Enabled = false;
            Connect_btu.Enabled = true;
            Disconnect_btu.Enabled = false;
        }
        //-------------------------------------read--------------------------------------------
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Int32 count = 0;
            string readingFromBuffer;
            string read_mode = "empty";
            string check_code = "empty";
            string[] check_code_array;
            
            int file_length_int = 0;


            while (bgWorker_Read.CancellationPending != true)
            {
                if(read_mode == "empty")
                {
                    if (serialPort1.IsOpen)
                    {
                        if (serialPort1.BytesToRead != 0)
                        {
                            Thread.Sleep(100);      
                            rx = serialPort1.ReadExisting();

                            check_code_array = rx.Split(Convert.ToChar(";"));

                            if(check_code_array.Length == 4 && check_code_array[0] == "tomofile")
                            {
                                check_code = check_code_array[0];
                                file_length = check_code_array[1];
                                file_name = check_code_array[2];
                                file_time = check_code_array[3];

                                file_length_int = (Convert.ToInt32(Convert.ToInt32(file_length) / file_rx.Length)) * file_rx.Length;

                            }
                            else if(check_code_array.Length == 1 && check_code_array[0] == "ready")
                            {
                                check_code = check_code_array[0];
                            }
                            else
                            {
                                check_code = "empty";
                            }
                            
                            
                            if (check_code == "tomofile")
                            {
                                read_mode = "start_receiving";
                                bgWorker_Writerestatus.RunWorkerAsync();
                            }
                            else if(check_code == "ready")
                            {
                                bgWorker_Writetomofile.RunWorkerAsync();
                            }
                            else if(check_code == "empty")
                            {
                                bgWorker_Read.ReportProgress(1);
                            }
                        }
                    }
                }else if(read_mode== "start_receiving")
                {
                    readingFromBuffer = "keep";
                    while (serialPort1.BytesToRead < file_rx.Length && count < num+1 && readingFromBuffer != "final")  //加上資料大小判斷file_length
                    {
                        Thread.Sleep(100);
                        count++;
                        if (count > num)
                        {
                            readingFromBuffer = "exceed_time";
                        }
                        else if(rx_Lists.Count >= file_length_int)
                        {
                            while (serialPort1.BytesToRead < Convert.ToInt32(file_length)-file_length_int)
                            {
                                
                                Thread.Sleep(100);
                                if(serialPort1.BytesToRead >= Convert.ToInt32(file_length) - file_length_int)
                                {
                                    break;
                                }
                            }
                            
                            readingFromBuffer = "final";
                        }
                    }
                    count = 0;
                    if (readingFromBuffer == "keep")
                    {
                        if (serialPort1.BytesToRead != 0)
                        {
                            //rx = serialPort1.ReadExisting();   //ReadExisting 在讀取二進位資料流轉換上用的byte數不一樣
                            serialPort1.Read(file_rx, 0, file_rx.Length);  //一個一個byte讀取
                            rx_Lists.AddRange(file_rx);
                            bgWorker_Read.ReportProgress(0);
                        }
                    }
                    else if(readingFromBuffer == "exceed_time")//更改超時的處理辦法
                    {
                        if (serialPort1.BytesToRead != 0)
                        {
                            //rx = serialPort1.ReadExisting();   //ReadExisting 在讀取二進位資料流轉換上用的byte數不一樣
                            serialPort1.Read(file_rx, 0, file_rx.Length);  //一個一個byte讀取
                            rx_Lists.AddRange(file_rx);
                            bgWorker_Read.ReportProgress(0);
                        }
                    }
                    else if(readingFromBuffer == "final")
                    {
                        if (serialPort1.BytesToRead != 0)
                        {
                            int a = serialPort1.Read(file_rx, 0, file_rx.Length);

                            rx_Lists.AddRange(file_rx);
                            rx_Lists.RemoveRange(Convert.ToInt32(file_length), rx_Lists.Count - Convert.ToInt32(file_length));

                            bgWorker_Read.ReportProgress(0);
                            read_mode = "empty";
                        }
                    }

                    Thread.Sleep(100);
                }
                else
                {
                    //TODO
                }

                Thread.Sleep(100);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                textBox1.AppendText(rx);
            }
            else if(e.ProgressPercentage == 0)
            {
                //rx_Lists.AddRange(file_rx);
                textBox1.AppendText(Convert.ToString(rx_Lists.Count));

                if (rx_Lists.Count == Convert.ToInt32(file_length))
                {
                    DateTime f_time = new DateTime();

                    f_time = DateTime.Now;

                    int F_time_Min = f_time.Minute;
                    int F_time_Sec = f_time.Second;

                    string ReTime_show = Convert.ToString((F_time_Min * 60 + F_time_Sec) - Convert.ToInt32(file_time));
                    MessageBox.Show(ReTime_show + "(s)");

                    //StreamWriter sw = new StreamWriter(tb_Save_Path.Text + "re" + file_name + ".txt");
                    //foreach (int i in rx_Lists)
                    //{
                    //    sw.Write(Convert.ToString(i) + " ");
                    //}
                    //sw.Close();

                    FileStream fs = new FileStream(tb_Save_Path.Text + "re" + file_name, FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Write(rx_Lists.ToArray(), 0, rx_Lists.Count);
                    fs.Dispose();
                }
            }
        }

        private void bgWorker_Read_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }
        //-----------------------------------------------------------------------------------

        //---------------------------write---------------------------------------------------
        private void bgWorker_write_DoWork(object sender, DoWorkEventArgs e)
        {
            while (bgWorker_Write.CancellationPending != true)
            {
                if (serialPort1.IsOpen)
                {
                    if (textBox2.Text != "")
                    {
                        //Thread.Sleep(100);
                        tx = textBox2.Text;
                        serialPort1.Write(tx);
                        bgWorker_Write.ReportProgress(0);
                    }
                }
            }
        }

        private void bgWorker_write_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox2.Clear();
        }

        private void bgWorker_Write_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        //------------------------------------------------------------------------------------------

        //--------------------------------------五個按鈕--------------------------------------------
        private void Command_btu_Click(object sender, EventArgs e)
        {
            textBox2.Text = "+++";

            Command_btu.Enabled = false;
            Data_btu.Enabled = true;
            Configurtion_btu.Enabled = true;
        }

        private void Data_btu_Click(object sender, EventArgs e)
        {
            textBox2.Text = "ATA\r\n";

            Command_btu.Enabled = true;
            Data_btu.Enabled = false;
            Configurtion_btu.Enabled = false;
        }

        private void Configurtion_btu_Click(object sender, EventArgs e)
        {
            textBox2.Text = "AT&V\r\n";
        }

        private void RE_btu_Click(object sender, EventArgs e)
        {
            if(ComPort.Items.Count == 0)
            {
                ComPort.Items.Clear();
            }
            else
            {
                ComPort.Items.Clear();
                ComPort.Items.AddRange(SerialPort.GetPortNames());
                ComPort.SelectedIndex = 0;
                Connect_btu.Enabled = true;
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                Load_file.Enabled = false;
                Send_btu.Enabled = false;

                DateTime c_time = new DateTime();

                c_time = DateTime.Now;

                int C_time_Min = c_time.Minute;
                int C_time_Sec = c_time.Second;

                Time_show = Convert.ToString(C_time_Min * 60 + C_time_Sec);

                string file_info = Read_file_Length + ";" +  Read_Name + ";" + Time_show;
                tx = "tomofile" + ";" + file_info;
                serialPort1.Write(tx);
            }
        }

        private void Clear_btu_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        

        //-------------------------------------------------------------------------------------

        private void bgWorker_Writetomofile_DoWork(object sender, DoWorkEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                //tx = Read_All;
                //serialPort1.Write(tx);
                serialPort1.Write(file_bytes, 0, file_bytes.Length);
                bgWorker_Writetomofile.ReportProgress(0);
            }
        }

        private void bgWorker_Writetomofile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Load_file.Enabled = true;
        }

        private void bgWorker_Writetomofile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgWorker_Writetomofile.Dispose();
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                tx = "ready";
                serialPort1.Write(tx);
            }
        }

        private void bgWorker_Writerestatus_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgWorker_Writerestatus.Dispose();
        }

        //------------------------------讀取文件------------------------------------
        private void Load_file_Click(object sender, EventArgs e)
        {
            Load_file.Enabled = false;
            Send_btu.Enabled = true;
            
            //-----以字串方式讀取-----
            //StreamReader str = new StreamReader(file_path);
            //Read_All = str.ReadToEnd();
            //Read_file_Length = Convert.ToString(Read_All.Length);
            //Read_Name = Path.GetFileName(file_path);
            //str.Close();

            //-----讀取二進制文件，可以控制要傳出幾個byte-----
            FileStream str = new FileStream(tb_Load_Path.Text, FileMode.Open, FileAccess.Read);
            
            BinaryReader binaryReader = new BinaryReader(str);
            file_bytes = binaryReader.ReadBytes(Convert.ToInt32(str.Length));
            binaryReader.Dispose();
            str.Dispose();

            Read_Name = Path.GetFileName(tb_Load_Path.Text);
            Read_file_Length = Convert.ToString(file_bytes.Length);
        }
    }
}
