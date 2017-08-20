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
    public partial class frmKasaKarti : Form
    {
        bool blnYeniKayit = true;

        public frmKasaKarti()
        {
            InitializeComponent();
        }

        private void frmKasaKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            clsGenel.prcdFillComboBox("Isyeri_Tanitimi", "Isyeri_Kodu", "Isyeri_Adi", new ComboBox[] { cbIsyeriKodu });
            clsGenel.prcdFillComboBox("Para_Birimi_Tanitimi", "Para_Birimi", "", new ComboBox[] { cbParaBirimi });

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
                txtKasaAdi.Focus();
            else
                txtKasaKodu.Focus();
        }

        public void prcdTemizle()
        {
            txtKasaAdi.Clear();
            txtYetkilisi.Clear();
            cbIsyeriKodu.SelectedItemByCode(clsGenel.fncGetParameter("Isyeri_Kodu"));
            if (cbIsyeriKodu.SelectedIndex < 0 && cbIsyeriKodu.Items.Count > 0) cbIsyeriKodu.SelectedIndex = 0;
            cbParaBirimi.SelectedItemByCode(clsGenel.fncGetParameter("Para_Birimi", "TL"));

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

        private void txtKasaKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (!string.IsNullOrEmpty(txtKasaKodu.Text.Trim()))
                {
                    SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                    cnn.Open();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Kasa_Tanitimi WHERE Silindi = 0 AND Kasa_Kodu = @Kasa_Kodu";
                    cmd.Parameters.AddWithValue("@Kasa_Kodu", txtKasaKodu.Text.Trim());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtKasaAdi.Text = reader["Kasa_Adi"].TOSTRING();
                        txtYetkilisi.Text = reader["Yetkilisi"].TOSTRING();
                        cbParaBirimi.SelectedItemByCode(reader["Para_Birimi"].TOSTRING());
                        cbIsyeriKodu.SelectedItemByCode(reader["Isyeri_Kodu"].TOSTRING());
                        blnYeniKayit = false;
                    }
                    reader.Close();
                    cmd.Dispose();
                    cnn.Close();
                    prcdAktifPasifKontrol(true);
                }
                else
                {
                    MessageBox.Show("Lütfen bir kasa kodu giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            if (blnYeniKayit)
                cmd.CommandText = "INSERT INTO Kasa_Tanitimi (Kasa_Adi, Yetkilisi, Para_Birimi, Isyeri_Kodu, Insert_User, Insert_Date, Kasa_Kodu) " +
                                  "VALUES (@Kasa_Adi, @Yetkilisi, @Para_Birimi, @Isyeri_Kodu, @Kullanici, @Zaman, @Kasa_Kodu)";
            else
                cmd.CommandText = "UPDATE Kasa_Tanitimi SET Kasa_Adi = @Kasa_Adi, Yetkilisi = @Yetkilisi, Para_Birimi = @Para_Birimi, Isyeri_Kodu = @Isyeri_Kodu, Update_User = @Kullanici, Update_Date = @Zaman " +
                                  "WHERE Silindi = 0 AND Kasa_Kodu = @Kasa_Kodu";
            
            cmd.Parameters.AddWithValue("@Kasa_Adi", txtKasaAdi.Text.Trim());
            cmd.Parameters.AddWithValue("@Yetkilisi", txtYetkilisi.Text.Trim());
            cmd.Parameters.AddWithValue("@Para_Birimi", cbParaBirimi.SelectedItemForCode());
            cmd.Parameters.AddWithValue("@Isyeri_Kodu", cbIsyeriKodu.SelectedItemForCode().TOINT());
            cmd.Parameters.AddWithValue("@Kullanici", clsGenel.strKullaniciKodu);
            cmd.Parameters.AddWithValue("@Zaman", DateTime.Now);
            cmd.Parameters.AddWithValue("@Kasa_Kodu", txtKasaKodu.Text.Trim());
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
                cmd.CommandText = "UPDATE Kasa_Tanitimi SET Silindi = 1, Delete_User = @Delete_User, Delete_Date = @Delete_Date WHERE Silindi = 0 AND Kasa_Kodu = @Kasa_Kodu";
                cmd.Parameters.AddWithValue("@Delete_User", clsGenel.strKullaniciKodu);
                cmd.Parameters.AddWithValue("@Delete_Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Kasa_Kodu", txtKasaKodu.Text.Trim());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();

                tsbVazgec.PerformClick();
            }
        }

        private void frmKasaKarti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.FocusNextControl();
            }
        }

        private void btnKasaKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECKasa();
            if (o != null)
            {
                txtKasaKodu.Text = o.TOSTRING();
                txtKasaKodu_KeyDown(txtKasaKodu, new KeyEventArgs(Keys.Return));
            }
        }
    }
}
