using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChensControl
{
    public partial class ChensRichTextBox : UserControl
    {
        public ChensRichTextBox()
        {
            InitializeComponent();
        }

        private bool _TextEnabled = true;

        public bool TextEnabled
        {
            get
            {
                return _TextEnabled;
            }
            set
            {
                _TextEnabled = value;
                this.Invalidate();
            }
        }

        private void SetSize()
        {
            txtInner.Location = new Point(3, 3);
            txtInner.Height = this.Height -7;
            txtInner.Width = this.Width - 6;
            this.Invalidate();
        }

        private void ChensRichTextBox_Load(object sender, EventArgs e)
        {
            this.SetSize();
        }

        private void ChensRichTextBox_Resize(object sender, EventArgs e)
        {
            this.SetSize();
        }

        private void PaintBoder(PaintEventArgs e)
        {
            Graphics g = e.Graphics;


            if (this._TextEnabled)
            {
                txtInner.Visible = true;
                Pen p = new Pen(Color.FromArgb(200, 200, 200), 1);
                g.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);
            }
            else
            {
                txtInner.Visible = false;
                SolidBrush b = new SolidBrush(Color.FromArgb(200, 200, 200));
                g.FillRectangle(b, 0, 0, this.Width, this.Height);
            }
        }

        private void ChensRichTextBox_Paint(object sender, PaintEventArgs e)
        {
            PaintBoder(e);
        }
    }
}
