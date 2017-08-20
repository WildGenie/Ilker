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
    public partial class frmHizliSatisKantin : Form
    {
        DataTable dtStoklar = new DataTable();
        DataTable dtCesniler = new DataTable();
        DataView dvCesniler;
        Dictionary<string, Button> lstGrupButtons = new Dictionary<string, Button>();
        Dictionary<string, MyButton> lstStokButtons = new Dictionary<string, MyButton>();

        int intMaxGrupSayisi = 0;
        int intMaxStokSayisi = 0;
        int intMaxCesniSayisi = 0;
        public frmHizliSatisKantin()
        {
            InitializeComponent();
            intMaxGrupSayisi = tlpGruplar.ColumnCount * tlpGruplar.RowCount;
            intMaxStokSayisi = tlpStoklar.ColumnCount * tlpStoklar.RowCount;
            intMaxCesniSayisi = tlpCesniler.ColumnCount * tlpCesniler.RowCount;
            btnTuslarNokta.Text = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            nudBakiye.TextChanged += new EventHandler(nudBakiye_TextChanged);
            nudHarcamaLimiti.TextChanged += new EventHandler(nudHarcamaLimiti_TextChanged);
            nudTutar.TextChanged += new EventHandler(nudTutar_TextChanged);
            nudKalanLimit.TextChanged += new EventHandler(nudKalanLimit_TextChanged);
            nudBakiye_TextChanged(nudBakiye, new EventArgs());
            nudHarcamaLimiti_TextChanged(nudHarcamaLimiti, new EventArgs());
            nudTutar_TextChanged(nudTutar, new EventArgs());
            nudKalanLimit_TextChanged(nudKalanLimit, new EventArgs());

            dtStoklar.Columns.Add("Anahtar", typeof(string));
            dtStoklar.Columns.Add("Stok_No", typeof(int));
            dtStoklar.Columns.Add("Stok_Kodu", typeof(string));
            dtStoklar.Columns.Add("Birim_Kodu", typeof(string));
            dtStoklar.Columns.Add("Aciklama", typeof(string));
            dtStoklar.Columns.Add("Kdv_Orani", typeof(double));
            dtStoklar.Columns.Add("Kdv_Tutari", typeof(double));
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
            dtCesniler.Columns.Add("Kdv_Tutari", typeof(double));
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
            lstGrupButtons.Add("btnGrup11", btnGrup11);
            lstGrupButtons.Add("btnGrup12", btnGrup12);
            lstGrupButtons.Add("btnGrup13", btnGrup13);
            lstGrupButtons.Add("btnGrup14", btnGrup14);
            lstGrupButtons.Add("btnGrup15", btnGrup15);

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
            lstStokButtons.Add("btnStok41", btnStok41);
            lstStokButtons.Add("btnStok42", btnStok42);
            lstStokButtons.Add("btnStok43", btnStok43);
            lstStokButtons.Add("btnStok44", btnStok44);
            lstStokButtons.Add("btnStok45", btnStok45);
            lstStokButtons.Add("btnStok46", btnStok46);
            lstStokButtons.Add("btnStok47", btnStok47);
            lstStokButtons.Add("btnStok48", btnStok48);

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

        private void frmHizliSatisKantin_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnTemizleKart.PerformClick();
            prcdAktifPasifKontrol(false);
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void prcdFocusText()
        {
            if (pnlKartBaslik.Enabled)
                txtKartKodu.Focus();
            else
                txtTuslar.Focus();
        }

        public void prcdGruplarGetir()
        {
            int iGrupSayisi = 0;

            if (intCariNo > 0)
            {
                SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = string.Format("SELECT TOP {0} * FROM Stok_Grup_Tanitimi AS SGT WHERE Kurum_Kodu = @Kurum_Kodu AND (SELECT COUNT(Kodu) FROM Cari_Yasakli_Urunler WHERE Kurum_Kodu = SGT.Kurum_Kodu AND Cari_No = @Cari_No AND Tip = 0 AND Kodu = SGT.Grup_Kodu) = 0", intMaxGrupSayisi);
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Cari_No", intCariNo);
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
            }

            for (int i = iGrupSayisi; i < intMaxGrupSayisi; i++)
            {
                Button btnGrup = lstGrupButtons["btnGrup" + (i + 1).TOSTRING()];
                btnGrup.Text = "";
                btnGrup.AccessibleDescription = "";
                btnGrup.Visible = false;
            }

            btnGrup1_Click(btnGrup1, new EventArgs());
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
                                                "WHERE ST.Silindi = 0 AND ST.Kurum_Kodu = @Kurum_Kodu AND ST.Grup_Kodu = @Grup_Kodu AND ST.Stok_Tipi IN (0, 1) AND (ST.BT1_Hizli_Satis = 1 OR ST.BT2_Hizli_Satis = 1) " +
                                                "AND (SELECT COUNT(Kodu) FROM Cari_Yasakli_Urunler WHERE Kurum_Kodu = ST.Kurum_Kodu AND Cari_No = @Cari_No AND Tip = 1 AND Kodu = CAST(ST.Stok_No AS VARCHAR)) = 0", intMaxStokSayisi);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", clsGenel.intGenelIsyeriKodu);
                cmd.Parameters.AddWithValue("@Depo_Kodu", clsGenel.intGenelDepoKodu);
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Grup_Kodu", strGrupKodu);
                cmd.Parameters.AddWithValue("@Cari_No", intCariNo);
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
                    btnStok.BackImage = clsExtensions.fncLOADIMAGE(reader["Resim"].TOBYTEARRAY());

                    btnStok.Visible = true;
                }
                reader.Close();
                cmd.Dispose();
                cnn.Close();
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
                                                "AND (SELECT COUNT(Kodu) FROM Cari_Yasakli_Urunler WHERE Kurum_Kodu = ST.Kurum_Kodu AND Cari_No = @Cari_No AND Tip = 1 AND Kodu = CAST(ST.Stok_No AS VARCHAR)) = 0 " +
                                                "ORDER BY SBT.Sira_No", intMaxCesniSayisi);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", clsGenel.intGenelIsyeriKodu);
                cmd.Parameters.AddWithValue("@Depo_Kodu", clsGenel.intGenelDepoKodu);
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Stok_No", intStokNo);
                cmd.Parameters.AddWithValue("@Cari_No", intCariNo);
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

        private void btnTemizleTuslar_Click(object sender, EventArgs e)
        {
            txtTuslar.Clear();
            prcdFocusText();
        }

        private void btnTuslar7_Click(object sender, EventArgs e)
        {
            txtTuslar.Text += ((Button)sender).Text.Trim();
            prcdFocusText();
        }

        private void btnGrup1_Click(object sender, EventArgs e)
        {
            prcdStoklarGetir(((Button)sender).AccessibleDescription);
            prcdFocusText();
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
            prcdFocusText();
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
            prcdFocusText();
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
            prcdToplamAl();
            prcdFocusText();
        }

        private void btnTumunuSil_Click(object sender, EventArgs e)
        {
            btnTemizleTuslar.PerformClick();
            dtCesniler.Rows.Clear();
            dtStoklar.Rows.Clear();
            btnGrup1.PerformClick();
            blnCesniButon = false;
            blnCesniDataGrid = false;
            prcdFocusText();
            nudTutar.Value = 0;
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

            prcdFocusText();
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
            prcdFocusText();
        }

        private void btnCesni1_Click(object sender, EventArgs e)
        {
            blnCesniButon = true;
            txtTuslar.Text += ((MyButton)sender).Value2.TOSTRING();
            txtTuslar_KeyDown(sender, new KeyEventArgs(Keys.Return));
            txtTuslar.Clear();
            prcdFocusText();
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

                    if (clsGenel.fncCariUrunYasakliMi(intCariNo, reader["Grup_Kodu"].TOSTRING(), intStokNo))
                    {
                        MessageBox.Show("Bu ürün bu müşteriye satılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        blnDevam = false;
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
                        DR["Kdv_Tutari"] = (dblMiktar * dblFiyati) - ((dblMiktar * dblFiyati) / (1 + (dblKdvOrani / 100)));
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

                        prcdToplamAl();
                    }
                }
                reader.Close();
                cmd.Dispose();
                cnn.Close();

                txtTuslar.Clear();
            }
        }

        private void prcdToplamAl()
        {
            nudTutar.Value = dtStoklar.Compute("SUM(Tutari)", "").TODECIMAL() + dtCesniler.Compute("SUM(Tutari)", "").TODECIMAL();
            nudKalanLimit.Value = nudHarcamaLimiti.Value - nudTutar.Value;
        }

        int intCariNo = 0;
        private void btnTemizleKart_Click(object sender, EventArgs e)
        {
            intCariNo = 0;
            pbResim.Image = null;
            txtKartKodu.Clear();
            txtAdi.Clear();
            txtSoyadi.Clear();
            txtSinifi.Clear();
            txtSubesi.Clear();
            txtOgrenciNo.Clear();
            nudHarcamaLimiti.Value = 0;
            nudBakiye.Value = 0;
            nudKalanLimit.Value = 0;
            btnTumunuSil.PerformClick();
            prcdGruplarGetir();
            prcdStoklarGetir("");
            prcdCesnilerGetir(0);
            prcdAktifPasifKontrol(false);
            prcdFocusText();
        }

        private void txtKartKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (!string.IsNullOrEmpty(txtKartKodu.Text.Trim()))
                {
                    SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                    cnn.Open();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Cari_Tanitimi WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Kart_Kodu = @Kart_Kodu";
                    cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                    cmd.Parameters.AddWithValue("@Kart_Kodu", txtKartKodu.Text.Trim());
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        intCariNo = reader["Cari_No"].TOINT();
                        pbResim.LOADIMAGE(reader["Resim"].TOBYTEARRAY());
                        txtAdi.Text = reader["Adi"].TOSTRING();
                        txtSoyadi.Text = reader["Soyadi"].TOSTRING();
                        txtSinifi.Text = reader["Sinifi"].TOSTRING();
                        txtSubesi.Text = reader["Subesi"].TOSTRING();
                        txtOgrenciNo.Text = reader["Ogrenci_No"].TOSTRING();
                        if (reader["Harcama_Limiti"].TODECIMAL() > 0)
                        {
                            nudHarcamaLimiti.Value = reader["Harcama_Limiti"].TODECIMAL() - clsGenel.fncMusteriGunlukBorcGetir(intCariNo).TODECIMAL();
                            nudHarcamaLimiti.AccessibleDescription = "";
                        }
                        else
                        {
                            nudHarcamaLimiti.Value = 0;
                            nudHarcamaLimiti.AccessibleDescription = "YOK";
                        }
                        nudBakiye.Value = clsGenel.fncMusteriBakiyeGetir(intCariNo).TODECIMAL();

                        prcdGruplarGetir();
                        prcdAktifPasifKontrol(true);
                        prcdFocusText();
                    }
                    reader.Close();
                    cmd.Dispose();
                    cnn.Close();
                }
            }
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            if (fncKaydet())
            {
                btnTumunuSil.PerformClick();
                btnTemizleKart.PerformClick();
            }
        }

        private bool fncKaydet()
        {
            bool blnReturn = false;

            if (nudBakiye.Value >= nudTutar.Value && (string.IsNullOrEmpty(nudHarcamaLimiti.AccessibleDescription.Trim()) && nudHarcamaLimiti.Value >= nudTutar.Value))
            {

                SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.Transaction = cnn.BeginTransaction();
                try
                {
                    int intFisTipi = (int)clsFisTipleri.FisTipleri.HizliSatis;
                    int intFisNo = clsGenel.fncYeniFisNoGetir(clsFisTipleri.FisTipleri.HizliSatis, clsGenel.intGenelIsyeriKodu, cnn, cmd);
                    string strParaBirimi = clsGenel.fncGetParameter("Para_Birimi", "TL");
                    DateTime dtFisTarihi = DateTime.Now;
                    string strAnahtar = dtFisTarihi.ToString("yyyyMMddHHmmssfff");

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
                    if (intCariNo > 0)
                    {
                        cmd.CommandText = "INSERT INTO Islem_Detay_Cari (Cari_No, Fis_Tarihi, Fis_Saati, Borc_Tutari, Borc_Tutari_Baslik, Borc_Tutari_Kart, Borc_Tutari_Sistem, Alacak_Tutari, Alacak_Tutari_Baslik, Alacak_Tutari_Kart, Alacak_Tutari_Sistem, Aciklama, Silindi, Kurum_Kodu, Fis_Tipi, Isyeri_Kodu, Fis_No, Fis_Sira, Islem_Yonu) " +
                                          "VALUES (@Cari_No, @Fis_Tarihi, @Fis_Saati, @Borc_Tutari, @Borc_Tutari_Baslik, @Borc_Tutari_Kart, @Borc_Tutari_Sistem, @Alacak_Tutari, @Alacak_Tutari_Baslik, @Alacak_Tutari_Kart, @Alacak_Tutari_Sistem, @Aciklama, @Silindi, @Kurum_Kodu, @Fis_Tipi, @Isyeri_Kodu, @Fis_No, @Fis_Sira, @Islem_Yonu)";
                        cmd.Parameters.AddWithValue("@Cari_No", intCariNo);
                        cmd.Parameters.AddWithValue("@Fis_Tarihi", dtFisTarihi.TODATE());
                        cmd.Parameters.AddWithValue("@Fis_Saati", dtFisTarihi.TOTIME());
                        cmd.Parameters.AddWithValue("@Borc_Tutari", nudTutar.Value);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Baslik", nudTutar.Value);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Kart", nudTutar.Value);
                        cmd.Parameters.AddWithValue("@Borc_Tutari_Sistem", nudTutar.Value);
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
                    }

                    List<DataRow> lstDRStok = new List<DataRow>();
                    EnumerableRowCollection<DataRow> arrDRStok = from myRow in dtStoklar.AsEnumerable() select myRow;
                    lstDRStok.AddRange(arrDRStok);
                    EnumerableRowCollection<DataRow> arrDRCesni = from myRow in dtCesniler.AsEnumerable() select myRow;
                    lstDRStok.AddRange(arrDRCesni);

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
                        cmd.Parameters.AddWithValue("@Isk_Orani_1", 0);
                        cmd.Parameters.AddWithValue("@Isk_Orani_2", 0);
                        cmd.Parameters.AddWithValue("@Isk_Orani_3", 0);
                        cmd.Parameters.AddWithValue("@Kdv_Orani", DR["Kdv_Orani"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Isk_Tutari_1", 0);
                        cmd.Parameters.AddWithValue("@Isk_Tutari_1_Baslik", 0);
                        cmd.Parameters.AddWithValue("@Isk_Tutari_1_Kart", 0);
                        cmd.Parameters.AddWithValue("@Isk_Tutari_1_Sistem", 0);
                        cmd.Parameters.AddWithValue("@Isk_Tutari_2", 0);
                        cmd.Parameters.AddWithValue("@Isk_Tutari_2_Baslik", 0);
                        cmd.Parameters.AddWithValue("@Isk_Tutari_2_Kart", 0);
                        cmd.Parameters.AddWithValue("@Isk_Tutari_2_Sistem", 0);
                        cmd.Parameters.AddWithValue("@Isk_Tutari_3", 0);
                        cmd.Parameters.AddWithValue("@Isk_Tutari_3_Baslik", 0);
                        cmd.Parameters.AddWithValue("@Isk_Tutari_3_Kart", 0);
                        cmd.Parameters.AddWithValue("@Isk_Tutari_3_Sistem", 0);
                        cmd.Parameters.AddWithValue("@Kdv_Tutari", DR["Kdv_Tutari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Kdv_Tutari_Baslik", DR["Kdv_Tutari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Kdv_Tutari_Kart", DR["Kdv_Tutari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Kdv_Tutari_Sistem", DR["Kdv_Tutari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Giris_Tutari", 0);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Baslik", 0);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Kart", 0);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Sistem", 0);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari", DR["Tutari"].TODOUBLE() - DR["Kdv_Tutari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Baslik", DR["Tutari"].TODOUBLE() - DR["Kdv_Tutari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Kart", DR["Tutari"].TODOUBLE() - DR["Kdv_Tutari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Sistem", DR["Tutari"].TODOUBLE() - DR["Kdv_Tutari"].TODOUBLE());
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Net", 0);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Net_Baslik", 0);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Net_Kart", 0);
                        cmd.Parameters.AddWithValue("@Giris_Tutari_Net_Sistem", 0);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Net", DR["Tutari"]);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Net_Baslik", DR["Tutari"]);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Net_Kart", DR["Tutari"]);
                        cmd.Parameters.AddWithValue("@Cikis_Tutari_Net_Sistem", DR["Tutari"]);
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

                    cmd.Transaction.Commit();

                    blnReturn = true;
                }
                catch (Exception ex)
                {
                    cmd.Transaction.Rollback();
                    MessageBox.Show("Satışların kayıt işleminde bir hata oluştu." + Environment.NewLine + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                if (nudBakiye.Value < nudTutar.Value)
                {
                    MessageBox.Show("Karttaki bakiye yetersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else if (string.IsNullOrEmpty(nudHarcamaLimiti.AccessibleDescription.Trim()) && nudHarcamaLimiti.Value < nudTutar.Value)
                {
                    MessageBox.Show("Günlük harcama limiti aşıldı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }

            return blnReturn;
        }

        private void prcdAktifPasifKontrol(bool blnEnabled)
        {
            pnlKartBaslik.Enabled = !blnEnabled;
            tlpStoklar.Enabled = blnEnabled;
            pnlIslemler.Enabled = blnEnabled;
            pnlGruplar.Enabled = blnEnabled;
            btnOdeme.Enabled = blnEnabled;
            btnTemizleKart.Enabled = blnEnabled;
        }

        private void nudBakiye_TextChanged(object sender, EventArgs e)
        {
            txtBakiye.Text = nudBakiye.Value.ToString(clsGenel.strDoubleFormatTwo);
        }

        private void nudHarcamaLimiti_TextChanged(object sender, EventArgs e)
        {
            txtHarcamaLimiti.Text = nudHarcamaLimiti.Value.ToString(clsGenel.strDoubleFormatTwo);
        }

        private void nudTutar_TextChanged(object sender, EventArgs e)
        {
            txtTutar.Text = nudTutar.Value.ToString(clsGenel.strDoubleFormatTwo);
        }

        private void nudKalanLimit_TextChanged(object sender, EventArgs e)
        {
            txtKalanLimit.Text = nudKalanLimit.Value.ToString(clsGenel.strDoubleFormatTwo);
        }
    }
}
