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
    /// <summary>
    /// 展开按钮
    /// </summary>
    public partial class ChensMenuButton2 : UserControl
    {
        public ChensMenuButton2(JSModule module)
        {
            this.Height = 30;
            this.jsmodule = module;
            mouseIn = false;
            InitializeComponent();
        }
        public JSModule jsmodule;
        private bool mouseIn;
        private void ChensMenuButton2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush b;
            //画底色
            if (mouseIn)
            {
                //鼠标悬浮  39, 169, 227
                b = new SolidBrush(Color.FromArgb(135, 205, 160));
            }
            else
            {
                // 默认底色 46, 55, 64
                b = new SolidBrush(Color.FromArgb(95, 190, 220));

            }
            g.FillRectangle(b, 0, 0, this.Width, this.Height);

            //画边框
            Pen p = new Pen(Color.FromArgb(40, 47, 56));
            g.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);

            //画文字
            g.DrawString(jsmodule.Name, this.Font, new SolidBrush(Color.White), new PointF(100, 6));

            //画图标
            g.DrawImage(ChensControl.Properties.Resources.jj, 75, 5, 18, 18);
        }

        private void ChensMenuButton2_MouseEnter(object sender, EventArgs e)
        {
            mouseIn = true;
            this.Invalidate();
        }

        private void ChensMenuButton2_MouseLeave(object sender, EventArgs e)
        {
            mouseIn = false;
            this.Invalidate();
        }
    }
}
