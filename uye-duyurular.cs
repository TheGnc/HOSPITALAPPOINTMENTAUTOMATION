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
    public partial class uye_duyurular : Form
    {
        public uye_duyurular()
        {
            InitializeComponent();
        }
        MySqlConnection baglan = new MySqlConnection(connection.con);
        DataTable tablo = new DataTable();
        MySqlCommand cmd;
        MySqlDataAdapter adp = new MySqlDataAdapter();
        public void duyurularigetir()
        {
            tablo.Clear();
            baglan.Open();
            cmd = new MySqlCommand("SELECT baslik,icerik FROM aciklamalar", baglan);
            adp.SelectCommand = cmd;
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
        private void uye_duyurular_Load(object sender, EventArgs e)
        {
            duyurularigetir();
        }
    }
}
