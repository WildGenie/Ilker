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
    public partial class frmStokBirimKarti : Form
    {
        DataTable dtBirimler = new DataTable();
        public frmStokBirimKarti()
        {
            InitializeComponent();
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmStokBirimKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Stok_Birim_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtBirimler);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();

            dgvBirimler.DataSource = dtBirimler;
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            dgvBirimler.CommitEdit(DataGridViewDataErrorContexts.Commit);

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Stok_Birim_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Stok_Birim_Tanitimi (Kurum_Kodu, Birim_Kodu, Birim_Adi, Agirlik_Birimi) VALUES (@Kurum_Kodu, @Birim_Kodu, @Birim_Adi, @Agirlik_Birimi)";
            foreach (DataRow dr in dtBirimler.Rows)
            {
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Birim_Kodu", dr["Birim_Kodu"]);
                cmd.Parameters.AddWithValue("@Birim_Adi", dr["Birim_Adi"]);
                cmd.Parameters.AddWithValue("@Agirlik_Birimi", dr["Agirlik_Birimi"].TOINT());
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cmd.Dispose();
            cnn.Close();
        }

        private void dgvBirimler_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //
        }
    }
}
