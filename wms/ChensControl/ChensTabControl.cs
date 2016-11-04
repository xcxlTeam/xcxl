using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


namespace ChensControl
{
    public class ChensTabControl : System.Windows.Forms.TabControl
    {
        private bool mHaveClose = false;
        //
        // 摘要: 
        //     获取或设置一个值，该值指示在选项卡上是否有关闭按钮。
        //
        // 返回结果: 
        //     如果选项卡有关闭按钮，则为 true；否则为 false。 默认值为 false。
        [DefaultValue(false)]
        [System.ComponentModel.Description("获取或设置一个值，该值指示在选项卡上是否有关闭按钮。"), System.ComponentModel.Category("Power Properties")]
        public bool HaveClose
        {
            get { return mHaveClose; }
            set { mHaveClose = value; }
        }

        private bool mCloseTip = false;
        //
        // 摘要: 
        //     获取或设置一个值，该值指示点击选项卡上关闭按钮是否提示。
        //
        // 返回结果: 
        //     如果关闭有提示，则为 true；否则为 false。 默认值为 false。
        [DefaultValue(false)]
        [System.ComponentModel.Description("获取或设置一个值，该值指示在点击选项卡上的关闭按钮是否提示。"), System.ComponentModel.Category("Power Properties")]
        public bool CloseTip
        {
            get { return mCloseTip; }
            set { mCloseTip = value; }
        }

        //
        // 摘要: 
        //     获取或设置控件的背景色。
        //
        // 返回结果: 
        //     表示控件背景色的 System.Drawing.Color。默认值为 System.Drawing.Color.Silver
        //[DefaultValue(Color.Silver)]
        [System.ComponentModel.Description("获取或设置控件的背景色。"), System.ComponentModel.Category("Power Properties")]
        public Color TabBackColor = Color.Silver;

        private Color ActivedColor = Color.FromArgb(20, 20, 20);
        private Color NotActivedColor = Color.FromArgb(20, 20, 20);
        private Color SelectedNotActivedColor = Color.FromArgb(20, 20, 20);
        private int iconWidth = 15;
        private int iconHeight = 13;
        private Image icon = null;
        private Image iCon_R = null;
        //private bool mouseInCloseBtn = false;

        SolidBrush focusBrush = null;
        SolidBrush notFocusBrush = null;

        public ChensTabControl()
            : base()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.Font = new System.Drawing.Font("微软雅黑", 9, FontStyle.Bold);
            icon = ChensControl.Properties.Resources.close_g;
            iCon_R = ChensControl.Properties.Resources.close_r;
            iconWidth = icon.Width;
            iconHeight = icon.Height;

            focusBrush = new SolidBrush(Color.PowderBlue);
            notFocusBrush = new SolidBrush(Color.LightSteelBlue);

            //focusBrush = new SolidBrush(Color.FromArgb(247, 224, 249));
            //notFocusBrush = new SolidBrush(Color.FromArgb(209, 161, 188));
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = GetTabRect(e.Index);

            if (TabBackColor != SystemColors.Control && this.TabPages != null && this.TabPages.Count >= 1 && e.Index == this.TabPages.Count - 1)
            {
                SolidBrush b = new SolidBrush(TabBackColor);
                g.FillRectangle(b, 0, r.Bottom, this.Width, this.Height);
                g.FillRectangle(b, r.Right, 0, this.Width - r.Right, r.Height);

                b.Dispose();
            }

            //g = e.Graphics;

            if (e.Index == this.SelectedIndex)
            {
                g.FillRectangle(focusBrush, r);
            }
            else
            {
                g.FillRectangle(notFocusBrush, r);
            }

            //g.FillRectangle(Brushes.White, r);
            string title = this.TabPages[e.Index].Text;
            g.DrawString(title, this.Font, new SolidBrush(Color.Black), new PointF(r.X + 7, r.Y + 4));

            r.Offset(r.Width - iconWidth - 3, 2);
            //if (e.Index == this.SelectedIndex)
            //{
            //    if (mouseInCloseBtn == false)
            //    {
            //        g.DrawImage(icon, new Point(r.X, r.Y));
            //    }
            //    else
            //    {
            //        g.DrawImage(iCon_R, new Point(r.X, r.Y));
            //    }
            //}

            if (!this.HaveClose) return;

            g.DrawImage(icon, new Point(r.X, r.Y));
        }


        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (!this.HaveClose) return;
            else if (CloseTip)
            {
                if (MessageBox.Show("是否确认关闭?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) return;
            }

            Point p = e.Location;
            Rectangle r = GetTabRect(this.SelectedIndex);
            r.Offset(r.Width - iconWidth - 3, 2);
            r.Width = iconWidth;
            r.Height = iconHeight;
            if (r.Contains(p))
            {
                //Form frm = GetTabPageForm(this.TabPages[this.SelectedIndex]);
                //if (frm != null)
                //{
                //    frm.Close();
                //    frm.Dispose();
                //    frm = null;
                //}
                if (this.SelectedIndex >= 0)
                {
                    this.TabPages[this.SelectedIndex].Dispose();
                    //this.TabPages[this.SelectedIndex] = null;
                }
                //this.TabPages.RemoveAt(this.SelectedIndex);
            }
        }
        private Form GetTabPageForm(TabPage page = null)
        {
            if (page == null) page = this.SelectedTab;
            if (page == null) return null;
            if (page.Controls == null || page.Controls.Count <= 0) return null;
            if (!(page.Controls[0] is Form)) return null;

            Form f = page.Controls[0] as Form;
            return f;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {

            //Point p = e.Location;
            //Rectangle r = GetTabRect(this.SelectedIndex);
            //r.Offset(r.Width - iconWidth - 3, 3);
            //r.Width = iconWidth;
            //r.Height = iconHeight;
            //if (r.Contains(p))
            //{
            //    if (mouseInCloseBtn == false)
            //    {
            //        mouseInCloseBtn = true;
            //        this.Invalidate();
            //    }
            //}
            //else
            //{
            //    if (mouseInCloseBtn == true)
            //    {
            //        mouseInCloseBtn = false;
            //        this.Invalidate();
            //    }
            //}


            base.OnMouseMove(e);
        }

    }
}
