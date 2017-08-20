using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace PRCTicari
{
    public partial class frmHizliSatis : Form
    {
        DataTable dtStoklar = new DataTable();
        DataTable dtCesniler = new DataTable();
        DataView dvCesniler;
        Dictionary<string, Button> lstGrupButtons = new Dictionary<string, Button>();
        Dictionary<string, MyButton> lstStokButtons = new Dictionary<string, MyButton>();

        int intMaxGrupSayisi = 0;
        int intMaxStokSayisi = 0;
        int intMaxCesniSayisi = 0;
        public frmHizliSatis()
        {
            InitializeComponent();
            intMaxGrupSayisi = tlpGruplar.ColumnCount * tlpGruplar.RowCount;
            intMaxStokSayisi = tlpStoklar.ColumnCount * tlpStoklar.RowCount;
            intMaxCesniSayisi = tlpCesniler.ColumnCount * tlpCesniler.RowCount;
            btnTuslarNokta.Text = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            dtStoklar.Columns.Add("Anahtar", typeof(string));
            dtStoklar.Columns.Add("Stok_No", typeof(int));
            dtStoklar.Columns.Add("Stok_Kodu", typeof(string));
            dtStoklar.Columns.Add("Birim_Kodu", typeof(string));
            dtStoklar.Columns.Add("Aciklama", typeof(string));
            dtStoklar.Columns.Add("Kdv_Orani", typeof(double));
            dtStoklar.Columns.Add("Stok_Adi", typeof(string));
            dtStoklar.Columns.Add("Miktari", typeof(double));
            dtStoklar.Columns.Add("Fiyati", typeof(double));
            dtStoklar.Columns.Add("Tutari", typeof(double));
            dgvStoklar.DataSource = dtStoklar;

            dtCesniler.Columns.Add("Anahtar", typeof(string));
            dtCesniler.Columns.Add("Stok_No", typeof(int));
            dtCesniler.Columns.Add("Stok_Kodu", typeof(string));
            dtCesniler.Columns.Add("Birim_Kodu", typeof(string));
            dtCesniler.Columns.Add("Aciklama", typeof(string));
            dtCesniler.Columns.Add("Kdv_Orani", typeof(double));
            dtCesniler.Columns.Add("Stok_Adi", typeof(string));
            dtCesniler.Columns.Add("Miktari", typeof(double));
            dtCesniler.Columns.Add("Fiyati", typeof(double));
            dtCesniler.Columns.Add("Tutari", typeof(double));
            dvCesniler = new DataView(dtCesniler);
            dgvCesniler.DataSource = dvCesniler;

            lstGrupButtons.Add("btnGrup1", btnGrup1);
            lstGrupButtons.Add("btnGrup2", btnGrup2);
            lstGrupButtons.Add("btnGrup3", btnGrup3);
            lstGrupButtons.Add("btnGrup4", btnGrup4);
            lstGrupButtons.Add("btnGrup5", btnGrup5);
            lstGrupButtons.Add("btnGrup6", btnGrup6);
            lstGrupButtons.Add("btnGrup7", btnGrup7);
            lstGrupButtons.Add("btnGrup8", btnGrup8);
            lstGrupButtons.Add("btnGrup9", btnGrup9);
            lstGrupButtons.Add("btnGrup10", btnGrup10);

            lstStokButtons.Add("btnStok1", btnStok1);
            lstStokButtons.Add("btnStok2", btnStok2);
            lstStokButtons.Add("btnStok3", btnStok3);
            lstStokButtons.Add("btnStok4", btnStok4);
            lstStokButtons.Add("btnStok5", btnStok5);
            lstStokButtons.Add("btnStok6", btnStok6);
            lstStokButtons.Add("btnStok7", btnStok7);
            lstStokButtons.Add("btnStok8", btnStok8);
            lstStokButtons.Add("btnStok9", btnStok9);
            lstStokButtons.Add("btnStok10", btnStok10);
            lstStokButtons.Add("btnStok11", btnStok11);
            lstStokButtons.Add("btnStok12", btnStok12);
            lstStokButtons.Add("btnStok13", btnStok13);
            lstStokButtons.Add("btnStok14", btnStok14);
            lstStokButtons.Add("btnStok15", btnStok15);
            lstStokButtons.Add("btnStok16", btnStok16);
            lstStokButtons.Add("btnStok17", btnStok17);
            lstStokButtons.Add("btnStok18", btnStok18);
            lstStokButtons.Add("btnStok19", btnStok19);
            lstStokButtons.Add("btnStok20", btnStok20);
            lstStokButtons.Add("btnStok21", btnStok21);
            lstStokButtons.Add("btnStok22", btnStok22);
            lstStokButtons.Add("btnStok23", btnStok23);
            lstStokButtons.Add("btnStok24", btnStok24);
            lstStokButtons.Add("btnStok25", btnStok25);
            lstStokButtons.Add("btnStok26", btnStok26);
            lstStokButtons.Add("btnStok27", btnStok27);
            lstStokButtons.Add("btnStok28", btnStok28);
            lstStokButtons.Add("btnStok29", btnStok29);
            lstStokButtons.Add("btnStok30", btnStok30);
            lstStokButtons.Add("btnStok31", btnStok31);
            lstStokButtons.Add("btnStok32", btnStok32);
            lstStokButtons.Add("btnStok33", btnStok33);
            lstStokButtons.Add("btnStok34", btnStok34);
            lstStokButtons.Add("btnStok35", btnStok35);
            lstStokButtons.Add("btnStok36", btnStok36);
            lstStokButtons.Add("btnStok37", btnStok37);
            lstStokButtons.Add("btnStok38", btnStok38);
            lstStokButtons.Add("btnStok39", btnStok39);
            lstStokButtons.Add("btnStok40", btnStok40);

            lstStokButtons.Add("btnCesni1", btnCesni1);
            lstStokButtons.Add("btnCesni2", btnCesni2);
            lstStokButtons.Add("btnCesni3", btnCesni3);
            lstStokButtons.Add("btnCesni4", btnCesni4);
            lstStokButtons.Add("btnCesni5", btnCesni5);
            lstStokButtons.Add("btnCesni6", btnCesni6);
            lstStokButtons.Add("btnCesni7", btnCesni7);
            lstStokButtons.Add("btnCesni8", btnCesni8);
            lstStokButtons.Add("btnCesni9", btnCesni9);
            lstStokButtons.Add("btnCesni10", btnCesni10);
            lstStokButtons.Add("btnCesni11", btnCesni11);
            lstStokButtons.Add("btnCesni12", btnCesni12);
        }

        private void frmHizliSatis_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            prcdGruplarGetir();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void prcdGruplarGetir()
        {
            int iGrupSayisi = 0;
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = string.Format("SELECT TOP {0} * FROM Stok_Grup_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu", intMaxGrupSayisi);
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                iGrupSayisi++;
                Button btnGrup = lstGrupButtons["btnGrup" + iGrupSayisi.TOSTRING()];
                btnGrup.Text = reader["Grup_Adi"].TOSTRING();
                btnGrup.AccessibleDescription = reader["Grup_Kodu"].TOSTRING();
                btnGrup.Visible = true;
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();

            for (int i = iGrupSayisi; i < intMaxGrupSayisi; i++)
            {
                Button btnGrup = lstGrupButtons["btnGrup" + (i + 1).TOSTRING()];
                btnGrup.Text = "";
                btnGrup.AccessibleDescription = "";
                btnGrup.Visible = false;
            }

            btnGrup1.PerformClick();
        }

        public void prcdStoklarGetir(string strGrupKodu)
        {
            int iStokSayisi = 0;

            if (!string.IsNullOrEmpty(strGrupKodu))
            {
                SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = string.Format("SELECT TOP {0} ST.*, " +
                                                "(SELECT SUM((A.Giris_Miktari - A.Cikis_Miktari) * (CASE WHEN Birim_Kodu = (CASE WHEN B.BT1_Hizli_Satis = 1 THEN B.Birim_Kodu_1 ELSE B.Birim_Kodu_2 END) THEN 1 ELSE (CASE WHEN B.BT1_Hizli_Satis = 1 THEN B.BT2_Orani ELSE B.BT1_Orani END) END)) FROM Islem_Detay_Stok AS A INNER JOIN Stok_Tanitimi AS B ON B.Silindi = 0 AND A.Kurum_Kodu = B.Kurum_Kodu AND A.Stok_No = B.Stok_No WHERE A.Silindi = 0 AND A.Kurum_Kodu = ST.Kurum_Kodu AND A.Stok_No = ST.Stok_No AND A.Isyeri_Kodu = @Isyeri_Kodu AND A.Depo_Kodu = @Depo_Kodu) AS Depo_Miktari " +
                                                "FROM Stok_Tanitimi AS ST " +
                                                "WHERE ST.Silindi = 0 AND ST.Kurum_Kodu = @Kurum_Kodu AND ST.Grup_Kodu = @Grup_Kodu AND ST.Stok_Tipi IN (0, 1) AND (ST.BT1_Hizli_Satis = 1 OR ST.BT2_Hizli_Satis = 1)", intMaxStokSayisi);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", clsGenel.intGenelIsyeriKodu);
                cmd.Parameters.AddWithValue("@Depo_Kodu", clsGenel.intGenelDepoKodu);
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Grup_Kodu", strGrupKodu);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    iStokSayisi++;
                    MyButton btnStok = lstStokButtons["btnStok" + iStokSayisi.TOSTRING()];
                    btnStok.Text = reader["Kisa_Adi"].TOSTRING();
                    btnStok.Value1 = reader["Depo_Miktari"].TODOUBLE();
                    if (reader["BT1_Hizli_Satis"].TOINT() == 1)
                    {
                        btnStok.Value2 = reader["BT1_Barkod"].TOSTRING();
                        btnStok.Value3 = reader["BT1_Satis_Fiyati"].TODOUBLE();
                    }
                    else if (reader["BT2_Hizli_Satis"].TOINT() == 1)
                    {
                        btnStok.Value2 = reader["BT2_Barkod"].TOSTRING();
                        btnStok.Value3 = reader["BT2_Satis_Fiyati"].TODOUBLE();
                    }

                    btnStok.LabelLeftBottomText = btnStok.Value1.TODOUBLE().ToString(clsGenel.strDoubleFormatTwo);
                    btnStok.LabelRightBottomText = btnStok.Value3.TODOUBLE().ToString(clsGenel.strDoubleFormatFour);

                    btnStok.Visible = true;
                }
                reader.Close();
                cmd.Dispose();
                cnn.Close();

                tlpStoklar.RowCount = Math.Ceiling(iStokSayisi / 5.0).TOINT();
                tlpStoklar.ColumnCount = Math.Ceiling(iStokSayisi / 8.0).TOINT();
            }

            for (int i = iStokSayisi; i < intMaxStokSayisi; i++)
            {
                MyButton btnStok = lstStokButtons["btnStok" + (i + 1).TOSTRING()];
                btnStok.Text = "";
                btnStok.Value1 = 0;
                btnStok.Value2 = "";
                btnStok.Value3 = 0;
                btnStok.Visible = false;
            }

            prcdCesnilerGetir(0);
        }

        public void prcdCesnilerGetir(int intStokNo)
        {
            int iCesniSayisi = 0;

            if (intStokNo > 0)
            {
                SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = string.Format("SELECT TOP {0} ST.*, " +
                                                "(SELECT SUM((A.Giris_Miktari - A.Cikis_Miktari) * (CASE WHEN Birim_Kodu = (CASE WHEN B.BT1_Hizli_Satis = 1 THEN B.Birim_Kodu_1 ELSE B.Birim_Kodu_2 END) THEN 1 ELSE (CASE WHEN B.BT1_Hizli_Satis = 1 THEN B.BT2_Orani ELSE B.BT1_Orani END) END)) FROM Islem_Detay_Stok AS A INNER JOIN Stok_Tanitimi AS B ON B.Silindi = 0 AND A.Kurum_Kodu = B.Kurum_Kodu AND A.Stok_No = B.Stok_No WHERE A.Silindi = 0 AND A.Kurum_Kodu = ST.Kurum_Kodu AND A.Stok_No = ST.Stok_No AND A.Isyeri_Kodu = @Isyeri_Kodu AND A.Depo_Kodu = @Depo_Kodu) AS Depo_Miktari " +
                                                "FROM Stok_Bagli_Tanitimi AS SBT " +
                                                "INNER JOIN Stok_Tanitimi AS ST ON ST.Silindi = 0 AND ST.Kurum_Kodu = SBT.Kurum_Kodu AND ST.Stok_No = SBT.Bagli_Stok_No AND ST.Stok_Tipi = 4 " +
                                                "WHERE SBT.Kurum_Kodu = @Kurum_Kodu AND SBT.Stok_No = @Stok_No " +
                                                "ORDER BY SBT.Sira_No", intMaxCesniSayisi);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", clsGenel.intGenelIsyeriKodu);
                cmd.Parameters.AddWithValue("@Depo_Kodu", clsGenel.intGenelDepoKodu);
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Stok_No", intStokNo);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    iCesniSayisi++;
                    MyButton btnCesni = lstStokButtons["btnCesni" + iCesniSayisi.TOSTRING()];
                    btnCesni.Text = reader["Kisa_Adi"].TOSTRING();
                    btnCesni.Value1 = reader["Depo_Miktari"].TODOUBLE();
                    if (reader["BT1_Hizli_Satis"].TOINT() == 1)
                    {
                        btnCesni.Value2 = reader["BT1_Barkod"].TOSTRING();
                        btnCesni.Value3 = reader["BT1_Satis_Fiyati"].TODOUBLE();
                    }
                    else if (reader["BT2_Hizli_Satis"].TOINT() == 1)
                    {
                        btnCesni.Value2 = reader["BT2_Barkod"].TOSTRING();
                        btnCesni.Value3 = reader["BT2_Satis_Fiyati"].TODOUBLE();
                    }

                    btnCesni.LabelLeftBottomText = btnCesni.Value1.TODOUBLE().ToString(clsGenel.strDoubleFormatTwo);
                    btnCesni.LabelRightBottomText = btnCesni.Value3.TODOUBLE().ToString(clsGenel.strDoubleFormatFour);

                    btnCesni.Visible = true;
                }
                reader.Close();
                cmd.Dispose();
                cnn.Close();
            }

            for (int i = iCesniSayisi; i < intMaxCesniSayisi; i++)
            {
                MyButton btnCesni = lstStokButtons["btnCesni" + (i + 1).TOSTRING()];
                btnCesni.Text = "";
                btnCesni.Value1 = 0;
                btnCesni.Value2 = "";
                btnCesni.Value3 = 0;
                btnCesni.Visible = false;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtTuslar.Clear();
            txtTuslar.Focus();
        }

        private void btnTuslar7_Click(object sender, EventArgs e)
        {
            txtTuslar.Text += ((Button)sender).Text.Trim();
            txtTuslar.Focus();
        }

        private void btnGrup1_Click(object sender, EventArgs e)
        {
            prcdStoklarGetir(((Button)sender).AccessibleDescription);
            txtTuslar.Focus();
        }

        private void dgvStoklar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dvCesniler.RowFilter = string.Format("Anahtar = '{0}'", dgvStoklar.CurrentRow.Cells["colAnahtar"].Value.TOSTRING());
                prcdCesnilerGetir(dgvStoklar.CurrentRow.Cells["colStokNo"].Value.TOINT());
            }
        }

        private void btnDaraAl_Click(object sender, EventArgs e)
        {
            txtTuslar.Focus();
        }

        private void btnAciklamaGir_Click(object sender, EventArgs e)
        {
            if (blnCesniDataGrid)
            {
                if (dgvCesniler.CurrentRow != null)
                {
                    dvCesniler[dgvCesniler.CurrentRow.Index]["Aciklama"] = Interaction.InputBox("Lütfen '" + dvCesniler[dgvCesniler.CurrentRow.Index]["Stok_Adi"] + "' isimli çeşniye bir açıklama giriniz.", "Açıklama", "");
                }
            }
            else
            {
                if (dgvStoklar.CurrentRow != null)
                {
                    dtStoklar.Rows[dgvStoklar.CurrentRow.Index]["Aciklama"] = Interaction.InputBox("Lütfen '" + dtStoklar.Rows[dgvStoklar.CurrentRow.Index]["Stok_Adi"] + "' isimli ürüne bir açıklama giriniz.", "Açıklama", "");
                }
            }
            txtTuslar.Focus();
        }

        private void btnSatiriSil_Click(object sender, EventArgs e)
        {
            if (blnCesniDataGrid)
            {
                if (dgvCesniler.CurrentRow != null)
                {
                    dvCesniler.Delete(dgvCesniler.CurrentRow.Index);
                }
            }
            else
            {
                if (dgvStoklar.CurrentRow != null)
                {
                    string strAnahtar = dgvStoklar.CurrentRow.Cells["colAnahtar"].Value.TOSTRING();
                    foreach (DataRow DR in dtCesniler.Select(string.Format("Anahtar = '{0}'", strAnahtar)))
                    {
                        dtCesniler.Rows.Remove(DR);
                    }
                    dtStoklar.Rows.RemoveAt(dgvStoklar.CurrentRow.Index);
                }
            }
            txtTuslar.Focus();
        }

        private void btnTumunuSil_Click(object sender, EventArgs e)
        {
            txtTuslar.Clear();
            dtCesniler.Rows.Clear();
            dtStoklar.Rows.Clear();
            btnGrup1.PerformClick();
            blnCesniButon = false;
            blnCesniDataGrid = false;
            txtTuslar.Focus();
        }

        private void btnOdemeAl_Click(object sender, EventArgs e)
        {
            if (dtStoklar.Rows.Count > 0)
            {
                frmOdeme foForm = new frmOdeme(dtStoklar, dtCesniler);
                if (foForm.ShowDialog() == DialogResult.OK)
                {
                    btnTumunuSil.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("Ödeme işlemi için ürün girmeniz gerekmektedir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            txtTuslar.Focus();
        }

        bool blnCesniButon = false;
        bool blnCesniDataGrid = false;

        private void dgvStoklar_Click(object sender, EventArgs e)
        {
            dgvStoklar.RowsDefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvStoklar.RowsDefaultCellStyle.SelectionForeColor = Color.Red;
            dgvCesniler.RowsDefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgvCesniler.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            blnCesniDataGrid = false;
        }

        private void dgvCesniler_Click(object sender, EventArgs e)
        {
            dgvStoklar.RowsDefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgvStoklar.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            dgvCesniler.RowsDefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvCesniler.RowsDefaultCellStyle.SelectionForeColor = Color.Red;
            blnCesniDataGrid = true;
        }

        private void btnStok1_Click(object sender, EventArgs e)
        {
            txtTuslar.Text += ((MyButton)sender).Value2.TOSTRING();
            txtTuslar_KeyDown(sender, new KeyEventArgs(Keys.Return));
            txtTuslar.Clear();
            txtTuslar.Focus();
        }

        private void btnCesni1_Click(object sender, EventArgs e)
        {
            blnCesniButon = true;
            txtTuslar.Text += ((MyButton)sender).Value2.TOSTRING();
            txtTuslar_KeyDown(sender, new KeyEventArgs(Keys.Return));
            txtTuslar.Clear();
            txtTuslar.Focus();
            blnCesniButon = false;
        }

        private void txtTuslar_KeyDown(object sender, KeyEventArgs e)
        {
            string strText = txtTuslar.Text.Trim();
            if (!string.IsNullOrEmpty(strText))
            {
                string strBarkod = "";
                double dblBarkodMiktar = 0;

                string[] arrText = strText.Split('X');
                if (arrText.Length > 1)
                {
                    dblBarkodMiktar = arrText[0].TODOUBLE();
                    strBarkod = arrText[1];
                }
                else
                {
                    dblBarkodMiktar = 1;
                    strBarkod = arrText[0];
                }

                SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT ST.*, " +
                                  "ISNULL(SBT1.Agirlik_Birimi, CAST(0 AS TINYINT)) AS BT1_Agirlik_Birimi, " +
                                  "ISNULL(SBT2.Agirlik_Birimi, CAST(0 AS TINYINT)) AS BT2_Agirlik_Birimi " +
                                  "FROM Stok_Tanitimi AS ST " +
                                  "LEFT OUTER JOIN Stok_Birim_Tanitimi AS SBT1 ON SBT1.Birim_Kodu = ST.Birim_Kodu_1 " +
                                  "LEFT OUTER JOIN Stok_Birim_Tanitimi AS SBT2 ON SBT2.Birim_Kodu = ST.Birim_Kodu_2 " +
                                  "WHERE ST.Silindi = 0 AND ST.Kurum_Kodu = @Kurum_Kodu AND (ST.BT1_Barkod = @BT1_Barkod OR ST.BT2_Barkod = @BT2_Barkod)";

                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@BT1_Barkod", strBarkod);
                cmd.Parameters.AddWithValue("@BT2_Barkod", strBarkod);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    bool blnDevam = true;
                    string strAnahtar = "";
                    int intStokNo = reader["Stok_No"].TOINT();
                    string strStokKodu = reader["Stok_Kodu"].TOSTRING();
                    string strStokAdi = reader["Kisa_Adi"].TOSTRING();
                    string strBirimKodu = "";
                    double dblMiktar = 0;
                    int intAgirlikBirimi = 0;
                    double dblFiyati = 0;
                    double dblKdvOrani = reader["Kdv_Perakende"].TODOUBLE();

                    if (reader["BT1_Barkod"].TOSTRING() == strBarkod)
                    {
                        intAgirlikBirimi = reader["BT1_Agirlik_Birimi"].TOINT();
                        dblFiyati = reader["BT1_Satis_Fiyati"].TODOUBLE();
                        strBirimKodu = reader["Birim_Kodu_1"].TOSTRING();
                    }
                    else
                    {
                        intAgirlikBirimi = reader["BT2_Agirlik_Birimi"].TOINT();
                        dblFiyati = reader["BT2_Satis_Fiyati"].TODOUBLE();
                        strBirimKodu = reader["Birim_Kodu_2"].TOSTRING();
                    }

                    if (intAgirlikBirimi == 0)
                        dblMiktar = 1;
                    else
                    {
                        dblMiktar = txtTerazi.Text.Trim().TODOUBLE();
                        if (dblMiktar == 0)
                        {
                            MessageBox.Show("Bu ürün ağırlık birimli olduğundan tartım yapmanız gerekmektedir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            blnDevam = false;
                        }
                    }
                    dblMiktar *= dblBarkodMiktar;

                    if (blnDevam)
                    {
                        DataRow DR;
                        strAnahtar = blnCesniButon ? dgvStoklar.CurrentRow.Cells["colAnahtar"].Value.TOSTRING() : DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        DR = blnCesniButon ? dtCesniler.NewRow() : dtStoklar.NewRow();
                        DR["Anahtar"] = strAnahtar;
                        DR["Stok_No"] = intStokNo;
                        DR["Stok_Kodu"] = strStokKodu;
                        DR["Birim_Kodu"] = strBirimKodu;
                        DR["Aciklama"] = "";
                        DR["Kdv_Orani"] = dblKdvOrani;
                        DR["Stok_Adi"] = strStokAdi;
                        DR["Miktari"] = dblMiktar;
                        DR["Fiyati"] = dblFiyati;
                        DR["Tutari"] = dblMiktar * dblFiyati;

                        if (blnCesniButon)
                        {
                            dtCesniler.Rows.Add(DR);
                            dgvCesniler.CurrentCell = dgvCesniler.Rows[dgvCesniler.Rows.Count - 1].Cells["colStokAdiCesni"];
                            dgvCesniler_Click(dgvCesniler, new EventArgs());
                        }
                        else
                        {
                            dtStoklar.Rows.Add(DR);
                            dgvStoklar.CurrentCell = dgvStoklar.Rows[dgvStoklar.Rows.Count - 1].Cells["colStokAdi"];
                            dgvStoklar_Click(dgvStoklar, new EventArgs());
                        }
                    }
                }
                reader.Close();
                cmd.Dispose();
                cnn.Close();

                txtTuslar.Clear();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
