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

            dtTedarikciler.Columns.Add("Tedarikci_No", typeof(int));
            dtTedarikciler.Columns.Add("Tedarikci_Kodu", typeof(string));
            dtTedarikciler.Columns.Add("Tedarikci_Sec", typeof(string));
            dtTedarikciler.Columns.Add("Tedarikci_Adi", typeof(string));
            dgvTedarikciler.DataSource = dtTedarikciler;

            dtAlislar.Columns.Add("Ay", typeof(string));
            dtAlislar.Columns.Add("Miktar", typeof(double));
            dgvAlislar.DataSource = dtAlislar;

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
            cbBT1BirimTipi.SelectedItemByCode();
            nudBT1BirimOrani.Value = 1;
            txtBT1Barkod.Clear();
            nudBT1AlisFiyati.Value = 0;
            nudBT1AlisFiyatiKdvli.Value = 0;
            nudBT1SatisFiyati.Value = 0;
            cbBT2BirimTipi.SelectedItemByCode();
            nudBT2BirimOrani.Value = 1;
            txtBT2Barkod.Clear();
            nudBT2AlisFiyati.Value = 0;
            nudBT2AlisFiyatiKdvli.Value = 0;
            nudBT2SatisFiyati.Value = 0;
            dtTedarikciler.Rows.Clear();
            dtAlislar.Rows.Clear();

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
            cmd.CommandText = "SELECT ISNULL(MAX(Stok_No), CAST(0 AS INT)) + 1 AS Stok_No FROM Stok_Tanitimi";
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
                    cmd.CommandText = "SELECT * FROM Stok_Tanitimi WHERE Silindi = 0 AND Stok_Kodu = @Stok_Kodu";
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
                        cbBT1BirimTipi.SelectedItemByCode(reader["Birim_Kodu_1"].TOSTRING());
                        nudBT1BirimOrani.Value = reader["BT1_Orani"].TODECIMAL();
                        txtBT1Barkod.Text = reader["BT1_Barkod"].TOSTRING();
                        cbBT2BirimTipi.SelectedItemByCode(reader["Birim_Kodu_2"].TOSTRING());
                        nudBT2BirimOrani.Value = reader["BT2_Orani"].TODECIMAL();
                        txtBT2Barkod.Text = reader["BT2_Barkod"].TOSTRING();
                        nudBT1AlisFiyati.Value = reader["BT1_Alis_Fiyati"].TODECIMAL();
                        nudBT1AlisFiyatiKdvli.Value = reader["BT1_Alis_Kdvli_Fiyati"].TODECIMAL();
                        nudBT1SatisFiyati.Value = reader["BT1_Satis_Fiyati"].TODECIMAL();
                        nudBT2AlisFiyati.Value = reader["BT2_Alis_Fiyati"].TODECIMAL();
                        nudBT2AlisFiyatiKdvli.Value = reader["BT2_Alis_Kdvli_Fiyati"].TODECIMAL();
                        nudBT2SatisFiyati.Value = reader["BT2_Satis_Fiyati"].TODECIMAL();
                        blnYeniKayit = false;
                    }
                    reader.Close();
                    cmd.Parameters.Clear();

                    cmd.CommandText = "SELECT STT.Tedarikci_No, CT.Cari_Kodu AS Tedarikci_Kodu, '...' AS Tedarikci_Sec, CT.Unvani AS Tedarikci_Adi FROM Stok_Tanitimi AS ST INNER JOIN Stok_Tedarikci_Tanitimi AS STT ON ST.Stok_No = STT.Stok_No INNER JOIN Cari_Tanitimi AS CT ON CT.Silindi = 0 AND CT.Cari_No = STT.Tedarikci_No WHERE ST.Silindi = 0 AND ST.Stok_No = @Stok_No";
                    cmd.Parameters.AddWithValue("@Stok_No", lblStokNo.Text.Trim());
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dtTedarikciler);
                    sda.Dispose();
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
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            if (blnYeniKayit)
            {
                lblStokNo.Text = fncYeniStokNoGetir().TOSTRING();
                cmd.CommandText = "INSERT INTO Stok_Tanitimi (Stok_No, Stok_Adi, Kisa_Adi, Grup_Kodu, Ozel_Kodu, Kdv_Toptan, Kdv_Perakende, " +
                                  "Birim_Kodu_1, BT1_Orani, BT1_Barkod, BT1_Alis_Fiyati, BT1_Alis_Kdvli_Fiyati, BT1_Satis_Fiyati, " +
                                  "Birim_Kodu_2, BT2_Orani, BT2_Barkod, BT2_Alis_Fiyati, BT2_Alis_Kdvli_Fiyati, BT2_Satis_Fiyati, " +
                                  "Insert_User, Insert_Date, Stok_Kodu) " +
                                  "VALUES (@Stok_No, @Stok_Adi, @Kisa_Adi, @Grup_Kodu, @Ozel_Kodu, @Kdv_Toptan, @Kdv_Perakende, " +
                                  "@Birim_Kodu_1, @BT1_Orani, @BT1_Barkod, @BT1_Alis_Fiyati, @BT1_Alis_Kdvli_Fiyati, @BT1_Satis_Fiyati, " +
                                  "@Birim_Kodu_2, @BT2_Orani, @BT2_Barkod, @BT2_Alis_Fiyati, @BT2_Alis_Kdvli_Fiyati, @BT2_Satis_Fiyati, " + 
                                  "@Kullanici, @Zaman, @Stok_Kodu)";
            }
            else
                cmd.CommandText = "UPDATE Stok_Tanitimi SET Stok_No = @Stok_No, Stok_Adi = @Stok_Adi, Kisa_Adi = @Kisa_Adi, Grup_Kodu = @Grup_Kodu, Ozel_Kodu = @Ozel_Kodu, Kdv_Toptan = @Kdv_Toptan, Kdv_Perakende = @Kdv_Perakende, " +
                                  "Birim_Kodu_1 = @Birim_Kodu_1, BT1_Orani = @BT1_Orani, BT1_Barkod = @BT1_Barkod, BT1_Alis_Fiyati = @BT1_Alis_Fiyati, BT1_Alis_Kdvli_Fiyati = @BT1_Alis_Kdvli_Fiyati, BT1_Satis_Fiyati = @BT1_Satis_Fiyati, " +
                                  "Birim_Kodu_2 = @Birim_Kodu_2, BT2_Orani = @BT2_Orani, BT2_Barkod = @BT2_Barkod, BT2_Alis_Fiyati = @BT2_Alis_Fiyati, BT2_Alis_Kdvli_Fiyati = @BT2_Alis_Kdvli_Fiyati, BT2_Satis_Fiyati = @BT2_Satis_Fiyati, " +
                                  "Update_User = @Kullanici, Update_Date = @Zaman " +
                                  "WHERE Silindi = 0 AND Stok_Kodu = @Stok_Kodu";

            cmd.Parameters.AddWithValue("@Stok_No", lblStokNo.Text.Trim());
            cmd.Parameters.AddWithValue("@Stok_Adi", txtStokAdi.Text.Trim());
            cmd.Parameters.AddWithValue("@Kisa_Adi", txtKisaAdi.Text.Trim());
            cmd.Parameters.AddWithValue("@Grup_Kodu", txtGrupKodu.Text.Trim());
            cmd.Parameters.AddWithValue("@Ozel_Kodu", txtOzelKodu.Text.Trim());
            cmd.Parameters.AddWithValue("@Kdv_Toptan", cbKdvToptan.SelectedItemForCode().TODOUBLE(0));
            cmd.Parameters.AddWithValue("@Kdv_Perakende", cbKdvPerakende.SelectedItemForCode().TODOUBLE(0));
            cmd.Parameters.AddWithValue("@Birim_Kodu_1", cbBT1BirimTipi.SelectedItemForCode());
            cmd.Parameters.AddWithValue("@BT1_Orani", nudBT1BirimOrani.Value);
            cmd.Parameters.AddWithValue("@BT1_Barkod", txtBT1Barkod.Text.Trim());
            cmd.Parameters.AddWithValue("@BT1_Alis_Fiyati", nudBT1AlisFiyati.Value);
            cmd.Parameters.AddWithValue("@BT1_Alis_Kdvli_Fiyati", nudBT1AlisFiyatiKdvli.Value);
            cmd.Parameters.AddWithValue("@BT1_Satis_Fiyati", nudBT1SatisFiyati.Value);
            cmd.Parameters.AddWithValue("@Birim_Kodu_2", cbBT2BirimTipi.SelectedItemForCode());
            cmd.Parameters.AddWithValue("@BT2_Orani", nudBT2BirimOrani.Value);
            cmd.Parameters.AddWithValue("@BT2_Barkod", txtBT2Barkod.Text.Trim());
            cmd.Parameters.AddWithValue("@BT2_Alis_Fiyati", nudBT2AlisFiyati.Value);
            cmd.Parameters.AddWithValue("@BT2_Alis_Kdvli_Fiyati", nudBT2AlisFiyatiKdvli.Value);
            cmd.Parameters.AddWithValue("@BT2_Satis_Fiyati", nudBT2SatisFiyati.Value);
            cmd.Parameters.AddWithValue("@Kullanici", clsGenel.strKullaniciKodu);
            cmd.Parameters.AddWithValue("@Zaman", DateTime.Now);
            cmd.Parameters.AddWithValue("@Stok_Kodu", txtStokKodu.Text.Trim());
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            cmd.CommandText = "DELETE FROM Stok_Tedarikci_Tanitimi WHERE Stok_No = @Stok_No";
            cmd.Parameters.AddWithValue("@Stok_No", lblStokNo.Text.Trim());
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            cmd.CommandText = "INSERT INTO Stok_Tedarikci_Tanitimi (Stok_No, Tedarikci_No) VALUES (@Stok_No, @Tedarikci_No)";
            foreach (DataRow DR in dtTedarikciler.Rows)
            {
                cmd.Parameters.AddWithValue("@Stok_No", lblStokNo.Text.Trim());
                cmd.Parameters.AddWithValue("@Tedarikci_No", DR["Tedarikci_No"]);
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
                cmd.CommandText = "UPDATE Stok_Tanitimi SET Silindi = 1, Delete_User = @Delete_User, Delete_Date = @Delete_Date WHERE Silindi = 0 AND Stok_Kodu = @Stok_Kodu";
                cmd.Parameters.AddWithValue("@Delete_User", clsGenel.strKullaniciKodu);
                cmd.Parameters.AddWithValue("@Delete_Date", DateTime.Now);
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
            cmd.CommandText = "SELECT * FROM Cari_Tanitimi WHERE Silindi = 0 AND Cari_Kodu = @Cari_Kodu";
            cmd.Parameters.AddWithValue("@Cari_Kodu", dgvTedarikciler.CurrentRow.Cells["colTedarikciKodu"].Value);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dgvTedarikciler.CurrentRow.Cells["colTedarikciNo"].Value = reader["Cari_No"];
                dgvTedarikciler.CurrentRow.Cells["colTedarikciSec"].Value = "...";
                dgvTedarikciler.CurrentRow.Cells["colTedarikciAdi"].Value = reader["Unvani"];
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
    }
}
