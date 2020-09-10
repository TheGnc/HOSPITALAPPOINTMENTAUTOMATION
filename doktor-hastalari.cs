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
    public partial class doktor_hastalari : Form
    {
        public doktor_hastalari()
        {
            InitializeComponent();
        }
        public int doktor_id;
        DataTable tablo = new DataTable();
        MySqlDataAdapter adp = new MySqlDataAdapter();
        MySqlCommand cmd;
        MySqlConnection baglan = new MySqlConnection(connection.con);
        public void hastalarimi_getir()
        {
            tablo.Clear();
            baglan.Open();
 cmd = new MySqlCommand("SELECT randevu.randevu_tarih,randevu.randevu_saati,hastane.hastane_adi,bolum.bolum_adi,hasta.ad,hasta.soyad  FROM randevu,hastane,hasta,bolum WHERE doktor_id='" + doktor_id + "' and hastane.hastane_id=randevu.hastane_id and bolum.bolum_id=randevu.bolum_id and hasta.hasta_id=randevu.hasta_id ", baglan);
            adp.SelectCommand = cmd;
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();

        }
        private void doktor_hastalari_Load(object sender, EventArgs e)
        {
            hastalarimi_getir();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            if (textBox2.Text != "")
            {
                tablo.Clear();
                baglan.Open();
                cmd = new MySqlCommand("SELECT randevu.randevu_tarih,randevu.randevu_saati,hastane.hastane_adi,bolum.bolum_adi,hasta.ad,hasta.soyad  FROM randevu,hastane,hasta,bolum WHERE hasta.ad LIKE '%" + textBox2.Text + "%'  and doktor_id='" + doktor_id + "' and hastane.hastane_id=randevu.hastane_id and bolum.bolum_id=randevu.bolum_id and hasta.hasta_id=randevu.hasta_id ", baglan);
                adp.SelectCommand = cmd;
                adp.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglan.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                tablo.Clear();
                baglan.Open();
                cmd = new MySqlCommand("SELECT randevu.randevu_tarih,randevu.randevu_saati,hastane.hastane_adi,bolum.bolum_adi,hasta.ad,hasta.soyad  FROM randevu,hastane,hasta,bolum WHERE hasta.soyad LIKE '%" + textBox3.Text + "%'  and doktor_id='" + doktor_id + "' and hastane.hastane_id=randevu.hastane_id and bolum.bolum_id=randevu.bolum_id and hasta.hasta_id=randevu.hasta_id ", baglan);
                adp.SelectCommand = cmd;
                adp.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglan.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
