namespace PRCTicari
{
    partial class frmMasaSatis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasaSatis));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbMasaEkle = new System.Windows.Forms.ToolStripButton();
            this.tsbDuzenle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbKapat = new System.Windows.Forms.ToolStripButton();
            this.pnlMasa = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlSalon = new System.Windows.Forms.Panel();
            this.pnlMasaIslem = new System.Windows.Forms.Panel();
            this.pnlMasaEkle = new System.Windows.Forms.Panel();
            this.btnMasaEkleTamam = new System.Windows.Forms.Button();
            this.txtMasaKodu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMasaSil = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlMasaIslem.SuspendLayout();
            this.pnlMasaEkle.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusStrip1.BackgroundImage")));
            this.statusStrip1.Location = new System.Drawing.Point(0, 487);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(926, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BackgroundImage")));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMasaEkle,
            this.tsbDuzenle,
            this.toolStripSeparator2,
            this.tsbKapat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(926, 54);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbMasaEkle
            // 
            this.tsbMasaEkle.Image = ((System.Drawing.Image)(resources.GetObject("tsbMasaEkle.Image")));
            this.tsbMasaEkle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMasaEkle.Name = "tsbMasaEkle";
            this.tsbMasaEkle.Size = new System.Drawing.Size(63, 51);
            this.tsbMasaEkle.Text = "Masa Ekle";
            this.tsbMasaEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMasaEkle.Click += new System.EventHandler(this.tsbMasaEkle_Click);
            // 
            // tsbDuzenle
            // 
            this.tsbDuzenle.Image = ((System.Drawing.Image)(resources.GetObject("tsbDuzenle.Image")));
            this.tsbDuzenle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDuzenle.Name = "tsbDuzenle";
            this.tsbDuzenle.Size = new System.Drawing.Size(53, 51);
            this.tsbDuzenle.Text = "Düzenle";
            this.tsbDuzenle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDuzenle.Click += new System.EventHandler(this.tsbDuzenle_Click);
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
            // pnlMasa
            // 
            this.pnlMasa.AutoScroll = true;
            this.pnlMasa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMasa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMasa.Location = new System.Drawing.Point(133, 54);
            this.pnlMasa.Name = "pnlMasa";
            this.pnlMasa.Size = new System.Drawing.Size(553, 250);
            this.pnlMasa.TabIndex = 16;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView1.Location = new System.Drawing.Point(686, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 433);
            this.dataGridView1.TabIndex = 0;
            // 
            // pnlSalon
            // 
            this.pnlSalon.AutoScroll = true;
            this.pnlSalon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSalon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSalon.Location = new System.Drawing.Point(0, 54);
            this.pnlSalon.Name = "pnlSalon";
            this.pnlSalon.Size = new System.Drawing.Size(133, 433);
            this.pnlSalon.TabIndex = 17;
            // 
            // pnlMasaIslem
            // 
            this.pnlMasaIslem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMasaIslem.Controls.Add(this.btnMasaSil);
            this.pnlMasaIslem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMasaIslem.Location = new System.Drawing.Point(133, 304);
            this.pnlMasaIslem.Name = "pnlMasaIslem";
            this.pnlMasaIslem.Size = new System.Drawing.Size(553, 183);
            this.pnlMasaIslem.TabIndex = 18;
            // 
            // pnlMasaEkle
            // 
            this.pnlMasaEkle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMasaEkle.Controls.Add(this.btnMasaEkleTamam);
            this.pnlMasaEkle.Controls.Add(this.txtMasaKodu);
            this.pnlMasaEkle.Controls.Add(this.label1);
            this.pnlMasaEkle.Location = new System.Drawing.Point(0, 54);
            this.pnlMasaEkle.Name = "pnlMasaEkle";
            this.pnlMasaEkle.Size = new System.Drawing.Size(280, 74);
            this.pnlMasaEkle.TabIndex = 19;
            // 
            // btnMasaEkleTamam
            // 
            this.btnMasaEkleTamam.Location = new System.Drawing.Point(69, 35);
            this.btnMasaEkleTamam.Name = "btnMasaEkleTamam";
            this.btnMasaEkleTamam.Size = new System.Drawing.Size(195, 28);
            this.btnMasaEkleTamam.TabIndex = 2;
            this.btnMasaEkleTamam.Text = "Tamam";
            this.btnMasaEkleTamam.UseVisualStyleBackColor = true;
            this.btnMasaEkleTamam.Click += new System.EventHandler(this.btnMasaEkleTamam_Click);
            // 
            // txtMasaKodu
            // 
            this.txtMasaKodu.Location = new System.Drawing.Point(69, 12);
            this.txtMasaKodu.Name = "txtMasaKodu";
            this.txtMasaKodu.Size = new System.Drawing.Size(195, 20);
            this.txtMasaKodu.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Masa Kodu:";
            // 
            // btnMasaSil
            // 
            this.btnMasaSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMasaSil.Location = new System.Drawing.Point(5, 3);
            this.btnMasaSil.Name = "btnMasaSil";
            this.btnMasaSil.Size = new System.Drawing.Size(141, 33);
            this.btnMasaSil.TabIndex = 0;
            this.btnMasaSil.Text = "Masa Sil";
            this.btnMasaSil.UseVisualStyleBackColor = true;
            this.btnMasaSil.Click += new System.EventHandler(this.btnMasaSil_Click);
            // 
            // frmMasaSatis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(926, 509);
            this.Controls.Add(this.pnlMasaEkle);
            this.Controls.Add(this.pnlMasa);
            this.Controls.Add(this.pnlMasaIslem);
            this.Controls.Add(this.pnlSalon);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmMasaSatis";
            this.Text = "Masa Satış";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.frmMasaSatis_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlMasaIslem.ResumeLayout(false);
            this.pnlMasaEkle.ResumeLayout(false);
            this.pnlMasaEkle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbMasaEkle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbKapat;
        private System.Windows.Forms.Panel pnlMasa;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlSalon;
        private System.Windows.Forms.ToolStripButton tsbDuzenle;
        private System.Windows.Forms.Panel pnlMasaIslem;
        private System.Windows.Forms.Panel pnlMasaEkle;
        private System.Windows.Forms.Button btnMasaEkleTamam;
        private System.Windows.Forms.TextBox txtMasaKodu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMasaSil;
    }
}