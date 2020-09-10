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
    public partial class hastane_isleri : Form
    {
        public hastane_isleri()
        {
            InitializeComponent();
        }
        MySqlCommand cmd;
        MySqlConnection baglan = new MySqlConnection(connection.con);
        int varmi;
        private void button1_Click(object sender, EventArgs e)
        {
            
            baglan.Open();
            string il,ilce,ad;
            il=comboBox1.Text;
            ilce=comboBox2.Text;
            ad=textBox1.Text;
            if (il != "" && ilce != "" && ad != "")
            {
                cmd = new MySqlCommand("SELECT * FROM hastane WHERE il='" + il + "' and ilce='" + ilce + "' and hastane_adi='" + ad + "'", baglan);
                varmi = Convert.ToInt16(cmd.ExecuteScalar());
                if (varmi != 0)
                {
                    MessageBox.Show("Böyle Bir Hastane Mevcut");
                }
                else
                {
                    cmd = new MySqlCommand("INSERT INTO hastane(il,ilce,hastane_adi) values('" + il + "','" + ilce + "','" + ad + "')", baglan);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("HASTANE BAŞARIYLA KAYIT EDİLDİ");
                    hastane_listele();
                }
            }
            else
            {
                MessageBox.Show("Alanları Doldurunuz");
            }
            baglan.Close();

        }
        public void hastane_listele()
        {
            DataTable tablo = new DataTable();

            MySqlDataAdapter adp = new MySqlDataAdapter();
            tablo.Clear();
     
            MySqlConnection baglan = new MySqlConnection(connection.con);
            baglan.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM hastane", baglan);
            label4.Visible = false;
            textBox2.Visible = false;
       
            adp.SelectCommand = cmd;
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
        private void hastane_isleri_Load(object sender, EventArgs e)
        {
            hastane_listele();
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection(connection.con);
            baglan.Open();
            int id=Convert.ToInt32(textBox2.Text);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM hastane WHERE hastane_id=" + id + "", baglan);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarıyla Silindi");
                baglan.Close();
                hastane_listele();
                
            }
            catch (Exception warning)
            {
                MessageBox.Show(warning.ToString());
            }
   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string il, ilce, ad;
            int hastane_id = Convert.ToInt16(textBox2.Text);
            il = comboBox1.Text;
            ilce = comboBox2.Text;
            ad = textBox1.Text;
            cmd = new MySqlCommand("UPDATE hastane SET il='" + il + "',ilce='" + ilce + "',hastane_adi='" + ad + "' WHERE hastane_id=" + hastane_id + "", baglan);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Güncellendi");
            baglan.Close();
            hastane_listele();
        }
    }
}
