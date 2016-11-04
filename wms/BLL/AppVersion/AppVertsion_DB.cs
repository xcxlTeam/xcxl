using System.Data.SqlClient;
using System.Data;

namespace BLL.AppVersion
{
    class AppVertsion_DB
    {
        internal SqlDataReader GetAppVersionByVersion(AppVersionInfo model)
        {
            string strSql = string.Empty;
            strSql = string.Format("SELECT * FROM T_AppVersionLog WHERE AppName = '{0}' AND AppVersion = '{1}' ", model.AppName, model.AppVersion);

            return OperationSql.ExecuteReader(CommandType.Text, strSql, null);
        }
    }
}
