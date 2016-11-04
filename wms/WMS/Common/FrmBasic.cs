using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS.Common
{
    public partial class FrmBasic : Form
    {
        public FrmBasic()
        {
            InitializeComponent();
        }

        private void FrmBasic_FormClosed(object sender, FormClosedEventArgs e)
        {
            RemoveTab();
        }

        private void RemoveTab()
        {
            Common.Common_Func.RemoveTabPageForm(this);
        }
    }
}
