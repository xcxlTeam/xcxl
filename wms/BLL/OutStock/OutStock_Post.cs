using BLL.Basic.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.OutStock
{
    public class OutStock_Post
    {
        public virtual bool GetMaterialRequestInfoForSAP(ref OutStock_Model outStockModel, UserInfo userModel, ref string strErrMsg)
        {
            return true;
        }
    }
}
