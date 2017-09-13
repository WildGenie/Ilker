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
    public partial class rpGunSonuRaporu : Form
    {
        public rpGunSonuRaporu(string strFormID)
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
            cmd.CommandText = "SELECT SGT.Grup_Kodu, SGT.Grup_Adi, ST.Stok_Kodu, ST.Stok_Adi, SUM(Cikis_Tutari_Net) AS Cikis_Tutari " +
                              "FROM Islem_Detay_Stok AS IDS " +
                              "INNER JOIN Stok_Tanitimi AS ST ON ST.Silindi = 0 AND IDS.Kurum_Kodu = ST.Kurum_Kodu AND IDS.Stok_No = ST.Stok_No " +
                              "INNER JOIN Stok_Grup_Tanitimi AS SGT ON IDS.Kurum_Kodu = SGT.Kurum_Kodu AND ST.Grup_Kodu = SGT.Grup_Kodu " +
                              "WHERE IDS.Silindi = 0 AND IDS.Kurum_Kodu = @Kurum_Kodu AND IDS.Fis_Tarihi >= @Fis_Tarihi_Bas AND IDS.Fis_Tarihi <= @Fis_Tarihi_Bit " +
                              "GROUP BY SGT.Grup_Kodu, SGT.Grup_Adi, ST.Stok_Kodu, ST.Stok_Adi " +
                              "ORDER BY SGT.Grup_Adi, ST.Stok_Adi";
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
