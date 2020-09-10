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
    public partial class poliklinikler : Form
    {
        public poliklinikler()
        {
            InitializeComponent();
        }
        int hastane_id;
        MySqlConnection baglan = new MySqlConnection(connection.con);
       
        public void poliklinik_listele()
        {
            
            baglan.Open();
            MySqlCommand hastane_sorgusu = new MySqlCommand("SELECT DISTINCT hastane_adi FROM hastane", baglan);
            MySqlDataReader dr = hastane_sorgusu.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["hastane_adi"].ToString());
            }
            dr.Close();
            baglan.Close();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan.Open();
            MySqlCommand sorgu = new MySqlCommand("SELECT * FROM hastane WHERE hastane_adi='" + comboBox1.Text + "'", baglan);
            MySqlDataReader oku = sorgu.ExecuteReader();
            oku.Read();
            hastane_id = Convert.ToInt16(oku["hastane_id"].ToString());
            oku.Close();
            baglan.Close();
        
        }
        DataTable tablo = new DataTable();
        MySqlCommand cmd;
        MySqlDataAdapter adp = new MySqlDataAdapter();
        public void poliklinik_yenile()
        {
            tablo.Clear();
            baglan.Open();
            cmd = new MySqlCommand("SELECT hastane.hastane_adi,bolum.bolum_adi,bolum.bolum_id FROM bolum,hastane WHERE bolum.hastane_id=hastane.hastane_id", baglan);
            adp.SelectCommand = cmd;
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
        private void poliklinikler_Load(object sender, EventArgs e)
        {
            poliklinik_yenile();
            poliklinik_listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // POLİKLİNİK EKLEME SAYFASI
            string poliklinik_ad = textBox1.Text;
            baglan.Open();
            cmd = new MySqlCommand("SELECT * FROM bolum WHERE bolum_adi='" + poliklinik_ad + "'", baglan);
             int varmi = Convert.ToInt16(cmd.ExecuteScalar());
             if (varmi != 0)
           {
               MessageBox.Show("Böyle bir poliklinik var");
           }
           else
           {
               cmd = new MySqlCommand("İNSERT İNTO bolum(hastane_id,bolum_adi) values('" + hastane_id + "','" + poliklinik_ad + "')", baglan);
               cmd.ExecuteNonQuery();
               MessageBox.Show("Poliklinik Eklendi");
         
               baglan.Close();
               comboBox1.Text = "";
               textBox1.Text = "";
               poliklinik_yenile();
            
           }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            int bolum_id = Convert.ToInt16(textBox2.Text);
            cmd = new MySqlCommand("DELETE FROM bolum WHERE bolum_id=" + bolum_id + "", baglan);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silindi");
            baglan.Close();
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            textBox1.Text = "";
            poliklinik_listele();
            poliklinik_yenile();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            int id = Convert.ToInt16(textBox2.Text);
            string bolum_adi = textBox1.Text;
            cmd = new MySqlCommand("UPDATE bolum SET bolum_adi='" + bolum_adi + "',hastane_id=" + hastane_id + " WHERE bolum_id=" + id + "", baglan);
            cmd.ExecuteNonQuery();
            baglan.Close();
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            textBox1.Text = "";
            poliklinik_listele();
            poliklinik_yenile();
           
           
        }
    }
}
