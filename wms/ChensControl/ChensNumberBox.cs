using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ChensControl
{
    public class ChensNumberBox : NumericUpDown
    {
        public ChensNumberBox():base()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Font = ControlCommon.GetDefaultFont();
           
        }

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

        /// <summary> 
        /// 是否启用热点效果 
        /// </summary> 
        [Category("行为"),
       Description("获得或设置一个值，指示当鼠标经过控件时控件边框是否发生变化。只在控件的BorderStyle为FixedSingle时有效"),
       DefaultValue(true)]

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
                if (this.BorderStyle == BorderStyle.FixedSingle)
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
