namespace PRCTicari
{
    partial class frmSecIrsaliye
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSecIrsaliye));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbTumSubeler = new System.Windows.Forms.CheckBox();
            this.lblUnvani = new System.Windows.Forms.Label();
            this.lblCariKodu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvIrsaliyeler = new System.Windows.Forms.DataGridView();
            this.colSec = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFisTipi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsyeriKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFisNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFisTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBelgeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepoKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepoAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTutariNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbTamam = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbKapat = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIrsaliyeler)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbTumSubeler);
            this.panel1.Controls.Add(this.lblUnvani);
            this.panel1.Controls.Add(this.lblCariKodu);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 69);
            this.panel1.TabIndex = 0;
            // 
            // cbTumSubeler
            // 
            this.cbTumSubeler.AutoSize = true;
            this.cbTumSubeler.Location = new System.Drawing.Point(67, 46);
            this.cbTumSubeler.Name = "cbTumSubeler";
            this.cbTumSubeler.Size = new System.Drawing.Size(86, 17);
            this.cbTumSubeler.TabIndex = 4;
            this.cbTumSubeler.Text = "Tüm Şubeler";
            this.cbTumSubeler.UseVisualStyleBackColor = true;
            this.cbTumSubeler.CheckedChanged += new System.EventHandler(this.cbTumSubeler_CheckedChanged);
            // 
            // lblUnvani
            // 
            this.lblUnvani.AutoSize = true;
            this.lblUnvani.Location = new System.Drawing.Point(64, 30);
            this.lblUnvani.Name = "lblUnvani";
            this.lblUnvani.Size = new System.Drawing.Size(0, 13);
            this.lblUnvani.TabIndex = 3;
            // 
            // lblCariKodu
            // 
            this.lblCariKodu.AutoSize = true;
            this.lblCariKodu.Location = new System.Drawing.Point(64, 9);
            this.lblCariKodu.Name = "lblCariKodu";
            this.lblCariKodu.Size = new System.Drawing.Size(0, 13);
            this.lblCariKodu.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ünvanı:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cari Kodu:";
            // 
            // dgvIrsaliyeler
            // 
            this.dgvIrsaliyeler.AllowUserToAddRows = false;
            this.dgvIrsaliyeler.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvIrsaliyeler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIrsaliyeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIrsaliyeler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSec,
            this.colFisTipi,
            this.colIsyeriKodu,
            this.colFisNo,
            this.colFisTarihi,
            this.colBelgeNo,
            this.colDepoKodu,
            this.colDepoAdi,
            this.colTutariNet});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIrsaliyeler.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvIrsaliyeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIrsaliyeler.Location = new System.Drawing.Point(0, 123);
            this.dgvIrsaliyeler.Name = "dgvIrsaliyeler";
            this.dgvIrsaliyeler.RowHeadersWidth = 24;
            this.dgvIrsaliyeler.Size = new System.Drawing.Size(602, 203);
            this.dgvIrsaliyeler.TabIndex = 1;
            // 
            // colSec
            // 
            this.colSec.DataPropertyName = "Sec";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "False";
            this.colSec.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSec.FalseValue = "0";
            this.colSec.HeaderText = "Seç";
            this.colSec.Name = "colSec";
            this.colSec.TrueValue = "1";
            this.colSec.Width = 40;
            // 
            // colFisTipi
            // 
            this.colFisTipi.DataPropertyName = "Fis_Tipi";
            this.colFisTipi.HeaderText = "Fiş Tipi";
            this.colFisTipi.Name = "colFisTipi";
            this.colFisTipi.ReadOnly = true;
            this.colFisTipi.Visible = false;
            // 
            // colIsyeriKodu
            // 
            this.colIsyeriKodu.DataPropertyName = "Isyeri_Kodu";
            this.colIsyeriKodu.HeaderText = "İşyeri Kodu";
            this.colIsyeriKodu.Name = "colIsyeriKodu";
            this.colIsyeriKodu.ReadOnly = true;
            this.colIsyeriKodu.Visible = false;
            // 
            // colFisNo
            // 
            this.colFisNo.DataPropertyName = "Fis_No";
            this.colFisNo.HeaderText = "Fiş No";
            this.colFisNo.Name = "colFisNo";
            this.colFisNo.ReadOnly = true;
            this.colFisNo.Visible = false;
            // 
            // colFisTarihi
            // 
            this.colFisTarihi.DataPropertyName = "Fis_Tarihi";
            this.colFisTarihi.HeaderText = "Fiş Tarihi";
            this.colFisTarihi.Name = "colFisTarihi";
            this.colFisTarihi.ReadOnly = true;
            // 
            // colBelgeNo
            // 
            this.colBelgeNo.DataPropertyName = "Belge_No";
            this.colBelgeNo.HeaderText = "Belge No";
            this.colBelgeNo.Name = "colBelgeNo";
            this.colBelgeNo.ReadOnly = true;
            // 
            // colDepoKodu
            // 
            this.colDepoKodu.DataPropertyName = "Depo_Kodu_1";
            this.colDepoKodu.HeaderText = "Depo Kodu";
            this.colDepoKodu.Name = "colDepoKodu";
            this.colDepoKodu.ReadOnly = true;
            this.colDepoKodu.Visible = false;
            // 
            // colDepoAdi
            // 
            this.colDepoAdi.DataPropertyName = "Depo_Adi";
            this.colDepoAdi.HeaderText = "Depo Adı";
            this.colDepoAdi.Name = "colDepoAdi";
            this.colDepoAdi.ReadOnly = true;
            this.colDepoAdi.Width = 200;
            // 
            // colTutariNet
            // 
            this.colTutariNet.DataPropertyName = "Tutari_Net";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,##0.00;-#,##0.00;#.#";
            this.colTutariNet.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTutariNet.HeaderText = "Tutarı";
            this.colTutariNet.Name = "colTutariNet";
            this.colTutariNet.ReadOnly = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusStrip1.BackgroundImage")));
            this.statusStrip1.Location = new System.Drawing.Point(0, 326);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(602, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BackgroundImage")));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbTamam,
            this.toolStripSeparator1,
            this.tsbKapat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(602, 54);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbTamam
            // 
            this.tsbTamam.Image = ((System.Drawing.Image)(resources.GetObject("tsbTamam.Image")));
            this.tsbTamam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTamam.Name = "tsbTamam";
            this.tsbTamam.Size = new System.Drawing.Size(51, 51);
            this.tsbTamam.Text = "Tamam";
            this.tsbTamam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbTamam.Click += new System.EventHandler(this.tsbTamam_Click);
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
            // frmSecIrsaliye
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(602, 348);
            this.Controls.Add(this.dgvIrsaliyeler);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSecIrsaliye";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İrsaliye Seçimi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSecIrsaliye_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIrsaliyeler)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvIrsaliyeler;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbTamam;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbKapat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFisTipi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsyeriKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFisNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFisTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBelgeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepoKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepoAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTutariNet;
        private System.Windows.Forms.Label lblUnvani;
        private System.Windows.Forms.Label lblCariKodu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbTumSubeler;
    }
}