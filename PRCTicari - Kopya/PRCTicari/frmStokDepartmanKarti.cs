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
    public partial class frmStokDepartmanKarti : Form
    {
        DataTable dtDepartmanlar = new DataTable();
        public frmStokDepartmanKarti()
        {
            InitializeComponent();
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmStokDepartmanKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT Departman_Kodu, Departman_Adi FROM Stok_Departman_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtDepartmanlar);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();

            dgvDepartmanlar.DataSource = dtDepartmanlar;
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            dgvDepartmanlar.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (dgvDepartmanlar.Rows.Count > 0)
                dgvDepartmanlar.CurrentCell = dgvDepartmanlar.Rows[0].Cells[colDepartmanKodu.Name];
            dtDepartmanlar.AcceptChanges();

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Stok_Departman_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Stok_Departman_Tanitimi (Kurum_Kodu, Departman_Kodu, Departman_Adi) VALUES (@Kurum_Kodu, @Departman_Kodu, @Departman_Adi)";
            foreach (DataRow dr in dtDepartmanlar.Rows)
            {
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Departman_Kodu", dr["Departman_Kodu"]);
                cmd.Parameters.AddWithValue("@Departman_Adi", dr["Departman_Adi"]);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cmd.Dispose();
            cnn.Close();
        }
    }
}
