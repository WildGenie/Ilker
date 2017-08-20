namespace PRCTicari
{
    partial class frmMasrafKarti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasrafKarti));
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pnlBaslik = new System.Windows.Forms.Panel();
            this.btnMasrafKodu = new System.Windows.Forms.Button();
            this.txtMasrafKodu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDetay = new System.Windows.Forms.Panel();
            this.cbIslem = new System.Windows.Forms.CheckBox();
            this.txtMasrafAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbKaydet = new System.Windows.Forms.ToolStripButton();
            this.tsbSil = new System.Windows.Forms.ToolStripButton();
            this.tsbVazgec = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbKapat = new System.Windows.Forms.ToolStripButton();
            this.lblMasrafNo = new System.Windows.Forms.Label();
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
            this.panel1.Location = new System.Drawing.Point(0, 146);
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
            this.pnlBaslik.Controls.Add(this.lblMasrafNo);
            this.pnlBaslik.Controls.Add(this.btnMasrafKodu);
            this.pnlBaslik.Controls.Add(this.txtMasrafKodu);
            this.pnlBaslik.Controls.Add(this.label1);
            this.pnlBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBaslik.Location = new System.Drawing.Point(0, 54);
            this.pnlBaslik.Name = "pnlBaslik";
            this.pnlBaslik.Size = new System.Drawing.Size(315, 37);
            this.pnlBaslik.TabIndex = 0;
            // 
            // btnMasrafKodu
            // 
            this.btnMasrafKodu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMasrafKodu.Location = new System.Drawing.Point(173, 7);
            this.btnMasrafKodu.Name = "btnMasrafKodu";
            this.btnMasrafKodu.Size = new System.Drawing.Size(27, 22);
            this.btnMasrafKodu.TabIndex = 1;
            this.btnMasrafKodu.TabStop = false;
            this.btnMasrafKodu.Text = "...";
            this.btnMasrafKodu.UseVisualStyleBackColor = true;
            this.btnMasrafKodu.Click += new System.EventHandler(this.btnMasrafKodu_Click);
            // 
            // txtMasrafKodu
            // 
            this.txtMasrafKodu.Location = new System.Drawing.Point(73, 8);
            this.txtMasrafKodu.Name = "txtMasrafKodu";
            this.txtMasrafKodu.Size = new System.Drawing.Size(100, 20);
            this.txtMasrafKodu.TabIndex = 0;
            this.txtMasrafKodu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMasrafKodu_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Masraf Kodu:";
            // 
            // pnlDetay
            // 
            this.pnlDetay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetay.Controls.Add(this.cbIslem);
            this.pnlDetay.Controls.Add(this.txtMasrafAdi);
            this.pnlDetay.Controls.Add(this.label2);
            this.pnlDetay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetay.Location = new System.Drawing.Point(0, 91);
            this.pnlDetay.Name = "pnlDetay";
            this.pnlDetay.Size = new System.Drawing.Size(315, 55);
            this.pnlDetay.TabIndex = 1;
            // 
            // cbIslem
            // 
            this.cbIslem.AutoSize = true;
            this.cbIslem.Location = new System.Drawing.Point(73, 31);
            this.cbIslem.Name = "cbIslem";
            this.cbIslem.Size = new System.Drawing.Size(50, 17);
            this.cbIslem.TabIndex = 3;
            this.cbIslem.Text = "İşlem";
            this.cbIslem.UseVisualStyleBackColor = true;
            // 
            // txtMasrafAdi
            // 
            this.txtMasrafAdi.Location = new System.Drawing.Point(73, 5);
            this.txtMasrafAdi.Name = "txtMasrafAdi";
            this.txtMasrafAdi.Size = new System.Drawing.Size(237, 20);
            this.txtMasrafAdi.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Masraf Adı:";
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
            // lblMasrafNo
            // 
            this.lblMasrafNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMasrafNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMasrafNo.Location = new System.Drawing.Point(210, 8);
            this.lblMasrafNo.Name = "lblMasrafNo";
            this.lblMasrafNo.Size = new System.Drawing.Size(100, 20);
            this.lblMasrafNo.TabIndex = 3;
            this.lblMasrafNo.Text = "0";
            this.lblMasrafNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMasrafKarti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(315, 171);
            this.Controls.Add(this.pnlDetay);
            this.Controls.Add(this.pnlBaslik);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMasrafKarti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masraf Kartı";
            this.Shown += new System.EventHandler(this.frmMasrafKarti_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMasrafKarti_KeyDown);
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
        private System.Windows.Forms.Button btnMasrafKodu;
        private System.Windows.Forms.TextBox txtMasrafKodu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMasrafAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbIslem;
        private System.Windows.Forms.Label lblMasrafNo;
    }
}