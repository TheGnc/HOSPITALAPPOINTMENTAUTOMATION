using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace mhrs_randevu_otomasyonu
{
    public partial class uye_hakkimizda : Form
    {
        public uye_hakkimizda()
        {
            InitializeComponent();
        }
        MySqlConnection baglan = new MySqlConnection(connection.con);
        private void uye_hakkimizda_Load(object sender, EventArgs e)
        {
            // VERİTABANI BAGLANTISI SAGLANDI
            baglan.Open();
            // VERİTABANINDAN BİLGİLER ÇEKİLDİ
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM ayarlar", baglan);
            MySqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                // VERİLER AKTARILDI
                textBox1.Text = oku["baslik"].ToString();
                textBox2.Text = oku["icerik"].ToString();

 
            }
            // VT KAPANDI
            baglan.Close();  
        }
    }
}
