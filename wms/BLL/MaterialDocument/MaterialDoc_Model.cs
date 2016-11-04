using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BLL.MaterialDocument
{
    [Serializable]
    public class MaterialDoc_Model
    {
        /// <summary>
        /// 物料凭证号
        /// </summary>   
        
        public string MaterialDoc { get; set; }

        /// <summary>
        /// 凭证年度
        /// </summary>
        
        public string MaterialDocDate { get; set; }

        /// <summary>
        /// 凭证记账日期
        /// </summary>
        
        public DateTime MaterialDocPost { get; set; }

        /// <summary>
        /// 凭证类型
        /// </summary>
        
        public int MaterialDocType { get; set; }
    }
}
