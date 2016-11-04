using BLL.Common;
using BLL.Material;
using BLL.PrintBarcode;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace BLL.Stock
{
    public class Stock_DB
    {
        public List<Stock_Model> GetStockByMaterialNo(string strMaterialNo)
        {
            try
            {
                List<Stock_Model> lstStock = new List<Stock_Model>();

                string strSql = string.Format("select * from v_getstockbymaterialno where materialno = '{0}'", strMaterialNo);

                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        Stock_Model stockModel = new Stock_Model();
                        stockModel.MaterialNo = dr["materialno"].ToDBString();
                        stockModel.AreaNo = dr["areano"].ToDBString();
                        stockModel.MaterialDesc = dr["materialdesc"].ToDBString();
                        stockModel.Qty = dr["qty"].ToDouble();
                        lstStock.Add(stockModel);
                    }
                }
                return lstStock;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Stock_Model> GetCapacity(QueryConditions list)
        {
            if (list==null)
            {
                return null;
            }
            try
            {
                List<Stock_Model> lstStock = new List<Stock_Model>();

                string strSql = @"select T.materialno,T.materialdesc,T.materialstd,T.ProductLineNo
                                , SUM(T.ErpQty) ErpQty, SUM(T.SaveQty) SaveQty, SUM(T.trayQty) trayQty, SUM(T.ErpQty + T.SaveQty + T.trayQty) TotalQty
                                 from (
                                select b.materialno, b.materialdesc, b.materialstd, a.ProductLineNo
                                , SUM(b.qty) trayQty, 0 SaveQty, 0 ErpQty
                                 from T_TRAY a
                                join T_OUTBARCODE b on a.ID = b.TRAYID
                                where 1 = 1 and ISNULL(b.iFlag, 0) = 0
                                --0and a.ProductLineNo = @ProductLineNo
                                --1and b.MaterialNo=@MaterialNo
                                --2and a.lastModifyDt>=@BeginDate 
                                --3and a.lastModifyDt<=@EndDate
                                --4and b.materialdesc like @MaterialDesc
                                --5and b.materialstd like @MaterialStd
                                --6and b.VoucherNo=@VoucherNo
                                group by b.materialno, b.materialdesc, b.materialstd, a.ProductLineNo
                                union all
                                select a.materialno, a.materialdesc, a.materialstd, b.ProductLineNo
                                , 0 trayQty, SUM(a.qty) SaveQty, 0 ErpQty
                                 from T_ProductInDetails a
                                join T_ProductInRecord b on a.ID = b.ID
                                where 1 = 1 and b.cstate = -1
                                --0and b.ProductLineNo = @ProductLineNo
                                --1and a.MaterialNo=@MaterialNo
                                --2and b.lastupdatetime>=@BeginDate 
                                --3and b.lastupdatetime<=@EndDate
                                --4and a.materialdesc like @MaterialDesc
                                --5and a.materialstd like @MaterialStd
                                --6and b.VoucherNo=@VoucherNo
                                group by a.materialno, a.materialdesc, a.materialstd, b.ProductLineNo
                                union all
                                select a.materialno, a.materialdesc, a.materialstd, b.ProductLineNo
                                , 0 trayQty, 0 SaveQty, SUM(a.qty) ErpQty
                                 from T_ProductInDetails a
                                join T_ProductInRecord b on a.ID = b.ID
                                where 1 = 1 and b.cstate = 0
                                --0and b.ProductLineNo = @ProductLineNo
                                --1and a.MaterialNo=@MaterialNo
                                --2and b.lastupdatetime>=@BeginDate 
                                --3and b.lastupdatetime<=@EndDate
                                --4and a.materialdesc like @MaterialDesc
                                --5and a.materialstd like @MaterialStd
                                --6and b.VoucherNo=@VoucherNo
                                group by a.materialno, a.materialdesc, a.materialstd, b.ProductLineNo
                                ) T
                                GROUP BY T.materialno, T.materialdesc, T.materialstd,T.ProductLineNo";
                if(!string.IsNullOrEmpty(list.ProductLineNo))
                {
                    strSql = strSql.Replace("--0", "").Replace("@ProductLineNo", list.ProductLineNo.ToSelSqlString());
                }
                if (!string.IsNullOrEmpty(list.MaterialNo))
                {
                    strSql = strSql.Replace("--1", "").Replace("@MaterialNo", list.MaterialNo.ToSelSqlString());
                }
                if (list.StartTime!=null)
                {
                    string BeginDate = list.StartTime.ToDateTime().ToString("yyyy-MM-dd");
                    strSql = strSql.Replace("--2", "").Replace("@BeginDate", BeginDate.ToSelSqlString());
                }
                if (list.EndTime!=null)
                {
                    string EndDate = list.EndTime.ToDateTime().AddDays(1).ToString("yyyy-MM-dd");
                    strSql = strSql.Replace("--3", "").Replace("@EndDate", EndDate.ToSelSqlString());
                }
                if (!string.IsNullOrEmpty(list.MaterialNo))
                {
                    strSql = strSql.Replace("--4", "").Replace("@MaterialDesc", list.MaterialDesc.ToLikeSqlString());
                }
                if (!string.IsNullOrEmpty(list.MaterialStd))
                {
                    strSql = strSql.Replace("--5", "").Replace("@MaterialStd", list.MaterialStd.ToLikeSqlString());
                }
                if (!string.IsNullOrEmpty(list.VoucherNo))
                {
                    strSql = strSql.Replace("--6", "").Replace("@VoucherNo", list.VoucherNo.ToSelSqlString());
                }
                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        Stock_Model stockModel = new Stock_Model();
                        stockModel.ProductLineNo= dr["ProductLineNo"].ToDBString();
                        stockModel.MaterialNo = dr["materialno"].ToDBString();
                        stockModel.MaterialDesc = dr["materialdesc"].ToDBString();
                        stockModel.MaterialStd= dr["materialstd"].ToDBString();
                        stockModel.TotalQty = dr["TotalQty"].ToDouble();
                        stockModel.TrayQty = dr["TrayQty"].ToDouble();
                        stockModel.SaveQty = dr["SaveQty"].ToDouble();
                        stockModel.ErpQty = dr["ErpQty"].ToDouble();

                        lstStock.Add(stockModel);
                    }
                }
                return lstStock;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Stock_Model> GetStockBySerialNo(string strSerialNo)
        {
            try
            {
                List<Stock_Model> lstStock = new List<Stock_Model>();

                string strSql = string.Format(@"SELECT b.qty,a.materialno,a.materialdesc,a.materialstd,b.areano,b.warehouseno,b.houseno,
  c.warehousename,d.housename,e.areaname
  FROM[Barcode].[dbo].[T_OUTBARCODE] a
  join[Barcode].[dbo].[T_STOCK] b on a.serialno = b.serialno
  left join [Barcode].[dbo].[T_AREA] e on e.areano=b.areano
  left join [Barcode].[dbo].[T_house] d on d.id=e.houseid
  left join [Barcode].[dbo].[T_warehouse] c on c.id=d.warehouseid
  where a.serialno = '{0}'", strSerialNo);

                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        Stock_Model stockModel = new Stock_Model();
                        stockModel.MaterialNo = dr["materialno"].ToDBString();
                        stockModel.AreaNo = dr["areano"].ToDBString();
                        stockModel.MaterialDesc = dr["materialdesc"].ToDBString();
                        stockModel.MaterialStd= dr["MaterialStd"].ToDBString();
                        stockModel.AreaName= dr["AreaName"].ToDBString();
                        stockModel.HouseName = dr["HouseName"].ToDBString();
                        stockModel.WarehouseName = dr["WarehouseName"].ToDBString();
                        stockModel.HouseNo = dr["HouseNo"].ToDBString();
                        stockModel.WarehouseNo = dr["WarehouseNo"].ToDBString();

                        stockModel.Qty = dr["qty"].ToDouble();
                        stockModel.SerialNo = strSerialNo;
                        lstStock.Add(stockModel);
                    }
                }
                return lstStock;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Stock_Model> GetStockByArrayMaterialNo(string VoucherNo, string strArrayMaterialNo)
        {
            string strMaterialNo = "";
            string[] ArrayMaterialNo = strArrayMaterialNo.Split(',');
            foreach (var item in ArrayMaterialNo)
            {
                if (string.IsNullOrEmpty(strMaterialNo))
                {
                    strMaterialNo = "N'" + item + "'";
                }
                else
                    strMaterialNo += (",N'" + item + "'");
            }
            try
            {
                List<Stock_Model> lstStock = new List<Stock_Model>();
                string strSql = "";
                if (string.IsNullOrEmpty(VoucherNo))
                {
                    strSql = @"select * from v_getstockbymaterialno  where 1=1 and materialno in (" + strMaterialNo + ")";
                }
                else
                {
                    strSql = @"select a.materialno,a.materialdesc,b.materialstd,warehouseno,areano,b.voucherno,ISNULL(sum(a.qty),0) qty from T_STOCK a join T_OUTBARCODE b on a.serialno=b.serialno
                            where a.materialno in (" + strMaterialNo + ") and b.voucherno='" + VoucherNo + "' group by a.materialno,a.materialdesc,b.materialstd,warehouseno,areano,b.voucherno";
                }

                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        Stock_Model stockModel = new Stock_Model();
                        stockModel.MaterialNo = dr["materialno"].ToDBString();
                        stockModel.AreaNo = dr["areano"].ToDBString();
                        stockModel.MaterialDesc = dr["materialdesc"].ToDBString();
                        stockModel.MaterialStd= dr["materialstd"].ToDBString();

                        stockModel.Qty = dr["qty"].ToDouble();
                        if (!string.IsNullOrEmpty(VoucherNo))
                            stockModel.VoucherNo = dr["VoucherNo"].ToDBString();
                        lstStock.Add(stockModel);
                    }
                }
                return lstStock;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Stock_Model> GetStockByAreaNo(string strAreaNo)
        {
            try
            {
                string strSql = "select (case when materialno is null then tmaterialno else materialno end) as materialno,(case when materialdesc is null then tmaterialdesc else materialdesc end) as materialdesc,sum(QTY) as qty from t_stock where areano ='{0}' " +
                            "group by materialno,materialdesc,tmaterialno,tmaterialdesc";
                strSql = string.Format(strSql, strAreaNo);
                List<Stock_Model> lstStock = new List<Stock_Model>();

                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        Stock_Model SM = new Stock_Model();
                        SM.MaterialNo = dr["materialno"].ToDBString();
                        SM.MaterialDesc = dr["materialdesc"].ToDBString();
                        SM.Qty = dr["qty"].ToDouble();
                        lstStock.Add(SM);
                    }
                }
                return lstStock;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal bool CheckImportTable(ref string strError)
        {
            try
            {
                string sql = @"
                create table T_P_ImportStock
                (
                  stockid       NUMBER,
                  outbarcodeid  NUMBER,
                  barcode       NVARCHAR2(100),
                  serialno      NVARCHAR2(50),
                  materialno    NVARCHAR2(50),
                  materialdesc  NVARCHAR2(50),
                  isrohs        NUMBER,
                  warehouseno   NVARCHAR2(20),
                  houseno       NVARCHAR2(20),
                  areano        NVARCHAR2(20),
                  qty           NUMBER,
                  tmaterialno   NVARCHAR2(50),
                  tmaterialdesc NVARCHAR2(50),
                  pickareano    NVARCHAR2(20),
                  celareano     NVARCHAR2(20),
                  status        NUMBER,
                  isdel         NUMBER,
                  batchno       NVARCHAR2(30),
                  sn            NVARCHAR2(30),
                  importstatus  NUMBER,
                  importuser    NVARCHAR2(50),
                  importdate    DATE
                )
                ";

                OperationSql.ExecuteNonQuery2(CommandType.Text, sql);
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("ORA-00955") >= 0)
                    return true;
                strError = (ex.Message);
                return false;
            }
        }

        //internal bool DealImport(ref string strError)
        //{
        //    if (!UpdateSapMaterial(ref strError)) return false;

        //    strError = string.Empty;
        //    //SqlParameter[] para = new SqlParameter[]{
        //    //new SqlParameter("ErrStrng",SqlDbType.NVarChar,200,ParameterDirection.Output,true,0,0,"ErrStrng",DataRowVersion.Default,strError)
        //    //};
        //    //OperationSql.ExecuteNonQuery2( CommandType.StoredProcedure, "Proc_ImportStock", para);
        //    //strError = para[para.Length - 1].Value.ToString();

        //    if (string.IsNullOrEmpty(strError))
        //    {
        //        return true;
        //    }
        //    else if (strError.ToLower() == "null")
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //private bool UpdateSapMaterial(ref string strError)
        //{
        //    List<Barcode_Model> lstBarcode = new List<Barcode_Model>();
        //    using (SqlDataReader dr = OperationSql.ExecuteReader(CommandType.Text, "SELECT MATERIALNO FROM T_P_IMPORTSTOCK WHERE MATERIALDESC IS NULL AND ROWNUM <= 5000 GROUP BY MATERIALNO", null))
        //    {
        //        while (dr.Read())
        //        {
        //            lstBarcode.Add(new Barcode_Model() { MATERIALNO = dr["MATERIALNO"].ToDBString() });
        //        }

        //        dr.Close();
        //    }
        //    if (lstBarcode == null || lstBarcode.Count <= 0) return true;

        //    List<Material_Model> lstMaterial = new List<Material_Model>();
        //    Material_SAP materialSap = new Material_SAP();
        //    if (!materialSap.GetMaterialInfoForSAPByBarcode(lstBarcode, ref lstMaterial, ref strError)) return false;
        //    if (lstMaterial == null || lstMaterial.Count <= 0) return false;

        //    List<string> lstSql = new List<string>();
        //    foreach (Material_Model material in lstMaterial)
        //    {
        //        lstSql.Add(string.Format("UPDATE T_P_IMPORTSTOCK SET MATERIALDESC = '{0}', ISROHS = {1} WHERE MATERIALNO = '{2}'", material.MaterialDesc, material.ROHS == "ROHS" ? 2 : 1, material.MaterialNo));
        //    }
        //    if (lstSql == null || lstSql.Count <= 0) return true;

        //    int OnceImportSize = 500;
        //    List<string> lstTemp = new List<string>();
        //    while (lstSql.Count >= OnceImportSize)
        //    {
        //        lstTemp =(lstSql.GetRange(0, OnceImportSize-1));
        //        if (OperationSql.ExecuteNonQueryList(lstTemp, ref strError) <=0)
        //        {
        //            return false;
        //        }
        //        lstSql.RemoveRange(0, OnceImportSize - 1);
        //    }

        //    if (lstSql.Count >= 1)
        //    {
        //        lstTemp = lstSql;
        //        if (OperationSql.ExecuteNonQueryList(lstTemp, ref strError) <= 0)
        //        {
        //            return false;
        //        }
        //    }

        //    object o = OperationSql.ExecuteScalar(CommandType.Text, "select count(1) from (SELECT MATERIALNO FROM T_P_IMPORTSTOCK WHERE MATERIALDESC IS NULL GROUP BY MATERIALNO )", null);
        //    if (o.ToInt32() >= 1)
        //    {
        //        strError = "还有未更新完的物料信息";
        //        return false;
        //    }
        //    return true;
        //}

        public bool GetSaleBillVouchCodeByCustomer(string ccusname, out List<string> list, out string strErrMsg)
        {
            try
            {
                list = new List<string>();
                string strSql = "select csbvcode from SaleBillVouchZT where ccusname like '%" + ccusname + "%' and cSource=N'销售' and ivouchstate='Opening' and iverifystate=0 and isnull(bReturnFlag,0)<>1 ";
                using (SqlDataReader dr = OperationSql.ExecuteReaderForU8(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        list.Add(dr["csbvcode"].ToDBString());
                    }
                }
                strErrMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                list = null;
                return false;
            }
        }
        
        public bool GetSaleBillVouchByCode(string code, out SaleBillVouch_Model model,out string strErrMsg)
        {
            try
            {
                string strSql = @"Select SaleBillVouchZW.cSOCode as ssocode,csbvcode as ssbvcode, SaleBillVouchZW.sbvid, SaleBillVouchZW.autoid,SaleBillVouchZW.SBVID,SO_SODetails.iquantity as ssoqty,SaleBillVouchZW.iquantity as ssbvqty,cWhCode,cWhName,SaleBillVouchZW.cInvCode,SaleBillVouchZW.cinvname,cinvstd,SaleBillVouchZW.irowno as ssbvrowno,SO_SODetails.iRowNo as ssorowno,cbdefine1
 From SaleBillVouchZW  
left join (select cbdefine1 as cbdefine1,cbdefine5 as cbdefine5,cbdefine6 as cbdefine6,autoid as keyextend_b_autoid_salebillvouchs_extradefine_autoid 
from salebillvouchs_extradefine) extend_b_autoid_salebillvouchs_extradefine on 
keyextend_b_autoid_salebillvouchs_extradefine_autoid=salebillvouchzw.autoid  
join SaleBillVouchZT on SaleBillVouchZT.sbvid=SaleBillVouchZW.sbvid
left join SO_SODetails on (SaleBillVouchZW.cSOCode = SO_SODetails.cSOCode and SaleBillVouchZW.iorderrowno = SO_SODetails.iRowNo)
where cSource=N'销售' and csbvcode='" + code + "'";
                model = new SaleBillVouch_Model();
                model.csbvcode = code;
                model.details = new List<SaleBillDetails_Model>();

                using (SqlDataReader dr = OperationSql.ExecuteReaderForU8(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        model.sbvid = dr["SBVID"].ToDBString();
                        SaleBillDetails_Model SM = new SaleBillDetails_Model();
                        SM.autoid = dr["autoid"].ToDBString();
                        SM.cinvcode = dr["cinvcode"].ToDBString();
                        SM.cinvname = dr["cinvname"].ToDBString();
                        SM.cinvstd = dr["cinvstd"].ToDBString();
                        SM.ssorowno = dr["ssorowno"].ToDBString();
                        SM.ssbvrowno = dr["ssbvrowno"].ToDBString();
                        SM.cWhCode = dr["cWhCode"].ToDBString();
                        SM.cWhName = dr["cWhName"].ToDBString();
                        SM.ssoqty = dr["ssoqty"].ToDecimal();
                        SM.ssbvqty = dr["ssbvqty"].ToDecimal();
                        SM.ssocode = dr["ssocode"].ToDBString();
                        SM.ssbvcode = dr["ssbvcode"].ToDBString();
                        model.details.Add(SM);
                    }
                }
                strErrMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                model = null;
                return false;
            }
        }

        public bool GetOldSaleBillVouch(SaleBillDetails_Model detail, out List<SaleBillDetails_Model> list, out string strErrMsg)
        {
            try
            {
                string strSql = @"select * from T_temptrans where ssbvcode = '" + detail.ssbvcode + "' and ssbvrowno = '" + detail.ssbvrowno + "'";
                list = new List<SaleBillDetails_Model>();
                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        SaleBillDetails_Model SM = new SaleBillDetails_Model();
                        SM.cinvcode = dr["cinvcode"].ToDBString();
                        SM.cinvname = dr["cinvname"].ToDBString();
                        SM.cinvstd = dr["cinvstd"].ToDBString();
                        SM.ssorowno = dr["ssorowno"].ToDBString();
                        SM.ssbvrowno = dr["ssbvrowno"].ToDBString();
                        SM.ssoqty = dr["ssoqty"].ToDecimal();
                        SM.ssbvqty = dr["ssbvqty"].ToDecimal();
                        SM.ssocode = dr["ssocode"].ToDBString();
                        SM.ssbvcode = dr["ssbvcode"].ToDBString();
                        SM.creater = dr["creater"].ToString();
                        SM.createdate = dr["createdate"].ToString();
                        SM.verifydate = dr["verifydate"].ToString();
                        SM.qty = dr["qty"].ToDecimal();
                        SM.dsocode = dr["dsocode"].ToDBString();
                        SM.dsorowno = dr["dsorowno"].ToDBString();
                        SM.dsoqty = dr["dsoqty"].ToDecimal();
                        SM.RealQty = dr["RealQty"].ToDecimal();
                        //获取autoid
                        SM.autoid = OperationSql.ExecuteScalarForU8(System.Data.CommandType.Text, @"Select SaleBillVouchZW.autoid
 From SaleBillVouchZW  
left join (select cbdefine1 as cbdefine1,cbdefine5 as cbdefine5,cbdefine6 as cbdefine6,autoid as keyextend_b_autoid_salebillvouchs_extradefine_autoid 
from salebillvouchs_extradefine) extend_b_autoid_salebillvouchs_extradefine on 
keyextend_b_autoid_salebillvouchs_extradefine_autoid=salebillvouchzw.autoid  
join SaleBillVouchZT on SaleBillVouchZT.sbvid=SaleBillVouchZW.sbvid
left join SO_SODetails on (SaleBillVouchZW.cSOCode = SO_SODetails.cSOCode and SaleBillVouchZW.iorderrowno = SO_SODetails.iRowNo)
where cSource=N'销售' and csbvcode = '" + SM.ssbvcode + "' and SaleBillVouchZW.cinvcode ='" + SM.cinvcode + "'").ToString();
                        list.Add(SM);
                    }
                }
                strErrMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                list = null;
                return false;
            }
        }

        public bool GetSaleBillDetailsForTrans(SaleBillDetails_Model detail, out List<SaleBillDetails_Model> list, out string strErrMsg)
        {
            try
            {
                list = new List<SaleBillDetails_Model>();
                string strSql = @"select cSOCode,iRowNo,iQuantity from SO_SODetails
where dbclosedate is null and cInvCode = '" + detail.cinvcode + "' and cSOCode != '" + detail.ssocode + "'";
                using (SqlDataReader dr = OperationSql.ExecuteReaderForU8(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        strSql = "select * from T_temptrans where RealQty < " + detail.qty + " and ssocode = '" + dr["cSOCode"].ToDBString() + "' and cinvcode = '" + detail.cinvcode + "'";
                        if(OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql).Read())
                        {
                            break;
                        }
                        strSql = "select SUM(qty) from T_temptrans where  cinvcode = '" + detail.cinvcode + "' and dsocode = '" + dr["cSOCode"].ToDBString() + "'";
                        decimal sum = OperationSql.ExecuteScalar(System.Data.CommandType.Text, strSql).ToDecimal();
                        if(sum != null && (dr["iQuantity"].ToDecimal() - sum < detail.qty))
                        {
                            continue;
                        }
                        strSql = "select SUM(T_STOCK.qty) from T_OUTBARCODE join T_STOCK on T_STOCK.serialno = T_OUTBARCODE.serialno where T_STOCK.warehouseno = '14' and T_OUTBARCODE.materialno = '" + detail.cinvcode + "' and SoCode = '" + dr["cSOCode"].ToDBString() + "'";
                        sum = OperationSql.ExecuteScalar(System.Data.CommandType.Text, strSql).ToDecimal();
                        if (sum == null)
                        {
                            continue;
                        }
                        else if(sum < detail.qty)
                        {
                            continue;
                        }
                        SaleBillDetails_Model SM = new SaleBillDetails_Model();
                        SM.autoid = detail.autoid;
                        SM.cinvcode = detail.cinvcode;
                        SM.cinvname = detail.cinvname;
                        SM.cinvstd = detail.cinvstd;
                        SM.ssorowno = detail.ssorowno;
                        SM.ssbvrowno = detail.ssbvrowno;
                        SM.cWhCode = detail.cWhCode;
                        SM.cWhName = detail.cWhName;
                        SM.ssoqty = detail.ssoqty;
                        SM.ssbvqty = detail.ssbvqty;
                        SM.ssocode = detail.ssocode;
                        SM.ssbvcode = detail.ssbvcode;
                        SM.dsocode = dr["cSOCode"].ToDBString();
                        SM.dsorowno = dr["iRowNo"].ToDBString();
                        SM.dsoqty = sum;
                        SM.qty = detail.qty;
                        //SM.dsoqty = dr["iQuantity"].ToDecimal();
                        list.Add(SM);
                    }
                }
                strErrMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                list = null;
                return false;
            }
        }
        //借调记录表 
        //id
        //cinvcode物料编码
        //cinvname物料名称
        //cinvstd规格型号
        //qty借调数量
        //creater借调人员
        //createdate借调生单时间
        //verifydate借调审核时间
        //ssocode原销售订单号
        //ssorowno原销售订单行号
        //ssoqty原销售订单数量
        //ssbvcode原销售发票号
        //ssbvrowno原销售发票行号
        //ssbvqty原销售发票数量
        //dsocode被借销售订单号
        //dsorowno被借销售订单行号
        //dsoqty被借销售订单数量
        public bool SaveTempTrans(string creater, SaleBillDetails_Model detail, out string strErrMsg)
        {
            try
            {
                string sql = @"insert T_temptrans (cinvcode,cinvname,cinvstd,qty,creater,createdate,ssocode,ssorowno,ssoqty,ssbvcode,ssbvrowno,ssbvqty,dsocode,dsorowno,dsoqty) 
values ('" + detail.cinvcode + "','" + detail.cinvname + "','" + detail.cinvstd + "'," + detail.qty.ToString() + ",'" + creater + "',GETDATE(),'" + detail.ssocode + "','" + detail.ssorowno + "',"
            + detail.ssoqty.ToString() + ",'" + detail.ssbvcode + "','" + detail.ssbvrowno + "'," + detail.ssbvqty.ToString() + ",'" + detail.dsocode + "','" + detail.dsorowno + "'," + detail.dsoqty.ToString() + ")";
                int i = OperationSql.ExecuteNonQuery(CommandType.Text, sql, null);
                if (i <= 0)
                {
                    strErrMsg = "数据库操作失败,未能保存记录";
                    return false;
                }
                strErrMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }

        public bool DelTempTrans(SaleBillDetails_Model detail, out string strErrMsg)
        {
            try
            {
                string sql = @"delete T_temptrans where cinvcode = '" + detail.cinvcode + "' and ssbvcode = '" + detail.ssbvcode + "' and ssbvrowno = '" + detail.ssbvrowno + "'";
                int i = OperationSql.ExecuteNonQuery(CommandType.Text, sql, null);
                if (i <= 0)
                {
                    strErrMsg = "数据库操作失败,未能删除记录";
                    return false;
                }
                strErrMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }

        public bool VerifyTempTrans(SaleBillDetails_Model detail, out string strErrMsg)
        {
            try
            {
                string sql = @"update salebillvouchs_extradefine set cbdefine5 = '是',cbdefine6 = '" + detail.dsocode + "' where autoid = " + detail.autoid;
                int i = OperationSql.ExecuteNonQueryForU8(CommandType.Text, sql, null);
                if (i <= 0)
                {
                    strErrMsg = "数据库操作失败,未能更新记录";
                    return false;
                }
                sql = @"update T_temptrans set verifydate = GETDATE() where cinvcode = '" + detail.cinvcode + "' and ssbvcode = '" + detail.ssbvcode + "'";
                i = OperationSql.ExecuteNonQuery(CommandType.Text, sql, null);
                if (i <= 0)
                {
                    strErrMsg = "数据库操作失败,未能更新记录";
                    return false;
                }
                strErrMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }

        public bool GiveUpTempTrans(SaleBillDetails_Model detail, out string strErrMsg)
        {
            try
            {
                string sql = @"update salebillvouchs_extradefine set cbdefine5 = null,cbdefine6 = null where autoid = " + detail.autoid;
                int i = OperationSql.ExecuteNonQueryForU8(CommandType.Text, sql, null);
                if (i <= 0)
                {
                    strErrMsg = "数据库操作失败,未能弃审记录";
                    return false;
                }
                sql = @"update T_temptrans set verifydate = null where cinvcode = '" + detail.cinvcode + "' and ssbvcode = '" + detail.ssbvcode + "'";
                i = OperationSql.ExecuteNonQuery(CommandType.Text, sql, null);
                if (i <= 0)
                {
                    strErrMsg = "数据库操作失败,未能弃审记录";
                    return false;
                }
                strErrMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
        }

        public bool QueryTempTrans(string cinvcode, string cinvstd, string ssocode, string ssbvcode, string dsocode, string dsbvcode, out List<SaleBillDetails_Model> list, out string strErrMsg)
        {
            try
            {
                //先判断查询条件中是否有被借销售发票号
                string strSql;
                if (dsbvcode != null && dsocode == null)
                {
                    strSql = @"Select distinct SO_SODetails.cSOCode
 From SaleBillVouchZW  
left join (select cbdefine1 as cbdefine1,cbdefine5 as cbdefine5,cbdefine6 as cbdefine6,autoid as keyextend_b_autoid_salebillvouchs_extradefine_autoid 
from salebillvouchs_extradefine) extend_b_autoid_salebillvouchs_extradefine on 
keyextend_b_autoid_salebillvouchs_extradefine_autoid=salebillvouchzw.autoid  
join SaleBillVouchZT on SaleBillVouchZT.sbvid=SaleBillVouchZW.sbvid
left join SO_SODetails on (SaleBillVouchZW.cSOCode = SO_SODetails.cSOCode and SaleBillVouchZW.iorderrowno = SO_SODetails.iRowNo)
where cSource=N'销售' and csbvcode = '" + dsbvcode + "'";
                    dsocode = OperationSql.ExecuteScalarForU8(System.Data.CommandType.Text, strSql).ToDBString();
                }
                strSql = @"select * from T_temptrans where (1=1) ";
                if(cinvcode != null)
                {
                    strSql += " and cinvcode = '" + cinvcode + "' ";
                }
                if (cinvstd != null)
                {
                    strSql += " and cinvstd like '%" + cinvstd + "%' ";
                }
                if (ssocode != null)
                {
                    strSql += " and ssocode = '" + ssocode + "' ";
                }
                if (ssbvcode != null)
                {
                    strSql += " and ssbvcode = '" + ssbvcode + "' ";
                }
                if (dsocode != null)
                {
                    strSql += " and dsocode = '" + dsocode + "' ";
                }
                list = new List<SaleBillDetails_Model>();
                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, strSql))
                {
                    while (dr.Read())
                    {
                        SaleBillDetails_Model SM = new SaleBillDetails_Model();
                        SM.cinvcode = dr["cinvcode"].ToDBString();
                        SM.cinvname = dr["cinvname"].ToDBString();
                        SM.cinvstd = dr["cinvstd"].ToDBString();
                        SM.ssorowno = dr["ssorowno"].ToDBString();
                        SM.ssbvrowno = dr["ssbvrowno"].ToDBString();
                        SM.ssoqty = dr["ssoqty"].ToDecimal();
                        SM.ssbvqty = dr["ssbvqty"].ToDecimal();
                        SM.ssocode = dr["ssocode"].ToDBString();
                        SM.ssbvcode = dr["ssbvcode"].ToDBString();
                        SM.creater = dr["creater"].ToString();
                        SM.createdate = dr["createdate"].ToString();
                        SM.verifydate = dr["verifydate"].ToString();
                        SM.qty = dr["qty"].ToDecimal();
                        SM.dsocode = dr["dsocode"].ToDBString();
                        SM.dsorowno = dr["dsorowno"].ToDBString();
                        SM.dsoqty = dr["dsoqty"].ToDecimal();
                        SM.RealQty = dr["RealQty"].ToDecimal();
                        list.Add(SM);
                    }
                }
                strErrMsg = "";
                return true;
            }
            catch(Exception ex)
            {
                list = null;
                strErrMsg = ex.Message;
                return false;
            }
        }

        public bool QueryStockSumByWHcode(string WHcode,out List<Stock_Model> list, out string strErrMsg)
        {
            try
            {
                string sql = @"select materialno, materialdesc,materialstd,SUM(qty) as sumqty from T_STOCK where warehouseno = '" + WHcode + "' group by materialno,materialdesc,materialstd,warehouseno";
                list = new List<Stock_Model>();
                using (SqlDataReader dr = OperationSql.ExecuteReader(System.Data.CommandType.Text, sql))
                {
                    while (dr.Read())
                    {
                        Stock_Model model = new Stock_Model();
                        model.MaterialNo = dr["materialno"].ToDBString();
                        model.MaterialDesc = dr["materialdesc"].ToDBString();
                        model.MaterialStd = dr["materialstd"].ToDBString();
                        model.Qty = dr["sumqty"].ToDouble();
                        list.Add(model);
                    }
                }
                strErrMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                list = null;
                strErrMsg = ex.Message;
                return false;
            }
        }

        public bool SaveCheckOmitAdd(string strBarcode, Basic.Area.AreaInfo areaInfo,ref string strErrMsg)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = OperationSql.connectionString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }

            SqlTransaction myTran;
            myTran = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.Transaction = myTran;
            //SqlDataReader reader = null;
            string sql = null;
            try
            {
                int iSn = 0;
                cmd.CommandText = "P_GetNewSeqVal_SEQ_STOCK";
                //指定SqlCommand对象传给数据库的是存储过程的名称而不是sql语句  
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                //指定"@ID"为输出参数  
                cmd.Parameters[0].Direction = ParameterDirection.Output;
                //执行  
                cmd.ExecuteNonQuery();
                iSn = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();

                sql = string.Format(@"insert into t_stock (id,barcode,serialno,materialno,materialdesc,warehouseno,houseno,areano,qty,
       status,isdel,creater,createtime,batchno,sn,returnsupcode,returnreson,returnsupname)
       select {0} id,barcode,serialno,materialno,materialdesc,'{1}','{2}','{3}',
       qty,1,0,'admin',GETDATE(),batchno,sn,(case  when vouchertype=30 then supcode  end ), reason,(case  when vouchertype=30 then supname  end )  from t_outbarcode 
       where serialno = '{4}'", iSn, areaInfo.WarehouseNo, areaInfo.HouseNo, areaInfo.AreaNo, strBarcode);

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                if (areaInfo.AreaType == 1)
                {
                    sql = string.Format("update T_OUTBARCODE set iFlag=3 where serialno='{0}'", strBarcode);
                }
                else
                {
                    sql = string.Format("update T_OUTBARCODE set iFlag=2 where serialno='{0}'", strBarcode);
                }

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                myTran.Commit();
                return true;

            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                myTran.Rollback();
                return false;
            }
            finally
            {
                //if (reader != null && !reader.IsClosed)
                //    reader.Close();
                conn.Close();
            }
        }
    }

}
