using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Basic.P2B
{
    public class Building : Common.BasicInfo
    {
        public int ID { get; set; }
        /// <summary>
        /// 建筑名称
        /// </summary>
        public string bName { get; set; }
        /// <summary>
        /// 建筑编号
        /// </summary>
        public string bNo { get; set; }
        /// <summary>
        /// 优先级
        /// </summary>
        public int iGrade { get; set; }
        /// <summary>
        /// 包含制法
        /// </summary>
        public List<Preparation> lstP { get; set; }
        /// <summary>
        /// 对应仓库编号
        /// </summary>
        public string WareHouseNo { get; set; }
    }
}
