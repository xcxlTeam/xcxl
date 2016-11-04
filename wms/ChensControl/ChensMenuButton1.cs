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
    /// 折叠按钮
    /// </summary>
    public partial class ChensMenuButton1 : UserControl
    {
        public ChensMenuButton1(JSModule module, JSModules modules, Panel panel)
        {
            this.Height = 40;
            jsmodule = module;
            this.childPanel = panel;
            jsmodules = modules.modules.Where(p => p.ParentID == module.ID).ToList<JSModule>();
            InitializeComponent();
            this.CreateChildPanel();

        }

        public JSModule jsmodule;
        private List<JSModule> jsmodules;
        public Panel childPanel;

        private void CreateChildPanel()
        {

            childPanel.Height = 0;

            int lastTop = 0;
            foreach (JSModule module in jsmodules)
            {
                ChensMenuButton2 button2 = new ChensMenuButton2(module);
                childPanel.Controls.Add(button2);
                button2.Left = 0;
                button2.Top = lastTop;
                lastTop = button2.Bottom;
                childPanel.Height += button2.Height;
            }

        }

        private void ChensMenuButton1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //画底色   52,65,74
            SolidBrush b = new SolidBrush(Color.FromArgb(50, 150, 185));
            g.FillRectangle(b, 0, 0, this.Width, this.Height);

            //画边框
            Pen p = new Pen(Color.FromArgb(40, 47, 56));
            g.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);

            //画文字
            g.DrawString(jsmodule.Name, this.Font, new SolidBrush(Color.White), new PointF(80, 11));

            //画图标
            ControlCommon.DrawMenuIcon(g, jsmodule.ID);


        }

        private void ChensMenuButton1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void ChensMenuButton1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void ChensMenuButton1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
