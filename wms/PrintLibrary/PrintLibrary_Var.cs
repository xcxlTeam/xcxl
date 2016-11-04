using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintLibrary
{
    public class PrintLibrary_Var
    {
        public const string strWebAddress = "http://www.scg.com?";
        public const string InnerVersion = "B";
        public const string OutVersion = "A";
        public const string TrayVersion = "T";

    }

    public enum PrinterStatus
    {
        其他状态 = 1,
        未知,
        空闲,
        正在打印,
        预热,
        停止打印,
        打印中,
        离线,
        未找到,
        错误
    }
}
