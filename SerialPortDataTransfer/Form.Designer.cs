namespace COMPDT
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textBoxMessege = new System.Windows.Forms.TextBox();
            this.SendFile = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.Messages = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.Connection = new System.Windows.Forms.Button();
            this.Browse = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MessageToSend = new System.Windows.Forms.TextBox();
            this.SendMessege = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Delete = new System.Windows.Forms.Button();
            this.FileInfo = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMessege
            // 
            this.textBoxMessege.Location = new System.Drawing.Point(6, 71);
            this.textBoxMessege.Name = "textBoxMessege";
            this.textBoxMessege.Size = new System.Drawing.Size(93, 20);
            this.textBoxMessege.TabIndex = 3;
            // 
            // SendFile
            // 
            this.SendFile.Enabled = false;
            this.SendFile.Location = new System.Drawing.Point(452, 233);
            this.SendFile.Name = "SendFile";
            this.SendFile.Size = new System.Drawing.Size(161, 35);
            this.SendFile.TabIndex = 5;
            this.SendFile.Text = "Передать файл";
            this.SendFile.UseVisualStyleBackColor = true;
            this.SendFile.Click += new System.EventHandler(this.SendFileButton);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(5, 32);
            this.textBoxName.MaxLength = 32;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(94, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Название:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Послед. порт:";
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7"});
            this.comboBoxPort.Location = new System.Drawing.Point(6, 31);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(102, 21);
            this.comboBoxPort.TabIndex = 8;
            // 
            // Messages
            // 
            this.Messages.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Messages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Messages.Cursor = System.Windows.Forms.Cursors.Default;
            this.Messages.Location = new System.Drawing.Point(6, 19);
            this.Messages.Name = "Messages";
            this.Messages.ReadOnly = true;
            this.Messages.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Messages.Size = new System.Drawing.Size(605, 208);
            this.Messages.TabIndex = 9;
            this.Messages.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Скорость предачи:";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "115200"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(6, 70);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(102, 21);
            this.comboBoxBaudRate.TabIndex = 11;
            // 
            // Connection
            // 
            this.Connection.Location = new System.Drawing.Point(6, 107);
            this.Connection.Name = "Connection";
            this.Connection.Size = new System.Drawing.Size(102, 21);
            this.Connection.TabIndex = 18;
            this.Connection.Text = "Подключиться";
            this.Connection.UseVisualStyleBackColor = true;
            this.Connection.Click += new System.EventHandler(this.ConnectionButton);
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(105, 31);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 20);
            this.Browse.TabIndex = 19;
            this.Browse.Text = "Путь";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.BrowseButton);
            // 
            // textBoxPath
            // 
            this.textBoxPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPath.Location = new System.Drawing.Point(2, -7);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.ShortcutsEnabled = false;
            this.textBoxPath.Size = new System.Drawing.Size(109, 13);
            this.textBoxPath.TabIndex = 21;
            this.textBoxPath.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxPort);
            this.groupBox1.Controls.Add(this.Connection);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxBaudRate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(116, 139);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Содержание:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MessageToSend);
            this.groupBox2.Controls.Add(this.SendMessege);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.SendFile);
            this.groupBox2.Controls.Add(this.Messages);
            this.groupBox2.Location = new System.Drawing.Point(12, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(619, 307);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Сообщения";
            // 
            // MessageToSend
            // 
            this.MessageToSend.Location = new System.Drawing.Point(92, 274);
            this.MessageToSend.Name = "MessageToSend";
            this.MessageToSend.Size = new System.Drawing.Size(440, 20);
            this.MessageToSend.TabIndex = 12;
            // 
            // SendMessege
            // 
            this.SendMessege.Location = new System.Drawing.Point(538, 274);
            this.SendMessege.Name = "SendMessege";
            this.SendMessege.Size = new System.Drawing.Size(75, 20);
            this.SendMessege.TabIndex = 11;
            this.SendMessege.Text = "Отправить";
            this.SendMessege.UseVisualStyleBackColor = true;
            this.SendMessege.Click += new System.EventHandler(this.SendMessageButton);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Комментарии:";
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(105, 71);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 20);
            this.Add.TabIndex = 25;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.AddInfoToFileButton);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Delete);
            this.groupBox3.Controls.Add(this.FileInfo);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.Browse);
            this.groupBox3.Controls.Add(this.textBoxMessege);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBoxName);
            this.groupBox3.Controls.Add(this.Add);
            this.groupBox3.Location = new System.Drawing.Point(134, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(497, 139);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Редактирование файла";
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(5, 107);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(175, 21);
            this.Delete.TabIndex = 27;
            this.Delete.Text = "Очистить";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.ClearFileInfoButton);
            // 
            // FileInfo
            // 
            this.FileInfo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FileInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.FileInfo.Location = new System.Drawing.Point(186, 19);
            this.FileInfo.Name = "FileInfo";
            this.FileInfo.ReadOnly = true;
            this.FileInfo.Size = new System.Drawing.Size(303, 109);
            this.FileInfo.TabIndex = 10;
            this.FileInfo.Text = "";
            // 
            // Form
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 469);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxPath);
            this.Name = "Form";
            this.ShowIcon = false;
            this.Text = "Serial Port Data Transfer";
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.Load += new System.EventHandler(this.Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBoxMessege;
        private System.Windows.Forms.Button SendFile;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.RichTextBox Messages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Button Connection;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox FileInfo;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.TextBox MessageToSend;
        private System.Windows.Forms.Button SendMessege;
        private System.Windows.Forms.Label label4;
    }
}

