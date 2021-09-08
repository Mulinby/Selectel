namespace Selectel
{
    partial class Main_window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_window));
            this.portList = new System.Windows.Forms.ComboBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textServer = new System.Windows.Forms.TextBox();
            this.textUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textContainer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textPath = new System.Windows.Forms.TextBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.checkReplace = new System.Windows.Forms.CheckBox();
            this.checkFolder = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textFileName = new System.Windows.Forms.Label();
            this.textExtension = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textSize = new System.Windows.Forms.Label();
            this.textStatus = new System.Windows.Forms.Label();
            this.textCount = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // portList
            // 
            this.portList.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.portList.DropDownHeight = 50;
            this.portList.DropDownWidth = 120;
            this.portList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.portList.FormattingEnabled = true;
            this.portList.IntegralHeight = false;
            this.portList.ItemHeight = 13;
            this.portList.Location = new System.Drawing.Point(20, 10);
            this.portList.Margin = new System.Windows.Forms.Padding(10);
            this.portList.Name = "portList";
            this.portList.Size = new System.Drawing.Size(120, 21);
            this.portList.TabIndex = 1;
            this.portList.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            // 
            // btn_connect
            // 
            this.btn_connect.BackColor = System.Drawing.SystemColors.Control;
            this.btn_connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_connect.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_connect.FlatAppearance.BorderSize = 0;
            this.btn_connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_connect.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_connect.Location = new System.Drawing.Point(150, 9);
            this.btn_connect.Margin = new System.Windows.Forms.Padding(10);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(120, 23);
            this.btn_connect.TabIndex = 2;
            this.btn_connect.Text = "ПОДКЛЮЧИТЬСЯ";
            this.btn_connect.UseVisualStyleBackColor = false;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Selectel клиент";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "СЕРВЕР";
            // 
            // textServer
            // 
            this.textServer.Location = new System.Drawing.Point(150, 76);
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(120, 20);
            this.textServer.TabIndex = 4;
            this.textServer.Text = "ftp.selcdn.ru";
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(150, 102);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(120, 20);
            this.textUser.TabIndex = 6;
            this.textUser.Text = "USER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "ПОЛЬЗОВАТЕЛЬ";
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(150, 128);
            this.textPass.Name = "textPass";
            this.textPass.PasswordChar = '*';
            this.textPass.Size = new System.Drawing.Size(120, 20);
            this.textPass.TabIndex = 8;
            this.textPass.Text = "PASSWORD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "ПАРОЛЬ";
            // 
            // textContainer
            // 
            this.textContainer.Location = new System.Drawing.Point(150, 154);
            this.textContainer.Name = "textContainer";
            this.textContainer.Size = new System.Drawing.Size(120, 20);
            this.textContainer.TabIndex = 10;
            this.textContainer.Text = "Maneki";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "КОНТЕЙНЕР";
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(150, 50);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(374, 20);
            this.textPath.TabIndex = 12;
            this.textPath.Text = "D:";
            this.textPath.Click += new System.EventHandler(this.TextPath_Click);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(52, 53);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(92, 13);
            this.labelPath.TabIndex = 11;
            this.labelPath.Text = "ПУТЬ К ФАЙЛУ";
            // 
            // checkReplace
            // 
            this.checkReplace.AutoSize = true;
            this.checkReplace.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkReplace.Location = new System.Drawing.Point(290, 12);
            this.checkReplace.Name = "checkReplace";
            this.checkReplace.Size = new System.Drawing.Size(105, 17);
            this.checkReplace.TabIndex = 13;
            this.checkReplace.Text = "Заменять файл";
            this.checkReplace.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkReplace.UseVisualStyleBackColor = true;
            this.checkReplace.CheckedChanged += new System.EventHandler(this.CheckReplace_CheckedChanged);
            // 
            // checkFolder
            // 
            this.checkFolder.AutoSize = true;
            this.checkFolder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkFolder.Location = new System.Drawing.Point(420, 12);
            this.checkFolder.Name = "checkFolder";
            this.checkFolder.Size = new System.Drawing.Size(105, 17);
            this.checkFolder.TabIndex = 14;
            this.checkFolder.Text = "Папка целиком";
            this.checkFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkFolder.UseVisualStyleBackColor = true;
            this.checkFolder.CheckedChanged += new System.EventHandler(this.CheckFolder_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(370, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Имя";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(329, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Расширение";
            // 
            // textFileName
            // 
            this.textFileName.AutoSize = true;
            this.textFileName.Location = new System.Drawing.Point(405, 79);
            this.textFileName.Name = "textFileName";
            this.textFileName.Size = new System.Drawing.Size(38, 13);
            this.textFileName.TabIndex = 19;
            this.textFileName.Text = "NAME";
            // 
            // textExtension
            // 
            this.textExtension.AutoSize = true;
            this.textExtension.Location = new System.Drawing.Point(405, 131);
            this.textExtension.Name = "textExtension";
            this.textExtension.Size = new System.Drawing.Size(28, 13);
            this.textExtension.TabIndex = 20;
            this.textExtension.Text = "EXT";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(353, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Размер";
            // 
            // textSize
            // 
            this.textSize.AutoSize = true;
            this.textSize.Location = new System.Drawing.Point(405, 105);
            this.textSize.Name = "textSize";
            this.textSize.Size = new System.Drawing.Size(31, 13);
            this.textSize.TabIndex = 22;
            this.textSize.Text = "SIZE";
            // 
            // textStatus
            // 
            this.textStatus.AutoSize = true;
            this.textStatus.Location = new System.Drawing.Point(20, 188);
            this.textStatus.Name = "textStatus";
            this.textStatus.Size = new System.Drawing.Size(68, 13);
            this.textStatus.TabIndex = 24;
            this.textStatus.Text = "Ожидание...";
            // 
            // textCount
            // 
            this.textCount.AutoSize = true;
            this.textCount.Location = new System.Drawing.Point(405, 157);
            this.textCount.Name = "textCount";
            this.textCount.Size = new System.Drawing.Size(13, 13);
            this.textCount.TabIndex = 25;
            this.textCount.Text = "0";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(309, 157);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(90, 13);
            this.labelCount.TabIndex = 26;
            this.labelCount.Text = "Файлов в папке";
            // 
            // Main_window
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(544, 211);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.textCount);
            this.Controls.Add(this.textStatus);
            this.Controls.Add(this.textSize);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textExtension);
            this.Controls.Add(this.textFileName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkFolder);
            this.Controls.Add(this.checkReplace);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.textContainer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.portList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(560, 300);
            this.Name = "Main_window";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selectel клиент";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_window_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox portList;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textServer;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textContainer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.CheckBox checkReplace;
        private System.Windows.Forms.CheckBox checkFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label textFileName;
        private System.Windows.Forms.Label textExtension;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label textSize;
        private System.Windows.Forms.Label textStatus;
        private System.Windows.Forms.Label textCount;
        private System.Windows.Forms.Label labelCount;
    }
}

