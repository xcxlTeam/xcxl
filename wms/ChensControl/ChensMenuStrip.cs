using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChensControl
{
    public class ChensMenuStrip : System.Windows.Forms.MenuStrip
    {
        public ChensMenuStrip()
        {
            this.Font = ControlCommon.GetDefaultFont();
            this.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ChensMenuStrip
            // 
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ResumeLayout(false);

        }
    }
}
