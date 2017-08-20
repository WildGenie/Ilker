using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PRCTicari
{
    public partial class MyDataGridView : DataGridView
    {
        public MyDataGridView()
        {
            InitializeComponent();
        }

        public MyDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.ColumnCount > 0)
                {
                    int col = this.CurrentCell.ColumnIndex;
                    int row = this.CurrentCell.RowIndex;
                    int rowindcont = 0;
                    if (this.AllowUserToAddRows == false)
                    {
                        rowindcont = this.RowCount - 1;
                    }
                    else
                    {
                        rowindcont = this.NewRowIndex;
                    }
                    for (int i = 0; i <= this.ColumnCount - 1; i++)
                    {
                        if (!(row == rowindcont))
                        {
                            if (col == (this.Columns.Count - 1))
                            {
                                col = -1;
                                row += 1;
                            }
                        }
                        else
                        {
                            if (col == (this.Columns.Count - 1))
                            {
                                col = -1;
                            }
                        }
                        if (this.Columns[col + 1].Visible)
                        {
                            this.EndEdit();
                            this.CurrentCell = this[col + 1, row];
                            break;
                        }
                        else
                        {
                            col += 1;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (this.ColumnCount > 0)
                {
                    int col = this.CurrentCell.ColumnIndex;
                    int row = this.CurrentCell.RowIndex;
                    int rowindcont = 0;
                    if (this.AllowUserToAddRows == false)
                    {
                        rowindcont = this.RowCount - 1;
                    }
                    else
                    {
                        rowindcont = this.NewRowIndex;
                    }
                    for (int i = 0; i <= this.ColumnCount - 1; i++)
                    {
                        if (!(row == rowindcont))
                        {
                            if (col == (this.Columns.Count - 1))
                            {
                                col = -1;
                                row += 1;
                            }
                        }
                        else
                        {
                            if (col == (this.Columns.Count - 1))
                            {
                                col = -1;
                            }
                        }
                        if (this.Columns[col + 1].Visible)
                        {
                            this.EndEdit();
                            this.CurrentCell = this[col + 1, row];
                            break; 
                        }
                        else
                        {
                            col += 1;
                        }
                    }
                    e.Handled = true;
                }
            }
            base.OnKeyDown(e);
        }
    }
}
