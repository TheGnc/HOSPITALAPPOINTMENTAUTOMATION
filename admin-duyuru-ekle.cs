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
    public partial class admin_duyuru_ekle : Form
    {
        public admin_duyuru_ekle()
        {
            InitializeComponent();
        }
        MySqlConnection baglan = new MySqlConnection(connection.con);
        DataTable tablo = new DataTable();
        MySqlCommand cmd;
        MySqlDataAdapter adp = new MySqlDataAdapter();
        int aciklama_id = 0;
        public void duyurularigetir()
        {
            tablo.Clear();
            baglan.Open();
            cmd = new MySqlCommand("SELECT baslik,icerik,aciklama_id FROM aciklamalar", baglan);
            adp.SelectCommand = cmd;
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
        private void admin_duyuru_ekle_Load(object sender, EventArgs e)
        {
            duyurularigetir();
        }
        string yol, resim_ad;
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                yol = openFileDialog1.FileName;
                resim_ad = openFileDialog1.SafeFileName;
                label4.Text = resim_ad;
                pictureBox1.Image = Image.FromFile(yol);
            }
          
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string baslik,icerik;
            baslik=textBox1.Text;
            icerik=textBox2.Text;
            cmd = new MySqlCommand("insert into aciklamalar(baslik,icerik,resim) values('" + baslik + "','" + icerik + "','" + resim_ad + "')", baglan);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Açıklama Başarıyla Kayıt Edildi");
            baglan.Close();
            duyurularigetir();
            textBox1.Text = "";
            textBox2.Text="";
            pictureBox1.Image.Save(@"C:\wamp\www\hastane\aciklama_resim\" + resim_ad);
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            aciklama_id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[2].Value.ToString());
        }
    }
}
