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
    public partial class admin_hasta_kayit : Form
    {
        public admin_hasta_kayit()
        {
            InitializeComponent();
        }
        int varmi;
        MySqlCommand cmd = new MySqlCommand();
        MySqlConnection baglan = new MySqlConnection(connection.con);
        sifrele sek = new sifrele();
        private void button1_Click(object sender, EventArgs e)
        {
           // HASTA KAYIT KODLARI
            baglan.Open();
            string tc, sifre, ad, soyad, dogum_yeri, il, ilce, mail, telefon, adres;
            string cinsiyet;
            string[] d_t= new string[3];
            string dogum_tarihi;
            d_t = dateTimePicker1.Text.Split('.');
            dogum_tarihi = d_t[2] + "-" + d_t[1] + "-" + d_t[0];

            tc = textBox1.Text;
            sifre = sek.md5sifrele(textBox2.Text);
            ad = textBox3.Text;
            soyad = textBox4.Text;
     
            dogum_yeri = textBox5.Text;

            il = textBox6.Text;
            ilce = textBox10.Text;
            mail = textBox7.Text;
            telefon = textBox8.Text;
            adres = textBox9.Text;
            cmd = new MySqlCommand("SELECT * FROM hasta WHERE tc='" + tc + "'", baglan);
            varmi = Convert.ToInt16(cmd.ExecuteScalar());
            if (varmi != 0)
            {
                MessageBox.Show("Böyle bir hasta mevcut");
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    cinsiyet = "Erkek";
                    cmd = new MySqlCommand(@"INSERT INTO hasta(tc,sifre,ad,soyad,dogum_tarihi,dogum_yeri,cinsiyet,il,ilce,mail,telefon,adres) values('" + tc + "','" + sifre + "','" + ad + "','" + soyad + "','" + dogum_tarihi + "','" + dogum_yeri + "','" + cinsiyet + "','" + il + "','" + ilce + "','" + mail + "','" + telefon + "','" + adres + "')", baglan);
                }
                else if (radioButton2.Checked == true)
                {
                    cinsiyet = "Kadın";
                    cmd = new MySqlCommand(@"INSERT INTO hasta(tc,sifre,ad,soyad,dogum_tarihi,dogum_yeri,cinsiyet,il,ilce,mail,telefon,adres) values('" + tc + "','" + sifre + "','" + ad + "','" + soyad + "','" + dogum_tarihi + "','" + dogum_yeri + "','" + cinsiyet + "','" + il + "','" + ilce + "','" + mail + "','" + telefon + "','" + adres + "')", baglan);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("BAŞARIYLA KAYIT EDİLDİ");
                }
                catch (Exception warning)
                {

                    MessageBox.Show(warning.ToString());
                }
            }
            baglan.Close();
        }

        private void admin_hasta_kayit_Load(object sender, EventArgs e)
        {

        }
    }
}
