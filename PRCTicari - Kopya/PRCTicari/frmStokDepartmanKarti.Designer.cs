namespace PRCTicari
{
    partial class frmStokDepartmanKarti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStokDepartmanKarti));
            this.dgvDepartmanlar = new PRCTicari.MyDataGridView(this.components);
            this.colDepartmanKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmanAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbKaydet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbKapat = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartmanlar)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDepartmanlar
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDepartmanlar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDepartmanlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartmanlar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDepartmanKodu,
            this.colDepartmanAdi});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDepartmanlar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDepartmanlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepartmanlar.Location = new System.Drawing.Point(0, 54);
            this.dgvDepartmanlar.Name = "dgvDepartmanlar";
            this.dgvDepartmanlar.RowHeadersWidth = 24;
            this.dgvDepartmanlar.Size = new System.Drawing.Size(362, 220);
            this.dgvDepartmanlar.TabIndex = 12;
            // 
            // colDepartmanKodu
            // 
            this.colDepartmanKodu.DataPropertyName = "Departman_Kodu";
            this.colDepartmanKodu.HeaderText = "Departman Kodu";
            this.colDepartmanKodu.Name = "colDepartmanKodu";
            this.colDepartmanKodu.Width = 110;
            // 
            // colDepartmanAdi
            // 
            this.colDepartmanAdi.DataPropertyName = "Departman_Adi";
            this.colDepartmanAdi.HeaderText = "Departman Adı";
            this.colDepartmanAdi.Name = "colDepartmanAdi";
            this.colDepartmanAdi.Width = 200;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusStrip1.BackgroundImage")));
            this.statusStrip1.Location = new System.Drawing.Point(0, 274);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(362, 22);
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
            this.toolStrip1.Size = new System.Drawing.Size(362, 54);
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
            // frmStokDepartmanKarti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(362, 296);
            this.Controls.Add(this.dgvDepartmanlar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmStokDepartmanKarti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Departman Kartı";
            this.Shown += new System.EventHandler(this.frmStokDepartmanKarti_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartmanlar)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyDataGridView dgvDepartmanlar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbKaydet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbKapat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmanKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmanAdi;
    }
}