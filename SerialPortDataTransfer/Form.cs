using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using SERIAL_RX_TX;

namespace COMPDT
{
    
    public partial class Form : System.Windows.Forms.Form
    {
 
        //private void SerialPortConnect(String port, int baudrate, Parity parity, int databits, StopBits stopbits)
        //{
        //    DateTime dt = DateTime.Now;
        //    String dtn = dt.ToShortTimeString();

        //    serialport = new System.IO.Ports.SerialPort(port, baudrate, parity, databits, stopbits);
        //    try
        //    {
        //        serialport.Open();
        //        Disconnection.Enabled = true;
        //        Send.Enabled = true;
        //        Connection.Enabled = false;
        //        Messeges.AppendText(" [" + dtn + "] " + "Подключен\n");
        //        serialport.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataReceived);
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.ToString(), "Ошибка"); }
        //}
        //private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    DateTime dt = DateTime.Now;
        //    String dtn = dt.ToShortTimeString();

        //    Messeges.AppendText(" [" + dtn + "] " + "Получено: " + serialport.ReadExisting() + "\n");
        //}
        //private System.IO.Ports.SerialPort serialport;
        private SerialComPort serialcomport;
        private Timer receivedDataTimer;
        private Timer replayFileTimer;
        private string receivedData;
        private bool dataReady = false;
        private StreamReader file;
        private void Form_Load(object sender, EventArgs e)
        {

        }   
        public Form()
        {
            InitializeComponent();
            //Disconnection.Enabled = false;
            SendFile.Enabled = false;
            file = null;
            serialcomport = new SerialComPort();
            serialcomport.RegisterReceiveCallback(ReceiveDataHandler);
            receivedDataTimer = new Timer();
            receivedDataTimer.Interval = 25;   // 25 ms
            receivedDataTimer.Tick += new EventHandler(ReceivedDataTimerTick);
            receivedDataTimer.Start();
            replayFileTimer = new Timer();
            replayFileTimer.Interval = 1000;   // 1000 ms
            replayFileTimer.Tick += new EventHandler(ReplayFileTimerTick);
            replayFileTimer.Start();
        }
        private void ReceiveDataHandler(string data)
        {
            if (dataReady)
            {
                Debug.Print("Полученные данные были отброшены, потому что буфер строки не очищен");
            }
            else
            {

                dataReady = true;
                receivedData = data;
            }
        }
        private void ReceivedDataTimerTick(object sender, EventArgs e)
        {
            string path = textBoxPath.Text + "2.txt";

            if (dataReady)
                {
                string indata = string.Empty;

                Messages.Clear();
                //StringBuilder sb = new System.Text.StringBuilder();
                //string[] binaryArr1 = new string[sb.Length];
                //string[] binaryArr2 = new string[sb.Length];
                //string[] residueArr = new string[binaryArr1.Length];
                //string[] residueArr2 = new string[binaryArr1.Length];

                //string binaryStr=null;
                //foreach (byte b in System.Text.Encoding.UTF8.GetBytes(indata))
                //    for (int k = 0; k < sb.Length; k++)
                //    {
                //        sb.Append(Convert.ToString(b, 2).PadLeft(11, '0').PadRight(15, '0'))/*.Append(' ')*/;
                //        binaryArr1[k] = sb.ToString();
                //        sb.Append(Convert.ToString(b, 2).PadLeft(11, '0'))/*.Append(' ')*/;
                //        binaryArr2[k] = sb.ToString();
                //        //string binaryStr = sb.ToString();
                //    }
                //for (int i = 0; i < binaryArr1.Length; i++)
                //{
                //    int binaryInt = Convert.ToInt32(binaryArr1[i], 2);
                //    int residue = binaryInt % 19/*10011*/;
                //    residueArr[i] = Convert.ToString(residue, 2);
                //    binaryArr1[i] = binaryArr2[i] + residueArr[i] + ' ';
                //    binaryStr += binaryArr1[i];
                //}
                //char[] separators = new char[] { ' ' };
                //var wordsArray = binaryStr.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                //string wordsStr = null;
                //string wordsStr2 = null;
                //string[] arrayCode = new string[binaryArr1.Length];
                //for (int o = 0; o < wordsArray.Length; o++)
                //{
                //    int wordsInt = Convert.ToInt32(wordsArray[o], 2);
                //    int residue = wordsInt % 19/*10011*/;
                //    wordsStr = wordsArray[o];
                //    StringBuilder sb2 = new StringBuilder(wordsStr);
                //    if (residue != 0) { if (sb2[residue - 2] == 1) { sb2[residue - 2] = '0'; } else { sb2[residue - 2] = '1'; } }
                //    wordsStr2 = sb2.ToString();
                //    arrayCode[o] = wordsStr2;
                //}
                //var bytes = arrayCode.Select(s => Convert.ToByte(s, 16));
                //var word = Encoding.UTF8.GetString(bytes.ToArray()); ;
                dataReady = false;
                //UpdateDataWindow(receivedData);
                Messages.Clear();
                UpdateDataWindow("Данные приняты...");
                StellsBox.Clear();
                UpdateWindow(receivedData);
                using (FileStream file = new FileStream(path, FileMode.Append))
                using (StreamWriter sw = new StreamWriter(file))
                    sw.WriteLine(StellsBox.Text);
            }
        }
        private void ReplayFileTimerTick(object sender, EventArgs e)
        {
            if (file != null)
            {
                try
                {
                    string message = file.ReadLine();
                    if (!file.EndOfStream)
                    {
                        serialcomport.SendLine(message + "\n");
                    }
                    else
                    {
                        file.BaseStream.Seek(0, 0);  // start over reading the file
                    }
                }
                catch (Exception error)
                {
                    Debug.Print(error.Message);
                }
            }
        }
        private void UpdateDataWindow(string message)
        {
            Messages.Text += message;
            Messages.SelectionStart = Messages.TextLength;
            Messages.ScrollToCaret(); 
        }
        private void UpdateWindow(string message)
        {
            StellsBox.Text += message;
            StellsBox.SelectionStart = StellsBox.TextLength;
            StellsBox.ScrollToCaret(); 
        }
        //private void UpdateReportWindow(string message)
        //{
        //    TransferReport.Text += message;
        //    TransferReport.SelectionStart = TransferReport.TextLength;
        //    TransferReport.ScrollToCaret();
        //}
        //private void SendMessageButton(object sender, EventArgs e)
        //{
        //    DateTime dt = DateTime.Now;
        //    String dtn = dt.ToShortTimeString();

        //    if (serialcomport.IsOpen())
        //    {

        //        string message = " [" + dtn + "] " + comboBoxPort.Text + ":" + MessageToSend.Text + "\r\n";
        //        serialcomport.SendLine(message);
        //        UpdateDataWindow(message);
        //    }
        //    else
        //    {
        //        UpdateDataWindow(" [" + dtn + "] " + "Откройте свой порт\r\n");
        //    }
        //}
        private void SendFileButton(object sender, EventArgs e)
        {
            Messages.Clear();
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();
            
            if (!serialcomport.IsOpen())
            {
                UpdateDataWindow(" [" + dtn + "] " + "Откройте свой порт\r\n");
                return;
            }
            if (SendFile.Text == "Передать")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    file = new System.IO.StreamReader(openFileDialog.FileName);
                    SendFile.Text = "Остановить передачу";
                    UpdateDataWindow("Передача через COM порт: " + openFileDialog.FileName + "\r\n");
                }
            }
            else
            {
                if (file != null)
                {
                    
                    file.Close();
                    file = null;
                    SendFile.Text = "Передать";
                    this.timer1.Dispose();
                }
            }
        }
        private void ConnectionButton(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            if (comboBoxPort.Text == "" || comboBoxBaudRate.Text == "")
            { Messages.Text = " [" + dtn + "] " + "Пожалуйста заполните настройки порта\n"; }
            else
            {
                    // Handles the Open/Close button, which toggles its label, depending on previous state.
                    string status;
                    if (Connection.Text == "Подключиться")
                    {
                        status = serialcomport.Open(comboBoxPort.Text, comboBoxBaudRate.Text, "8", "None", "One");
                        if (status.Contains("Открыт"))
                        {
                            Connection.Text = "Отключиться";
                            SendFile.Enabled = true;
                    }
                    }
                    else
                    {
                        status = serialcomport.Close();
                        Connection.Text = "Подключиться";
                    }
                    UpdateDataWindow(status);
            }
        }
        private void BrowseButton(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Выберите путь, где хотите сохранить свои файлы:" })
                if (fbd.ShowDialog() == DialogResult.OK) 
                {
                    FileInfo.Text = "Файлы будут сохранены по пути " + fbd.SelectedPath + "\n";
                    textBoxPath.Text = fbd.SelectedPath + "\\";
                    
                }
        }
        private void AddInfoToFileButton(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            string path = textBoxPath.Text + textBoxName.Text + ".txt";

            using(FileStream file = new FileStream(path, FileMode.Append)) 
                using (StreamWriter sw = new StreamWriter(file))
                    sw.WriteLine(textBoxMessege.Text);

            using (StreamReader sr = new StreamReader(path, true))
            {
                FileInfo.Clear();
                FileInfo.AppendText(" [" + dtn + "] " + textBoxName.Text + ".txt изменен \n");
                FileInfo.AppendText(" Содержание:\n" + sr.ReadToEnd());
            }
        }


        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
