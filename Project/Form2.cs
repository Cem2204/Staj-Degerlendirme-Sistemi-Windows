using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
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
        private void verileriOku(int kayiti, string sKodu, int x, int y = 0)
        {
            string ogrbqueryString = "";
            string stabqueryString = "";

            if (x == 0)
            {
                ogrbqueryString = $"SELECT ID, TCNO, Ad, Soyad, OGRNO, Sinif, TELNO, EMail FROM ogrencibilgileri WHERE ID = {kayiti}";
                stabqueryString = $"SELECT StajYeri, StajBaslangic, StajBaslangicOnay, StajBitis, StajBitisOnay, StajEvrakTeslim, ZstajYazi, ENDYazi, DilekceVerildiMi, KabulGetirdiMi, Mustehaklik, KimlikFotokopi, StajDegerlendirmeF, StajRap, Aciklama FROM stajbilgileri WHERE ogrenci_ID = {kayiti} AND StajType = {y}";

            }
            else if (x == 1)
            {
                ogrbqueryString = $"SELECT ID,TCNO, Ad, Soyad, OGRNO, Sinif, TELNO, EMail FROM ogrencibilgileri ORDER BY ID DESC LIMIT 1";
                stabqueryString = $"SELECT StajYeri, StajBaslangic, StajBaslangicOnay, StajBitis, StajBitisOnay, StajEvrakTeslim, ZstajYazi, ENDYazi, DilekceVerildiMi, KabulGetirdiMi, Mustehaklik, KimlikFotokopi, StajDegerlendirmeF, StajRap, Aciklama FROM stajbilgileri WHERE StajType = {y} ORDER BY ogrenci_ID DESC LIMIT 1";
            }
            else if (x == 2)
            {
                ogrbqueryString = $"SELECT ID, TCNO, Ad, Soyad, OGRNO, Sinif, TELNO, EMail FROM ogrencibilgileri ORDER BY ID LIMIT 1";
                stabqueryString = $"SELECT StajYeri, StajBaslangic, StajBaslangicOnay, StajBitis, StajBitisOnay, StajEvrakTeslim, ZstajYazi, ENDYazi, DilekceVerildiMi, KabulGetirdiMi, Mustehaklik, KimlikFotokopi, StajDegerlendirmeF, StajRap, Aciklama FROM stajbilgileri WHERE StajType = {y} ORDER BY ogrenci_ID LIMIT 1";

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
                sinifTB.Text = sinif.ToString();

            }

            reader.Close();
            MySqlDataReader reader2 = stacommand.ExecuteReader();
            if (reader2.HasRows)
            {
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
            }
            else
            {
                stajYerTB.Text = "";
                dateTimePicker1.Value = new DateTime(2023, 1, 1);
                dateTimePicker2.Value = new DateTime(2023, 1, 1);
                stajStartCB.Checked = false;
                stajBitisCB.Checked = false;
                stajTeslimCB.Checked = false;
                zStajYTB.Text = "";
                endTB.Text = "";
                bDilekceCBOX.Checked = false;
                kabulCBOX.Checked = false;
                mustehakCBOX.Checked = false;
                kfotokCBOX.Checked = false;
                dFormCBOX.Checked = false;
                sRaporCBOX.Checked = false;
                aciklamaRTB.Text = "";
                
            }

            reader2.Close();

            connection.Close();
        }
        private void kayitSil(int kayiti, int sTipi)
        {
            string stabqueryString = $"DELETE FROM stajbilgileri WHERE ogrenci_ID = {kayiti} AND StajType = {sTipi}";
            MySqlCommand stacommand = new MySqlCommand(stabqueryString, connection);
            connection.Open();
            stacommand.ExecuteNonQuery();
            connection.Close();
            DialogResult result = MessageBox.Show("Öğrenciyi tamamen silmek ister misiniz?", "Sil", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string ogrbqueryString = $"DELETE FROM ogrencibilgileri WHERE ID = {kayiti}";

                MySqlCommand ogrcommand = new MySqlCommand(ogrbqueryString, connection);

                connection.Open();
                ogrcommand.ExecuteNonQuery();

                connection.Close();
            }
            else if (result == DialogResult.No)
            {


            }

        }

        private void kaydet()
        {
            int satir;
            connection.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.CommandText = "INSERT INTO `ogrencibilgileri` (`ID`, `TCNO`, `Ad`, `Soyad`, `OGRNO`, `Sinif`, `TELNO`, `EMail`) VALUES (@Kayitno, @TC, @Ad, @Soyad, @OGRNO, @Sinif, @TelNo, @Mail)";
            komut.Parameters.AddWithValue("@Kayitno", Convert.ToInt32(kayitNoTB.Text));
            komut.Parameters.AddWithValue("@TC", Convert.ToInt64(tcTB.Text));
            komut.Parameters.AddWithValue("@Ad", adTB.Text);
            komut.Parameters.AddWithValue("@Soyad", soyadTB.Text);
            komut.Parameters.AddWithValue("@OGRNO", Convert.ToInt32(ogrNoTB.Text));
            komut.Parameters.AddWithValue("@Sinif", Convert.ToInt32(sinifTB.Text));
            komut.Parameters.AddWithValue("@TelNo", Convert.ToInt64(telNOTB.Text));
            komut.Parameters.AddWithValue("@Mail", emailTB.Text);
            komut.Connection = connection;
            satir = komut.ExecuteNonQuery();
            MessageBox.Show(satir + " öğrenci eklendi");
            komut.Dispose();
            connection.Close();
            connection.Open();
            MySqlCommand komut2 = new MySqlCommand();
            komut2.CommandText = "INSERT INTO `stajbilgileri` (`ogrenci_ID`, `staj_ID`, `StajType`, `StajYeri`, `StajBaslangic`, `StajBaslangicOnay`, `StajBitis`, `StajBitisOnay`, `StajEvrakTeslim`, `ZStajYazi`, `ENDYazi`, `DilekceVerildiMi`, `KabulGetirdiMi`, `Mustehaklik`, `KimlikFotokopi`, `StajDegerlendirmeF`, `StajRap`, `Aciklama`)" +
                " VALUES (@KayitNo, NULL, @StajTipi,@StajYeri, @BaslangicT, @BasladiMi, @BitisT, @BittiMi, @TeslimEdildiMi, @Zyazi,@ENDYazi, @DilekceVerildiMi, @KabulGetirdiMi, @Mustehaklik, @KimlikFotokopi, @StajDegerlendirmeF, @StajRap, @Aciklama)";
            komut2.Parameters.AddWithValue("@Kayitno", Convert.ToInt32(kayitNoTB.Text));
            komut2.Parameters.AddWithValue("@StajTipi", stajKODCB.SelectedIndex);
            komut2.Parameters.AddWithValue("@StajYeri", stajYerTB.Text);
            komut2.Parameters.AddWithValue("@BaslangicT", dateTimePicker1.Value);
            if (stajStartCB.Checked) { komut2.Parameters.AddWithValue("@BasladiMi", 1); }
            else { komut2.Parameters.AddWithValue("BasladiMi", 0); }


            komut2.Parameters.AddWithValue("@BitisT", dateTimePicker2.Value);
            if (stajBitisCB.Checked) { komut2.Parameters.AddWithValue("@BittiMi", 1); }
            else { komut2.Parameters.AddWithValue("BittiMi", 0); }
            if (stajTeslimCB.Checked) { komut2.Parameters.AddWithValue("@TeslimEdildiMi", 1); }
            else { komut2.Parameters.AddWithValue("@TeslimEdildiMi", 0); }
            komut2.Parameters.AddWithValue("@Zyazi", Convert.ToInt32(zStajYTB.Text));
            komut2.Parameters.AddWithValue("@ENDYazi", Convert.ToInt32(endTB.Text));
            if (bDilekceCBOX.Checked) { komut2.Parameters.AddWithValue("@DilekceVerildiMi", 1); }
            else { komut2.Parameters.AddWithValue("@DilekceVerildiMi", 0); }
            if (kabulCBOX.Checked) { komut2.Parameters.AddWithValue("@KabulGetirdiMi", 1); }
            else { komut2.Parameters.AddWithValue("@@KabulGetirdiMi", 0); }
            if (mustehakCBOX.Checked) { komut2.Parameters.AddWithValue("@Mustehaklik", 1); }
            else { komut2.Parameters.AddWithValue("@Mustehaklik", 0); }
            if (kfotokCBOX.Checked) { komut2.Parameters.AddWithValue("@KimlikFotokopi", 1); }
            else { komut2.Parameters.AddWithValue("@KimlikFotokopi", 0); }
            if (dFormCBOX.Checked) { komut2.Parameters.AddWithValue("@StajDegerlendirmeF", 1); }
            else { komut2.Parameters.AddWithValue("@StajDegerlendirmeF", 0); }
            if (sRaporCBOX.Checked) { komut2.Parameters.AddWithValue("@StajRap", 1); }
            else { komut2.Parameters.AddWithValue("@StajRap", 0); }
            komut2.Parameters.AddWithValue("@Aciklama", aciklamaRTB.Text);
            komut2.Connection = connection;
            komut2.ExecuteNonQuery();
            komut2.Dispose();

            connection.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int x = 0;
            int i = Convert.ToInt32(kayitNoTB.Text);
            string sKodu = "END300";
            verileriOku(i, sKodu, x);

        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y;
            if (stajKODCB.SelectedIndex == 0)
            {
                y = 0;

            }
            else
            {
                y = 1;
            }

            string sKodu = stajKODCB.Text;
            int kayiti = Convert.ToInt32(kayitNoTB.Text);
            verileriOku(kayiti, sKodu, x, y);
        }

        private void stajTeslimCB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nextBTN_Click(object sender, EventArgs e)
        {
            connection.Open();
            string sayimquery = "SELECT COUNT(ID) FROM ogrencibilgileri";
            MySqlCommand symcomand = new MySqlCommand(sayimquery, connection);
            int sonsayi = Convert.ToInt32(symcomand.ExecuteScalar());
            connection.Close();
            int x = 0;
            string sKodu = stajKODCB.Text;
            int kayiti = Convert.ToInt32(kayitNoTB.Text);
            kayiti = kayiti + 1;
            if (kayiti > sonsayi) { kayiti = sonsayi; }
            kayitNoTB.Text = kayiti.ToString();
            verileriOku(kayiti, sKodu, x);

        }

        private void backBTN_Click(object sender, EventArgs e)
        {
            int x = 0;
            string sKodu = stajKODCB.Text;
            int kayiti = Convert.ToInt32(kayitNoTB.Text);
            kayiti = kayiti - 1;
            if (kayiti < 1) { kayiti = 1; }
            verileriOku(kayiti, sKodu, x);
            kayitNoTB.Text = kayiti.ToString();
        }

        private void firstSelectBTN_Click(object sender, EventArgs e)
        {
            int x = 2;
            string sKodu = stajKODCB.Text;
            int kayiti = Convert.ToInt32(kayitNoTB.Text);
            kayiti = 1;
            verileriOku(kayiti, sKodu, x);
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

        private void addBTN_Click(object sender, EventArgs e)
        {

            tcTB.Text = "";
            adTB.Text = "";
            soyadTB.Text = "";
            ogrNoTB.Text = "";
            telNOTB.Text = "";
            emailTB.Text = "";
            sinifTB.Text = "";
            stajKODCB.SelectedIndex = 0;
            stajYerTB.Text = "";
            dateTimePicker1.Value = new DateTime(2023, 1, 1);
            dateTimePicker2.Value = new DateTime(2023, 1, 1);
            stajStartCB.Checked = false;
            stajBitisCB.Checked = false;
            stajTeslimCB.Checked = false;
            zStajYTB.Text = "";
            endTB.Text = "";
            bDilekceCBOX.Checked = false;
            kabulCBOX.Checked = false;
            mustehakCBOX.Checked = false;
            kfotokCBOX.Checked = false;
            dFormCBOX.Checked = false;
            sRaporCBOX.Checked = false;
            aciklamaRTB.Text = "";
            connection.Open();
            string sayimquery = "SELECT COUNT(ID) FROM ogrencibilgileri";
            MySqlCommand symcomand = new MySqlCommand(sayimquery, connection);
            int sonsayi = Convert.ToInt32(symcomand.ExecuteScalar());
            connection.Close();
            kayitNoTB.Text = (sonsayi + 1).ToString();

        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            kaydet();
        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(kayitNoTB.Text);
            int sTipi = stajKODCB.SelectedIndex;
            DialogResult result = MessageBox.Show("Kaydı silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) { kayitSil(i, sTipi); }
            else { };
        }

        
    }
}


        

