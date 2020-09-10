namespace mhrs_randevu_otomasyonu
{
    partial class doktor_paneli
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kişiselBilgilerimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izinİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izineAyrılToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hastaİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hastalarımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ayarlarToolStripMenuItem,
            this.kişiselBilgilerimToolStripMenuItem,
            this.izinİşlemleriToolStripMenuItem,
            this.hastaİşlemleriToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(773, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.çıkışYapToolStripMenuItem});
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.ayarlarToolStripMenuItem.Text = "Ayarlar";
            // 
            // çıkışYapToolStripMenuItem
            // 
            this.çıkışYapToolStripMenuItem.Name = "çıkışYapToolStripMenuItem";
            this.çıkışYapToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.çıkışYapToolStripMenuItem.Text = "Çıkış Yap";
            this.çıkışYapToolStripMenuItem.Click += new System.EventHandler(this.çıkışYapToolStripMenuItem_Click);
            // 
            // kişiselBilgilerimToolStripMenuItem
            // 
            this.kişiselBilgilerimToolStripMenuItem.Name = "kişiselBilgilerimToolStripMenuItem";
            this.kişiselBilgilerimToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.kişiselBilgilerimToolStripMenuItem.Text = "Kişisel Bilgilerim";
            this.kişiselBilgilerimToolStripMenuItem.Click += new System.EventHandler(this.kişiselBilgilerimToolStripMenuItem_Click);
            // 
            // izinİşlemleriToolStripMenuItem
            // 
            this.izinİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izineAyrılToolStripMenuItem});
            this.izinİşlemleriToolStripMenuItem.Name = "izinİşlemleriToolStripMenuItem";
            this.izinİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.izinİşlemleriToolStripMenuItem.Text = "İzin İşlemleri";
            // 
            // izineAyrılToolStripMenuItem
            // 
            this.izineAyrılToolStripMenuItem.Name = "izineAyrılToolStripMenuItem";
            this.izineAyrılToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.izineAyrılToolStripMenuItem.Text = "İzine Ayrıl";
            this.izineAyrılToolStripMenuItem.Click += new System.EventHandler(this.izineAyrılToolStripMenuItem_Click);
            // 
            // hastaİşlemleriToolStripMenuItem
            // 
            this.hastaİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hastalarımToolStripMenuItem});
            this.hastaİşlemleriToolStripMenuItem.Name = "hastaİşlemleriToolStripMenuItem";
            this.hastaİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.hastaİşlemleriToolStripMenuItem.Text = "Hasta İşlemleri";
            // 
            // hastalarımToolStripMenuItem
            // 
            this.hastalarımToolStripMenuItem.Name = "hastalarımToolStripMenuItem";
            this.hastalarımToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.hastalarımToolStripMenuItem.Text = "Hastalarım";
            this.hastalarımToolStripMenuItem.Click += new System.EventHandler(this.hastalarımToolStripMenuItem_Click);
            // 
            // doktor_paneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 392);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "doktor_paneli";
            this.Text = "doktor_paneli";
            this.Load += new System.EventHandler(this.doktor_paneli_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışYapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izinİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izineAyrılToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hastaİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hastalarımToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kişiselBilgilerimToolStripMenuItem;
    }
}