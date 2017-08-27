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
    public partial class frmPersonelKarti : Form
    {
        bool blnYeniKayit = true;

        public frmPersonelKarti()
        {
            InitializeComponent();
        }

        private void frmPersonelKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            clsGenel.prcdFillComboBox("Para_Birimi_Tanitimi", "Para_Birimi", "", new ComboBox[] { cbIsyeriKodu }, true);
            clsGenel.prcdFillComboBox("Isyeri_Tanitimi", "Isyeri_Kodu", "Isyeri_Adi", new ComboBox[] { cbIsyeriKodu });

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
                txtPersonelKodu.Focus();
        }

        public void prcdTemizle()
        {
            lblPersonelNo.Text = "0";
            txtAdi.Clear();
            txtAileNo.Clear();
            txtAnaAdi.Clear();
            txtApartmanBlok.Clear();
            txtBabaAdi.Clear();
            txtBankaAdi.Clear();
            txtBankaSubesi.Clear();
            txtCaddeSokak.Clear();
            txtCalismaYeri.Clear();
            txtCikisNedeni.Clear();
            txtCiltNo.Clear();
            txtDaire.Clear();
            txtDisKapiNo.Clear();
            txtDogumYeri.Clear();
            txtEMail1.Clear();
            txtEMail2.Clear();
            txtGorevKodu.Clear();
            txtGrupKodu.Clear();
            txtHesapNo.Clear();
            txtIl.Clear();
            txtIlce.Clear();
            txtKat.Clear();
            txtKimlikIl.Clear();
            txtKimlikIlce.Clear();
            txtKimlikMahalleKoy.Clear();
            txtKimlikSeriNo1.Clear();
            txtKimlikSeriNo2.Clear();
            txtMahalleKoy.Clear();
            txtOzelKodu.Clear();
            txtSiraNo.Clear();
            txtSiteAdi.Clear();
            txtSoyadi.Clear();
            txtTCKimlikNo.Clear();
            txtUlke.Clear();
            cbAskerlik.SelectedIndex = 0;
            cbCinsiyeti.SelectedIndex = 0;
            cbEgitimDurumu.SelectedIndex = 0;
            cbEhliyet.SelectedIndex = 0;
            cbIsyeriKodu.SelectedIndex = -1;
            cbKanGrubu.SelectedIndex = 0;
            cbMedeniHali.SelectedIndex = 0;
            dtpIseGirisTarihi.Value = DateTime.Now.Date;
            dtpIstenCikisTarihi.Value = clsGenel.fncMinDateTime();
            dtpDogumTarihi.Value = DateTime.Now.Date;
            nudAGITutari.Value = 0;
            nudCocukSayisi.Value = 0;
            nudMaas.Value = 0;
            nudYatirilanMaas.Value = 0;
            pbResim.Image = null;


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

        private int fncYeniPersonelNoGetir()
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
                if (!string.IsNullOrEmpty(txtPersonelKodu.Text.Trim()))
                {
                    SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                    cnn.Open();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Cari_Tanitimi WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Cari_Kodu = @Cari_Kodu";
                    cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                    cmd.Parameters.AddWithValue("@Cari_Kodu", txtPersonelKodu.Text.Trim());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblPersonelNo.Text = reader["Cari_No"].TOSTRING();
                        txtAdi.Text = reader["Adi"].TOSTRING();
                        txtAileNo.Text = reader["Aile_No"].TOSTRING();
                        txtAnaAdi.Text = reader["Ana_Adi"].TOSTRING();
                        txtApartmanBlok.Text = reader["Apartman_Blok"].TOSTRING();
                        txtBabaAdi.Text = reader["Baba_Adi"].TOSTRING();
                        txtBankaAdi.Text = reader["Banka_Adi"].TOSTRING();
                        txtBankaSubesi.Text = reader["Banka_Subesi"].TOSTRING();
                        txtCaddeSokak.Text = reader["Cadde_Sokak"].TOSTRING();
                        txtCalismaYeri.Text = reader["Calisma_Yeri"].TOSTRING();
                        txtCikisNedeni.Text = reader["Cikis_Nedeni"].TOSTRING();
                        txtCiltNo.Text = reader["Cilt_No"].TOSTRING();
                        txtDaire.Text = reader["Daire"].TOSTRING();
                        txtDisKapiNo.Text = reader["Dis_Kapi_No"].TOSTRING();
                        txtDogumYeri.Text = reader["Dogum_Yeri"].TOSTRING();
                        txtEMail1.Text = reader["E_Mail_1"].TOSTRING();
                        txtEMail2.Text = reader["E_Mail_2"].TOSTRING();
                        txtGorevKodu.Text = reader["Gorev_Kodu"].TOSTRING();
                        txtGrupKodu.Text = reader["Grup_Kodu"].TOSTRING();
                        txtHesapNo.Text = reader["Hesap_No"].TOSTRING();
                        txtIl.Text = reader["Il"].TOSTRING();
                        txtIlce.Text = reader["Ilce"].TOSTRING();
                        txtKat.Text = reader["Kat"].TOSTRING();
                        txtKimlikIl.Text = reader["Kimlik_Il"].TOSTRING();
                        txtKimlikIlce.Text = reader["Kimlik_Ilce"].TOSTRING();
                        txtKimlikMahalleKoy.Text = reader["Kimlik_Mahalle_Koy"].TOSTRING();
                        txtKimlikSeriNo1.Text = reader["Kimlik_Seri_No_1"].TOSTRING();
                        txtKimlikSeriNo2.Text = reader["Kimlik_Seri_No_2"].TOSTRING();
                        txtMahalleKoy.Text = reader["Mahalle_Koy"].TOSTRING();
                        txtOzelKodu.Text = reader["Ozel_Kodu"].TOSTRING();
                        txtSiraNo.Text = reader["Sira_No"].TOSTRING();
                        txtSiteAdi.Text = reader["Site_Adi"].TOSTRING();
                        txtSoyadi.Text = reader["Soyadi"].TOSTRING();
                        txtTCKimlikNo.Text = reader["Vergi_TC_No"].TOSTRING();
                        txtUlke.Text = reader["Ulke"].TOSTRING();
                        cbAskerlik.SelectedIndex = reader["Askerlik"].TOINT();
                        cbCinsiyeti.SelectedIndex = reader["Cinsiyeti"].TOINT();
                        cbEgitimDurumu.SelectedIndex = reader["Egitim_Durumu"].TOINT();
                        cbEhliyet.SelectedIndex = reader["Ehliyet"].TOINT();
                        cbIsyeriKodu.SelectedItemByCode(reader["Isyeri_Kodu"].TOSTRING());
                        cbKanGrubu.SelectedIndex = reader["Kan_Grubu"].TOINT();
                        cbMedeniHali.SelectedIndex = reader["Medeni_Hali"].TOINT();
                        dtpIseGirisTarihi.Value = reader["Ise_Giris_Tarihi"].TODATETIME();
                        dtpIstenCikisTarihi.Value = reader["Isten_Cikis_Tarihi"].TODATETIME();
                        dtpDogumTarihi.Value = reader["Dogum_Tarihi"].TODATETIME();
                        nudAGITutari.Value = reader["AGI_Tutari"].TODECIMAL();
                        nudCocukSayisi.Value = reader["Cocuk_Sayisi"].TODECIMAL();
                        nudMaas.Value = reader["Maas"].TODECIMAL();
                        nudYatirilanMaas.Value = reader["Yatirilan_Maas"].TODECIMAL();
                        pbResim.LOADIMAGE(reader["Resim"].TOBYTEARRAY());

                        blnYeniKayit = false;
                    }
                    reader.Close();
                    cmd.Dispose();
                    cnn.Close();
                    prcdAktifPasifKontrol(true);
                }
                else
                {
                    MessageBox.Show("Lütfen bir personel kodu giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                lblPersonelNo.Text = fncYeniPersonelNoGetir().TOSTRING();
                cmd.CommandText = "INSERT INTO Cari_Tanitimi (Cari_No, Unvani, Grup_Kodu, Ozel_Kodu, Indirim, Para_Birimi, Vergi_Dairesi, " +
                                  "Vergi_TC_No, Musteri, Satici, Personel, Mahalle_Koy, Cadde_Sokak, Dis_Kapi_No, Site_Adi, Apartman_Blok, Kat, Daire, Ilce, Il, Ulke, " +
                                  "Telefon_1, Telefon_2, Telefon_3, Fax_1, Fax_2, E_Mail_1, E_Mail_2, Ise_Giris_Tarihi, Isten_Cikis_Tarihi, Gorev_Kodu, Maas, Insert_User, Insert_Date, Kurum_Kodu, Cari_Kodu) " +
                                  "VALUES (@Cari_No, @Unvani, @Grup_Kodu, @Ozel_Kodu, @Indirim, @Para_Birimi, @Vergi_Dairesi, " +
                                  "@Vergi_TC_No, @Musteri, @Satici, @Personel, @Mahalle_Koy, @Cadde_Sokak, @Dis_Kapi_No, @Site_Adi, @Apartman_Blok, @Kat, @Daire, @Ilce, @Il, @Ulke, " +
                                  "@Telefon_1, @Telefon_2, @Telefon_3, @Fax_1, @Fax_2, @E_Mail_1, @E_Mail_2, @Ise_Giris_Tarihi, @Isten_Cikis_Tarihi, @Gorev_Kodu, @Maas, @Kullanici, @Zaman, @Kurum_Kodu, @Cari_Kodu)";
            }
            else
                cmd.CommandText = "UPDATE Cari_Tanitimi SET Cari_No = @Cari_No, Unvani = @Unvani, Grup_Kodu = @Grup_Kodu, Ozel_Kodu = @Ozel_Kodu, Indirim = @Indirim, Para_Birimi = @Para_Birimi, Vergi_Dairesi = @Vergi_Dairesi, " +
                                  "Vergi_TC_No = @Vergi_TC_No, Musteri = @Musteri, Satici = @Satici, Personel = @Personel, Mahalle_Koy = @Mahalle_Koy, Cadde_Sokak = @Cadde_Sokak, Dis_Kapi_No = @Dis_Kapi_No, Site_Adi = @Site_Adi, Apartman_Blok = @Apartman_Blok, Kat = @Kat, Daire = @Daire, Ilce = @Ilce, Il = @Il, Ulke = @Ulke, " +
                                  "Telefon_1 = @Telefon_1, Telefon_2 = @Telefon_2, Telefon_3 = @Telefon_3, Fax_1 = @Fax_1, Fax_2 = @Fax_2, E_Mail_1 = @E_Mail_1, E_Mail_2 = @E_Mail_2, Ise_Giris_Tarihi = @Ise_Giris_Tarihi, Isten_Cikis_Tarihi = @Isten_Cikis_Tarihi, Gorev_Kodu = @Gorev_Kodu, Maas = @Maas, Update_User = @Kullanici, Update_Date = @Zaman " +
                                  "WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Cari_Kodu = @Cari_Kodu";

            cmd.Parameters.AddWithValue("@Cari_No", lblPersonelNo.Text.Trim());
            cmd.Parameters.AddWithValue("@Unvani", txtAdi.Text.Trim());
            cmd.Parameters.AddWithValue("@Grup_Kodu", txtGrupKodu.Text.Trim());
            cmd.Parameters.AddWithValue("@Ozel_Kodu", txtOzelKodu.Text.Trim());
            cmd.Parameters.AddWithValue("@Indirim", nudCocukSayisi.Value);
            cmd.Parameters.AddWithValue("@Para_Birimi", cbIsyeriKodu.SelectedItem.TOSTRING());
            cmd.Parameters.AddWithValue("@Vergi_Dairesi", txtVergiDairesi.Text.Trim());
            cmd.Parameters.AddWithValue("@Vergi_TC_No", txtCikisNedeni.Text.Trim());
            cmd.Parameters.AddWithValue("@Musteri", cbMusteri.Checked ? 1 : 0);
            cmd.Parameters.AddWithValue("@Satici", cbSatici.Checked ? 1 : 0);
            cmd.Parameters.AddWithValue("@Personel", cbPersonel.Checked ? 1 : 0);
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
            if (cbPersonel.Checked)
            {
                cmd.Parameters.AddWithValue("@Ise_Giris_Tarihi", dtpIseGirisTarihi.Value.TODATE());
                cmd.Parameters.AddWithValue("@Isten_Cikis_Tarihi", dtpIstenCikisTarihi.Value.TODATE());
                cmd.Parameters.AddWithValue("@Gorev_Kodu", txtGorevKodu.Text.Trim());
                cmd.Parameters.AddWithValue("@Maas", nudMaas.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Ise_Giris_Tarihi", clsGenel.fncMinDateTime());
                cmd.Parameters.AddWithValue("@Isten_Cikis_Tarihi", clsGenel.fncMinDateTime());
                cmd.Parameters.AddWithValue("@Gorev_Kodu", "");
                cmd.Parameters.AddWithValue("@Maas", 0);
            }
            cmd.Parameters.AddWithValue("@Kullanici", clsGenel.strKullaniciKodu);
            cmd.Parameters.AddWithValue("@Zaman", DateTime.Now);
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Cari_Kodu", txtPersonelKodu.Text.Trim());
            cmd.ExecuteNonQuery();

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
                cmd.Parameters.AddWithValue("@Cari_Kodu", txtPersonelKodu.Text.Trim());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();

                tsbVazgec.PerformClick();
            }
        }

        private void frmPersonelKarti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.FocusNextControl();
            }
        }

        private void btnCariKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECCari();
            if (o != null)
            {
                txtPersonelKodu.Text = o.TOSTRING();
                txtCariKodu_KeyDown(txtPersonelKodu, new KeyEventArgs(Keys.Return));
            }
        }

        private void btnGrupKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECCariGrupKodu();
            if (o != null) txtGrupKodu.Text = o.TOSTRING();
        }

        private void btnOzelKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECCariOzelKodu();
            if (o != null) txtOzelKodu.Text = o.TOSTRING();
        }

        private void btnGorevi_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECCariGorevKodu();
            if (o != null)
                txtGorevKodu.Text = o.TOSTRING();
        }

        private void lblResimSil_Click(object sender, EventArgs e)
        {
            pbResim.Image = null;
        }

        private void lblResimEkle_Click(object sender, EventArgs e)
        {
            pbResim.LOADIMAGE();
        }
    }
}
