using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.P2B
{
    public class Preparation : Common.BasicInfo
    {
        public int ID { get; set; }
        /// <summary>
        /// 制法代码：2位工艺代码+2位流水号|如：FL20|
        /// FL：食用香精，FE：酊剂，EM：乳化香精，FR：日化香精，SP：副产品
        /// </summary>
        public string pCode { get; set; }
        /// <summary>
        /// 制法中文名称
        /// </summary>
        public string pName { get; set; }
        /// <summary>
        /// 所属建筑id
        /// </summary>
        public int bid { get; set; }
    }
}
