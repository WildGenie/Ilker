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
    public partial class rpStokHareket : Form
    {
        public rpStokHareket(string strFormID)
        {
            InitializeComponent();

            dtpBaslangicTarihi.Value = DateTime.Now.Date;
            dtpBitisTarihi.Value = DateTime.Now.Date;
            this.AccessibleDescription = strFormID;
            prcdRaporDosyaListesi();
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbOnizleme_Click(object sender, EventArgs e)
        {
            prcdRaporHazirla(((ToolStripButton)sender).Tag.TOBYTE());
        }

        private void prcdRaporDosyaListesi()
        {
            cbRaporAdi.Items.Clear();
            cbRaporAdi.Items.AddRange(clsGenel.fncRaporDosyaListesi(this.AccessibleDescription));
            clsGenel.prcdRaporXMLGetir(this.AccessibleDescription, cbRaporAdi);
        }

        private void prcdRaporHazirla(byte bytTip)
        {
            Dictionary<string, DataTable> dDataTables = new Dictionary<string, DataTable>();

            DataTable dtRapor = new DataTable();

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT @Fis_Tarihi_Bas AS Rapor_Baslangic_Tarihi, @Fis_Tarihi_Bit AS Rapor_Bitis_Tarihi, IDS.Fis_Tarihi, IDS.Fis_Saati, ST.Stok_Kodu, ST.Stok_Adi, ST.Birim_Kodu_1 AS Birim_Kodu, IDS.Giris_Miktari * (CASE WHEN IDS.Birim_Kodu = ST.Birim_Kodu_2 THEN ST.BT2_Orani ELSE CAST(1 AS INT) END) AS Giris_Miktari, IDS.Cikis_Miktari * (CASE WHEN IDS.Birim_Kodu = ST.Birim_Kodu_2 THEN ST.BT2_Orani ELSE CAST(1 AS INT) END) AS Cikis_Miktari, Giris_Tutari_Net, Cikis_Tutari_Net " +
                              "FROM Islem_Detay_Stok AS IDS " +
                              "INNER JOIN Stok_Tanitimi AS ST ON ST.Kurum_Kodu = IDS.Kurum_Kodu AND ST.Stok_No = IDS.Stok_No AND ST.Silindi = 0 " +
                              "WHERE IDS.Silindi = 0 AND IDS.Kurum_Kodu = @Kurum_Kodu AND IDS.Fis_Tarihi <= @Fis_Tarihi_Bit " +
                              (!txtBaslangicStokKodu.Text.ISNULLOREMPTY() ? "AND ST.Stok_Kodu >= @Stok_Kodu_Bas " : "") +
                              (!txtBitisStokKodu.Text.ISNULLOREMPTY() ? "AND ST.Stok_Kodu <= @Stok_Kodu_Bit " : "") +
                              "ORDER BY ST.Stok_Kodu, IDS.Fis_Tarihi, IDS.Fis_Saati";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Fis_Tarihi_Bas", dtpBaslangicTarihi.Value.Date);
            cmd.Parameters.AddWithValue("@Fis_Tarihi_Bit", dtpBitisTarihi.Value.ENDOFTHEDAY());
            if (!txtBaslangicStokKodu.Text.ISNULLOREMPTY())
                cmd.Parameters.AddWithValue("@Stok_Kodu_Bas", txtBaslangicStokKodu.Text.Trim());
            if (!txtBitisStokKodu.Text.ISNULLOREMPTY())
                cmd.Parameters.AddWithValue("@Stok_Kodu_Bit", txtBitisStokKodu.Text.Trim() + "Zz");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtRapor);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();


            dDataTables.Add("dtRapor", dtRapor);

            clsGenel.prcdRaporHazirla(bytTip, this.AccessibleDescription, cbRaporAdi, dDataTables);
        }

        private void btnBaslangicStokKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECStok();
            if (o != null) txtBaslangicStokKodu.Text = o.TOSTRING();
        }

        private void btnBitisStokKodu_Click(object sender, EventArgs e)
        {
            object o = clsXKod.fncSECStok();
            if (o != null) txtBitisStokKodu.Text = o.TOSTRING();
        }
    }
}
