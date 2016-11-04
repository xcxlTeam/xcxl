using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace PrintLibrary
{
    public class FontConvertBmp
    {
        private string BarcodeText;
        private string FontName;
        private string FileName;
        private int FontSize;
        /// <summary>
        /// 最大宽度(应传入值为8的倍数)
        /// </summary>
        private int Width;
        private bool IsMul;
        private bool IsBold;
        private bool IsItalic;
        private int Angle;
        private StringBuilder ReturnBarcodeCMD;

        List<char> List1 = new List<char>();
        List<int> List2 = new List<int>();
        string S = string.Empty;
        
        /// <summary>
        /// GETFONTHEX主方法
        /// </summary>
        /// <param name="_BarcodeText">文本</param>
        /// <param name="_isMul">是否一定是多行</param>
        /// <param name="_FontName">字体</param>
        /// <param name="_FileName">传入打印机的唯一文档名</param>
        /// <param name="_FontSize">字体大小</param>
        /// <param name="_Width">最大宽度,应传入值为8的倍数(_isMul=false时无效)</param>
        /// <param name="_IsBold">是否加粗</param>
        /// <param name="_IsItalic">是否斜体</param>
        /// <param name="_ReturnBarcodeCMD">输出字符串</param>
        public void GETFONTHEX(string _BarcodeText,bool _isMul, string _FontName, string _FileName, int _FontSize, int _Width, bool _IsBold, bool _IsItalic, StringBuilder _ReturnBarcodeCMD)
        {
            this.BarcodeText = string.IsNullOrEmpty(_BarcodeText) ? " " : _BarcodeText;
            this.IsMul = _isMul;
            this.FontName = _FontName;
            this.FileName = _FileName;
            this.FontSize = _FontSize;
            this.Width = _Width;
            this.IsBold = _IsBold;
            this.IsItalic = _IsItalic;
            this.Angle = 0;
            this.ReturnBarcodeCMD = _ReturnBarcodeCMD;
            this.ReturnBarcodeCMD.Clear();
            S = string.Empty;
            InitDictionary();
            TextToImage();
        }

        /// <summary>
        /// GETFONTHEX主方法
        /// </summary>
        /// <param name="_BarcodeText">文本</param>
        /// <param name="_isMul">是否一定是多行</param>
        /// <param name="_FontName">字体</param>
        /// <param name="_FileName">传入打印机的唯一文档名</param>
        /// <param name="_FontSize">字体大小</param>
        /// <param name="_Width">最大宽度,应传入值为8的倍数(_isMul=false时无效)</param>
        /// <param name="_IsBold">是否加粗</param>
        /// <param name="_IsItalic">是否斜体</param>
        /// <param name="_Angle">旋转角度(0°,90°,180°,270°)</param>
        /// <param name="_ReturnBarcodeCMD">输出字符串</param>
        public void GETFONTHEX(string _BarcodeText, bool _isMul, string _FontName, string _FileName, int _FontSize, int _Width, bool _IsBold, bool _IsItalic, int _Angle, StringBuilder _ReturnBarcodeCMD)
        {
            this.BarcodeText = string.IsNullOrEmpty(_BarcodeText) ? " " : _BarcodeText;
            this.IsMul = _isMul;
            this.FontName = _FontName;
            this.FileName = _FileName;
            this.FontSize = _FontSize;
            this.Width = _Width;
            this.IsBold = _IsBold;
            this.IsItalic = _IsItalic;
            this.Angle = _Angle % 360;
            this.ReturnBarcodeCMD = _ReturnBarcodeCMD;
            this.ReturnBarcodeCMD.Clear();
            S = string.Empty;
            InitDictionary();
            TextToImage();
        }
        private void InitDictionary()
        {
            for (int i = 0; i <= 18; i++)
            {
                List1.Add(Convert.ToChar(71 + i));
                List2.Add(i + 1);
            }
            for (int i = 0; i <= 19; i++)
            {
                List1.Add(Convert.ToChar(103 + i));
                List2.Add(20 * (i + 1));
            }
        }
        private string CompressCode(int Input)
        {
            if (Input > 0)
            {
                for (int i = List1.Count - 1; i >= 0; i--)
                {
                    if (Input >= List2[i])
                    {
                        S += List1[i];
                        Input -= List2[i];
                        if (Input == 0)
                            break;
                    }
                }
                CompressCode(Input);
            }
            return S;
        }
        private void TextToImage()
        {
            FontStyle myfs = new FontStyle();
            if (this.IsBold)
            {
                myfs |= FontStyle.Bold;
            }
            if (this.IsItalic)
            {
                myfs |= FontStyle.Italic;
            }
            int W = this.Width;
            int H = 0;
            Font f = new Font(this.FontName, Convert.ToSingle(this.FontSize), myfs, GraphicsUnit.Pixel);
            Bitmap tempimageforg = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(tempimageforg);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            if (!IsMul)
            {
                SizeF sf = g.MeasureString(this.BarcodeText, f);
                W = Convert.ToInt32(Math.Ceiling(sf.Width));
                W = W + (8 - W % 8);
                H = Convert.ToInt32(Math.Ceiling(sf.Height));
            }
            else
            {
                SizeF sf = g.MeasureString(this.BarcodeText, f, this.Width);
                W = Convert.ToInt32(Math.Ceiling(sf.Width));
                W = W + (8 - W % 8);
                H = Convert.ToInt32(Math.Ceiling(sf.Height));
            }
            int ImgWidth = W, ImgHeight = H;
            if (this.Angle % 180 == 0)
            {
                ImgWidth = W;
                ImgHeight = H;
            }
            else if (this.Angle % 90 == 0)
            {
                ImgWidth = H;
                ImgHeight = W;
            }
            else
            {
                //ImgWidth = (int)Math.Sqrt(Math.Pow(W, 2) + Math.Pow(H, 2));
                //ImgHeight = (W * H / ImgWidth) * 2;
            }
            Bitmap Image = new Bitmap(ImgWidth, ImgHeight, PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(Image);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            g.Clear(Color.White);
            switch (this.Angle)
            {
                case 0:
                    g.TranslateTransform(0, 0, MatrixOrder.Prepend);
                    break;

                case 90:
                    g.TranslateTransform(ImgWidth, 0, MatrixOrder.Prepend);
                    break;

                case 180:
                    g.TranslateTransform(ImgWidth, ImgHeight, MatrixOrder.Prepend);
                    break;

                case 270:
                    g.TranslateTransform(0, ImgHeight, MatrixOrder.Prepend);
                    break;
            }
            g.RotateTransform(Angle);
            g.DrawString(this.BarcodeText, f, Brushes.Black, new RectangleF(0f, 0f, (float)W, (float)H));
            g.ResetTransform();
            if (Angle % 180 == 0)
            {
                StringBuilder TempString = new StringBuilder(Image.Height * Image.Width);
                int Sum = 0;
                for (int j = 0; j < Image.Height; j++)
                {
                    for (int i = 0; i < Image.Width / 4; i++)
                    {
                        Sum = 0;
                        for (int m = 0; m < 4; m++)
                        {
                            if (Image.GetPixel(i * 4 + m, j).B == 0)
                                Sum += 1 << (3 - m);
                        }
                        TempString.Append(Sum.ToString("x"));
                    }
                }

                StringBuilder strBmpData = new StringBuilder();
                int Count = 1;
                for (int i = 1; i < TempString.Length; i++)
                {
                    if (TempString[i - 1] == TempString[i])
                    {
                        Count += 1;
                        if (i == TempString.Length - 1)
                            strBmpData.Append(CompressCode(Count) + TempString[i]);
                    }
                    else
                    {
                        if (Count != 1)
                            strBmpData.Append(CompressCode(Count) + TempString[i - 1]);
                        else
                            strBmpData.Append(TempString[i - 1]);
                        S = String.Empty;
                        Count = 1;
                    }
                }

                this.ReturnBarcodeCMD.Append("~DG" + this.FileName + "," + (Image.Height * Image.Width / 8).ToString("00000") + "," + (Image.Width / 8).ToString("000") + ",");
                this.ReturnBarcodeCMD.Append(strBmpData);
                g.Dispose();
                Image.Dispose();
            }
            else if (this.Angle % 90 == 0)
            {
                StringBuilder strBmpData = new StringBuilder();

                int _W = (Image.Width + 7) / 8;
                int bitcnt = 7;
                int v = 0;
                Color clr;
                int grayval;

                for (int i = 0; i < Image.Height; i++)
                {
                    for (int j = 0; j < _W * 8; j++)
                    {
                        if (j < Image.Width)
                        {
                            clr = Image.GetPixel(j, i);
                            grayval = (clr.R + clr.G + clr.B) / 3;
                        }
                        else
                            grayval = 0xFF;

                        if (grayval > 100)
                            v &= ~(0x01 << bitcnt);
                        else
                            v |= (0x01 << bitcnt);

                        bitcnt--;
                        if (bitcnt < 0)
                        {
                            bitcnt = 7;
                            strBmpData.Append(v.ToString("X2"));
                            v = 0;
                        }
                    }
                }

                this.ReturnBarcodeCMD.Append("~DG" + this.FileName + "," + (_W * Image.Height).ToString() + "," + _W.ToString() + ",");
                this.ReturnBarcodeCMD.Append(strBmpData);
                g.Dispose();
                Image.Dispose();
            }
        }
    }
}
