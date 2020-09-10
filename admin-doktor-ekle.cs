using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace mhrs_randevu_otomasyonu
{
    public partial class admin_doktor_ekle : Form
    {
        public admin_doktor_ekle()
        {
            InitializeComponent();
        }
        int hastane_id;
        int bolum_id;
        MySqlConnection baglan = new MySqlConnection(connection.con);
        MySqlCommand cmd;
        DataTable tablo = new DataTable();
        MySqlDataAdapter adp = new MySqlDataAdapter();
        public void temizle()
        {
            // FORMDAKİ BÜTÜN ALANLARI TEMİZLEMEYE YARAR
            tablo.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
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
            cmd = new MySqlCommand("SELECT * FROM bolum WHERE hastane_id=" +hastane_id + "", baglan);
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
            cmd = new MySqlCommand("SELECT doktor_id,doktor_tc,doktor_sifre,bolum_adi,hastane_adi,ad,soyad,cinsiyet,yetki,resim FROM hastane,bolum,doktorlar WHERE hastane.hastane_id=doktorlar.hastane_id AND bolum.bolum_id=doktorlar.bolum_id", baglan);
            adp.SelectCommand = cmd;
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();

        }
        private void admin_doktor_ekle_Load(object sender, EventArgs e)
        {
            doktor_listele();
            hastane_listele();
            bolum_listele();

        }
        sifrele sek = new sifrele();
        string yol, resimad;
        private void button2_Click(object sender, EventArgs e)
        {
          
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                yol = openFileDialog1.FileName;
                resimad = openFileDialog1.SafeFileName;
                label10.Text = resimad;
                pictureBox1.Image = Image.FromFile(yol);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            int panel_secim = comboBox3.SelectedIndex + 1;
            string tc, sifre, ad, soyad,cinsiyet;
            tc = textBox1.Text;
            sifre = sek.md5sifrele(textBox2.Text);
            ad = textBox3.Text;
            soyad = textBox4.Text;
            cinsiyet = comboBox4.Text;
            if (tc == "" || sifre == "" || ad == "" || soyad == "" || cinsiyet == "")
            {
                MessageBox.Show("Boş Alanları Lütfen Doldurunuz");
            }
            else
            {
                cmd = new MySqlCommand("SELECT * FROM doktorlar WHERE doktor_tc='" + tc + "'", baglan);
                cmd.ExecuteNonQuery();
                int varmi = Convert.ToInt16(cmd.ExecuteScalar());
                if (varmi != 0)
                {
                    MessageBox.Show("Böyle Bir Doktor Mevcut");
                    temizle();
                }
                else
                {
                    cmd = new MySqlCommand("insert into doktorlar(doktor_tc,doktor_sifre,bolum_id,hastane_id,ad,soyad,cinsiyet,yetki,resim) values('" + tc + "','" + sifre + "','" + bolum_id + "','" + hastane_id + "','" + ad + "','" + soyad + "','" + cinsiyet + "'," + panel_secim + ",'" + resimad + "')", baglan);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doktor Eklendi");
                    pictureBox1.Image.Save(@"C:\wamp\www\hastane\doktor_resim\" + resimad);
                    baglan.Close();
                    temizle();
                    doktor_listele();
                    hastane_listele();
                    bolum_listele();
                }
            }
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

       
    }
}
