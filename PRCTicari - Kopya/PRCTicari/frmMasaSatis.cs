using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PRCTicari
{
    public partial class frmMasaSatis : Form
    {
        public frmMasaSatis()
        {
            InitializeComponent();
        }

        private void prcdSalonListesiGetir()
        {
            for (int i = pnlSalon.Controls.Count - 1; i >= 0; i--)
            {
                if (pnlSalon.Controls[i] is Button)
                    pnlSalon.Controls[i].Dispose();
            }

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Salon_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu AND Isyeri_Kodu = @Isyeri_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Isyeri_Kodu", clsGenel.intGenelIsyeriKodu);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Button btnSalon = new Button();
                btnSalon.AccessibleDescription = reader["Salon_Kodu"].TOSTRING();
                btnSalon.Text = reader["Salon_Adi"].TOSTRING();
                btnSalon.Cursor = Cursors.Hand;
                btnSalon.Dock = DockStyle.Top;
                btnSalon.Height = 40;
                btnSalon.BackColor = Color.Silver;
                btnSalon.Parent = pnlSalon;
                btnSalon.BringToFront();
                btnSalon.Click += btnSalon_Click;
                if (pnlSalon.Controls.Count == 1)
                    btnSalon.PerformClick();
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
        }

        Button btnSeciliSalon = null;
        Button btnSeciliMasa = null;
        private void btnSalon_Click(object sender, EventArgs e)
        {
            pnlMasaIslem.Visible = false;
            btnSeciliMasa = null;
            btnSeciliSalon = ((Button)sender);

            for (int i = pnlMasa.Controls.Count - 1; i >= 0; i--)
            {
                if (pnlMasa.Controls[i] is MyButton)
                    pnlMasa.Controls[i].Dispose();
            }

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Masa_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu AND Isyeri_Kodu = @Isyeri_Kodu AND Salon_Kodu = @Salon_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
            cmd.Parameters.AddWithValue("@Isyeri_Kodu", clsGenel.intGenelIsyeriKodu);
            cmd.Parameters.AddWithValue("@Salon_Kodu", btnSeciliSalon.AccessibleDescription);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MyButton btnMasa = new MyButton();
                btnMasa.AccessibleDescription = reader["Salon_Kodu"].TOSTRING();
                btnMasa.Text = reader["Masa_Kodu"].TOSTRING();
                btnMasa.Cursor = Cursors.Hand;
                btnMasa.Width = 100;
                btnMasa.Height = 100;
                btnMasa.Left = reader["Lokasyon_X"].TOINT();
                btnMasa.Top = reader["Lokasyon_Y"].TOINT();
                btnMasa.Font = new Font(btnMasa.Font.Name, btnMasa.Font.Size, FontStyle.Bold);
                btnMasa.BackColor = Color.Silver;
                btnMasa.Parent = pnlMasa;
                btnMasa.BringToFront();
                btnMasa.Click += btnMasa_Click;
                btnMasa.MouseDown += btnMasa_MouseDown;
                btnMasa.MouseMove += btnMasa_MouseMove;
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
        }

        bool blnDuzenlemeModu = false;
        private void btnMasa_Click(object sender, EventArgs e)
        {
            if (!blnDuzenlemeModu)
            {
                btnSeciliMasa = ((MyButton)sender);pnlMasaIslem.Visible = true;
            }
        }

        private Point MouseDownLocation;
        private void btnMasa_MouseDown(object sender, MouseEventArgs e)
        {
            if (blnDuzenlemeModu)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    MouseDownLocation = e.Location;
                }
            }

        }

        private void btnMasa_MouseMove(object sender, MouseEventArgs e)
        {
            if (blnDuzenlemeModu)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    ((MyButton)sender).Left = e.X + ((MyButton)sender).Left - MouseDownLocation.X;
                    ((MyButton)sender).Top = e.Y + ((MyButton)sender).Top - MouseDownLocation.Y;
                }
            }
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbDuzenle_Click(object sender, EventArgs e)
        {
            blnDuzenlemeModu = !blnDuzenlemeModu;
            tsbDuzenle.Text = blnDuzenlemeModu ? "Kilitle" : "Düzenle";
            if (!blnDuzenlemeModu)
            {
                SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "UPDATE Masa_Tanitimi SET Lokasyon_X = @Lokasyon_X, Lokasyon_Y = @Lokasyon_Y WHERE Kurum_Kodu = @Kurum_Kodu AND Isyeri_Kodu = @Isyeri_Kodu AND Salon_Kodu = @Salon_Kodu AND Masa_Kodu = @Masa_Kodu";
                for (int i = pnlMasa.Controls.Count - 1; i >= 0; i--)
                {
                    if (pnlMasa.Controls[i] is MyButton)
                    {
                        MyButton btnMasa = (MyButton)pnlMasa.Controls[i];
                        cmd.Parameters.AddWithValue("@Lokasyon_X", btnMasa.Left);
                        cmd.Parameters.AddWithValue("@Lokasyon_Y", btnMasa.Top);
                        cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                        cmd.Parameters.AddWithValue("@Isyeri_Kodu", clsGenel.intGenelIsyeriKodu);
                        cmd.Parameters.AddWithValue("@Salon_Kodu", btnMasa.AccessibleDescription);
                        cmd.Parameters.AddWithValue("@Masa_Kodu", btnMasa.Text);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
                cmd.Dispose();
                cnn.Close();
            }
        }

        private void tsbMasaEkle_Click(object sender, EventArgs e)
        {
            txtMasaKodu.Clear();
            pnlMasaEkle.Visible = !pnlMasaEkle.Visible;
        }

        private void btnMasaEkleTamam_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMasaKodu.Text.Trim()))
            {
                SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(Masa_Kodu) AS Sayi FROM Masa_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu AND Isyeri_Kodu = @Isyeri_Kodu AND Salon_Kodu = @Salon_Kodu AND Masa_Kodu = @Masa_Kodu";
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", clsGenel.intGenelIsyeriKodu);
                cmd.Parameters.AddWithValue("@Salon_Kodu", btnSeciliSalon.AccessibleDescription);
                cmd.Parameters.AddWithValue("@Masa_Kodu", txtMasaKodu.Text.Trim());
                int intSayi = cmd.ExecuteScalar().TOINT();
                cmd.Parameters.Clear();
                if (intSayi == 0)
                {
                    cmd.CommandText = "INSERT INTO Masa_Tanitimi  (Kurum_Kodu, Isyeri_Kodu, Salon_Kodu, Masa_Kodu, Lokasyon_X, Lokasyon_Y) VALUES (@Kurum_Kodu, @Isyeri_Kodu, @Salon_Kodu, @Masa_Kodu, @Lokasyon_X, @Lokasyon_Y)";
                    cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                    cmd.Parameters.AddWithValue("@Isyeri_Kodu", clsGenel.intGenelIsyeriKodu);
                    cmd.Parameters.AddWithValue("@Salon_Kodu", btnSeciliSalon.AccessibleDescription);
                    cmd.Parameters.AddWithValue("@Masa_Kodu", txtMasaKodu.Text.Trim());
                    cmd.Parameters.AddWithValue("@Lokasyon_X", (pnlMasa.Width / 2).TOINT());
                    cmd.Parameters.AddWithValue("@Lokasyon_Y", (pnlMasa.Height / 2).TOINT());
                    cmd.ExecuteNonQuery();
                    btnSeciliSalon.PerformClick();

                    pnlMasaEkle.Visible = false;
                }
                else
                {
                    MessageBox.Show("Bu masa kodu kullanılmaktadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

                cmd.Dispose();
                cnn.Close();
            }
            else
            {
                MessageBox.Show("Lütfen masa kodu giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void frmMasaSatis_Shown(object sender, EventArgs e)
        {
            pnlMasaIslem.Visible = false;
            tsbMasaEkle.PerformClick();
            prcdSalonListesiGetir();
        }

        private void btnMasaSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu masayı silmek istediğinize emin misiniz?", "Masa Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "DELETE FROM Masa_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu AND Isyeri_Kodu = @Isyeri_Kodu AND Salon_Kodu = @Salon_Kodu AND Masa_Kodu = @Masa_Kodu";
                cmd.Parameters.AddWithValue("@Kurum_Kodu", clsGenel.strKurumKodu);
                cmd.Parameters.AddWithValue("@Isyeri_Kodu", clsGenel.intGenelIsyeriKodu);
                cmd.Parameters.AddWithValue("@Salon_Kodu", btnSeciliSalon.AccessibleDescription);
                cmd.Parameters.AddWithValue("@Masa_Kodu", btnSeciliMasa.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();

                btnSeciliSalon.PerformClick();
            }
        }
    }
}
