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
    public partial class frmStokIslem : Form
    {
        int intFisTipi = 0;
        clsFisTipleri.FisTipleri ftFisTipi;
        clsFisTipleri.IslemYonu iyIslemYonu = clsFisTipleri.IslemYonu.Yok;
        int intCariNo = 0;
        DataTable dtKalemler = new DataTable();
        BindingSource bsKalemler = new BindingSource();
        bool blnYeniKayit = true;
        bool blnSilindi = true;
        bool blnComboBox = false;
        bool blnDegisti = false;
        public List<int> lstBagliIrsaliyeFisTipi = new List<int>();
        public List<int> lstBagliIrsaliyeIsyeriKodu = new List<int>();
        public List<int> lstBagliIrsaliyeFisNo = new List<int>();
        int intBagliFaturaFisTipi = 0;
        int intBagliFaturaIsyeriKodu = 0;
        int intBagliFaturaFisNo = 0;

        public frmStokIslem(clsFisTipleri.FisTipleri ftGetFisTipi)
        {
            InitializeComponent();

            ftFisTipi = ftGetFisTipi;
            intFisTipi = (int)ftFisTipi;
            iyIslemYonu = clsFisTipleri.fncIslemYonu(ftFisTipi);
            this.Text = clsFisTipleri.fncIslemText(ftFisTipi);

            clsGenel.prcdFillComboBox("Isyeri_Tanitimi", "Isyeri_Kodu", "Isyeri_Adi", new ComboBox[] { cbIsyeriKodu });
            clsGenel.prcdFillComboBox("Depo_Tanitimi", "Depo_Kodu", "Depo_Adi", new ComboBox[] { cbDepoKodu2 });
            clsGenel.prcdFillComboBox("Belge_Tipi_Tanitimi", "Belge_Tipi", "", new ComboBox[] { cbBelgeTipi }, true);
            clsGenel.prcdFillComboBox("Para_Birimi_Tanitimi", "Para_Birimi", "", new ComboBox[] { cbParaBirimi });

            cbIsyeriKodu.SelectedItemByCode(clsGenel.fncGetParameter("Isyeri_Kodu_FT" + intFisTipi.TOSTRING()));
            if (cbIsyeriKodu.SelectedIndex < 0) cbIsyeriKodu.SelectedItemByCode(clsGenel.fncGetParameter("Isyeri_Kodu"));
            if (cbIsyeriKodu.SelectedIndex < 0 && cbIsyeriKodu.Items.Count > 0) cbIsyeriKodu.SelectedIndex = 0;


            txtCariKodu.Enabled = ftFisTipi != clsFisTipleri.FisTipleri.StokZayi &&
                                  ftFisTipi != clsFisTipleri.FisTipleri.StokIkram &&
                                  ftFisTipi != clsFisTipleri.FisTipleri.StokDuzeltme &&
                                  ftFisTipi != clsFisTipleri.FisTipleri.StokTransfer;
            btnSecCariKodu.Enabled = txtCariKodu.Enabled;

            if (iyIslemYonu == clsFisTipleri.IslemYonu.Giris)
            {
                colCMiktari.Visible = false;
                colGMiktari.HeaderText = "Miktarı";
            }
            else if (iyIslemYonu == clsFisTipleri.IslemYonu.Cikis || iyIslemYonu == clsFisTipleri.IslemYonu.Cift)
            {
                colGMiktari.Visible = false;
                colCMiktari.HeaderText = "Miktarı";

                if (iyIslemYonu == clsFisTipleri.IslemYonu.Cift)
                {
                    cbDepoKodu2.Visible = true;
                    label17.Visible = true;

                    label16.Text = "V. Depo Kodu:";
                    cbDepoKodu1.Left = 692;
                    label17.Text = "A. Depo Kodu:";
                    cbDepoKodu2.Left = 692;
                }
            }
            else
            {
                txtAraToplam.Visible = false;
                txtIskontoToplami.Visible = false;
                txtKdvToplami.Visible = false;
                txtNetToplam.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
            }
        }

        private void frmStokIslem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.FocusNextControl();
            }
        }
        private void frmStokIslem_Shown(object sender, EventArgs e)
        {
            txtFaturaIrsaliyeNo.Visible = ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeAlis ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeAlisIade ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeSatis ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeSatisIade ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.FaturaAlis ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.FaturaAlisIade ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.FaturaSatis ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.FaturaSatisIade;
            label18.Visible = txtFaturaIrsaliyeNo.Visible;
            if (ftFisTipi == clsFisTipleri.FisTipleri.FaturaAlis ||
                ftFisTipi == clsFisTipleri.FisTipleri.FaturaAlisIade ||
                ftFisTipi == clsFisTipleri.FisTipleri.FaturaSatis ||
                ftFisTipi == clsFisTipleri.FisTipleri.FaturaSatisIade)
            {
                label18.Text = "İrsaliye No:";
            }
            else if (ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeAlis ||
                     ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeAlisIade ||
                     ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeSatis ||
                     ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeSatisIade)
            {
                label18.Text = "Fatura No:";
            }

            label18.Left = txtFaturaIrsaliyeNo.Left - label18.Width;

            txtKasaKodu.Visible = ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeAlis ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeAlisIade ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeSatis ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeSatisIade ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.FaturaAlis ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.FaturaAlisIade ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.FaturaSatis ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.FaturaSatisIade;
            label19.Visible = txtKasaKodu.Visible;
            btnSecKasaKodu.Visible = txtKasaKodu.Visible;

            tsbIrsaliye.Visible = ftFisTipi == clsFisTipleri.FisTipleri.FaturaAlis ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.FaturaAlisIade ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.FaturaSatis ||
                                  ftFisTipi == clsFisTipleri.FisTipleri.FaturaSatisIade;
            toolStripSeparator2.Visible = tsbIrsaliye.Visible;

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
            clsGenel.prcdFillComboBox("Depo_Tanitimi", "Depo_Kodu", "Depo_Adi", new ComboBox[] { cbDepoKodu1 }, false, "Isyeri_Kodu", "=", cbIsyeriKodu.SelectedItemForCode());
            if (cbDepoKodu1.SelectedIndex < 0) cbDepoKodu1.SelectedItemByCode(clsGenel.fncGetParameter("Depo_Kodu"));
            if (cbDepoKodu1.SelectedIndex < 0 && cbDepoKodu1.Items.Count > 0) cbDepoKodu1.SelectedIndex = 0;
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

        private void txtCariKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                prcdCariBilgiGetir();
            }
        }

        private void btnSecCariKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECCari();
            if (o != null)
            {
                txtCariKodu.Text = o.TOSTRING();
                prcdCariBilgiGetir();
            }
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
            tsbIrsaliye.Enabled = blnEnabled && !blnSilindi;
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

            lstBagliIrsaliyeFisTipi.Clear();
            lstBagliIrsaliyeIsyeriKodu.Clear();
            lstBagliIrsaliyeFisNo.Clear();
            intBagliFaturaFisTipi = 0;
            intBagliFaturaIsyeriKodu = 0;
            intBagliFaturaFisNo = 0;

            prcdFaturaAktifPasifKontrol(true);

            blnComboBox = false;
            intCariNo = 0;
            dtpFisTarihi.Value = DateTime.Now.Date;
            dtpFisSaati.Value = DateTime.Now;
            txtCariKodu.Clear();
            lblUnvani.Text = "";
            txtBelgeNo.Clear();
            dtpBelgeTarihi.Value = DateTime.Now.Date;
            txtAciklama.Clear();
            txtAraToplam.Clear();
            txtIskontoToplami.Clear();
            txtKdvToplami.Clear();
            txtNetToplam.Clear();
            txtFaturaIrsaliyeNo.Clear();

            txtKasaKodu.Text = txtKasaKodu.Visible ? clsGenel.fncGetParameter("Kasa_Kodu") : "";

            cbBelgeTipi.SelectedItemByCode(clsGenel.fncGetParameter("Belge_Tipi_FT" + intFisTipi.TOSTRING(), (cbBelgeTipi.Items.Count > 0 ? cbBelgeTipi.Items[0].TOSTRING() : "")));
            cbParaBirimi.SelectedItemByCode(clsGenel.fncGetParameter("Para_Birimi", "TL"));

            cbDepoKodu1.SelectedItemByCode(clsGenel.fncGetParameter("Depo_Kodu_FT" + intFisTipi.TOSTRING()));
            if (cbDepoKodu1.SelectedIndex < 0) cbDepoKodu1.SelectedItemByCode(clsGenel.fncGetParameter("Depo_Kodu"));
            if (cbDepoKodu1.SelectedIndex < 0 && cbDepoKodu1.Items.Count > 0) cbDepoKodu1.SelectedIndex = 0;

            cbFiyatTipi.SelectedIndex = clsGenel.fncGetParameter("Fiyat_Tipi_FT" + intFisTipi.TOSTRING(), "0").TOINT();
            cbKdvTipi1.SelectedIndex = clsGenel.fncGetParameter("Kdv_Tipi_1_FT" + intFisTipi.TOSTRING(), "0").TOINT();
            cbKdvTipi2.SelectedIndex = clsGenel.fncGetParameter("Kdv_Tipi_2_FT" + intFisTipi.TOSTRING(), "0").TOINT();

            dtKalemler.Rows.Clear();

            blnYeniKayit = true;
            blnSilindi = false;
            blnComboBox = true;
            blnDegisti = false;
        }

        private void prcdCariBilgiGetir()
        {
            intCariNo = 0;
            lblUnvani.Text = "";
            if (!string.IsNullOrEmpty(txtCariKodu.Text))
            {
                SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Cari_Tanitimi WHERE Silindi = 0 AND Cari_Kodu = @Cari_Kodu";
                cmd.Parameters.AddWithValue("@Cari_Kodu", txtCariKodu.Text.Trim());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    intCariNo = reader["Cari_No"].TOINT();
                    lblUnvani.Text = reader["Unvani"].TOSTRING();
                }
                else
                {
                    intCariNo = 0;
                    lblUnvani.Text = "";
                }
                reader.Close();
                cmd.Dispose();
                cnn.Close();
            }
        }

        private void txtFisNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (cbIsyeriKodu.SelectedItemForCode().TOINT() != 0)
                {
                    if (txtFisNo.Text.Trim().TOINT() != 0)
                    {
                        blnComboBox = false;
                        SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                        cnn.Open();
                        SqlCommand cmd = cnn.CreateCommand();
                        cmd.CommandText = "SELECT IB.*, CT.Cari_Kodu " +
                                          "FROM Islem_Baslik AS IB " +
                                          "LEFT OUTER JOIN Cari_Tanitimi AS CT ON CT.Silindi = 0 AND CT.Cari_No = IB.Cari_No " +
                                          "WHERE IB.Fis_Tipi = @Fis_Tipi AND IB.Isyeri_Kodu = @Isyeri_Kodu AND IB.Fis_No = @Fis_No";
                        cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                        cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode().TOINT());
                        cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.Trim().TOINT());
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            dtpFisTarihi.Value = reader["Fis_Tarihi"].TODATE();
                            dtpFisSaati.Value = reader["Fis_Saati"].TOTIME();
                            txtCariKodu.Text = reader["Cari_Kodu"].TOSTRING();
                            prcdCariBilgiGetir();
                            cbBelgeTipi.SelectedItemByCode(reader["Belge_Tipi"].TOSTRING());
                            txtBelgeNo.Text = reader["Belge_No"].TOSTRING();
                            dtpBelgeTarihi.Value = reader["Belge_Tarihi"].TODATE();
                            cbParaBirimi.SelectedItemByCode(reader["Para_Birimi"].TOSTRING());
                            cbFiyatTipi.SelectedIndex = reader["Fiyat_Tipi"].TOINT();
                            cbKdvTipi1.SelectedIndex = reader["Kdv_Tipi_1"].TOINT();
                            cbKdvTipi2.SelectedIndex = reader["Kdv_Tipi_2"].TOINT();
                            cbDepoKodu1.SelectedItemByCode(reader["Depo_Kodu_1"].TOSTRING());
                            cbDepoKodu2.SelectedItemByCode(reader["Depo_Kodu_2"].TOSTRING());
                            txtAciklama.Text = reader["Aciklama"].TOSTRING();

                            blnSilindi = reader["Silindi"].TOINT() == 1;
                            blnYeniKayit = false;
                        }
                        reader.Close();
                        cmd.Dispose();
                        cnn.Close();

                        prcdFaturaIrsaliyeBilgiGetir();
                        prcdDetayGetir();

                        prcdAktifPasifKontrol(true);
                        blnDegisti = false;
                        blnComboBox = true;
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

        private void prcdDetayGetir()
        {
            dtKalemler.Rows.Clear();

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT ID.Stok_No, ST.Stok_Kodu, '...' AS Sec_Stok_Kodu, ST.Stok_Adi, ID.Giris_Miktari, ID.Cikis_Miktari, ID.Birim_Kodu, " +
                              "'...' AS Sec_Birim_Kodu, ID.Birim_Fiyati, ID.Isk_Orani_1, ID.Isk_Orani_2, ID.Isk_Orani_3, ID.Kdv_Orani, '...' AS Sec_Kdv_Orani, " +
                              "ID.Isk_Tutari_1, ID.Isk_Tutari_2, ID.Isk_Tutari_3, ID.Kdv_Tutari, (ID.Giris_Tutari + ID.Cikis_Tutari) AS Tutari, (ID.Giris_Tutari_Net + ID.Cikis_Tutari_Net) AS Tutari_Net, ID.Aciklama " +
                              "FROM Islem_Detay_Stok AS ID " +
                              "LEFT OUTER JOIN Stok_Tanitimi AS ST ON ST.Silindi = 0 AND ST.Stok_No = ID.Stok_No " +
                              "WHERE ID.Fis_Tipi = @Fis_Tipi AND ID.Isyeri_Kodu = @Isyeri_Kodu AND ID.Fis_No = @Fis_No " +
                              (iyIslemYonu == clsFisTipleri.IslemYonu.Cift ? "AND ID.Islem_Yonu = @Islem_Yonu" : "");
            if (lstBagliIrsaliyeFisTipi.Count > 0)
            {
                for (int i = 0; i < lstBagliIrsaliyeFisTipi.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@Fis_Tipi", lstBagliIrsaliyeFisTipi[i]);
                    cmd.Parameters.AddWithValue("@Isyeri_Kodu", lstBagliIrsaliyeIsyeriKodu[i]);
                    cmd.Parameters.AddWithValue("@Fis_No", lstBagliIrsaliyeFisNo[i]);
                    if (iyIslemYonu == clsFisTipleri.IslemYonu.Cift)
                        cmd.Parameters.AddWithValue("@Islem_Yonu", ((int)clsFisTipleri.IslemYonu.Cikis));

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dtKalemler);
                    sda.Dispose();
                    cmd.Parameters.Clear();
                }
            }
            else
            {
                cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode().TOINT());
                cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.Trim().TOINT());
                if (iyIslemYonu == clsFisTipleri.IslemYonu.Cift)
                    cmd.Parameters.AddWithValue("@Islem_Yonu", ((int)clsFisTipleri.IslemYonu.Cikis));

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtKalemler);
                sda.Dispose();
            }

            cmd.Dispose();
            cnn.Close();
            bsKalemler.DataSource = dtKalemler;
            dgvKalemler.DataSource = bsKalemler;
            prcdGenelToplam();
        }

        private void prcdFaturaIrsaliyeBilgiGetir()
        {
            if (ftFisTipi == clsFisTipleri.FisTipleri.FaturaAlis || ftFisTipi == clsFisTipleri.FisTipleri.FaturaSatis || ftFisTipi == clsFisTipleri.FisTipleri.FaturaAlisIade || ftFisTipi == clsFisTipleri.FisTipleri.FaturaSatisIade ||
                ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeAlis || ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeSatis || ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeAlisIade || ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeSatisIade)
            {
                SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                if (ftFisTipi == clsFisTipleri.FisTipleri.FaturaAlis || ftFisTipi == clsFisTipleri.FisTipleri.FaturaSatis || ftFisTipi == clsFisTipleri.FisTipleri.FaturaAlisIade || ftFisTipi == clsFisTipleri.FisTipleri.FaturaSatisIade)
                    cmd.CommandText = "SELECT Irsaliye_Fis_Tipi, Irsaliye_Isyeri_Kodu, Irsaliye_Fis_No, " +
                                      "(SELECT Belge_No FROM Islem_Baslik WHERE Fis_Tipi = SBI.Irsaliye_Fis_Tipi AND Isyeri_Kodu = SBI.Irsaliye_Isyeri_Kodu AND Fis_No = SBI.Irsaliye_Fis_No) AS Irsaliye_No " +
                                      "FROM Stok_Bagli_Irsaliyeler AS SBI WHERE Fatura_Fis_Tipi = @Fis_Tipi AND Fatura_Isyeri_Kodu = @Isyeri_Kodu AND Fatura_Fis_No = @Fis_No";
                else if (ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeAlis || ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeSatis || ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeAlisIade || ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeSatisIade)
                    cmd.CommandText = "SELECT Fatura_Fis_Tipi, Fatura_Isyeri_Kodu, Fatura_Fis_No, " +
                                      "(SELECT Belge_No FROM Islem_Baslik WHERE Fis_Tipi = SBI.Fatura_Fis_Tipi AND Isyeri_Kodu = SBI.Fatura_Isyeri_Kodu AND Fis_No = SBI.Fatura_Fis_No) AS Fatura_No " +
                                      "FROM Stok_Bagli_Irsaliyeler AS SBI WHERE Irsaliye_Fis_Tipi = @Fis_Tipi AND Irsaliye_Isyeri_Kodu = @Isyeri_Kodu AND Irsaliye_Fis_No = @Fis_No";
                cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode().TOINT());
                cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.Trim().TOINT());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (ftFisTipi == clsFisTipleri.FisTipleri.FaturaAlis || ftFisTipi == clsFisTipleri.FisTipleri.FaturaSatis || ftFisTipi == clsFisTipleri.FisTipleri.FaturaAlisIade || ftFisTipi == clsFisTipleri.FisTipleri.FaturaSatisIade)
                    {
                        lstBagliIrsaliyeFisTipi.Add(reader["Irsaliye_Fis_Tipi"].TOINT());
                        lstBagliIrsaliyeIsyeriKodu.Add(reader["Irsaliye_Isyeri_Kodu"].TOINT());
                        lstBagliIrsaliyeFisNo.Add(reader["Irsaliye_Fis_No"].TOINT());

                        if (!string.IsNullOrEmpty(txtFaturaIrsaliyeNo.Text.Trim())) txtFaturaIrsaliyeNo.Text += ", ";
                        txtFaturaIrsaliyeNo.Text += reader["Irsaliye_No"].TOSTRING();

                        prcdFaturaAktifPasifKontrol(false);
                    }
                    else if (ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeAlis || ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeSatis || ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeAlisIade || ftFisTipi == clsFisTipleri.FisTipleri.IrsaliyeSatisIade)
                    {
                        intBagliFaturaFisTipi = reader["Fatura_Fis_Tipi"].TOINT();
                        intBagliFaturaIsyeriKodu = reader["Fatura_Isyeri_Kodu"].TOINT();
                        intBagliFaturaFisNo = reader["Fatura_Fis_No"].TOINT();

                        txtFaturaIrsaliyeNo.Text = reader["Fatura_No"].TOSTRING();
                    }
                }
                reader.Close();
                cmd.Dispose();
                cnn.Close();
            }
        }

        private void dgvKalemler_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bsKalemler.ResetBindings(true);

            if (dgvKalemler.Columns[e.ColumnIndex].Name == colCMiktari.Name ||
                dgvKalemler.Columns[e.ColumnIndex].Name == colGMiktari.Name ||
                dgvKalemler.Columns[e.ColumnIndex].Name == colFiyati.Name ||
                dgvKalemler.Columns[e.ColumnIndex].Name == colIskonto1.Name ||
                dgvKalemler.Columns[e.ColumnIndex].Name == colIskonto2.Name ||
                dgvKalemler.Columns[e.ColumnIndex].Name == colIskonto3.Name)
            {
                if (dgvKalemler.Columns[e.ColumnIndex].Name == colCMiktari.Name)
                    dgvKalemler.Rows[e.RowIndex].Cells[colGMiktari.Name].Value = 0;

                if (dgvKalemler.Columns[e.ColumnIndex].Name == colGMiktari.Name)
                    dgvKalemler.Rows[e.RowIndex].Cells[colCMiktari.Name].Value = 0;

                prcdSatirHesapla(true);
            }
            else if (dgvKalemler.Columns[e.ColumnIndex].Name == colStokKodu.Name)
            {
                prcdStokBilgiGetir();
            }

            txtCariKodu_TextChanged(txtCariKodu, new EventArgs());
        }

        private void dgvKalemler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvKalemler.ReadOnly && e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (dgvKalemler.Columns[e.ColumnIndex].Name == colSecStokKodu.Name)
                {
                    object o = clsXKod.fncSECStok();
                    if (o != null)
                    {
                        dgvKalemler.CurrentRow.Cells["colStokKodu"].Value = o.TOSTRING();
                        bsKalemler.ResetBindings(true);
                        prcdStokBilgiGetir();
                    }
                }
                else if (dgvKalemler.Columns[e.ColumnIndex].Name == colSecBirim.Name && e.RowIndex != dgvKalemler.NewRowIndex)
                {
                    object o = clsXKod.fncSECStokBirim(dgvKalemler.CurrentRow.Cells["colStokNo"].Value.TOINT());
                    if (o != null)
                    {
                        dgvKalemler.CurrentRow.Cells["colBirimi"].Value = o.TOSTRING();
                        prcdStokBilgiGetir(false, false, false, true);
                    }
                }
                else if (dgvKalemler.Columns[e.ColumnIndex].Name == colSecKdv.Name && e.RowIndex != dgvKalemler.NewRowIndex)
                {
                    object o = clsXKod.fncSECKdv();

                    if (o != null)
                    {
                        dgvKalemler.CurrentRow.Cells["colKdv"].Value = o.TOSTRING();
                        prcdStokBilgiGetir(false, false, false, true);
                    }
                }
            }
        }

        private void prcdStokBilgiGetir(bool blnStokBilgi = true, bool blnBirimi = true, bool blnKdv = true, bool blnFiyat = true)
        {
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Stok_Tanitimi WHERE Silindi = 0 AND Stok_Kodu = @Stok_Kodu";
            cmd.Parameters.AddWithValue("@Stok_Kodu", dgvKalemler.CurrentRow.Cells["colStokKodu"].Value);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dgvKalemler.CurrentRow.Cells["colStokNo"].Value = reader["Stok_No"];
                dgvKalemler.CurrentRow.Cells["colSecStokKodu"].Value = "...";
                dgvKalemler.CurrentRow.Cells["colStokAdi"].Value = reader["Stok_Adi"];
                dgvKalemler.CurrentRow.Cells["colSecBirim"].Value = "...";
                dgvKalemler.CurrentRow.Cells["colSecKdv"].Value = "...";

                if (blnBirimi)
                    dgvKalemler.CurrentRow.Cells["colBirimi"].Value = reader["Birim_Kodu_1"];

                if (blnKdv)
                {
                    if (cbKdvTipi2.SelectedIndex == 0)
                        dgvKalemler.CurrentRow.Cells["colKdv"].Value = reader["Kdv_Toptan"];
                    else
                        dgvKalemler.CurrentRow.Cells["colKdv"].Value = reader["Kdv_Perakende"];
                }

                if (blnFiyat)
                {
                    string strBTNo = "";
                    if (reader["Birim_Kodu_1"].TOSTRING() == dgvKalemler.CurrentRow.Cells["colBirimi"].Value.TOSTRING())
                        strBTNo = "BT1";
                    else
                        strBTNo = "BT2";

                    if (cbFiyatTipi.SelectedIndex == 0)
                    {
                        if (cbKdvTipi1.SelectedIndex == 0)
                            dgvKalemler.CurrentRow.Cells["colFiyati"].Value = reader[strBTNo + "_Alis_Fiyati"].TODOUBLE() * (1 + (dgvKalemler.CurrentRow.Cells["colKdv"].Value.TODOUBLE() / 100));
                        else
                            dgvKalemler.CurrentRow.Cells["colFiyati"].Value = reader[strBTNo + "_Alis_Fiyati"].TODOUBLE();
                    }
                    else
                    {
                        if (cbKdvTipi1.SelectedIndex == 0)
                            dgvKalemler.CurrentRow.Cells["colFiyati"].Value = reader[strBTNo + "_Satis_Fiyati"].TODOUBLE();
                        else
                            dgvKalemler.CurrentRow.Cells["colFiyati"].Value = reader[strBTNo + "_Satis_Fiyati"].TODOUBLE() / (1 + (dgvKalemler.CurrentRow.Cells["colKdv"].Value.TODOUBLE() / 100));
                    }
                }

                prcdSatirHesapla(true);
            }
            else
            {
                dgvKalemler.CurrentRow.Cells["colStokNo"].Value = 0;
                dgvKalemler.CurrentRow.Cells["colSecStokKodu"].Value = "...";
                dgvKalemler.CurrentRow.Cells["colStokAdi"].Value = "";
                dgvKalemler.CurrentRow.Cells["colSecBirim"].Value = "...";
                dgvKalemler.CurrentRow.Cells["colSecKdv"].Value = "...";
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
        }

        private void prcdSatirHesapla(bool blnGenelToplam = false)
        {
            double dblGMiktari = dgvKalemler.CurrentRow.Cells["colGMiktari"].Value.TODOUBLE();
            double dblCMiktari = dgvKalemler.CurrentRow.Cells["colCMiktari"].Value.TODOUBLE();
            double dblMiktari = dblGMiktari + dblCMiktari;
            double dblFiyati = dgvKalemler.CurrentRow.Cells["colFiyati"].Value.TODOUBLE();
            double dblKdvOrani = cbKdvTipi1.SelectedIndex != 2 ? dgvKalemler.CurrentRow.Cells["colKdv"].Value.TODOUBLE() : 0;
            double dblIskOrani1 = dgvKalemler.CurrentRow.Cells["colIskonto1"].Value.TODOUBLE();
            double dblIskOrani2 = dgvKalemler.CurrentRow.Cells["colIskonto2"].Value.TODOUBLE();
            double dblIskOrani3 = dgvKalemler.CurrentRow.Cells["colIskonto3"].Value.TODOUBLE();

            double dblTutari = dblMiktari * dblFiyati;
            double dblTutariNet = dblTutari;

            double dblIskTutari1 = dblTutari * dblIskOrani1 / 100;
            double dblIskTutari2 = (dblTutari - dblIskTutari1) * dblIskOrani2 / 100;
            double dblIskTutari3 = (dblTutari - dblIskTutari1 - dblIskTutari2) * dblIskOrani3 / 100;

            double dblTutariIskontolu = dblTutari - dblIskTutari1 - dblIskTutari2 - dblIskTutari3;
            dblTutariNet = dblTutariNet - dblIskTutari1 - dblIskTutari2 - dblIskTutari3;

            double dblKdvTutari = 0;
            if (cbKdvTipi1.SelectedIndex == 0)
                dblKdvTutari = dblTutariIskontolu - (dblTutariIskontolu / (1 + (dblKdvOrani / 100)));
            else if (cbKdvTipi1.SelectedIndex == 1)
            {
                dblKdvTutari = dblTutariIskontolu * dblKdvOrani / 100;
                dblTutariNet += dblKdvTutari;
            }

            dgvKalemler.CurrentRow.Cells["colIskontoTut1"].Value = dblIskTutari1;
            dgvKalemler.CurrentRow.Cells["colIskontoTut2"].Value = dblIskTutari2;
            dgvKalemler.CurrentRow.Cells["colIskontoTut3"].Value = dblIskTutari3;
            dgvKalemler.CurrentRow.Cells["colKdvTutari"].Value = dblKdvTutari;
            dgvKalemler.CurrentRow.Cells["colTutari"].Value = dblTutari;
            dgvKalemler.CurrentRow.Cells["colTutariNet"].Value = dblTutariNet;

            if (blnGenelToplam)
                prcdGenelToplam();
        }

        private void prcdGenelToplam()
        {
            double dblAraToplam = dtKalemler.Compute("SUM(Tutari)", "").TODOUBLE();
            double dblIskToplam = dtKalemler.Compute("SUM(Isk_Tutari_1)", "").TODOUBLE() + dtKalemler.Compute("SUM(Isk_Tutari_2)", "").TODOUBLE() + dtKalemler.Compute("SUM(Isk_Tutari_3)", "").TODOUBLE();
            double dblKdvToplam = dtKalemler.Compute("SUM(Kdv_Tutari)", "").TODOUBLE();
            double dblNetToplam = dblAraToplam - dblIskToplam + (cbKdvTipi1.SelectedIndex != 0 ? dblKdvToplam : 0);

            txtAraToplam.Text = dblAraToplam.ToString(clsGenel.strDoubleFormatTwo);
            txtIskontoToplami.Text = dblIskToplam.ToString(clsGenel.strDoubleFormatTwo);
            txtKdvToplami.Text = dblKdvToplam.ToString(clsGenel.strDoubleFormatTwo);
            txtNetToplam.Text = dblNetToplam.ToString(clsGenel.strDoubleFormatTwo);
        }

        private void cbFiyatTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dgvKalemler.ReadOnly)
            {
                if (blnComboBox && MessageBox.Show(((ComboBox)sender).AccessibleDescription + " değişimini kalemlere yansıtmak istiyor musunuz?", ((ComboBox)sender).AccessibleName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow DR in dgvKalemler.Rows)
                    {
                        dgvKalemler.CurrentCell = DR.Cells[colStokKodu.Name];
                        prcdStokBilgiGetir(false, false, ((ComboBox)sender).Tag.TOINT() != 0, ((ComboBox)sender).Tag.TOINT() != 2);
                    }
                }
            }
            txtCariKodu_TextChanged(txtCariKodu, new EventArgs());
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
            if (dgvKalemler.ReadOnly || string.IsNullOrEmpty(txtFaturaIrsaliyeNo.Text.Trim()))
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
                        cmd.CommandText = "UPDATE Islem_Detay_Cari SET Silindi = @Silindi_Yeni WHERE Silindi = @Silindi AND Fis_Tipi = @Fis_Tipi AND Isyeri_Kodu = @Isyeri_Kodu AND Fis_No = @Fis_No";
                        cmd.Parameters.AddWithValue("@Silindi_Yeni", 1);
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
                        cmd.CommandText = "UPDATE Islem_Detay_Stok SET Silindi = @Silindi_Yeni WHERE Silindi = @Silindi AND Fis_Tipi = @Fis_Tipi AND Isyeri_Kodu = @Isyeri_Kodu AND Fis_No = @Fis_No";
                        cmd.Parameters.AddWithValue("@Silindi_Yeni", 1);
                        cmd.Parameters.AddWithValue("@Silindi", 0);
                        cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                        cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                        cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.CommandText = "DELETE FROM Stok_Bagli_Irsaliyeler WHERE Fatura_Fis_Tipi = @Fis_Tipi AND Fatura_Isyeri_Kodu = @Isyeri_Kodu AND Fatura_Fis_No = @Fis_No";
                        cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                        cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                        cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        cmd.Transaction.Commit();

                        tsbVazgec.PerformClick();
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
            else
            {
                MessageBox.Show("Faturalandırılmış irsaliye silinemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private bool fncKaydet()
        {
            bool blnReturn = false;

            dgvKalemler.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (!dgvKalemler.ReadOnly && !string.IsNullOrEmpty(txtFaturaIrsaliyeNo.Text.Trim()))
            {
                MessageBox.Show("Faturalandırılmış irsaliye değiştirilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return blnReturn;
            }

            if (cbDepoKodu2.Visible && cbDepoKodu1.SelectedItemForCode() == cbDepoKodu2.SelectedItemForCode())
            {
                MessageBox.Show("Veren depo ile alan depo aynı olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                    cmd.CommandText = "INSERT INTO Islem_Baslik (Depo_Kodu_1, Depo_Kodu_2, Fis_Tarihi, Fis_Saati, Cari_No, Belge_Tipi, Belge_No, Belge_Tarihi, Para_Birimi, Fiyat_Tipi, Kdv_Tipi_1, Kdv_Tipi_2, Aciklama, Insert_User, Inser_Date, Silindi, Fis_Tipi, Isyeri_Kodu, Fis_No) " +
                                      "VALUES (@Depo_Kodu_1, @Depo_Kodu_2, @Fis_Tarihi, @Fis_Saati, @Cari_No, @Belge_Tipi, @Belge_No, @Belge_Tarihi, @Para_Birimi, @Fiyat_Tipi, @Kdv_Tipi_1, @Kdv_Tipi_2, @Aciklama, @Kullanici, @Zaman, @Silindi, @Fis_Tipi, @Isyeri_Kodu, @Fis_No)";
                }
                else
                {
                    cmd.CommandText = "UPDATE Islem_Baslik SET Depo_Kodu_1 = @Depo_Kodu_1, Depo_Kodu_2 = @Depo_Kodu_2, Fis_Tarihi = @Fis_Tarihi, Fis_Saati = @Fis_Saati, Cari_No = @Cari_No, Belge_Tipi = @Belge_Tipi, Belge_No = @Belge_No, Belge_Tarihi = @Belge_Tarihi, Para_Birimi = @Para_Birimi, Fiyat_Tipi = @Fiyat_Tipi, Kdv_Tipi_1 = @Kdv_Tipi_1, Kdv_Tipi_2 = @Kdv_Tipi_2, Aciklama = @Aciklama, Update_User = @Kullanici, Update_Date = @Zaman " +
                                      "WHERE Silindi = @Silindi AND Fis_Tipi = @Fis_Tipi AND Isyeri_Kodu = @Isyeri_Kodu AND Fis_No = @Fis_No";
                }
                cmd.Parameters.AddWithValue("@Depo_Kodu_1", cbDepoKodu1.SelectedItemForCode());
                cmd.Parameters.AddWithValue("@Depo_Kodu_2", cbDepoKodu2.SelectedItemForCode());
                cmd.Parameters.AddWithValue("@Fis_Tarihi", dtpFisTarihi.Value.TODATE());
                cmd.Parameters.AddWithValue("@Fis_Saati", dtpFisSaati.Value.TOTIME());
                cmd.Parameters.AddWithValue("@Cari_No", intCariNo);
                cmd.Parameters.AddWithValue("@Belge_Tipi", cbBelgeTipi.SelectedItemForCode());
                cmd.Parameters.AddWithValue("@Belge_No", txtBelgeNo.Text.Trim());
                cmd.Parameters.AddWithValue("@Belge_Tarihi", dtpBelgeTarihi.Value.TODATE());
                cmd.Parameters.AddWithValue("@Para_Birimi", cbParaBirimi.SelectedItemForCode());
                cmd.Parameters.AddWithValue("@Fiyat_Tipi", cbFiyatTipi.SelectedIndex);
                cmd.Parameters.AddWithValue("@Kdv_Tipi_1", cbKdvTipi1.SelectedIndex);
                cmd.Parameters.AddWithValue("@Kdv_Tipi_2", cbKdvTipi2.SelectedIndex);
                cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.Trim());
                cmd.Parameters.AddWithValue("@Kullanici", clsGenel.strKullaniciKodu);
                cmd.Parameters.AddWithValue("@Zaman", DateTime.Now);
                cmd.Parameters.AddWithValue("@Silindi", 0);
                cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                double dblAlacakTutariCari = intCariNo != 0 ? dtKalemler.Compute("SUM(Tutari_Net)", "Giris_Miktari <> 0").TODOUBLE() : 0;
                double dblBorcTutariCari = intCariNo != 0 ? dtKalemler.Compute("SUM(Tutari_Net)", "Cikis_Miktari <> 0").TODOUBLE() : 0;
                double dblAlacakTutariKasa = !string.IsNullOrEmpty(txtKasaKodu.Text.Trim()) ? dtKalemler.Compute("SUM(Tutari_Net)", "Giris_Miktari <> 0").TODOUBLE() : 0;
                double dblBorcTutariKasa = !string.IsNullOrEmpty(txtKasaKodu.Text.Trim()) ? dtKalemler.Compute("SUM(Tutari_Net)", "Cikis_Miktari <> 0").TODOUBLE() : 0;

                cmd.CommandText = "DELETE FROM Islem_Detay_Cari WHERE Silindi = @Silindi AND Fis_Tipi = @Fis_Tipi AND Isyeri_Kodu = @Isyeri_Kodu AND Fis_No = @Fis_No";
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

                cmd.CommandText = "DELETE FROM Islem_Detay_Stok WHERE Silindi = @Silindi AND Fis_Tipi = @Fis_Tipi AND Isyeri_Kodu = @Isyeri_Kodu AND Fis_No = @Fis_No";
                cmd.Parameters.AddWithValue("@Silindi", 0);
                cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                cmd.CommandText = "DELETE FROM Stok_Bagli_Irsaliyeler WHERE Fatura_Fis_Tipi = @Fatura_Fis_Tipi AND Fatura_Isyeri_Kodu = @Fatura_Isyeri_Kodu AND Fatura_Fis_No = @Fatura_Fis_No";
                cmd.Parameters.AddWithValue("@Fatura_Fis_Tipi", intFisTipi);
                cmd.Parameters.AddWithValue("@Fatura_Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                cmd.Parameters.AddWithValue("@Fatura_Fis_No", txtFisNo.Text.TOINT());
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                if (intCariNo > 0)
                {
                    cmd.CommandText = "INSERT INTO Islem_Detay_Cari (Cari_No, Fis_Tarihi, Fis_Saati, Borc_Tutari, Borc_Tutari_Baslik, Borc_Tutari_Kart, Borc_Tutari_Sistem, Alacak_Tutari, Alacak_Tutari_Baslik, Alacak_Tutari_Kart, Alacak_Tutari_Sistem, Aciklama, Silindi, Fis_Tipi, Isyeri_Kodu, Fis_No, Fis_Sira, Islem_Yonu) " +
                                      "VALUES (@Cari_No, @Fis_Tarihi, @Fis_Saati, @Borc_Tutari, @Borc_Tutari_Baslik, @Borc_Tutari_Kart, @Borc_Tutari_Sistem, @Alacak_Tutari, @Alacak_Tutari_Baslik, @Alacak_Tutari_Kart, @Alacak_Tutari_Sistem, @Aciklama, @Silindi, @Fis_Tipi, @Isyeri_Kodu, @Fis_No, @Fis_Sira, @Islem_Yonu)";
                    cmd.Parameters.AddWithValue("@Cari_No", intCariNo);
                    cmd.Parameters.AddWithValue("@Fis_Tarihi", dtpFisTarihi.Value.TODATE());
                    cmd.Parameters.AddWithValue("@Fis_Saati", dtpFisSaati.Value.TOTIME());
                    cmd.Parameters.AddWithValue("@Borc_Tutari", dblBorcTutariCari);
                    cmd.Parameters.AddWithValue("@Borc_Tutari_Baslik", dblBorcTutariCari);
                    cmd.Parameters.AddWithValue("@Borc_Tutari_Kart", dblBorcTutariCari);
                    cmd.Parameters.AddWithValue("@Borc_Tutari_Sistem", dblBorcTutariCari);
                    cmd.Parameters.AddWithValue("@Alacak_Tutari", dblAlacakTutariCari);
                    cmd.Parameters.AddWithValue("@Alacak_Tutari_Baslik", dblAlacakTutariCari);
                    cmd.Parameters.AddWithValue("@Alacak_Tutari_Kart", dblAlacakTutariCari);
                    cmd.Parameters.AddWithValue("@Alacak_Tutari_Sistem", dblAlacakTutariCari);
                    cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.Trim());
                    cmd.Parameters.AddWithValue("@Silindi", 0);
                    cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                    cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                    cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                    cmd.Parameters.AddWithValue("@Fis_Sira", 1);
                    cmd.Parameters.AddWithValue("@Islem_Yonu", dblAlacakTutariCari > 0 ? ((int)clsFisTipleri.IslemYonu.Cikis) : ((int)clsFisTipleri.IslemYonu.Giris));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }

                if (!string.IsNullOrEmpty(txtKasaKodu.Text.Trim()))
                {
                    if (intCariNo > 0)
                    {
                        cmd.CommandText = "INSERT INTO Islem_Detay_Cari (Cari_No, Fis_Tarihi, Fis_Saati, Borc_Tutari, Borc_Tutari_Baslik, Borc_Tutari_Kart, Borc_Tutari_Sistem, Alacak_Tutari, Alacak_Tutari_Baslik, Alacak_Tutari_Kart, Alacak_Tutari_Sistem, Aciklama, Silindi, Fis_Tipi, Isyeri_Kodu, Fis_No, Fis_Sira, Islem_Yonu) " +
                                          "VALUES (@Cari_No, @Fis_Tarihi, @Fis_Saati, @Borc_Tutari, @Borc_Tutari_Baslik, @Borc_Tutari_Kart, @Borc_Tutari_Sistem, @Alacak_Tutari, @Alacak_Tutari_Baslik, @Alacak_Tutari_Kart, @Alacak_Tutari_Sistem, @Aciklama, @Silindi, @Fis_Tipi, @Isyeri_Kodu, @Fis_No, @Fis_Sira, @Islem_Yonu)";
                        cmd.Parameters.AddWithValue("@Cari_No", intCariNo);
                        cmd.Parameters.AddWithValue("@Fis_Tarihi", dtpFisTarihi.Value.TODATE());
                        cmd.Parameters.AddWithValue("@Fis_Saati", dtpFisSaati.Value.TOTIME());
                        cmd.Parameters.AddWithValue("@Borc_Tutari", dblAlacakTutariCari);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Baslik", dblAlacakTutariCari);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Kart", dblAlacakTutariCari);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Sistem", dblAlacakTutariCari);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari", dblBorcTutariCari);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari_Baslik", dblBorcTutariCari);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari_Kart", dblBorcTutariCari);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari_Sistem", dblBorcTutariCari);
                        cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.Trim());
                        cmd.Parameters.AddWithValue("@Silindi", 0);
                        cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                        cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                        cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                        cmd.Parameters.AddWithValue("@Fis_Sira", 2);
                        cmd.Parameters.AddWithValue("@Islem_Yonu", dblAlacakTutariCari > 0 ? ((int)clsFisTipleri.IslemYonu.Giris) : ((int)clsFisTipleri.IslemYonu.Cikis));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    cmd.CommandText = "INSERT INTO Islem_Detay_Kasa (Kasa_Kodu, Fis_Tarihi, Fis_Saati, Borc_Tutari, Borc_Tutari_Baslik, Borc_Tutari_Kart, Borc_Tutari_Sistem, Alacak_Tutari, Alacak_Tutari_Baslik, Alacak_Tutari_Kart, Alacak_Tutari_Sistem, Aciklama, Silindi, Fis_Tipi, Isyeri_Kodu, Fis_No, Fis_Sira, Islem_Yonu) " +
                                      "VALUES (@Kasa_Kodu, @Fis_Tarihi, @Fis_Saati, @Borc_Tutari, @Borc_Tutari_Baslik, @Borc_Tutari_Kart, @Borc_Tutari_Sistem, @Alacak_Tutari, @Alacak_Tutari_Baslik, @Alacak_Tutari_Kart, @Alacak_Tutari_Sistem, @Aciklama, @Silindi, @Fis_Tipi, @Isyeri_Kodu, @Fis_No, @Fis_Sira, @Islem_Yonu)";
                    cmd.Parameters.AddWithValue("@Kasa_Kodu", intCariNo);
                    cmd.Parameters.AddWithValue("@Fis_Tarihi", dtpFisTarihi.Value.TODATE());
                    cmd.Parameters.AddWithValue("@Fis_Saati", dtpFisSaati.Value.TOTIME());
                    cmd.Parameters.AddWithValue("@Borc_Tutari", dblBorcTutariKasa);
                    cmd.Parameters.AddWithValue("@Borc_Tutari_Baslik", dblBorcTutariKasa);
                    cmd.Parameters.AddWithValue("@Borc_Tutari_Kart", dblBorcTutariKasa);
                    cmd.Parameters.AddWithValue("@Borc_Tutari_Sistem", dblBorcTutariKasa);
                    cmd.Parameters.AddWithValue("@Alacak_Tutari", dblAlacakTutariKasa);
                    cmd.Parameters.AddWithValue("@Alacak_Tutari_Baslik", dblAlacakTutariKasa);
                    cmd.Parameters.AddWithValue("@Alacak_Tutari_Kart", dblAlacakTutariKasa);
                    cmd.Parameters.AddWithValue("@Alacak_Tutari_Sistem", dblAlacakTutariKasa);
                    cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.Trim());
                    cmd.Parameters.AddWithValue("@Silindi", 0);
                    cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                    cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                    cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                    cmd.Parameters.AddWithValue("@Fis_Sira", 1);
                    cmd.Parameters.AddWithValue("@Islem_Yonu", dblAlacakTutariKasa > 0 ? ((int)clsFisTipleri.IslemYonu.Cikis) : ((int)clsFisTipleri.IslemYonu.Giris));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                
                for (int iSira = 0; iSira < dtKalemler.Rows.Count; iSira++)
                {
                    DataRow DR = dtKalemler.Rows[iSira];

                    for (int iIY = 2; iIY >= (iyIslemYonu == clsFisTipleri.IslemYonu.Cift ? 1 : 2); iIY--)
                    {
                        clsFisTipleri.IslemYonu iyIslemYonuS = (iyIslemYonu == clsFisTipleri.IslemYonu.Cift ? (clsFisTipleri.IslemYonu)iIY : (iyIslemYonu == clsFisTipleri.IslemYonu.Yok ? (DR["Cikis_Miktari"].TODOUBLE() != 0 ? clsFisTipleri.IslemYonu.Cikis : clsFisTipleri.IslemYonu.Giris) : iyIslemYonu));
                        bool blnTersIslem = iyIslemYonu == clsFisTipleri.IslemYonu.Cift && iyIslemYonuS == clsFisTipleri.IslemYonu.Giris;
                        string strDepoKodu = blnTersIslem ? cbDepoKodu2.SelectedItemForCode() : cbDepoKodu1.SelectedItemForCode();
                        double dblGirisMiktari = blnTersIslem ? DR["Cikis_Miktari"].TODOUBLE() : DR["Giris_Miktari"].TODOUBLE();
                        double dblCikisMiktari = blnTersIslem ? DR["Giris_Miktari"].TODOUBLE() : DR["Cikis_Miktari"].TODOUBLE();
                        double dblGirisTutari = iyIslemYonuS == clsFisTipleri.IslemYonu.Giris ? DR["Tutari"].TODOUBLE() : 0;
                        double dblCikisTutari = iyIslemYonuS == clsFisTipleri.IslemYonu.Cikis ? DR["Tutari"].TODOUBLE() : 0;
                        double dblGirisTutariNet = iyIslemYonuS == clsFisTipleri.IslemYonu.Giris ? DR["Tutari_Net"].TODOUBLE() : 0;
                        double dblCikisTutariNet = iyIslemYonuS == clsFisTipleri.IslemYonu.Cikis ? DR["Tutari_Net"].TODOUBLE() : 0;

                        cmd.CommandText = "INSERT INTO Islem_Detay_Stok (Depo_Kodu, Fis_Tarihi, Fis_Saati, Stok_No, Birim_Kodu, Giris_Miktari, Cikis_Miktari, Birim_Fiyati, Isk_Orani_1, Isk_Orani_2, Isk_Orani_3, Kdv_Orani, Isk_Tutari_1, Isk_Tutari_1_Baslik, Isk_Tutari_1_Kart, Isk_Tutari_1_Sistem, Isk_Tutari_2, Isk_Tutari_2_Baslik, Isk_Tutari_2_Kart, Isk_Tutari_2_Sistem, Isk_Tutari_3, Isk_Tutari_3_Baslik, Isk_Tutari_3_Kart, Isk_Tutari_3_Sistem, Kdv_Tutari, Kdv_Tutari_Baslik, Kdv_Tutari_Kart, Kdv_Tutari_Sistem, Giris_Tutari, Giris_Tutari_Baslik, Giris_Tutari_Kart, Giris_Tutari_Sistem, Cikis_Tutari, Cikis_Tutari_Baslik, Cikis_Tutari_Kart, Cikis_Tutari_Sistem, Giris_Tutari_Net, Giris_Tutari_Net_Baslik, Giris_Tutari_Net_Kart, Giris_Tutari_Net_Sistem, Cikis_Tutari_Net, Cikis_Tutari_Net_Baslik, Cikis_Tutari_Net_Kart, Cikis_Tutari_Net_Sistem, Aciklama, Silindi, Fis_Tipi, Isyeri_Kodu, Fis_No, Fis_Sira, Islem_Yonu) " +
                                          "VALUES (@Depo_Kodu, @Fis_Tarihi, @Fis_Saati, @Stok_No, @Birim_Kodu, @Giris_Miktari, @Cikis_Miktari, @Birim_Fiyati, @Isk_Orani_1, @Isk_Orani_2, @Isk_Orani_3, @Kdv_Orani, @Isk_Tutari_1, @Isk_Tutari_1_Baslik, @Isk_Tutari_1_Kart, @Isk_Tutari_1_Sistem, @Isk_Tutari_2, @Isk_Tutari_2_Baslik, @Isk_Tutari_2_Kart, @Isk_Tutari_2_Sistem, @Isk_Tutari_3, @Isk_Tutari_3_Baslik, @Isk_Tutari_3_Kart, @Isk_Tutari_3_Sistem, @Kdv_Tutari, @Kdv_Tutari_Baslik, @Kdv_Tutari_Kart, @Kdv_Tutari_Sistem, @Giris_Tutari, @Giris_Tutari_Baslik, @Giris_Tutari_Kart, @Giris_Tutari_Sistem, @Cikis_Tutari, @Cikis_Tutari_Baslik, @Cikis_Tutari_Kart, @Cikis_Tutari_Sistem, @Giris_Tutari_Net, @Giris_Tutari_Net_Baslik, @Giris_Tutari_Net_Kart, @Giris_Tutari_Net_Sistem, @Cikis_Tutari_Net, @Cikis_Tutari_Net_Baslik, @Cikis_Tutari_Net_Kart, @Cikis_Tutari_Net_Sistem, @Aciklama, @Silindi, @Fis_Tipi, @Isyeri_Kodu, @Fis_No, @Fis_Sira, @Islem_Yonu)";
                        cmd.Parameters.AddWithValue("@Depo_Kodu", strDepoKodu);
                        cmd.Parameters.AddWithValue("@Fis_Tarihi", dtpFisTarihi.Value.TODATE());
                        cmd.Parameters.AddWithValue("@Fis_Saati", dtpFisSaati.Value.TOTIME());
                        cmd.Parameters.AddWithValue("@Stok_No", DR["Stok_No"].TOINT());
                        cmd.Parameters.AddWithValue("@Birim_Kodu", DR["Birim_Kodu"].TOSTRING());
                        cmd.Parameters.AddWithValue("@Giris_Miktari", dblGirisMiktari);
                        cmd.Parameters.AddWithValue("@Cikis_Miktari", dblCikisMiktari);
                        cmd.Parameters.AddWithValue("@Birim_Fiyati", DR["Birim_Fiyati"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Isk_Orani_1", DR["Isk_Orani_1"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Isk_Orani_2", DR["Isk_Orani_2"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Isk_Orani_3", DR["Isk_Orani_3"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Kdv_Orani", DR["Kdv_Orani"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Isk_Tutari_1", DR["Isk_Tutari_1"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Isk_Tutari_1_Baslik", DR["Isk_Tutari_1"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Isk_Tutari_1_Kart", DR["Isk_Tutari_1"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Isk_Tutari_1_Sistem", DR["Isk_Tutari_1"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Isk_Tutari_2", DR["Isk_Tutari_2"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Isk_Tutari_2_Baslik", DR["Isk_Tutari_2"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Isk_Tutari_2_Kart", DR["Isk_Tutari_2"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Isk_Tutari_2_Sistem", DR["Isk_Tutari_2"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Isk_Tutari_3", DR["Isk_Tutari_3"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Isk_Tutari_3_Baslik", DR["Isk_Tutari_3"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Isk_Tutari_3_Kart", DR["Isk_Tutari_3"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Isk_Tutari_3_Sistem", DR["Isk_Tutari_3"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Kdv_Tutari", DR["Kdv_Tutari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Kdv_Tutari_Baslik", DR["Kdv_Tutari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Kdv_Tutari_Kart", DR["Kdv_Tutari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Kdv_Tutari_Sistem", DR["Kdv_Tutari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Giris_Tutari", dblGirisTutari);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Baslik", dblGirisTutari);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Kart", dblGirisTutari);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Sistem", dblGirisTutari);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari", dblCikisTutari);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Baslik", dblCikisTutari);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Kart", dblCikisTutari);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Sistem", dblCikisTutari);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Net", dblGirisTutariNet);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Net_Baslik", dblGirisTutariNet);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Net_Kart", dblGirisTutariNet);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Net_Sistem", dblGirisTutariNet);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Net", dblCikisTutariNet);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Net_Baslik", dblCikisTutariNet);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Net_Kart", dblCikisTutariNet);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Net_Sistem", dblCikisTutariNet);
                        cmd.Parameters.AddWithValue("@Aciklama", DR["Aciklama"].TOSTRING());
                        cmd.Parameters.AddWithValue("@Silindi", 0);
                        cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                        cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                        cmd.Parameters.AddWithValue("@Fis_No", txtFisNo.Text.TOINT());
                        cmd.Parameters.AddWithValue("@Fis_Sira", iSira + 1);
                        cmd.Parameters.AddWithValue("@Islem_Yonu", ((int)iyIslemYonuS));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }

                cmd.CommandText = "INSERT INTO Stok_Bagli_Irsaliyeler (Irsaliye_Fis_Tipi, Irsaliye_Isyeri_Kodu, Irsaliye_Fis_No, Fatura_Fis_Tipi, Fatura_Isyeri_Kodu, Fatura_Fis_No) VALUES (@Irsaliye_Fis_Tipi, @Irsaliye_Isyeri_Kodu, @Irsaliye_Fis_No, @Fatura_Fis_Tipi, @Fatura_Isyeri_Kodu, @Fatura_Fis_No)";
                for (int i = 0; i < lstBagliIrsaliyeFisTipi.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@Irsaliye_Fis_Tipi", lstBagliIrsaliyeFisTipi[i]);
                    cmd.Parameters.AddWithValue("@Irsaliye_Isyeri_Kodu", lstBagliIrsaliyeIsyeriKodu[i]);
                    cmd.Parameters.AddWithValue("@Irsaliye_Fis_No", lstBagliIrsaliyeFisNo[i]);
                    cmd.Parameters.AddWithValue("@Fatura_Fis_Tipi", intFisTipi);
                    cmd.Parameters.AddWithValue("@Fatura_Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode());
                    cmd.Parameters.AddWithValue("@Fatura_Fis_No", txtFisNo.Text.TOINT());
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
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
            object o = clsXKod.fncSECFisStok(ftFisTipi, cbIsyeriKodu.SelectedItemForCode().TOINT());
            if (o != null)
            {
                txtFisNo.Text = o.TOSTRING();
                txtFisNo_KeyDown(txtFisNo, new KeyEventArgs(Keys.Return));
            }
        }

        private void txtCariKodu_TextChanged(object sender, EventArgs e)
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

        private void btnSecKasaKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECKasa();
            if (o != null)
            {
                txtKasaKodu.Text = o.TOSTRING();
            }
        }

        private void tsbIrsaliye_Click(object sender, EventArgs e)
        {
            if (intCariNo != 0)
            {
                frmSecIrsaliye frmForm = new frmSecIrsaliye(intFisTipi, cbIsyeriKodu.SelectedItemForCode().TOINT(), txtFisNo.Text.TOINT(), intCariNo);
                if (frmForm.ShowDialog() == DialogResult.OK)
                {
                    lstBagliIrsaliyeFisTipi.Clear();
                    lstBagliIrsaliyeIsyeriKodu.Clear();
                    lstBagliIrsaliyeFisNo.Clear();

                    lstBagliIrsaliyeFisTipi.AddRange(frmForm.lstResultFisTipi);
                    lstBagliIrsaliyeIsyeriKodu.AddRange(frmForm.lstResultIsyeriKodu);
                    lstBagliIrsaliyeFisNo.AddRange(frmForm.lstResultFisNo);

                    prcdFaturaAktifPasifKontrol(lstBagliIrsaliyeFisTipi.Count == 0);

                    txtFaturaIrsaliyeNo.Text = "";
                    for (int i = 0; i < frmForm.lstResultBelgeNo.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(txtFaturaIrsaliyeNo.Text.Trim())) txtFaturaIrsaliyeNo.Text += ", ";
                        txtFaturaIrsaliyeNo.Text += frmForm.lstResultBelgeNo[i];
                    }

                    prcdDetayGetir();
                    blnDegisti = true;
                }
                frmForm.Dispose();
            }
            else
            {
                MessageBox.Show("Lütfen bir cari seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void prcdFaturaAktifPasifKontrol(bool blnEnabled = true)
        {
            dgvKalemler.ReadOnly = !blnEnabled;
            dgvKalemler.AllowUserToAddRows = blnEnabled;
            dgvKalemler.AllowUserToDeleteRows = blnEnabled;
        }
    }
}