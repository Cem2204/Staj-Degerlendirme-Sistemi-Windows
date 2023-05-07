using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project
{
    public partial class Form3 : Form
    {
        MySqlConnection connection = new MySqlConnection("Server = localhost;Database = projectdb; user=root;Pwd=");
        public Form3()
        {
            InitializeComponent();
        }

        
        private void listele()
        {
            connection.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("Select * From ogrencibilgileri ORDER BY ID", connection);
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            adapter.Dispose();
            connection.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
           listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nameTB.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            surnameTB.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            nameTB.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            surnameTB.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            ogrIDTB.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            int ogrIDF = Convert.ToInt32(ogrIDTB.Text);
            puanlarigor(ogrIDF, stajKODCB.SelectedIndex);

        }
        private void nameTB_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = $"Ad LIKE '%{nameTB.Text}%'";

            dataGridView1.DataSource = bs;
        }
        private void surnameTB_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = $"Soyad LIKE '%{surnameTB.Text}%'";

            dataGridView1.DataSource = bs;
        }
       
        private void puanlarigor(int ogrID, int StajT)
        {
            string myquery = "";
            if(StajT == 0)
            {
                myquery = $"SELECT isyeri_degerlendirme, SBY, soru1, soru2, soru3, soru4, soru5, soru6, soru7, soru8, soru9, soru10, soru11, soru12, soru13, soru14, soru15, soru16, soru17, soru18, soru19, BasariliMi FROM end300staj WHERE ogrenci_ID = {ogrID}";
            }
            else
            {
                myquery = $"SELECT isyeri_degerlendirme, SBY, soru1, soru2, soru3, soru4, soru5, soru6, soru7, soru8, soru9, soru10, soru11, soru12, soru13, soru14, soru15, soru16, soru17, soru18, soru19, BasariliMi FROM end400staj WHERE ogrenci_ID = {ogrID}";

            }
            MySqlCommand ogrcommand = new MySqlCommand(myquery, connection);
            connection.Open();
            MySqlDataReader reader = ogrcommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    puanLBL.Text = "Toplam Puan";
                    comboBox21.SelectedIndex = reader.GetInt32(0);
                    comboBox22.SelectedIndex = reader.GetInt32(1);
                    comboBox1.SelectedIndex = reader.GetInt32(2);
                    comboBox2.SelectedIndex = reader.GetInt32(3);
                    comboBox3.SelectedIndex = reader.GetInt32(4);
                    comboBox4.SelectedIndex = reader.GetInt32(5);
                    comboBox5.SelectedIndex = reader.GetInt32(6);
                    comboBox6.SelectedIndex = reader.GetInt32(7);
                    comboBox7.SelectedIndex = reader.GetInt32(8);
                    comboBox8.SelectedIndex = reader.GetInt32(9);
                    comboBox9.SelectedIndex = reader.GetInt32(10);
                    comboBox10.SelectedIndex = reader.GetInt32(11);
                    comboBox11.SelectedIndex = reader.GetInt32(12);
                    comboBox12.SelectedIndex = reader.GetInt32(13);
                    comboBox13.SelectedIndex = reader.GetInt32(14);
                    comboBox14.SelectedIndex = reader.GetInt32(15);
                    comboBox15.SelectedIndex = reader.GetInt32(16);
                    comboBox16.SelectedIndex = reader.GetInt32(17);
                    comboBox17.SelectedIndex = reader.GetInt32(18);
                    comboBox18.SelectedIndex = reader.GetInt32(19);
                    comboBox19.SelectedIndex = reader.GetInt32(20);
                    comboBox20.SelectedIndex = reader.GetInt32(21);
                    int x = 0;
                    for (int i = 1; i <= 22; i++)
                    {
                        System.Windows.Forms.ComboBox comboBox = Controls.Find("comboBox" + i, true).FirstOrDefault() as System.Windows.Forms.ComboBox;
                        if (comboBox != null)
                        {
                            x += comboBox.SelectedIndex;
                        }
                    }
                    
                    puanLBL.Text = "Puan: " + x.ToString();
                    if(x > 50)
                    {
                        comboBox20.SelectedIndex =0;
                    }
                    else { comboBox20.SelectedIndex = 1; }
                    

                }
            }
            else
            {
                comboBox21.SelectedIndex =0;
                comboBox22.SelectedIndex =0;
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                comboBox4.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
                comboBox6.SelectedIndex = 0;
                comboBox7.SelectedIndex = 0;
                comboBox8.SelectedIndex = 0;
                comboBox9.SelectedIndex = 0;
                comboBox10.SelectedIndex =0;
                comboBox11.SelectedIndex =0;
                comboBox12.SelectedIndex =0;
                comboBox13.SelectedIndex =0;
                comboBox14.SelectedIndex =0;
                comboBox15.SelectedIndex =0;
                comboBox16.SelectedIndex =0;
                comboBox17.SelectedIndex =0;
                comboBox18.SelectedIndex =0;
                comboBox19.SelectedIndex =0;
                comboBox20.SelectedIndex =0;
            }
            reader.Close();
            connection.Close();
        }

        private void KaydetBTN_Click(object sender, EventArgs e)
        {
            
            connection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand();
            if (stajKODCB.SelectedIndex == 0)
            {
                mySqlCommand.CommandText = "INSERT INTO `end300staj` (`ogrenci_ID`, `isyeri_degerlendirme`, `SBY`, `soru1`, `soru2`, `soru3`, `soru4`, `soru5`, `soru6`, `soru7`, `soru8`, `soru9`, `soru10`, `soru11`, `soru12`, `soru13`, `soru14`, `soru15`, `soru16`, `soru17`, `soru18`, `soru19`, `BasariliMi`) VALUES (@ogrenci_ID,@isyeriD,@SBY,@soru1,@soru2,@soru3,@soru4,@soru5,@soru6,@soru7,@soru8,@soru9,@soru10,@soru11,@soru12,@soru13,@soru14,@soru15,@soru16,@soru17,@soru18,@soru19,@BasariliMi);";
            }
            else
            {
                mySqlCommand.CommandText = "INSERT INTO `end400staj` (`ogrenci_ID`, `isyeri_degerlendirme`, `SBY`, `soru1`, `soru2`, `soru3`, `soru4`, `soru5`, `soru6`, `soru7`, `soru8`, `soru9`, `soru10`, `soru11`, `soru12`, `soru13`, `soru14`, `soru15`, `soru16`, `soru17`, `soru18`, `soru19`, `BasariliMi`) VALUES (@ogrenci_ID,@isyeriD,@SBY,@soru1,@soru2,@soru3,@soru4,@soru5,@soru6,@soru7,@soru8,@soru9,@soru10,@soru11,@soru12,@soru13,@soru14,@soru15,@soru16,@soru17,@soru18,@soru19,@BasariliMi);";
            }
            mySqlCommand.Parameters.AddWithValue("@ogrenci_ID", Convert.ToInt32(ogrIDTB.Text));
            mySqlCommand.Parameters.AddWithValue("@isyeriD", comboBox21.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@SBY", comboBox22.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru1",comboBox1.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru2", comboBox2.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru3", comboBox3.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru4", comboBox4.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru5", comboBox5.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru6", comboBox6.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru7", comboBox7.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru8", comboBox8.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru9", comboBox9.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru10", comboBox10.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru11", comboBox11.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru12", comboBox12.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru13", comboBox13.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru14", comboBox14.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru15", comboBox15.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru16", comboBox16.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru17", comboBox17.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru18", comboBox18.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@soru19", comboBox19.SelectedIndex);
            mySqlCommand.Parameters.AddWithValue("@BasariliMi", comboBox20.SelectedIndex);
            mySqlCommand.Connection = connection;
            mySqlCommand.ExecuteNonQuery();
            mySqlCommand.Dispose();
            connection.Close();
        }

        private void degerlendirmeFormBTN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bölümün sitesinden Değerlendirme Formuna ulaşabilirsiniz.","Form",MessageBoxButtons.OKCancel);
        }
    }
}
