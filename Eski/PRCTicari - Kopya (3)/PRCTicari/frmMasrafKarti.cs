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
    public partial class frmMasrafKarti : Form
    {
        DataTable dtMasraflar = new DataTable();
        public frmMasrafKarti()
        {
            InitializeComponent();
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMasrafKarti_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT Masraf_Kodu, Masraf_Adi, Islem FROM Masraf_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtMasraflar);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();

            dgvMasraflar.DataSource = dtMasraflar;
        }

        private void tsbKaydet_Click(object sender, EventArgs e)
        {
            dgvMasraflar.CommitEdit(DataGridViewDataErrorContexts.Commit);

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM Masraf_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO Masraf_Tanitimi (Kurum_Kodu, Masraf_Kodu, Masraf_Adi, Islem) VALUES (@Kurum_Kodu, @Masraf_Kodu, @Masraf_Adi, @Islem)";
            foreach (DataRow dr in dtMasraflar.Rows)
            {
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Masraf_Kodu", dr["Masraf_Kodu"]);
                cmd.Parameters.AddWithValue("@Masraf_Adi", dr["Masraf_Adi"]);
                cmd.Parameters.AddWithValue("@Islem", dr["Islem"].TOINT());
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            cmd.Dispose();
            cnn.Close();
        }

        private void dgvIsyerleri_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //
        }
    }
}
