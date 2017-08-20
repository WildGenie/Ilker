using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PRCTicari
{
    public partial class MyButton : Button
    {
        object oValue1 = null;
        object oValue2 = null;
        object oValue3 = null;
        object oValue4 = null;
        object oValue5 = null;

        Label lblLeftTop = new Label();
        Label lblLeftBottom = new Label();
        Label lblRightTop = new Label();
        Label lblRightBottom = new Label();
        int intMargin = 3;

        [Category("Labels")]
        public string LabelLeftTopText { get { return lblLeftTop.Text; } set { lblLeftTop.Text = value; } }

        [Category("Labels")]
        public string LabelLeftBottomText { get { return lblLeftBottom.Text; } set { lblLeftBottom.Text = value; } }

        [Category("Labels")]
        public string LabelRightTopText { get { return lblRightTop.Text; } set { lblRightTop.Text = value; } }

        [Category("Labels")]
        public string LabelRightBottomText { get { return lblRightBottom.Text; } set { lblRightBottom.Text = value; } }

        [Category("Labels")]
        public Font LabelLeftTopFont { get { return lblLeftTop.Font; } set { lblLeftTop.Font = value; } }

        [Category("Labels")]
        public Font LabelLeftBottomFont { get { return lblLeftBottom.Font; } set { lblLeftBottom.Font = value; } }

        [Category("Labels")]
        public Font LabelRightTopFont { get { return lblRightTop.Font; } set { lblRightTop.Font = value; } }

        [Category("Labels")]
        public Font LabelRightBottomFont { get { return lblRightBottom.Font; } set { lblRightBottom.Font = value; } }

        [Category("Labels")]
        public Color LabelLeftTopForeColor { get { return lblLeftTop.ForeColor; } set { lblLeftTop.ForeColor = value; } }

        [Category("Labels")]
        public Color LabelLeftBottomForeColor { get { return lblLeftBottom.ForeColor; } set { lblLeftBottom.ForeColor = value; } }

        [Category("Labels")]
        public Color LabelRightTopForeColor { get { return lblRightTop.ForeColor; } set { lblRightTop.ForeColor = value; } }

        [Category("Labels")]
        public Color LabelRightBottomForeColor { get { return lblRightBottom.ForeColor; } set { lblRightBottom.ForeColor = value; } }
        public object Value1 { get { return oValue1; } set { oValue1 = value; } }
        public object Value2 { get { return oValue2; } set { oValue2 = value; } }
        public object Value3 { get { return oValue3; } set { oValue3 = value; } }
        public object Value4 { get { return oValue4; } set { oValue4 = value; } }
        public object Value5 { get { return oValue5; } set { oValue5 = value; } }

        public MyButton() : base()
        {
            InitializeComponent();
            prcdHazirlik();
        }

        public MyButton(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            prcdHazirlik();
        }

        private void prcdHazirlik()
        {
            Size = new System.Drawing.Size(100, 100);

            this.Controls.Add(lblLeftTop);
            this.Controls.Add(lblLeftBottom);
            this.Controls.Add(lblRightTop);
            this.Controls.Add(lblRightBottom);

            lblLeftTop.BackColor = System.Drawing.Color.Transparent;
            lblLeftBottom.BackColor = System.Drawing.Color.Transparent;
            lblRightTop.BackColor = System.Drawing.Color.Transparent;
            lblRightBottom.BackColor = System.Drawing.Color.Transparent;
            lblLeftTop.Text = "";
            lblLeftBottom.Text = "";
            lblRightTop.Text = "";
            lblRightBottom.Text = "";
            lblLeftTop.AutoSize = true;
            lblLeftBottom.AutoSize = true;
            lblRightTop.AutoSize = true;
            lblRightBottom.AutoSize = true;

            lblLeftTop.Left = intMargin;
            lblLeftTop.Top = intMargin;
            lblLeftBottom.Left = intMargin;
            lblLeftBottom.Top = this.Height - lblLeftBottom.Height - intMargin;
            lblRightTop.Left = this.Width - lblRightTop.Width - intMargin;
            lblRightTop.Top = intMargin;
            lblRightBottom.Left = this.Width - lblRightBottom.Width - intMargin;
            lblRightBottom.Top = this.Height - lblRightBottom.Height - intMargin;

            lblRightTop.TextAlign = System.Drawing.ContentAlignment.TopRight;
            lblRightBottom.TextAlign = System.Drawing.ContentAlignment.TopRight;

            lblLeftTop.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
            lblLeftBottom.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
            lblRightTop.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
            lblRightBottom.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);

            lblLeftTop.Resize += (sender, args) => {
                lblLeftTop.Left = intMargin;
                lblLeftTop.Top = intMargin;
            };

            lblLeftBottom.Resize += (sender, args) => {
                lblLeftBottom.Left = intMargin;
                lblLeftBottom.Top = this.Height - lblLeftBottom.Height - intMargin;
            };

            lblRightTop.Resize += (sender, args) => {
                lblRightTop.Left = this.Width - lblRightTop.Width - intMargin;
                lblRightTop.Top = intMargin;
            };

            lblRightBottom.Resize += (sender, args) => {
                lblRightBottom.Left = this.Width - lblRightBottom.Width - intMargin;
                lblRightBottom.Top = this.Height - lblRightBottom.Height - intMargin;
            };

            lblLeftTop.Click += (sender, args) => {
                InvokeOnClick(this, args);
            };

            lblLeftBottom.Click += (sender, args) => {
                InvokeOnClick(this, args);
            };

            lblRightTop.Click += (sender, args) => {
                InvokeOnClick(this, args);
            };

            lblRightBottom.Click += (sender, args) => {
                InvokeOnClick(this, args);
            };
        }


    }
}
