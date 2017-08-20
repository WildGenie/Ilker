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
            cmd.CommandText = "SELECT * FROM Para_Birimi_Tanitimi";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtParaBirimleri);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();

            dgvParaBirimleri.DataSource = dtParaBirimleri;
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Para_Birimi_Tanitimi";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Para_Birimi_Tanitimi (Para_Birimi) VALUES (@Para_Birimi)";
            foreach (DataRow dr in dtParaBirimleri.Rows)
            {
                cmd.Parameters.AddWithValue("@Para_Birimi", dr["Para_Birimi"]);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cmd.Dispose();
            cnn.Close();
        }
    }
}
