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
    public partial class frmStokReyonKarti : Form
    {
        DataTable dtReyonlar = new DataTable();
        public frmStokReyonKarti()
        {
            InitializeComponent();
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmStokReyonKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT Reyon_Kodu, Reyon_Adi FROM Stok_Reyon_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtReyonlar);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();

            dgvReyonlar.DataSource = dtReyonlar;
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            dgvReyonlar.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgvReyonlar.CurrentCell = dgvReyonlar.Rows[dgvReyonlar.NewRowIndex].Cells[colReyonKodu.Name];

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Stok_Reyon_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Stok_Reyon_Tanitimi (Kurum_Kodu, Reyon_Kodu, Reyon_Adi) VALUES (@Kurum_Kodu, @Reyon_Kodu, @Reyon_Adi)";
            foreach (DataRow dr in dtReyonlar.Rows)
            {
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Reyon_Kodu", dr["Reyon_Kodu"]);
                cmd.Parameters.AddWithValue("@Reyon_Adi", dr["Reyon_Adi"]);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cmd.Dispose();
            cnn.Close();
        }
    }
}
