using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.Common
{
    public class Common_DB
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page">分页方式</param>
        /// <param name="Tables">表名(视图名)</param>
        /// <param name="Filter">筛选条件</param>
        /// <param name="Fields">显示列</param>
        /// <param name="Sort">排序方式</param>
        /// <returns>查询结果</returns>
        //public static SqlDataReader QueryByDividPage(ref Common.DividPage page, string Tables, string Filter = "", string Fields = "*", string Sort = "Order by ID Desc")
        //{
        //    if (Fields.Trim() == "*") Fields = Tables + '.' + Fields;
        //    if (!string.IsNullOrEmpty(Filter.Trim()) && Filter.ToLower().IndexOf("where") < 0) Filter = "where " + Filter;

        //    if (page == null) page = new Common.DividPage();
        //    if (page.CurrentPageNumber <= 0) page.CurrentPageNumber = 1;
        //    int RecordCounts = 0;

        //    int TopNumber = page.CurrentPageShowCounts * page.CurrentPageNumber;
        //    int WhereNumber = (page.CurrentPageNumber - 1) * page.CurrentPageShowCounts;

        //    string strSqlRecordCounts = "Select Count(1) As recordcounts  From " + Tables + "  " + Filter;
        //    try
        //    {
        //        using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSqlRecordCounts))
        //        {
        //            if (dr.Read())
        //            {
        //                RecordCounts = int.Parse(dr["recordcounts"].ToString());
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //    }



        //    if (page.CurrentPageShowCounts < 0) page.CurrentPageShowCounts = TopNumber = RecordCounts;
        //    string strSql = "Select * From (Select ROW_NUMBER() OVER(@Sort) AS ROWNUMBER , @Fields  From  @Tables  @Filter ) a Where ROWNUMBER <= @TopNumber And ROWNUMBER > @WhereNumber ";


        //    strSql = strSql.Replace("@TopNumber", TopNumber.ToString());
        //    strSql = strSql.Replace("@Sort", Sort.ToString());
        //    strSql = strSql.Replace("@Fields", Fields.ToString());
        //    strSql = strSql.Replace("@Tables", Tables.ToString());
        //    strSql = strSql.Replace("@Filter", Filter.ToString());
        //    strSql = strSql.Replace("@WhereNumber", WhereNumber.ToString());

        //    SqlDataReader dR = OperationSql.ExecuteReader(CommandType.Text, strSql);

        //    page.RecordCounts = RecordCounts;
        //    if (page.RecordCounts > 0)
        //    {
        //        page.PagesCount = (RecordCounts + page.CurrentPageShowCounts - 1) / page.CurrentPageShowCounts;
        //        if (page.CurrentPageShowCounts == 1) page.CurrentPageRecordCounts = 1;
        //        else if (page.CurrentPageNumber < page.PagesCount) page.CurrentPageRecordCounts = page.CurrentPageShowCounts;
        //        else page.CurrentPageRecordCounts = RecordCounts % page.CurrentPageShowCounts;
        //    }
        //    else
        //    {
        //        page.PagesCount = 0;
        //        page.CurrentPageRecordCounts = 0;
        //    }

        //    return dR;
        //}

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page">分页方式</param>
        /// <param name="Tables">表名(视图名)</param>
        /// <param name="Filter">筛选条件</param>
        /// <param name="Fields">显示列</param>
        /// <param name="Sort">排序方式</param>
        /// <returns>查询结果</returns>
        public static SqlDataReader QueryByDividPage(ref Common.DividPage page, string Tables, string Filter = "", string Fields = "*", string Sort = "Order by ID Desc")
        {
            try
            {
                if (Fields.Trim() == "*") Fields = Tables + '.' + Fields;
                if (!string.IsNullOrEmpty(Filter.Trim()) && Filter.ToLower().IndexOf("where") < 0) Filter = "where " + Filter;

                if (page == null) page = new Common.DividPage() { CurrentPageShowCounts = -1 };
                if (page.CurrentPageNumber <= 0) page.CurrentPageNumber = 1;
                int RecordCounts = 0;

                int TopNumber = page.CurrentPageShowCounts * page.CurrentPageNumber;
                int WhereNumber = (page.CurrentPageNumber - 1) * page.CurrentPageShowCounts;

                string strSqlRecordCounts = "Select Count(1) As recordcounts  From " + Tables + "  " + Filter;
                if (strSqlRecordCounts.ToLower().IndexOf("group by") >= 0) strSqlRecordCounts = string.Format("Select Count(1) As recordcounts from ({0}) t", strSqlRecordCounts);
                try
                {
                    using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSqlRecordCounts))
                    {
                        if (dr.Read())
                        {
                            RecordCounts = int.Parse(dr["recordcounts"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                }



                if (page.CurrentPageShowCounts < 0) page.CurrentPageShowCounts = TopNumber = RecordCounts;
                //if (Filter.ToLower().IndexOf("group by") < 0)
                //{
                //    if (!string.IsNullOrEmpty(Filter.Trim())) Filter = string.Format("{0} and rownum <= {1}", Filter, (TopNumber + 10));
                //    else Filter = string.Format("where rownum <= {1}", Filter, (TopNumber + 10));
                //}
                string strSql = "Select * From (Select ROW_NUMBER() OVER(@Sort) AS PageRowNumber , @Fields  From  @Tables  @Filter ) t Where PageRowNumber <= @TopNumber And PageRowNumber > @WhereNumber ";


                strSql = strSql.Replace("@TopNumber", TopNumber.ToString());
                strSql = strSql.Replace("@Sort", Sort.ToString());
                strSql = strSql.Replace("@Fields", Fields.ToString());
                strSql = strSql.Replace("@Tables", Tables.ToString());
                strSql = strSql.Replace("@Filter", Filter.ToString());
                strSql = strSql.Replace("@WhereNumber", WhereNumber.ToString());

                SqlDataReader dR = OperationSql.ExecuteReader(CommandType.Text, strSql);

                page.RecordCounts = RecordCounts;
                if (page.RecordCounts > 0)
                {
                    if (page.CurrentPageShowCounts <= 0) page.PagesCount = 0;
                    else page.PagesCount = (RecordCounts + page.CurrentPageShowCounts - 1) / page.CurrentPageShowCounts;

                    if (page.CurrentPageNumber < page.PagesCount) page.CurrentPageRecordCounts = page.CurrentPageShowCounts;
                    else page.CurrentPageRecordCounts = RecordCounts % page.CurrentPageShowCounts;
                    if (page.CurrentPageRecordCounts == 0) page.CurrentPageRecordCounts = page.CurrentPageShowCounts;
                }
                else
                {
                    page.PagesCount = 0;
                    page.CurrentPageRecordCounts = 0;
                }

                return dR;
            }
            catch (Exception ex)
            {
                string strError = string.Empty;
                //Common_Func.IsOracleError(ex.Message, ref strError);
                throw new Exception(strError);
            }
        }

        //public static SqlDataReader QueryByDividPage(ref Common.DividPage page, string Tables, string Filter = "", string Fields = "*", string Sort = "Order by ID Desc")
        //{
        //    if (page == null) page = new Common.DividPage();
        //    if (page.CurrentPageNumber == 0) page.CurrentPageNumber = 1;
        //    int RecordCounts = 0;

        //    int TopNumber = page.CurrentPageShowCounts * page.CurrentPageNumber;
        //    int WhereNumber = (page.CurrentPageNumber - 1) * page.CurrentPageShowCounts;

        //    string strSqlRecordCounts = "select count(*) as recordcounts  from " + Tables + "  " + Filter;
        //    using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, strSqlRecordCounts))
        //    {
        //        if (dr.Read())
        //        {
        //            RecordCounts = int.Parse(dr["recordcounts"].ToString());
        //        }
        //    }



        //    string strSql = "select   *   from  (select top @TopNumber ROW_NUMBER()   OVER   (@Sort)   AS   ROWNUM , @Fields  from  @Tables @Filter ) t   ";
        //    strSql += " where  ROWNUM > @WhereNumber";

        //    strSql = strSql.Replace("@TopNumber", TopNumber.ToString());
        //    strSql = strSql.Replace("@Sort", Sort.ToString());
        //    strSql = strSql.Replace("@Fields", Fields.ToString());
        //    strSql = strSql.Replace("@Tables", Tables.ToString());
        //    strSql = strSql.Replace("@Filter", Filter.ToString());
        //    strSql = strSql.Replace("@WhereNumber", WhereNumber.ToString());

        //    SqlDataReader dR = OperationSql.ExecuteReader(CommandType.Text, strSql);

        //    page.RecordCounts = RecordCounts;
        //    if (page.RecordCounts > 0)
        //    {
        //        page.PagesCount = (RecordCounts + page.CurrentPageShowCounts - 1) / page.CurrentPageShowCounts;


        //    }
        //    else
        //    {
        //        page.PagesCount = 0;
        //        page.CurrentPageRecordCounts = 0;
        //    }

        //    return dR;
        //}

        public static SqlDataReader QueryAll(string Tables, string Filter = "", string Fields = "*", string Sort = "Order by ID Desc")
        {
            if (Fields.Trim() == "*") Fields = Tables + '.' + Fields;
            if (!string.IsNullOrEmpty(Filter.Trim()) && Filter.ToLower().IndexOf("where") < 0) Filter = "where " + Filter;

            string strSql = "Select @Fields  From  @Tables  @Filter @Sort ";


            strSql = strSql.Replace("@Sort", Sort.ToString());
            strSql = strSql.Replace("@Fields", Fields.ToString());
            strSql = strSql.Replace("@Tables", Tables.ToString());
            strSql = strSql.Replace("@Filter", Filter.ToString());

            SqlDataReader dR = OperationSql.ExecuteReader(CommandType.Text, strSql);
            return dR;
        }
    }
}
