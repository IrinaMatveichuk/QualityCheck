using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace QualityCheck
{
    public partial class MainForm : Form
    {
        string directory, newDirectory;
        FileInformation fi;

        FileSystemWatcher watcher;

        string path;
        string connStr;
        string text;

        Database db;

        public MainForm()
        {
            InitializeComponent();
            textBoxThDMax.KeyPress += textBoxThDMax_KeyPress;
            textBoxThUMax.KeyPress += textBoxThUMax_KeyPress;
            textBoxThrpMax.KeyPress += textBoxThrpMax_KeyPress;
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            PathArcTextBox.Text = "D:\\VKR_files\\";
            //    directory = PathArcTextBox.Text;
            //    newDirectory = PathArcTextBox.Text+"\\OldFiles\\";
            buttonStart.Enabled = false;
            buttonStop.Enabled = false;
        }
        
        public void GetData()
        {
            fi.ThrpMax = Convert.ToDouble(textBoxThrpMax.Text);
            fi.ThDMax = Convert.ToDouble(textBoxThDMax.Text);
            fi.ThUMax = Convert.ToDouble(textBoxThUMax.Text);
            fi.pl = Convert.ToInt32(textBoxWd.Text);
        } //данные с формы
        
        public void ProcessFile(string path)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            fi.Clear();
            fi.ReadData(directory, newDirectory);
            GetData();
            fi.CalculateParams();
            db.FillInDB(fi, sw);
        }

        public string DBhost()
        {
            return textBoxHost.Text;
        }
        public string DBport()
        {
            return textBoxPort.Text;
        }
        public string DBlogin()
        {
            return textBoxLogin.Text;
        }
        public string DBpassword()
        {
            return textBoxPassword.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int gr = DefineGroup();
            try
            {
                db.CreateUser(textBox_firstname.Text, textBox_secondname.Text, textBox_thirdname.Text, textBox_password.Text, textBox_uid.Text, gr);
            }
            catch
            {
                MessageBox.Show("Проверьте правильность ввода даннных!");
            }
            textBox_firstname.Text = "";
            textBox_secondname.Text = "";
            textBox_thirdname.Text = "";
            textBox_password.Text = "";
            textBox_uid.Text = "";
            if (radioButton1.Checked == true) radioButton1.Checked = false;
            else if (radioButton2.Checked == true) radioButton2.Checked = false;
            else if (radioButton3.Checked == true) radioButton3.Checked = false;
            MessageBox.Show("Пользователь добавлен");
        } //добавление пользователя

        public int DefineGroup()
        {
            if (radioButton1.Checked == true) return 1;
            else if (radioButton2.Checked == true) return 2;
            else if (radioButton3.Checked == true) return 3;
            else return 0;
        }

        public void OnChanged(object source, FileSystemEventArgs e)
        {
            //System.Threading.Thread.Sleep(10000);
            ProcessFile(directory);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            bool fl = false;
            //connStr = "server=" + DBhost() + ";user=" + DBlogin() + ";port=" + DBport() + ";password=" + DBpassword() + ";";
            db = new Database(connStr);

            using (var conn = new MySqlConnection(connStr))
            using (var cmd = conn.CreateCommand())
            {
                string dr = "";
                conn.Open();
                cmd.CommandText = "use QualityInfo;";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select user_id from users limit 1;";
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == false) MessageBox.Show("Необходимо добавить пользователя");
                else fl = true;
                reader.Close(); // закрываем reader
                conn.Close();
            }

            if (fl == true)
            {
                directory = PathArcTextBox.Text;
                newDirectory = PathArcTextBox.Text + "\\OldFiles\\";

                fi = new FileInformation(connStr);
                fi.st.ReadSettings();

                int nfiles = Directory.GetFiles(directory).Length;
                if (nfiles != 0)
                {
                    for (int i = 0; i < nfiles; i++)
                        ProcessFile(directory);
                }

                watcher = new FileSystemWatcher();
                watcher.Path = PathArcTextBox.Text;
                watcher.Filter = "*.txt";
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.EnableRaisingEvents = true;
                buttonStart.Enabled = false;
                buttonStop.Enabled = true;
                textBoxThDMax.Enabled = false;
                textBoxThUMax.Enabled = false;
                textBoxThrpMax.Enabled = false;
                textBoxWd.Enabled = false;
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                connStr = "server=" + DBhost() + ";user=" + DBlogin() + ";port=" + DBport() + ";password=" + DBpassword() + ";";

                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    conn.Close();
                }
                buttonStart.Enabled = true;
                buttonConnect.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Проверьте правильность ввода параметров");
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            textBoxThDMax.Enabled = true;
            textBoxThUMax.Enabled = true;
            textBoxThrpMax.Enabled = true;
            textBoxWd.Enabled = true;

            watcher.EnableRaisingEvents = false;
        }
        
        private void textBoxThDMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void textBoxThUMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void textBoxThrpMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void buttonChangeConst_Click(object sender, EventArgs e)
        {
            Process.Start(@"settings.txt");
        }

        private void buttonDir1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog DirDialog = new FolderBrowserDialog();
            //DialogResult result = DirDialog.ShowDialog();
            DirDialog.Description = "Выбор директории";
            DirDialog.SelectedPath = @"D:\";

            if (DirDialog.ShowDialog() == DialogResult.OK)
            {
                PathArcTextBox.Text = DirDialog.SelectedPath;
                directory = PathArcTextBox.Text;
                newDirectory = PathArcTextBox.Text + "\\OldFiles\\";
            }

        }
    }
}
