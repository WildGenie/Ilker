namespace PRCTicari
{
    partial class frmMasrafIslem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasrafIslem));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlAnaBaslik = new System.Windows.Forms.Panel();
            this.cbBelgeTipi = new System.Windows.Forms.ComboBox();
            this.cbParaBirimi = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFisSaati = new System.Windows.Forms.DateTimePicker();
            this.dtpFisTarihi = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpBelgeTarihi = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBelgeNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSilindi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbIsyeriKodu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFisNo = new System.Windows.Forms.TextBox();
            this.pnlBaslik = new System.Windows.Forms.Panel();
            this.btnSecFisNo = new System.Windows.Forms.Button();
            this.pnlAltToplam = new System.Windows.Forms.Panel();
            this.txtBakiye = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtToplamAlacak = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtToplamBorc = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblBakiyeTipi = new System.Windows.Forms.Label();
            this.btnIleri = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            this.dgvKalemler = new PRCTicari.MyDataGridView(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbKaydet = new System.Windows.Forms.ToolStripButton();
            this.tsbSil = new System.Windows.Forms.ToolStripButton();
            this.tsbVazgec = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbKapat = new System.Windows.Forms.ToolStripButton();
            this.lblUnvani = new System.Windows.Forms.Label();
            this.btnSecCariKodu = new System.Windows.Forms.Button();
            this.txtCariKodu = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSecKasaKodu = new System.Windows.Forms.Button();
            this.txtKasaKodu = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.colMasrafKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSecMasrafKodu = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colMasrafAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKdv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSecKdv = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colBorcTutari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlacakTutari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMasrafNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKdvTutari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMasrafTipi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAnaBaslik.SuspendLayout();
            this.pnlBaslik.SuspendLayout();
            this.pnlAltToplam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKalemler)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAnaBaslik
            // 
            this.pnlAnaBaslik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAnaBaslik.Controls.Add(this.btnSecKasaKodu);
            this.pnlAnaBaslik.Controls.Add(this.txtKasaKodu);
            this.pnlAnaBaslik.Controls.Add(this.label19);
            this.pnlAnaBaslik.Controls.Add(this.lblUnvani);
            this.pnlAnaBaslik.Controls.Add(this.btnSecCariKodu);
            this.pnlAnaBaslik.Controls.Add(this.txtCariKodu);
            this.pnlAnaBaslik.Controls.Add(this.label11);
            this.pnlAnaBaslik.Controls.Add(this.cbBelgeTipi);
            this.pnlAnaBaslik.Controls.Add(this.cbParaBirimi);
            this.pnlAnaBaslik.Controls.Add(this.label7);
            this.pnlAnaBaslik.Controls.Add(this.dtpFisSaati);
            this.pnlAnaBaslik.Controls.Add(this.dtpFisTarihi);
            this.pnlAnaBaslik.Controls.Add(this.label6);
            this.pnlAnaBaslik.Controls.Add(this.dtpBelgeTarihi);
            this.pnlAnaBaslik.Controls.Add(this.label5);
            this.pnlAnaBaslik.Controls.Add(this.txtBelgeNo);
            this.pnlAnaBaslik.Controls.Add(this.label4);
            this.pnlAnaBaslik.Controls.Add(this.label3);
            this.pnlAnaBaslik.Controls.Add(this.lblSilindi);
            this.pnlAnaBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAnaBaslik.Location = new System.Drawing.Point(0, 54);
            this.pnlAnaBaslik.Name = "pnlAnaBaslik";
            this.pnlAnaBaslik.Size = new System.Drawing.Size(1080, 111);
            this.pnlAnaBaslik.TabIndex = 1;
            // 
            // cbBelgeTipi
            // 
            this.cbBelgeTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBelgeTipi.FormattingEnabled = true;
            this.cbBelgeTipi.Location = new System.Drawing.Point(281, 31);
            this.cbBelgeTipi.Name = "cbBelgeTipi";
            this.cbBelgeTipi.Size = new System.Drawing.Size(121, 21);
            this.cbBelgeTipi.TabIndex = 3;
            this.cbBelgeTipi.SelectedIndexChanged += new System.EventHandler(this.txtBelgeNo_TextChanged);
            // 
            // cbParaBirimi
            // 
            this.cbParaBirimi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParaBirimi.FormattingEnabled = true;
            this.cbParaBirimi.Location = new System.Drawing.Point(477, 31);
            this.cbParaBirimi.Name = "cbParaBirimi";
            this.cbParaBirimi.Size = new System.Drawing.Size(128, 21);
            this.cbParaBirimi.TabIndex = 6;
            this.cbParaBirimi.SelectedIndexChanged += new System.EventHandler(this.txtBelgeNo_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(418, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Para Birimi:";
            // 
            // dtpFisSaati
            // 
            this.dtpFisSaati.CustomFormat = "HH:mm";
            this.dtpFisSaati.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFisSaati.Location = new System.Drawing.Point(145, 59);
            this.dtpFisSaati.Name = "dtpFisSaati";
            this.dtpFisSaati.Size = new System.Drawing.Size(54, 20);
            this.dtpFisSaati.TabIndex = 1;
            this.dtpFisSaati.ValueChanged += new System.EventHandler(this.txtBelgeNo_TextChanged);
            // 
            // dtpFisTarihi
            // 
            this.dtpFisTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFisTarihi.Location = new System.Drawing.Point(70, 59);
            this.dtpFisTarihi.Name = "dtpFisTarihi";
            this.dtpFisTarihi.Size = new System.Drawing.Size(74, 20);
            this.dtpFisTarihi.TabIndex = 0;
            this.dtpFisTarihi.ValueChanged += new System.EventHandler(this.txtBelgeNo_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Fiş Tarihi:";
            // 
            // dtpBelgeTarihi
            // 
            this.dtpBelgeTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBelgeTarihi.Location = new System.Drawing.Point(281, 81);
            this.dtpBelgeTarihi.Name = "dtpBelgeTarihi";
            this.dtpBelgeTarihi.Size = new System.Drawing.Size(121, 20);
            this.dtpBelgeTarihi.TabIndex = 5;
            this.dtpBelgeTarihi.ValueChanged += new System.EventHandler(this.txtBelgeNo_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Belge Tarihi:";
            // 
            // txtBelgeNo
            // 
            this.txtBelgeNo.Location = new System.Drawing.Point(281, 56);
            this.txtBelgeNo.Name = "txtBelgeNo";
            this.txtBelgeNo.Size = new System.Drawing.Size(121, 20);
            this.txtBelgeNo.TabIndex = 4;
            this.txtBelgeNo.TextChanged += new System.EventHandler(this.txtBelgeNo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Belge No:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Belge Tipi:";
            // 
            // lblSilindi
            // 
            this.lblSilindi.AutoSize = true;
            this.lblSilindi.BackColor = System.Drawing.Color.Silver;
            this.lblSilindi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSilindi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSilindi.ForeColor = System.Drawing.Color.Red;
            this.lblSilindi.Location = new System.Drawing.Point(89, 81);
            this.lblSilindi.Name = "lblSilindi";
            this.lblSilindi.Size = new System.Drawing.Size(80, 26);
            this.lblSilindi.TabIndex = 28;
            this.lblSilindi.Text = "SİLİNDİ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "İşyeri Kodu:";
            // 
            // cbIsyeriKodu
            // 
            this.cbIsyeriKodu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsyeriKodu.FormattingEnabled = true;
            this.cbIsyeriKodu.Location = new System.Drawing.Point(66, 3);
            this.cbIsyeriKodu.Name = "cbIsyeriKodu";
            this.cbIsyeriKodu.Size = new System.Drawing.Size(128, 21);
            this.cbIsyeriKodu.TabIndex = 0;
            this.cbIsyeriKodu.SelectedIndexChanged += new System.EventHandler(this.cbIsyeriKodu_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fiş No:";
            // 
            // txtFisNo
            // 
            this.txtFisNo.Location = new System.Drawing.Point(66, 28);
            this.txtFisNo.Name = "txtFisNo";
            this.txtFisNo.Size = new System.Drawing.Size(52, 20);
            this.txtFisNo.TabIndex = 1;
            this.txtFisNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFisNo_KeyDown);
            // 
            // pnlBaslik
            // 
            this.pnlBaslik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBaslik.Controls.Add(this.btnSecFisNo);
            this.pnlBaslik.Controls.Add(this.cbIsyeriKodu);
            this.pnlBaslik.Controls.Add(this.label1);
            this.pnlBaslik.Controls.Add(this.txtFisNo);
            this.pnlBaslik.Controls.Add(this.label2);
            this.pnlBaslik.Location = new System.Drawing.Point(4, 58);
            this.pnlBaslik.Name = "pnlBaslik";
            this.pnlBaslik.Size = new System.Drawing.Size(205, 53);
            this.pnlBaslik.TabIndex = 0;
            // 
            // btnSecFisNo
            // 
            this.btnSecFisNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecFisNo.Location = new System.Drawing.Point(118, 27);
            this.btnSecFisNo.Name = "btnSecFisNo";
            this.btnSecFisNo.Size = new System.Drawing.Size(25, 22);
            this.btnSecFisNo.TabIndex = 4;
            this.btnSecFisNo.TabStop = false;
            this.btnSecFisNo.Text = "...";
            this.btnSecFisNo.UseVisualStyleBackColor = true;
            this.btnSecFisNo.Click += new System.EventHandler(this.btnSecFisNo_Click);
            // 
            // pnlAltToplam
            // 
            this.pnlAltToplam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAltToplam.Controls.Add(this.txtBakiye);
            this.pnlAltToplam.Controls.Add(this.label10);
            this.pnlAltToplam.Controls.Add(this.txtToplamAlacak);
            this.pnlAltToplam.Controls.Add(this.label8);
            this.pnlAltToplam.Controls.Add(this.txtToplamBorc);
            this.pnlAltToplam.Controls.Add(this.label15);
            this.pnlAltToplam.Controls.Add(this.txtAciklama);
            this.pnlAltToplam.Controls.Add(this.label9);
            this.pnlAltToplam.Controls.Add(this.lblBakiyeTipi);
            this.pnlAltToplam.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAltToplam.Location = new System.Drawing.Point(0, 386);
            this.pnlAltToplam.Name = "pnlAltToplam";
            this.pnlAltToplam.Size = new System.Drawing.Size(1080, 105);
            this.pnlAltToplam.TabIndex = 3;
            // 
            // txtBakiye
            // 
            this.txtBakiye.BackColor = System.Drawing.SystemColors.Window;
            this.txtBakiye.Location = new System.Drawing.Point(447, 58);
            this.txtBakiye.Name = "txtBakiye";
            this.txtBakiye.ReadOnly = true;
            this.txtBakiye.Size = new System.Drawing.Size(121, 20);
            this.txtBakiye.TabIndex = 20;
            this.txtBakiye.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(405, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Bakiye:";
            // 
            // txtToplamAlacak
            // 
            this.txtToplamAlacak.BackColor = System.Drawing.SystemColors.Window;
            this.txtToplamAlacak.Location = new System.Drawing.Point(447, 32);
            this.txtToplamAlacak.Name = "txtToplamAlacak";
            this.txtToplamAlacak.ReadOnly = true;
            this.txtToplamAlacak.Size = new System.Drawing.Size(121, 20);
            this.txtToplamAlacak.TabIndex = 18;
            this.txtToplamAlacak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(366, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Toplam Alacak:";
            // 
            // txtToplamBorc
            // 
            this.txtToplamBorc.BackColor = System.Drawing.SystemColors.Window;
            this.txtToplamBorc.Location = new System.Drawing.Point(447, 6);
            this.txtToplamBorc.Name = "txtToplamBorc";
            this.txtToplamBorc.ReadOnly = true;
            this.txtToplamBorc.Size = new System.Drawing.Size(121, 20);
            this.txtToplamBorc.TabIndex = 4;
            this.txtToplamBorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(377, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Toplam Borç:";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(61, 6);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(296, 92);
            this.txtAciklama.TabIndex = 0;
            this.txtAciklama.TextChanged += new System.EventHandler(this.txtBelgeNo_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Açıklama:";
            // 
            // lblBakiyeTipi
            // 
            this.lblBakiyeTipi.AutoSize = true;
            this.lblBakiyeTipi.Location = new System.Drawing.Point(567, 61);
            this.lblBakiyeTipi.Name = "lblBakiyeTipi";
            this.lblBakiyeTipi.Size = new System.Drawing.Size(0, 13);
            this.lblBakiyeTipi.TabIndex = 22;
            // 
            // btnIleri
            // 
            this.btnIleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIleri.Location = new System.Drawing.Point(175, 86);
            this.btnIleri.Name = "btnIleri";
            this.btnIleri.Size = new System.Drawing.Size(25, 22);
            this.btnIleri.TabIndex = 13;
            this.btnIleri.TabStop = false;
            this.btnIleri.Tag = "1";
            this.btnIleri.Text = ">";
            this.btnIleri.UseVisualStyleBackColor = true;
            this.btnIleri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // btnGeri
            // 
            this.btnGeri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeri.Location = new System.Drawing.Point(151, 86);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(25, 22);
            this.btnGeri.TabIndex = 12;
            this.btnGeri.TabStop = false;
            this.btnGeri.Tag = "0";
            this.btnGeri.Text = "<";
            this.btnGeri.UseVisualStyleBackColor = true;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // dgvKalemler
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvKalemler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKalemler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKalemler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMasrafKodu,
            this.colSecMasrafKodu,
            this.colMasrafAdi,
            this.colKdv,
            this.colSecKdv,
            this.colBorcTutari,
            this.colAlacakTutari,
            this.colAciklama,
            this.colMasrafNo,
            this.colKdvTutari,
            this.colMasrafTipi});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKalemler.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvKalemler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKalemler.Location = new System.Drawing.Point(0, 165);
            this.dgvKalemler.Name = "dgvKalemler";
            this.dgvKalemler.RowHeadersWidth = 24;
            this.dgvKalemler.Size = new System.Drawing.Size(1080, 221);
            this.dgvKalemler.TabIndex = 2;
            this.dgvKalemler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKalemler_CellClick);
            this.dgvKalemler.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKalemler_CellEndEdit);
            this.dgvKalemler.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvKalemler_CellPainting);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusStrip1.BackgroundImage")));
            this.statusStrip1.Location = new System.Drawing.Point(0, 491);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1080, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
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
            this.toolStrip1.Size = new System.Drawing.Size(1080, 54);
            this.toolStrip1.TabIndex = 7;
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
            // lblUnvani
            // 
            this.lblUnvani.AutoSize = true;
            this.lblUnvani.Location = new System.Drawing.Point(405, 11);
            this.lblUnvani.Name = "lblUnvani";
            this.lblUnvani.Size = new System.Drawing.Size(0, 13);
            this.lblUnvani.TabIndex = 32;
            // 
            // btnSecCariKodu
            // 
            this.btnSecCariKodu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecCariKodu.Location = new System.Drawing.Point(377, 6);
            this.btnSecCariKodu.Name = "btnSecCariKodu";
            this.btnSecCariKodu.Size = new System.Drawing.Size(25, 22);
            this.btnSecCariKodu.TabIndex = 30;
            this.btnSecCariKodu.TabStop = false;
            this.btnSecCariKodu.Text = "...";
            this.btnSecCariKodu.UseVisualStyleBackColor = true;
            this.btnSecCariKodu.Click += new System.EventHandler(this.btnSecCariKodu_Click);
            // 
            // txtCariKodu
            // 
            this.txtCariKodu.Location = new System.Drawing.Point(281, 7);
            this.txtCariKodu.Name = "txtCariKodu";
            this.txtCariKodu.Size = new System.Drawing.Size(96, 20);
            this.txtCariKodu.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(225, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Cari Kodu:";
            // 
            // btnSecKasaKodu
            // 
            this.btnSecKasaKodu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecKasaKodu.Location = new System.Drawing.Point(580, 55);
            this.btnSecKasaKodu.Name = "btnSecKasaKodu";
            this.btnSecKasaKodu.Size = new System.Drawing.Size(25, 22);
            this.btnSecKasaKodu.TabIndex = 40;
            this.btnSecKasaKodu.TabStop = false;
            this.btnSecKasaKodu.Text = "...";
            this.btnSecKasaKodu.UseVisualStyleBackColor = true;
            this.btnSecKasaKodu.Click += new System.EventHandler(this.btnSecKasaKodu_Click);
            // 
            // txtKasaKodu
            // 
            this.txtKasaKodu.BackColor = System.Drawing.SystemColors.Window;
            this.txtKasaKodu.Location = new System.Drawing.Point(477, 56);
            this.txtKasaKodu.Name = "txtKasaKodu";
            this.txtKasaKodu.Size = new System.Drawing.Size(103, 20);
            this.txtKasaKodu.TabIndex = 7;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(415, 60);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 13);
            this.label19.TabIndex = 39;
            this.label19.Text = "Kasa Kodu:";
            // 
            // colMasrafKodu
            // 
            this.colMasrafKodu.DataPropertyName = "Masraf_Kodu";
            this.colMasrafKodu.HeaderText = "Masraf Kodu";
            this.colMasrafKodu.Name = "colMasrafKodu";
            // 
            // colSecMasrafKodu
            // 
            this.colSecMasrafKodu.DataPropertyName = "Sec_Masraf_Kodu";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "...";
            this.colSecMasrafKodu.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSecMasrafKodu.HeaderText = "";
            this.colSecMasrafKodu.Name = "colSecMasrafKodu";
            this.colSecMasrafKodu.ReadOnly = true;
            this.colSecMasrafKodu.Width = 30;
            // 
            // colMasrafAdi
            // 
            this.colMasrafAdi.DataPropertyName = "Masraf_Adi";
            this.colMasrafAdi.HeaderText = "Masraf Adı";
            this.colMasrafAdi.Name = "colMasrafAdi";
            this.colMasrafAdi.ReadOnly = true;
            this.colMasrafAdi.Width = 200;
            // 
            // colKdv
            // 
            this.colKdv.DataPropertyName = "Kdv_Orani";
            this.colKdv.HeaderText = "Kdv";
            this.colKdv.Name = "colKdv";
            this.colKdv.ReadOnly = true;
            this.colKdv.Width = 50;
            // 
            // colSecKdv
            // 
            this.colSecKdv.DataPropertyName = "Sec_Kdv_Orani";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "...";
            this.colSecKdv.DefaultCellStyle = dataGridViewCellStyle3;
            this.colSecKdv.HeaderText = "";
            this.colSecKdv.Name = "colSecKdv";
            this.colSecKdv.ReadOnly = true;
            this.colSecKdv.Width = 30;
            // 
            // colBorcTutari
            // 
            this.colBorcTutari.DataPropertyName = "Borc_Tutari";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0.00;-#,##0.00;#.#";
            this.colBorcTutari.DefaultCellStyle = dataGridViewCellStyle4;
            this.colBorcTutari.HeaderText = "Borç Tutarı";
            this.colBorcTutari.Name = "colBorcTutari";
            // 
            // colAlacakTutari
            // 
            this.colAlacakTutari.DataPropertyName = "Alacak_Tutari";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,##0.00;-#,##0.00;#.#";
            this.colAlacakTutari.DefaultCellStyle = dataGridViewCellStyle5;
            this.colAlacakTutari.HeaderText = "Alacak Tutarı";
            this.colAlacakTutari.Name = "colAlacakTutari";
            // 
            // colAciklama
            // 
            this.colAciklama.DataPropertyName = "Aciklama";
            this.colAciklama.HeaderText = "Açıklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.Width = 200;
            // 
            // colMasrafNo
            // 
            this.colMasrafNo.DataPropertyName = "Masraf_No";
            this.colMasrafNo.HeaderText = "Masraf No";
            this.colMasrafNo.Name = "colMasrafNo";
            this.colMasrafNo.ReadOnly = true;
            this.colMasrafNo.Visible = false;
            // 
            // colKdvTutari
            // 
            this.colKdvTutari.DataPropertyName = "Kdv_Tutari";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "#,##0.00;-#,##0.00;#.#";
            this.colKdvTutari.DefaultCellStyle = dataGridViewCellStyle6;
            this.colKdvTutari.HeaderText = "Kdv Tutarı";
            this.colKdvTutari.Name = "colKdvTutari";
            this.colKdvTutari.ReadOnly = true;
            this.colKdvTutari.Visible = false;
            // 
            // colMasrafTipi
            // 
            this.colMasrafTipi.DataPropertyName = "Masraf_Tipi";
            this.colMasrafTipi.HeaderText = "Masraf Tipi";
            this.colMasrafTipi.Name = "colMasrafTipi";
            this.colMasrafTipi.Visible = false;
            // 
            // frmMasrafIslem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1080, 513);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.btnIleri);
            this.Controls.Add(this.pnlBaslik);
            this.Controls.Add(this.dgvKalemler);
            this.Controls.Add(this.pnlAltToplam);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlAnaBaslik);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmMasrafIslem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masraf İşlem";
            this.Shown += new System.EventHandler(this.frmMasrafIslem_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMasrafIslem_KeyDown);
            this.pnlAnaBaslik.ResumeLayout(false);
            this.pnlAnaBaslik.PerformLayout();
            this.pnlBaslik.ResumeLayout(false);
            this.pnlBaslik.PerformLayout();
            this.pnlAltToplam.ResumeLayout(false);
            this.pnlAltToplam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKalemler)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbKaydet;
        private System.Windows.Forms.ToolStripButton tsbSil;
        private System.Windows.Forms.ToolStripButton tsbVazgec;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbKapat;
        private System.Windows.Forms.Panel pnlAnaBaslik;
        private System.Windows.Forms.Panel pnlBaslik;
        private System.Windows.Forms.ComboBox cbIsyeriKodu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFisNo;
        private System.Windows.Forms.DateTimePicker dtpFisSaati;
        private System.Windows.Forms.DateTimePicker dtpFisTarihi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpBelgeTarihi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBelgeNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbBelgeTipi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbParaBirimi;
        private System.Windows.Forms.Label label7;
        private MyDataGridView dgvKalemler;
        private System.Windows.Forms.Panel pnlAltToplam;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtToplamBorc;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label lblSilindi;
        private System.Windows.Forms.Button btnSecFisNo;
        private System.Windows.Forms.Button btnIleri;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.TextBox txtBakiye;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtToplamAlacak;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBakiyeTipi;
        private System.Windows.Forms.Label lblUnvani;
        private System.Windows.Forms.Button btnSecCariKodu;
        private System.Windows.Forms.TextBox txtCariKodu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSecKasaKodu;
        private System.Windows.Forms.TextBox txtKasaKodu;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMasrafKodu;
        private System.Windows.Forms.DataGridViewButtonColumn colSecMasrafKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMasrafAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKdv;
        private System.Windows.Forms.DataGridViewButtonColumn colSecKdv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBorcTutari;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlacakTutari;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAciklama;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMasrafNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKdvTutari;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMasrafTipi;
    }
}