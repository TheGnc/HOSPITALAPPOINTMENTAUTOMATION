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
    public partial class uye_doktorlar : Form
    {
        public uye_doktorlar()
        {
            InitializeComponent();
        }

        MySqlConnection baglan = new MySqlConnection(connection.con);
        MySqlCommand cmd;
        DataTable tablo = new DataTable();
        MySqlDataAdapter adp = new MySqlDataAdapter();
        int bolum_id;
        public void doktor_getir()
        {
            tablo.Clear();
            baglan.Open();
            cmd = new MySqlCommand("SELECT hastane.hastane_adi,bolum.bolum_adi,doktorlar.ad,doktorlar.soyad,doktorlar.cinsiyet FROM hastane,bolum,doktorlar WHERE doktorlar.bolum_id=bolum.bolum_id and doktorlar.hastane_id=hastane.hastane_id", baglan);
            adp.SelectCommand = cmd;
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;

            MySqlCommand bolum_sorgusu = new MySqlCommand("SELECT * FROM bolum ", baglan);
            MySqlDataReader dr = bolum_sorgusu.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["bolum_adi"].ToString());
            }
            dr.Close();
            baglan.Close();
        }
        private void uye_doktorlar_Load(object sender, EventArgs e)
        {
            doktor_getir();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            if (textBox1.Text != "")
            {
                tablo.Clear();
                baglan.Open();
                cmd = new MySqlCommand("SELECT hastane.hastane_adi,bolum.bolum_adi,doktorlar.ad,doktorlar.soyad,doktorlar.cinsiyet FROM hastane,bolum,doktorlar WHERE doktorlar.ad LIKE '" + textBox1.Text + "%' and doktorlar.bolum_id=bolum.bolum_id and doktorlar.hastane_id=hastane.hastane_id", baglan);
                adp.SelectCommand = cmd;
                adp.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglan.Close();
            }
                      
            else
            {
                doktor_getir();
            }
         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
            if (textBox2.Text != "")
            {
                tablo.Clear();
                baglan.Open();
                cmd = new MySqlCommand("SELECT hastane.hastane_adi,bolum.bolum_adi,doktorlar.ad,doktorlar.soyad,doktorlar.cinsiyet FROM hastane,bolum,doktorlar WHERE doktorlar.soyad LIKE '" + textBox2.Text + "%' and doktorlar.bolum_id=bolum.bolum_id and doktorlar.hastane_id=hastane.hastane_id", baglan);
                adp.SelectCommand = cmd;
                adp.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglan.Close();
            }
            else
            {
                doktor_getir();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            baglan.Open();
            MySqlCommand sorgu = new MySqlCommand("SELECT * FROM bolum WHERE bolum_adi='" + comboBox1.Text + "'", baglan);
            MySqlDataReader oku= sorgu.ExecuteReader();
            oku.Read();
            bolum_id = Convert.ToInt16(oku["bolum_id"].ToString());
            oku.Close();
            baglan.Close();
        }
    }
}
