using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace PRCTicari
{
    public partial class frmOdeme : Form
    {
        DataTable dtOdemeTipleri = new DataTable();
        DataTable dtOdemeStoklar = new DataTable();
        DataTable dtOdemeCesniler = new DataTable();
        DataView dvOdemeCesniler;
        private DialogResult drResult = DialogResult.Cancel;
        int intFormWidth = 0;

        private void dgvStoklar_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //
        }

        private void frmOdeme_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = drResult;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtTuslar.Clear();
        }

        public frmOdeme(DataTable dtStoklar, DataTable dtCesniler)
        {
            InitializeComponent();

            intFormWidth = colSec.Width + colStokAdi.Width + colMiktari.Width + colFiyati.Width + colTutari.Width + 56;
            btnTuslarNokta.Text = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT Odeme_No, Odeme_Kodu, Odeme_Adi, Odeme_Tipi, Kayit_Tipi, Kayit_Kodu, CAST(0 AS FLOAT) AS Odeme_Tutari FROM Odeme_Tanitimi WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtOdemeTipleri);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();
            dgvOdemeTipleri.DataSource = dtOdemeTipleri;

            dtOdemeStoklar = dtStoklar.Clone();
            dtOdemeStoklar.Columns.Add("Sec", typeof(int));
            dtOdemeStoklar.Columns.Add("Odeme_Anahtar", typeof(string));
            dtOdemeStoklar.Columns.Add("Isk_Orani_1", typeof(double));
            dtOdemeStoklar.Columns.Add("Isk_Tutari_1", typeof(double));
            dtOdemeStoklar.Columns.Add("Isk_Orani_2", typeof(double));
            dtOdemeStoklar.Columns.Add("Isk_Tutari_2", typeof(double));
            dtOdemeStoklar.Columns.Add("Isk_Orani_3", typeof(double));
            dtOdemeStoklar.Columns.Add("Isk_Tutari_3", typeof(double));
            dtOdemeStoklar.Columns.Add("Kdv_Tutari", typeof(double));
            dtOdemeStoklar.Columns.Add("Tutari_Net", typeof(double));

            foreach (DataRow DR in dtStoklar.Rows)
            {
                DataRow DRCopy = dtOdemeStoklar.NewRow();
                foreach (DataColumn DC in dtStoklar.Columns) DRCopy[DC.ColumnName] = DR[DC.ColumnName];
                DRCopy["Sec"] = 1;
                DRCopy["Odeme_Anahtar"] = "";
                DRCopy["Isk_Orani_1"] = 0;
                DRCopy["Isk_Tutari_1"] = 0;
                DRCopy["Isk_Orani_2"] = 0;
                DRCopy["Isk_Tutari_2"] = 0;
                DRCopy["Isk_Orani_3"] = 0;
                DRCopy["Isk_Tutari_3"] = 0;
                DRCopy["Kdv_Tutari"] = 0;
                DRCopy["Tutari_Net"] = 0;

                dtOdemeStoklar.Rows.Add(DRCopy);
            }

            dtOdemeCesniler = dtCesniler.Clone();
            dtOdemeCesniler.Columns.Add("Isk_Orani_1", typeof(double));
            dtOdemeCesniler.Columns.Add("Isk_Tutari_1", typeof(double));
            dtOdemeCesniler.Columns.Add("Isk_Orani_2", typeof(double));
            dtOdemeCesniler.Columns.Add("Isk_Tutari_2", typeof(double));
            dtOdemeCesniler.Columns.Add("Isk_Orani_3", typeof(double));
            dtOdemeCesniler.Columns.Add("Isk_Tutari_3", typeof(double));
            dtOdemeCesniler.Columns.Add("Kdv_Tutari", typeof(double));
            dtOdemeCesniler.Columns.Add("Tutari_Net", typeof(double));

            foreach (DataRow DR in dtCesniler.Rows)
            {
                DataRow DRCopy = dtOdemeCesniler.NewRow();
                foreach (DataColumn DC in dtCesniler.Columns) DRCopy[DC.ColumnName] = DR[DC.ColumnName];
                DRCopy["Isk_Orani_1"] = 0;
                DRCopy["Isk_Tutari_1"] = 0;
                DRCopy["Isk_Orani_2"] = 0;
                DRCopy["Isk_Tutari_2"] = 0;
                DRCopy["Isk_Orani_3"] = 0;
                DRCopy["Isk_Tutari_3"] = 0;
                DRCopy["Kdv_Tutari"] = 0;
                DRCopy["Tutari_Net"] = 0;

                dtOdemeCesniler.Rows.Add(DRCopy);
            }
            dvOdemeCesniler = new DataView(dtOdemeCesniler);

            dgvStoklar.DataSource = dtOdemeStoklar;
            dgvCesniler.DataSource = dvOdemeCesniler;
        }

        private void frmOdeme_Shown(object sender, EventArgs e)
        {
            btnParcaliOdeme.PerformClick();
        }

        private void btnTuslar7_Click(object sender, EventArgs e)
        {
            txtTuslar.Text += ((Button)sender).Text.Trim();
            txtTuslar.Focus();
        }

        private void dgvStoklar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dvOdemeCesniler.RowFilter = string.Format("Anahtar = '{0}'", dgvStoklar.CurrentRow.Cells["colAnahtar"].Value.TOSTRING());
            }
        }

        bool blnDirty = false;
        private void dgvStoklar_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvStoklar.CurrentRow.Index > -1 && dgvStoklar.Columns[dgvStoklar.CurrentCell.ColumnIndex].Name == colSec.Name && !blnDirty)
            {
                blnDirty = true;
                if (string.IsNullOrEmpty(dgvStoklar.CurrentRow.Cells[colOdemeAnahtar.Name].Value.TOSTRING().Trim()))
                {
                    dgvStoklar.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    if (dblYuvarlamaOrani != 0)
                    {
                        if (MessageBox.Show("Tutar değişeceği için yuvarlama işlemi iptal olacak. Devam etmek istediğinize emin misiniz?", "Yuvarlama", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            dblYuvarlamaOrani = 0;
                        else
                        {
                            dgvStoklar.CurrentRow.Cells[colSec.Name].Value = dgvStoklar.CurrentRow.Cells[colSec.Name].Value.TOINT() == 0 ? 1 : 0;
                            dgvStoklar.RefreshEdit();
                            blnDirty = false;
                            return;
                        }
                    }
                    prcdToplamAl();
                }
                else
                {
                    dgvStoklar.CurrentRow.Cells[colSec.Name].Value = 1;
                    dgvStoklar.RefreshEdit();
                }

                blnDirty = false;
            }
        }

        private void btnSecMusteriKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECMusteri();
            if (o != null)
            {
                prcdMusteriBilgiGetir(o.TOSTRING());
            }
        }

        private void btnTemizleMusteriKodu_Click(object sender, EventArgs e)
        {
            prcdMusteriBilgiGetir("");
        }

        private void txtMusteriKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                prcdMusteriBilgiGetir(txtMusteriKodu.Text.Trim());
            }
        }

        int intMusteriNo = 0;
        string strMusteriKodu = "";
        double dblMusteriIndirimOrani = 0;
        private void prcdMusteriBilgiGetir(string strMusteriKoduTemp)
        {
            if (dblYuvarlamaOrani != 0)
            {
                if (MessageBox.Show("Müşteri bilgisi değiştiğinde tutar değişebileceği için yuvarlama işlemi iptal olacak. Devam etmek istediğinize emin misiniz?", "Yuvarlama", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    dblYuvarlamaOrani = 0;
                else
                {
                    txtMusteriKodu.Text = strMusteriKodu;
                    return;
                }
            }

            DataRow[] arrDR = dtOdemeTipleri.Select("Odeme_Tipi = 3");
            foreach (DataRow DR in arrDR) DR["Odeme_Tutari"] = 0;
            intMusteriNo = 0;
            lblUnvani.Text = "";
            lblIskontoOrani.Text = "";
            strMusteriKodu = "";
            dblMusteriIndirimOrani = 0;
            txtMusteriKodu.Text = strMusteriKoduTemp;
            strMusteriKodu = txtMusteriKodu.Text;
            if (!string.IsNullOrEmpty(txtMusteriKodu.Text))
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
                    intMusteriNo = reader["Cari_No"].TOINT();
                    lblUnvani.Text = reader["Unvani"].TOSTRING();
                    dblMusteriIndirimOrani = reader["Indirim"].TODOUBLE();
                    lblIskontoOrani.Text = "Müşteri İndirimi: %" + dblMusteriIndirimOrani.ToString(clsGenel.strDoubleFormatTwo);
                }
                reader.Close();
                cmd.Dispose();
                cnn.Close();
            }


            prcdToplamAl();
        }

        private void btnParcaliOdeme_Click(object sender, EventArgs e)
        {
            if (btnParcaliOdeme.Text == "<<")
            {
                this.Width -= intFormWidth;
                this.Left += intFormWidth / 2;

                foreach (DataRow DR in dtOdemeStoklar.Rows)
                {
                    if (string.IsNullOrEmpty(DR["Odeme_Anahtar"].TOSTRING().Trim()))
                    {
                        DR["Sec"] = 1;
                    }
                }

                btnParcaliOdeme.Text = ">>";
            }
            else
            {
                this.Width += intFormWidth;
                this.Left -= intFormWidth / 2;

                foreach (DataGridViewColumn DGVC in dgvStoklar.Columns)
                {
                    DGVC.Visible = DGVC.Name == colSec.Name || DGVC.Name == colStokAdi.Name || DGVC.Name == colMiktari.Name || DGVC.Name == colFiyati.Name || DGVC.Name == colTutari.Name;
                }

                foreach (DataGridViewColumn DGVC in dgvCesniler.Columns)
                {
                    DGVC.Visible = DGVC.Name == colStokAdiCesni.Name || DGVC.Name == colMiktariCesni.Name || DGVC.Name == colFiyatiCesni.Name || DGVC.Name == colTutariCesni.Name;
                }

                foreach (DataRow DR in dtOdemeStoklar.Rows)
                {
                    if (string.IsNullOrEmpty(DR["Odeme_Anahtar"].TOSTRING().Trim()))
                    {
                        DR["Sec"] = 0;
                    }
                }

                btnParcaliOdeme.Text = "<<";
            }

            prcdToplamAl();
        }

        double dblYuvarlamaOrani = 0;
        private void btnAsagiYuvarla_Click(object sender, EventArgs e)
        {
            dblYuvarlamaOrani = (lblToplam.AccessibleDescription.TODOUBLE() - Math.Floor(lblToplam.AccessibleDescription.TODOUBLE())) / lblToplam.AccessibleDescription.TODOUBLE() * 100;
            prcdToplamAl();
        }

        private void btnYukariYuvarla_Click(object sender, EventArgs e)
        {
            dblYuvarlamaOrani = (1 - (lblToplam.AccessibleDescription.TODOUBLE() - Math.Floor(lblToplam.AccessibleDescription.TODOUBLE()))) / lblToplam.AccessibleDescription.TODOUBLE() * -1 * 100;
            prcdToplamAl();
        }

        private void btnYuvarlamaIptal_Click(object sender, EventArgs e)
        {
            dblYuvarlamaOrani = 0;
            prcdToplamAl();
        }

        double dblIskontoOrani = 0;

        private void btnOranIskontosu_Click(object sender, EventArgs e)
        {
            dblIskontoOrani = txtTuslar.Text.TODOUBLE();
            prcdToplamAl();
            txtTuslar.Clear();
            txtTuslar.Focus();
        }

        private void btnTutarIskontosu_Click(object sender, EventArgs e)
        {
            dblIskontoOrani = txtTuslar.Text.TODOUBLE() / lblNetToplam.AccessibleDescription.TODOUBLE() * 100;
            prcdToplamAl();
            txtTuslar.Clear();
            txtTuslar.Focus();
        }

        private void btnIskontoIptal_Click(object sender, EventArgs e)
        {
            dblIskontoOrani = 0;
            prcdToplamAl();
            txtTuslar.Clear();
            txtTuslar.Focus();
        }

        private void dgvOdemeTipleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOdemeTipleri.Columns[e.ColumnIndex].Name == colOdemeAdi.Name && e.RowIndex > -1)
            {
                if (dgvOdemeTipleri.Rows[e.RowIndex].Cells[colOdemeTipi.Name].Value.TOINT() == 3 && intMusteriNo == 0)
                {
                    MessageBox.Show("Veresiye işlemi için müşteri seçmeniz gerekmektedir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (dgvOdemeTipleri.Rows[e.RowIndex].Cells[colOdemeTipi.Name].Value.TOINT() != 0 && txtTuslar.Text.Trim().TODOUBLE() > lblKalan.AccessibleDescription.TODOUBLE())
                {
                    MessageBox.Show("Bu ödeme tipinde kalan tutardan daha fazla bedel girilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (dgvOdemeTipleri.Rows[e.RowIndex].Cells[colOdemeTutari.Name].Value.TODOUBLE() == 0)
                {
                    if (!string.IsNullOrEmpty(txtTuslar.Text.Trim()))
                        dgvOdemeTipleri.Rows[e.RowIndex].Cells[colOdemeTutari.Name].Value = txtTuslar.Text.Trim().TODOUBLE();
                    else
                        dgvOdemeTipleri.Rows[e.RowIndex].Cells[colOdemeTutari.Name].Value = lblKalan.AccessibleDescription.TODOUBLE();
                }
                else
                {
                    dgvOdemeTipleri.Rows[e.RowIndex].Cells[colOdemeTutari.Name].Value = 0;
                }

                prcdToplamAl();
                txtTuslar.Clear();
                txtTuslar.Focus();
            }
        }

        private void dgvStoklar_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (!string.IsNullOrEmpty(dgvStoklar.Rows[e.RowIndex].Cells[colOdemeAnahtar.Name].Value.TOSTRING().Trim()))
            {
                dgvStoklar.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                dgvStoklar.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void prcdToplamAl()
        {
            double dblIskToplami1 = 0;
            double dblIskToplami2 = 0;
            double dblIskToplami3 = 0;
            double dblKdvToplami = 0;
            double dblTutarToplami = 0;
            double dblTutarIskontoluToplami = 0;
            double dblTutarNetToplami = 0;

            EnumerableRowCollection arrDR = from myRow in dtOdemeStoklar.AsEnumerable() where myRow.Field<int>("Sec") == 1 && string.IsNullOrEmpty(myRow.Field<string>("Odeme_Anahtar").TOSTRING().Trim()) select myRow;
            foreach (DataRow DR in arrDR)
            {
                DR["Isk_Orani_1"] = dblMusteriIndirimOrani;
                DR["Isk_Orani_2"] = dblIskontoOrani;
                DR["Isk_Orani_3"] = dblYuvarlamaOrani;

                double dblMiktari = DR["Miktari"].TODOUBLE();
                double dblFiyati = DR["Fiyati"].TODOUBLE();
                double dblKdvOrani = DR["Kdv_Orani"].TODOUBLE();
                double dblIskOrani1 = DR["Isk_Orani_1"].TODOUBLE();
                double dblIskOrani2 = DR["Isk_Orani_2"].TODOUBLE();
                double dblIskOrani3 = DR["Isk_Orani_3"].TODOUBLE();

                double dblTutari = dblMiktari * dblFiyati;
                double dblTutariNet = dblTutari;
                double dblTutariIskontolu = dblTutari;

                double dblIskTutari1 = dblTutari * dblIskOrani1 / 100;
                double dblIskTutari2 = (dblTutari - dblIskTutari1) * dblIskOrani2 / 100;
                double dblIskTutari3 = (dblTutari - dblIskTutari1 - dblIskTutari2) * dblIskOrani3 / 100;

                double dblTutariIskontoluYuvarlamali = dblTutari - dblIskTutari1 - dblIskTutari2 - dblIskTutari3;
                dblTutariIskontolu = dblTutariIskontolu - dblIskTutari1 - dblIskTutari2;
                dblTutariNet = dblTutariNet - dblIskTutari1 - dblIskTutari2 - dblIskTutari3;

                double dblKdvTutari = dblTutariIskontoluYuvarlamali - (dblTutariIskontoluYuvarlamali / (1 + (dblKdvOrani / 100)));

                DR["Isk_Tutari_1"] = dblIskTutari1;
                DR["Isk_Tutari_2"] = dblIskTutari2;
                DR["Isk_Tutari_3"] = dblIskTutari3;
                DR["Kdv_Tutari"] = dblKdvTutari;
                DR["Tutari"] = dblTutari;
                DR["Tutari_Net"] = dblTutariNet;

                dblIskToplami1 += dblIskTutari1;
                dblIskToplami2 += dblIskTutari2;
                dblIskToplami3 += dblIskTutari3;
                dblKdvToplami += dblKdvTutari;
                dblTutarToplami += dblTutari;
                dblTutarIskontoluToplami += dblTutariIskontolu;
                dblTutarNetToplami += dblTutariNet;

                foreach (DataRow DRCesni in dtOdemeCesniler.Select(string.Format("Anahtar = '{0}'", DR["Anahtar"].TOSTRING())))
                {
                    DRCesni["Isk_Orani_1"] = dblMusteriIndirimOrani;
                    DRCesni["Isk_Orani_2"] = dblIskontoOrani;
                    DRCesni["Isk_Orani_3"] = dblYuvarlamaOrani;

                    double dblMiktariCesni = DRCesni["Miktari"].TODOUBLE();
                    double dblFiyatiCesni = DRCesni["Fiyati"].TODOUBLE();
                    double dblKdvOraniCesni = DRCesni["Kdv_Orani"].TODOUBLE();
                    double dblIskOrani1Cesni = DRCesni["Isk_Orani_1"].TODOUBLE();
                    double dblIskOrani2Cesni = DRCesni["Isk_Orani_2"].TODOUBLE();
                    double dblIskOrani3Cesni = DRCesni["Isk_Orani_3"].TODOUBLE();

                    double dblTutariCesni = dblMiktariCesni * dblFiyatiCesni;
                    double dblTutariNetCesni = dblTutariCesni;
                    double dblTutariIskontoluCesni = dblTutariCesni;

                    double dblIskTutari1Cesni = dblTutariCesni * dblIskOrani1Cesni / 100;
                    double dblIskTutari2Cesni = (dblTutariCesni - dblIskTutari1Cesni) * dblIskOrani2Cesni / 100;
                    double dblIskTutari3Cesni = (dblTutariCesni - dblIskTutari1Cesni - dblIskTutari2Cesni) * dblIskOrani3Cesni / 100;

                    double dblTutariIskontoluYuvarlamaliCesni = dblTutariCesni - dblIskTutari1Cesni - dblIskTutari2Cesni - dblIskTutari3Cesni;
                    dblTutariIskontoluCesni = dblTutariIskontoluCesni - dblIskTutari1Cesni - dblIskTutari2Cesni;
                    dblTutariNetCesni = dblTutariNetCesni - dblIskTutari1Cesni - dblIskTutari2Cesni - dblIskTutari3Cesni;

                    double dblKdvTutariCesni = dblTutariIskontoluYuvarlamaliCesni - (dblTutariIskontoluYuvarlamaliCesni / (1 + (dblKdvOraniCesni / 100)));

                    DRCesni["Isk_Tutari_1"] = dblIskTutari1Cesni;
                    DRCesni["Isk_Tutari_2"] = dblIskTutari2Cesni;
                    DRCesni["Isk_Tutari_3"] = dblIskTutari3Cesni;
                    DRCesni["Kdv_Tutari"] = dblKdvTutariCesni;
                    DRCesni["Tutari"] = dblTutariCesni;
                    DRCesni["Tutari_Net"] = dblTutariNetCesni;

                    dblIskToplami1 += dblIskTutari1Cesni;
                    dblIskToplami2 += dblIskTutari2Cesni;
                    dblIskToplami3 += dblIskTutari3Cesni;
                    dblKdvToplami += dblKdvTutariCesni;
                    dblTutarToplami += dblTutariCesni;
                    dblTutarIskontoluToplami += dblTutariIskontoluCesni;
                    dblTutarNetToplami += dblTutariNetCesni;
                }
            }
            double dblOdenen = dtOdemeTipleri.Compute("SUM(Odeme_Tutari)", "").TODOUBLE();

            lblAraToplam.AccessibleDescription = dblTutarToplami.TOSTRING();
            lblIskontoToplami.AccessibleDescription = (dblIskToplami1 + dblIskToplami2).TOSTRING();
            lblToplam.AccessibleDescription = dblTutarIskontoluToplami.TOSTRING();
            lblYuvarlama.AccessibleDescription = dblIskToplami3.TOSTRING();
            lblKdvToplami.AccessibleDescription = dblKdvToplami.TOSTRING();
            lblNetToplam.AccessibleDescription = dblTutarNetToplami.TOSTRING();
            lblOdenen.AccessibleDescription = dblOdenen.TOSTRING();
            if (dblTutarNetToplami - dblOdenen > 0)
            {
                lblKalan.AccessibleDescription = (dblTutarNetToplami - dblOdenen).TOSTRING();
                lblParaUstu.AccessibleDescription = "0";
            }
            else
            {
                lblKalan.AccessibleDescription = "0";
                lblParaUstu.AccessibleDescription = Math.Abs(dblTutarNetToplami - dblOdenen).TOSTRING();
            }


            lblAraToplam.Text = dblTutarToplami.ToString(clsGenel.strDoubleFormatTwo);
            lblIskontoToplami.Text = (dblIskToplami1 + dblIskToplami2).ToString(clsGenel.strDoubleFormatTwo);
            lblToplam.Text = dblTutarIskontoluToplami.ToString(clsGenel.strDoubleFormatTwo);
            lblYuvarlama.Text = dblIskToplami3.ToString(clsGenel.strDoubleFormatTwo);
            lblKdvToplami.Text = dblKdvToplami.ToString(clsGenel.strDoubleFormatTwo);
            lblNetToplam.Text = dblTutarNetToplami.ToString(clsGenel.strDoubleFormatTwo);
            lblOdenen.Text = dblOdenen.ToString(clsGenel.strDoubleFormatTwo);
            if (dblTutarNetToplami - dblOdenen > 0)
            {
                lblKalan.Text = (dblTutarNetToplami - dblOdenen).ToString(clsGenel.strDoubleFormatTwo);
                lblParaUstu.Text = "";
            }
            else
            {
                lblKalan.Text = "";
                lblParaUstu.Text = Math.Abs(dblTutarNetToplami - dblOdenen).ToString(clsGenel.strDoubleFormatTwo);
            }
        }

        Dictionary<string, DataTable> dOdemeler = new Dictionary<string, DataTable>();
        private void btnOdemeAl_Click(object sender, EventArgs e)
        {
            if (Math.Round(lblKalan.AccessibleDescription.TODOUBLE(), 2, MidpointRounding.AwayFromZero) == 0)
            {
                string strOdemeAnahtar = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "|" + intMusteriNo.TOSTRING();

                DataTable dtOdeme = dtOdemeTipleri.Clone();
                EnumerableRowCollection<DataRow> arrDR = from myRow in dtOdemeTipleri.AsEnumerable() where myRow.Field<double>("Odeme_Tutari") != 0 select myRow;
                if (arrDR.Count() > 0)
                {
                    foreach (DataRow DR in arrDR)
                    {
                        if (lblParaUstu.AccessibleDescription.TODOUBLE() > 0 && DR["Odeme_Tipi"].TOINT() == 0)
                        {
                            DR["Odeme_Tutari"] = DR["Odeme_Tutari"].TODOUBLE() - lblParaUstu.AccessibleDescription.TODOUBLE();
                        }
                        dtOdeme.ImportRow(DR);
                        DR["Odeme_Tutari"] = 0;
                    }
                    dOdemeler.Add(strOdemeAnahtar, dtOdeme);

                    arrDR = from myRow in dtOdemeStoklar.AsEnumerable() where myRow.Field<int>("Sec") == 1 && string.IsNullOrEmpty(myRow.Field<string>("Odeme_Anahtar").TOSTRING().Trim()) select myRow;
                    foreach (DataRow DR in arrDR)
                    {
                        DR["Odeme_Anahtar"] = strOdemeAnahtar;
                    }

                    btnYuvarlamaIptal.PerformClick();
                    btnTemizleMusteriKodu.PerformClick();

                    prcdToplamAl();
                }

                arrDR = from myRow in dtOdemeStoklar.AsEnumerable() where string.IsNullOrEmpty(myRow.Field<string>("Odeme_Anahtar").TOSTRING().Trim()) select myRow;
                if (arrDR.Count() == 0)
                {
                    if (fncKaydet())
                    {
                        drResult = DialogResult.OK;
                        Close();
                    }
                }

                dgvStoklar.Refresh();
            }
            else
            {
                MessageBox.Show("Ödemede kalan tutar olduğundan işleme devam edilemiyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private bool fncKaydet()
        {
            bool blnReturn = false;
            
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.Transaction = cnn.BeginTransaction();
            try
            {
                foreach (string strOdemeAnahtar in dOdemeler.Keys)
                {
                    string strAnahtar = strOdemeAnahtar.Split('|')[0].TOSTRING();
                    int intCariNo = strOdemeAnahtar.Split('|')[1].TOINT();
                    int intFisTipi = (int)clsFisTipleri.FisTipleri.HizliSatis;
                    int intFisNo = clsGenel.fncYeniFisNoGetir(clsFisTipleri.FisTipleri.HizliSatis, clsGenel.intGenelIsyeriKodu, cnn, cmd);
                    string strParaBirimi = clsGenel.fncGetParameter("Para_Birimi", "TL");
                    DateTime dtFisTarihi = DateTime.ParseExact(strAnahtar, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                    DataTable dtOdeme = dOdemeler[strOdemeAnahtar];
                    double dblOdemeToplami = dtOdeme.Compute("SUM(Odeme_Tutari)", "").TODOUBLE();
                    double dblOdemeToplamiVeresiyesiz = dtOdeme.Compute("SUM(Odeme_Tutari)", "Odeme_Tipi <> 3").TODOUBLE();

                    cmd.CommandText = "INSERT INTO Islem_Baslik (Depo_Kodu_1, Depo_Kodu_2, Fis_Tarihi, Fis_Saati, Cari_No, Belge_Tipi, Belge_No, Belge_Tarihi, Para_Birimi, Fiyat_Tipi, Kdv_Tipi_1, Kdv_Tipi_2, Aciklama, Insert_User, Inser_Date, Silindi, Kurum_Kodu, Fis_Tipi, Isyeri_Kodu, Fis_No) " +
                                      "VALUES (@Depo_Kodu_1, @Depo_Kodu_2, @Fis_Tarihi, @Fis_Saati, @Cari_No, @Belge_Tipi, @Belge_No, @Belge_Tarihi, @Para_Birimi, @Fiyat_Tipi, @Kdv_Tipi_1, @Kdv_Tipi_2, @Aciklama, @Kullanici, @Zaman, @Silindi, @Kurum_Kodu, @Fis_Tipi, @Isyeri_Kodu, @Fis_No)";
                    cmd.Parameters.AddWithValue("@Depo_Kodu_1", clsGenel.intGenelDepoKodu);
                    cmd.Parameters.AddWithValue("@Depo_Kodu_2", 0);
                    cmd.Parameters.AddWithValue("@Fis_Tarihi", dtFisTarihi.TODATE());
                    cmd.Parameters.AddWithValue("@Fis_Saati", dtFisTarihi.TOTIME());
                    cmd.Parameters.AddWithValue("@Cari_No", intCariNo);
                    cmd.Parameters.AddWithValue("@Belge_Tipi", "");
                    cmd.Parameters.AddWithValue("@Belge_No", strAnahtar);
                    cmd.Parameters.AddWithValue("@Belge_Tarihi", dtFisTarihi);
                    cmd.Parameters.AddWithValue("@Para_Birimi", strParaBirimi);
                    cmd.Parameters.AddWithValue("@Fiyat_Tipi", 1);
                    cmd.Parameters.AddWithValue("@Kdv_Tipi_1", 1);
                    cmd.Parameters.AddWithValue("@Kdv_Tipi_2", 1);
                    cmd.Parameters.AddWithValue("@Aciklama", "");
                    cmd.Parameters.AddWithValue("@Kullanici", clsGenel.strKullaniciKodu);
                    cmd.Parameters.AddWithValue("@Zaman", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Silindi", 0);
                    cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                    cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                    cmd.Parameters.AddWithValue("@Isyeri_Kodu", clsGenel.intGenelIsyeriKodu);
                    cmd.Parameters.AddWithValue("@Fis_No", intFisNo);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();


                    int intFisSira1 = 1;
                    int intFisSira2 = 1;
                    if (intCariNo > 0)
                    {
                        cmd.CommandText = "INSERT INTO Islem_Detay_Cari (Cari_No, Fis_Tarihi, Fis_Saati, Borc_Tutari, Borc_Tutari_Baslik, Borc_Tutari_Kart, Borc_Tutari_Sistem, Alacak_Tutari, Alacak_Tutari_Baslik, Alacak_Tutari_Kart, Alacak_Tutari_Sistem, Aciklama, Silindi, Kurum_Kodu, Fis_Tipi, Isyeri_Kodu, Fis_No, Fis_Sira, Islem_Yonu) " +
                                          "VALUES (@Cari_No, @Fis_Tarihi, @Fis_Saati, @Borc_Tutari, @Borc_Tutari_Baslik, @Borc_Tutari_Kart, @Borc_Tutari_Sistem, @Alacak_Tutari, @Alacak_Tutari_Baslik, @Alacak_Tutari_Kart, @Alacak_Tutari_Sistem, @Aciklama, @Silindi, @Kurum_Kodu, @Fis_Tipi, @Isyeri_Kodu, @Fis_No, @Fis_Sira, @Islem_Yonu)";
                        cmd.Parameters.AddWithValue("@Cari_No", intCariNo);
                        cmd.Parameters.AddWithValue("@Fis_Tarihi", dtFisTarihi.TODATE());
                        cmd.Parameters.AddWithValue("@Fis_Saati", dtFisTarihi.TOTIME());
                        cmd.Parameters.AddWithValue("@Borc_Tutari", dblOdemeToplami);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Baslik", dblOdemeToplami);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Kart", dblOdemeToplami);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Sistem", dblOdemeToplami);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari", 0);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari_Baslik", 0);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari_Kart", 0);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari_Sistem", 0);
                        cmd.Parameters.AddWithValue("@Aciklama", "");
                        cmd.Parameters.AddWithValue("@Silindi", 0);
                        cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                        cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                        cmd.Parameters.AddWithValue("@Isyeri_Kodu", clsGenel.intGenelIsyeriKodu);
                        cmd.Parameters.AddWithValue("@Fis_No", intFisNo);
                        cmd.Parameters.AddWithValue("@Fis_Sira", intFisSira1);
                        cmd.Parameters.AddWithValue("@Islem_Yonu", ((int)clsFisTipleri.IslemYonu.Giris));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        intFisSira1++;

                        cmd.CommandText = "INSERT INTO Islem_Detay_Cari (Cari_No, Fis_Tarihi, Fis_Saati, Borc_Tutari, Borc_Tutari_Baslik, Borc_Tutari_Kart, Borc_Tutari_Sistem, Alacak_Tutari, Alacak_Tutari_Baslik, Alacak_Tutari_Kart, Alacak_Tutari_Sistem, Aciklama, Silindi, Kurum_Kodu, Fis_Tipi, Isyeri_Kodu, Fis_No, Fis_Sira, Islem_Yonu) " +
                                          "VALUES (@Cari_No, @Fis_Tarihi, @Fis_Saati, @Borc_Tutari, @Borc_Tutari_Baslik, @Borc_Tutari_Kart, @Borc_Tutari_Sistem, @Alacak_Tutari, @Alacak_Tutari_Baslik, @Alacak_Tutari_Kart, @Alacak_Tutari_Sistem, @Aciklama, @Silindi, @Kurum_Kodu, @Fis_Tipi, @Isyeri_Kodu, @Fis_No, @Fis_Sira, @Islem_Yonu)";
                        cmd.Parameters.AddWithValue("@Cari_No", intCariNo);
                        cmd.Parameters.AddWithValue("@Fis_Tarihi", dtFisTarihi.TODATE());
                        cmd.Parameters.AddWithValue("@Fis_Saati", dtFisTarihi.TOTIME());
                        cmd.Parameters.AddWithValue("@Borc_Tutari", 0);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Baslik", 0);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Kart", 0);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Sistem", 0);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari", dblOdemeToplamiVeresiyesiz);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari_Baslik", dblOdemeToplamiVeresiyesiz);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari_Kart", dblOdemeToplamiVeresiyesiz);
                        cmd.Parameters.AddWithValue("@Alacak_Tutari_Sistem", dblOdemeToplamiVeresiyesiz);
                        cmd.Parameters.AddWithValue("@Aciklama", "");
                        cmd.Parameters.AddWithValue("@Silindi", 0);
                        cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                        cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                        cmd.Parameters.AddWithValue("@Isyeri_Kodu", clsGenel.intGenelIsyeriKodu);
                        cmd.Parameters.AddWithValue("@Fis_No", intFisNo);
                        cmd.Parameters.AddWithValue("@Fis_Sira", intFisSira1);
                        cmd.Parameters.AddWithValue("@Islem_Yonu", ((int)clsFisTipleri.IslemYonu.Cikis));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        intFisSira1++;
                    }

                    foreach (DataRow DR in dtOdeme.Rows)
                    {
                        if (DR["Kayit_Tipi"].TOINT() == 1)
                        {
                            cmd.CommandText = "INSERT INTO Islem_Detay_Cari (Cari_No, Fis_Tarihi, Fis_Saati, Borc_Tutari, Borc_Tutari_Baslik, Borc_Tutari_Kart, Borc_Tutari_Sistem, Alacak_Tutari, Alacak_Tutari_Baslik, Alacak_Tutari_Kart, Alacak_Tutari_Sistem, Aciklama, Odeme_No, Silindi, Kurum_Kodu, Fis_Tipi, Isyeri_Kodu, Fis_No, Fis_Sira, Islem_Yonu) " +
                                              "VALUES (@Cari_No, @Fis_Tarihi, @Fis_Saati, @Borc_Tutari, @Borc_Tutari_Baslik, @Borc_Tutari_Kart, @Borc_Tutari_Sistem, @Alacak_Tutari, @Alacak_Tutari_Baslik, @Alacak_Tutari_Kart, @Alacak_Tutari_Sistem, @Aciklama, @Odeme_No, @Silindi, @Kurum_Kodu, @Fis_Tipi, @Isyeri_Kodu, @Fis_No, @Fis_Sira, @Islem_Yonu)";
                            cmd.Parameters.AddWithValue("@Cari_No", DR["Kayit_Kodu"]);
                            cmd.Parameters.AddWithValue("@Fis_Tarihi", dtFisTarihi.TODATE());
                            cmd.Parameters.AddWithValue("@Fis_Saati", dtFisTarihi.TOTIME());
                            cmd.Parameters.AddWithValue("@Borc_Tutari", DR["Odeme_Tutari"]);
                            cmd.Parameters.AddWithValue("@Borc_Tutari_Baslik", DR["Odeme_Tutari"]);
                            cmd.Parameters.AddWithValue("@Borc_Tutari_Kart", DR["Odeme_Tutari"]);
                            cmd.Parameters.AddWithValue("@Borc_Tutari_Sistem", DR["Odeme_Tutari"]);
                            cmd.Parameters.AddWithValue("@Alacak_Tutari", 0);
                            cmd.Parameters.AddWithValue("@Alacak_Tutari_Baslik", 0);
                            cmd.Parameters.AddWithValue("@Alacak_Tutari_Kart", 0);
                            cmd.Parameters.AddWithValue("@Alacak_Tutari_Sistem", 0);
                            cmd.Parameters.AddWithValue("@Aciklama", "");
                            cmd.Parameters.AddWithValue("@Odeme_No", DR["Odeme_No"]);
                            cmd.Parameters.AddWithValue("@Silindi", 0);
                            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                            cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                            cmd.Parameters.AddWithValue("@Isyeri_Kodu", clsGenel.intGenelIsyeriKodu);
                            cmd.Parameters.AddWithValue("@Fis_No", intFisNo);
                            cmd.Parameters.AddWithValue("@Fis_Sira", intFisSira1);
                            cmd.Parameters.AddWithValue("@Islem_Yonu", ((int)clsFisTipleri.IslemYonu.Giris));
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            intFisSira1++;
                        }
                        else if (DR["Kayit_Tipi"].TOINT() == 2)
                        {
                            cmd.CommandText = "INSERT INTO Islem_Detay_Kasa (Kasa_Kodu, Fis_Tarihi, Fis_Saati, Borc_Tutari, Borc_Tutari_Baslik, Borc_Tutari_Kart, Borc_Tutari_Sistem, Alacak_Tutari, Alacak_Tutari_Baslik, Alacak_Tutari_Kart, Alacak_Tutari_Sistem, Aciklama, Odeme_No, Silindi, Kurum_Kodu, Fis_Tipi, Isyeri_Kodu, Fis_No, Fis_Sira, Islem_Yonu) " +
                                  "VALUES (@Kasa_Kodu, @Fis_Tarihi, @Fis_Saati, @Borc_Tutari, @Borc_Tutari_Baslik, @Borc_Tutari_Kart, @Borc_Tutari_Sistem, @Alacak_Tutari, @Alacak_Tutari_Baslik, @Alacak_Tutari_Kart, @Alacak_Tutari_Sistem, @Aciklama, @Odeme_No, @Silindi, @Kurum_Kodu, @Fis_Tipi, @Isyeri_Kodu, @Fis_No, @Fis_Sira, @Islem_Yonu)";
                            cmd.Parameters.AddWithValue("@Kasa_Kodu", DR["Kayit_Kodu"]);
                            cmd.Parameters.AddWithValue("@Fis_Tarihi", dtFisTarihi.TODATE());
                            cmd.Parameters.AddWithValue("@Fis_Saati", dtFisTarihi.TOTIME());
                            cmd.Parameters.AddWithValue("@Borc_Tutari", DR["Odeme_Tutari"]);
                            cmd.Parameters.AddWithValue("@Borc_Tutari_Baslik", DR["Odeme_Tutari"]);
                            cmd.Parameters.AddWithValue("@Borc_Tutari_Kart", DR["Odeme_Tutari"]);
                            cmd.Parameters.AddWithValue("@Borc_Tutari_Sistem", DR["Odeme_Tutari"]);
                            cmd.Parameters.AddWithValue("@Alacak_Tutari", 0);
                            cmd.Parameters.AddWithValue("@Alacak_Tutari_Baslik", 0);
                            cmd.Parameters.AddWithValue("@Alacak_Tutari_Kart", 0);
                            cmd.Parameters.AddWithValue("@Alacak_Tutari_Sistem", 0);
                            cmd.Parameters.AddWithValue("@Aciklama", "");
                            cmd.Parameters.AddWithValue("@Odeme_No", DR["Odeme_No"]);
                            cmd.Parameters.AddWithValue("@Silindi", 0);
                            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                            cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                            cmd.Parameters.AddWithValue("@Isyeri_Kodu", clsGenel.intGenelIsyeriKodu);
                            cmd.Parameters.AddWithValue("@Fis_No", intFisNo);
                            cmd.Parameters.AddWithValue("@Fis_Sira", intFisSira2);
                            cmd.Parameters.AddWithValue("@Islem_Yonu", ((int)clsFisTipleri.IslemYonu.Giris));
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            intFisSira2++;
                        }
                    }
                    
                    List<DataRow> lstDRStok = new List<DataRow>();
                    EnumerableRowCollection<DataRow> arrDRStok = from myRow in dtOdemeStoklar.AsEnumerable() where myRow.Field<string>("Odeme_Anahtar").TOSTRING().Trim() == strOdemeAnahtar select myRow;
                    lstDRStok.AddRange(arrDRStok);
                    foreach (DataRow DR in arrDRStok)
                    {
                        EnumerableRowCollection<DataRow> arrDRCesni = from myRow in dtOdemeCesniler.AsEnumerable() where myRow.Field<string>("Anahtar").TOSTRING().Trim() == DR["Anahtar"].TOSTRING() select myRow;
                        lstDRStok.AddRange(arrDRCesni);
                    }

                    int intFisSiraStok = 1;
                    foreach (DataRow DR in lstDRStok)
                    {
                        cmd.CommandText = "INSERT INTO Islem_Detay_Stok (Depo_Kodu, Fis_Tarihi, Fis_Saati, Stok_No, Birim_Kodu, Giris_Miktari, Cikis_Miktari, Birim_Fiyati, Isk_Orani_1, Isk_Orani_2, Isk_Orani_3, Kdv_Orani, Isk_Tutari_1, Isk_Tutari_1_Baslik, Isk_Tutari_1_Kart, Isk_Tutari_1_Sistem, Isk_Tutari_2, Isk_Tutari_2_Baslik, Isk_Tutari_2_Kart, Isk_Tutari_2_Sistem, Isk_Tutari_3, Isk_Tutari_3_Baslik, Isk_Tutari_3_Kart, Isk_Tutari_3_Sistem, Kdv_Tutari, Kdv_Tutari_Baslik, Kdv_Tutari_Kart, Kdv_Tutari_Sistem, Giris_Tutari, Giris_Tutari_Baslik, Giris_Tutari_Kart, Giris_Tutari_Sistem, Cikis_Tutari, Cikis_Tutari_Baslik, Cikis_Tutari_Kart, Cikis_Tutari_Sistem, Giris_Tutari_Net, Giris_Tutari_Net_Baslik, Giris_Tutari_Net_Kart, Giris_Tutari_Net_Sistem, Cikis_Tutari_Net, Cikis_Tutari_Net_Baslik, Cikis_Tutari_Net_Kart, Cikis_Tutari_Net_Sistem, Aciklama, Silindi, Kurum_Kodu, Fis_Tipi, Isyeri_Kodu, Fis_No, Fis_Sira, Islem_Yonu) " +
                                          "VALUES (@Depo_Kodu, @Fis_Tarihi, @Fis_Saati, @Stok_No, @Birim_Kodu, @Giris_Miktari, @Cikis_Miktari, @Birim_Fiyati, @Isk_Orani_1, @Isk_Orani_2, @Isk_Orani_3, @Kdv_Orani, @Isk_Tutari_1, @Isk_Tutari_1_Baslik, @Isk_Tutari_1_Kart, @Isk_Tutari_1_Sistem, @Isk_Tutari_2, @Isk_Tutari_2_Baslik, @Isk_Tutari_2_Kart, @Isk_Tutari_2_Sistem, @Isk_Tutari_3, @Isk_Tutari_3_Baslik, @Isk_Tutari_3_Kart, @Isk_Tutari_3_Sistem, @Kdv_Tutari, @Kdv_Tutari_Baslik, @Kdv_Tutari_Kart, @Kdv_Tutari_Sistem, @Giris_Tutari, @Giris_Tutari_Baslik, @Giris_Tutari_Kart, @Giris_Tutari_Sistem, @Cikis_Tutari, @Cikis_Tutari_Baslik, @Cikis_Tutari_Kart, @Cikis_Tutari_Sistem, @Giris_Tutari_Net, @Giris_Tutari_Net_Baslik, @Giris_Tutari_Net_Kart, @Giris_Tutari_Net_Sistem, @Cikis_Tutari_Net, @Cikis_Tutari_Net_Baslik, @Cikis_Tutari_Net_Kart, @Cikis_Tutari_Net_Sistem, @Aciklama, @Silindi, @Kurum_Kodu, @Fis_Tipi, @Isyeri_Kodu, @Fis_No, @Fis_Sira, @Islem_Yonu)";
                        cmd.Parameters.AddWithValue("@Depo_Kodu", clsGenel.intGenelDepoKodu);
                        cmd.Parameters.AddWithValue("@Fis_Tarihi", dtFisTarihi.TODATE());
                        cmd.Parameters.AddWithValue("@Fis_Saati", dtFisTarihi.TOTIME());
                        cmd.Parameters.AddWithValue("@Stok_No", DR["Stok_No"].TOINT());
                        cmd.Parameters.AddWithValue("@Birim_Kodu", DR["Birim_Kodu"].TOSTRING());
                        cmd.Parameters.AddWithValue("@Giris_Miktari", 0);
                        cmd.Parameters.AddWithValue("@Cikis_Miktari", DR["Miktari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Birim_Fiyati", DR["Fiyati"].TODOUBLE());
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
                        cmd.Parameters.AddWithValue("@Giris_Tutari", 0);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Baslik", 0);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Kart", 0);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Sistem", 0);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari", DR["Tutari_Net"].TODOUBLE() - DR["Kdv_Tutari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Baslik", DR["Tutari_Net"].TODOUBLE() - DR["Kdv_Tutari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Kart", DR["Tutari_Net"].TODOUBLE() - DR["Kdv_Tutari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Sistem", DR["Tutari_Net"].TODOUBLE() - DR["Kdv_Tutari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Net", 0);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Net_Baslik", 0);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Net_Kart", 0);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Net_Sistem", 0);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Net", DR["Tutari_Net"]);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Net_Baslik", DR["Tutari_Net"]);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Net_Kart", DR["Tutari_Net"]);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Net_Sistem", DR["Tutari_Net"]);
                        cmd.Parameters.AddWithValue("@Aciklama", DR["Aciklama"].TOSTRING());
                        cmd.Parameters.AddWithValue("@Silindi", 0);
                        cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                        cmd.Parameters.AddWithValue("@Fis_Tipi", intFisTipi);
                        cmd.Parameters.AddWithValue("@Isyeri_Kodu", clsGenel.intGenelIsyeriKodu);
                        cmd.Parameters.AddWithValue("@Fis_No", intFisNo);
                        cmd.Parameters.AddWithValue("@Fis_Sira", intFisSiraStok);
                        cmd.Parameters.AddWithValue("@Islem_Yonu", ((int)clsFisTipleri.IslemYonu.Cikis));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        intFisSiraStok++;
                    }
                }

                cmd.Transaction.Commit();
                blnReturn = true;
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();
                MessageBox.Show("Satışların kayıt işleminde bir hata oluştu." + Environment.NewLine + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            cmd.Dispose();
            cnn.Close();

            return blnReturn;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ödeme işleminden çıkmak istiyor musunuz?", "Kapat", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
