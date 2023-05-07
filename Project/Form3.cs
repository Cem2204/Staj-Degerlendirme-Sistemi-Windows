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
    }
}
