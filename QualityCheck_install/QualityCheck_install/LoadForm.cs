﻿using System;
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
    public partial class LoadForm : Form
    {
        string connStr;

        public LoadForm(string text)
        {
            InitializeComponent();
            Shown += new EventHandler(Form2_Shown);
            connStr = text;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            buttonReady.Enabled = false;
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    var comd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS `QualityInfo`;", conn);
                    comd.ExecuteNonQuery();
                    progressBar1.Value = 5;
                    comd = new MySqlCommand("USE qualityinfo;", conn);
                    comd.ExecuteNonQuery();
                    progressBar1.Value = 10;
                    label1.Text = "Создание таблиц...";
                    comd = new MySqlCommand("CREATE TABLE IF NOT EXISTS users (" +
                                               "user_id INT NOT NULL PRIMARY KEY AUTO_iNCREMENT," +
                                               "user_uid char(20) NOT NULL unique," +
                                               "lastname char(20)," +
                                               "firstname char(20)," +
                                               "thirdname char(20)," +
                                               "user_password char(20)," +
                                               "user_group int); ", conn);
                    comd.ExecuteNonQuery();
                    progressBar1.Value = 20;
                    comd = new MySqlCommand("CREATE TABLE IF NOT EXISTS collection_file (" +
                        "collection_id INT NOT NULL PRIMARY KEY AUTO_iNCREMENT, " +
                        "file_name CHAR(50) unique, collection_start DATETIME, " +
                        "collection_end DATETIME, " +
                        "quality_mark INT,user_id INT, " +
                        "FOREIGN KEY (user_id) REFERENCES users(user_id));", conn);
                    comd.ExecuteNonQuery();
                    progressBar1.Value = 30;
                    comd = new MySqlCommand("CREATE TABLE IF NOT EXISTS device_information (" +
                        "device_id INT NOT NULL PRIMARY KEY AUTO_iNCREMENT, " +
                        "manufacturer CHAR(50), model CHAR(50), os_version char(50), " +
                        "collection_id INT, " +
                        "FOREIGN KEY (collection_id) REFERENCES collection_file(collection_id));", conn);
                    comd.ExecuteNonQuery();
                    progressBar1.Value = 30;
                    comd = new MySqlCommand("CREATE TABLE IF NOT EXISTS network_information (" +
                        "network_id INT NOT NULL PRIMARY KEY AUTO_iNCREMENT, hostname CHAR(50), " +
                        "mac CHAR(50), interface_type char(50), device_description CHAR(50), " +
                        "ipv6 CHAR(50), ipv4 char(50), collection_id INT, " +
                        "FOREIGN KEY (collection_id) REFERENCES collection_file(collection_id));", conn);
                    comd.ExecuteNonQuery();
                    progressBar1.Value = 40;
                    comd = new MySqlCommand("CREATE TABLE IF NOT EXISTS throughput_raw_data (" +
                        "throughput_id INT NOT NULL PRIMARY KEY AUTO_iNCREMENT, " +
                        "collection_datetime DATETIME," +
                        "max_download float," +
                        "max_upload float," +
                        "first_scale INT," +
                        "second_scale INT," +
                        "third_scale INT," +
                        "fourth_scale INT," +
                        "fifth_scale INT, " +
                        "collection_id INT, " +
                        "FOREIGN KEY (collection_id) REFERENCES collection_file(collection_id));", conn);
                    comd.ExecuteNonQuery();
                    progressBar1.Value = 50;
                    comd = new MySqlCommand("CREATE TABLE IF NOT EXISTS icmp_test (" +
                        "icmp_test_id INT NOT NULL PRIMARY KEY AUTO_iNCREMENT, " +
                        "url_test CHAR(50), " +
                        "test_result char(10), " +
                        "icmp_length INT, rtt INT, ttl_default INT, " +
                        "ttl INT," +
                        "collection_id INT," +
                        "FOREIGN KEY (collection_id) REFERENCES collection_file(collection_id));", conn);
                    comd.ExecuteNonQuery();
                    progressBar1.Value = 60;
                    comd = new MySqlCommand("CREATE TABLE IF NOT EXISTS http_test (" +
                        "http_test_id INT NOT NULL PRIMARY KEY AUTO_iNCREMENT," +
                        "url_test CHAR(50),  " +
                        "bytes_received INT, " +
                        "time_elapsed INT, " +
                        "status_code CHAR(10)," +
                        "collection_id INT," +
                        "FOREIGN KEY (collection_id) REFERENCES collection_file(collection_id));", conn);
                    comd.ExecuteNonQuery();
                    progressBar1.Value = 70;
                    comd = new MySqlCommand("CREATE TABLE IF NOT EXISTS traffic_error (" +
                        "traffic_error_id INT NOT NULL PRIMARY KEY AUTO_iNCREMENT, " +
                        "collection_datetime DATETIME, " +
                        "in_pack_discard INT, " +
                        "in_pack_errors INT,  " +
                        "out_pack_discard INT, " +
                        "out_pack_errors INT," +
                        "collection_id INT," +
                        "FOREIGN KEY (collection_id) REFERENCES collection_file(collection_id));", conn);
                    comd.ExecuteNonQuery();
                    progressBar1.Value = 80;
                    comd = new MySqlCommand("CREATE TABLE IF NOT EXISTS event_error (" +
                        "traffic_error_id INT NOT NULL PRIMARY KEY AUTO_iNCREMENT, " +
                        "collection_datetime DATETIME, " +
                        "error_number INT, " +
                        "collection_id INT," +
                        "FOREIGN KEY (collection_id) REFERENCES collection_file(collection_id));", conn);
                    comd.ExecuteNonQuery();
                    progressBar1.Value = 90;
                    comd = new MySqlCommand("CREATE TABLE IF NOT EXISTS parameter (" +
                        "parameter_id INT NOT NULL PRIMARY KEY AUTO_iNCREMENT, " +
                        "kRg FLOAT, " +
                        "kTh FLOAT, " +
                        "kDy FLOAT, " +
                        "kEr FLOAT, " +
                        "kWd FLOAT, " +
                        "collection_id INT," +
                        "FOREIGN KEY (collection_id) REFERENCES collection_file(collection_id));", conn);
                    comd.ExecuteNonQuery();
                    progressBar1.Value = 100;
                    conn.Close();
                }
            buttonReady.Enabled = true;
        }

        private void buttonReady_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}