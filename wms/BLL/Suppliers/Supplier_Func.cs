using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Supplier
{
    public class Supplier_Func
    {
        public bool GetSupplierInfoForU8(ref Supplier_Model SupplierInfo, ref string strErrMsg) 
        {
            try
            {
                Supplier_U8 SLA = new Supplier_U8();
                return SLA.GetSupplierInfoForU8(ref SupplierInfo,ref strErrMsg);
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;

            }
        }
    }
}
