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
    public partial class ChensReference : UserControl
    {
        public ChensReference()
        {
            InitializeComponent();
            
           
        }

        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        
        public  string ReferText
        {
            get { return lblInner.Text; }
            set { lblInner.Text = value; }
        }

        private Brush foreBrush = Brushes.Black;

        //定义委托
        public delegate void ReferenceHandle(object sender, EventArgs e);

        //定义事件
        public event ReferenceHandle RefButtonClick;

        private void ChensReference_Load(object sender, EventArgs e)
        {
            SetControlsSize();
        }

        private void ChensReference_Resize(object sender, EventArgs e)
        {
            SetControlsSize();
            this.Invalidate();
        }

        private void SetControlsSize()
        {
            SetButtonSize();
            SetControlHeight();
           
        }

        

        private void SetButtonSize()
        {
            
            btnRefer.Height = 18;
            btnRefer.Width = 18;
            btnRefer.Location = new Point(this.Width - btnRefer.Width -1 ,  2);
            btnRefer.Refresh();
        }

        private void SetControlHeight()
        {
            this.Height = 23;
        }

        private void ChensReference_Paint(object sender, PaintEventArgs e)
        {
            
            PaintBoder(e);
        }

        private void PaintBoder(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            Pen p = new Pen(Color.FromArgb(200,200,200), 1);
            g.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);
            g.DrawString(this.Text, this.Font, foreBrush, 1, 1);
        }

        private void btnRefer_Click(object sender, EventArgs e)
        {
            RefButtonClick(sender, e);
        }

        
        
    }
}
