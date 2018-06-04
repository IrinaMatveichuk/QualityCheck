using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;

namespace QualityCheck
{
    class FileInformation
    {
        public Settings st;
        string connStr;

        public int pl=1; //ко-во последних измерений для оценки
        public double HTTPSpeed;
        public string DTsc, DTec; //начало сбора данных
        public ICMPClass[] ICMP = new ICMPClass[2];
        public HTTPClass[] HTTP = new HTTPClass[2];
        public ThrpClass[] Thrp = new ThrpClass[25];
        public string HstN; //название хоста
        public string AdpI;
        public string[] AdpI1 = new string[3];
        public string MfMd; //проиводитель и модель ПК
        public string Manufacturer; 
        public string Model;
        public string OSversion; //данные ОС
        public string IPvX;
        public string[] IPv64 = new string[2];
        public int[] InEr = new int[4];
        public string InErdt;
        public string EvErdt;
        public int EvErnum;
        public string filename;
        public int ThCount = 25;
        public double ThrpMax, ThDMax, ThUMax; //макс. скорость связи
        public string user_uid;
        public int user_group;

        public double[] Qrg;
        public double kRg;
        public double[] Qth;
        public double kTh;
        public double Qdy;
        public double kDy;
        public double Qer;
        public double kEr;
        public double Qwd;
        public double kWd;

        public FileInformation(string conn)
        {
            st = new Settings();
            this.connStr = conn;
            for (int i = 0; i < 2; i++)
                HTTP[i] = new HTTPClass();
            for (int i = 0; i < 2; i++)
                ICMP[i] = new ICMPClass();
            for (int i = 0; i < ThCount; i++)
                Thrp[i] = new ThrpClass();
        }

        public void CalculateParams()
        {
            Qrg = QrgCount();
            kRg = kRgCount(Qrg);
            Qth = QthCount();
            kTh = kThCount(Qth);
            Qdy = QdyCount();
            kDy = kDyCount(Qdy);
            Qer = QerCount();
            kEr = kErCount(Qer);
            Qwd = QwdCount(pl, connStr);
            kWd = kWdCount(Qwd);
        }

        public double QerCount()
        {
            double Qer = st.d[0] * Math.Pow(Math.E, -InEr[0]) + st.d[1] * Math.Pow(Math.E, -InEr[2]);
            return Qer;
        }

        public double kErCount(double Qer)
        {
            double Qermin = st.d[0] * (1 / Math.E) + st.d[1] * (1 / Math.E);
            double Qermax = st.d[0] + st.d[1];
            //MessageBox.Show(Qermin.ToString()+" "+ Qermax.ToString());
            double kEr = (Qer - Qermin) / (Qermax - Qermin);
            //MessageBox.Show(kEr.ToString());
            return kEr;
        }

        public double[] QrgCount()
        {
            double[] Qrg = new double[ThCount];
            for (int i = 0; i < ThCount; i++)
            {
                for (int j = 0; j < st.qgr; j++)
                {
                    st.p[j] = (100 * Thrp[i].gr[j]) / 60;
                    st.p[j] = st.p[j] / 100;
                }
                Qrg[i] = 0;
                for (int j = 0; j < st.qgr; j++)
                {
                    Qrg[i] += st.a[j] * Math.Pow(Math.E, st.p[j]);
                }
            }
            return Qrg;
        }

        public double kRgCount(double[] Qrg)
        {
            double Qrgmin = 0, Qrgmax = 0, sum = 0, kRg;
            double[] kRg1 = new double[ThCount];
            for (int i = 0; i < st.qgr; i++)
            {
                if (i == 0) Qrgmax += st.a[i] * Math.E;
                else Qrgmax += st.a[i];
            }
            for (int i = 0; i < st.qgr; i++)
            {
                if (i == st.qgr - 1) Qrgmin += st.a[i] * Math.E;
                else Qrgmin += st.a[i];
            }

            for (int i = 0; i < ThCount; i++)
            {
                kRg1[i] = (Qrg[i] - Qrgmin) / (Qrgmax - Qrgmin);
                sum += kRg1[i];
                //kRg1[i] = Math.Round(kRg1[i], 3, MidpointRounding.AwayFromZero);
            }
            //MessageBox.Show(kRg[1].ToString());
            kRg = sum / kRg1.Length;
            return kRg;
        }

        public double QdyCount()
        {
            double Qdy = 0;
            for (int i = 0; i < st.qdy; i++)
            {
                double pow = -((double)ICMP[i].time / (double)ICMP[i].maxTime);
                Qdy += st.c[i] * Math.Pow(Math.E, pow);
            }
            //MessageBox.Show(Qdy.ToString());
            return Qdy;
        }

        public double kDyCount(double Qdy)
        {
            double Qdymin = 0, Qdymax = 0;
            double kDy;
            for (int i = 0; i < st.qdy; i++)
            {
                Qdymax += st.c[i] * (1 / Math.E);
                Qdymin += st.c[0];
            }
            //MessageBox.Show(Qdymax.ToString() + " " + Qdymin.ToString());
            kDy = (Qdy - Qdymin) / (Qdymax - Qdymin);
            //MessageBox.Show(Qdy.ToString() + " " + kDy.ToString());
            return kDy;
        }

        public double[] QthCount()
        {
            double[] QTh = new double[ThCount];
            double Tdw = (HTTP[0].bytesReceived + HTTP[1].bytesReceived) / 2;
            for (int i = 0; i < ThCount; i++)
            {
                QTh[i] = st.b[0] * Math.Pow(Math.E, Thrp[i].downspeed / ThrpMax) + st.b[1] * Math.Pow(Math.E, Thrp[i].upspeed / ThrpMax)
                    + st.b[2] * Math.Pow(Math.E, Tdw / ThrpMax);
            }
            return QTh;
        }

        public double kThCount(double[] QTh)
        {
            double sum = 0, kTh;
            double[] kTh1 = new double[ThCount];
            double QThMax = st.b[0] * Math.Pow(Math.E, ThDMax / ThrpMax) + st.b[1] * Math.Pow(Math.E, ThUMax / ThrpMax)
                    + st.b[2] * Math.Pow(Math.E, HTTPSpeed / ThrpMax);
            double QThMin = st.b[0] + st.b[1] + st.b[2];
            //MessageBox.Show(QThMax.ToString()+" "+QThMin.ToString());
            for (int i = 0; i < ThCount; i++)
            {
                kTh1[i] = (QTh[i] - QThMin) / (QThMax - QThMin);
                if (kTh1[i] > 1) kTh1[i] = 1;
                sum += kTh1[i];
                //MessageBox.Show(QTh[i].ToString()+" "+kTh[i].ToString());
            }
            kTh = sum / kTh1.Length;
            return kTh;
        }

        public double QwdCount(int n, string connStr)
        {
            double Qwd = 0; 
            int count; //кол-во строк с оценкой
            //MessageBox.Show(connStr);
            //string connStr = "server=" + db.host + ";user=" + db.login + ";port=" + db.port + ";password=" + db.password + ";";
            using (var conn = new MySqlConnection(connStr))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "use QualityInfo;";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT COUNT(*) FROM collection_file WHERE quality_mark IS NOT NULL;";
                count = Convert.ToInt32(cmd.ExecuteScalar());
                if (n < count) count = n;
                int[] marks = new int[count];
                cmd.CommandText = "SELECT quality_mark FROM collection_file WHERE quality_mark IS NOT NULL ORDER BY collection_id DESC LIMIT " + count + ";";
                MySqlDataReader reader = cmd.ExecuteReader();
                int k = 0;
                while (reader.Read())
                {
                    // элементы массива [] - это значения столбцов из запроса SELECT
                    marks[k] = Convert.ToInt32(reader[0]);
                    k++;
                }
                reader.Close(); // закрываем reader
                conn.Close();
                //MessageBox.Show(marks[1].ToString());
                for (int i = 0; i < k; i++)
                {
                    Qwd += marks[i] * Math.Pow(Math.E, -(i + 1) / k);
                }
                pl = k;
                //MessageBox.Show(Qwd.ToString());
            }
            return Qwd;
        }

        public double kWdCount(double Qwd)
        {
            double kWd;
            double Qwdmin = 0, Qwdmax = 0;

            for (int i = 0; i < pl; i++)
            {
                Qwdmin += 1 * Math.Pow(Math.E, -(i + 1) / pl);
                Qwdmax += 5 * Math.Pow(Math.E, -(i + 1) / pl);
            }
            kWd = (Qwd - Qwdmin) / (Qwdmax - Qwdmin);
            if (Qwd == 0) kWd = 1;
            //MessageBox.Show(kWd.ToString());
            return kWd;
        }

        public void ReadData(string directory, string newDirectory)
        {
            string text;
            DirectoryInfo inputDirectory = new DirectoryInfo(directory);
            var myFile = inputDirectory.GetFiles().OrderByDescending(f => f.LastWriteTime).First();
            filename = myFile.ToString();
            string path = directory+"\\" + filename + "";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                text = sr.ReadLine();
            //MessageBox.Show(text);

            int indDTsc = text.IndexOf("DTsc");
            for (int i = indDTsc + 4; i < indDTsc + 23; i++)
                DTsc += text[i];
            int indDTec = text.IndexOf("DTec");
            for (int i = indDTec + 4; i < indDTec + 23; i++)
                DTec += text[i];
            //MessageBox.Show(fi.DTec);
            string data = "";
            int j = 1, m = 0;
            for (int i = 29; i < text.Length; i++)
            {
                data += text[i].ToString();
                if (text[i].ToString() == "," && j == 1)
                {
                    data = data.Remove(data.Length - 1);
                    Thrp[m].datetime = data;
                    //MessageBox.Show(fi.Thrp[m].datetime.ToString());
                    data = "";
                    j++;
                    continue;
                }
                else if (text[i].ToString() == "," && j == 2)
                {
                    data = data.Remove(data.Length - 1);
                    Thrp[m].downspeed = Convert.ToDouble(data, CultureInfo.GetCultureInfo("en-US"));
                    data = "";
                    j++;
                    continue;
                }
                else if (text[i].ToString() == "," && j == 3)
                {
                    data = data.Remove(data.Length - 1);
                    Thrp[m].upspeed = Convert.ToDouble(data, CultureInfo.GetCultureInfo("en-US"));
                    data = "";
                    j++;
                    continue;
                }
                else if (text[i].ToString() == "," && j == 4)
                {
                    data = data.Remove(data.Length - 1);
                    Thrp[m].gr[0] = Convert.ToInt16(data);
                    data = "";
                    j++;
                    continue;
                }
                else if (text[i].ToString() == "," && j == 5)
                {
                    data = data.Remove(data.Length - 1);
                    Thrp[m].gr[1] = Convert.ToInt16(data);
                    data = "";
                    j++;
                    continue;
                }
                else if (text[i].ToString() == "," && j == 6)
                {
                    data = data.Remove(data.Length - 1);
                    Thrp[m].gr[2] = Convert.ToInt16(data);
                    data = "";
                    j++;
                    continue;
                }
                else if (text[i].ToString() == "," && j == 7)
                {
                    data = data.Remove(data.Length - 1);
                    Thrp[m].gr[3] = Convert.ToInt16(data);
                    data = "";
                    j++;
                    continue;
                }
                else if ((text[i].ToString() == "," || text[i].ToString() == "|") && j == 8)
                {
                    data = data.Remove(data.Length - 1);
                    if (text[i].ToString() == "|") i += 4;
                    Thrp[m].gr[4] = Convert.ToInt16(data);
                    data = "";
                    j = 1;
                    m++;
                    if (m == 25) break;
                    continue;
                }
            }
            int indHstN = text.IndexOf("HstN");
            for (int i = indHstN + 4; ; i++)
            {
                if (text[i] == '|') break;
                HstN += text[i];
            }
            int indMfMd = text.IndexOf("MfMd");
            for (int i = indMfMd + 4; ; i++)
            {
                if (text[i] == '|') break;
                MfMd += text[i];
            }
            int indOpSy = text.IndexOf("OpSy");
            for (int i = indOpSy + 4; ; i++)
            {
                if (text[i] == '|') break;
                OSversion += text[i];
            }
            int indAdpI = text.IndexOf("AdpI");
            for (int i = indAdpI + 4; ; i++)
            {
                if (text[i] == '|') break;
                AdpI += text[i];
            }
            AdpI1 = AdpI.Split(',');
            int indIPvX = text.IndexOf("IPvX");
            for (int i = indIPvX + 4; ; i++)
            {
                if (text[i] == '|') break;
                IPvX += text[i];
            }
            IPv64 = IPvX.Split(',');
            int indHTTP1 = text.IndexOf("HTTP");
            int indHTTP2 = text.IndexOf("HTTP", indHTTP1 + 1);
            for (int i = 0; i < 2; i++)
            {
                data = "";
                if (i == 0) j = indHTTP1 + 4;
                else j = indHTTP2 + 4;
                while (text[j] != ',')
                {
                    HTTP[i].URL += text[j];
                    j++;
                }
                j++;
                while (text[j] != ',')
                {
                    data += text[j];
                    j++;
                }
                j++;
                HTTP[i].bytesReceived = Convert.ToInt32(data);
                data = "";
                while (text[j] != ',')
                {
                    data += text[j];
                    j++;
                }
                j++;
                HTTP[i].timeElapsed = Convert.ToInt32(data);
                while (text[j] != '|')
                {
                    HTTP[i].status += text[j];
                    j++;
                }
            }
            int indICMP1 = text.IndexOf("ICMP");
            int indICMP2 = text.IndexOf("ICMP", indICMP1 + 1);
            for (int i = 0; i < 2; i++)
            {
                data = "";
                if (i == 0) j = indICMP1 + 4;
                else j = indICMP2 + 4;
                while (text[j] != ',')
                {
                    ICMP[i].IP += text[j];
                    j++;
                }
                j++;
                while (text[j] != ',')
                {
                    ICMP[i].status += text[j];
                    j++;
                }
                j++;
                while (text[j] != ',')
                {
                    data += text[j];
                    j++;
                }
                j++;
                ICMP[i].bytes = Convert.ToInt16(data);
                data = "";
                while (text[j] != ',')
                {
                    data += text[j];
                    j++;
                }
                j++;
                ICMP[i].time = Convert.ToInt16(data);
                data = "";
                while (text[j] != ',')
                {
                    data += text[j];
                    j++;
                }
                j++;
                ICMP[i].maxTime = Convert.ToInt16(data);
                data = "";
                while (text[j] != '|')
                {
                    data += text[j];
                    j++;
                }
                j++;
                ICMP[i].jumps = Convert.ToInt16(data);
                data = "";
            }
            int indInEr = text.IndexOf("InEr");
            for (int i = indInEr + 4; i < indInEr + 23; i++)
                InErdt += text[i];
            int indUID = text.IndexOf("UID");
            for (int i = indUID + 3; ; i++)
            {
                if (text[i] == '|') break;
                user_uid += text[i];
            }
            j = indInEr + 24; data = "";
            for (int i = 0; i < 4; i++)
            {
                while (text[j] != ',' && text[j] != '|')
                {
                    data += text[j];
                    j++;
                }
                j++;
                //MessageBox.Show(data);
                InEr[i] = Convert.ToInt16(data);
                data = "";
            }
            int indEvEr = text.IndexOf("EvEr");
            for (int i = indEvEr + 4; i < indEvEr + 23; i++)
                EvErdt += text[i];
            j = indEvEr + 24; data = "";
            while (text[j] != '|')
            {
                data += text[j];
                j++;
            }
            EvErnum = Convert.ToInt16(data);
            //MessageBox.Show(directory + filename);
            Directory.CreateDirectory(newDirectory);
            File.Move(directory + "\\" + filename, newDirectory + filename);
            //myFile.MoveTo(newDirectory+filename);
            //MessageBox.Show(data);
        } //обработка данных из файла

        public void ChangeDateFormat(ref string date)
        {
            string day = date[0].ToString() + date[1].ToString();
            string month = date[3].ToString() + date[4].ToString();
            string year = date.Substring(6, 4);
            date = year + "-" + month + "-" + day + " " + date.Substring(11);
        }

        public void Clear()
        {
            DTsc = "";
            DTec = ""; //начало сбора данных
            HstN = ""; //название хоста
            AdpI = "";
            MfMd = ""; //проиводитель и модель ПК
            Manufacturer = "";
            Model = "";
            OSversion = ""; //данные ОС
            IPvX = "";
            InErdt = "";
            EvErdt = "";
            filename = "";
            user_uid = "";
            for (int i=0;i<2;i++)
            {
                ICMP[i].IP = "";
                HTTP[i].URL = "";
                HTTP[i].status = "";
                Thrp[i].datetime = "";
            }
            for (int i = 0; i < ThCount; i++)
            {
                Thrp[i].datetime = "";
            }
            filename = "";
        }
    }

    public class Settings
    {
        string settingspath = "settings.txt";

        public int qgr = 5; //кол-во скоростных групп
        public int qdy = 2; //кол-во серверов для измерения задержки

        public int[] a;
        public double[] p;
        public int[] b = new int[3];
        public int[] c;
        public int[] d = new int[2];

        public Settings()
        {

            a = new int[qgr];
            p = new double[qgr];
            c = new int[qdy];
            d = new int[2];

        }

        public void ReadSettings()
        {
            string[] strings = new string[17];
            strings = File.ReadAllLines(settingspath);
            for (int i = 0; i < 5; i++)
            {
                string data = "";
                int j = 3;
                while (strings[i + 2][j] != ';')
                {
                    data += strings[i + 2][j];
                    j++;
                }
                a[i] = Convert.ToInt16(data);
            }
            for (int i = 0; i < 3; i++)
            {
                string data = "";
                int j = 3;
                while (strings[i + 8][j] != ';')
                {
                    data += strings[i + 8][j];
                    j++;
                }
                b[i] = Convert.ToInt16(data);
            }
            for (int i = 0; i < 2; i++)
            {
                string data = "";
                int j = 3;
                while (strings[i + 12][j] != ';')
                {
                    data += strings[i + 12][j];
                    j++;
                }
                c[i] = Convert.ToInt16(data);
            }
            for (int i = 0; i < 2; i++)
            {
                string data = "";
                int j = 3;
                while (strings[i + 15][j] != ';' && strings[i + 15][j] != '.')
                {
                    data += strings[i + 15][j];
                    j++;
                }
                d[i] = Convert.ToInt16(data);
            }
        } //данные из файла настроек
    }

    public class ThrpClass
    {
        public string datetime;
        public double downspeed, upspeed;
        public int[] gr = new int[5];

        //public ThrpClass()
        //{
        //    date = "";
        //}
    }

    public class ICMPClass
    {
        public string IP;
        public double status;
        public int bytes;
        public int time;
        public int maxTime;
        public int jumps;
    }

    public class HTTPClass
    {
        public string URL;
        public int bytesReceived;
        public int timeElapsed;
        public string status;
    }
}
