using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WMS.Print
{
    public class BarCode128
    {
        //ASCII从32到127对应的条码区,由3个条、3个空、共11个单元构成,符号内含校验码
        private string[] Code128Encoding = new string[] { "11011001100", "11001101100", "11001100110", "10010011000", "10010001100", "10001001100", "10011001000", "10011000100", "10001100100", "11001001000", "11001000100", "11000100100", "10110011100", "10011011100", "10011001110", "10111001100", "10011101100", "10011100110", "11001110010", "11001011100", "11001001110", "11011100100", "11001110100", "11101101110", "11101001100", "11100101100", "11100100110", "11101100100", "11100110100", "11100110010", "11011011000", "11011000110", "11000110110", "10100011000", "10001011000", "10001000110", "10110001000", "10001101000", "10001100010", "11010001000", "11000101000", "11000100010", "10110111000", "10110001110", "10001101110", "10111011000", "10111000110", "10001110110", "11101110110", "11010001110", "11000101110", "11011101000", "11011100010", "11011101110", "11101011000", "11101000110", "11100010110", "11101101000", "11101100010", "11100011010", "11101111010", "11001000010", "11110001010", "10100110000", "10100001100", "10010110000", "10010000110", "10000101100", "10000100110", "10110010000", "10110000100", "10011010000", "10011000010", "10000110100", "10000110010", "11000010010", "11001010000", "11110111010", "11000010100", "10001111010", "10100111100", "10010111100", "10010011110", "10111100100", "10011110100", "10011110010", "11110100100", "11110010100", "11110010010", "11011011110", "11011110110", "11110110110", "10101111000", "10100011110", "10001011110", "10111101000", "10111100010", "11110101000", "11110100010", "10111011110", "10111101110", "11101011110", "11110101110", "11010000100", "11010010000", "11010011100" };
        private const string Code128Stop = "11000111010", Code128End = "11"; //固定码尾 
        private enum Code128ChangeModes { CodeA = 101, CodeB = 100, CodeC = 99 }; //变更  
        private enum Code128StartModes { CodeUnset = 0, CodeA = 103, CodeB = 104, CodeC = 105 };//各类编码的码头
        public float EncodeBarcode(string code, System.Drawing.Graphics g, float x, int y, int width, int height, bool showText)
        {
            if (string.IsNullOrEmpty(code)) new Exception("条码不能为空");
            List<int> encoded = CodetoEncoded(code); //1.拆分转义
            encoded.Add(CheckDigitCode128(encoded)); //2.加入校验码
            string encodestring = EncodeString(encoded); //3.编码

            //if (showText) //计算文本的大小,字体占图像的1/4高
            //{
            //    Font font = new System.Drawing.Font("宋体", height / 5F, System.Drawing.FontStyle.Regular, GraphicsUnit.Pixel, ((byte)(0)));
            //    SizeF size = g.MeasureString(code, font);
            //    height = height - (int)size.Height;
            //    g.DrawString(code, font, System.Drawing.Brushes.Black, x, y + height);
            //    int w = DrawBarCode(g, encodestring, x, y, width, height); //4.绘制
            //    return ((int)size.Width > w ? (int)size.Width : w);
            //}
            //else
                return DrawBarCode(g, encodestring, x, y, width, height); //4.绘制
        }
        private List<int> CodetoEncoded(string code)
        {
            List<int> encoded = new List<int>();
            int type = 0;//2:B类,3:C类
            for (int i = 0; code.Length > 0; i++)
            {
                int k = isNumber(code);
                if (k >= 4) //连续偶个数字可优先使用C类(其实并不定要转C类，但能用C类时条码会更短)
                {
                    if (type == 0) encoded.Add((int)Code128StartModes.CodeC); //加入码头
                    else if (type != 3) encoded.Add((int)(Code128ChangeModes.CodeC)); //转义
                    type = 3;
                    for (int j = 0; j < k; j = j + 2) //两位数字合为一个码身
                    {
                        encoded.Add(Int32.Parse(code.Substring(0, 2)));
                        code = code.Substring(2);
                    }
                }
                else
                {
                    if ((int)code[0] < 32 || (int)code[0] > 126) throw new Exception("字符串必须是数字或字母");
                    if (type == 0) encoded.Add((int)Code128StartModes.CodeB); //加入码头
                    else if (type != 2) encoded.Add((int)(Code128ChangeModes.CodeB)); //转义
                    type = 2;
                    encoded.Add((int)code[0] - 32);//字符串转为ASCII-32
                    code = code.Substring(1);
                }
            }
            return encoded;
        }

        private int CheckDigitCode128(List<int> encoded)
        {
            int check = encoded[0];
            for (int i = 1; i < encoded.Count; i++)
                check = check + (encoded[i] * i);
            return (check % 103);
        }

        //2.编码(对应Code128Encoding数组)
        private string EncodeString(List<int> encoded)
        {
            string encodedString = "";
            for (int i = 0; i < encoded.Count; i++)
            {
                encodedString += Code128Encoding[encoded[i]];
            }
            encodedString += Code128Stop + Code128End; // 加入结束码
            return encodedString;
        }

        private float DrawBarCode(System.Drawing.Graphics g, string encodeString, float x, int y, int width, int height)
        {
            float w = 1f;// width / encodeString.Length;
            for (int i = 0; i < encodeString.Length; i++)
            {
                g.FillRectangle(encodeString[i] == '0' ? System.Drawing.Brushes.White : System.Drawing.Brushes.Black, x, y, w, height);
                x += w * 0.8f;
            }
            return w * (encodeString.Length + 2);
        }
        //检测是否连续偶个数字,返回连续数字的长度
        private int isNumber(string code)
        {
            int k = 0;
            for (int i = 0; i < code.Length; i++)
            {
                if (char.IsNumber(code[i]))
                    k++;
                else
                    break;
            }
            if (k % 2 != 0) k--;
            return k;
        }
        public Image EncodeBarcode(string code, int width, int height, bool showText)
        {
            Bitmap image = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(Color.White);
                float w = EncodeBarcode(code, g, 0, 0, code.Length, height, showText);
                
                Bitmap image2 = new Bitmap(Convert.ToInt32(w), height); //剪切多余的空白;
                using (Graphics g2 = Graphics.FromImage(image2))
                {
                    g2.DrawImage(image, 0, 0);
                    return image2;
                }

            }

        }
        public byte[] EncodeBarcodeByte(string code, int width, int height, bool showText)
        {
            Image image = EncodeBarcode(code, width, height, showText);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byteImage = ms.ToArray();
            ms.Close();
            image.Dispose();
            return byteImage;

        }
    }
}
