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

namespace mhrs_randevu_otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlCommand cmd;
        int uye_id;
        sifrele sek = new sifrele();
        private void button1_Click(object sender, EventArgs e)
        {
            // BAĞLANTI AÇILIR VE DEĞİŞKENLER ÇEKİLİR 
            MySqlConnection baglan = new MySqlConnection(connection.con);
            baglan.Open();
            string k_adi, sifre;
            k_adi = textBox1.Text;
            sifre = sek.md5sifrele(textBox2.Text);
            if (k_adi == "" || sifre == "")
            {
                MessageBox.Show("Alanları Boş Bırakma");
            }
            else
            {

                // ADMİNLERİ KARŞILAŞTIRAN SORGU CÜMLECİGİ
                cmd = new MySqlCommand("SELECT * FROM yonetim where yonetici_adi='" + k_adi + "'and yonetici_sifre='" + sifre + "'", baglan);
                int varmi = Convert.ToInt32(cmd.ExecuteScalar());
                if (varmi != 0)
                {
                    // ADMİN GİRİŞ YAPTIYSA YÖNLENDİRMEYİ GERÇEKLEŞTİR 


                    MySqlDataReader oku = cmd.ExecuteReader();
                    oku.Read();
                    int admin_id = Convert.ToInt16(oku["yonetici_id"]);
                    oku.Close();

                    admin_panel admin_panel = new admin_panel();
                    admin_panel.admin = admin_id;
                
                    this.Hide();
                    admin_panel.Show();
                }
                else
                {

                    string yetki = "1";
                  //  string yetki2 = "Evet";
                    cmd = new MySqlCommand("SELECT * FROM doktorlar WHERE doktor_tc='" + k_adi + "'and doktor_sifre='" + sifre + "'and yetki='"+yetki+"'", baglan);
                    varmi = Convert.ToInt16(cmd.ExecuteScalar());
                    if (varmi != 0)
                    {
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                        int doktor_id = Convert.ToInt16(dr["doktor_id"]);
                        dr.Close();
                        doktor_paneli dr_panel = new doktor_paneli();
                        dr_panel.doktor_id = doktor_id;
                        this.Hide();
                        dr_panel.Show();
                    }
                    else
                    {
                        cmd = new MySqlCommand("SELECT * FROM hasta WHERE tc='" + k_adi + "'and sifre='" + sifre + "'", baglan);
                        varmi = Convert.ToInt16(cmd.ExecuteScalar());
                        if (varmi != 0)
                        {

                            MySqlDataReader dr = cmd.ExecuteReader();
                            dr.Read();
                             uye_id = Convert.ToInt16(dr["hasta_id"]);
                            uye_paneli uye_panel = new uye_paneli();
                            uye_panel.uye_id = uye_id;
                            this.Hide();
                            uye_panel.Show();
                        }
                        else
                        {
                            MessageBox.Show("Sistemde Kayıtlı Değilsiniz");
                        }
                    }
                }
            }
            baglan.Close();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            uye_ol uye_ol = new uye_ol();
            this.Hide();
            uye_ol.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifremi_unuttum sifremi_yenile = new sifremi_unuttum();
            this.Hide();
            sifremi_yenile.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
