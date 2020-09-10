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
    public partial class hakkimizda : Form
    {
        public hakkimizda()
        {
            InitializeComponent();
        }
        MySqlConnection baglan = new MySqlConnection(connection.con);
        private void hakkimizda_Load(object sender, EventArgs e)
        {
            // İD Yİ GÖNDERMEK İÇİN TEXTBOX'U FORM ACILDIGINDA GİZLEDİK
            textBox3.Visible = false;
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
                textBox3.Text = oku["ayarlar_id"].ToString();
            }
            // VT KAPANDI
            baglan.Close();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            int id;
            string baslik, icerik;
            id = Convert.ToInt32(textBox3.Text);
            baslik = textBox1.Text;
            icerik = textBox2.Text;
            MySqlCommand cmd = new MySqlCommand("UPDATE ayarlar SET baslik='"+baslik+"',icerik='"+icerik+"'WHERE ayarlar_id="+id+"", baglan);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("HAKKIMIZDA YAYIMLANDI");
                hakkimizda hakkimizda = new hakkimizda();
                this.Hide();
                hakkimizda.Show();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }


        }
    }
}
