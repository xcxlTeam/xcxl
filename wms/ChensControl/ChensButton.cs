using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ChensControl
{
    public class ChensButton : System.Windows.Forms.Button
    {
        private Color mouseInColor = Color.FromArgb(37,127,239);
        private Color mouseNotInColor = Color.FromArgb(34, 174, 253);

        

        public ChensButton():base()
        {
            this.Font = ControlCommon.GetDefaultFont();
            this.BackColor = mouseNotInColor;

        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
        {
            if (this.ForeColor != Color.White)
            {
                this.ForeColor = Color.White;
            }
            if ( this.FlatStyle != System.Windows.Forms.FlatStyle.Flat)
            {
                this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            }
            base.OnPaint(pevent);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.Cursor = Cursors.Hand;
            this.BackColor = mouseInColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.Cursor = Cursors.Default;
            this.BackColor = mouseNotInColor;
        }

      


    }
}
