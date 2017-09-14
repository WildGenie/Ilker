namespace PRCTicari
{
    partial class rpFaturaListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rpFaturaListesi));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOnizleme = new System.Windows.Forms.ToolStripButton();
            this.tsbYazdir = new System.Windows.Forms.ToolStripButton();
            this.tsbTasarim = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbKapat = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpBitisTarihi = new System.Windows.Forms.DateTimePicker();
            this.dtpBaslangicTarihi = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRaporAdi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCariKodu = new System.Windows.Forms.TextBox();
            this.btnCariKodu = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(292, 54);
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
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusStrip1.BackgroundImage")));
            this.statusStrip1.Location = new System.Drawing.Point(0, 188);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(292, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCariKodu);
            this.panel1.Controls.Add(this.txtCariKodu);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpBitisTarihi);
            this.panel1.Controls.Add(this.dtpBaslangicTarihi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbRaporAdi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 134);
            this.panel1.TabIndex = 14;
            // 
            // dtpBitisTarihi
            // 
            this.dtpBitisTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBitisTarihi.Location = new System.Drawing.Point(114, 68);
            this.dtpBitisTarihi.Name = "dtpBitisTarihi";
            this.dtpBitisTarihi.Size = new System.Drawing.Size(171, 20);
            this.dtpBitisTarihi.TabIndex = 5;
            // 
            // dtpBaslangicTarihi
            // 
            this.dtpBaslangicTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBaslangicTarihi.Location = new System.Drawing.Point(114, 42);
            this.dtpBaslangicTarihi.Name = "dtpBaslangicTarihi";
            this.dtpBaslangicTarihi.Size = new System.Drawing.Size(171, 20);
            this.dtpBaslangicTarihi.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Bitiş Tarihi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Başlangıç Tarihi:";
            // 
            // cbRaporAdi
            // 
            this.cbRaporAdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRaporAdi.FormattingEnabled = true;
            this.cbRaporAdi.Location = new System.Drawing.Point(114, 104);
            this.cbRaporAdi.Name = "cbRaporAdi";
            this.cbRaporAdi.Size = new System.Drawing.Size(171, 21);
            this.cbRaporAdi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rapor Adı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cari Kodu:";
            // 
            // txtCariKodu
            // 
            this.txtCariKodu.Location = new System.Drawing.Point(114, 6);
            this.txtCariKodu.Name = "txtCariKodu";
            this.txtCariKodu.Size = new System.Drawing.Size(144, 20);
            this.txtCariKodu.TabIndex = 6;
            // 
            // btnCariKodu
            // 
            this.btnCariKodu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCariKodu.Location = new System.Drawing.Point(258, 5);
            this.btnCariKodu.Name = "btnCariKodu";
            this.btnCariKodu.Size = new System.Drawing.Size(27, 22);
            this.btnCariKodu.TabIndex = 8;
            this.btnCariKodu.TabStop = false;
            this.btnCariKodu.Text = "...";
            this.btnCariKodu.UseVisualStyleBackColor = true;
            // 
            // rpFaturaListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(292, 210);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rpFaturaListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fatura Listesi";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbOnizleme;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbKapat;
        private System.Windows.Forms.ToolStripButton tsbYazdir;
        private System.Windows.Forms.ToolStripButton tsbTasarim;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpBitisTarihi;
        private System.Windows.Forms.DateTimePicker dtpBaslangicTarihi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbRaporAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCariKodu;
        private System.Windows.Forms.TextBox txtCariKodu;
        private System.Windows.Forms.Label label4;
    }
}