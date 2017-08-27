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
    public partial class frmIsyeriKarti : Form
    {
        DataTable dtIsyerleri = new DataTable();
        public frmIsyeriKarti()
        {
            InitializeComponent();
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmIsyeriKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT Isyeri_Kodu, Isyeri_Adi FROM Isyeri_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtIsyerleri);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();

            dgvIsyerleri.DataSource = dtIsyerleri;
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            dgvIsyerleri.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (dgvIsyerleri.Rows.Count > 0)
                dgvIsyerleri.CurrentCell = dgvIsyerleri.Rows[0].Cells[colIsyeriKodu.Name];
            dtIsyerleri.AcceptChanges();

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Isyeri_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Isyeri_Tanitimi (Kurum_Kodu, Isyeri_Kodu, Isyeri_Adi) VALUES (@Kurum_Kodu, @Isyeri_Kodu, @Isyeri_Adi)";
            foreach (DataRow dr in dtIsyerleri.Rows)
            {
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", dr["Isyeri_Kodu"]);
                cmd.Parameters.AddWithValue("@Isyeri_Adi", dr["Isyeri_Adi"]);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cmd.Dispose();
            cnn.Close();
        }
    }
}
