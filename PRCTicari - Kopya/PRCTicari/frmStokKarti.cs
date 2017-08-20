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
    public partial class frmStokKarti : Form
    {
        bool blnYeniKayit = true;
        DataTable dtTedarikciler = new DataTable();
        DataTable dtAlislar = new DataTable();
        DataTable dtBagliStoklar = new DataTable();

        public frmStokKarti()
        {
            InitializeComponent();
        }

        private void frmStokKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            nudBT1AlisFiyati.TextChanged += new EventHandler(nudBT1AlisFiyati_TextChanged);
            nudBT2AlisFiyati.TextChanged += new EventHandler(nudBT2AlisFiyati_TextChanged);
            nudBT1AlisFiyatiKdvli.TextChanged += new EventHandler(nudBT1AlisFiyatiKdvli_TextChanged);
            nudBT2AlisFiyatiKdvli.TextChanged += new EventHandler(nudBT2AlisFiyatiKdvli_TextChanged);

            clsGenel.prcdFillComboBox("STOK_Birim_Tanitimi", "Birim_Kodu", "Birim_Adi", new ComboBox[] { cbBT1BirimTipi, cbBT2BirimTipi }, true);
            clsGenel.prcdFillComboBox("Kdv_Tanitimi", "Kdv_Orani", "Kdv_Adi", new ComboBox[] { cbKdvPerakende, cbKdvToptan }, false);

            tsbVazgec.PerformClick();
        }

        public void prcdAktifPasifKontrol(bool blnEnabled)
        {
            pnlBaslik.Enabled = !blnEnabled;
            pnlDetay.Enabled = blnEnabled;
            tsbKaydet.Enabled = blnEnabled;
            tsbSil.Enabled = blnEnabled;
            tsbVazgec.Enabled = blnEnabled;
            if (blnEnabled)
                txtStokAdi.Focus();
            else
                txtStokKodu.Focus();
        }

        public void prcdTemizle()
        {
            lblStokNo.Text = "0";
            txtStokAdi.Clear();
            txtKisaAdi.Clear();
            txtGrupKodu.Clear();
            txtOzelKodu.Clear();
            cbKdvToptan.SelectedItemByCode();
            cbKdvPerakende.SelectedItemByCode();
            cbStokTipi.SelectedIndex = 0;
            txtDepartmanKodu.Clear();
            txtReyonKodu.Clear();
            nudRafOmru.Value = 0;
            txtRuhsatSahibi.Clear();
            nudMinMiktar.Value = 0;
            nudMaxMiktar.Value = 0;
            txtGidaUretimIzni.Clear();
            dtpRuhsatTarihi.Value = DateTime.Now.Date;
            txtUrunNotu.Clear();
            txtUrunIcerikBilgisi.Clear();
            txtAlerjenUyarisi.Clear();
            txtOzelKodu1.Clear();
            txtOzelKodu2.Clear();
            txtOzelKodu3.Clear();
            txtOzelKodu4.Clear();
            txtOzelKodu5.Clear();
            txtOzelKodu6.Clear();
            txtOzelKodu7.Clear();
            txtOzelKodu8.Clear();
            txtOzelKodu9.Clear();
            txtOzelKodu10.Clear();
            txtOzelKodu11.Clear();
            txtOzelKodu12.Clear();
            txtOzelKodu13.Clear();
            txtOzelKodu14.Clear();
            txtOzelKodu15.Clear();
            cbBT1BirimTipi.SelectedItemByCode();
            nudBT1BirimOrani.Value = 1;
            txtBT1Barkod.Clear();
            cbBT1HizliSatis.Checked = false;
            nudBT1AlisFiyati.Value = 0;
            nudBT1AlisFiyatiKdvli.Value = 0;
            nudBT1SatisFiyati1.Value = 0;
            nudBT1SatisFiyati2.Value = 0;
            nudBT1SatisFiyati3.Value = 0;
            cbBT2BirimTipi.SelectedItemByCode();
            nudBT2BirimOrani.Value = 1;
            txtBT2Barkod.Clear();
            cbBT2HizliSatis.Checked = false;
            nudBT2AlisFiyati.Value = 0;
            nudBT2AlisFiyatiKdvli.Value = 0;
            nudBT2SatisFiyati1.Value = 0;
            nudBT2SatisFiyati2.Value = 0;
            nudBT2SatisFiyati3.Value = 0;
            cbDurum.SelectedIndex = 0;
            pbResim.Image = null;
            nudKarbonhidrat.Value = 0;
            nudProtein.Value = 0;
            nudYag.Value = 0;
            nudDoymusYag.Value = 0;
            nudLif.Value = 0;
            nudKolesterol.Value = 0;
            nudSodyum.Value = 0;
            nudPotasyum.Value = 0;
            nudKalsiyum.Value = 0;
            nudVitaminA.Value = 0;
            nudVitaminC.Value = 0;
            nudDemir.Value = 0;
            nudEnerji.Value = 0;
            nudSeker.Value = 0;
            dtTedarikciler.Rows.Clear();
            dtAlislar.Rows.Clear();
            dtBagliStoklar.Rows.Clear();
            tcDetay.SelectedTab = tpGenel;
            tcBirimler.SelectedTab = tpBirim1;

            blnYeniKayit = true;
        }

        private void tsbVazgec_Click(object sender, EventArgs e)
        {
            prcdTemizle();
            prcdAktifPasifKontrol(false);
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int fncYeniStokNoGetir()
        {
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT ISNULL(MAX(Stok_No), CAST(0 AS INT)) + 1 AS Stok_No FROM Stok_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            int intYeniStokNo = cmd.ExecuteScalar().TOINT(0);
            cmd.Dispose();
            cnn.Close();

            return intYeniStokNo;
        }

        private void txtStokKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (!string.IsNullOrEmpty(txtStokKodu.Text.Trim()))
                {
                    SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                    cnn.Open();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Stok_Tanitimi WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Stok_Kodu = @Stok_Kodu";
                    cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                    cmd.Parameters.AddWithValue("@Stok_Kodu", txtStokKodu.Text.Trim());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblStokNo.Text = reader["Stok_No"].TOSTRING();
                        txtStokAdi.Text = reader["Stok_Adi"].TOSTRING();
                        txtKisaAdi.Text = reader["Kisa_Adi"].TOSTRING();
                        txtGrupKodu.Text = reader["Grup_Kodu"].TOSTRING();
                        txtOzelKodu.Text = reader["Ozel_Kodu"].TOSTRING();
                        cbKdvToptan.SelectedItemByCode(reader["Kdv_Toptan"].TOSTRING());
                        cbKdvPerakende.SelectedItemByCode(reader["Kdv_Perakende"].TOSTRING());
                        cbStokTipi.SelectedIndex = reader["Stok_Tipi"].TOINT();
                        txtDepartmanKodu.Text = reader["Departman_Kodu"].TOSTRING();
                        nudMinMiktar.Value = reader["Min_Miktar"].TODECIMAL();
                        nudMaxMiktar.Value = reader["Max_Miktar"].TODECIMAL();
                        nudRafOmru.Value = reader["Raf_Omru"].TODECIMAL();
                        txtReyonKodu.Text = reader["Reyon_Kodu"].TOSTRING();
                        txtUrunNotu.Text = reader["Urun_Notu"].TOSTRING();
                        txtUrunIcerikBilgisi.Text = reader["Urun_Icerigi"].TOSTRING();
                        txtRuhsatSahibi.Text = reader["Ruhsat_Sahibi"].TOSTRING();
                        dtpRuhsatTarihi.Value = reader["Ruhsat_Tarihi"].TODATE();
                        txtGidaUretimIzni.Text = reader["Gida_Uretim_Izni"].TOSTRING();
                        txtAlerjenUyarisi.Text = reader["Alerjen_Uyarisi"].TOSTRING();
                        cbBT1BirimTipi.SelectedItemByCode(reader["Birim_Kodu_1"].TOSTRING());
                        nudBT1BirimOrani.Value = reader["BT1_Orani"].TODECIMAL();
                        txtBT1Barkod.Text = reader["BT1_Barkod"].TOSTRING();
                        cbBT1HizliSatis.Checked = reader["BT1_Hizli_Satis"].TOINT() == 1;
                        cbBT2BirimTipi.SelectedItemByCode(reader["Birim_Kodu_2"].TOSTRING());
                        nudBT2BirimOrani.Value = reader["BT2_Orani"].TODECIMAL();
                        txtBT2Barkod.Text = reader["BT2_Barkod"].TOSTRING();
                        cbBT2HizliSatis.Checked = reader["BT2_Hizli_Satis"].TOINT() == 1;
                        nudBT1AlisFiyati.Value = reader["BT1_Alis_Fiyati"].TODECIMAL();
                        nudBT1AlisFiyatiKdvli.Value = reader["BT1_Alis_Kdvli_Fiyati"].TODECIMAL();
                        nudBT1SatisFiyati1.Value = reader["BT1_Satis_Fiyati_1"].TODECIMAL();
                        nudBT1SatisFiyati2.Value = reader["BT1_Satis_Fiyati_2"].TODECIMAL();
                        nudBT1SatisFiyati3.Value = reader["BT1_Satis_Fiyati_3"].TODECIMAL();
                        nudBT2AlisFiyati.Value = reader["BT2_Alis_Fiyati"].TODECIMAL();
                        nudBT2AlisFiyatiKdvli.Value = reader["BT2_Alis_Kdvli_Fiyati"].TODECIMAL();
                        nudBT2SatisFiyati1.Value = reader["BT2_Satis_Fiyati_1"].TODECIMAL();
                        nudBT2SatisFiyati2.Value = reader["BT2_Satis_Fiyati_2"].TODECIMAL();
                        nudBT2SatisFiyati3.Value = reader["BT2_Satis_Fiyati_3"].TODECIMAL();
                        cbDurum.SelectedIndex = reader["Durum"].TOINT();
                        pbResim.LOADIMAGE(reader["Resim"].TOBYTEARRAY());
                        nudKarbonhidrat.Value = reader["Karbonhidrat"].TODECIMAL();
                        nudProtein.Value = reader["Protein"].TODECIMAL();
                        nudYag.Value = reader["Yag"].TODECIMAL();
                        nudDoymusYag.Value = reader["Doymus_Yag"].TODECIMAL();
                        nudLif.Value = reader["Lif"].TODECIMAL();
                        nudKolesterol.Value = reader["Kolesterol"].TODECIMAL();
                        nudSodyum.Value = reader["Sodyum"].TODECIMAL();
                        nudPotasyum.Value = reader["Potasyum"].TODECIMAL();
                        nudKalsiyum.Value = reader["Kalsiyum"].TODECIMAL();
                        nudVitaminA.Value = reader["Vitamin_A"].TODECIMAL();
                        nudVitaminC.Value = reader["Vitamin_C"].TODECIMAL();
                        nudDemir.Value = reader["Demir"].TODECIMAL();
                        nudEnerji.Value = reader["Enerji"].TODECIMAL();
                        nudSeker.Value = reader["Seker"].TODECIMAL();
                        txtOzelKodu1.Text = reader["Ozel_Kodu_1"].TOSTRING();
                        txtOzelKodu2.Text = reader["Ozel_Kodu_2"].TOSTRING();
                        txtOzelKodu3.Text = reader["Ozel_Kodu_3"].TOSTRING();
                        txtOzelKodu4.Text = reader["Ozel_Kodu_4"].TOSTRING();
                        txtOzelKodu5.Text = reader["Ozel_Kodu_5"].TOSTRING();
                        txtOzelKodu6.Text = reader["Ozel_Kodu_6"].TOSTRING();
                        txtOzelKodu7.Text = reader["Ozel_Kodu_7"].TOSTRING();
                        txtOzelKodu8.Text = reader["Ozel_Kodu_8"].TOSTRING();
                        txtOzelKodu9.Text = reader["Ozel_Kodu_9"].TOSTRING();
                        txtOzelKodu10.Text = reader["Ozel_Kodu_10"].TOSTRING();
                        txtOzelKodu11.Text = reader["Ozel_Kodu_11"].TOSTRING();
                        txtOzelKodu12.Text = reader["Ozel_Kodu_12"].TOSTRING();
                        txtOzelKodu13.Text = reader["Ozel_Kodu_13"].TOSTRING();
                        txtOzelKodu14.Text = reader["Ozel_Kodu_14"].TOSTRING();
                        txtOzelKodu15.Text = reader["Ozel_Kodu_15"].TOSTRING();

                        blnYeniKayit = false;
                    }
                    reader.Close();
                    cmd.Parameters.Clear();

                    cmd.CommandText = "SELECT STT.Tedarikci_No, CT.Cari_Kodu AS Tedarikci_Kodu, '...' AS Tedarikci_Sec, CT.Unvani AS Tedarikci_Adi FROM Stok_Tanitimi AS ST INNER JOIN Stok_Tedarikci_Tanitimi AS STT ON ST.Kurum_Kodu = STT.Kurum_Kodu AND ST.Stok_No = STT.Stok_No INNER JOIN Cari_Tanitimi AS CT ON CT.Silindi = 0 AND CT.Kurum_Kodu = STT.Kurum_Kodu AND CT.Cari_No = STT.Tedarikci_No WHERE ST.Silindi = 0 AND ST.Kurum_Kodu = @Kurum_Kodu AND ST.Stok_No = @Stok_No";
                    cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                    cmd.Parameters.AddWithValue("@Stok_No", lblStokNo.Text.Trim());
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dtTedarikciler);
                    sda.Dispose();
                    cmd.Parameters.Clear();
                    dgvTedarikciler.DataSource = dtTedarikciler;

                    cmd.CommandText = "SELECT SBT.Bagli_Stok_No AS Stok_No, ST.Stok_Kodu AS Stok_Kodu, '...' AS Sec_Stok_Kodu, ST.Stok_Adi FROM Stok_Bagli_Tanitimi AS SBT INNER JOIN Stok_Tanitimi AS ST ON ST.Silindi = 0 AND ST.Kurum_Kodu = SBT.Kurum_Kodu AND ST.Stok_No = SBT.Bagli_Stok_No WHERE SBT.Kurum_Kodu = @Kurum_Kodu AND SBT.Stok_No = @Stok_No ORDER BY SBT.Sira_No";
                    cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                    cmd.Parameters.AddWithValue("@Stok_No", lblStokNo.Text.Trim());
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(dtBagliStoklar);
                    sda.Dispose();
                    dgvBagliStoklar.DataSource = dtBagliStoklar;

                    cmd.Dispose();
                    cnn.Close();

                    prcdAktifPasifKontrol(true);
                }
                else
                {
                    MessageBox.Show("Lütfen bir stok kodu giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            if (cbBT1HizliSatis.Checked && string.IsNullOrEmpty(txtBT1Barkod.Text.Trim()))
            {
                MessageBox.Show("Bu stoğun hızlı satışta kullanılabilmesi için bir barkoda ihtiyacı vardır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tcBirimler.SelectedTab = tpBirim1;
                txtBT1Barkod.Focus();
                return;
            }

            if (cbBT2HizliSatis.Checked && string.IsNullOrEmpty(txtBT2Barkod.Text.Trim()))
            {
                MessageBox.Show("Bu stoğun hızlı satışta kullanılabilmesi için bir barkoda ihtiyacı vardır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tcBirimler.SelectedTab = tpBirim2;
                txtBT2Barkod.Focus();
                return;
            }

            string strStok = clsGenel.fncBarkodKontrol(lblStokNo.Text.TOINT(), txtBT1Barkod.Text.Trim());
            if (!string.IsNullOrEmpty(strStok.Trim()))
            {
                MessageBox.Show("1. birimdeki barkod başka bir stokta kullanılmış." + Environment.NewLine + "(" + strStok + ")", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tcBirimler.SelectedTab = tpBirim1;
                txtBT1Barkod.Focus();
                return;
            }

            strStok = clsGenel.fncBarkodKontrol(lblStokNo.Text.TOINT(), txtBT2Barkod.Text.Trim());
            if (!string.IsNullOrEmpty(strStok.Trim()))
            {
                MessageBox.Show("2. birimdeki barkod başka bir stokta kullanılmış." + Environment.NewLine + "(" + strStok + ")", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                tcBirimler.SelectedTab = tpBirim2;
                txtBT2Barkod.Focus();
                return;
            }

            dgvTedarikciler.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgvTedarikciler.CurrentCell = dgvTedarikciler.Rows[dgvTedarikciler.NewRowIndex].Cells[colTedarikciKodu.Name];
            dgvBagliStoklar.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgvBagliStoklar.CurrentCell = dgvBagliStoklar.Rows[dgvBagliStoklar.NewRowIndex].Cells[colStokKodu.Name];

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            if (blnYeniKayit)
            {
                lblStokNo.Text = fncYeniStokNoGetir().TOSTRING();
                cmd.CommandText = "INSERT INTO Stok_Tanitimi (Stok_No, Stok_Adi, Kisa_Adi, Grup_Kodu, Ozel_Kodu, Kdv_Toptan, Kdv_Perakende, Stok_Tipi, " +
                                  "Departman_Kodu, Min_Miktar, Max_Miktar, Raf_Omru, Reyon_Kodu, Urun_Notu, Urun_Icerigi, Ruhsat_Sahibi, Ruhsat_Tarihi, Gida_Uretim_Izni, Alerjen_Uyarisi, " +
                                  "Birim_Kodu_1, BT1_Orani, BT1_Barkod, BT1_Hizli_Satis, BT1_Alis_Fiyati, BT1_Alis_Kdvli_Fiyati, BT1_Satis_Fiyati_1, BT1_Satis_Fiyati_2, BT1_Satis_Fiyati_3, " +
                                  "Birim_Kodu_2, BT2_Orani, BT2_Barkod, BT2_Hizli_Satis, BT2_Alis_Fiyati, BT2_Alis_Kdvli_Fiyati, BT2_Satis_Fiyati_1, BT2_Satis_Fiyati_2, BT2_Satis_Fiyati_3, " +
                                  "Durum, Resim, Karbonhidrat, Protein, Yag, Doymus_Yag, Lif, Kolesterol, " +
                                  "Sodyum, Potasyum, Kalsiyum, Vitamin_A, Vitamin_C, Demir, Enerji, Seker, " +
                                  "Ozel_Kodu_1, Ozel_Kodu_2, Ozel_Kodu_3, Ozel_Kodu_4, Ozel_Kodu_5, Ozel_Kodu_6, Ozel_Kodu_7, Ozel_Kodu_8, Ozel_Kodu_9, Ozel_Kodu_10, Ozel_Kodu_11, Ozel_Kodu_12, Ozel_Kodu_13, Ozel_Kodu_14, Ozel_Kodu_15, " +
                                  "Insert_User, Insert_Date, Kurum_Kodu, Stok_Kodu) " +
                                  "VALUES (@Stok_No, @Stok_Adi, @Kisa_Adi, @Grup_Kodu, @Ozel_Kodu, @Kdv_Toptan, @Kdv_Perakende, @Stok_Tipi, " +
                                  "@Departman_Kodu, @Min_Miktar, @Max_Miktar, @Raf_Omru, @Reyon_Kodu, @Urun_Notu, @Urun_Icerigi, @Ruhsat_Sahibi, @Ruhsat_Tarihi, @Gida_Uretim_Izni, @Alerjen_Uyarisi, " +
                                  "@Birim_Kodu_1, @BT1_Orani, @BT1_Barkod, @BT1_Hizli_Satis, @BT1_Alis_Fiyati, @BT1_Alis_Kdvli_Fiyati, @BT1_Satis_Fiyati_1, @BT1_Satis_Fiyati_2, @BT1_Satis_Fiyati_3, " +
                                  "@Birim_Kodu_2, @BT2_Orani, @BT2_Barkod, @BT2_Hizli_Satis, @BT2_Alis_Fiyati, @BT2_Alis_Kdvli_Fiyati, @BT2_Satis_Fiyati_1, @BT2_Satis_Fiyati_2, @BT2_Satis_Fiyati_3, " +
                                  "@Durum, @Resim, @Karbonhidrat, @Protein, @Yag, @Doymus_Yag, @Lif, @Kolesterol, " +
                                  "@Sodyum, @Potasyum, @Kalsiyum, @Vitamin_A, @Vitamin_C, @Demir, @Enerji, @Seker, " +
                                  "@Ozel_Kodu_1, @Ozel_Kodu_2, @Ozel_Kodu_3, @Ozel_Kodu_4, @Ozel_Kodu_5, @Ozel_Kodu_6, @Ozel_Kodu_7, @Ozel_Kodu_8, @Ozel_Kodu_9, @Ozel_Kodu_10, @Ozel_Kodu_11, @Ozel_Kodu_12, @Ozel_Kodu_13, @Ozel_Kodu_14, @Ozel_Kodu_15, " +
                                  "@Kullanici, @Zaman, @Kurum_Kodu, @Stok_Kodu)";
            }
            else
                cmd.CommandText = "UPDATE Stok_Tanitimi SET Stok_No = @Stok_No, Stok_Adi = @Stok_Adi, Kisa_Adi = @Kisa_Adi, Grup_Kodu = @Grup_Kodu, Ozel_Kodu = @Ozel_Kodu, Kdv_Toptan = @Kdv_Toptan, Kdv_Perakende = @Kdv_Perakende, Stok_Tipi = @Stok_Tipi, " +
                                  "Departman_Kodu = @Departman_Kodu, Min_Miktar = @Min_Miktar, Max_Miktar = @Max_Miktar, Raf_Omru = @Raf_Omru, Reyon_Kodu = @Reyon_Kodu, Urun_Notu = @Urun_Notu, Urun_Icerigi = @Urun_Icerigi, Ruhsat_Sahibi = @Ruhsat_Sahibi, Ruhsat_Tarihi = @Ruhsat_Tarihi, Gida_Uretim_Izni = @Gida_Uretim_Izni, Alerjen_Uyarisi = @Alerjen_Uyarisi, " +
                                  "Birim_Kodu_1 = @Birim_Kodu_1, BT1_Orani = @BT1_Orani, BT1_Barkod = @BT1_Barkod, BT1_Hizli_Satis = @BT1_Hizli_Satis, BT1_Alis_Fiyati = @BT1_Alis_Fiyati, BT1_Alis_Kdvli_Fiyati = @BT1_Alis_Kdvli_Fiyati, BT1_Satis_Fiyati_1 = @BT1_Satis_Fiyati_1, BT1_Satis_Fiyati_2 = @BT1_Satis_Fiyati_2, BT1_Satis_Fiyati_3 = @BT1_Satis_Fiyati_3, " +
                                  "Birim_Kodu_2 = @Birim_Kodu_2, BT2_Orani = @BT2_Orani, BT2_Barkod = @BT2_Barkod, BT2_Hizli_Satis = @BT2_Hizli_Satis, BT2_Alis_Fiyati = @BT2_Alis_Fiyati, BT2_Alis_Kdvli_Fiyati = @BT2_Alis_Kdvli_Fiyati, BT2_Satis_Fiyati_1 = @BT2_Satis_Fiyati_1, BT2_Satis_Fiyati_2 = @BT2_Satis_Fiyati_2, BT2_Satis_Fiyati_3 = @BT2_Satis_Fiyati_3, " +
                                  "Durum = @Durum, Resim = @Resim, Karbonhidrat = @Karbonhidrat, Protein = @Protein, Yag = @Yag, Doymus_Yag = @Doymus_Yag, Lif = @Lif, Kolesterol = @Kolesterol, " +
                                  "Sodyum = @Sodyum, Potasyum = @Potasyum, Kalsiyum = @Kalsiyum, Vitamin_A = @Vitamin_A, Vitamin_C = @Vitamin_C, Demir = @Demir, Enerji = @Enerji, Seker = @Seker, " +
                                  "Ozel_Kodu_1 = @Ozel_Kodu_1, Ozel_Kodu_2 = @Ozel_Kodu_2, Ozel_Kodu_3 = @Ozel_Kodu_3, Ozel_Kodu_4 = @Ozel_Kodu_4, Ozel_Kodu_5 = @Ozel_Kodu_5, Ozel_Kodu_6 = @Ozel_Kodu_6, Ozel_Kodu_7 = @Ozel_Kodu_7, Ozel_Kodu_8 = @Ozel_Kodu_8, Ozel_Kodu_9 = @Ozel_Kodu_9, Ozel_Kodu_10 = @Ozel_Kodu_10, Ozel_Kodu_11 = @Ozel_Kodu_11, Ozel_Kodu_12 = @Ozel_Kodu_12, Ozel_Kodu_13 = @Ozel_Kodu_13, Ozel_Kodu_14 = @Ozel_Kodu_14, Ozel_Kodu_15 = @Ozel_Kodu_15, " +
                                  "Update_User = @Kullanici, Update_Date = @Zaman " +
                                  "WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Stok_Kodu = @Stok_Kodu";

            cmd.Parameters.AddWithValue("@Stok_No", lblStokNo.Text.Trim());
            cmd.Parameters.AddWithValue("@Stok_Adi", txtStokAdi.Text.Trim());
            cmd.Parameters.AddWithValue("@Kisa_Adi", txtKisaAdi.Text.Trim());
            cmd.Parameters.AddWithValue("@Grup_Kodu", txtGrupKodu.Text.Trim());
            cmd.Parameters.AddWithValue("@Ozel_Kodu", txtOzelKodu.Text.Trim());
            cmd.Parameters.AddWithValue("@Kdv_Toptan", cbKdvToptan.SelectedItemForCode().TODOUBLE(0));
            cmd.Parameters.AddWithValue("@Kdv_Perakende", cbKdvPerakende.SelectedItemForCode().TODOUBLE(0));
            cmd.Parameters.AddWithValue("@Stok_Tipi", cbStokTipi.SelectedIndex);
            cmd.Parameters.AddWithValue("@Departman_Kodu", txtDepartmanKodu.Text.Trim());
            cmd.Parameters.AddWithValue("@Min_Miktar", nudMinMiktar.Value);
            cmd.Parameters.AddWithValue("@Max_Miktar", nudMaxMiktar.Value);
            cmd.Parameters.AddWithValue("@Raf_Omru", nudRafOmru.Value.TOINT());
            cmd.Parameters.AddWithValue("@Reyon_Kodu", txtReyonKodu.Text.Trim());
            cmd.Parameters.AddWithValue("@Urun_Notu", txtUrunNotu.Text.Trim());
            cmd.Parameters.AddWithValue("@Urun_Icerigi", txtUrunIcerikBilgisi.Text.Trim());
            cmd.Parameters.AddWithValue("@Ruhsat_Sahibi", txtRuhsatSahibi.Text.Trim());
            cmd.Parameters.AddWithValue("@Ruhsat_Tarihi", dtpRuhsatTarihi.Value.Date);
            cmd.Parameters.AddWithValue("@Gida_Uretim_Izni", txtGidaUretimIzni.Text.Trim());
            cmd.Parameters.AddWithValue("@Alerjen_Uyarisi", txtAlerjenUyarisi.Text.Trim());
            cmd.Parameters.AddWithValue("@Birim_Kodu_1", cbBT1BirimTipi.SelectedItemForCode());
            cmd.Parameters.AddWithValue("@BT1_Orani", nudBT1BirimOrani.Value);
            cmd.Parameters.AddWithValue("@BT1_Barkod", txtBT1Barkod.Text.Trim());
            cmd.Parameters.AddWithValue("@BT1_Hizli_Satis", (cbBT1HizliSatis.Checked ? 1 : 0));
            cmd.Parameters.AddWithValue("@BT1_Alis_Fiyati", nudBT1AlisFiyati.Value);
            cmd.Parameters.AddWithValue("@BT1_Alis_Kdvli_Fiyati", nudBT1AlisFiyatiKdvli.Value);
            cmd.Parameters.AddWithValue("@BT1_Satis_Fiyati_1", nudBT1SatisFiyati1.Value);
            cmd.Parameters.AddWithValue("@BT1_Satis_Fiyati_2", nudBT1SatisFiyati2.Value);
            cmd.Parameters.AddWithValue("@BT1_Satis_Fiyati_3", nudBT1SatisFiyati3.Value);
            cmd.Parameters.AddWithValue("@Birim_Kodu_2", cbBT2BirimTipi.SelectedItemForCode());
            cmd.Parameters.AddWithValue("@BT2_Orani", nudBT2BirimOrani.Value);
            cmd.Parameters.AddWithValue("@BT2_Barkod", txtBT2Barkod.Text.Trim());
            cmd.Parameters.AddWithValue("@BT2_Hizli_Satis", (cbBT2HizliSatis.Checked ? 1 : 0));
            cmd.Parameters.AddWithValue("@BT2_Alis_Fiyati", nudBT2AlisFiyati.Value);
            cmd.Parameters.AddWithValue("@BT2_Alis_Kdvli_Fiyati", nudBT2AlisFiyatiKdvli.Value);
            cmd.Parameters.AddWithValue("@BT2_Satis_Fiyati_1", nudBT2SatisFiyati1.Value);
            cmd.Parameters.AddWithValue("@BT2_Satis_Fiyati_2", nudBT2SatisFiyati2.Value);
            cmd.Parameters.AddWithValue("@BT2_Satis_Fiyati_3", nudBT2SatisFiyati3.Value);
            cmd.Parameters.AddWithValue("@Durum", cbDurum.SelectedIndex);
            cmd.Parameters.AddWithValue("@Resim", pbResim.TOBYTEARRAY());
            cmd.Parameters.AddWithValue("@Karbonhidrat", nudKarbonhidrat.Value);
            cmd.Parameters.AddWithValue("@Protein", nudProtein.Value);
            cmd.Parameters.AddWithValue("@Yag", nudYag.Value);
            cmd.Parameters.AddWithValue("@Doymus_Yag", nudDoymusYag.Value);
            cmd.Parameters.AddWithValue("@Lif", nudLif.Value);
            cmd.Parameters.AddWithValue("@Kolesterol", nudKolesterol.Value);
            cmd.Parameters.AddWithValue("@Sodyum", nudSodyum.Value);
            cmd.Parameters.AddWithValue("@Potasyum", nudPotasyum.Value);
            cmd.Parameters.AddWithValue("@Kalsiyum", nudKalsiyum.Value);
            cmd.Parameters.AddWithValue("@Vitamin_A", nudVitaminA.Value);
            cmd.Parameters.AddWithValue("@Vitamin_C", nudVitaminC.Value);
            cmd.Parameters.AddWithValue("@Demir", nudDemir.Value);
            cmd.Parameters.AddWithValue("@Enerji", nudEnerji.Value);
            cmd.Parameters.AddWithValue("@Seker", nudSeker.Value);
            cmd.Parameters.AddWithValue("@Ozel_Kodu_1", txtOzelKodu1.Text);
            cmd.Parameters.AddWithValue("@Ozel_Kodu_2", txtOzelKodu2.Text);
            cmd.Parameters.AddWithValue("@Ozel_Kodu_3", txtOzelKodu3.Text);
            cmd.Parameters.AddWithValue("@Ozel_Kodu_4", txtOzelKodu4.Text);
            cmd.Parameters.AddWithValue("@Ozel_Kodu_5", txtOzelKodu5.Text);
            cmd.Parameters.AddWithValue("@Ozel_Kodu_6", txtOzelKodu6.Text);
            cmd.Parameters.AddWithValue("@Ozel_Kodu_7", txtOzelKodu7.Text);
            cmd.Parameters.AddWithValue("@Ozel_Kodu_8", txtOzelKodu8.Text);
            cmd.Parameters.AddWithValue("@Ozel_Kodu_9", txtOzelKodu9.Text);
            cmd.Parameters.AddWithValue("@Ozel_Kodu_10", txtOzelKodu10.Text);
            cmd.Parameters.AddWithValue("@Ozel_Kodu_11", txtOzelKodu11.Text);
            cmd.Parameters.AddWithValue("@Ozel_Kodu_12", txtOzelKodu12.Text);
            cmd.Parameters.AddWithValue("@Ozel_Kodu_13", txtOzelKodu13.Text);
            cmd.Parameters.AddWithValue("@Ozel_Kodu_14", txtOzelKodu14.Text);
            cmd.Parameters.AddWithValue("@Ozel_Kodu_15", txtOzelKodu15.Text);
            cmd.Parameters.AddWithValue("@Kullanici", clsGenel.strKullaniciKodu);
            cmd.Parameters.AddWithValue("@Zaman", DateTime.Now);
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Stok_Kodu", txtStokKodu.Text.Trim());
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            cmd.CommandText = "DELETE FROM Stok_Tedarikci_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu AND Stok_No = @Stok_No";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Stok_No", lblStokNo.Text.Trim());
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            cmd.CommandText = "INSERT INTO Stok_Tedarikci_Tanitimi (Kurum_Kodu, Stok_No, Tedarikci_No) VALUES (@Kurum_Kodu, @Stok_No, @Tedarikci_No)";
            foreach (DataRow DR in dtTedarikciler.Rows)
            {
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Stok_No", lblStokNo.Text.Trim());
                cmd.Parameters.AddWithValue("@Tedarikci_No", DR["Tedarikci_No"]);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }

            cmd.CommandText = "DELETE FROM Stok_Bagli_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu AND Stok_No = @Stok_No";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Stok_No", lblStokNo.Text.Trim());
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            cmd.CommandText = "INSERT INTO Stok_Bagli_Tanitimi (Kurum_Kodu, Stok_No, Sira_No, Bagli_Stok_No) VALUES (@Kurum_Kodu, @Stok_No, @Sira_No, @Bagli_Stok_No)";
            for (int i = 0; i < dtBagliStoklar.Rows.Count; i++)
            {
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Stok_No", lblStokNo.Text.Trim());
                cmd.Parameters.AddWithValue("@Sira_No", i + 1);
                cmd.Parameters.AddWithValue("@Bagli_Stok_No", dtBagliStoklar.Rows[i]["Stok_No"]);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }

            cmd.Dispose();
            cnn.Close();

            tsbVazgec.PerformClick();
        }

        private void tsbSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "UPDATE Stok_Tanitimi SET Silindi = 1, Delete_User = @Delete_User, Delete_Date = @Delete_Date WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Stok_Kodu = @Stok_Kodu";
                cmd.Parameters.AddWithValue("@Delete_User", clsGenel.strKullaniciKodu);
                cmd.Parameters.AddWithValue("@Delete_Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Stok_Kodu", txtStokKodu.Text.Trim());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();

                tsbVazgec.PerformClick();
            }
        }

        private void dgvTedarikciler_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTedarikciler.Columns[e.ColumnIndex].Name == colTedarikciKodu.Name)
            {
                prcdTedarikciBilgiGetir();
            }
        }

        private void dgvTedarikciler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (dgvTedarikciler.Columns[e.ColumnIndex].Name == colTedarikciSec.Name)
                {
                    object o = clsXKod.fncSECCari();
                    if (o != null)
                    {
                        if (e.RowIndex == dgvTedarikciler.NewRowIndex)
                        {
                            dtTedarikciler.Rows.Add(dtTedarikciler.NewRow());
                            if (dtTedarikciler.Rows.Count < dgvTedarikciler.Rows.Count - 1) dgvTedarikciler.Rows.RemoveAt(e.RowIndex + 1);
                            dgvTedarikciler.CurrentCell = dgvTedarikciler.Rows[dgvTedarikciler.Rows.Count - 2].Cells[colTedarikciKodu.Name];
                            dgvTedarikciler.CurrentRow.Cells["colTedarikciKodu"].Value = o.TOSTRING();
                        }
                        else
                            dgvTedarikciler.CurrentRow.Cells["colTedarikciKodu"].Value = o.TOSTRING();

                        prcdTedarikciBilgiGetir();
                    }
                }
            }
        }

        private void prcdTedarikciBilgiGetir()
        {
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Cari_Tanitimi WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Cari_Kodu = @Cari_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Cari_Kodu", dgvTedarikciler.CurrentRow.Cells["colTedarikciKodu"].Value);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dgvTedarikciler.CurrentRow.Cells["colTedarikciNo"].Value = reader["Cari_No"];
                dgvTedarikciler.CurrentRow.Cells["colTedarikciSec"].Value = "...";
                dgvTedarikciler.CurrentRow.Cells["colTedarikciAdi"].Value = reader["Unvani"];
            }
            else
            {
                dgvTedarikciler.CurrentRow.Cells["colTedarikciNo"].Value = 0;
                dgvTedarikciler.CurrentRow.Cells["colTedarikciSec"].Value = "...";
                dgvTedarikciler.CurrentRow.Cells["colTedarikciAdi"].Value = "";
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
        }

        private void nudBT1AlisFiyati_TextChanged(object sender, EventArgs e)
        {
            if (nudBT1AlisFiyati.Focused || cbKdvToptan.Focused)
            {
                nudBT1AlisFiyatiKdvli.Value = nudBT1AlisFiyati.Text.TODECIMAL(0) * (1 + (cbKdvToptan.SelectedItemForCode().TODECIMAL(0) / 100));

                if (cbKdvToptan.Focused)
                {
                    nudBT2AlisFiyati_TextChanged(sender, e);
                }
            }
        }

        private void nudBT2AlisFiyati_TextChanged(object sender, EventArgs e)
        {
            if (nudBT2AlisFiyati.Focused || cbKdvToptan.Focused)
            {
                nudBT2AlisFiyatiKdvli.Value = nudBT2AlisFiyati.Text.TODECIMAL(0) * (1 + (cbKdvToptan.SelectedItemForCode().TODECIMAL(0) / 100));
            }
        }

        private void nudBT1AlisFiyatiKdvli_TextChanged(object sender, EventArgs e)
        {
            if (nudBT1AlisFiyatiKdvli.Focused)
            {
                nudBT1AlisFiyati.Value = nudBT1AlisFiyatiKdvli.Text.TODECIMAL(0) / (1 + (cbKdvToptan.SelectedItemForCode().TODECIMAL(0) / 100));
            }
        }

        private void nudBT2AlisFiyatiKdvli_TextChanged(object sender, EventArgs e)
        {
            if (nudBT2AlisFiyatiKdvli.Focused)
            {
                nudBT2AlisFiyati.Value = nudBT2AlisFiyatiKdvli.Text.TODECIMAL(0) / (1 + (cbKdvToptan.SelectedItemForCode().TODECIMAL(0) / 100));
            }
        }

        private void frmStokKarti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.FocusNextControl();
            }
        }

        private void btnStokKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECStok();
            if (o != null)
            {
                txtStokKodu.Text = o.TOSTRING();
                txtStokKodu_KeyDown(txtStokKodu, new KeyEventArgs(Keys.Return));
            }
        }

        private void btnGrupKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECStokGrupKodu();
            if (o != null) txtGrupKodu.Text = o.TOSTRING();
        }

        private void btnOzelKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECStokOzelKodu();
            if (o != null) txtOzelKodu.Text = o.TOSTRING();
        }

        private void cbBT1HizliSatis_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBT1HizliSatis.Checked) cbBT2HizliSatis.Checked = false;
        }

        private void cbBT2HizliSatis_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBT2HizliSatis.Checked) cbBT1HizliSatis.Checked = false;
        }

        private void dgvBagliStoklar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (dgvBagliStoklar.Columns[e.ColumnIndex].Name == colSecStokKodu.Name)
                {
                    object o = clsXKod.fncSECStok();
                    if (o != null)
                    {
                        if (e.RowIndex == dgvBagliStoklar.NewRowIndex)
                        {
                            dtBagliStoklar.Rows.Add(dtBagliStoklar.NewRow());
                            if (dtBagliStoklar.Rows.Count < dgvBagliStoklar.Rows.Count - 1) dgvBagliStoklar.Rows.RemoveAt(e.RowIndex + 1);
                            dgvBagliStoklar.CurrentCell = dgvBagliStoklar.Rows[dgvBagliStoklar.Rows.Count - 2].Cells[colStokKodu.Name];
                            dgvBagliStoklar.CurrentRow.Cells["colStokKodu"].Value = o.TOSTRING();
                        }
                        else
                            dgvBagliStoklar.CurrentRow.Cells["colStokKodu"].Value = o.TOSTRING();

                        prcdStokBilgiGetir();
                    }
                }
            }
        }

        private void prcdStokBilgiGetir()
        {
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Stok_Tanitimi WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Stok_Kodu = @Stok_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Stok_Kodu", dgvBagliStoklar.CurrentRow.Cells["colStokKodu"].Value);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dgvBagliStoklar.CurrentRow.Cells["colStokNo"].Value = reader["Stok_No"];
                dgvBagliStoklar.CurrentRow.Cells["colSecStokKodu"].Value = "...";
                dgvBagliStoklar.CurrentRow.Cells["colStokAdi"].Value = reader["Stok_Adi"];
            }
            else
            {
                dgvBagliStoklar.CurrentRow.Cells["colStokNo"].Value = 0;
                dgvBagliStoklar.CurrentRow.Cells["colSecStokKodu"].Value = "...";
                dgvBagliStoklar.CurrentRow.Cells["colStokAdi"].Value = "";
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
        }

        private void dgvBagliStoklar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBagliStoklar.Columns[e.ColumnIndex].Name == colStokKodu.Name)
            {
                prcdStokBilgiGetir();
            }
        }

        private void lblResimEkle_Click(object sender, EventArgs e)
        {
            pbResim.LOADIMAGE();
        }

        private void lblResimSil_Click(object sender, EventArgs e)
        {
            pbResim.Image = null;
        }

        private void btnDepartmanKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECStokDepartmanKodu();
            if (o != null) txtDepartmanKodu.Text = o.TOSTRING();
        }

        private void btnReyonKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECStokReyonKodu();
            if (o != null) txtReyonKodu.Text = o.TOSTRING();
        }

        private void btnOzelKodu1_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECStokOzelKodlar(((Button)sender).Tag.TOINT());
            if (o != null) ((TextBox)tpOzelKodlar.Controls["txtOzelKodu" + ((Button)sender).Tag.TOSTRING()]).Text = o.TOSTRING();
        }
    }
}
