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
    public partial class doktor_paneli : Form
    {
        public doktor_paneli()
        {
            InitializeComponent();
        }

        public int doktor_id;

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void izineAyrılToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dr_izin doktor_izin = new dr_izin();
            doktor_izin.MdiParent = this;
            doktor_izin.izin_id = doktor_id;
            doktor_izin.Show();
        }

        private void hastalarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doktor_hastalari dr_hastalari = new doktor_hastalari();
            dr_hastalari.doktor_id = doktor_id;
            dr_hastalari.MdiParent = this;
            dr_hastalari.Show();

        }

        private void kişiselBilgilerimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doktor_bilgileri dr_kisisel_bilgileri = new doktor_bilgileri();
            dr_kisisel_bilgileri.doktor_id = doktor_id;
            dr_kisisel_bilgileri.MdiParent = this;
            dr_kisisel_bilgileri.Show();
        }

        private void doktor_paneli_Load(object sender, EventArgs e)
        {

        }
       
   
       
    }
}
