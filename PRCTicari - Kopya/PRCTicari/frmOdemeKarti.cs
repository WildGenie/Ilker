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
    public partial class frmOdemeKarti : Form
    {
        int intKayitNo = 0;
        bool blnYeniKayit = true;

        public frmOdemeKarti()
        {
            InitializeComponent();
        }

        private void frmOdemeKarti_Shown(object sender, EventArgs e)
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
                txtOdemeAdi.Focus();
            else
                txtOdemeKodu.Focus();
        }

        public void prcdTemizle()
        {
            intKayitNo = 0;
            lblOdemeNo.Text = "0";
            txtOdemeAdi.Clear();
            cbOdemeTipi.SelectedIndex = -1;
            cbKayitTipi.SelectedIndex = -1;
            txtKayitKodu.Clear();
            lblKayitAdi.Text = "";
            intKayitNo = 0;

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

        private int fncYeniOdemeNoGetir()
        {
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT ISNULL(MAX(Odeme_No), CAST(0 AS INT)) + 1 AS Odeme_No FROM Odeme_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            int intYeniOdemeNo = cmd.ExecuteScalar().TOINT(0);
            cmd.Dispose();
            cnn.Close();

            return intYeniOdemeNo;
        }

        private void txtKasaKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (!string.IsNullOrEmpty(txtOdemeKodu.Text.Trim()))
                {
                    SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                    cnn.Open();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandText = "SELECT Odeme_No, Odeme_Adi, Odeme_Tipi, Kayit_Tipi, CASE Kayit_Tipi WHEN 0 THEN CAST('' AS VARCHAR(25)) WHEN 1 THEN (SELECT Cari_Kodu FROM Cari_Tanitimi WHERE Silindi = 0 AND CAST(Cari_No AS VARCHAR(25)) = OT.Kayit_Kodu) ELSE Kayit_Kodu END AS Kayit_Kodu FROM Odeme_Tanitimi AS OT WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Odeme_Kodu = @Odeme_Kodu";
                    cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                    cmd.Parameters.AddWithValue("@Odeme_Kodu", txtOdemeKodu.Text.Trim());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblOdemeNo.Text = reader["Odeme_No"].TOSTRING();
                        txtOdemeAdi.Text = reader["Odeme_Adi"].TOSTRING();
                        cbOdemeTipi.SelectedIndex = reader["Odeme_Tipi"].TOINT();
                        cbKayitTipi.SelectedIndex = reader["Kayit_Tipi"].TOINT();
                        txtKayitKodu.Text = reader["Kayit_Kodu"].TOSTRING();
                        prcdKayitKoduBilgiGetir();
                        blnYeniKayit = false;
                    }
                    reader.Close();
                    cmd.Dispose();
                    cnn.Close();
                    prcdAktifPasifKontrol(true);
                }
                else
                {
                    MessageBox.Show("Lütfen bir ödeme kodu giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void txtKayitKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                prcdKayitKoduBilgiGetir();
            }
        }

        private void prcdKayitKoduBilgiGetir()
        {
            intKayitNo = 0;
            lblKayitAdi.Text = "";
            if (!string.IsNullOrEmpty(txtKayitKodu.Text))
            {
                SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                if (cbKayitTipi.SelectedIndex == 1)
                    cmd.CommandText = "SELECT Cari_No AS Kayit_No, Unvani AS Kayit_Adi FROM Cari_Tanitimi WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Cari_Kodu = @Kayit_Kodu";
                else if (cbKayitTipi.SelectedIndex == 2)
                    cmd.CommandText = "SELECT CAST(0 AS INT) AS Kayit_No, Kasa_Adi AS Kayit_Adi FROM Kasa_Tanitimi WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Kasa_Kodu = @Kayit_Kodu";
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Kayit_Kodu", txtKayitKodu.Text.Trim());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    intKayitNo = reader["Kayit_No"].TOINT();
                    lblKayitAdi.Text = reader["Kayit_Adi"].TOSTRING();
                }
                reader.Close();
                cmd.Dispose();
                cnn.Close();
            }
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            if (cbOdemeTipi.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen ödeme tipini seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (cbKayitTipi.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen kayıt tipini seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (cbKayitTipi.SelectedIndex != 0 && string.IsNullOrEmpty(txtKayitKodu.Text.Trim()))
            {
                MessageBox.Show("Lütfen kayıt kodunu giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtKayitKodu.Focus();
                return;
            }

            if (cbKayitTipi.SelectedIndex == 1 && !string.IsNullOrEmpty(txtKayitKodu.Text.Trim()) && intKayitNo == 0)
            {
                txtKayitKodu.Focus();
                txtKayitKodu_KeyDown(txtKayitKodu, new KeyEventArgs(Keys.Return));
            }

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            if (blnYeniKayit)
            {
                lblOdemeNo.Text = fncYeniOdemeNoGetir().TOSTRING();
                cmd.CommandText = "INSERT INTO Odeme_Tanitimi (Odeme_No, Odeme_Adi, Odeme_Tipi, Kayit_Tipi, Kayit_Kodu, Insert_User, Insert_Date, Kurum_Kodu, Odeme_Kodu) " +
                                  "VALUES (@Odeme_No, @Odeme_Adi, @Odeme_Tipi, @Kayit_Tipi, @Kayit_Kodu, @Kullanici, @Zaman, @Kurum_Kodu, @Odeme_Kodu)";
            }
            else
                cmd.CommandText = "UPDATE Odeme_Tanitimi SET Odeme_No = @Odeme_No, Odeme_Adi = @Odeme_Adi, Odeme_Tipi = @Odeme_Tipi, Kayit_Tipi = @Kayit_Tipi, Kayit_Kodu = @Kayit_Kodu, Update_User = @Kullanici, Update_Date = @Zaman " +
                                  "WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Odeme_Kodu = @Odeme_Kodu";

            cmd.Parameters.AddWithValue("@Odeme_No", lblOdemeNo.Text.Trim());
            cmd.Parameters.AddWithValue("@Odeme_Adi", txtOdemeAdi.Text.Trim());
            cmd.Parameters.AddWithValue("@Odeme_Tipi", cbOdemeTipi.SelectedIndex);
            cmd.Parameters.AddWithValue("@Kayit_Tipi", cbKayitTipi.SelectedIndex);
            cmd.Parameters.AddWithValue("@Kayit_Kodu", (cbKayitTipi.SelectedIndex == 1 ? intKayitNo.TOSTRING() : txtKayitKodu.Text.Trim()));
            cmd.Parameters.AddWithValue("@Kullanici", clsGenel.strKullaniciKodu);
            cmd.Parameters.AddWithValue("@Zaman", DateTime.Now);
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Odeme_Kodu", txtOdemeKodu.Text.Trim());
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
                cmd.CommandText = "UPDATE Odeme_Tanitimi SET Silindi = 1, Delete_User = @Delete_User, Delete_Date = @Delete_Date WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Odeme_Kodu = @Odeme_Kodu";
                cmd.Parameters.AddWithValue("@Delete_User", clsGenel.strKullaniciKodu);
                cmd.Parameters.AddWithValue("@Delete_Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Odeme_Kodu", txtOdemeKodu.Text.Trim());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();

                tsbVazgec.PerformClick();
            }
        }

        private void frmOdemeKarti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.FocusNextControl();
            }
        }

        private void btnKasaKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECOdeme();
            if (o != null)
            {
                txtOdemeKodu.Text = o.TOSTRING();
                txtKasaKodu_KeyDown(txtOdemeKodu, new KeyEventArgs(Keys.Return));
            }
        }

        private void cbKayitTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKayitKodu.Clear();
            lblKayitAdi.Text = "";
            intKayitNo = 0;

            txtKayitKodu.Enabled = cbKayitTipi.SelectedIndex != 0;
            btnKayitKodu.Enabled = cbKayitTipi.SelectedIndex != 0;
        }

        private void btnKayitKodu_Click(object sender, EventArgs e)
        {
            object o = null;
            if (cbKayitTipi.SelectedIndex == 1)
                o = clsXKod.fncSECCari();
            else if (cbKayitTipi.SelectedIndex == 2)
                o = clsXKod.fncSECKasa();

            if (o != null)
            {
                txtKayitKodu.Text = o.TOSTRING();
                prcdKayitKoduBilgiGetir();
            }
        }
    }
}
