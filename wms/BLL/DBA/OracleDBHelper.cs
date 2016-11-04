using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using Sql.DataAccess;
using Sql.DataAccess.Client;
using Sql.DataAccess.Types;

/// <summary>
/// 数据库的通用访问代码
/// 此类为抽象类，不允许实例化，在应用时直接调用即可
/// </summary>
internal abstract class SqlDBHelper
{

    //获取数据库连接字符串，其属于静态变量且只读，项目中所有文档可以直接使用，但不能修改
    public static readonly string ConnectionStringLocalTransaction = ConfigurationManager.ConnectionStrings["ConnSqlWithAddress"].ConnectionString;
    //public static readonly string ConnectionStringLocalTransaction = ConfigurationManager.ConnectionStrings["ConnSql"].ConnectionString;
    //public static readonly string ConnectionStringLocalTransaction = "Password=123456;User ID=jxbarcode;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=jingxinwms)));";
    // 哈希表用来存储缓存的参数信息，哈希表可以存储任意类型的参数。
    private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

    /// <summary>
    ///执行一个不需要返回值的SqlCommand命令，通过指定专用的连接字符串。
    /// 使用参数数组形式提供参数列表 
    /// </summary>
    /// <remarks>
    /// 使用示例：
    ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">一个有效的数据库连接字符串</param>
    /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
    /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
    /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
    /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        
        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();

            //清空SqlCommand中的参数列表
            cmd.Parameters.Clear();
            conn.Close();
            return val;
        }
    }

    public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(ConnectionStringLocalTransaction))
        {
            //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();

            //清空SqlCommand中的参数列表
            cmd.Parameters.Clear();
            conn.Close();
            return val;
        }
    }
    public static int ExecuteNonQuery2(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中
            PrepareCommand2(cmd, conn, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();

            //清空SqlCommand中的参数列表
            cmd.Parameters.Clear();
            conn.Close();
            return val;
        }
    }

    public static int ExecuteNonQuery2( CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(ConnectionStringLocalTransaction))
        {
            //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中
            PrepareCommand2(cmd, conn, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();

            //清空SqlCommand中的参数列表
            cmd.Parameters.Clear();
            conn.Close();
            return val;
        }
    }

    /// <summary>
    ///执行一条不返回结果的SqlCommand，通过一个已经存在的数据库连接 
    /// 使用参数数组提供参数
    /// </summary>
    /// <remarks>
    /// 使用示例：  
    ///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="conn">一个现有的数据库连接</param>
    /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
    /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
    /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
    /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();

        PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
        int val = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        connection.Close();
        return val;
    }



    /// <summary>
    /// 执行一条不返回结果的SqlCommand，通过一个已经存在的数据库事物处理 
    /// 使用参数数组提供参数
    /// </summary>
    /// <remarks>
    /// 使用示例： 
    ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="trans">一个存在的 sql 事物处理</param>
    /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
    /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
    /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
    /// <returns>返回一个数值表示此SqlCommand命令执行后影响的行数</returns>
    public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
        int val = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return val;
    }



    /// <summary>
    /// 执行一条返回结果集的SqlCommand命令，通过专用的连接字符串。
    /// 使用参数数组提供参数
    /// </summary>
    /// <remarks>
    /// 使用示例：  
    ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">一个有效的数据库连接字符串</param>
    /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
    /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
    /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
    /// <returns>返回一个包含结果的SqlDataReader</returns>
    public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(ConnectionStringLocalTransaction);

        // 在这里使用try/catch处理是因为如果方法出现异常，则SqlDataReader就不存在，
        //CommandBehavior.CloseConnection的语句就不会执行，触发的异常由catch捕获。
        //关闭数据库连接，并通过throw再次引发捕捉到的异常。
        try
        {
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return rdr;
        }
        catch (Exception ex)
        {
            conn.Close();
            Console.WriteLine(ex.Message);

            throw;
        }
    }

    /// <summary>
    /// 执行一条返回第一条记录第一列的SqlCommand命令，通过专用的连接字符串。 
    /// 使用参数数组提供参数
    /// </summary>
    /// <remarks>
    /// 使用示例：  
    ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">一个有效的数据库连接字符串</param>
    /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
    /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
    /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
    /// <returns>返回一个object类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
    public static object ExecuteScalar( CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();

        using (SqlConnection connection = new SqlConnection(ConnectionStringLocalTransaction))
        {
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }
    }
    //CREATE BY XUP 特殊情况
    public static object ExecuteScalarTB(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        //判断数据库连接状态
        if (conn.State != ConnectionState.Open)
            conn.Open();

        cmd.Connection = conn;
        cmd.CommandText = cmdText;
        object val = cmd.ExecuteScalar();
        cmd.Parameters.Clear();
        return val;

    }

    /// <summary>
    /// 执行一条返回第一条记录第一列的SqlCommand命令，通过已经存在的数据库连接。
    /// 使用参数数组提供参数
    /// </summary>
    /// <remarks>
    /// 使用示例： 
    ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="conn">一个已经存在的数据库连接</param>
    /// <param name="commandType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
    /// <param name="commandText">存储过程的名字或者 T-SQL 语句</param>
    /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
    /// <returns>返回一个object类型的数据，可以通过 Convert.To{Type}方法转换类型</returns>
    public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();

        PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
        object val = cmd.ExecuteScalar();
        cmd.Parameters.Clear();
        connection.Close();
        return val;
    }




    /// <summary>
    /// 缓存参数数组
    /// </summary>
    /// <param name="cacheKey">参数缓存的键值</param>
    /// <param name="cmdParms">被缓存的参数列表</param>
    public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
    {
        parmCache[cacheKey] = commandParameters;
    }

    /// <summary>
    /// 获取被缓存的参数
    /// </summary>
    /// <param name="cacheKey">用于查找参数的KEY值</param>
    /// <returns>返回缓存的参数数组</returns>
    public static SqlParameter[] GetCachedParameters(string cacheKey)
    {
        SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

        if (cachedParms == null)
            return null;

        //新建一个参数的克隆列表
        SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

        //通过循环为克隆参数列表赋值
        for (int i = 0, j = cachedParms.Length; i < j; i++)
            //使用clone方法复制参数列表中的参数
            clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

        return clonedParms;
    }

    /// <summary>
    /// 为执行命令准备参数
    /// </summary>
    /// <param name="cmd">SqlCommand 命令</param>
    /// <param name="conn">已经存在的数据库连接</param>
    /// <param name="trans">数据库事物处理</param>
    /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
    /// <param name="cmdText">Command text，T-SQL语句 例如 Select * from Products</param>
    /// <param name="cmdParms">返回带参数的命令</param>
    private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
    {

        //判断数据库连接状态
        if (conn.State != ConnectionState.Open)
            conn.Open();

        cmd.Connection = conn;
        cmd.CommandText = cmdText;

        //判断是否需要事物处理
        if (trans != null)
            cmd.Transaction = trans;

        cmd.CommandType = cmdType;

        if (cmdParms != null)
        {
            foreach (SqlParameter parm in cmdParms)
            {

                if (parm.Value == null)
                {
                    parm.Value = DBNull.Value;

                }

                //switch (parm.SqlType)
                //{


                //    case SqlType.DateTime:
                //        cmd.CommandText = cmd.CommandText.Replace(parm.ParameterName + " ", "TO_DATE('" + parm.Value.ToString() + "','yyyy-mm-dd hh24:mi:ss' )");
                //        break;
                //    case SqlType.VarChar:
                //        cmd.CommandText = cmd.CommandText.Replace(parm.ParameterName + " ", "'" + parm.Value + "'");
                //        break;
                //    default:
                //        cmd.CommandText = cmd.CommandText.Replace(parm.ParameterName + " ", parm.Value.ToString());
                //        break;
                //}
                // cmd.Parameters.Add(parm);
            }
        }
    }

    private static void PrepareCommand2(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
    {

        //判断数据库连接状态
        if (conn.State != ConnectionState.Open)
            conn.Open();

        cmd.Connection = conn;
        cmd.CommandText = cmdText;

        //判断是否需要事物处理
        if (trans != null)
            cmd.Transaction = trans;

        cmd.CommandType = cmdType;

        if (cmdParms != null)
        {
            foreach (SqlParameter parm in cmdParms)
            {

                if (parm.Value == null)
                {
                    parm.Value = DBNull.Value;

                }


                cmd.Parameters.Add(parm);
            }
        }
    }

    public static DataSet ExecuteDataSet( CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(ConnectionStringLocalTransaction))
        {
            //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中 
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            //清空SqlCommand中的参数列表 
            cmd.Parameters.Clear();
            conn.Close();
            return ds; //注意:这里改了
        }
    }
    public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中 
            PrepareCommand2(cmd, conn, null, cmdType, cmdText, commandParameters);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            
            //清空SqlCommand中的参数列表 
            cmd.Parameters.Clear();
            conn.Close();
            
            return ds; //注意:这里改了
        }
    }

    public static DataSet ExecuteDataSetForCursor(ref int iResult, ref string strErrMsg, string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中 
            PrepareCommand2(cmd, conn, null, cmdType, cmdText, commandParameters);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            iResult = Int32.Parse(cmd.Parameters["bresult"].Value.ToString());
            strErrMsg = cmd.Parameters["ErrString"].Value.ToString();
            //清空SqlCommand中的参数列表 
            cmd.Parameters.Clear();
            conn.Close();

            return ds; //注意:这里改了
        }
    }
    public static DataSet ExecuteDataSetForCursor1(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中 
            PrepareCommand2(cmd, conn, null, cmdType, cmdText, commandParameters);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            //iResult = string.IsNullOrEmpty(cmd.Parameters["IsResult"].Value.ToString()) ? 0 : Int32.Parse(cmd.Parameters["IsResult"].Value.ToString());
            //清空SqlCommand中的参数列表 
            cmd.Parameters.Clear();
            conn.Close();

            return ds; //注意:这里改了
        }
    }
    //Create By xp
    public static int ExecuteNonQueryList(List<string> cmdTexts)
    {
        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(ConnectionStringLocalTransaction))
        {

            //判断数据库连接状态
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;

            SqlTransaction trans = conn.BeginTransaction();

            //判断是否需要事物处理
            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = System.Data.CommandType.Text;
            int val = -2;
            try
            {
                if (cmdTexts != null)
                {
                    foreach (string c in cmdTexts)
                    {
                        cmd.CommandText = c;
                        val = cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
            }
            catch (Exception)
            {
                val = -2;
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
                conn.Close();
            }

            return val;

        }

    }
    //Create By xp
    public static int ExecuteNonQueryList(List<string> cmdTexts, ref string strError)
    {
        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(ConnectionStringLocalTransaction))
        {

            //判断数据库连接状态
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;

            SqlTransaction trans = conn.BeginTransaction();

            //判断是否需要事物处理
            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = System.Data.CommandType.Text;
            int num = 0;
            int val = -2;
            try
            {
                if (cmdTexts != null)
                {
                    val = 0;
                    foreach (string c in cmdTexts)
                    {
                        num++;
                        cmd.CommandText = c;
                        val += cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                val = -2;
                strError = string.Format("执行第{0}条语句发生错误!{1}SQL:{2};{3}{4}", num, Environment.NewLine, cmdTexts[num - 1], Environment.NewLine, ex.Message);
                trans.Rollback();
                return val;
            }
            finally
            {
                trans.Dispose();
                conn.Close();
            }

            return val;

        }

    }

    public static int ExecuteNonQuery3(string connectionString, CommandType cmdType, string cmdText, List<SqlParameter[]> cmdParmsList)
    {
        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中
            //判断数据库连接状态
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            SqlTransaction trans = conn.BeginTransaction();
            //判断是否需要事物处理
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = cmdType;
            int val = -2;
            if (cmdParmsList != null)
            {
                try
                {
                    foreach (SqlParameter[] item in cmdParmsList)
                    {
                        PreCommand(item, cmd);
                        val = cmd.ExecuteNonQuery();
                        //清空SqlCommand中的参数列表
                        cmd.Parameters.Clear();
                    }
                    //trans.Commit();

                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
                finally
                {
                    trans.Dispose();
                    conn.Close();
                }

            }
            return val;
        }

    }

    private static void PreCommand(SqlParameter[] cmdParms, SqlCommand cmd)
    {
        foreach (SqlParameter parm in cmdParms)
        {

            if (parm.Value == null)
            {
                parm.Value = DBNull.Value;

            }

            //switch (parm.SqlType)
            //{
            //    case SqlType.DateTime:
            //        cmd.CommandText = cmd.CommandText.Replace(parm.ParameterName + " ", "TO_DATE('" + parm.Value.ToString() + "','yyyy-mm-dd hh24:mi:ss' )");
            //        break;
            //    case SqlType.VarChar:
            //        cmd.CommandText = cmd.CommandText.Replace(parm.ParameterName + " ", "'" + parm.Value + "'");
            //        break;
            //    case SqlType.NVarChar:
            //        cmd.CommandText = cmd.CommandText.Replace(parm.ParameterName + " ", "'" + parm.Value + "'");
            //        break;
            //    default:
            //        cmd.CommandText = cmd.CommandText.Replace(parm.ParameterName + " ", parm.Value.ToString());
            //        break;
            //}
        }
    }


    public static Array GetSqlArray(string SqlList, ArrayList ObjList)
    {
        Array list = null;
        if (ObjList == null || ObjList.Count <= 0)
        { }
        else
        { 
             
        }

        return list;
    }


}
