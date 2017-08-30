using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using FastReport;
using System.Data;
using System.Xml;
using System.Xml.Linq;

namespace PRCTicari
{
    public static class clsGenel
    {
        public static string strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public static int intGenelIsyeriKodu = ConfigurationManager.AppSettings["IsyeriKodu"].TOINT();
        public static int intGenelDepoKodu = ConfigurationManager.AppSettings["DepoKodu"].TOINT();
        public static string strKurumKodu = "ADANA01";
        public static string strKullaniciKodu = "SEFA";
        public static object oXKodSelected = null;
        public static string strDoubleFormatTwo = "#,##0.00;-#,##0.00;#.#";
        public static string strDoubleFormatFour = "#,##0.0000;-#,##0.0000;#.#";
        public static string strRaporPath = fncGetExePath() + @"\Raporlar";

        private static Dictionary<string, string> arrParametreler = new Dictionary<string, string>();

        public static int fncYeniFisNoGetir(clsFisTipleri.FisTipleri cftFisTipi, int intIsyeriKodu, SqlConnection scCnn = null, SqlCommand scCmd = null)
        {
            SqlConnection cnn = scCnn != null ? scCnn : new SqlConnection(clsGenel.strConnectionString);
            if (scCnn == null) cnn.Open();
            SqlCommand cmd = scCmd != null ? scCmd : cnn.CreateCommand();
            cmd.CommandText = "SELECT ISNULL(MAX(Fis_No), CAST(0 AS INT)) + 1 AS Fis_No FROM Islem_Baslik WHERE Kurum_Kodu = @Kurum_Kodu AND Fis_Tipi = @Fis_Tipi AND Isyeri_Kodu = @Isyeri_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", strKurumKodu);
            cmd.Parameters.AddWithValue("@Fis_Tipi", (int)cftFisTipi);
            cmd.Parameters.AddWithValue("@Isyeri_Kodu", intIsyeriKodu);
            int intYeniFisNo = cmd.ExecuteScalar().TOINT(0);
            if (scCnn == null)
            {
                cmd.Dispose();
                cnn.Close();
            }
            else
            {
                cmd.Parameters.Clear();
            }

            return intYeniFisNo;
        }

        public static double fncMusteriGunlukBorcGetir(int intCariNo)
        {
            double dblReturn = 0;
            SqlConnection cnn = new SqlConnection(strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT ISNULL(SUM(Borc_Tutari), CAST(0 AS FLOAT)) AS Borc_Tutari FROM Islem_Detay_Cari WHERE Kurum_Kodu = @Kurum_Kodu AND Cari_No = @Cari_No AND Fis_Tarihi >= @Fis_Tarihi_Bas AND Fis_Tarihi <= @Fis_Tarihi_Bit";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", strKurumKodu);
            cmd.Parameters.AddWithValue("@Cari_No", intCariNo);
            cmd.Parameters.AddWithValue("@Fis_Tarihi_Bas", DateTime.Now.TODATE());
            cmd.Parameters.AddWithValue("@Fis_Tarihi_Bit", DateTime.Now);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dblReturn = reader["Borc_Tutari"].TODOUBLE();
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
            return dblReturn;
        }

        public static double fncMusteriBakiyeGetir(int intCariNo)
        {
            double dblReturn = 0;
            SqlConnection cnn = new SqlConnection(strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT ISNULL(SUM(Alacak_Tutari - Borc_Tutari), CAST(0 AS FLOAT)) AS Bakiye FROM Islem_Detay_Cari WHERE Kurum_Kodu = @Kurum_Kodu AND Cari_No = @Cari_No";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", strKurumKodu);
            cmd.Parameters.AddWithValue("@Cari_No", intCariNo);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dblReturn = reader["Bakiye"].TODOUBLE();
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
            return dblReturn;
        }

        public static bool fncCariUrunYasakliMi(int intCariNo, string strGrupKodu = "", int intStokNo = 0)
        {
            bool blnReturn = false;
            SqlConnection cnn = new SqlConnection(strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(Kodu) AS Sayi FROM Cari_Yasakli_Urunler WHERE Kurum_Kodu = @Kurum_Kodu AND Cari_No = @Cari_No AND ((Tip = 0 AND Kodu = @Grup_Kodu) OR (Tip = 1 AND Kodu = @Stok_No))";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", strKurumKodu);
            cmd.Parameters.AddWithValue("@Cari_No", intCariNo);
            cmd.Parameters.AddWithValue("@Grup_Kodu", strGrupKodu);
            cmd.Parameters.AddWithValue("@Stok_No", intStokNo.TOSTRING());
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["Sayi"].TOINT() > 0) blnReturn = true;
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
            return blnReturn;
        }

        public static void prcdGetParameters()
        {
            arrParametreler.Clear();
            SqlConnection cnn = new SqlConnection(strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Parametreler WHERE Kurum_Kodu = @Kurum_Kodu";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", strKurumKodu);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                arrParametreler.Add(reader["Kodu"].TOSTRING(), reader["Degeri"].TOSTRING());
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
        }

        public static string fncGetParameter(string strKodu, string strDefault = "")
        {
            string strDeger = strDefault;
            if (arrParametreler.ContainsKey(strKodu))
            {
                strDeger = arrParametreler[strKodu];
            }
            return strDeger;
        }

        public static void prcdFillComboBox(string strTableName, string strCodeField, string strNameField, ComboBox[] arrCombo, bool blnEmptyItem = false,
                                           string strCriter1 = "", string strCriterEquality1 = "", object oCriterValue1 = null,
                                           string strCriter2 = "", string strCriterEquality2 = "", object oCriterValue2 = null,
                                           string strCriter3 = "", string strCriterEquality3 = "", object oCriterValue3 = null,
                                           string strCriter4 = "", string strCriterEquality4 = "", object oCriterValue4 = null,
                                           string strCriter5 = "", string strCriterEquality5 = "", object oCriterValue5 = null)
        {
            foreach (ComboBox cbCombo in arrCombo)
            {
                cbCombo.Items.Clear();
                if (blnEmptyItem) cbCombo.Items.Add("");
            }

            string strFields = strCodeField + (!string.IsNullOrEmpty(strNameField.Trim()) ? ", " + strNameField.Trim() : "");

            SqlConnection cnn = new SqlConnection(strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT " + strFields.Trim() + " FROM " + strTableName.Trim() + " WHERE Kurum_Kodu = @Kurum_Kodu ";
            cmd.Parameters.AddWithValue("@Kurum_Kodu", strKurumKodu);
            if (!string.IsNullOrEmpty(strCriter1.Trim()))
            {
                cmd.CommandText += "AND " + strCriter1 + " " + strCriterEquality1 + " @" + strCriter1;
                cmd.Parameters.AddWithValue("@" + strCriter1, oCriterValue1);
            }
            if (!string.IsNullOrEmpty(strCriter2.Trim()))
            {
                cmd.CommandText += "AND " + strCriter2 + " " + strCriterEquality2 + " @" + strCriter2;
                cmd.Parameters.AddWithValue("@" + strCriter2, oCriterValue2);
            }
            if (!string.IsNullOrEmpty(strCriter3.Trim()))
            {
                cmd.CommandText += "AND " + strCriter3 + " " + strCriterEquality3 + " @" + strCriter3;
                cmd.Parameters.AddWithValue("@" + strCriter3, oCriterValue3);
            }
            if (!string.IsNullOrEmpty(strCriter4.Trim()))
            {
                cmd.CommandText += "AND " + strCriter4 + " " + strCriterEquality4 + " @" + strCriter4;
                cmd.Parameters.AddWithValue("@" + strCriter4, oCriterValue4);
            }
            if (!string.IsNullOrEmpty(strCriter5.Trim()))
            {
                cmd.CommandText += "AND " + strCriter5 + " " + strCriterEquality5 + " @" + strCriter5;
                cmd.Parameters.AddWithValue("@" + strCriter5, oCriterValue5);
            }
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                foreach (ComboBox cbCombo in arrCombo)
                {
                    cbCombo.Items.Add(reader[strCodeField] + (!string.IsNullOrEmpty(strNameField.Trim()) ? "-" + reader[strNameField].TOSTRING() : ""));
                    cbCombo.SelectedIndex = 0;
                }
            }
            reader.Close();
            cmd.Dispose();
            cnn.Close();
        }

        public static DateTime fncMinDateTime()
        {
            return new DateTime(1900, 1, 1, 0, 0, 0, 0);
        }

        public static void DirectoryControl(string strPath)
        {
            string[] arrSplit = strPath.Split('\\');
            string strPathConfig = "";
            for (int i = 0; i < arrSplit.Length; i++)
            {
                strPathConfig += arrSplit[i] + "\\";
                if (!Directory.Exists(strPathConfig))
                {
                    Directory.CreateDirectory(strPathConfig);
                }
            }
        }

        public static string fncGetExePath()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace(@"file:\", "");
        }

        public static string[] fncRaporDosyaListesi(string strFormID)
        {
            string strPath = strRaporPath + @"\" + strFormID;
            DirectoryControl(strPath);
            DirectoryInfo DI = new DirectoryInfo(strPath);
            IEnumerable<string> lstRaporDosya = from cust in DI.GetFiles() select cust.Name;
            return lstRaporDosya.ToArray();
        }

        public static void prcdRaporHazirla(byte bytTip, string strFormID, ComboBox cbRaporAdi, Dictionary<string, DataTable> dDataTables)
        {
            string strPath = strRaporPath + @"\" + strFormID;
            DirectoryControl(strPath);

            Report rReport = new Report();

            if (!string.IsNullOrEmpty(cbRaporAdi.Text.Trim()))
                rReport.Load(strPath + @"\" + cbRaporAdi.Text.Trim());

            rReport.Dictionary.Connections.Clear();

            foreach (string strDTKey in dDataTables.Keys)
                rReport.RegisterData(dDataTables[strDTKey], strDTKey);

            prcdRaporXMLKayit(strFormID, cbRaporAdi.Text.Trim());

            if (bytTip == 0)
                rReport.Show();
            else if (bytTip == 1)
                rReport.Print();
            else if (bytTip == 2)
            {
                rReport.Design(true);

                cbRaporAdi.Items.Clear();
                cbRaporAdi.Items.AddRange(fncRaporDosyaListesi(strFormID));
            }

            prcdRaporXMLGetir(strFormID, cbRaporAdi);
        }

        public static void prcdRaporXMLKayit(string strFormID, string strRaporAdi)
        {
            XDocument xdXml = null;
            if (File.Exists(strRaporPath + @"\Raporlar.xml"))
            {
                xdXml = XDocument.Load(strRaporPath + @"\Raporlar.xml");
                XElement xeRaporlar = xdXml.Element("Raporlar");

                XElement xeFormID = xeRaporlar.Element("Rapor_" + strFormID);
                if (xeFormID != null)
                    xeFormID.Value = strRaporAdi;
                else
                {
                    xeFormID = new XElement("Rapor_" + strFormID, strRaporAdi);
                    xeRaporlar.Add(xeFormID);
                }
            }
            else
            {
                xdXml = new XDocument(
                    new XElement("Raporlar",
                        new XElement("Rapor_" + strFormID, strRaporAdi)
                    )
                );
            }

            xdXml.Save(strRaporPath + @"\Raporlar.xml");
        }

        public static void prcdRaporXMLGetir(string strFormID, ComboBox cbRaporAdi)
        {
            if (File.Exists(strRaporPath + @"\Raporlar.xml"))
            {
                XDocument xdXml = XDocument.Load(strRaporPath + @"\Raporlar.xml");
                XElement xeRaporlar = xdXml.Element("Raporlar");
                if (xeRaporlar != null)
                {
                    XElement xeFormID = xeRaporlar.Element("Rapor_" + strFormID);
                    if (xeFormID != null)
                        cbRaporAdi.SelectedItem = xeFormID.Value;
                }
            }
        }

        public static string fncBarkodKontrol(int intStokNo, string strBarkod)
        {
            string strReturn = "";

            if (!string.IsNullOrWhiteSpace(strBarkod.Trim()))
            {
                SqlConnection cnn = new SqlConnection(strConnectionString);
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT Stok_Kodu + ' - ' + Stok_Adi AS Bilgi FROM Stok_Tanitimi WHERE Kurum_Kodu = @Kurum_Kodu AND Stok_No <> @Stok_No AND (BT1_Barkod = @BT1_Barkod OR BT2_Barkod = @BT2_Barkod)";
                cmd.Parameters.AddWithValue("@Kurum_Kodu", strKurumKodu);
                cmd.Parameters.AddWithValue("@Stok_No", intStokNo);
                cmd.Parameters.AddWithValue("@BT1_Barkod", strBarkod);
                cmd.Parameters.AddWithValue("@BT2_Barkod", strBarkod);
                strReturn = cmd.ExecuteScalar().TOSTRING();
                cmd.Dispose();
                cnn.Close();
            }

            return strReturn;
        }
    }
}
