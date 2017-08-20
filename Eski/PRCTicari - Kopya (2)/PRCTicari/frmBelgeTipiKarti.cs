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
    public partial class frmBelgeTipiKarti : Form
    {
        DataTable dtBelgeTipleri = new DataTable();
        public frmBelgeTipiKarti()
        {
            InitializeComponent();
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBelgeTipiKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Belge_Tipi_Tanitimi";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtBelgeTipleri);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();

            dgvBelgeTipleri.DataSource = dtBelgeTipleri;
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            dgvBelgeTipleri.CommitEdit(DataGridViewDataErrorContexts.Commit);

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Belge_Tipi_Tanitimi";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Belge_Tipi_Tanitimi (Belge_Tipi) VALUES (@Belge_Tipi)";
            foreach (DataRow dr in dtBelgeTipleri.Rows)
            {
                cmd.Parameters.AddWithValue("@Belge_Tipi", dr["Belge_Tipi"]);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cmd.Dispose();
            cnn.Close();
        }
    }
}
