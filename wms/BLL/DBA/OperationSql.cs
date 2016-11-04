using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;

/// <summary>
/// 数据库的通用访问代码
/// 此类为抽象类，不允许实例化，在应用时直接调用即可
/// </summary>
internal abstract class OperationSql
{

    //获取数据库连接字符串，其属于静态变量且只读，项目中所有文档可以直接使用，但不能修改
    public static readonly string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

    // 哈希表用来存储缓存的参数信息，哈希表可以存储任意类型的参数。
    private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

    #region U8连接字符串
    private static string _U8ConnStr;
    /// <summary>
    /// U8连接字符串
    /// </summary>
    public static string U8ConnStr
    {
        get
        {
            if (string.IsNullOrEmpty(_U8ConnStr))
            {
                _U8ConnStr = "user id=" + GetU8BaseInfo().sqlUser + ";password=" + GetU8BaseInfo().sqlPassword + ";data source='" + GetU8BaseInfo().DBService
                        + "';persist security info=True;initial catalog=UFDATA_" + GetU8BaseInfo().accID + "_" + GetU8BaseInfo().year;
            }
            return _U8ConnStr;
        }
    }

    public struct info
    {
        public string sqlUser;
        public string sqlPassword;
        public string DBService;
        public string accID;
        public int year;
    }
    public static info GetU8BaseInfo()
    {
        info inf = new info();
        inf.accID = ConfigurationManager.AppSettings.Get("Accid");
        inf.year = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Year"));
        inf.sqlUser = ConfigurationManager.AppSettings.Get("SqlUser");
        inf.sqlPassword = ConfigurationManager.AppSettings.Get("SqlPassword");
        inf.DBService = ConfigurationManager.AppSettings.Get("DBService");
        return inf;
    }
    #endregion

    // 执行非查询SQL语句
    static public int ExecuteSql(string sqlString, out string errMsg)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        //SqlDataAdapter adp = new SqlDataAdapter();
        errMsg = "";
        int res;
        conn.ConnectionString = connectionString;
        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            errMsg = ex.Message;
            //errMsg = conn.ConnectionString;
            return -1;
        }
        cmd.Connection = conn;
        cmd.CommandText = sqlString;
        try
        {
            res = cmd.ExecuteNonQuery();               //执行非查询SQL语句
        }
        catch (Exception ex)
        {
            errMsg = ex.ToString();
            res = 0;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        if (res == 0)
        {
            return -1;
        }
        else
            return 0;
    }

    // 执行非查询SQL语句
    static public int ExecuteSqlForU8(string sqlString, out string errMsg)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        //SqlDataAdapter adp = new SqlDataAdapter();
        errMsg = "";
        int res;
        conn.ConnectionString = U8ConnStr;
        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            errMsg = ex.Message;
            //errMsg = conn.ConnectionString;
            return -1;
        }
        cmd.Connection = conn;
        cmd.CommandText = sqlString;
        try
        {
            res = cmd.ExecuteNonQuery();               //执行非查询SQL语句
        }
        catch (Exception ex)
        {
            errMsg = ex.ToString();
            res = 0;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        if (res == 0)
        {
            return -1;
        }
        else
            return 0;
    }

    /// <summary>
    /// 查看SQL语句是否能找到数据
    /// </summary>
    /// <param name="sqlString">sql语句</param>
    /// <param name="connectionString">数据库连接语句</param>
    /// <param name="retBool">有数据返回true,没有 false</param>
    /// <param name="errMsg">错误信息</param>
    /// <returns>0正确:非0 错误</returns>
    static public bool GetBool(string sqlString, out bool retBool, out string errMsg)
    {

        SqlDataReader Reader = null;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        errMsg = "";
        conn.ConnectionString = connectionString;
        retBool = false;
        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            errMsg = ex.Message;
            return false;
            //errMsg = conn.ConnectionString;
        }
        cmd.Connection = conn;
        cmd.CommandText = sqlString;
        try
        {
            Reader = cmd.ExecuteReader();        //执行SQL语句
            if (Reader.Read())
            {
                retBool = true;
            }
            else
                retBool = false;
            return false;
        }
        catch (Exception ex)
        {
            errMsg = ex.ToString();
            return false;
        }
        finally
        {
            conn.Dispose();
            conn.Close();
        }
    }

    /// <summary>
    /// 查看SQL语句是否能找到数据
    /// </summary>
    /// <param name="sqlString">sql语句</param>
    /// <param name="connectionString">数据库连接语句</param>
    /// <param name="retBool">有数据返回true,没有 false</param>
    /// <param name="errMsg">错误信息</param>
    /// <returns>0正确:非0 错误</returns>
    static public bool GetBoolForU8(string sqlString, out bool retBool, out string errMsg)
    {

        SqlDataReader Reader = null;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        errMsg = "";
        conn.ConnectionString = U8ConnStr;
        retBool = false;
        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            errMsg = ex.Message;
            return false;
            //errMsg = conn.ConnectionString;
        }
        cmd.Connection = conn;
        cmd.CommandText = sqlString;
        try
        {
            Reader = cmd.ExecuteReader();        //执行SQL语句
            if (Reader.Read())
            {
                retBool = true;
            }
            else
                retBool = false;
            return false;
        }
        catch (Exception ex)
        {
            errMsg = ex.ToString();
            return false;
        }
        finally
        {
            conn.Dispose();
            conn.Close();
        }
    }

    /// <summary>
    /// 测试连接
    /// </summary>
    /// <param name="connectionString"></param>
    /// <param name="errMsg"></param>
    /// <returns></returns>
    static public bool Connect(out string errMsg)
    {

        SqlConnection conn = new SqlConnection();
        errMsg = "";
        conn.ConnectionString = connectionString;
        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            errMsg = ex.Message;
            return false;
        }
        finally
        {
            conn.Dispose();
            conn.Close();
        }
        return true;
    }

    /// <summary>
    /// 通通过一个SQL查找一个string数据
    /// </summary>
    /// <param name="sqlString">sql语句</param>
    /// <param name="connectionString">数据库连接语句</param>
    /// <param name="retString">查找到的string</param>
    /// <param name="errMsg">错误信息</param>
    /// <returns>0正确:非0 错误</returns>
    static public int GetString(string sqlString, out string retString, out string errMsg)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        retString = "";
        errMsg = "";
        conn.ConnectionString = connectionString;
        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            errMsg = ex.Message;
            //errMsg = conn.ConnectionString;
            return -1;
        }
        cmd.Connection = conn;
        cmd.CommandText = sqlString;
        try
        {
            retString = cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            errMsg = ex.ToString();
            return -2;
        }
        finally
        {
            conn.Dispose();
            conn.Close();
        }
        return 0;

    }

    /// <summary>
    /// 通通过一个SQL查找一个string数据
    /// </summary>
    /// <param name="sqlString">sql语句</param>
    /// <param name="connectionString">数据库连接语句</param>
    /// <param name="retString">查找到的string</param>
    /// <param name="errMsg">错误信息</param>
    /// <returns>0正确:非0 错误</returns>
    static public int GetStringForU8(string sqlString, out string retString, out string errMsg)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        retString = "";
        errMsg = "";
        conn.ConnectionString = U8ConnStr;
        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            errMsg = ex.Message;
            //errMsg = conn.ConnectionString;
            return -1;
        }
        cmd.Connection = conn;
        cmd.CommandText = sqlString;
        try
        {
            retString = cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            errMsg = ex.ToString();
            return -2;
        }
        finally
        {
            conn.Dispose();
            conn.Close();
        }
        return 0;

    }


    /// <summary>
    /// 通过SQL返回DATASET
    /// </summary>
    /// <param name="sqlString">SQL语句</param>
    /// <param name="connectionString">数据库连接语句</param>
    /// <param name="result">返回的DATASET</param>
    /// <param name="errMsg">出错信息</param>
    /// <returns>0：正确 非0：错误</returns>
    static public int GetDataset(string sqlString, out DataSet result, out string errMsg)
    {
        errMsg = "";
        result = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter adp = new SqlDataAdapter();
        conn.ConnectionString = connectionString;
        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            errMsg = ex.Message;
            return -1;
        }
        cmd.Connection = conn;
        cmd.CommandText = sqlString;
        adp.SelectCommand = cmd;
        try
        {
            adp.Fill(result);
            conn.Close();
            conn.Dispose();
            return 0;
        }
        catch (Exception ex)
        {
            errMsg = ex.Message;
            conn.Dispose();
            conn.Close();
            return -1;
        }
    }

    /// <summary>
    /// 通过SQL返回DATASET
    /// </summary>
    /// <param name="sqlString">SQL语句</param>
    /// <param name="connectionString">数据库连接语句</param>
    /// <param name="result">返回的DATASET</param>
    /// <param name="errMsg">出错信息</param>
    /// <returns>0：正确 非0：错误</returns>
    static public int GetDatasetForU8(string sqlString, out DataSet result, out string errMsg)
    {
        errMsg = "";
        result = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter adp = new SqlDataAdapter();
        conn.ConnectionString = U8ConnStr;
        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            errMsg = ex.Message;
            return -1;
        }
        cmd.Connection = conn;
        cmd.CommandText = sqlString;
        adp.SelectCommand = cmd;
        try
        {
            adp.Fill(result);
            conn.Close();
            conn.Dispose();
            return 0;
        }
        catch (Exception ex)
        {
            errMsg = ex.Message;
            conn.Dispose();
            conn.Close();
            return -1;
        }
    }
    #region 对应oracle帮助类

    private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
    {
        if (conn.State != ConnectionState.Open)
            conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = cmdText;
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


    public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
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

    public static int ExecuteNonQueryForU8(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(U8ConnStr))
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

    public static int ExecuteNonQuery2(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中
            PrepareCommand2(cmd, conn, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();

            ////清空SqlCommand中的参数列表
            //cmd.Parameters.Clear();
            conn.Close();
            return val;
        }
    }

    public static int ExecuteNonQuery2ForU8(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(U8ConnStr))
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


    public static DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中 
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            SqlDataReader reader = cmd.ExecuteReader();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            //清空SqlCommand中的参数列表 
            cmd.Parameters.Clear();
            conn.Close();
            return ds; //注意:这里改了
        }
    }

    public static DataSet ExecuteDataSetForU8(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(U8ConnStr))
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

        using (SqlConnection conn = new SqlConnection(connectionString))
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

        using (SqlConnection conn = new SqlConnection(connectionString))
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
        SqlConnection conn = new SqlConnection(connectionString);
        cmd.CommandTimeout = 60;
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
    public static SqlDataReader ExecuteReaderForU8(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(U8ConnStr);

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
    public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
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
    public static object ExecuteScalarForU8(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();

        using (SqlConnection connection = new SqlConnection(U8ConnStr))
        {
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }
    }

    #endregion

}
