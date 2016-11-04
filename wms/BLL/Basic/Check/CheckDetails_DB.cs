using System;
using JXBLL.Common;
using System.Data.SqlClient;
using System.Data;

namespace JXBLL.Basic.Check
{
    internal class CheckDetails_DB
    {
        public SqlDataReader GetCheckDetailsByID(CheckDetailsInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM V_CheckDetails WHERE ID = {0}", model.ID);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }
    }
}
