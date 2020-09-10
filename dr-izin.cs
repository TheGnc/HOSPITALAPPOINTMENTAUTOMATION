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
    public partial class dr_izin : Form
    {
        public dr_izin()
        {
            InitializeComponent();
        }
        public int izin_id;
        MySqlConnection baglan = new MySqlConnection(connection.con);
        MySqlCommand cmd;
        string[] izin_baslangic = new string[3];
        string[] izin_bitis = new string[3];
        string izin_bas, izin_bit;
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            
            izin_baslangic = dateTimePicker1.Text.Split('.');
            izin_bitis      = dateTimePicker2.Text.Split('.');
            izin_bas = izin_baslangic[2] + "-" + izin_baslangic[1] + "-" + izin_baslangic[0];
            izin_bit = izin_bitis[2] + "-" + izin_bitis[1] + "-" + izin_bitis[0];


            cmd = new MySqlCommand("İNSERT İNTO izinler(izin_baslangic,izin_bitis,doktor_id) values('" + izin_bas + "','" + izin_bit + "','" + izin_id + "')", baglan);
            cmd.ExecuteNonQuery();
            MessageBox.Show("İzine Ayrıldınız");
            baglan.Close();

        }

        private void dr_izin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
