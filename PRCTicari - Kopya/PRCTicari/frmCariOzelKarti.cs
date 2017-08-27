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
    public partial class frmCariOzelKarti : Form
    {
        DataTable dtOzeller = new DataTable();
        public frmCariOzelKarti()
        {
            InitializeComponent();
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCariOzelKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT Ozel_Kodu, Ozel_Adi FROM Cari_Ozel_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtOzeller);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();

            dgvOzeller.DataSource = dtOzeller;
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            dgvOzeller.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (dgvOzeller.Rows.Count > 0)
                dgvOzeller.CurrentCell = dgvOzeller.Rows[0].Cells[colOzelKodu.Name];
            dtOzeller.AcceptChanges();

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Cari_Ozel_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Cari_Ozel_Tanitimi (Kurum_Kodu, Ozel_Kodu, Ozel_Adi) VALUES (@Kurum_Kodu, @Ozel_Kodu, @Ozel_Adi)";
            foreach (DataRow dr in dtOzeller.Rows)
            {
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Ozel_Kodu", dr["Ozel_Kodu"]);
                cmd.Parameters.AddWithValue("@Ozel_Adi", dr["Ozel_Adi"]);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cmd.Dispose();
            cnn.Close();
        }
    }
}
