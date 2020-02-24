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
        private void Form_Load(object sender, EventArgs e)
        {

        }
        //private System.IO.Ports.SerialPort serialport;
        private SerialComPort serialcomport;
        private Timer receivedDataTimer;
        private Timer replayFileTimer;
        private string receivedData;
        private bool dataReady = false;
        private StreamReader file;

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
            if (dataReady)
            {
                dataReady = false;
                UpdateDataWindow(receivedData);
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
                        serialcomport.SendLine(message + "\r\n");
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
        private void SendMessageButton(object sender, EventArgs e)
        {
            if (serialcomport.IsOpen())
            {
                string message = MessageToSend.Text + "\r\n";
                serialcomport.SendLine(message);
                UpdateDataWindow(message);
            }
            else
            {
                UpdateDataWindow("Сначала откройте свой порт\r\n");
            }
        }
        private void SendFileButton(object sender, EventArgs e)
        {
            if (!serialcomport.IsOpen())
            {
                UpdateDataWindow("Сначала откройте свой порт\r\n");
                return;
            }
            if (SendFile.Text == "Передать файл")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    file = new System.IO.StreamReader(openFileDialog.FileName);
                    SendFile.Text = "Остановить передачу";
                    UpdateDataWindow("Replaying to COM port: " + openFileDialog.FileName + "\r\n");
                }
            }
            else
            {
                if (file != null)
                {
                    file.Close();
                    file = null;
                    SendFile.Text = "Передать файл";
                }
            }
        }
        private void ConnectionButton(object sender, EventArgs e)
        {
            if (comboBoxPort.Text == "" || comboBoxBaudRate.Text == "")
            { Messages.Text = "Пожалуйста заполните настройки порта\n"; }
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
        //private void DisconnectionButton(object sender, EventArgs e)
        //{
        //    DateTime dt = DateTime.Now;
        //    String dtn = dt.ToShortTimeString();

        //    if (serialport.IsOpen)
        //    {
        //        serialport.Close();
        //        Disconnection.Enabled = false;
        //        Send.Enabled = false;
        //        Connection.Enabled = true;
        //        Messeges.AppendText(" [" + dtn + "] " + "Отключен\n");
        //    }
        //}
        private void BrowseButton(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Выберите путь, где хотите сохранить свои файлы:" })
                if (fbd.ShowDialog() == DialogResult.OK) 
                {
                    FileInfo.Text = "Файлы будут сохранены по пути" + fbd.SelectedPath + "\n";
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
        private void ClearFileInfoButton(object sender, EventArgs e)
        {
            
        }
    }
}
