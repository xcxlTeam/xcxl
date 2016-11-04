using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelLibrary
{
    public class ExcelLibrary_Model
    {
        private Font _CellFont;
        /// <summary>
        /// 单元格字体
        /// </summary>
        public Font CellFont
        {
            get { return _CellFont; }
            set { _CellFont = value; }
        }

        private int _Alignment = 0;
        /// <summary>
        /// 水平对齐方式 - 
        /// 0:常规;1:靠左;2:居中;3:靠右;4:填充;5:两端对齐;6:跨列居中;7:分散对齐
        /// </summary>
        public int Alignment
        {
            get { return _Alignment; }
            set { _Alignment = value; }
        }
        private int _VerticalAlignment = 0;
        /// <summary>
        /// 垂直对齐方式 - 
        /// 0:靠上;1:居中;2:靠下;3:两端对齐;4:分散对齐
        /// </summary>
        public int VerticalAlignment
        {
            get { return _VerticalAlignment; }
            set { _VerticalAlignment = value; }
        }

        private int _BorderTop = 0;
        /// <summary>
        /// 上边框 - 
        /// 0:No;1:Thin;2:Medium;3:dash;4:dot;5:Thick;6:double-line;7:hair-line;8:Medium dashed;
        /// 9:dash-dot;10:medium dash-dot;11:dash-dot-dot;12:medium dash-dot-dot;13:slanted dash-dot
        /// </summary>
        public int BorderTop
        {
            get { return _BorderTop; }
            set { _BorderTop = value; }
        }
        private int _BorderLeft = 0;
        /// <summary>
        /// 左边框 - 
        /// 0:No;1:Thin;2:Medium;3:dash;4:dot;5:Thick;6:double-line;7:hair-line;8:Medium dashed;
        /// 9:dash-dot;10:medium dash-dot;11:dash-dot-dot;12:medium dash-dot-dot;13:slanted dash-dot
        /// </summary>
        public int BorderLeft
        {
            get { return _BorderLeft; }
            set { _BorderLeft = value; }
        }
        private int _BorderRight = 0;
        /// <summary>
        /// 右边框 - 
        /// 0:No;1:Thin;2:Medium;3:dash;4:dot;5:Thick;6:double-line;7:hair-line;8:Medium dashed;
        /// 9:dash-dot;10:medium dash-dot;11:dash-dot-dot;12:medium dash-dot-dot;13:slanted dash-dot
        /// </summary>
        public int BorderRight
        {
            get { return _BorderRight; }
            set { _BorderRight = value; }
        }
        private int _BorderBottom = 0;
        /// <summary>
        /// 下边框 - 
        /// 0:No;1:Thin;2:Medium;3:dash;4:dot;5:Thick;6:double-line;7:hair-line;8:Medium dashed;
        /// 9:dash-dot;10:medium dash-dot;11:dash-dot-dot;12:medium dash-dot-dot;13:slanted dash-dot
        /// </summary>
        public int BorderBottom
        {
            get { return _BorderBottom; }
            set { _BorderBottom = value; }
        }

        //private string _CellPoint;
        /// <summary>
        /// 起始位置
        /// </summary>
        //public string CellPoint
        //{
        //    get { return (char)_ColumnIndex + (char)_RowIndex; }
        //    set
        //    {
        //        string X = string.Empty;
        //        string Y = string.Empty;
        //        foreach (char c in value)
        //        {
        //            if (char.IsLetter(c)) X += c;
        //            else if (char.IsDigit(c)) Y += c;
        //            else return;
        //        }

        //        if (!string.IsNullOrEmpty(X)) _ColumnIndex = X;
        //        if (!string.IsNullOrEmpty(Y)) _RowIndex = Y;
        //    }
        //}
        private int _ColumnIndex = 0;
        /// <summary>
        /// 列索引
        /// </summary>
        public int ColumnIndex
        {
            get { return _ColumnIndex; }
            set { _ColumnIndex = value; }
        }
        private int _RowIndex = 0;
        /// <summary>
        /// 行索引
        /// </summary>
        public int RowIndex
        {
            get { return _RowIndex; }
            set { _RowIndex = value; }
        }
        private int _ColumnSpan = 1;
        /// <summary>
        /// 列跨度
        /// </summary>
        public int ColumnSpan
        {
            get { return _ColumnSpan; }
            set { _ColumnSpan = value; }
        }
        private int _RowSpan = 1;
        /// <summary>
        /// 行跨度
        /// </summary>
        public int RowSpan
        {
            get { return _RowSpan; }
            set { _RowSpan = value; }
        }

        private int _Width = 10;
        /// <summary>
        /// 行高
        /// </summary>
        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        private int _Height = 15;
        /// <summary>
        /// 列宽
        /// </summary>
        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        private object _CellValue;
        /// <summary>
        /// 单元格内容
        /// </summary>
        public object CellValue
        {
            get { return _CellValue; }
            set { _CellValue = value; }
        }
    }
}
