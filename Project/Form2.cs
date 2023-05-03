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
        private void verileriOku(int kayiti, string sKodu)
        {
            string ogrbqueryString = $"SELECT TCNO, Ad, Soyad, OGRNO, Sinif, TELNO, EMail FROM ogrencibilgileri WHERE ID = {kayiti}";
            string stabqueryString = $"SELECT StajYeri, StajBaslangic, StajBaslangicOnay, StajBitis, StajBitisOnay, StajEvrakTeslim, ZstajYazi, ENDYazi, DilekceVerildiMi, KabulGetirdiMi, Mustehaklik, KimlikFotokopi, StajDegerlendirmeF, StajRap, Aciklama FROM stajbilgileri WHERE ogrenci_ID = {kayiti}";
            MySqlCommand ogrcommand = new MySqlCommand(ogrbqueryString, connection);
            MySqlCommand stacommand = new MySqlCommand(stabqueryString, connection);
            
            connection.Open();
            MySqlDataReader reader = ogrcommand.ExecuteReader();

            while (reader.Read())
            {
                BigInteger TC = reader.GetInt64(0);
                string ad = reader.GetString(1);
                string soyad = reader.GetString(2);
                BigInteger OGRNO = reader.GetInt64(3);
                int sinif = reader.GetInt32(4);
                string eposta = reader.GetString(5);
                tcTB.Text = TC.ToString();
                adTB.Text = ad;
                soyadTB.Text = soyad;
                ogrNoTB.Text = OGRNO.ToString();
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
                if (stajBaslangicOnay == 1) { stajStartCB.Checked = true; };
                if (stajBitisOnay == 1) { stajBitisCB.Checked = true; };
                if (stajEvrakTeslim == 1) { stajTeslimCB.Checked = true; };
                zStajYTB.Text = ZstajYazi.ToString();
                endTB.Text = ENDYazi.ToString();
                if (DilekceVerildiMi == 1) { bDilekceCBOX.Checked = true; };
                if (KabulGetirildiMi == 1) { kabulCBOX.Checked = true; };
                if (Mustehaklik == 1) { mustehakCBOX.Checked = true; };
                if (KimlikFotokopi == 1) { kfotokCBOX.Checked = true; };
                if (StajDegerlendirmeF == 1) { dFormCBOX.Checked = true; };
                if (StajRap == 1) { sRaporCBOX.Checked = true; };
                aciklamaRTB.Text = Aciklama.ToString();

            }
            reader2.Close();
            connection.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(kayitNoTB.Text);
            string sKodu = "END300";
            verileriOku(i,sKodu);

        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
            string sKodu = stajKODCB.Text;
            int kayiti = Convert.ToInt32(kayitNoTB.Text);
            verileriOku(kayiti, sKodu);
        }

        private void stajTeslimCB_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
