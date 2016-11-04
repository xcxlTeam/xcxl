using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class TempMaterial_Func
    {
        public bool GetTempMaterialByTempNo(string strMaterialDoc, ref TempMaterial tm, ref string strErrMsg)
        {
            bool bSucc = false;
            strErrMsg = string.Empty;
            TempMaterial_DB db = new TempMaterial_DB();
            try
            {
                tm = db.GetTempMaterialByTempNo(strMaterialDoc);
                if(tm != null)
                {
                    bSucc = true;
                }
                return bSucc;
            }
            catch (Exception ex)
            {
                bSucc = false;
                strErrMsg = ex.Message;
                return bSucc;
            }
        }
    }
}
