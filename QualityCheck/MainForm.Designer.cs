namespace QualityCheck
{
    partial class MainForm
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDir1 = new System.Windows.Forms.Button();
            this.PathArcTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxThUMax = new System.Windows.Forms.TextBox();
            this.textBoxThrpMax = new System.Windows.Forms.TextBox();
            this.textBoxThDMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_uid = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_thirdname = new System.Windows.Forms.TextBox();
            this.textBox_secondname = new System.Windows.Forms.TextBox();
            this.textBox_firstname = new System.Windows.Forms.TextBox();
            this.tabPages = new System.Windows.Forms.TabControl();
            this.buttonStop = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxWd = new System.Windows.Forms.TextBox();
            this.buttonChangeConst = new System.Windows.Forms.Button();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPages.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(162, 319);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(111, 25);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Начать работу";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(15, 319);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(141, 24);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "Подключиться к MySQL";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.buttonChangeConst);
            this.tabPage2.Controls.Add(this.textBoxWd);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.buttonDir1);
            this.tabPage2.Controls.Add(this.PathArcTextBox);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(357, 275);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Общие";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Директория начального хранения файлов";
            // 
            // buttonDir1
            // 
            this.buttonDir1.Location = new System.Drawing.Point(319, 29);
            this.buttonDir1.Name = "buttonDir1";
            this.buttonDir1.Size = new System.Drawing.Size(31, 20);
            this.buttonDir1.TabIndex = 5;
            this.buttonDir1.Text = "...";
            this.buttonDir1.UseVisualStyleBackColor = true;
            this.buttonDir1.Click += new System.EventHandler(this.buttonDir1_Click);
            // 
            // PathArcTextBox
            // 
            this.PathArcTextBox.Location = new System.Drawing.Point(6, 30);
            this.PathArcTextBox.Name = "PathArcTextBox";
            this.PathArcTextBox.Size = new System.Drawing.Size(307, 20);
            this.PathArcTextBox.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxThUMax);
            this.groupBox1.Controls.Add(this.textBoxThrpMax);
            this.groupBox1.Controls.Add(this.textBoxThDMax);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 140);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Скорость соединения (Кб/с)";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "Максимальная скорость связи, установленная оператором";
            // 
            // textBoxThUMax
            // 
            this.textBoxThUMax.Location = new System.Drawing.Point(222, 31);
            this.textBoxThUMax.Name = "textBoxThUMax";
            this.textBoxThUMax.Size = new System.Drawing.Size(79, 20);
            this.textBoxThUMax.TabIndex = 7;
            this.textBoxThUMax.Text = "20000";
            // 
            // textBoxThrpMax
            // 
            this.textBoxThrpMax.Location = new System.Drawing.Point(222, 98);
            this.textBoxThrpMax.Name = "textBoxThrpMax";
            this.textBoxThrpMax.Size = new System.Drawing.Size(79, 20);
            this.textBoxThrpMax.TabIndex = 6;
            this.textBoxThrpMax.Text = "200000";
            // 
            // textBoxThDMax
            // 
            this.textBoxThDMax.Location = new System.Drawing.Point(222, 63);
            this.textBoxThDMax.Name = "textBoxThDMax";
            this.textBoxThDMax.Size = new System.Drawing.Size(79, 20);
            this.textBoxThDMax.TabIndex = 4;
            this.textBoxThDMax.Text = "200000";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Максимальная скорость скачивания";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Максимальная скорость загрузки";
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(357, 275);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Настройки БД";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxPort);
            this.groupBox4.Controls.Add(this.textBoxHost);
            this.groupBox4.Controls.Add(this.textBoxPassword);
            this.groupBox4.Controls.Add(this.textBoxLogin);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(328, 114);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Настройки БД";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(202, 69);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(100, 20);
            this.textBoxPort.TabIndex = 24;
            this.textBoxPort.Text = "3306";
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(201, 34);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(100, 20);
            this.textBoxHost.TabIndex = 23;
            this.textBoxHost.Text = "localhost";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(57, 72);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(89, 20);
            this.textBoxPassword.TabIndex = 22;
            this.textBoxPassword.Text = "123456";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(57, 34);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(89, 20);
            this.textBoxLogin.TabIndex = 21;
            this.textBoxLogin.Text = "Admin";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(164, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Порт";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(164, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Хост";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 72);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 13);
            this.label16.TabIndex = 18;
            this.label16.Text = "Пароль";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "Логин";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.textBox_uid);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox_password);
            this.groupBox3.Controls.Add(this.textBox_thirdname);
            this.groupBox3.Controls.Add(this.textBox_secondname);
            this.groupBox3.Controls.Add(this.textBox_firstname);
            this.groupBox3.Location = new System.Drawing.Point(3, 123);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 257);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Добавление пользователя";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(106, 200);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(31, 17);
            this.radioButton3.TabIndex = 15;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(106, 176);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(31, 17);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(106, 152);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(31, 17);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(44, 151);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Группа";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(44, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "UID";
            // 
            // textBox_uid
            // 
            this.textBox_uid.Location = new System.Drawing.Point(106, 125);
            this.textBox_uid.Name = "textBox_uid";
            this.textBox_uid.Size = new System.Drawing.Size(178, 20);
            this.textBox_uid.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(128, 228);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(44, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Пароль";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Отчество";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Фамилия";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Имя";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(106, 99);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(178, 20);
            this.textBox_password.TabIndex = 3;
            // 
            // textBox_thirdname
            // 
            this.textBox_thirdname.Location = new System.Drawing.Point(106, 72);
            this.textBox_thirdname.Name = "textBox_thirdname";
            this.textBox_thirdname.Size = new System.Drawing.Size(178, 20);
            this.textBox_thirdname.TabIndex = 2;
            // 
            // textBox_secondname
            // 
            this.textBox_secondname.Location = new System.Drawing.Point(106, 46);
            this.textBox_secondname.Name = "textBox_secondname";
            this.textBox_secondname.Size = new System.Drawing.Size(178, 20);
            this.textBox_secondname.TabIndex = 1;
            // 
            // textBox_firstname
            // 
            this.textBox_firstname.Location = new System.Drawing.Point(106, 19);
            this.textBox_firstname.Name = "textBox_firstname";
            this.textBox_firstname.Size = new System.Drawing.Size(178, 20);
            this.textBox_firstname.TabIndex = 0;
            // 
            // tabPages
            // 
            this.tabPages.Controls.Add(this.tabPage3);
            this.tabPages.Controls.Add(this.tabPage2);
            this.tabPages.Location = new System.Drawing.Point(12, 12);
            this.tabPages.Name = "tabPages";
            this.tabPages.SelectedIndex = 0;
            this.tabPages.Size = new System.Drawing.Size(365, 301);
            this.tabPages.TabIndex = 1;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(279, 319);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(98, 25);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Остановить";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(237, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Параметр временного окна оценки качества";
            // 
            // textBoxWd
            // 
            this.textBoxWd.Location = new System.Drawing.Point(250, 216);
            this.textBoxWd.Name = "textBoxWd";
            this.textBoxWd.Size = new System.Drawing.Size(100, 20);
            this.textBoxWd.TabIndex = 8;
            this.textBoxWd.Text = "2";
            // 
            // buttonChangeConst
            // 
            this.buttonChangeConst.Location = new System.Drawing.Point(9, 246);
            this.buttonChangeConst.Name = "buttonChangeConst";
            this.buttonChangeConst.Size = new System.Drawing.Size(341, 23);
            this.buttonChangeConst.TabIndex = 9;
            this.buttonChangeConst.Text = "Изменить константы формул вычисления параметров";
            this.buttonChangeConst.UseVisualStyleBackColor = true;
            this.buttonChangeConst.Click += new System.EventHandler(this.buttonChangeConst_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(389, 352);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.tabPages);
            this.Name = "Form1";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPages.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonDir1;
        private System.Windows.Forms.TextBox PathArcTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxThUMax;
        private System.Windows.Forms.TextBox textBoxThrpMax;
        private System.Windows.Forms.TextBox textBoxThDMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_uid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_thirdname;
        private System.Windows.Forms.TextBox textBox_secondname;
        private System.Windows.Forms.TextBox textBox_firstname;
        private System.Windows.Forms.TabControl tabPages;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textBoxWd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonChangeConst;
    }
}

