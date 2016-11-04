using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class TempMaterial_DB
    {
        public TempMaterial GetTempMaterialByTempNo(string TempMaterialNo)
        {
            try
            {
                TempMaterial TM = new TempMaterial();

                string strSql = string.Format("select * from T_TEMPMATERIAL where TEMPMATERIALNO = '{0}'", TempMaterialNo);

                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        TM.TempMaterialNo = dr["TEMPMATERIALNO"].ToString();
                        TM.TempMaterialDesc = dr["TEMPMATERIALDESC"].ToString();
                        TM.MaterialNo = dr["MATERIALNO"].ToString();
                        TM.MaterialDesc = dr["MATERIALDESC"].ToString();
                        return TM;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
