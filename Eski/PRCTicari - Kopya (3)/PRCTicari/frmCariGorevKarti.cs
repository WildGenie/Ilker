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
    public partial class frmCariGorevKarti : Form
    {
        DataTable dtGorevler = new DataTable();
        public frmCariGorevKarti()
        {
            InitializeComponent();
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCariGorevKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Cari_Gorev_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtGorevler);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();

            dgvGorevler.DataSource = dtGorevler;
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            dgvGorevler.CommitEdit(DataGridViewDataErrorContexts.Commit);

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Cari_Gorev_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Cari_Gorev_Tanitimi (Kurum_Kodu, Gorev_Kodu, Gorev_Adi) VALUES (@Kurum_Kodu, @Gorev_Kodu, @Gorev_Adi)";
            foreach (DataRow dr in dtGorevler.Rows)
            {
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Gorev_Kodu", dr["Gorev_Kodu"]);
                cmd.Parameters.AddWithValue("@Gorev_Adi", dr["Gorev_Adi"]);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cmd.Dispose();
            cnn.Close();
        }
    }
}
