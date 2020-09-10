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
    public partial class sifremi_unuttum : Form
    {
        public sifremi_unuttum()
        {
            InitializeComponent();
        }
        sifrele md5 = new sifrele();
        MySqlConnection baglan = new MySqlConnection(connection.con);
        MySqlCommand cmd;
        Form1 giris = new Form1();
        
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string tc,sifre;
            tc = textBox1.Text;
            sifre = md5.md5sifrele(textBox2.Text);
            cmd = new MySqlCommand("SELECT * FROM hasta WHERE tc='" + tc + "'", baglan);
            cmd.ExecuteNonQuery();
            int varmi = Convert.ToInt16(cmd.ExecuteScalar());
            if (varmi != 0)
            {
                cmd = new MySqlCommand("UPDATE hasta SET sifre='" + sifre + "'WHERE tc='" + tc + "'", baglan);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Şifrenizi Değiştirdiniz");
                this.Hide();
                giris.Show();
            }
            else
            {
                cmd = new MySqlCommand("SELECT * FROM doktorlar WHERE doktor_tc='" + tc + "'", baglan);
                cmd.ExecuteNonQuery();
                 varmi = Convert.ToInt16(cmd.ExecuteScalar());
                 if (varmi != 0)
                 {
                     cmd = new MySqlCommand("UPDATE doktorlar SET doktor_sifre='" + sifre + "'", baglan);
                     cmd.ExecuteNonQuery();
                     MessageBox.Show("Şifreniz Değiştirildi");
                     this.Hide();
                     giris.Show();
                 }
                 else
                 {
                     MessageBox.Show("Sistemde Böyle Bir KAYIT YOK Veya Bilgileriniz Doğru Değil");
                     textBox1.Text = "";
                     textBox2.Text = "";
                 }

            }
            
            baglan.Close();

        }
    }
}
