using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ChensControl
{
    [ToolboxItem(true)]
    public partial class ChensComboBox: ComboBox
    {
        /// <summary> 
        /// 获得当前进程，以便重绘控件 
        /// </summary> 
        /// <param name="hWnd"></param> 
        /// <returns></returns> 
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        /// <summary> 
        /// 是否启用热点效果 
        /// </summary> 
        private bool _HotTrack = false;

        /// <summary> 
        /// 边框颜色 
        /// </summary> 
        private Color _BorderColor = Color.FromArgb(200, 200, 200);

        /// <summary> 
        /// 热点边框颜色 
        /// </summary> 
        private Color _HotColor = Color.FromArgb(0x33, 0x5E, 0xA8);

        /// <summary> 
        /// 是否鼠标MouseOver状态 
        /// </summary> 
        private bool _IsMouseOver = false;

        #region 属性
        /// <summary> 
        /// 是否启用热点效果 
        /// </summary> 
        [Category("行为"),
       Description("获得或设置一个值，指示当鼠标经过控件时控件边框是否发生变化。只在控件的BorderStyle为FixedSingle时有效"),
       DefaultValue(true)]
        public bool HotTrack
        {
            get
            {
                return this._HotTrack;
            }
            set
            {
                this._HotTrack = value;
                //在该值发生变化时重绘控件，下同 
                //在设计模式下，更改该属性时，如果不调用该语句， 
                //则不能立即看到设计试图中该控件相应的变化 
                this.Invalidate();
            }
        }
        /// <summary> 
        /// 边框颜色 
        /// </summary> 
        [Category("外观"),
       Description("获得或设置控件的边框颜色"),
       DefaultValue(typeof(Color), "#A7A6AA")]
        public Color BorderColor
        {
            get
            {
                return this._BorderColor;
            }
            set
            {
                this._BorderColor = value;
                this.Invalidate();
            }
        }
        /// <summary> 
        /// 热点时边框颜色 
        /// </summary> 
        [Category("外观"),
       Description("获得或设置当鼠标经过控件时控件的边框颜色。只在控件的BorderStyle为FixedSingle时有效"),
       DefaultValue(typeof(Color), "#335EA8")]
        public Color HotColor
        {
            get
            {
                return this._HotColor;
            }
            set
            {
                this._HotColor = value;
                this.Invalidate();
            }
        }


        #endregion 属性

         /// <summary> 
        /// 
        /// </summary> 
        public ChensComboBox()
            : base()
        {
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = ControlCommon.GetDefaultFont();
            this.Height = 23;
            this.BackColor = System.Drawing.Color.White;
            this.FormattingEnabled = true;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary> 
        /// 鼠标移动到该控件上时 
        /// </summary> 
        /// <param name="e"></param> 
        protected override void OnMouseMove(MouseEventArgs e)
        {
            //鼠标状态 
            this._IsMouseOver = true;
            //如果启用HotTrack，则开始重绘 

            if (this._HotTrack)
            {
                //重绘 
                this.Invalidate();
            }
            base.OnMouseMove(e);
        }
        /// <summary> 
        /// 当鼠标从该控件移开时 
        /// </summary> 
        /// <param name="e"></param> 
        protected override void OnMouseLeave(EventArgs e)
        {
            this._IsMouseOver = false;

            if (this._HotTrack)
            {
                //重绘 
                this.Invalidate();
            }
            base.OnMouseLeave(e);
        }

        /// <summary> 
        /// 当该控件获得焦点时 
        /// </summary> 
        /// <param name="e"></param> 
        protected override void OnGotFocus(EventArgs e)
        {

            if (this._HotTrack)
            {
                //重绘 
                this.Invalidate();
            }
            base.OnGotFocus(e);
        }
        /// <summary> 
        /// 当该控件失去焦点时 
        /// </summary> 
        /// <param name="e"></param> 
        protected override void OnLostFocus(EventArgs e)
        {
            if (this._HotTrack)
            {
                //重绘 
                this.Invalidate();
            }
            base.OnLostFocus(e);
        }

        /// <summary> 
        /// 获得操作系统消息 
        /// </summary> 
        /// <param name="m"></param> 
        protected override void WndProc(ref Message m)
        {

            base.WndProc(ref m);
            if (m.Msg == 0xf || m.Msg == 0x133)
            {
                //拦截系统消息，获得当前控件进程以便重绘。 

                IntPtr hDC = GetWindowDC(m.HWnd);
                if (hDC.ToInt32() == 0)
                {
                    return;
                }

                //只有在边框样式为FixedSingle时自定义边框样式才有效 
                if (this.FlatStyle == System.Windows.Forms.FlatStyle.Flat)
                {
                    //边框Width为1个像素 
                    System.Drawing.Pen pen = new Pen(this._BorderColor, 1); ;

                    if (this._HotTrack)
                    {
                        if (this.Focused)
                        {
                            pen.Color = this._HotColor;
                        }
                        else
                        {
                            if (this._IsMouseOver)
                            {
                                pen.Color = this._HotColor;
                            }
                            else
                            {
                                pen.Color = this._BorderColor;
                            }
                        }
                    }
                    //绘制边框 
                    System.Drawing.Graphics g = Graphics.FromHdc(hDC);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                    pen.Dispose();
                }
                //返回结果 
                m.Result = IntPtr.Zero;
                //释放 
                ReleaseDC(m.HWnd, hDC);
            }
        }


    }
}
