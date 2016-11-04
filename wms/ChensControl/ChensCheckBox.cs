using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChensControl
{
    public partial class ChensCheckBox : CheckBox
    {


        public ChensCheckBox()
            : base()
        {
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = ControlCommon.GetDefaultFont();
        }

        public string Textn
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
   
    }
}
