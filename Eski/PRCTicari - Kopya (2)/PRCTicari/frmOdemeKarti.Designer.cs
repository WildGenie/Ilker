namespace PRCTicari
{
    partial class frmOdemeKarti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOdemeKarti));
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pnlBaslik = new System.Windows.Forms.Panel();
            this.btnOdemeKodu = new System.Windows.Forms.Button();
            this.txtOdemeKodu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDetay = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbKayitTipi = new System.Windows.Forms.ComboBox();
            this.cbOdemeTipi = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOdemeAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbKaydet = new System.Windows.Forms.ToolStripButton();
            this.tsbSil = new System.Windows.Forms.ToolStripButton();
            this.tsbVazgec = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbKapat = new System.Windows.Forms.ToolStripButton();
            this.txtKayitKodu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnKayitKodu = new System.Windows.Forms.Button();
            this.lblKayitAdi = new System.Windows.Forms.Label();
            this.lblOdemeNo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlBaslik.SuspendLayout();
            this.pnlDetay.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 227);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 25);
            this.panel1.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusStrip1.BackgroundImage")));
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(313, 23);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pnlBaslik
            // 
            this.pnlBaslik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBaslik.Controls.Add(this.lblOdemeNo);
            this.pnlBaslik.Controls.Add(this.btnOdemeKodu);
            this.pnlBaslik.Controls.Add(this.txtOdemeKodu);
            this.pnlBaslik.Controls.Add(this.label1);
            this.pnlBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBaslik.Location = new System.Drawing.Point(0, 54);
            this.pnlBaslik.Name = "pnlBaslik";
            this.pnlBaslik.Size = new System.Drawing.Size(315, 37);
            this.pnlBaslik.TabIndex = 0;
            // 
            // btnOdemeKodu
            // 
            this.btnOdemeKodu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOdemeKodu.Location = new System.Drawing.Point(175, 7);
            this.btnOdemeKodu.Name = "btnOdemeKodu";
            this.btnOdemeKodu.Size = new System.Drawing.Size(27, 22);
            this.btnOdemeKodu.TabIndex = 1;
            this.btnOdemeKodu.TabStop = false;
            this.btnOdemeKodu.Text = "...";
            this.btnOdemeKodu.UseVisualStyleBackColor = true;
            this.btnOdemeKodu.Click += new System.EventHandler(this.btnKasaKodu_Click);
            // 
            // txtOdemeKodu
            // 
            this.txtOdemeKodu.Location = new System.Drawing.Point(75, 8);
            this.txtOdemeKodu.Name = "txtOdemeKodu";
            this.txtOdemeKodu.Size = new System.Drawing.Size(100, 20);
            this.txtOdemeKodu.TabIndex = 0;
            this.txtOdemeKodu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKasaKodu_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ödeme Kodu:";
            // 
            // pnlDetay
            // 
            this.pnlDetay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetay.Controls.Add(this.lblKayitAdi);
            this.pnlDetay.Controls.Add(this.btnKayitKodu);
            this.pnlDetay.Controls.Add(this.txtKayitKodu);
            this.pnlDetay.Controls.Add(this.label3);
            this.pnlDetay.Controls.Add(this.label6);
            this.pnlDetay.Controls.Add(this.cbKayitTipi);
            this.pnlDetay.Controls.Add(this.cbOdemeTipi);
            this.pnlDetay.Controls.Add(this.label5);
            this.pnlDetay.Controls.Add(this.txtOdemeAdi);
            this.pnlDetay.Controls.Add(this.label2);
            this.pnlDetay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetay.Location = new System.Drawing.Point(0, 91);
            this.pnlDetay.Name = "pnlDetay";
            this.pnlDetay.Size = new System.Drawing.Size(315, 136);
            this.pnlDetay.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Kayıt Tipi:";
            // 
            // cbKayitTipi
            // 
            this.cbKayitTipi.FormattingEnabled = true;
            this.cbKayitTipi.Items.AddRange(new object[] {
            "Yok",
            "Cari",
            "Kasa"});
            this.cbKayitTipi.Location = new System.Drawing.Point(75, 57);
            this.cbKayitTipi.Name = "cbKayitTipi";
            this.cbKayitTipi.Size = new System.Drawing.Size(127, 21);
            this.cbKayitTipi.TabIndex = 3;
            this.cbKayitTipi.SelectedIndexChanged += new System.EventHandler(this.cbKayitTipi_SelectedIndexChanged);
            // 
            // cbOdemeTipi
            // 
            this.cbOdemeTipi.FormattingEnabled = true;
            this.cbOdemeTipi.Items.AddRange(new object[] {
            "Nakit",
            "Pos",
            "Yemek Çeki",
            "Veresiye"});
            this.cbOdemeTipi.Location = new System.Drawing.Point(75, 31);
            this.cbOdemeTipi.Name = "cbOdemeTipi";
            this.cbOdemeTipi.Size = new System.Drawing.Size(127, 21);
            this.cbOdemeTipi.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ödeme Tipi:";
            // 
            // txtOdemeAdi
            // 
            this.txtOdemeAdi.Location = new System.Drawing.Point(75, 5);
            this.txtOdemeAdi.Name = "txtOdemeAdi";
            this.txtOdemeAdi.Size = new System.Drawing.Size(229, 20);
            this.txtOdemeAdi.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ödeme Adı:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BackgroundImage")));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbKaydet,
            this.tsbSil,
            this.tsbVazgec,
            this.toolStripSeparator1,
            this.tsbKapat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(315, 54);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbKaydet
            // 
            this.tsbKaydet.Image = ((System.Drawing.Image)(resources.GetObject("tsbKaydet.Image")));
            this.tsbKaydet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbKaydet.Name = "tsbKaydet";
            this.tsbKaydet.Size = new System.Drawing.Size(47, 51);
            this.tsbKaydet.Text = "Kaydet";
            this.tsbKaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbKaydet.Click += new System.EventHandler(this.tsbKaydet_Click);
            // 
            // tsbSil
            // 
            this.tsbSil.Image = ((System.Drawing.Image)(resources.GetObject("tsbSil.Image")));
            this.tsbSil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSil.Name = "tsbSil";
            this.tsbSil.Size = new System.Drawing.Size(36, 51);
            this.tsbSil.Text = "Sil";
            this.tsbSil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSil.Click += new System.EventHandler(this.tsbSil_Click);
            // 
            // tsbVazgec
            // 
            this.tsbVazgec.Image = ((System.Drawing.Image)(resources.GetObject("tsbVazgec.Image")));
            this.tsbVazgec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVazgec.Name = "tsbVazgec";
            this.tsbVazgec.Size = new System.Drawing.Size(47, 51);
            this.tsbVazgec.Text = "Vazgeç";
            this.tsbVazgec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbVazgec.Click += new System.EventHandler(this.tsbVazgec_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
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
            // txtKayitKodu
            // 
            this.txtKayitKodu.Location = new System.Drawing.Point(75, 84);
            this.txtKayitKodu.Name = "txtKayitKodu";
            this.txtKayitKodu.Size = new System.Drawing.Size(127, 20);
            this.txtKayitKodu.TabIndex = 14;
            this.txtKayitKodu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKayitKodu_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Kayıt Kodu:";
            // 
            // btnKayitKodu
            // 
            this.btnKayitKodu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKayitKodu.Location = new System.Drawing.Point(202, 83);
            this.btnKayitKodu.Name = "btnKayitKodu";
            this.btnKayitKodu.Size = new System.Drawing.Size(27, 22);
            this.btnKayitKodu.TabIndex = 16;
            this.btnKayitKodu.TabStop = false;
            this.btnKayitKodu.Text = "...";
            this.btnKayitKodu.UseVisualStyleBackColor = true;
            this.btnKayitKodu.Click += new System.EventHandler(this.btnKayitKodu_Click);
            // 
            // lblKayitAdi
            // 
            this.lblKayitAdi.AutoSize = true;
            this.lblKayitAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKayitAdi.Location = new System.Drawing.Point(72, 110);
            this.lblKayitAdi.Name = "lblKayitAdi";
            this.lblKayitAdi.Size = new System.Drawing.Size(0, 13);
            this.lblKayitAdi.TabIndex = 17;
            // 
            // lblOdemeNo
            // 
            this.lblOdemeNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOdemeNo.Location = new System.Drawing.Point(208, 7);
            this.lblOdemeNo.Name = "lblOdemeNo";
            this.lblOdemeNo.Size = new System.Drawing.Size(100, 20);
            this.lblOdemeNo.TabIndex = 2;
            this.lblOdemeNo.Text = "0";
            this.lblOdemeNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmOdemeKarti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(315, 252);
            this.Controls.Add(this.pnlDetay);
            this.Controls.Add(this.pnlBaslik);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmOdemeKarti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ödeme Kartı";
            this.Shown += new System.EventHandler(this.frmOdemeKarti_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOdemeKarti_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlBaslik.ResumeLayout(false);
            this.pnlBaslik.PerformLayout();
            this.pnlDetay.ResumeLayout(false);
            this.pnlDetay.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbKaydet;
        private System.Windows.Forms.ToolStripButton tsbSil;
        private System.Windows.Forms.ToolStripButton tsbVazgec;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbKapat;
        private System.Windows.Forms.Panel pnlBaslik;
        private System.Windows.Forms.Panel pnlDetay;
        private System.Windows.Forms.Button btnOdemeKodu;
        private System.Windows.Forms.TextBox txtOdemeKodu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOdemeAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbKayitTipi;
        private System.Windows.Forms.ComboBox cbOdemeTipi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnKayitKodu;
        private System.Windows.Forms.TextBox txtKayitKodu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblKayitAdi;
        private System.Windows.Forms.Label lblOdemeNo;
    }
}