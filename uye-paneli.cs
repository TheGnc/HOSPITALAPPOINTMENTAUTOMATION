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
    public partial class uye_paneli : Form
    {
        public uye_paneli()
        {
            InitializeComponent();
        }
        public int uye_id;
        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uye_hakkimizda hakkimizda = new uye_hakkimizda();
            hakkimizda.MdiParent = this;
            hakkimizda.Show();
        }

        private void doktorlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uye_doktorlar u_doktorlar = new uye_doktorlar();
            u_doktorlar.MdiParent = this;
            u_doktorlar.Show();
        }

        private void duyurularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uye_duyurular u_duyurular = new uye_duyurular();
            u_duyurular.MdiParent = this;
            u_duyurular.Show();
        }
  
      

        private void randevularımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hasta_randevularım randevularim = new hasta_randevularım();
            randevularim.MdiParent = this;
            randevularim.uye_id = uye_id;
            randevularim.Show();
          
        }

        private void randevuAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hasta_randevual randevu_al = new hasta_randevual();
            randevu_al.MdiParent = this;
            randevu_al.uye_id = uye_id;
            randevu_al.Show();
        }

        private void randevularımıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }
    }
}
