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
    public partial class frmParaBirimiKarti : Form
    {
        DataTable dtParaBirimleri = new DataTable();
        public frmParaBirimiKarti()
        {
            InitializeComponent();
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmParaBirimiKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT Para_Birimi FROM Para_Birimi_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtParaBirimleri);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();

            dgvParaBirimleri.DataSource = dtParaBirimleri;
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            dgvParaBirimleri.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (dgvParaBirimleri.Rows.Count > 0)
                dgvParaBirimleri.CurrentCell = dgvParaBirimleri.Rows[0].Cells[colParaBirimi.Name];
            dtParaBirimleri.AcceptChanges();

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Para_Birimi_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Para_Birimi_Tanitimi (Kurum_Kodu, Para_Birimi) VALUES (@Kurum_Kodu, @Para_Birimi)";
            foreach (DataRow dr in dtParaBirimleri.Rows)
            {
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Para_Birimi", dr["Para_Birimi"]);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cmd.Dispose();
            cnn.Close();
        }
    }
}
