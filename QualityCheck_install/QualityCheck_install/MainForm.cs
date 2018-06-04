using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QualityCheck_install
{
    public partial class MainForm : Form
    {
        public string connStr;
        LoadForm f2;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //connStr = "server=" + textBoxHost.Text + ";user=" + textBoxLogin.Text + ";port=" + textBoxPort.Text + ";password=" + textBoxPassword.Text + ";";
            buttonReady.Enabled = false;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                CreateDB();
            }
            catch
            {
                MessageBox.Show("Проверьте правильность ввода параметров");
            }
        }

        private void buttonReady_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CreateDB()
        {
            connStr = "server=" + textBoxHost.Text + ";user=" + textBoxLogin.Text + ";port=" + textBoxPort.Text + ";password=" + textBoxPassword.Text + ";";
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                conn.Close();
            }
            f2 = new LoadForm(connStr);
            buttonCreate.Enabled = false;
            f2.ShowDialog();
            buttonReady.Enabled = true;
        }
    }
}
