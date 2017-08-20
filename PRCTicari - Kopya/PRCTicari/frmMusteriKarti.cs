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
    public partial class frmMusteriKarti : Form
    {
        bool blnYeniKayit = true;
        DataTable dtYasakliUrunler = new DataTable();

        public frmMusteriKarti()
        {
            InitializeComponent();
        }

        private void frmOgrenciKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
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
                txtAdi.Focus();
            else
                txtMusteriKodu.Focus();
        }

        public void prcdTemizle()
        {
            lblMusteriNo.Text = "0";
            txtAdi.Clear();
            txtSoyadi.Clear();
            txtKartKodu.Clear();
            cbDurum.SelectedIndex = 0;
            cbTipi.SelectedIndex = 0;
            txtTCNo.Clear();
            dtpDogumTarihi.Value = DateTime.Now.Date;
            cbCinsiyeti.SelectedIndex = 0;
            nudBoy.Value = 0;
            nudKilo.Value = 0;
            nudHarcamaLimiti.Value = 0;
            txtSinifi.Clear();
            txtSubesi.Clear();
            txtOgrenciNo.Clear();
            pbResim.Image = null;
            txtMahalleKoy.Clear();
            txtCaddeSokak.Clear();
            txtDisKapiNo.Clear();
            txtSiteAdi.Clear();
            txtApartmanBlok.Clear();
            txtKat.Clear();
            txtDaire.Clear();
            txtIlce.Clear();
            txtIl.Clear();
            txtUlke.Clear();
            mtbTelefon1.Clear();
            mtbTelefon2.Clear();
            mtbTelefon3.Clear();
            mtbFax1.Clear();
            mtbFax2.Clear();
            txtEMail1.Clear();
            txtEMail2.Clear();
            txtVeliAdi.Clear();
            txtVeliSoyadi.Clear();
            cbVeliCinsiyeti.SelectedIndex = 0;
            mtbVeliTelefon1.Clear();
            mtbVeliTelefon2.Clear();
            txtVeliEMail.Clear();
            dtYasakliUrunler.Rows.Clear();
            cbVeliEMailGonder.Checked = false;
            tcDetay.SelectedTab = tpGenel;
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

        private int fncYeniCariNoGetir()
        {
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT ISNULL(MAX(Cari_No), CAST(0 AS INT)) + 1 AS Cari_No FROM Cari_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            int intYeniCariNo = cmd.ExecuteScalar().TOINT(0);
            cmd.Dispose();
            cnn.Close();

            return intYeniCariNo;
        }

        private void txtCariKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (!string.IsNullOrEmpty(txtMusteriKodu.Text.Trim()))
                {
                    SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                    cnn.Open();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Cari_Tanitimi WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Cari_Kodu = @Cari_Kodu";
                    cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                    cmd.Parameters.AddWithValue("@Cari_Kodu", txtMusteriKodu.Text.Trim());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblMusteriNo.Text = reader["Cari_No"].TOSTRING();
                        txtAdi.Text = reader["Adi"].TOSTRING();
                        txtSoyadi.Text = reader["Soyadi"].TOSTRING();
                        txtKartKodu.Text = reader["Kart_Kodu"].TOSTRING();
                        cbDurum.SelectedIndex = reader["Durum"].TOINT();
                        cbTipi.SelectedIndex = (reader["Ogrenci"].TOINT() == 1 ? 0 : (reader["Ogretmen"].TOINT() == 1 ? 1 : 2));
                        txtTCNo.Text = reader["Vergi_TC_No"].TOSTRING();
                        dtpDogumTarihi.Value = reader["Dogum_Tarihi"].TODATE();
                        cbCinsiyeti.SelectedIndex = reader["Cinsiyeti"].TOINT();
                        nudBoy.Value = reader["Boy"].TODECIMAL();
                        nudKilo.Value = reader["Kilo"].TODECIMAL();
                        nudHarcamaLimiti.Value = reader["Harcama_Limiti"].TODECIMAL();
                        txtSinifi.Text = reader["Sinifi"].TOSTRING();
                        txtSubesi.Text = reader["Subesi"].TOSTRING();
                        txtOgrenciNo.Text = reader["Ogrenci_No"].TOSTRING();
                        pbResim.LOADIMAGE(reader["Resim"].TOBYTEARRAY());
                        txtMahalleKoy.Text = reader["Mahalle_Koy"].TOSTRING();
                        txtCaddeSokak.Text = reader["Cadde_Sokak"].TOSTRING();
                        txtDisKapiNo.Text = reader["Dis_Kapi_No"].TOSTRING();
                        txtSiteAdi.Text = reader["Site_Adi"].TOSTRING();
                        txtApartmanBlok.Text = reader["Apartman_Blok"].TOSTRING();
                        txtKat.Text = reader["Kat"].TOSTRING();
                        txtDaire.Text = reader["Daire"].TOSTRING();
                        txtIlce.Text = reader["Ilce"].TOSTRING();
                        txtIl.Text = reader["Il"].TOSTRING();
                        txtUlke.Text = reader["Ulke"].TOSTRING();
                        mtbTelefon1.Text = reader["Telefon_1"].TOSTRING();
                        mtbTelefon2.Text = reader["Telefon_2"].TOSTRING();
                        mtbTelefon3.Text = reader["Telefon_3"].TOSTRING();
                        mtbFax1.Text = reader["Fax_1"].TOSTRING();
                        mtbFax2.Text = reader["Fax_2"].TOSTRING();
                        txtEMail1.Text = reader["E_Mail_1"].TOSTRING();
                        txtEMail2.Text = reader["E_Mail_2"].TOSTRING();
                        txtVeliAdi.Text = reader["Veli_Adi"].TOSTRING();
                        txtVeliSoyadi.Text = reader["Veli_Soyadi"].TOSTRING();
                        cbVeliCinsiyeti.SelectedIndex = reader["Veli_Cinsiyeti"].TOINT();
                        mtbVeliTelefon1.Text = reader["Veli_Telefon_1"].TOSTRING();
                        mtbVeliTelefon2.Text = reader["Veli_Telefon_2"].TOSTRING();
                        txtVeliEMail.Text = reader["Veli_E_Mail"].TOSTRING();
                        cbVeliEMailGonder.Checked = reader["Veli_E_Mail_Gonder"].TOINT() == 1;
                        blnYeniKayit = false;
                    }
                    reader.Close();
                    cmd.Parameters.Clear();

                    dtYasakliUrunler = new DataTable();
                    cmd.CommandText = "SELECT CASE WHEN CYU.Tip = 0 THEN 'Ürün Grubu' ELSE 'Tek Ürün' END AS Tip, " +
                                      "CASE WHEN CYU.Tip = 0 THEN CYU.Kodu ELSE ST.Stok_Kodu END AS Kodu, " +
                                      "CAST('...' AS VARCHAR(3)) AS Sec_Kodu, " +
                                      "CASE WHEN CYU.Tip = 0 THEN SGT.Grup_Adi ELSE ST.Stok_Adi END AS Adi, " +
                                      "CASE WHEN CYU.Tip = 0 THEN CAST(0 AS INT) ELSE ST.Stok_No END AS Stok_No " +
                                      "FROM Cari_Yasakli_Urunler AS CYU " +
                                      "LEFT OUTER JOIN Stok_Tanitimi AS ST ON ST.Silindi = 0 AND ST.Kurum_Kodu = CYU.Kurum_Kodu AND CAST(ST.Stok_No AS VARCHAR) = CYU.Kodu " +
                                      "LEFT OUTER JOIN Stok_Grup_Tanitimi AS SGT ON SGT.Kurum_Kodu = CYU.Kurum_Kodu AND SGT.Grup_Kodu = CYU.Kodu " +
                                      "WHERE CYU.Kurum_Kodu = @Kurum_Kodu AND CYU.Cari_No = @Cari_No " +
                                      "ORDER BY CYU.Sira_No";
                    cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                    cmd.Parameters.AddWithValue("@Cari_No", lblMusteriNo.Text.Trim());
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dtYasakliUrunler);
                    dgvYasakUrunler.DataSource = dtYasakliUrunler;
                    sda.Dispose();
                    cmd.Dispose();
                    cnn.Close();
                    prcdAktifPasifKontrol(true);
                }
                else
                {
                    MessageBox.Show("Lütfen bir müşteri kodu giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            if (blnYeniKayit)
            {
                lblMusteriNo.Text = fncYeniCariNoGetir().TOSTRING();
                cmd.CommandText = "INSERT INTO Cari_Tanitimi (Cari_No, Unvani, Adi, Soyadi, Kart_Kodu, Vergi_TC_No, Sinifi, Subesi, Ogrenci_No, Cinsiyeti, Durum, Boy, Kilo, " +
                                  "Dogum_Tarihi, Harcama_Limiti, Mahalle_Koy, Cadde_Sokak, Dis_Kapi_No, Site_Adi, Apartman_Blok, Kat, Daire, Ilce, Il, Ulke, Telefon_1, Telefon_2, Telefon_3, Fax_1, Fax_2, " +
                                  "E_Mail_1, E_Mail_2, Veli_Adi, Veli_Soyadi, Veli_Cinsiyeti, Veli_Telefon_1, Veli_Telefon_2, Veli_E_Mail, Veli_E_Mail_Gonder, Resim, Ogrenci, Ogretmen, " +
                                  "Musteri, Para_Birimi, Insert_User, Insert_Date, Kurum_Kodu, Cari_Kodu) " +
                                  "VALUES (@Cari_No, @Unvani, @Adi, @Soyadi, @Kart_Kodu, @Vergi_TC_No, @Sinifi, @Subesi, @Ogrenci_No, @Cinsiyeti, @Durum, @Boy, @Kilo, " +
                                  "@Dogum_Tarihi, @Harcama_Limiti, @Mahalle_Koy, @Cadde_Sokak, @Dis_Kapi_No, @Site_Adi, @Apartman_Blok, @Kat, @Daire, @Ilce, @Il, @Ulke, @Telefon_1, @Telefon_2, @Telefon_3, @Fax_1, @Fax_2, " +
                                  "@E_Mail_1, @E_Mail_2, @Veli_Adi, @Veli_Soyadi, @Veli_Cinsiyeti, @Veli_Telefon_1, @Veli_Telefon_2, @Veli_E_Mail, @Veli_E_Mail_Gonder, @Resim, @Ogrenci, @Ogretmen, " +
                                  "@Musteri, @Para_Birimi, @Kullanici, @Zaman, @Kurum_Kodu, @Cari_Kodu)";
            }
            else
                cmd.CommandText = "UPDATE Cari_Tanitimi SET Cari_No = @Cari_No, Unvani = @Unvani, Adi = @Adi, Soyadi = @Soyadi, Kart_Kodu = @Kart_Kodu, Vergi_TC_No = @Vergi_TC_No, Sinifi = @Sinifi, Subesi = @Subesi, Ogrenci_No = @Ogrenci_No, Cinsiyeti = @Cinsiyeti, Durum = @Durum, Boy = @Boy, Kilo = @Kilo, " +
                                  "Dogum_Tarihi = @Dogum_Tarihi, Harcama_Limiti = @Harcama_Limiti, Mahalle_Koy = @Mahalle_Koy, Cadde_Sokak = @Cadde_Sokak, Dis_Kapi_No = @Dis_Kapi_No, Site_Adi = @Site_Adi, Apartman_Blok = @Apartman_Blok, Kat = @Kat, Daire = @Daire, Ilce = @Ilce, Il = @Il, Ulke = @Ulke, Telefon_1 = @Telefon_1, Telefon_2 = @Telefon_2, Telefon_3 = @Telefon_3, Fax_1 = @Fax_1, Fax_2 = @Fax_2, " +
                                  "E_Mail_1 = @E_Mail_1, E_Mail_2 = @E_Mail_2, Veli_Adi = @Veli_Adi, Veli_Soyadi = @Veli_Soyadi, Veli_Cinsiyeti = @Veli_Cinsiyeti, Veli_Telefon_1 = @Veli_Telefon_1, Veli_Telefon_2 = @Veli_Telefon_2, Veli_E_Mail = @Veli_E_Mail, Veli_E_Mail_Gonder = @Veli_E_Mail_Gonder, Resim = @Resim, Ogrenci = @Ogrenci, Ogretmen = @Ogretmen, " +
                                  "Musteri = @Musteri, Para_Birimi = @Para_Birimi, Update_User = @Kullanici, Update_Date = @Zaman " +
                                  "WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Cari_Kodu = @Cari_Kodu";

            cmd.Parameters.AddWithValue("@Cari_No", lblMusteriNo.Text.Trim());
            cmd.Parameters.AddWithValue("@Unvani", txtAdi.Text.Trim() + " " + txtSoyadi.Text.Trim());
            cmd.Parameters.AddWithValue("@Adi", txtAdi.Text.Trim());
            cmd.Parameters.AddWithValue("@Soyadi", txtSoyadi.Text.Trim());
            cmd.Parameters.AddWithValue("@Kart_Kodu", txtKartKodu.Text.Trim());
            cmd.Parameters.AddWithValue("@Vergi_TC_No", txtTCNo.Text.Trim());
            cmd.Parameters.AddWithValue("@Sinifi", txtSinifi.Text.Trim());
            cmd.Parameters.AddWithValue("@Subesi", txtSubesi.Text.Trim());
            cmd.Parameters.AddWithValue("@Ogrenci_No", txtOgrenciNo.Text.Trim());
            cmd.Parameters.AddWithValue("@Cinsiyeti", cbCinsiyeti.SelectedIndex);
            cmd.Parameters.AddWithValue("@Durum", cbDurum.SelectedIndex);
            cmd.Parameters.AddWithValue("@Boy", nudBoy.Value);
            cmd.Parameters.AddWithValue("@Kilo", nudKilo.Value);
            cmd.Parameters.AddWithValue("@Dogum_Tarihi", dtpDogumTarihi.Value.TODATE());
            cmd.Parameters.AddWithValue("@Harcama_Limiti", nudHarcamaLimiti.Value);
            cmd.Parameters.AddWithValue("@Mahalle_Koy", txtMahalleKoy.Text.Trim());
            cmd.Parameters.AddWithValue("@Cadde_Sokak", txtCaddeSokak.Text.Trim());
            cmd.Parameters.AddWithValue("@Dis_Kapi_No", txtDisKapiNo.Text.Trim());
            cmd.Parameters.AddWithValue("@Site_Adi", txtSiteAdi.Text.Trim());
            cmd.Parameters.AddWithValue("@Apartman_Blok", txtApartmanBlok.Text.Trim());
            cmd.Parameters.AddWithValue("@Kat", txtKat.Text.Trim());
            cmd.Parameters.AddWithValue("@Daire", txtDaire.Text.Trim());
            cmd.Parameters.AddWithValue("@Ilce", txtIlce.Text.Trim());
            cmd.Parameters.AddWithValue("@Il", txtIl.Text.Trim());
            cmd.Parameters.AddWithValue("@Ulke", txtUlke.Text.Trim());
            cmd.Parameters.AddWithValue("@Telefon_1", mtbTelefon1.Text.Trim());
            cmd.Parameters.AddWithValue("@Telefon_2", mtbTelefon2.Text.Trim());
            cmd.Parameters.AddWithValue("@Telefon_3", mtbTelefon3.Text.Trim());
            cmd.Parameters.AddWithValue("@Fax_1", mtbFax1.Text.Trim());
            cmd.Parameters.AddWithValue("@Fax_2", mtbFax2.Text.Trim());
            cmd.Parameters.AddWithValue("@E_Mail_1", txtEMail1.Text.Trim());
            cmd.Parameters.AddWithValue("@E_Mail_2", txtEMail2.Text.Trim());
            cmd.Parameters.AddWithValue("@Veli_Adi", txtVeliAdi.Text.Trim());
            cmd.Parameters.AddWithValue("@Veli_Soyadi", txtVeliSoyadi.Text.Trim());
            cmd.Parameters.AddWithValue("@Veli_Cinsiyeti", cbVeliCinsiyeti.SelectedIndex);
            cmd.Parameters.AddWithValue("@Veli_Telefon_1", mtbVeliTelefon1.Text.Trim());
            cmd.Parameters.AddWithValue("@Veli_Telefon_2", mtbVeliTelefon2.Text.Trim());
            cmd.Parameters.AddWithValue("@Veli_E_Mail", txtVeliEMail.Text.Trim());
            cmd.Parameters.AddWithValue("@Veli_E_Mail_Gonder", (cbVeliEMailGonder.Checked ? 1 : 0));
            cmd.Parameters.AddWithValue("@Resim", pbResim.TOBYTEARRAY());
            cmd.Parameters.AddWithValue("@Ogrenci", (cbTipi.SelectedIndex == 0 ? 1 : 0));
            cmd.Parameters.AddWithValue("@Ogretmen", (cbTipi.SelectedIndex == 1 ? 1 : 0));
            cmd.Parameters.AddWithValue("@Musteri", 1);
            cmd.Parameters.AddWithValue("@Para_Birimi", clsGenel.fncGetParameter("Para_Birimi", "TL"));
            cmd.Parameters.AddWithValue("@Kullanici", clsGenel.strKullaniciKodu);
            cmd.Parameters.AddWithValue("@Zaman", DateTime.Now);
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Cari_Kodu", txtMusteriKodu.Text.Trim());
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            cmd.CommandText = "DELETE FROM Cari_Yasakli_Urunler WHERE Kurum_Kodu = @Kurum_Kodu AND Cari_No = @Cari_No";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Cari_No", lblMusteriNo.Text.Trim());
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            dgvYasakUrunler.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgvYasakUrunler.CurrentCell = dgvYasakUrunler.Rows[dgvYasakUrunler.NewRowIndex].Cells[colKodu.Name];
            cmd.CommandText = "INSERT INTO Cari_Yasakli_Urunler (Kurum_Kodu, Cari_No, Sira_No, Tip, Kodu) VALUES (@Kurum_Kodu, @Cari_No, @Sira_No, @Tip, @Kodu)";
            for (int i = 0; i < dtYasakliUrunler.Rows.Count; i++)
            {
                if (dtYasakliUrunler.Rows[i].RowState != DataRowState.Deleted)
                {
                    cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                    cmd.Parameters.AddWithValue("@Cari_No", lblMusteriNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Sira_No", i + 1);
                    cmd.Parameters.AddWithValue("@Tip", (dtYasakliUrunler.Rows[i]["Stok_No"].TOINT() == 0 ? 0 : 1));
                    cmd.Parameters.AddWithValue("@Kodu", (dtYasakliUrunler.Rows[i]["Stok_No"].TOINT() == 0 ? dtYasakliUrunler.Rows[i]["Kodu"] : dtYasakliUrunler.Rows[i]["Stok_No"]));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
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
                cmd.CommandText = "UPDATE Cari_Tanitimi SET Silindi = 1, Delete_User = @Delete_User, Delete_Date = @Delete_Date WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Cari_Kodu = @Cari_Kodu";
                cmd.Parameters.AddWithValue("@Delete_User", clsGenel.strKullaniciKodu);
                cmd.Parameters.AddWithValue("@Delete_Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Cari_Kodu", txtMusteriKodu.Text.Trim());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();

                tsbVazgec.PerformClick();
            }
        }

        private void frmOgrenciKarti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.FocusNextControl();
            }
        }

        private void btnCariKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECMusteri();
            if (o != null)
            {
                txtMusteriKodu.Text = o.TOSTRING();
                txtCariKodu_KeyDown(txtMusteriKodu, new KeyEventArgs(Keys.Return));
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

        private void cbTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbOgrenciBilgileri.Enabled = cbTipi.SelectedIndex == 0;
        }

        private void dgvYasakUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (dgvYasakUrunler.Columns[e.ColumnIndex].Name == colSecKodu.Name)
                {
                    object o = dgvYasakUrunler.Rows[e.RowIndex].Cells[colTip.Name].Value.TOSTRING() == "Ürün Grubu" ? clsXKod.fncSECStokGrupKodu() : clsXKod.fncSECStok();
                    if (o != null)
                    {
                        if (e.RowIndex == dgvYasakUrunler.NewRowIndex)
                        {
                            dtYasakliUrunler.Rows.Add(dtYasakliUrunler.NewRow());
                            if (dtYasakliUrunler.Rows.Count < dgvYasakUrunler.Rows.Count - 1) dgvYasakUrunler.Rows.RemoveAt(e.RowIndex + 1);
                            dgvYasakUrunler.CurrentCell = dgvYasakUrunler.Rows[dgvYasakUrunler.Rows.Count - 2].Cells[colKodu.Name];
                            dgvYasakUrunler.CurrentRow.Cells[colKodu.Name].Value = o.TOSTRING();
                        }
                        else
                            dgvYasakUrunler.CurrentRow.Cells[colKodu.Name].Value = o.TOSTRING();

                        prcdKodBilgiGetir();
                    }
                }
            }
        }

        private void prcdKodBilgiGetir()
        {
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();

            if (dgvYasakUrunler.CurrentRow.Cells[colTip.Name].Value.TOSTRING() == "Ürün Grubu")
                cmd.CommandText = "SELECT Grup_Adi AS Adi, CAST(0 AS INT) AS Stok_No FROM Stok_Grup_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu AND Grup_Kodu = @Kodu";
            else
                cmd.CommandText = "SELECT Stok_Adi AS Adi, Stok_No FROM Stok_Tanitimi WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Stok_Kodu = @Kodu";

            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Kodu", dgvYasakUrunler.CurrentRow.Cells[colKodu.Name].Value);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dgvYasakUrunler.CurrentRow.Cells[colAdi.Name].Value = reader["Adi"];
                dgvYasakUrunler.CurrentRow.Cells[colSecKodu.Name].Value = "...";
                dgvYasakUrunler.CurrentRow.Cells[colStokNo.Name].Value = reader["Stok_No"];
            }
            else
            {
                dgvYasakUrunler.CurrentRow.Cells[colAdi.Name].Value = "";
                dgvYasakUrunler.CurrentRow.Cells[colSecKodu.Name].Value = "...";
                dgvYasakUrunler.CurrentRow.Cells[colStokNo.Name].Value = 0;
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
        }

        private void dgvYasakUrunler_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvYasakUrunler.Columns[e.ColumnIndex].Name == colKodu.Name)
            {
                prcdKodBilgiGetir();
            }
        }

        private void dgvYasakUrunler_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[colTip.Name].Value = "Ürün Grubu";
        }
    }
}
