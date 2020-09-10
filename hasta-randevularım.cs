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
    public partial class hasta_randevularım : Form
    {
        public hasta_randevularım()
        {
            InitializeComponent();
        }
        public int uye_id;
        string randevu_id;
        MySqlConnection baglan = new MySqlConnection(connection.con);
        MySqlCommand cmd;
        DataTable tablo = new DataTable();
        MySqlDataAdapter adp = new MySqlDataAdapter();

        public void gelecek_randevu_listele()
        {

            tablo.Clear();
            baglan.Open();
            cmd = new MySqlCommand("SELECT randevu.randevu_id,hastane.hastane_adi,bolum.bolum_adi,doktorlar.ad,randevu.randevu_tarih,randevu_saati FROM bolum,hastane,doktorlar,randevu WHERE hasta_id=" + uye_id + " AND doktorlar.doktor_id=randevu.doktor_id AND hastane.hastane_id=randevu.hastane_id AND bolum.bolum_id=randevu.bolum_id", baglan);
            adp.SelectCommand = cmd;
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
      
        private void hasta_randevularım_Load(object sender, EventArgs e)
        {
           
            gelecek_randevu_listele();
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            randevu_id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string i = randevu_id.ToString();
            if (i.Length > 0)
            {
                int y = Convert.ToInt16(randevu_id);
                baglan.Open();
                cmd = new MySqlCommand("DELETE FROM randevu WHERE randevu_id=" + y + "", baglan);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Randevunuz İptal Edildi");
                baglan.Close();
                gelecek_randevu_listele();
            }
            else
            {
                MessageBox.Show("Seçim Yapınız");
            }

        }

        
    }
}
