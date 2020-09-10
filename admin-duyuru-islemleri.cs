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
using System.IO;

namespace mhrs_randevu_otomasyonu
{
    public partial class admin_duyuru_islemleri : Form
    {
        public admin_duyuru_islemleri()
        {
            InitializeComponent();
        }
        int aciklama_id = 0;
        string baslik, icerik;
        MySqlConnection baglan = new MySqlConnection(connection.con);
        MySqlCommand cmd;
        DataTable tablo = new DataTable();
        MySqlDataAdapter adp = new MySqlDataAdapter();
        public void duyuru_listele()
        {
            tablo.Clear();
            baglan.Open();
            cmd = new MySqlCommand("SELECT * FROM aciklamalar ", baglan);
            adp.SelectCommand = cmd;
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            aciklama_id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void admin_duyuru_islemleri_Load(object sender, EventArgs e)
        {
            duyuru_listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablo.Clear();
            string resim;
            baglan.Open();
            cmd = new MySqlCommand("SELECT * FROM aciklamalar WHERE aciklama_id=" + aciklama_id + "", baglan);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            resim = dr["resim"].ToString();
            dr.Close();
            File.Delete(@"C:\wamp\www\hastane\aciklama_resim\" + resim);
            MySqlCommand duyuru_sil = new MySqlCommand("DELETE FROM aciklamalar WHERE aciklama_id=" + aciklama_id + "", baglan);
            duyuru_sil.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Silindi");
            baglan.Close();
            duyuru_listele();
            temizle();
        }
        public void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            baslik = textBox1.Text;
            icerik = textBox2.Text;
            cmd = new MySqlCommand("UPDATE aciklamalar SET baslik='" + baslik + "',icerik='" + icerik + "'WHERE aciklama_id="+aciklama_id+"", baglan);
            int kontrol_et = Convert.ToInt16(cmd.ExecuteNonQuery());
            if (kontrol_et == 1)
            {
                MessageBox.Show("Başarıyla Güncellendi");
                baglan.Close();
            }
            duyuru_listele();
            temizle();
            
        }
    }
}
