using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Project
{
    public partial class Form1 : Form
    {
 
        MySqlConnection connection = new MySqlConnection("Server = localhost;Database = projectdb; user=root;Pwd=");
        public Form1()
        {
            InitializeComponent();
        }

        private void Staj_Load(object sender, EventArgs e)
        {
            
            MySqlCommand command = new MySqlCommand("SELECT AdSoyad FROM kullanicilar", connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                adCOMBO.Items.Add(reader.GetString("AdSoyad"));
            }
            connection.Close();
            adCOMBO.SelectedIndex = 0;
        }

        private void adCOMBO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void girisBTN_Click(object sender, EventArgs e)
        {
            connection.Open();
            string selectedUsername = adCOMBO.SelectedItem.ToString();
            string password = parolaTB.Text;
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM kullanicilar WHERE AdSoyad=@username AND password=@password", connection);
            command.Parameters.AddWithValue("@username", selectedUsername);
            command.Parameters.AddWithValue("@password", password);
            int count = Convert.ToInt32(command.ExecuteScalar());
            if (count > 0)
            {
                MySqlCommand command2 = new MySqlCommand("SELECT Yetki FROM kullanicilar WHERE AdSoyad=@username", connection);
                command2.Parameters.AddWithValue("@username", selectedUsername);
                string userType = command2.ExecuteScalar().ToString();

                if (userType == "0")
                {
                    MessageBox.Show("Görevli Giriş Yaptı.");
                    Form2 form2 = new Form2();
                    this.Hide();
                    form2.Show();


                }
                else if (userType == "1")
                {
                    MessageBox.Show("Hoca Giriş Yaptı");
                    Form3 form3 = new Form3();
                    this.Hide();
                    form3.Show();
                }
                else
                {
                    MessageBox.Show("Bilinmeyen kullanıcı tipi.");
                }
            }
            else
            {
                MessageBox.Show("Giriş Başarısız");
            }
            connection.Close();
        }
    }
}
