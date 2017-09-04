namespace PRCTicari
{
    partial class frmStokGrupKarti
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStokGrupKarti));
            this.dgvGruplar = new PRCTicari.MyDataGridView(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbKaydet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbKapat = new System.Windows.Forms.ToolStripButton();
            this.colGrupKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrupAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHizliSatis = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGruplar)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGruplar
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvGruplar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGruplar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGruplar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGrupKodu,
            this.colGrupAdi,
            this.colHizliSatis});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGruplar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGruplar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGruplar.Location = new System.Drawing.Point(0, 54);
            this.dgvGruplar.Name = "dgvGruplar";
            this.dgvGruplar.RowHeadersWidth = 24;
            this.dgvGruplar.Size = new System.Drawing.Size(448, 220);
            this.dgvGruplar.TabIndex = 12;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusStrip1.BackgroundImage")));
            this.statusStrip1.Location = new System.Drawing.Point(0, 274);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(448, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BackgroundImage")));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbKaydet,
            this.toolStripSeparator1,
            this.tsbKapat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(448, 54);
            this.toolStrip1.TabIndex = 11;
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
            // colGrupKodu
            // 
            this.colGrupKodu.DataPropertyName = "Grup_Kodu";
            this.colGrupKodu.HeaderText = "Grup Kodu";
            this.colGrupKodu.Name = "colGrupKodu";
            this.colGrupKodu.Width = 85;
            // 
            // colGrupAdi
            // 
            this.colGrupAdi.DataPropertyName = "Grup_Adi";
            this.colGrupAdi.HeaderText = "Grup Adı";
            this.colGrupAdi.Name = "colGrupAdi";
            this.colGrupAdi.Width = 200;
            // 
            // colHizliSatis
            // 
            this.colHizliSatis.DataPropertyName = "Hizli_Satis";
            this.colHizliSatis.FalseValue = "0";
            this.colHizliSatis.HeaderText = "Hızlı Satış";
            this.colHizliSatis.Name = "colHizliSatis";
            this.colHizliSatis.TrueValue = "1";
            this.colHizliSatis.Width = 70;
            // 
            // frmStokGrupKarti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(448, 296);
            this.Controls.Add(this.dgvGruplar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmStokGrupKarti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Grup Kartı";
            this.Shown += new System.EventHandler(this.frmStokGrupKarti_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGruplar)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyDataGridView dgvGruplar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbKaydet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbKapat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrupKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrupAdi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colHizliSatis;
    }
}