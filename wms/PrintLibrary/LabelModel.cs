using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintLibrary
{
    public class LabelModel
    {
        public bool isMul { get; set; }

        /// <summary>
        ///  label名称
        /// </summary>
        public string labelName { get; set; }

        /// <summary>
        /// text值
        /// </summary>
        public string textValue { get; set; }

        /// <summary>
        /// 直线
        /// </summary>
        public string line { get; set; }

        /// <summary>
        /// 条码内容
        /// </summary>
        public string barcodeValue { get; set; }

        /// <summary>
        /// 打印标签类型
        /// </summary>
        public string labelType { get; set; }

        /// <summary>
        /// 字体高度,PC上12号字体对应值为32
        /// </summary>
        public int fontHeight { get; set; }

        /// <summary>
        /// 字体宽度，值为0对应方块字
        /// </summary>
        public int fontWidth { get; set; }

        /// <summary>
        /// 直线的高度
        /// </summary>
        public string lineHeight { get; set; }

        /// <summary>
        /// 直线的宽度
        /// </summary>
        public string lineWidth { get; set; }

        /// <summary>
        /// 粗体
        /// </summary>
        public int Bold { get; set; }

        /// <summary>
        /// X轴
        /// </summary>
        public string loctionX { get; set; }

        /// <summary>
        /// Y轴
        /// </summary>
        public string loctionY { get; set; }

        /// <summary>
        /// 打印份数
        /// </summary>
        public int printCount { get; set; }
    }
}
