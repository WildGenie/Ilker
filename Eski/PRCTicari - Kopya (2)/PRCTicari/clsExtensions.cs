using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PRCTicari
{
    public static class clsExtensions
    {
        public static string TOSTRING(this object o, string strDefault = "")
        {
            string strResult = strDefault.Trim();
            if (o != null && o is DBNull == false)
            {
                strResult = o.ToString().Trim();
            }
            return strResult;
        }

        public static double TODOUBLE(this object o, double dblDefault = 0)
        {
            double dblResult = dblDefault;

            if (o != null && o is DBNull == false)
                double.TryParse(o.ToString().Trim(), out dblResult);

            return dblResult;
        }

        public static decimal TODECIMAL(this object o, decimal dDefault = 0)
        {
            decimal dResult = dDefault;

            if (o != null && o is DBNull == false)
                decimal.TryParse(o.ToString().Trim(), out dResult);

            return dResult;
        }

        public static int TOINT(this object o, int intDefault = 0)
        {
            int intResult = intDefault;

            if (o != null && o is DBNull == false)
                int.TryParse(o.ToString().Trim(), out intResult);

            return intResult;
        }

        public static byte TOBYTE(this object o, byte bytDefault = 0)
        {
            byte bytResult = bytDefault;

            if (o != null && o is DBNull == false)
                byte.TryParse(o.ToString().Trim(), out bytResult);

            return bytResult;
        }

        public static bool TOBOOL(this object o, bool blnDefault = false)
        {
            bool blnResult = blnDefault;

            if (o != null && o is DBNull == false)
                bool.TryParse(o.ToString().Trim(), out blnResult);

            return blnResult;
        }

        public static DateTime TODATE(this object o)
        {
            DateTime dtResult = new DateTime(1900, 1, 1);

            if (o != null && o is DBNull == false)
                DateTime.TryParse(o.ToString().Trim(), out dtResult);

            return dtResult.Date;
        }

        public static DateTime TODATE(this object o, DateTime dtDefault)
        {
            DateTime dtResult = dtDefault;

            if (o != null && o is DBNull == false)
                DateTime.TryParse(o.ToString().Trim(), out dtResult);

            return dtResult.Date;
        }

        public static DateTime TODATETIME(this object o)
        {
            DateTime dtResult = new DateTime(1900, 1, 1);

            if (o != null && o is DBNull == false)
                DateTime.TryParse(o.ToString().Trim(), out dtResult);

            return dtResult;
        }

        public static DateTime TODATETIME(this object o, DateTime dtDefault)
        {
            DateTime dtResult = dtDefault;

            if (o != null && o is DBNull == false)
                DateTime.TryParse(o.ToString().Trim(), out dtResult);

            return dtResult;
        }

        public static DateTime TOTIME(this object o)
        {
            DateTime dtResult = new DateTime(1900, 1, 1, 0, 0, 0);

            if (o != null && o is DBNull == false)
                DateTime.TryParse(o.ToString().Trim(), out dtResult);

            dtResult = new DateTime(1900, 1, 1, dtResult.Hour, dtResult.Minute, dtResult.Second);

            return dtResult;
        }

        public static DateTime TOTIME(this object o, DateTime dtDefault)
        {
            DateTime dtResult = new DateTime(1900, 1, 1, dtDefault.Hour, dtDefault.Minute, dtDefault.Second);

            if (o != null && o is DBNull == false)
                DateTime.TryParse(o.ToString().Trim(), out dtResult);

            dtResult = new DateTime(1900, 1, 1, dtResult.Hour, dtResult.Minute, dtResult.Second);

            return dtResult;
        }

        public static void SelectedItemByCode(this ComboBox cbCombo, string strCode = "")
        {
            for (int i = 0; i < cbCombo.Items.Count; i++)
            {
                cbCombo.SelectedIndex = -1;
                string[] arrItem = cbCombo.Items[i].TOSTRING().Split('-');
                string strItem = "";
                if (arrItem.Length > 0) strItem = arrItem[0];
                if (strItem.Trim() == strCode.Trim())
                {
                    cbCombo.SelectedIndex = i;
                    break;
                }
                if (cbCombo.SelectedIndex == -1 && cbCombo.Items.Count > 0)
                    cbCombo.SelectedIndex = 0;
            }
        }

        public static string SelectedItemForCode(this ComboBox cbCombo)
        {
            string[] arrItem = cbCombo.SelectedItem.TOSTRING().Split('-');
            string strItem = "";
            if (arrItem.Length > 0) strItem = arrItem[0];
            return strItem;
        }

        public static void FocusNextControl(this Form frmForm)
        {
            if (frmForm.ActiveControl is DataGridView == false && ((frmForm.ActiveControl is TextBox && !((TextBox)frmForm.ActiveControl).Multiline) || frmForm.ActiveControl is TextBox == false))
            {
                frmForm.SelectNextControl(frmForm.ActiveControl, true, true, true, true);
            }
        }
    }
}
