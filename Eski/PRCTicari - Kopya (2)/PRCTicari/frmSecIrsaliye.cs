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
    public partial class frmSecIrsaliye : Form
    {
        int intGetCariNo = 0;
        int intGetFaturaFisTipi = 0;
        int intGetIrsaliyeFisTipi = 0;
        int intGetFaturaIsyeriKodu = 0;
        int intGetFaturaFisNo = 0;
        DataTable dtIrsaliyeler = new DataTable();

        public List<int> lstResultFisTipi = new List<int>();
        public List<int> lstResultIsyeriKodu = new List<int>();
        public List<int> lstResultFisNo = new List<int>();
        public List<string> lstResultBelgeNo = new List<string>();
        private DialogResult drResult = DialogResult.Cancel;

        public frmSecIrsaliye(int intFisTipi, int intIsyeriKodu, int intFisNo, int intCariNo)
        {
            InitializeComponent();
            
            intGetCariNo = intCariNo;
            intGetFaturaFisTipi = intFisTipi;
            intGetIrsaliyeFisTipi = intFisTipi - 10;
            intGetFaturaIsyeriKodu = intIsyeriKodu;
            intGetFaturaFisNo = intFisNo;

            prcdCariBilgiGetir();
            cbTumSubeler_CheckedChanged(cbTumSubeler, new EventArgs());
        }

        private void cbTumSubeler_CheckedChanged(object sender, EventArgs e)
        {
            prcdIrsaliyeListesiGetir();
        }

        public void prcdCariBilgiGetir()
        {
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Cari_Tanitimi WHERE Silindi = 0 AND Cari_No = @Cari_No";
            cmd.Parameters.AddWithValue("@Cari_No", intGetCariNo);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lblCariKodu.Text = reader["Cari_Kodu"].TOSTRING();
                lblUnvani.Text = reader["Unvani"].TOSTRING();
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
        }

        public void prcdIrsaliyeListesiGetir()
        {
            if (dtIrsaliyeler.Columns.Count > 0) dtIrsaliyeler.Rows.Clear();

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT CAST(0 AS INT) AS Sec, IB.Fis_Tipi, IB.Isyeri_Kodu, IB.Fis_No, IB.Fis_Tarihi, IB.Belge_No, IB.Depo_Kodu_1, (CAST(IB.Depo_Kodu_1 AS VARCHAR) + '-' + DT.Depo_Adi) AS Depo_Adi, SUM(ABS(Giris_Tutari_Net - Cikis_Tutari_Net)) AS Tutari_Net " + 
                              "FROM Islem_Baslik AS IB " +
                              "INNER JOIN Islem_Detay_Stok AS IDS ON IB.Silindi = IDS.Silindi AND IB.Fis_Tipi = IDS.Fis_Tipi AND IB.Isyeri_Kodu = IDS.Isyeri_Kodu AND IB.Fis_No = IDS.Fis_No " +
                              "INNER JOIN Depo_Tanitimi AS DT ON IB.Depo_Kodu_1 = DT.Depo_Kodu " +
                              "WHERE IB.Silindi = 0 " +
                              "AND (SELECT COUNT(Irsaliye_Fis_No) FROM Stok_Bagli_Irsaliyeler WHERE Irsaliye_Fis_Tipi = IB.Fis_Tipi AND Irsaliye_Isyeri_Kodu = IB.Isyeri_Kodu AND Irsaliye_Fis_No = IB.Fis_No AND (Fatura_Fis_Tipi <> @Fatura_Fis_Tipi OR Fatura_Isyeri_Kodu <> @Fatura_Isyeri_Kodu OR Fatura_Fis_No <> @Fatura_Fis_No)) = 0 " +
                              "AND IB.Fis_Tipi = @Fis_Tipi " + 
                              (cbTumSubeler.Checked ? "AND IB.Isyeri_Kodu = @Isyeri_Kodu " : "") +
                              "GROUP BY IB.Fis_Tipi, IB.Isyeri_Kodu, IB.Fis_No, IB.Fis_Tarihi, IB.Belge_No, IB.Depo_Kodu_1, DT.Depo_Adi";
            cmd.Parameters.AddWithValue("@Cari_No", intGetCariNo);
            cmd.Parameters.AddWithValue("@Fatura_Fis_Tipi", intGetFaturaFisTipi);
            cmd.Parameters.AddWithValue("@Fatura_Isyeri_Kodu", intGetFaturaIsyeriKodu);
            cmd.Parameters.AddWithValue("@Fatura_Fis_No", intGetFaturaFisNo);
            cmd.Parameters.AddWithValue("@Fis_Tipi", intGetIrsaliyeFisTipi);
            if (cbTumSubeler.Checked) cmd.Parameters.AddWithValue("@Isyeri_Kodu", intGetFaturaIsyeriKodu);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtIrsaliyeler);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();

            dgvIrsaliyeler.DataSource = dtIrsaliyeler;
        }

        private void tsbTamam_Click(object sender, EventArgs e)
        {
            dgvIrsaliyeler.CommitEdit(DataGridViewDataErrorContexts.Commit);

            foreach (DataRow DR in dtIrsaliyeler.Rows)
            {
                if (DR["Sec"].TOINT() == 1)
                {
                    lstResultFisTipi.Add(DR["Fis_Tipi"].TOINT());
                    lstResultIsyeriKodu.Add(DR["Isyeri_Kodu"].TOINT());
                    lstResultFisNo.Add(DR["Fis_No"].TOINT());
                    lstResultBelgeNo.Add(DR["Belge_No"].TOSTRING());
                }
            }

            drResult = DialogResult.OK;
            Close();
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSecIrsaliye_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = drResult;
        }
    }
}
