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
    public partial class rpCariListesi : Form
    {
        public rpCariListesi(string strFormID)
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

            DataTable dtRapor = new DataTable();
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Cari_Tanitimi WHERE Silindi = 0 AND Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
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
