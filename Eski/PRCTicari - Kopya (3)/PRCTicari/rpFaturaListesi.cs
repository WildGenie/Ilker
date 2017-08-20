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
    public partial class rpFaturaListesi : Form
    {
        public rpFaturaListesi(string strFormID)
        {
            InitializeComponent();

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

            DataTable dtFaturaListesi = new DataTable();
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT IB.Isyeri_Kodu, IB.Fis_No, " + clsFisTipleri.fncFisTipiSQL("IB.Fis_Tipi") + " AS Fis_Tipi_Aciklama, CONVERT(VARCHAR, IB.Fis_Tarihi, 104) AS Fis_Tarihi, CT.Cari_Kodu, CT.Unvani, IB.Belge_Tipi, IB.Belge_No, CONVERT(VARCHAR, IB.Belge_Tarihi, 104) AS Belge_Tarihi, ISNULL(SUM(ABS(ID.Giris_Tutari_Net)), CAST(0 AS FLOAT)) AS Giris_Tutari, ISNULL(SUM(ABS(ID.Cikis_Tutari_Net)), CAST(0 AS FLOAT)) AS Cikis_Tutari, IB.Aciklama " +
                              "FROM Islem_Baslik AS IB " +
                              "INNER JOIN Islem_Detay_Stok AS ID ON IB.Kurum_Kodu = ID.Kurum_Kodu AND IB.Fis_Tipi = ID.Fis_Tipi AND IB.Isyeri_Kodu = ID.Isyeri_Kodu AND IB.Fis_No = ID.Fis_No AND IB.Silindi = ID.Silindi " +
                              "INNER JOIN Depo_Tanitimi AS DT ON DT.Kurum_Kodu = IB.Kurum_Kodu AND DT.Depo_Kodu = IB.Depo_Kodu_1 " +
                              "LEFT OUTER JOIN Cari_Tanitimi AS CT ON CT.Kurum_Kodu = IB.Kurum_Kodu AND CT.Silindi = 0 AND CT.Cari_No = IB.Cari_No " +
                              "WHERE IB.Silindi = 0 AND IB.Kurum_Kodu = @Kurum_Kodu AND IB.Fis_Tipi IN (" + 
                              ((int)clsFisTipleri.FisTipleri.FaturaAlis).TOSTRING() + ", " +
                              ((int)clsFisTipleri.FisTipleri.FaturaSatis).TOSTRING() + ", " +
                              ((int)clsFisTipleri.FisTipleri.FaturaAlisIade).TOSTRING() + ", " +
                              ((int)clsFisTipleri.FisTipleri.FaturaSatisIade).TOSTRING() + ", " +
                              ((int)clsFisTipleri.FisTipleri.HizliSatis).TOSTRING() + ") " +
                              "GROUP BY IB.Fis_Tipi, IB.Isyeri_Kodu, IB.Fis_No, IB.Fis_Tarihi, CT.Cari_Kodu, CT.Unvani, IB.Belge_Tipi, IB.Belge_No, IB.Belge_Tarihi, IB.Aciklama";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtFaturaListesi);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();
            dDataTables.Add("dtFaturaListesi", dtFaturaListesi);

            clsGenel.prcdRaporHazirla(bytTip, this.AccessibleDescription, cbRaporAdi, dDataTables);
        }
    }
}
