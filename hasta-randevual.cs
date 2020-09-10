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
using System.Collections;

namespace mhrs_randevu_otomasyonu
{
    
    public partial class hasta_randevual : Form
    {
 
        public hasta_randevual()
        {
            InitializeComponent();
        }
        public int uye_id;
        int hastane_id, bolum_id, doktor_id;
     
        RadioButton uret = new RadioButton();
        MySqlCommand cmd;
        MySqlConnection baglan = new MySqlConnection(connection.con);
        MySqlDataReader dr;
        ArrayList dizim = new ArrayList();
        int randevu_alis;
        string[] tarih = new string[3];
        string randevu_tarihi;
        DateTime baslangic, bitis, ogle_ara_baslangic, ogle_ara_bitis;
        string a, b,c,d;
        DateTime xx, basla;
        public void hastane_listele()
        {
            baglan.Open();
            cmd = new MySqlCommand("SELECT * FROM hastane", baglan);
            dr = cmd.ExecuteReader();
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
            cmd = new MySqlCommand("SELECT * FROM hastane WHERE hastane_adi='" + comboBox1.Text + "'", baglan);
            dr = cmd.ExecuteReader();
            dr.Read();
            hastane_id = Convert.ToInt16(dr["hastane_id"]);
            dr.Close();
            baglan.Close();
            bolum_listele();
        }
        public void bolum_listele()
        {
            comboBox2.Items.Clear();
            baglan.Open();
             cmd= new MySqlCommand("SELECT * FROM bolum WHERE hastane_id=" + hastane_id + "", baglan);
             dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["bolum_adi"].ToString());
            }
            dr.Close();
            baglan.Close();
        }
        public void doktor_listele()
        {
            comboBox3.Items.Clear();
            baglan.Open();
            cmd = new MySqlCommand("SELECT * FROM doktorlar WHERE hastane_id=" + hastane_id + " and bolum_id=" + bolum_id + "", baglan);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["ad"].ToString());
            }
            dr.Close();
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // RANDEVU ARAMA KODLARI AŞAĞIDAKİ GİBİDİR
            listBox1.Items.Clear();
            baglan.Open();
            tarih = dateTimePicker1.Text.Split('.');
            randevu_tarihi = tarih[2] + "-" + tarih[1] + "-" + tarih[0];
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || dateTimePicker1.Text == "")
            {
                MessageBox.Show("Tüm Alanlar Dolu olmak zorunda");

            }
            else
            {   // DOKTOR İZİNLİMİ DİYE BAK İZİNLİ İSE BURASINI GERÇEKLEŞTİR
                cmd = new MySqlCommand("SELECT * FROM izinler WHERE doktor_id=" + doktor_id + " AND izin_baslangic <='" + randevu_tarihi + "' AND izin_bitis>='" + randevu_tarihi + "'", baglan);
                int varmi = Convert.ToInt16(cmd.ExecuteScalar());
                if (varmi != 0)
                {
                    MessageBox.Show("Doktor İzinli");

                }
                else
                {
                    // LİSTELENEN SAATLERİN KODLARI
                    // EĞER DOKTOR İZİNLİ DEĞİL İSE BELİRTİLEN ÇALIŞMA SAATLERİNİ ÇEK
                    cmd = new MySqlCommand("SELECT * FROM calisma_saatleri WHERE bolum_id=" + bolum_id + "", baglan);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    // ÇEKTİĞİNİZ SAATLERİ DİZİYE ATAYIN
                    baslangic = Convert.ToDateTime(dr["calisma_baslangic"].ToString());
                    bitis = Convert.ToDateTime(dr["calisma_bitis"].ToString());
                    dateTimePicker2.Value = baslangic;
                    dateTimePicker3.Value = bitis;
                    ogle_ara_baslangic = Convert.ToDateTime(dr["ogle_ara_baslangic"].ToString());
                     ogle_ara_bitis = Convert.ToDateTime(dr["ogle_ara_bitis"].ToString());
                     randevu_alis = Convert.ToInt16(dr["randevu_alis"].ToString());
                     dr.Close();
                     TimeSpan fark = bitis - baslangic;
                     int aralik=Convert.ToInt16(fark.TotalMinutes/randevu_alis);
                      basla = baslangic;
                     dizim.Add(basla);
                      xx = basla;
                      c = xx.ToString();
                      if (c.Length == 18)
                      {
                          d = c.Substring(10, 5);
                   
                      }
                      else
                      {
                          d = c.Substring(11, 5);
                        
                      }
 MySqlCommand cmd4 = new MySqlCommand(@"SELECT * FROM randevu WHERE hastane_id=" + hastane_id + " AND bolum_id=" + bolum_id + " AND doktor_id=" + doktor_id + " AND randevu_tarih='" + randevu_tarihi + "' AND randevu_saati='" + d + "'", baglan);
                      varmi = Convert.ToInt16(cmd4.ExecuteScalar());
                      if (varmi == 0)
                      {
                          listBox1.Items.Add(d);
                      }
                     for (int i = 0; i < aralik; i++)
                     {
                         xx = basla.AddMinutes(randevu_alis * (i + 1));
                        
                      if (xx < ogle_ara_baslangic || xx > ogle_ara_bitis)
                         {
                             a = xx.ToString();
                            
                             if (a.Length == 18)
                             {
                               b = a.Substring(10, 5);
                             }
                             else
                             {
                                 b = a.Substring(11, 5);
                             }
                            
                     MySqlCommand cmd2 = new MySqlCommand(@"SELECT * FROM randevu 
                    WHERE hastane_id=" + hastane_id + 
                   " AND bolum_id=" + bolum_id + 
                   " AND doktor_id=" + doktor_id + 
                   " AND randevu_tarih='" + randevu_tarihi +
                   "' AND randevu_saati='" +b + "'", baglan);
                             varmi = Convert.ToInt16(cmd2.ExecuteScalar());
                             if (varmi == 0)
                             {
                                 listBox1.Items.Add(b);
                             }
                         }
                     }

                }

                
            }
           
            baglan.Close();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            // YUKARIDAKİ KODLARDAN AYRI OLARAK HASTA SEÇTİĞİ SAATİ SEÇİP RANDEVU AL BUTTONUNA TIKLAYARAK RANDEVU ALMA İŞLEMİ GERÇEKLEŞECEKTİR.
            baglan.Open();
            MySqlCommand  cmd3 = new MySqlCommand(@"insert into randevu(hastane_id,bolum_id,doktor_id,hasta_id,randevu_tarih,randevu_saati)
            values("+hastane_id+","+bolum_id+","+doktor_id+","+uye_id+",'"+randevu_tarihi+"','"+listBox1.SelectedItem+"')",baglan);
            cmd3.ExecuteNonQuery();
            MessageBox.Show("Randevu Başarıyla Alındı");
            baglan.Close();
        }
        private void hasta_randevual_Load(object sender, EventArgs e)
        {
            
            hastane_listele();
            bolum_listele();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan.Open();
            cmd = new MySqlCommand("SELECT * FROM bolum WHERE bolum_adi='" + comboBox2.Text + "'", baglan);
            dr = cmd.ExecuteReader();
            dr.Read();
            bolum_id = Convert.ToInt16(dr["bolum_id"]);
            dr.Close();
            baglan.Close();
            doktor_listele();
            
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan.Open();
            cmd = new MySqlCommand("SELECT * FROM doktorlar WHERE ad='" + comboBox3.Text + "'", baglan);
            dr = cmd.ExecuteReader();
            dr.Read();
            doktor_id = Convert.ToInt16(dr["doktor_id"]);
            dr.Close();
            baglan.Close();
        }       
    }
}
