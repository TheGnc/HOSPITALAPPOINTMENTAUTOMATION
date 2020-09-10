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
    public partial class doktor_bilgileri : Form
    {
        public doktor_bilgileri()
        {
            InitializeComponent();
        }
        MySqlCommand cmd;
        MySqlConnection baglan = new MySqlConnection(connection.con);
        public int doktor_id;
        public void doktor_bilgilerini_getir()
        {
            baglan.Open();
            cmd = new MySqlCommand("SELECT * FROM doktorlar WHERE doktor_id='"+doktor_id+"' ", baglan);
            MySqlDataReader oku = cmd.ExecuteReader();
            oku.Read();
            textBox1.Text = oku["doktor_tc"].ToString();
            textBox3.Text = oku["ad"].ToString();
            textBox4.Text = oku["soyad"].ToString();
            baglan.Close();
        }
        private void doktor_bilgileri_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            doktor_bilgilerini_getir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            cmd = new MySqlCommand("UPDATE doktorlar SET doktor_tc='" + textBox1.Text + "',soyad='" + textBox4.Text + "',ad='" + textBox3.Text + "'WHERE doktor_id='" + doktor_id + "'", baglan);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Güncellendi");
            baglan.Close();
        }
    }
}
