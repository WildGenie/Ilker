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
    public partial class frmKurumKarti : Form
    {
        DataTable dtKurumlar = new DataTable();
        public frmKurumKarti()
        {
            InitializeComponent();
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmKurumKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT Kurum_Kodu, Kurum_Adi FROM Kurum_Tanitimi";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtKurumlar);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();

            dgvKurumlar.DataSource = dtKurumlar;
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            dgvKurumlar.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (dgvKurumlar.Rows.Count > 0)
                dgvKurumlar.CurrentCell = dgvKurumlar.Rows[0].Cells[colKurumKodu.Name];
            dtKurumlar.AcceptChanges();

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Kurum_Tanitimi";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Kurum_Tanitimi (Kurum_Kodu, Kurum_Adi) VALUES (@Kurum_Kodu, @Kurum_Adi)";
            foreach (DataRow dr in dtKurumlar.Rows)
            {
                cmd.Parameters.AddWithValue("@Kurum_Kodu", dr["Kurum_Kodu"]);
                cmd.Parameters.AddWithValue("@Kurum_Adi", dr["Kurum_Adi"]);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cmd.Dispose();
            cnn.Close();
        }
    }
}
