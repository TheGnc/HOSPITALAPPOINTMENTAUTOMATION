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
    public partial class hasta_islemleri : Form
    {
        public hasta_islemleri()
        {
            InitializeComponent();
        }
        DataTable tablo = new DataTable();
        MySqlDataAdapter adp = new MySqlDataAdapter();
        MySqlCommand cmd = new MySqlCommand();
        public void hasta_listele()
        {
            tablo.Clear();
            MySqlConnection baglan = new MySqlConnection(connection.con);
            baglan.Open();
            cmd = new MySqlCommand("SELECT * FROM hasta", baglan);
            adp.SelectCommand = cmd;
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
        private void hasta_islemleri_Load(object sender, EventArgs e)
        {
            hasta_listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
      
            // LİSTELENEN VERİYE TIKLANDIGINDA GEREKLİ OLAN ALANLARIN OTOMATİK OLARAK DOLMASINI SAĞLAYACAKTIR 
            textBox11.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Text= dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            string cins;
          //  dateTimePicker1.Text =Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            cins = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            if (cins == "Kadin")
            {
                radioButton2.PerformClick();
            }
            else if (cins == "Erkek")
            {
                radioButton1.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // AŞAĞIDA SİLME İŞLEMİ KODLARI BULUNMAKTADIR 
            // BAĞLANTIYI AÇ
            MySqlConnection baglan = new MySqlConnection(connection.con);
            baglan.Open();
            int id;
            id = Convert.ToInt32(textBox11.Text);
            // GELEN TC YE GÖRE ÜYEYİ SİL 
            cmd = new MySqlCommand("DELETE FROM hasta WHERE hasta_id='" + id + "'", baglan);
            try
            {
                // KAYIT BAŞARILIYSA SİL
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarıyla Silindi");
                baglan.Close();
                hasta_listele();
          
            }
            catch (Exception hata)
            {
                // EĞER PROGRAM HATA YAKALARSA HATAYI GÖSTER 
                MessageBox.Show(hata.ToString());
            }
            // PROGRAMI KAPAT 

        }
        sifrele sek = new sifrele();
        private void button2_Click(object sender, EventArgs e)
        {
            // GÜNCELLEME BUTONU EYLEMLERİ GERÇEKLEŞMEKTEDİR.
            // BAĞLANTI AÇILIR
            MySqlConnection baglan = new MySqlConnection(connection.con);
            baglan.Open();
            // DEĞİŞKENLER TANIMLANIR VE ATANIR 
            string tc, ad, soyad, dogum_yeri, il, ilce, mail, telefon, adres, cinsiyet;
               
                int id = Convert.ToInt32(textBox11.Text);
                  tc = textBox1.Text;
                  ad = textBox3.Text;
                  soyad = textBox4.Text;
                  string[] d_t = new string[3];
                  string dogum_tarihi;
                  d_t = dateTimePicker1.Text.Split('.');
                  dogum_tarihi = d_t[2] + "-" + d_t[1] + "-" + d_t[0];

                  dogum_yeri = textBox5.Text;
                  il = textBox6.Text;
                  ilce = textBox10.Text;
                  mail = textBox7.Text;
                  telefon = textBox8.Text;
                  adres = textBox9.Text;
                     if (radioButton1.Checked == true)
                      {
                          cinsiyet = "Erkek";
                          cmd = new MySqlCommand(@"UPDATE hasta SET tc='" + tc + "',ad='" + ad + "',soyad='" + soyad + "',dogum_tarihi='" + dogum_tarihi + "',dogum_yeri='" + dogum_yeri + "',il='" + il + "',ilce='" + ilce + "',mail='" + mail + "',telefon='" + telefon + "',adres='" + adres + "',cinsiyet='" + cinsiyet + "'WHERE hasta_id=" + id + "", baglan);
                          cmd.ExecuteNonQuery();
                          MessageBox.Show("KAYIT BAŞARIYLA GÜNCELLENDİ");
                          baglan.Close();
                          hasta_listele();
                     }
                      else if (radioButton2.Checked == true)
                      {
                          cinsiyet = "Kadın";
                          cmd = new MySqlCommand(@"UPDATE hasta SET tc='" + tc + "',ad='" + ad + "',soyad='" + soyad + "',dogum_tarihi='" + dogum_tarihi + "',dogum_yeri='" + dogum_yeri + "',il='" + il + "',ilce='" + ilce + "',mail='" + mail + "',telefon='" + telefon + "',adres='" + adres + "',cinsiyet='" + cinsiyet + "'WHERE hasta_id=" + id + "", baglan);
                          cmd.ExecuteNonQuery();
                          MessageBox.Show("KAYIT BAŞARIYLA GÜNCELLENDİ");
                          baglan.Close();
                          hasta_listele();
                      }
                     else
                     {
                         MessageBox.Show("Hay Aksi ! Ters Giden Birşeyler var ");
                     }


        }
    }
}
