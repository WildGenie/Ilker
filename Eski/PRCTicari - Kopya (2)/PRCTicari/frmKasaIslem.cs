using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PRCTicari
{
    public partial class frmKasaIslem : Form
    {
        int intFisTipi = 0;
        clsFisTipleri.FisTipleri ftFisTipi;
        clsFisTipleri.IslemYonu iyIslemYonu = clsFisTipleri.IslemYonu.Yok;
        DataTable dtKalemler = new DataTable();
        BindingSource bsKalemler = new BindingSource();
        bool blnYeniKayit = true;
        bool blnSilindi = true;
        bool blnDegisti = false;

        public frmKasaIslem(clsFisTipleri.FisTipleri ftGetFisTipi)
        {
            InitializeComponent();

            ftFisTipi = ftGetFisTipi;
            intFisTipi = (int)ftFisTipi;
            iyIslemYonu = clsFisTipleri.fncIslemYonu(ftFisTipi);
            this.Text = clsFisTipleri.fncIslemText(ftFisTipi);

            clsGenel.prcdFillComboBox("Isyeri_Tanitimi", "Isyeri_Kodu", "Isyeri_Adi", new ComboBox[] { cbIsyeriKodu });
            clsGenel.prcdFillComboBox("Belge_Tipi_Tanitimi", "Belge_Tipi", "", new ComboBox[] { cbBelgeTipi }, true);
            clsGenel.prcdFillComboBox("Para_Birimi_Tanitimi", "Para_Birimi", "", new ComboBox[] { cbParaBirimi });

            cbIsyeriKodu.SelectedItemByCode(clsGenel.fncGetParameter("Isyeri_Kodu_FT" + intFisTipi.TOSTRING()));
            if (cbIsyeriKodu.SelectedIndex < 0) cbIsyeriKodu.SelectedItemByCode(clsGenel.fncGetParameter("Isyeri_Kodu"));
            if (cbIsyeriKodu.SelectedIndex < 0 && cbIsyeriKodu.Items.Count > 0) cbIsyeriKodu.SelectedIndex = 0;
            
            colMasrafKodu.Visible = ftFisTipi == clsFisTipleri.FisTipleri.KasaTediye;
            colSecMasrafKodu.Visible = colMasrafKodu.Visible;
            colMasrafAdi.Visible = colMasrafKodu.Visible;

            if (iyIslemYonu == clsFisTipleri.IslemYonu.Giris || iyIslemYonu == clsFisTipleri.IslemYonu.Cikis)
            {
                if (iyIslemYonu == clsFisTipleri.IslemYonu.Giris)
                {
                    colAlacakTutari.Visible = false;
                    colBorcTutari.HeaderText = "Tutarı";
                }
                else if (iyIslemYonu == clsFisTipleri.IslemYonu.Cikis)
                {
                    colBorcTutari.Visible = false;
                    colAlacakTutari.HeaderText = "Tutarı";
                }

                label15.Text = "Toplam Tutar:";
                label15.Left = txtToplamBorc.Left - label15.Width;
                label8.Visible = false;
                label10.Visible = false;
                txtToplamAlacak.Visible = false;
                txtBakiye.Visible = false;
            }
            else if (ftFisTipi == clsFisTipleri.FisTipleri.KasaVirman || ftFisTipi == clsFisTipleri.FisTipleri.KasaDevir)
            {
                colCariKodu.Visible = false;
                colUnvani.Visible = false;
            }
        }

        private void frmKasaIslem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.FocusNextControl();
            }
        }

        private void frmKasaIslem_Shown(object sender, EventArgs e)
        {
            blnDegisti = false;
            this.WindowState = FormWindowState.Maximized;
            fncVazgec();
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbIsyeriKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFisNo.Text = clsGenel.fncYeniFisNoGetir(ftFisTipi, cbIsyeriKodu.SelectedItemForCode().TOINT()).TOSTRING();
        }

        private void tsbVazgec_Click(object sender, EventArgs e)
        {
            fncVazgec();
        }

        private bool fncVazgec(bool blnMaxFisNo = true)
        {
            bool blnReturn = false;
            if ((blnDegisti && MessageBox.Show("Kaydetmeden çıkmak istediğinize emin misiniz?", "Vazgeç", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) || !blnDegisti)
            {
                prcdTemizle(blnMaxFisNo);
                prcdAktifPasifKontrol(false);
                blnReturn = true;
            }
            return blnReturn;
        }

        public void prcdAktifPasifKontrol(bool blnEnabled)
        {
            pnlBaslik.Enabled = !blnEnabled;
            pnlAnaBaslik.Enabled = blnEnabled;
            pnlAltToplam.Enabled = blnEnabled;
            dgvKalemler.Enabled = blnEnabled;
            tsbKaydet.Enabled = blnEnabled && !blnSilindi;
            tsbSil.Enabled = blnEnabled && !blnSilindi;
            tsbVazgec.Enabled = blnEnabled;
            lblSilindi.Visible = blnSilindi;

            if (blnEnabled)
                dtpFisTarihi.Focus();
            else
                txtFisNo.Focus();
        }

        public void prcdTemizle(bool blnMaxFisNo = true)
        {
            if (blnMaxFisNo)
                cbIsyeriKodu_SelectedIndexChanged(cbIsyeriKodu, new EventArgs());

            dtpFisTarihi.Value = DateTime.Now.Date;
            dtpFisSaati.Value = DateTime.Now;
            txtBelgeNo.Clear();
            dtpBelgeTarihi.Value = DateTime.Now.Date;
            txtAciklama.Clear();
            txtToplamBorc.Clear();
            txtToplamAlacak.Clear();
            txtBakiye.Clear();
            txtToplamBorc.Clear();

            cbBelgeTipi.SelectedItemByCode(clsGenel.fncGetParameter("Belge_Tipi_FT" + intFisTipi.TOSTRING(), (cbBelgeTipi.Items.Count > 0 ? cbBelgeTipi.Items[0].TOSTRING() : "")));
            cbParaBirimi.SelectedItemByCode(clsGenel.fncGetParameter("Para_Birimi", "TL"));

            dtKalemler.Rows.Clear();

            blnYeniKayit = true;
            blnSilindi = false;
            blnDegisti = false;
        }

        private void txtFisNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (cbIsyeriKodu.SelectedItemForCode().TOINT() != 0)
                {
                    if (txtFisNo.Text.Trim().TOINT() != 0)
                    {
                        SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                        cnn.Open();
                        SqlCommand cmd = cnn.CreateCommand();
                        cmd.CommandText = "SELECT IB.* " +
                                          "FROM Islem_Baslik AS IB " +
                                          "WHERE IB.Fis_Tipi = @Fis_Tipi AND IB.Isyeri_Kodu = @Isyeri_Kodu AND IB.Fis_No = @Fis_No";
                        cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                        cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode().TOINT());
                        cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.Trim().TOINT());
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            dtpFisTarihi.Value = reader["Fis_Tarihi"].TODATE();
                            dtpFisSaati.Value = reader["Fis_Saati"].TOTIME();
                            cbBelgeTipi.SelectedItemByCode(reader["Belge_Tipi"].TOSTRING());
                            txtBelgeNo.Text = reader["Belge_No"].TOSTRING();
                            dtpBelgeTarihi.Value = reader["Belge_Tarihi"].TODATE();
                            cbParaBirimi.SelectedItemByCode(reader["Para_Birimi"].TOSTRING());
                            txtAciklama.Text = reader["Aciklama"].TOSTRING();

                            blnSilindi = reader["Silindi"].TOINT() == 1;
                            blnYeniKayit = false;
                        }
                        reader.Close();
                        cmd.Parameters.Clear();

                        cmd.CommandText = "SELECT ID.Kasa_Kodu, '...' AS Sec_Kasa_Kodu, KT.Kasa_Adi, ID.Cari_No, CT.Cari_Kodu, '...' AS Sec_Cari_Kodu, ID.Masraf_Kodu, '...' AS Sec_Masraf_Kodu, MT.Masraf_Adi, CT.Unvani, Alacak_Tutari, Borc_Tutari, ID.Aciklama " +
                                          "FROM Islem_Detay_Kasa AS ID " +
                                          "LEFT OUTER JOIN Kasa_Tanitimi AS KT ON KT.Silindi = 0 AND KT.Kasa_Kodu = ID.Kasa_Kodu " +
                                          "LEFT OUTER JOIN Cari_Tanitimi AS CT ON CT.Silindi = 0 AND CT.Cari_No = ID.Cari_No " +
                                          "LEFT OUTER JOIN Masraf_Tanitimi AS MT ON MT.Silindi = 0 AND MT.Masraf_Kodu = ID.Masraf_Kodu " +
                                          "WHERE ID.Fis_Tipi = @Fis_Tipi AND ID.Isyeri_Kodu = @Isyeri_Kodu AND ID.Fis_No = @Fis_No " +
                                          "ORDER BY ID.Fis_Sira";
                        cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                        cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode().TOINT());
                        cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.Trim().TOINT());

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dtKalemler);
                        sda.Dispose();
                        cmd.Dispose();
                        cnn.Close();
                        bsKalemler.DataSource = dtKalemler;
                        dgvKalemler.DataSource = bsKalemler;
                        prcdGenelToplam();
                        prcdAktifPasifKontrol(true);
                        blnDegisti = false;
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bir fiş numarası giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir işyeri kodu seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void dgvKalemler_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bsKalemler.ResetBindings(true);

            if (dgvKalemler.Columns[e.ColumnIndex].Name == colBorcTutari.Name ||
            dgvKalemler.Columns[e.ColumnIndex].Name == colAlacakTutari.Name)
            {
                if (dgvKalemler.Columns[e.ColumnIndex].Name == colBorcTutari.Name)
                    dgvKalemler.Rows[e.RowIndex].Cells[colAlacakTutari.Name].Value = 0;

                if (dgvKalemler.Columns[e.ColumnIndex].Name == colAlacakTutari.Name)
                    dgvKalemler.Rows[e.RowIndex].Cells[colBorcTutari.Name].Value = 0;

                prcdGenelToplam();
            }
            else if (dgvKalemler.Columns[e.ColumnIndex].Name == colKasaKodu.Name)
            {
                prcdKasaBilgiGetir();
            }
            else if (dgvKalemler.Columns[e.ColumnIndex].Name == colCariKodu.Name)
            {
                prcdCariBilgiGetir();
            }
            else if (dgvKalemler.Columns[e.ColumnIndex].Name == colMasrafKodu.Name)
            {
                prcdMasrafBilgiGetir();
            }

            txtBelgeNo_TextChanged(txtBelgeNo, new EventArgs());
        }

        private void dgvKalemler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (dgvKalemler.Columns[e.ColumnIndex].Name == colSecKasaKodu.Name)
                {
                    object o = clsXKod.fncSECKasa();
                    if (o != null)
                    {
                        dgvKalemler.CurrentRow.Cells[colKasaKodu.Name].Value = o.TOSTRING();
                        bsKalemler.ResetBindings(true);
                        prcdKasaBilgiGetir();
                    }
                }
                else if (dgvKalemler.Columns[e.ColumnIndex].Name == colSecCariKodu.Name)
                {
                    object o = clsXKod.fncSECCari();
                    if (o != null)
                    {
                        dgvKalemler.CurrentRow.Cells[colCariKodu.Name].Value = o.TOSTRING();
                        bsKalemler.ResetBindings(true);
                        prcdCariBilgiGetir();
                    }
                }
                else if (dgvKalemler.Columns[e.ColumnIndex].Name == colSecMasrafKodu.Name)
                {
                    object o = clsXKod.fncSECMasraf(true);
                    if (o != null)
                    {
                        dgvKalemler.CurrentRow.Cells[colMasrafKodu.Name].Value = o.TOSTRING();
                        bsKalemler.ResetBindings(true);
                        prcdMasrafBilgiGetir();
                    }
                }
            }
        }

        private void prcdKasaBilgiGetir()
        {
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Kasa_Tanitimi WHERE Silindi = 0 AND Kasa_Kodu = @Kasa_Kodu";
            cmd.Parameters.AddWithValue("@Kasa_Kodu", dgvKalemler.CurrentRow.Cells[colKasaKodu.Name].Value);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dgvKalemler.CurrentRow.Cells["colSecKasaKodu"].Value = "...";
                dgvKalemler.CurrentRow.Cells["colKasaAdi"].Value = reader["Kasa_Adi"];
            }
            else
            {
                dgvKalemler.CurrentRow.Cells["colSecKasaKodu"].Value = "...";
                dgvKalemler.CurrentRow.Cells["colKasaAdi"].Value = "";
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
        }

        private void prcdCariBilgiGetir()
        {
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Cari_Tanitimi WHERE Silindi = 0 AND Cari_Kodu = @Cari_Kodu";
            cmd.Parameters.AddWithValue("@Cari_Kodu", dgvKalemler.CurrentRow.Cells[colCariKodu.Name].Value);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dgvKalemler.CurrentRow.Cells["colCariNo"].Value = reader["Cari_No"];
                dgvKalemler.CurrentRow.Cells["colSecCariKodu"].Value = "...";
                dgvKalemler.CurrentRow.Cells["colUnvani"].Value = reader["Unvani"];
            }
            else
            {
                dgvKalemler.CurrentRow.Cells["colCariNo"].Value = 0;
                dgvKalemler.CurrentRow.Cells["colSecCariKodu"].Value = "...";
                dgvKalemler.CurrentRow.Cells["colUnvani"].Value = "";
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
            
            dgvKalemler.CurrentRow.Cells["colMasrafKodu"].Value = "";
            dgvKalemler.CurrentRow.Cells["colMasrafAdi"].Value = "";
        }

        private void prcdMasrafBilgiGetir()
        {
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Masraf_Tanitimi WHERE Islem = 1 AND Masraf_Kodu = @Masraf_Kodu";
            cmd.Parameters.AddWithValue("@Masraf_Kodu", dgvKalemler.CurrentRow.Cells[colMasrafKodu.Name].Value);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dgvKalemler.CurrentRow.Cells["colSecMasrafKodu"].Value = "...";
                dgvKalemler.CurrentRow.Cells["colMasrafAdi"].Value = reader["Masraf_Adi"];
            }
            else
            {
                dgvKalemler.CurrentRow.Cells["colSecMasrafKodu"].Value = "...";
                dgvKalemler.CurrentRow.Cells["colMasrafAdi"].Value = "";
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();

            dgvKalemler.CurrentRow.Cells["colCariNo"].Value = 0;
            dgvKalemler.CurrentRow.Cells["colCariKodu"].Value = "";
            dgvKalemler.CurrentRow.Cells["colUnvani"].Value = "";
        }

        bool blnTutarEsit = true;
        private void prcdGenelToplam()
        {
            double dblBorcToplam = dtKalemler.Compute("SUM(Borc_Tutari)", "").TODOUBLE();
            double dblAlacakToplam = dtKalemler.Compute("SUM(Alacak_Tutari)", "").TODOUBLE();
            double dblBakiye = dblBorcToplam - dblAlacakToplam;

            blnTutarEsit = (((ftFisTipi == clsFisTipleri.FisTipleri.KasaVirman) && dblBorcToplam == dblAlacakToplam) || ftFisTipi != clsFisTipleri.FisTipleri.KasaVirman );

            if (iyIslemYonu == clsFisTipleri.IslemYonu.Cikis || iyIslemYonu == clsFisTipleri.IslemYonu.Giris)
            {
                txtToplamBorc.Text = Math.Abs(dblBakiye).ToString(clsGenel.strDoubleFormatTwo);
            }
            else
            {
                txtToplamBorc.Text = dblBorcToplam.ToString(clsGenel.strDoubleFormatTwo);
                txtToplamAlacak.Text = dblAlacakToplam.ToString(clsGenel.strDoubleFormatTwo);
                txtBakiye.Text = Math.Abs(dblBakiye).ToString(clsGenel.strDoubleFormatTwo);
                lblBakiyeTipi.Text = dblBakiye < 0 ? "Alacaklı" : (dblBakiye > 0 ? "Borçlu" : "");
            }
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            if (fncKaydet())
            {
                fncVazgec();
            }
        }

        private void tsbSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu fişi silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.Transaction = cnn.BeginTransaction();
                try
                {
                    cmd.CommandText = "UPDATE Islem_Baslik SET Silindi = @Silindi_Yeni, Delete_User = @Delete_User, Delete_Date = @Delete_Date WHERE Silindi = @Silindi AND Fis_Tipi = @Fis_Tipi AND Isyeri_Kodu = @Isyeri_Kodu AND Fis_No = @Fis_No";
                    cmd.Parameters.AddWithValue("@Silindi_Yeni", 1);
                    cmd.Parameters.AddWithValue("@Delete_User", clsGenel.strKullaniciKodu);
                    cmd.Parameters.AddWithValue("@Delete_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Silindi", 0);
                    cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                    cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                    cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE Islem_Detay_Kasa SET Silindi = @Silindi_Yeni WHERE Silindi = @Silindi AND Fis_Tipi = @Fis_Tipi AND Isyeri_Kodu = @Isyeri_Kodu AND Fis_No = @Fis_No";
                    cmd.Parameters.AddWithValue("@Silindi_Yeni", 1);
                    cmd.Parameters.AddWithValue("@Silindi", 0);
                    cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                    cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                    cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE Islem_Detay_Cari SET Silindi = @Silindi_Yeni WHERE Silindi = @Silindi AND Fis_Tipi = @Fis_Tipi AND Isyeri_Kodu = @Isyeri_Kodu AND Fis_No = @Fis_No";
                    cmd.Parameters.AddWithValue("@Silindi_Yeni", 1);
                    cmd.Parameters.AddWithValue("@Silindi", 0);
                    cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                    cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                    cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE Islem_Detay_Masraf SET Silindi = @Silindi_Yeni WHERE Silindi = @Silindi AND Fis_Tipi = @Fis_Tipi AND Isyeri_Kodu = @Isyeri_Kodu AND Fis_No = @Fis_No";
                    cmd.Parameters.AddWithValue("@Silindi_Yeni", 1);
                    cmd.Parameters.AddWithValue("@Silindi", 0);
                    cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                    cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                    cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                    cmd.ExecuteNonQuery();

                    cmd.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    cmd.Transaction.Rollback();
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                cmd.Dispose();
                cnn.Close();
            }
        }

        private bool fncKaydet()
        {
            bool blnReturn = false;

            dgvKalemler.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (!blnTutarEsit)
            {
                MessageBox.Show("Borç tutarı ve alacak tutarı eşit olmalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return blnReturn;
            }

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.Transaction = cnn.BeginTransaction();
            try
            {
                if (blnYeniKayit)
                {
                    cbIsyeriKodu_SelectedIndexChanged(cbIsyeriKodu, new EventArgs());
                    cmd.CommandText = "INSERT INTO Islem_Baslik (Fis_Tarihi, Fis_Saati, Belge_Tipi, Belge_No, Belge_Tarihi, Para_Birimi, Aciklama, Insert_User, Inser_Date, Silindi, Fis_Tipi, Isyeri_Kodu, Fis_No) " +
                                      "VALUES (@Fis_Tarihi, @Fis_Saati, @Belge_Tipi, @Belge_No, @Belge_Tarihi, @Para_Birimi, @Aciklama, @Kullanici, @Zaman, @Silindi, @Fis_Tipi, @Isyeri_Kodu, @Fis_No)";
                }
                else
                {
                    cmd.CommandText = "UPDATE Islem_Baslik SET Fis_Tarihi = @Fis_Tarihi, Fis_Saati = @Fis_Saati, Belge_Tipi = @Belge_Tipi, Belge_No = @Belge_No, Belge_Tarihi = @Belge_Tarihi, Para_Birimi = @Para_Birimi, Aciklama = @Aciklama, Update_User = @Kullanici, Update_Date = @Zaman " +
                                      "WHERE Silindi = @Silindi AND Fis_Tipi = @Fis_Tipi AND Isyeri_Kodu = @Isyeri_Kodu AND Fis_No = @Fis_No";
                }
                cmd.Parameters.AddWithValue("@Fis_Tarihi", dtpFisTarihi.Value.TODATE());
                cmd.Parameters.AddWithValue("@Fis_Saati", dtpFisSaati.Value.TOTIME());
                cmd.Parameters.AddWithValue("@Belge_Tipi", cbBelgeTipi.SelectedItemForCode());
                cmd.Parameters.AddWithValue("@Belge_No", txtBelgeNo.Text.Trim());
                cmd.Parameters.AddWithValue("@Belge_Tarihi", dtpBelgeTarihi.Value.TODATE());
                cmd.Parameters.AddWithValue("@Para_Birimi", cbParaBirimi.SelectedItemForCode());
                cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.Trim());
                cmd.Parameters.AddWithValue("@Kullanici", clsGenel.strKullaniciKodu);
                cmd.Parameters.AddWithValue("@Zaman", DateTime.Now);
                cmd.Parameters.AddWithValue("@Silindi", 0);
                cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                cmd.CommandText = "DELETE FROM Islem_Detay_Kasa WHERE Silindi = @Silindi AND Fis_Tipi = @Fis_Tipi AND Isyeri_Kodu = @Isyeri_Kodu AND Fis_No = @Fis_No";
                cmd.Parameters.AddWithValue("@Silindi", 0);
                cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM Islem_Detay_Cari WHERE Silindi = @Silindi AND Fis_Tipi = @Fis_Tipi AND Isyeri_Kodu = @Isyeri_Kodu AND Fis_No = @Fis_No";
                cmd.Parameters.AddWithValue("@Silindi", 0);
                cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM Islem_Detay_Masraf WHERE Silindi = @Silindi AND Fis_Tipi = @Fis_Tipi AND Isyeri_Kodu = @Isyeri_Kodu AND Fis_No = @Fis_No";
                cmd.Parameters.AddWithValue("@Silindi", 0);
                cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                for (int iSira = 0; iSira < dtKalemler.Rows.Count; iSira++)
                {
                    DataRow DR = dtKalemler.Rows[iSira];
                    double dblAlacakTutari = !string.IsNullOrEmpty(DR["Kasa_Kodu"].TOSTRING()) ? DR["Alacak_Tutari"].TODOUBLE() : 0;
                    double dblBorcTutari = !string.IsNullOrEmpty(DR["Kasa_Kodu"].TOSTRING()) ? DR["Borc_Tutari"].TODOUBLE() : 0;

                    clsFisTipleri.IslemYonu iyIslemYonuS = (iyIslemYonu == clsFisTipleri.IslemYonu.Yok ? (DR["Borc_Tutari"].TODOUBLE() != 0 ? clsFisTipleri.IslemYonu.Giris : clsFisTipleri.IslemYonu.Cikis) : iyIslemYonu);

                    cmd.CommandText = "INSERT INTO Islem_Detay_Kasa (Fis_Tarihi, Fis_Saati, Kasa_Kodu, Cari_No, Masraf_Kodu, Alacak_Tutari, Alacak_Tutari_Baslik, Alacak_Tutari_Kart, Alacak_Tutari_Sistem, Borc_Tutari, Borc_Tutari_Baslik, Borc_Tutari_Kart, Borc_Tutari_Sistem, Aciklama, Silindi, Fis_Tipi, Isyeri_Kodu, Fis_No, Fis_Sira, Islem_Yonu) " +
                                      "VALUES (@Fis_Tarihi, @Fis_Saati, @Kasa_Kodu, @Cari_No, @Masraf_Kodu, @Alacak_Tutari, @Alacak_Tutari_Baslik, @Alacak_Tutari_Kart, @Alacak_Tutari_Sistem, @Borc_Tutari, @Borc_Tutari_Baslik, @Borc_Tutari_Kart, @Borc_Tutari_Sistem, @Aciklama, @Silindi, @Fis_Tipi, @Isyeri_Kodu, @Fis_No, @Fis_Sira, @Islem_Yonu)";
                    cmd.Parameters.AddWithValue("@Fis_Tarihi", dtpFisTarihi.Value.TODATE());
                    cmd.Parameters.AddWithValue("@Fis_Saati", dtpFisSaati.Value.TOTIME());
                    cmd.Parameters.AddWithValue("@Kasa_Kodu", DR["Kasa_Kodu"].TOSTRING());
                    cmd.Parameters.AddWithValue("@Cari_No", DR["Cari_No"].TOINT());
                    cmd.Parameters.AddWithValue("@Masraf_Kodu", DR["Masraf_Kodu"].TOSTRING());

                    cmd.Parameters.AddWithValue("@Alacak_Tutari", dblAlacakTutari);
                    cmd.Parameters.AddWithValue("@Alacak_Tutari_Baslik", dblAlacakTutari);
                    cmd.Parameters.AddWithValue("@Alacak_Tutari_Kart", dblAlacakTutari);
                    cmd.Parameters.AddWithValue("@Alacak_Tutari_Sistem", dblAlacakTutari);
                    cmd.Parameters.AddWithValue("@Borc_Tutari", dblBorcTutari);
                    cmd.Parameters.AddWithValue("@Borc_Tutari_Baslik", dblBorcTutari);
                    cmd.Parameters.AddWithValue("@Borc_Tutari_Kart", dblBorcTutari);
                    cmd.Parameters.AddWithValue("@Borc_Tutari_Sistem", dblBorcTutari);

                    cmd.Parameters.AddWithValue("@Aciklama", DR["Aciklama"].TOSTRING());
                    cmd.Parameters.AddWithValue("@Silindi", 0);
                    cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                    cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                    cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                    cmd.Parameters.AddWithValue("@Fis_Sira", iSira + 1);
                    cmd.Parameters.AddWithValue("@Islem_Yonu", ((int)iyIslemYonuS));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                    if (DR["Cari_No"].TOINT() > 0)
                    {
                        cmd.CommandText = "INSERT INTO Islem_Detay_Cari (Fis_Tarihi, Fis_Saati, Cari_No, Alacak_Tutari, Alacak_Tutari_Baslik, Alacak_Tutari_Kart, Alacak_Tutari_Sistem, Borc_Tutari, Borc_Tutari_Baslik, Borc_Tutari_Kart, Borc_Tutari_Sistem, Aciklama, Silindi, Fis_Tipi, Isyeri_Kodu, Fis_No, Fis_Sira, Islem_Yonu) " +
                                          "VALUES (@Fis_Tarihi, @Fis_Saati, @Cari_No, @Alacak_Tutari, @Alacak_Tutari_Baslik, @Alacak_Tutari_Kart, @Alacak_Tutari_Sistem, @Borc_Tutari, @Borc_Tutari_Baslik, @Borc_Tutari_Kart, @Borc_Tutari_Sistem, @Aciklama, @Silindi, @Fis_Tipi, @Isyeri_Kodu, @Fis_No, @Fis_Sira, @Islem_Yonu)";

                        cmd.Parameters.AddWithValue("@Fis_Tarihi", dtpFisTarihi.Value.TODATE());
                        cmd.Parameters.AddWithValue("@Fis_Saati", dtpFisSaati.Value.TOTIME());
                        cmd.Parameters.AddWithValue("@Cari_No", DR["Cari_No"].TOINT());
                        cmd.Parameters.AddWithValue("@Alacak_Tutari", dblBorcTutari);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari_Baslik", dblBorcTutari);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari_Kart", dblBorcTutari);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari_Sistem", dblBorcTutari);
                        cmd.Parameters.AddWithValue("@Borc_Tutari", dblAlacakTutari);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Baslik", dblAlacakTutari);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Kart", dblAlacakTutari);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Sistem", dblAlacakTutari);
                        cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.Trim());
                        cmd.Parameters.AddWithValue("@Silindi", 0);
                        cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                        cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                        cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                        cmd.Parameters.AddWithValue("@Fis_Sira", iSira + 1);
                        cmd.Parameters.AddWithValue("@Islem_Yonu", iyIslemYonuS == clsFisTipleri.IslemYonu.Giris ? (int)clsFisTipleri.IslemYonu.Cikis : (int)clsFisTipleri.IslemYonu.Giris);

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    else if (!string.IsNullOrEmpty(DR["Masraf_Kodu"].TOSTRING()))
                    {

                        cmd.CommandText = "INSERT INTO Islem_Detay_Masraf (Fis_Tarihi, Fis_Saati, Masraf_Kodu, Alacak_Tutari, Alacak_Tutari_Baslik, Alacak_Tutari_Kart, Alacak_Tutari_Sistem, Borc_Tutari, Borc_Tutari_Baslik, Borc_Tutari_Kart, Borc_Tutari_Sistem, Aciklama, Silindi, Fis_Tipi, Isyeri_Kodu, Fis_No, Fis_Sira, Islem_Yonu) " +
                                          "VALUES (@Fis_Tarihi, @Fis_Saati, @Masraf_Kodu, @Alacak_Tutari, @Alacak_Tutari_Baslik, @Alacak_Tutari_Kart, @Alacak_Tutari_Sistem, @Borc_Tutari, @Borc_Tutari_Baslik, @Borc_Tutari_Kart, @Borc_Tutari_Sistem, @Aciklama, @Silindi, @Fis_Tipi, @Isyeri_Kodu, @Fis_No, @Fis_Sira, @Islem_Yonu)";
                        cmd.Parameters.AddWithValue("@Fis_Tarihi", dtpFisTarihi.Value.TODATE());
                        cmd.Parameters.AddWithValue("@Fis_Saati", dtpFisSaati.Value.TOTIME());
                        cmd.Parameters.AddWithValue("@Masraf_Kodu", DR["Masraf_Kodu"].TOSTRING());
                        cmd.Parameters.AddWithValue("@Alacak_Tutari", dblBorcTutari);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari_Baslik", dblBorcTutari);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari_Kart", dblBorcTutari);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari_Sistem", dblBorcTutari);
                        cmd.Parameters.AddWithValue("@Borc_Tutari", dblAlacakTutari);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Baslik", dblAlacakTutari);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Kart", dblAlacakTutari);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Sistem", dblAlacakTutari);
                        cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.Trim());
                        cmd.Parameters.AddWithValue("@Silindi", 0);
                        cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                        cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                        cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                        cmd.Parameters.AddWithValue("@Fis_Sira", iSira + 1);
                        cmd.Parameters.AddWithValue("@Islem_Yonu", iyIslemYonuS == clsFisTipleri.IslemYonu.Giris ? (int)clsFisTipleri.IslemYonu.Cikis : (int)clsFisTipleri.IslemYonu.Giris);

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
                cmd.Transaction.Commit();
                blnReturn = true;
                blnDegisti = false;
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            cmd.Dispose();
            cnn.Close();
            return blnReturn;
        }

        private void btnSecFisNo_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECFisKasa(ftFisTipi, cbIsyeriKodu.SelectedItemForCode().TOINT());
            if (o != null)
            {
                txtFisNo.Text = o.TOSTRING();
                txtFisNo_KeyDown(txtFisNo, new KeyEventArgs(Keys.Return));
            }
        }

        private void txtBelgeNo_TextChanged(object sender, EventArgs e)
        {
            blnDegisti = true;
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            if (fncVazgec(false))
            {
                SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = string.Format("SELECT ISNULL({0}(Fis_No), (SELECT ISNULL({1}(Fis_No), CAST(1 AS INT)) FROM Islem_Baslik WHERE Silindi = 0 AND Fis_Tipi = @Fis_Tipi_Ic AND Isyeri_Kodu = @Isyeri_Kodu_Ic)) AS Fis_No FROM Islem_Baslik WHERE Silindi = 0 AND Fis_Tipi = @Fis_Tipi AND Isyeri_Kodu = @Isyeri_Kodu AND Fis_No {2} @Fis_No",
                                                (((Button)sender).Tag.TOINT() == 0 ? "MAX" : "MIN"),
                                                (((Button)sender).Tag.TOINT() == 0 ? "MIN" : "MAX"),
                                                (((Button)sender).Tag.TOINT() == 0 ? "<" : ">"));
                cmd.Parameters.AddWithValue("@Fis_Tipi_Ic", intFisTipi);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu_Ic", cbIsyeriKodu.SelectedItemForCode().TOINT());
                cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode().TOINT());
                cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                int intYeniFisNo = cmd.ExecuteScalar().TOINT(0);
                cmd.Dispose();
                cnn.Close();

                txtFisNo.Text = intYeniFisNo.TOSTRING();
                txtFisNo_KeyDown(txtFisNo, new KeyEventArgs(Keys.Return));
            }
        }
    }
}