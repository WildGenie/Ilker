using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PRCTicari
{
    public static class clsGenel
    {
        public static string strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public static string strKullaniciKodu = "SEFA";
        public static object oXKodSelected = null;
        public static string strDoubleFormatTwo = "#,##0.00;-#,##0.00;#.#";
        public static string strDoubleFormatFour = "#,##0.0000;-#,##0.0000;#.#";

        private static Dictionary<string, string> arrParametreler = new Dictionary<string, string>();

        public static void prcdGetParameters()
        {
            arrParametreler.Clear();
            SqlConnection cnn = new SqlConnection(strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Parametreler";
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
            cmd.CommandText = "SELECT " + strFields.Trim() + " FROM " + strTableName.Trim() + " WHERE 1 = 1 ";
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
    }
}
