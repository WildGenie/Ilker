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
            cmd.CommandText = "SELECT * FROM Isyeri_Tanitimi";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtIsyerleri);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();

            dgvIsyerleri.DataSource = dtIsyerleri;
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Isyeri_Tanitimi";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Isyeri_Tanitimi (Isyeri_Kodu, Isyeri_Adi) VALUES (@Isyeri_Kodu, @Isyeri_Adi)";
            foreach (DataRow dr in dtIsyerleri.Rows)
            {
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
