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
    public partial class frmMasrafKarti : Form
    {
        bool blnYeniKayit = true;

        public frmMasrafKarti()
        {
            InitializeComponent();
        }

        private void frmMasrafKarti_Shown(object sender, EventArgs e)
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
                txtMasrafAdi.Focus();
            else
                txtMasrafKodu.Focus();
        }

        public void prcdTemizle()
        {
            lblMasrafNo.Text = "0";
            txtMasrafAdi.Clear();
            rbSabit.Checked = true;
            cbIslem.Checked = false;
            cbKdvOrani.SelectedItemByCode();
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

        private int fncYeniMasrafNoGetir()
        {
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT ISNULL(MAX(Masraf_No), CAST(0 AS INT)) + 1 AS Masraf_No FROM Masraf_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            int intYeniMasrafNo = cmd.ExecuteScalar().TOINT(0);
            cmd.Dispose();
            cnn.Close();

            return intYeniMasrafNo;
        }

        private void txtMasrafKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (!string.IsNullOrEmpty(txtMasrafKodu.Text.Trim()))
                {
                    SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                    cnn.Open();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Masraf_Tanitimi WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Masraf_Kodu = @Masraf_Kodu";
                    cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                    cmd.Parameters.AddWithValue("@Masraf_Kodu", txtMasrafKodu.Text.Trim());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblMasrafNo.Text = reader["Masraf_No"].TOSTRING();
                        txtMasrafAdi.Text = reader["Masraf_Adi"].TOSTRING();
                        cbIslem.Checked = reader["Islem"].TOINT() == 1;
                        rbSabit.Checked = reader["Masraf_Tipi"].TOINT() == 0;
                        rbDegisken.Checked = reader["Masraf_Tipi"].TOINT() == 1;
                        cbKdvOrani.SelectedItemByCode(reader["Kdv_Orani"].TOSTRING());
                        blnYeniKayit = false;
                    }
                    reader.Close();
                    cmd.Dispose();
                    cnn.Close();
                    prcdAktifPasifKontrol(true);
                }
                else
                {
                    MessageBox.Show("Lütfen bir masraf kodu giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                lblMasrafNo.Text = fncYeniMasrafNoGetir().TOSTRING();
                cmd.CommandText = "INSERT INTO Masraf_Tanitimi (Masraf_No, Masraf_Adi, Islem, Masraf_Tipi, Kdv_Orani, Insert_User, Insert_Date, Kurum_Kodu, Masraf_Kodu) " +
                                  "VALUES (@Masraf_No, @Masraf_Adi, @Islem, @Masraf_Tipi, @Kdv_Orani, @Kullanici, @Zaman, @Kurum_Kodu, @Masraf_Kodu)";
            }
            else
                cmd.CommandText = "UPDATE Masraf_Tanitimi SET Masraf_No = @Masraf_No, Masraf_Adi = @Masraf_Adi, Islem = @Islem, Masraf_Tipi = @Masraf_Tipi, Kdv_Orani = @Kdv_Orani, Update_User = @Kullanici, Update_Date = @Zaman " +
                                  "WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Masraf_Kodu = @Masraf_Kodu";
            
            cmd.Parameters.AddWithValue("@Masraf_No", lblMasrafNo.Text.Trim());
            cmd.Parameters.AddWithValue("@Masraf_Adi", txtMasrafAdi.Text.Trim());
            cmd.Parameters.AddWithValue("@Islem", (cbIslem.Checked ? 1 : 0));
            cmd.Parameters.AddWithValue("@Masraf_Tipi", (rbSabit.Checked ? 0 : 1));
            cmd.Parameters.AddWithValue("@Kdv_Orani", cbKdvOrani.SelectedItemForCode().TODOUBLE(0));
            cmd.Parameters.AddWithValue("@Kullanici", clsGenel.strKullaniciKodu);
            cmd.Parameters.AddWithValue("@Zaman", DateTime.Now);
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Masraf_Kodu", txtMasrafKodu.Text.Trim());
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
                cmd.CommandText = "UPDATE Masraf_Tanitimi SET Silindi = 1, Delete_User = @Delete_User, Delete_Date = @Delete_Date WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Masraf_Kodu = @Masraf_Kodu";
                cmd.Parameters.AddWithValue("@Delete_User", clsGenel.strKullaniciKodu);
                cmd.Parameters.AddWithValue("@Delete_Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Masraf_Kodu", txtMasrafKodu.Text.Trim());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();

                tsbVazgec.PerformClick();
            }
        }

        private void frmMasrafKarti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.FocusNextControl();
            }
        }

        private void btnMasrafKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECMasraf();
            if (o != null)
            {
                txtMasrafKodu.Text = o.TOSTRING();
                txtMasrafKodu_KeyDown(txtMasrafKodu, new KeyEventArgs(Keys.Return));
            }
        }
    }
}
