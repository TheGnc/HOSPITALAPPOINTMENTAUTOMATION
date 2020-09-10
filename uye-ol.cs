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
using System.Security.Cryptography;

namespace mhrs_randevu_otomasyonu
{
    public partial class uye_ol : Form
    {
        public uye_ol()
        {
            InitializeComponent();
        }
        MySqlCommand cmd = new MySqlCommand();
        sifrele sek = new sifrele();
        private void button1_Click(object sender, EventArgs e)
        {
            // VERİTABANI İLE BAĞLANTI GERÇEKLEŞTİRİLİR
            MySqlConnection baglan = new MySqlConnection(connection.con);
            baglan.Open();
            // DEĞİŞKENLER TANIMLANIR 
            string tc, sifre, ad, soyad, dogum_yeri, il, ilce, mail, telefon, adres;
            string cinsiyet;
            string[] d_t = new string[3];
            string dogum_tarihi;
            d_t = dateTimePicker1.Text.Split('.');
            dogum_tarihi = d_t[2] + "-" + d_t[1] + "-" + d_t[0];
            // DEĞİŞKENLER PROGRAMDAN ÇEKİLİR 
                    tc = textBox1.Text;
                    sifre = sek.md5sifrele(textBox2.Text);
                    ad = textBox3.Text;
                    soyad=textBox4.Text;
                    dogum_yeri = textBox5.Text;
                    il = textBox6.Text;
                    ilce=textBox10.Text;
                    mail = textBox7.Text;
                    telefon = textBox8.Text;
                    adres = textBox9.Text;
                    cmd = new MySqlCommand("SELECT * FROM hasta WHERE tc='" + tc + "'", baglan);
                    int varmi = Convert.ToInt16(cmd.ExecuteScalar());
                    if (varmi != 0)
                    {
                            MessageBox.Show("BÖYLE BİR KAYIT VAR");
                    }
                        else
                        {
                            // CİNSİYET SEÇİMİNE GÖRE 2 AYRI EKLEME GERÇEKLEŞTİRİLİR
 if (radioButton1.Checked == true)
  {
 cinsiyet = "Erkek";
 cmd = new MySqlCommand(@"İNSERT İNTO hasta(tc,sifre,ad,soyad,dogum_tarihi,dogum_yeri,cinsiyet,il,ilce,mail,telefon,adres) values('" + tc + "','" + sifre + "','" + ad + "','" + soyad + "','" + dogum_tarihi + "','" + dogum_yeri + "','" + cinsiyet + "','" + il + "','" + ilce + "','" + mail + "','" + telefon + "','" + adres + "')", baglan);
 }
else if (radioButton2.Checked == true)
 {
   cinsiyet = "Kadın";
   cmd = new MySqlCommand(@"İNSERT İNTO hasta(tc,sifre,ad,soyad,dogum_tarihi,dogum_yeri,cinsiyet,il,ilce,mail,telefon,adres) values('" + tc + "','" + sifre + "','" + ad + "','" + soyad + "','" + dogum_tarihi + "','" + dogum_yeri + "','" + cinsiyet + "','" + il + "','" + ilce + "','" + mail + "','" + telefon + "','" + adres + "')", baglan);
   }
                            else if (radioButton1.Checked == false || radioButton1.Checked == false)
                            {
                                MessageBox.Show("Cinsiyetinizi Belirtiniz");
                            }
                            else
                            {
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("BAŞARIYLA KAYIT OLUNDU");
                                Form1 giris = new Form1();
                                this.Hide();
                                giris.Show();
                            }
                        }
            // BAGLANTI KAPATILIR
            baglan.Close();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textBoxa girilecek karakter sayısını 11 ile sınırladık
          
        }

        private void uye_ol_Load(object sender, EventArgs e)
        {

        }
    }
}
