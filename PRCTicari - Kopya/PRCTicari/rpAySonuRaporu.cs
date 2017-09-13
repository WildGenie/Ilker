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
    public partial class rpAySonuRaporu : Form
    {
        public rpAySonuRaporu(string strFormID)
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
            cmd.CommandText = "SELECT CAST(1 AS INT) AS Sira, '+' AS Islem_Tipi, 'SATILAN ÜRÜN' AS Aciklama, ISNULL((SELECT SUM(Cikis_Tutari_Net) FROM Islem_Detay_Stok WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Fis_Tarihi >= @Fis_Tarihi_Bas AND Fis_Tarihi <= @Fis_Tarihi_Bit), CAST(0 AS FLOAT)) AS Tutar " +
                              "UNION " +
                              "SELECT CAST(2 AS INT) AS Sira, '-' AS Islem_Tipi, 'ALINAN ÜRÜN' AS Aciklama, ISNULL((SELECT SUM(Giris_Tutari_Net) FROM Islem_Detay_Stok WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Fis_Tarihi >= @Fis_Tarihi_Bas AND Fis_Tarihi <= @Fis_Tarihi_Bit), CAST(0 AS FLOAT)) AS Tutar " +
                              "UNION " +
                              "SELECT CAST(3 AS INT) AS Sira, '-' AS Islem_Tipi, 'MASRAFLAR' AS Aciklama, ISNULL((SELECT SUM(Borc_Tutari - Alacak_Tutari) FROM Islem_Detay_Masraf WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Fis_Tarihi >= @Fis_Tarihi_Bas AND Fis_Tarihi <= @Fis_Tarihi_Bit), CAST(0 AS FLOAT)) AS Tutar " +
                              "UNION " +
                              "SELECT CAST(4 AS INT) AS Sira, '-' AS Islem_Tipi, 'PERSONEL GİDERİ' AS Aciklama, ISNULL((SELECT SUM(Maas) FROM Cari_Tanitimi WHERE Personel = 1 AND Kurum_Kodu = @Kurum_Kodu), CAST(0 AS FLOAT)) AS Tutar " +
                              "UNION " +
                              "SELECT CAST(5 AS INT) AS Sira, '-' AS Islem_Tipi, 'CARİ ÖDEMELER' AS Aciklama, ISNULL((SELECT SUM(Borc_Tutari - Alacak_Tutari) FROM Islem_Detay_Cari WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu AND Fis_Tarihi >= @Fis_Tarihi_Bas AND Fis_Tarihi <= @Fis_Tarihi_Bit), CAST(0 AS FLOAT)) AS Tutar ";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Fis_Tarihi_Bas", dtpBaslangicTarihi.Value.Date);
            cmd.Parameters.AddWithValue("@Fis_Tarihi_Bit", dtpBitisTarihi.Value.ENDOFTHEDAY());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtRapor);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();


            dDataTables.Add("dtRapor", dtRapor);

            clsGenel.prcdRaporHazirla(bytTip, this.AccessibleDescription, cbRaporAdi, dDataTables);
        }
    }
}
