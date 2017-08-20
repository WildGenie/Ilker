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
    public partial class frmStokGrupKarti : Form
    {
        DataTable dtGruplar = new DataTable();
        public frmStokGrupKarti()
        {
            InitializeComponent();
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmStokGrupKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Stok_Grup_Tanitimi";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtGruplar);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();

            dgvGruplar.DataSource = dtGruplar;
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            dgvGruplar.CommitEdit(DataGridViewDataErrorContexts.Commit);

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Stok_Grup_Tanitimi";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Stok_Grup_Tanitimi (Grup_Kodu, Grup_Adi) VALUES (@Grup_Kodu, @Grup_Adi)";
            foreach (DataRow dr in dtGruplar.Rows)
            {
                cmd.Parameters.AddWithValue("@Grup_Kodu", dr["Grup_Kodu"]);
                cmd.Parameters.AddWithValue("@Grup_Adi", dr["Grup_Adi"]);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cmd.Dispose();
            cnn.Close();
        }
    }
}
