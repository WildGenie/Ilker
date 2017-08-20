namespace PRCTicari
{
    partial class rpIrsaliyeListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rpIrsaliyeListesi));
            this.label1 = new System.Windows.Forms.Label();
            this.cbRaporAdi = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOnizleme = new System.Windows.Forms.ToolStripButton();
            this.tsbYazdir = new System.Windows.Forms.ToolStripButton();
            this.tsbTasarim = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbKapat = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rapor Adı:";
            // 
            // cbRaporAdi
            // 
            this.cbRaporAdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRaporAdi.FormattingEnabled = true;
            this.cbRaporAdi.Location = new System.Drawing.Point(75, 99);
            this.cbRaporAdi.Name = "cbRaporAdi";
            this.cbRaporAdi.Size = new System.Drawing.Size(229, 21);
            this.cbRaporAdi.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BackgroundImage")));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOnizleme,
            this.tsbYazdir,
            this.tsbTasarim,
            this.toolStripSeparator2,
            this.tsbKapat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(316, 54);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbOnizleme
            // 
            this.tsbOnizleme.Image = ((System.Drawing.Image)(resources.GetObject("tsbOnizleme.Image")));
            this.tsbOnizleme.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOnizleme.Name = "tsbOnizleme";
            this.tsbOnizleme.Size = new System.Drawing.Size(61, 51);
            this.tsbOnizleme.Tag = "0";
            this.tsbOnizleme.Text = "Önizleme";
            this.tsbOnizleme.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbOnizleme.Click += new System.EventHandler(this.tsbOnizleme_Click);
            // 
            // tsbYazdir
            // 
            this.tsbYazdir.Image = ((System.Drawing.Image)(resources.GetObject("tsbYazdir.Image")));
            this.tsbYazdir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbYazdir.Name = "tsbYazdir";
            this.tsbYazdir.Size = new System.Drawing.Size(42, 51);
            this.tsbYazdir.Tag = "1";
            this.tsbYazdir.Text = "Yazdır";
            this.tsbYazdir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbYazdir.Click += new System.EventHandler(this.tsbOnizleme_Click);
            // 
            // tsbTasarim
            // 
            this.tsbTasarim.Image = ((System.Drawing.Image)(resources.GetObject("tsbTasarim.Image")));
            this.tsbTasarim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTasarim.Name = "tsbTasarim";
            this.tsbTasarim.Size = new System.Drawing.Size(52, 51);
            this.tsbTasarim.Tag = "2";
            this.tsbTasarim.Text = "Tasarım";
            this.tsbTasarim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbTasarim.Click += new System.EventHandler(this.tsbOnizleme_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // tsbKapat
            // 
            this.tsbKapat.Image = ((System.Drawing.Image)(resources.GetObject("tsbKapat.Image")));
            this.tsbKapat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbKapat.Name = "tsbKapat";
            this.tsbKapat.Size = new System.Drawing.Size(41, 51);
            this.tsbKapat.Text = "Kapat";
            this.tsbKapat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbKapat.Click += new System.EventHandler(this.tsbKapat_Click);
            // 
            // rpIrsaliyeListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(316, 124);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cbRaporAdi);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rpIrsaliyeListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İrsaliye Listesi";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRaporAdi;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbOnizleme;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbKapat;
        private System.Windows.Forms.ToolStripButton tsbYazdir;
        private System.Windows.Forms.ToolStripButton tsbTasarim;
    }
}