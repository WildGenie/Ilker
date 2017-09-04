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
            cmd.CommandText = "SELECT Grup_Kodu, Grup_Adi, Hizli_Satis FROM Stok_Grup_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
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
            if (dgvGruplar.Rows.Count > 0)
                dgvGruplar.CurrentCell = dgvGruplar.Rows[0].Cells[colGrupKodu.Name];
            dtGruplar.AcceptChanges();

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Stok_Grup_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Stok_Grup_Tanitimi (Kurum_Kodu, Grup_Kodu, Grup_Adi, Hizli_Satis) VALUES (@Kurum_Kodu, @Grup_Kodu, @Grup_Adi, @Hizli_Satis)";
            foreach (DataRow dr in dtGruplar.Rows)
            {
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Grup_Kodu", dr["Grup_Kodu"]);
                cmd.Parameters.AddWithValue("@Grup_Adi", dr["Grup_Adi"]);
                cmd.Parameters.AddWithValue("@Hizli_Satis", dr["Hizli_Satis"]);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cmd.Dispose();
            cnn.Close();
        }
    }
}
