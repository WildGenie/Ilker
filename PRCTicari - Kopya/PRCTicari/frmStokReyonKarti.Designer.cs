namespace PRCTicari
{
    partial class frmStokReyonKarti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStokReyonKarti));
            this.dgvReyonlar = new PRCTicari.MyDataGridView(this.components);
            this.colReyonKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReyonAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbKaydet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbKapat = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReyonlar)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReyonlar
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvReyonlar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReyonlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReyonlar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReyonKodu,
            this.colReyonAdi});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReyonlar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReyonlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReyonlar.Location = new System.Drawing.Point(0, 54);
            this.dgvReyonlar.Name = "dgvReyonlar";
            this.dgvReyonlar.RowHeadersWidth = 24;
            this.dgvReyonlar.Size = new System.Drawing.Size(350, 220);
            this.dgvReyonlar.TabIndex = 12;
            // 
            // colReyonKodu
            // 
            this.colReyonKodu.DataPropertyName = "Reyon_Kodu";
            this.colReyonKodu.HeaderText = "Reyon Kodu";
            this.colReyonKodu.Name = "colReyonKodu";
            // 
            // colReyonAdi
            // 
            this.colReyonAdi.DataPropertyName = "Reyon_Adi";
            this.colReyonAdi.HeaderText = "Reyon Adı";
            this.colReyonAdi.Name = "colReyonAdi";
            this.colReyonAdi.Width = 200;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusStrip1.BackgroundImage")));
            this.statusStrip1.Location = new System.Drawing.Point(0, 274);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(350, 22);
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
            this.toolStrip1.Size = new System.Drawing.Size(350, 54);
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
            // frmStokReyonKarti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(350, 296);
            this.Controls.Add(this.dgvReyonlar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmStokReyonKarti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Reyon Kartı";
            this.Shown += new System.EventHandler(this.frmStokReyonKarti_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReyonlar)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyDataGridView dgvReyonlar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbKaydet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbKapat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReyonKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReyonAdi;
    }
}