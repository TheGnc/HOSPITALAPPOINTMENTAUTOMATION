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
    public partial class calisma_saatleri : Form
    {
        public calisma_saatleri()
        {
            InitializeComponent();
        }
        int bolum_id;
        int i;
        int varmi;
        MySqlConnection baglan = new MySqlConnection(connection.con);
        MySqlCommand cmd;
        MySqlDataAdapter adp = new MySqlDataAdapter();
        DataTable tablo = new DataTable();
        public void saat()
        {
            for (i = 5; i <= 55; i += 5)
            {
                comboBox2.Items.Add(i);
            }
        }
        public void calisma_saat_listele()
        {
            tablo.Clear();
            baglan.Open();
          
           
            MySqlCommand poliklinik_saatleri = new MySqlCommand("SELECT bolum_adi,calisma_baslangic,calisma_bitis,ogle_ara_baslangic,ogle_ara_bitis,randevu_alis,calisma_id FROM calisma_saatleri,bolum WHERE calisma_saatleri.bolum_id=bolum.bolum_id", baglan);
            adp.SelectCommand = poliklinik_saatleri;
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
       
            cmd = new MySqlCommand("SELECT * FROM bolum", baglan);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["bolum_adi"].ToString());
            }
            dr.Close();
            baglan.Close();
        }
        private void calisma_saatleri_Load(object sender, EventArgs e)
        {
            calisma_saat_listele();
            saat();
        }
  
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            baglan.Open();
            string bolum_adi = comboBox1.Text;
            MySqlCommand sorgu = new MySqlCommand("SELECT * FROM bolum WHERE bolum_adi ='" + bolum_adi + "'", baglan);
            MySqlDataReader dr = sorgu.ExecuteReader();
            dr.Read();
            bolum_id = Convert.ToInt16(dr["bolum_id"].ToString());
            dr.Close();
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablo.Clear();
            baglan.Open();
            cmd = new MySqlCommand("SELECT * FROM calisma_saatleri WHERE bolum_id=" + bolum_id + " and calisma_baslangic='" + textBox1.Text + "' and calisma_bitis='"+textBox2.Text+"'", baglan);
            varmi = Convert.ToInt16(cmd.ExecuteScalar());
            if (varmi != 0)
            {
                MessageBox.Show("Böyle Bir Kayıt var");
            }
            else
            {
            cmd = new MySqlCommand("İNSERT İNTO calisma_saatleri(bolum_id,calisma_baslangic,calisma_bitis,ogle_ara_baslangic,ogle_ara_bitis,randevu_alis) values('" + bolum_id + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox2.Text + "')", baglan);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Tamamlandı");
             baglan.Close();
             calisma_saat_listele();
             saat();
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(textBox5.Text);
            baglan.Open();
            cmd = new MySqlCommand("DELETE FROM calisma_saatleri WHERE calisma_id=" + id + "", baglan);
            cmd.ExecuteNonQuery();
            baglan.Close();
            calisma_saat_listele();
            saat();
           
        }

                          private void button3_Click(object sender, EventArgs e)
                                 {
            
                                         baglan.Open();
                                                     int id = Convert.ToInt16(textBox5.Text);
                                                             string baslangic = textBox1.Text;
                                                     string bitis = textBox2.Text;
                                                 string o_baslangic = textBox3.Text;
                                             string o_bitis = textBox4.Text;
             cmd = new MySqlCommand("UPDATE calisma_saatleri SET bolum_id=" + bolum_id + ",calisma_baslangic='" + baslangic + "',calisma_bitis='" + bitis + "',ogle_ara_baslangic='" + o_baslangic + "',ogle_ara_bitis='" + o_bitis + "',randevu_alis=" + comboBox2.Text + " WHERE calisma_id=" + id + "", baglan);
                                             cmd.ExecuteNonQuery();
                                             MessageBox.Show("Güncellendi");
                                            baglan.Close();
                                            comboBox1.Items.Clear();
                                             calisma_saat_listele();
           // bolum_listele();
     

                                  }
        
    }
}
