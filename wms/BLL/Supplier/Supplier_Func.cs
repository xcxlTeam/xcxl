using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXBLL.Supplier
{
    public class Supplier_Func
    {
        public bool GetSupplierInfoForSAP(ref Supplier_Model SupplierInfo, ref string strErrMsg) 
        {
            try
            {
                Supplier_SAP SLA = new Supplier_SAP();
                return SLA.GetSupplierInfoForSAP(ref SupplierInfo,ref strErrMsg);
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;

            }
        }
    }
}
