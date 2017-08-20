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
    public partial class frmDepoKarti : Form
    {
        DataTable dtDepolar = new DataTable();
        public frmDepoKarti()
        {
            InitializeComponent();
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDepoKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT Depo_Kodu, Depo_Adi, Isyeri_Kodu FROM Depo_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtDepolar);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();

            dgvDepolar.DataSource = dtDepolar;
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            dgvDepolar.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgvDepolar.CurrentCell = dgvDepolar.Rows[dgvDepolar.NewRowIndex].Cells[colDepoKodu.Name];

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Depo_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Depo_Tanitimi (Kurum_Kodu, Depo_Kodu, Depo_Adi, Isyeri_Kodu) VALUES (@Kurum_Kodu, @Depo_Kodu, @Depo_Adi, @Isyeri_Kodu)";
            foreach (DataRow dr in dtDepolar.Rows)
            {
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Depo_Kodu", dr["Depo_Kodu"]);
                cmd.Parameters.AddWithValue("@Depo_Adi", dr["Depo_Adi"]);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", dr["Isyeri_Kodu"]);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cmd.Dispose();
            cnn.Close();
        }
    }
}
