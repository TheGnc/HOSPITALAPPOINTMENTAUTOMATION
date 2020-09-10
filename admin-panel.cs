using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mhrs_randevu_otomasyonu
{
    public partial class admin_panel : Form
    {
        public admin_panel()
        {
            InitializeComponent();
        }


        public int admin;
     
        private void hastaİşleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // HASTA İŞLERİNE TIKLANDIGINDA FORM'U KAPATIR VE HASTA İSLEMLERİ KISMINA YÖNLENDİRME SAGLAR
            hasta_islemleri hasta_isleri = new hasta_islemleri();
            hasta_isleri.MdiParent = this;
                hasta_isleri.Show();
        }

        private void hastaKayıtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // FORMU KAPATIR HASTA KAYIT FORMUNA YÖNLENDİRİR 
            admin_hasta_kayit hasta_kayit = new admin_hasta_kayit();
            hasta_kayit.MdiParent = this;
            hasta_kayit.Show();
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // HAKKIMIZDAYA TIKLADIGINDA YÖNLENDİRME YAPILIR
            hakkimizda hakkimizda = new hakkimizda();
            hakkimizda.MdiParent = this;
            hakkimizda.Show();
        }

        private void hastaneİşleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // HASTANE İŞLERİNE TIKLANDIGINDA YÖNLENDİRME YAPAR
            hastane_isleri hastane_isleri = new hastane_isleri();
            hastane_isleri.MdiParent = this;
            hastane_isleri.Show();
        }

        private void polikliniklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // POLİKLİNİGE TIKLANINCA ACILICAKTIR.
            poliklinikler poliklinik = new poliklinikler();
            poliklinik.MdiParent = this;
            poliklinik.Show();
        }

        private void admin_panel_Load(object sender, EventArgs e)
        {
          
        }

        private void çalışmaSaatleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ÇALIŞMA SAATLERİ SAYFASINA YÖNLENDİRME YAPAR
            calisma_saatleri calisma_saatleri = new calisma_saatleri();
            calisma_saatleri.MdiParent = this;
            calisma_saatleri.Show();
        }

    

        private void doktorlarımızToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ADMİN DOKTOR EKLEMESİ İÇİN DOKTOR EKLEME PANELİNİ ÇAĞIRIR
            admin_doktor_ekle doktor_ekle = new admin_doktor_ekle();
            doktor_ekle.MdiParent = this;
            doktor_ekle.Show();
        }

        private void doktorİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ADMİN DOKTOR DÜZENLEMESİ İÇİN DOKTOR DÜZENLEME PANELİNİ ÇAĞIRIR
            admin_doktor_isleri admin_doktor_isleri = new admin_doktor_isleri();
            admin_doktor_isleri.MdiParent = this;
            admin_doktor_isleri.Show();
        }

        private void duyuruEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // DUYRUU EKLEME SAYFASINA YÖNLENDİRME
            admin_duyuru_ekle admin_duyuru_ekle = new admin_duyuru_ekle();
            admin_duyuru_ekle.MdiParent = this;
            admin_duyuru_ekle.Show();
        }

        private void duyuruListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // DUYURU DÜZENLEME
            admin_duyuru_islemleri duyuru_islemleri = new admin_duyuru_islemleri();
            duyuru_islemleri.MdiParent = this;
            duyuru_islemleri.Show();
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // PROGRAMI KAPATIR
            this.Close();
        }
    }
}
