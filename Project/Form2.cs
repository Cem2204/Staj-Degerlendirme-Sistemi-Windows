using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form2 : Form
    {
        MySqlConnection connection = new MySqlConnection("Server = localhost;Database = projectdb; user=root;Pwd=");
        
        public Form2()
        {
            InitializeComponent();
            
        }
        private void verileriOku(int kayiti, string sKodu, int x)
        {
            string ogrbqueryString = "";
            string stabqueryString = "";
            if (x == 0) {
                ogrbqueryString = $"SELECT ID, TCNO, Ad, Soyad, OGRNO, Sinif, TELNO, EMail FROM ogrencibilgileri WHERE ID = {kayiti}";
                stabqueryString = $"SELECT StajYeri, StajBaslangic, StajBaslangicOnay, StajBitis, StajBitisOnay, StajEvrakTeslim, ZstajYazi, ENDYazi, DilekceVerildiMi, KabulGetirdiMi, Mustehaklik, KimlikFotokopi, StajDegerlendirmeF, StajRap, Aciklama FROM stajbilgileri WHERE ogrenci_ID = {kayiti}";
            }
            else if(x == 1)
            {
                ogrbqueryString = $"SELECT ID,TCNO, Ad, Soyad, OGRNO, Sinif, TELNO, EMail FROM ogrencibilgileri ORDER BY ID DESC LIMIT 1";
                stabqueryString = $"SELECT StajYeri, StajBaslangic, StajBaslangicOnay, StajBitis, StajBitisOnay, StajEvrakTeslim, ZstajYazi, ENDYazi, DilekceVerildiMi, KabulGetirdiMi, Mustehaklik, KimlikFotokopi, StajDegerlendirmeF, StajRap, Aciklama FROM stajbilgileri ORDER BY ogrenci_ID DESC LIMIT 1";
            }
            else if (x == 2)
            {
                ogrbqueryString = $"SELECT ID, TCNO, Ad, Soyad, OGRNO, Sinif, TELNO, EMail FROM ogrencibilgileri ORDER BY ID LIMIT 1";
                stabqueryString = $"SELECT StajYeri, StajBaslangic, StajBaslangicOnay, StajBitis, StajBitisOnay, StajEvrakTeslim, ZstajYazi, ENDYazi, DilekceVerildiMi, KabulGetirdiMi, Mustehaklik, KimlikFotokopi, StajDegerlendirmeF, StajRap, Aciklama FROM stajbilgileri ORDER BY ogrenci_ID LIMIT 1";

            }
            MySqlCommand ogrcommand = new MySqlCommand(ogrbqueryString, connection);
            MySqlCommand stacommand = new MySqlCommand(stabqueryString, connection);
            
            connection.Open();
            MySqlDataReader reader = ogrcommand.ExecuteReader();

            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                BigInteger TC = reader.GetInt64(1);
                string ad = reader.GetString(2);
                string soyad = reader.GetString(3);
                BigInteger OGRNO = reader.GetInt64(4);
                int sinif = reader.GetInt32(5);
                BigInteger TelNo = reader.GetInt64(6);
                string eposta = reader.GetString(7);
                kayitNoTB.Text = ID.ToString();
                tcTB.Text = TC.ToString();
                adTB.Text = ad;
                soyadTB.Text = soyad;
                ogrNoTB.Text = OGRNO.ToString();
                telNOTB.Text = TelNo.ToString();
                emailTB.Text = eposta;

            }

            reader.Close();
            MySqlDataReader reader2 = stacommand.ExecuteReader();

            while (reader2.Read())
            {
                string stajYeri = reader2.GetString(0);
                DateTime stajBaslangic = reader2.GetDateTime(1);
                int stajBaslangicOnay = reader2.GetInt32(2);
                DateTime stajBitis = reader2.GetDateTime(3);
                int stajBitisOnay = reader2.GetInt32(4);
                int stajEvrakTeslim = reader2.GetInt32(5);
                int ZstajYazi = reader2.GetInt32(6);
                int ENDYazi = reader2.GetInt32(7);
                int DilekceVerildiMi = reader2.GetInt32(8);
                int KabulGetirildiMi = reader2.GetInt32(9);
                int Mustehaklik = reader2.GetInt32(10);
                int KimlikFotokopi = reader2.GetInt32(11);
                int StajDegerlendirmeF = reader2.GetInt32(12);
                int StajRap = reader2.GetInt32(13);
                string Aciklama = reader2.GetString(14);

                stajYerTB.Text = stajYeri;
                dateTimePicker1.Value = stajBaslangic;
                dateTimePicker2.Value = stajBitis;
                if (stajBaslangicOnay == 1) { stajStartCB.Checked = true; } else { stajStartCB.Checked = false; };
                if (stajBitisOnay == 1) { stajBitisCB.Checked = true; } else { stajBitisCB.Checked = false; };
                if (stajEvrakTeslim == 1) { stajTeslimCB.Checked = true; } else { stajTeslimCB.Checked = false; };
                zStajYTB.Text = ZstajYazi.ToString();
                endTB.Text = ENDYazi.ToString();
                if (DilekceVerildiMi == 1) { bDilekceCBOX.Checked = true; } else { bDilekceCBOX.Checked = false; };
                if (KabulGetirildiMi == 1) { kabulCBOX.Checked = true; } else { kabulCBOX.Checked = false; };
                if (Mustehaklik == 1) { mustehakCBOX.Checked = true; } else { mustehakCBOX.Checked = false; };
                if (KimlikFotokopi == 1) { kfotokCBOX.Checked = true; } else { kfotokCBOX.Checked = false; };
                if (StajDegerlendirmeF == 1) { dFormCBOX.Checked = true; } else { dFormCBOX.Checked = false; };
                if (StajRap == 1) { sRaporCBOX.Checked = true; } else { sRaporCBOX.Checked = false; }
                aciklamaRTB.Text = Aciklama.ToString();

            }
            reader2.Close();
            connection.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int x = 0;
            int i = Convert.ToInt32(kayitNoTB.Text);
            string sKodu = "END300";
            verileriOku(i,sKodu,x);

        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
            int x = 0;
            string sKodu = stajKODCB.Text;
            int kayiti = Convert.ToInt32(kayitNoTB.Text);
            verileriOku(kayiti, sKodu,x);
        }

        private void stajTeslimCB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nextBTN_Click(object sender, EventArgs e)
        {
            int x = 0;
            string sKodu = stajKODCB.Text;
            int kayiti = Convert.ToInt32(kayitNoTB.Text);
            kayiti = kayiti + 1;
            verileriOku(kayiti, sKodu,x);
            kayitNoTB.Text = kayiti.ToString();
        }

        private void backBTN_Click(object sender, EventArgs e)
        {
            int x = 0;
            string sKodu = stajKODCB.Text;
            int kayiti = Convert.ToInt32(kayitNoTB.Text);
            kayiti = kayiti - 1;
            verileriOku(kayiti, sKodu,x);
            kayitNoTB.Text = kayiti.ToString();
        }

        private void firstSelectBTN_Click(object sender, EventArgs e)
        {
            int x = 2;
            string sKodu = stajKODCB.Text;
            int kayiti = Convert.ToInt32(kayitNoTB.Text);
            kayiti =  1;
            verileriOku(kayiti, sKodu,x);
            kayitNoTB.Text = kayiti.ToString();
        }

        private void endBTN_Click(object sender, EventArgs e)
        {
            connection.Open();
            string sayimquery = "SELECT COUNT(ID) FROM ogrencibilgileri";
            MySqlCommand symcomand = new MySqlCommand(sayimquery, connection);
            int sonsayi = Convert.ToInt32(symcomand.ExecuteScalar());
            connection.Close();
            int x = 1;
            string sKodu = stajKODCB.Text;
            int kayiti = Convert.ToInt32(kayitNoTB.Text);
            kayiti = sonsayi;
            verileriOku(kayiti, sKodu, x);
            kayitNoTB.Text = kayiti.ToString();
        }
    }
}
