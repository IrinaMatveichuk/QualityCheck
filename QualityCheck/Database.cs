using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;
using System.Diagnostics;


namespace QualityCheck
{
    class Database
    {
        public string connStr;

        public Database(string conn)
        {
            this.connStr = conn;
        }

        public void CreateDB()
        {
            string script = File.ReadAllText("create_db.sql");
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var comd = new MySqlCommand(script, conn);
                comd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CreateUser(string firstname, string secondname, string thirdname, string password, string uid, int group)
        {
            //string connStr = "server=" + db.host + ";user=" + db.login + ";port=" + db.port + ";password=" + db.password + ";";
            using (var conn = new MySqlConnection(connStr))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "use QualityInfo;";
                cmd.ExecuteNonQuery();
                string comm = "insert into users (user_uid, lastname, firstname, thirdname, user_password, user_group) values " +
                    "(" + uid + ", '" + secondname + "', '" + firstname + "', '" + thirdname + "', '" + password + "', "+group+"); ";
                cmd.CommandText = comm;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void FillInDB(FileInformation fi, Stopwatch sw)
        {
            string comm;
            string dr = "";
            int userid, collection_id;
            //string connStr = "server=" + db.host + ";user=" + db.login + ";port=" + db.port + ";password=" + db.password + ";";
            using (var conn = new MySqlConnection(connStr))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "use QualityInfo;";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT user_id FROM users WHERE user_uid = " + fi.user_uid + ";";
                //MessageBox.Show(fi.user_uid);
                MySqlDataReader reader = cmd.ExecuteReader();
                int k = 0;
                while (reader.Read())
                {
                    // элементы массива [] - это значения столбцов из запроса SELECT
                    dr += reader[0].ToString();
                    k++;
                }
                reader.Close(); // закрываем reader
                //MessageBox.Show(dr);
                userid = Convert.ToInt32(dr);
                dr = "";

                fi.ChangeDateFormat(ref fi.DTsc);
                fi.ChangeDateFormat(ref fi.DTec);
                comm = "INSERT INTO collection_file (file_name, collection_start, collection_end, user_id) VALUES " +
                    "('" + fi.filename + "', '" + fi.DTsc + "', '" + fi.DTec + "', " + userid + ");";
                cmd.CommandText = comm;
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT collection_id FROM collection_file WHERE file_name = '" + fi.filename + "';";
                reader = cmd.ExecuteReader();
                k = 0;
                while (reader.Read())
                {
                    // элементы массива [] - это значения столбцов из запроса SELECT
                    dr += reader[0].ToString();
                    k++;
                }
                reader.Close(); // закрываем reader
                //MessageBox.Show(dr);
                collection_id = Convert.ToInt32(dr);
                dr = "";

                comm = "insert into device_information (manufacturer, model, os_version, collection_id) values " +
                    "('" + fi.Manufacturer + "', '" + fi.Model + "', '" + fi.OSversion + "', " + collection_id + ");";
                cmd.CommandText = comm;
                cmd.ExecuteNonQuery();

                for (int i = 0; i < fi.ThCount; i++)
                {
                    fi.ChangeDateFormat(ref fi.Thrp[i].datetime);
                    //MessageBox.Show(fi.Thrp[i].datetime.ToString());
                    comm = "insert into throughput_raw_data (collection_datetime, max_download, max_upload, first_scale, second_scale, third_scale, fourth_scale, fifth_scale, collection_id) values " +
                        "('" + fi.Thrp[i].datetime + "', " + fi.Thrp[i].downspeed + ", " + fi.Thrp[i].upspeed + ", " + fi.Thrp[i].gr[0] + ", " + fi.Thrp[i].gr[1]
                        + ", " + fi.Thrp[i].gr[2] + ", " + fi.Thrp[i].gr[3] + ", " + fi.Thrp[i].gr[4] + ", " + collection_id + ");";
                    //MessageBox.Show(comm);
                    cmd.CommandText = comm;
                    cmd.ExecuteNonQuery();
                }

                for (int i = 0; i < 2; i++)
                {
                    comm = "insert into icmp_test (url_test, test_result, icmp_length, rtt, ttl_default, ttl, collection_id) values " +
                    "('" + fi.ICMP[i].IP + "', '" + fi.ICMP[i].status + "', " + fi.ICMP[i].jumps + ", " + fi.ICMP[i].bytes +
                    ", " + fi.ICMP[i].maxTime + ", " + fi.ICMP[i].time + ", " + collection_id + ")";
                    cmd.CommandText = comm;
                    cmd.ExecuteNonQuery();
                }

                for (int i = 0; i < 2; i++)
                {
                    comm = "insert into http_test (url_test, bytes_received, time_elapsed, status_code, collection_id) values " +
                        "('" + fi.HTTP[i].URL + "', " + fi.HTTP[i].bytesReceived + ", " + fi.HTTP[i].timeElapsed + ", '" + fi.HTTP[i].status + "', " + collection_id + ");";
                    cmd.CommandText = comm;
                    cmd.ExecuteNonQuery();
                }

                fi.ChangeDateFormat(ref fi.InErdt);
                comm = "insert into traffic_error (collection_datetime, in_pack_discard, in_pack_errors, out_pack_discard, out_pack_errors, collection_id) values " +
                    "('" + fi.InErdt + "', " + fi.InEr[0] + ", " + fi.InEr[1] + ", " + fi.InEr[2] + ", " + fi.InEr[3] + ", " + collection_id + ");";
                cmd.CommandText = comm;
                cmd.ExecuteNonQuery();

                //MessageBox.Show(fi.kRg.ToString());
                comm = "insert into parameter (kRg, kTh, kDy, kEr, kWd, collection_id) values " +
                    "(" + fi.kRg + ", " + fi.kTh + ", " + fi.kDy + ", " + fi.kEr + ", " + fi.kWd + ", " + collection_id + ");";
                cmd.CommandText = comm;
                cmd.ExecuteNonQuery();

                conn.Close();

                sw.Stop();
                MessageBox.Show((sw.ElapsedMilliseconds / 100.0).ToString());
                MessageBox.Show("Данные из последнего файла от пользователя с UID = " + fi.user_uid + " обработаны и загружены в БД. Ожидается выставление оценки.");
            }
        }
    }
}
