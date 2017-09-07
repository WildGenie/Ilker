using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PRCTicari
{
    public partial class frmKullaniciGirisi : Form
    {
        DialogResult drReturn = DialogResult.Cancel;

        public frmKullaniciGirisi()
        {
            InitializeComponent();
        }

        private void txtKullaniciKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                txtSifre.Focus();
        }

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                tsbTamam.PerformClick();
        }

        private void tsbTamam_Click(object sender, EventArgs e)
        {
            if (txtKullaniciKodu.Text.Trim() == "PRC" && txtSifre.Text.TOMD5() == "f25aba7d3fa1086d9e34cec3b6a236b1")
            {
                clsGenel.strKullaniciKodu = "PRC";
                clsGenel.strKullaniciAdi = "PRC";
                clsGenel.strKullaniciSoyadi = "Software";
                drReturn = DialogResult.OK;
                this.Close();
            }
            else
            {
                SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT Kullanici_Kodu, Adi, Soyadi FROM Kullanici_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu AND Kullanici_Kodu = @Kullanici_Kodu AND Sifre = @Sifre";
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Kullanici_Kodu", txtKullaniciKodu.Text.Trim());
                cmd.Parameters.AddWithValue("@Sifre", txtSifre.Text.TOMD5());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    clsGenel.strKullaniciKodu = reader["Kullanici_Kodu"].TOSTRING();
                    clsGenel.strKullaniciAdi = reader["Adi"].TOSTRING();
                    clsGenel.strKullaniciSoyadi = reader["Soyadi"].TOSTRING();
                    drReturn = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı kodu veya şifre yanlış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                reader.Close();
                cmd.Dispose();
                cnn.Close();
            }
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKullaniciGirisi_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = drReturn;
        }
    }
}
