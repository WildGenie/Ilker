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
    public partial class frmCariKarti : Form
    {
        bool blnYeniKayit = true;
        DataTable dtYetkililer = new DataTable();

        public frmCariKarti()
        {
            InitializeComponent();
        }

        private void frmCariKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            clsGenel.prcdFillComboBox("Para_Birimi_Tanitimi", "Para_Birimi", "", new ComboBox[] { cbParaBirimi }, true);

            //dtYetkililer.Columns.Add("Adi", typeof(string));
            //dtYetkililer.Columns.Add("Soyadi", typeof(string));
            //dtYetkililer.Columns.Add("Telefon_1", typeof(string));
            //dtYetkililer.Columns.Add("E_Mail_1", typeof(string));

            tsbVazgec.PerformClick();

            tcDetay.TabPages.Remove(tpPersonel);
        }

        public void prcdAktifPasifKontrol(bool blnEnabled)
        {
            pnlBaslik.Enabled = !blnEnabled;
            pnlDetay.Enabled = blnEnabled;
            tsbKaydet.Enabled = blnEnabled;
            tsbSil.Enabled = blnEnabled;
            tsbVazgec.Enabled = blnEnabled;
            if (blnEnabled)
                txtUnvani.Focus();
            else
                txtCariKodu.Focus();
        }

        public void prcdTemizle()
        {
            lblCariNo.Text = "0";
            txtUnvani.Clear();
            txtVergiDairesi.Clear();
            txtVergiNo.Clear();
            txtGrupKodu.Clear();
            txtOzelKodu.Clear();
            nudIndirim.Value = 0;
            cbParaBirimi.SelectedItemByCode(clsGenel.fncGetParameter("Para_Birimi", "TL"));
            cbMusteri.Checked = true;
            cbSatici.Checked = false;
            cbPersonel.Checked = false;
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
            tcDetay.SelectedTab = tpGenel;
            pnlPersonel.Enabled = false;
            dtpIseGirisTarihi.Value = DateTime.Now.Date;
            dtpIstenCikisTarihi.Value = clsGenel.fncMinDateTime();
            txtGorevKodu.Clear();
            nudMaas.Value = 0;


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
                if (!string.IsNullOrEmpty(txtCariKodu.Text.Trim()))
                {
                    SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                    cnn.Open();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Cari_Tanitimi WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Cari_Kodu = @Cari_Kodu";
                    cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                    cmd.Parameters.AddWithValue("@Cari_Kodu", txtCariKodu.Text.Trim());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblCariNo.Text = reader["Cari_No"].TOSTRING();
                        txtUnvani.Text = reader["Unvani"].TOSTRING();
                        txtVergiDairesi.Text = reader["Vergi_Dairesi"].TOSTRING();
                        txtVergiNo.Text = reader["Vergi_TC_No"].TOSTRING();
                        txtGrupKodu.Text = reader["Grup_Kodu"].TOSTRING();
                        txtOzelKodu.Text = reader["Ozel_Kodu"].TOSTRING();
                        nudIndirim.Value = reader["Indirim"].TODECIMAL();
                        cbParaBirimi.SelectedItemByCode(reader["Para_Birimi"].TOSTRING());
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
                        cbMusteri.Checked = reader["Musteri"].TOINT() == 1;
                        cbSatici.Checked = reader["Satici"].TOINT() == 1;
                        cbPersonel.Checked = reader["Personel"].TOINT() == 1;
                        dtpIseGirisTarihi.Value = reader["Ise_Giris_Tarihi"].TODATE();
                        dtpIstenCikisTarihi.Value = reader["Isten_Cikis_Tarihi"].TODATE();
                        txtGorevKodu.Text = reader["Gorev_Kodu"].TOSTRING();
                        nudMaas.Value = reader["Maas"].TODECIMAL();
                        blnYeniKayit = false;
                    }
                    reader.Close();
                    cmd.Parameters.Clear();

                    dtYetkililer = new DataTable();
                    cmd.CommandText = "SELECT CYT.Adi, CYT.Soyadi, CYT.Telefon_1, CYT.E_Mail_1 FROM Cari_Yetkili_Tanitimi AS CYT WHERE CYT.Kurum_Kodu = @Kurum_Kodu AND CYT.Cari_No = @Cari_No";
                    cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                    cmd.Parameters.AddWithValue("@Cari_No", lblCariNo.Text.Trim());
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dtYetkililer);
                    dgvYetkililer.DataSource = dtYetkililer;
                    sda.Dispose();
                    cmd.Dispose();
                    cnn.Close();
                    prcdAktifPasifKontrol(true);
                }
                else
                {
                    MessageBox.Show("Lütfen bir cari kodu giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            dgvYetkililer.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (dgvYetkililer.Rows.Count > 0)
                dgvYetkililer.CurrentCell = dgvYetkililer.Rows[0].Cells[colAdi.Name];
            dtYetkililer.AcceptChanges();

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            if (blnYeniKayit)
            {
                lblCariNo.Text = fncYeniCariNoGetir().TOSTRING();
                cmd.CommandText = "INSERT INTO Cari_Tanitimi (Cari_No, Unvani, Grup_Kodu, Ozel_Kodu, Indirim, Para_Birimi, Vergi_Dairesi, " +
                                  "Vergi_TC_No, Satici, Mahalle_Koy, Cadde_Sokak, Dis_Kapi_No, Site_Adi, Apartman_Blok, Kat, Daire, Ilce, Il, Ulke, " +
                                  "Telefon_1, Telefon_2, Telefon_3, Fax_1, Fax_2, E_Mail_1, E_Mail_2, Insert_User, Insert_Date, Kurum_Kodu, Cari_Kodu) " +
                                  "VALUES (@Cari_No, @Unvani, @Grup_Kodu, @Ozel_Kodu, @Indirim, @Para_Birimi, @Vergi_Dairesi, " +
                                  "@Vergi_TC_No, @Satici, @Mahalle_Koy, @Cadde_Sokak, @Dis_Kapi_No, @Site_Adi, @Apartman_Blok, @Kat, @Daire, @Ilce, @Il, @Ulke, " +
                                  "@Telefon_1, @Telefon_2, @Telefon_3, @Fax_1, @Fax_2, @E_Mail_1, @E_Mail_2, @Kullanici, @Zaman, @Kurum_Kodu, @Cari_Kodu)";
            }
            else
                cmd.CommandText = "UPDATE Cari_Tanitimi SET Cari_No = @Cari_No, Unvani = @Unvani, Grup_Kodu = @Grup_Kodu, Ozel_Kodu = @Ozel_Kodu, Indirim = @Indirim, Para_Birimi = @Para_Birimi, Vergi_Dairesi = @Vergi_Dairesi, " +
                                  "Vergi_TC_No = @Vergi_TC_No, Satici = @Satici, Mahalle_Koy = @Mahalle_Koy, Cadde_Sokak = @Cadde_Sokak, Dis_Kapi_No = @Dis_Kapi_No, Site_Adi = @Site_Adi, Apartman_Blok = @Apartman_Blok, Kat = @Kat, Daire = @Daire, Ilce = @Ilce, Il = @Il, Ulke = @Ulke, " +
                                  "Telefon_1 = @Telefon_1, Telefon_2 = @Telefon_2, Telefon_3 = @Telefon_3, Fax_1 = @Fax_1, Fax_2 = @Fax_2, E_Mail_1 = @E_Mail_1, E_Mail_2 = @E_Mail_2, Update_User = @Kullanici, Update_Date = @Zaman " +
                                  "WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Cari_Kodu = @Cari_Kodu";

            cmd.Parameters.AddWithValue("@Cari_No", lblCariNo.Text.Trim());
            cmd.Parameters.AddWithValue("@Unvani", txtUnvani.Text.Trim());
            cmd.Parameters.AddWithValue("@Grup_Kodu", txtGrupKodu.Text.Trim());
            cmd.Parameters.AddWithValue("@Ozel_Kodu", txtOzelKodu.Text.Trim());
            cmd.Parameters.AddWithValue("@Indirim", nudIndirim.Value);
            cmd.Parameters.AddWithValue("@Para_Birimi", cbParaBirimi.SelectedItem.TOSTRING());
            cmd.Parameters.AddWithValue("@Vergi_Dairesi", txtVergiDairesi.Text.Trim());
            cmd.Parameters.AddWithValue("@Vergi_TC_No", txtVergiNo.Text.Trim());
            cmd.Parameters.AddWithValue("@Satici", cbSatici.Checked ? 1 : 0);
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
            cmd.Parameters.AddWithValue("@Kullanici", clsGenel.strKullaniciKodu);
            cmd.Parameters.AddWithValue("@Zaman", DateTime.Now);
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Cari_Kodu", txtCariKodu.Text.Trim());
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            cmd.CommandText = "DELETE FROM Cari_Yetkili_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu AND Cari_No = @Cari_No";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Cari_No", lblCariNo.Text.Trim());
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            if (cbMusteri.Checked || cbSatici.Checked)
            {
                cmd.CommandText = "INSERT INTO Cari_Yetkili_Tanitimi (Kurum_Kodu, Cari_No, Sira_No, Adi, Soyadi, Telefon_1, E_Mail_1) VALUES (@Kurum_Kodu, @Cari_No, @Sira_No, @Adi, @Soyadi, @Telefon_1, @E_Mail_1)";
                for (int i = 0; i < dtYetkililer.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                    cmd.Parameters.AddWithValue("@Cari_No", lblCariNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Sira_No", i + 1);
                    cmd.Parameters.AddWithValue("@Adi", dtYetkililer.Rows[i]["Adi"]);
                    cmd.Parameters.AddWithValue("@Soyadi", dtYetkililer.Rows[i]["Soyadi"]);
                    cmd.Parameters.AddWithValue("@Telefon_1", dtYetkililer.Rows[i]["Telefon_1"]);
                    cmd.Parameters.AddWithValue("@E_Mail_1", dtYetkililer.Rows[i]["E_Mail_1"]);
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
                cmd.Parameters.AddWithValue("@Cari_Kodu", txtCariKodu.Text.Trim());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();

                tsbVazgec.PerformClick();
            }
        }

        private void frmCariKarti_KeyDown(object sender, KeyEventArgs e)
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
                txtCariKodu.Text = o.TOSTRING();
                txtCariKodu_KeyDown(txtCariKodu, new KeyEventArgs(Keys.Return));
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

        private void cbPersonel_CheckedChanged(object sender, EventArgs e)
        {
            pnlPersonel.Enabled = cbPersonel.Checked;
        }

        private void cbSatici_CheckedChanged(object sender, EventArgs e)
        {
            dgvYetkililer.Enabled = cbSatici.Checked || cbMusteri.Checked;
        }

        private void btnGorevi_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECCariGorevKodu();
            if (o != null)
                txtGorevKodu.Text = o.TOSTRING();
        }
    }
}
