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
    public partial class frmXKod : Form
    {
        public object oXKodSelected = null;

        private string strGetSQL = "";
        private string[] arrGetParamNames = null;
        private object[] arrGetParamValues = null;
        private string[] arrGetFields = null;
        private string[] arrGetFieldTitles = null;
        private int[] arrGetFieldWidths = null;
        private int intGetDefaultCriterIndex = 0;
        private int intGetReturnFieldIndex = 0;
        private DataTable dtXKod = new DataTable();
        private DialogResult drResult = DialogResult.Cancel;
        private bool blnFormat = false;
         
        public frmXKod(string strFormText, string strSQL, string[] arrParamNames, object[] arrParamValues, string[] arrFields, string[] arrFieldTitles, int[] arrFieldWidths, int intDefaultCriterIndex, int intReturnFieldIndex)
        {
            InitializeComponent();

            this.Text = strFormText;

            strGetSQL = strSQL;
            arrGetParamNames = arrParamNames;
            arrGetParamValues = arrParamValues;
            arrGetFields = arrFields;
            arrGetFieldTitles = arrFieldTitles;
            arrGetFieldWidths = arrFieldWidths;
            intGetDefaultCriterIndex = intDefaultCriterIndex;
            intGetReturnFieldIndex = intReturnFieldIndex;

            int intFormWidth = 0;
            for (int i = 0; i < arrGetFields.Length; i++)
            {
                DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn();
                dgvc.Name = "col" + arrGetFields[i];
                dgvc.DataPropertyName = arrGetFields[i];
                dgvc.HeaderText = arrGetFieldTitles[i];
                dgvc.Width = arrGetFieldWidths[i];
                dgvc.ReadOnly = true;
                dgvXKod.Columns.Add(dgvc);

                cbFields.Items.Add(arrGetFieldTitles[i]);

                intFormWidth += arrGetFieldWidths[i];
            }
            cbFields.SelectedIndex = intGetDefaultCriterIndex;
            cbCriterType.SelectedIndex = 0;

            if (intFormWidth != 0) this.Width = intFormWidth + 70;
        }

        private void prcdXKodDoldur()
        {
            if (dtXKod.Columns.Count > 0) dtXKod.Rows.Clear();

            SqlConnection cnn = new SqlConnection(clsGenel.strConnectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT * FROM (" + strGetSQL + ") AS A WHERE ";
            cmd.CommandText += arrGetFields[cbFields.SelectedIndex] + " LIKE @" + arrGetFields[cbFields.SelectedIndex];
            for (int i = 0; i < arrGetParamNames.Length; i++)
            {
                cmd.Parameters.AddWithValue(arrGetParamNames[i], arrGetParamValues[i]);
            }
            cmd.Parameters.AddWithValue("@" + arrGetFields[cbFields.SelectedIndex], (cbCriterType.SelectedIndex == 1 ? "%" : "") + txtCriter.Text + "%");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtXKod);
            sda.Dispose();
            cmd.Dispose();
            cnn.Close();

            dgvXKod.DataSource = dtXKod;

            if (!blnFormat)
            {
                foreach (DataGridViewColumn DC in dgvXKod.Columns)
                {
                    if (dtXKod.Columns[DC.DataPropertyName].DataType == typeof(double) ||
                        dtXKod.Columns[DC.DataPropertyName].DataType == typeof(float) ||
                        dtXKod.Columns[DC.DataPropertyName].DataType == typeof(decimal))
                    {
                        DC.DefaultCellStyle.Format = clsGenel.strDoubleFormatTwo;
                        DC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }

                blnFormat = true;
            }
        }

        private void txtCriter_TextChanged(object sender, EventArgs e)
        {
            prcdXKodDoldur();
        }

        private void dgvXKod_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbTamam.PerformClick();
        }

        private void tsbTamam_Click(object sender, EventArgs e)
        {
            if (dgvXKod.CurrentRow != null)
            {
                oXKodSelected = dgvXKod.CurrentRow.Cells["col" + arrGetFields[intGetReturnFieldIndex]].Value;
                drResult = DialogResult.OK;
                Close();
            }
        }

        private void frmXKod_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = drResult;
        }

        private void tsbKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvXKod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                tsbTamam.PerformClick();
            }
        }

        private void txtCriter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                tsbTamam.PerformClick();
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (dgvXKod.Rows.Count > 0 && dgvXKod.Rows.Count > dgvXKod.CurrentRow.Index + 1)
                {
                    dgvXKod.CurrentCell = dgvXKod.Rows[dgvXKod.CurrentRow.Index + 1].Cells[0];
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (dgvXKod.Rows.Count > 0 && dgvXKod.CurrentRow.Index != 0)
                {
                    dgvXKod.CurrentCell = dgvXKod.Rows[dgvXKod.CurrentRow.Index - 1].Cells[0];
                }
            }
        }

        private void frmXKod_Shown(object sender, EventArgs e)
        {
            txtCriter.Focus();
        }
    }
}
