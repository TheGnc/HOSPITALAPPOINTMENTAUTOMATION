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
    public partial class admin_doktor_isleri : Form
    {
        public admin_doktor_isleri()
        {
            InitializeComponent();
        }
        int hastane_id;
        int bolum_id;
        MySqlConnection baglan = new MySqlConnection(connection.con);
        MySqlCommand cmd;
        DataTable tablo = new DataTable();
        MySqlDataAdapter adp = new MySqlDataAdapter();
        public void hastane_listele()
        {

            baglan.Open();
            MySqlCommand hastane_sorgusu = new MySqlCommand("SELECT * FROM hastane", baglan);
            MySqlDataReader dr = hastane_sorgusu.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["hastane_adi"].ToString());
            }
            dr.Close();
            baglan.Close();

        }
        public void bolum_listele()
        {
            comboBox2.Items.Clear();
            baglan.Open();
            cmd = new MySqlCommand("SELECT * FROM bolum WHERE hastane_id=" + hastane_id + "", baglan);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["bolum_adi"].ToString());
            }
            dr.Close();
            baglan.Close();
        }
        public void doktor_listele()
        {
            baglan.Open();
            cmd = new MySqlCommand("SELECT doktor_id,doktor_tc,bolum_adi,hastane_adi,ad,soyad,cinsiyet,yetki,resim FROM hastane,bolum,doktorlar WHERE hastane.hastane_id=doktorlar.hastane_id AND bolum.bolum_id=doktorlar.bolum_id", baglan);
            adp.SelectCommand = cmd;
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();

        }
        public void temizle()
        {
            tablo.Clear();
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void admin_doktor_isleri_Load(object sender, EventArgs e)
        {
            doktor_listele();
            hastane_listele();
            bolum_listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox2.Text);
            string resim;
            baglan.Open();
            cmd = new MySqlCommand("SELECT * FROM doktorlar WHERE doktor_id=" + id + "", baglan);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            resim = dr["resim"].ToString();
            dr.Close();
            File.Delete(@"C:\wamp\www\hastane\doktor_resim\" + resim);
            cmd = new MySqlCommand("DELETE FROM doktorlar WHERE doktor_id=" + id + "", baglan);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Doktor Silindi");
            baglan.Close();
            temizle();
            doktor_listele();
            hastane_listele();
            bolum_listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        //comboBox3.Text=dataGridView1.CurrentRow.Cells[]
            textBox3.Text=dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text=dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan.Open();
            cmd = new MySqlCommand("SELECT * FROM hastane WHERE hastane_adi='" + comboBox1.Text + "'", baglan);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            hastane_id = Convert.ToInt16(dr["hastane_id"].ToString());
            dr.Close();
            baglan.Close();
            bolum_listele();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan.Open();
            cmd = new MySqlCommand("SELECT * FROM bolum WHERE bolum_adi='" + comboBox2.Text + "'", baglan);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            bolum_id = Convert.ToInt16(dr["bolum_id"].ToString());
            dr.Close();
            baglan.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tablo.Clear();
            baglan.Open();
            int doktor_id = Convert.ToInt16(textBox2.Text);
            string doktor_tc = textBox1.Text;
            string doktor_ad = textBox3.Text;
            string doktor_soyad = textBox4.Text;
            string doktor_cins = comboBox4.Text;
            int yetki = comboBox3.SelectedIndex + 1;
            cmd = new MySqlCommand("UPDATE doktorlar SET doktor_tc='" + doktor_tc + "',bolum_id=" + bolum_id + ",hastane_id=" + hastane_id + ",ad='" + doktor_ad + "',soyad='" + doktor_soyad + "',cinsiyet='" + doktor_cins + "',yetki=" + yetki + " WHERE doktor_id="+doktor_id+"", baglan);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Güncellendi");
            baglan.Close();
            temizle();
            doktor_listele();
            hastane_listele();
            bolum_listele();
            
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
