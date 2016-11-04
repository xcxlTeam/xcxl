//using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;


namespace Test
{
    public class SAP_Common
    {


        //static SAP_Common instance = null;
        //private RfcConfigParameters rfcPar = null;
        //private RfcDestination dest = null;
        //private RfcRepository rfcrep = null;

        //SAP_Common()
        //{
        //    rfcPar = new RfcConfigParameters();
        //    rfcPar.Add(RfcConfigParameters.Name, "test_comba");
        //    rfcPar.Add(RfcConfigParameters.AppServerHost, "192.168.49.80");//"192.168.0.65"
        //    rfcPar.Add(RfcConfigParameters.Client, "600");
        //    rfcPar.Add(RfcConfigParameters.User, "COMBAWMS");//COMBAWMS
        //    rfcPar.Add(RfcConfigParameters.Password, "12345678");//"12345678"
        //    rfcPar.Add(RfcConfigParameters.SystemNumber, "00");
        //    rfcPar.Add(RfcConfigParameters.Language, "ZH");
        //    dest = RfcDestinationManager.GetDestination(rfcPar);
        //    rfcrep = dest.Repository;
        //}
        //static readonly object lockobj = new object();
        //public static SAP_Common CreateInstance()
        //{

        //    lock (lockobj)
        //    {
        //        if (instance == null)
        //        {
        //            instance = new SAP_Common();
        //        }
        //        return instance;
        //    }


        //}

        //public List<IRfcTable> GetTable(string funname, List<string> tablenames, Dictionary<string, string> sps, out string msg)
        //{
        //    IRfcFunction myfun = null;
        //    msg = string.Empty;
        //    List<IRfcTable> list = new List<IRfcTable>();
        //    myfun = rfcrep.CreateFunction(funname);

        //    foreach (var item in sps)
        //    {
        //        myfun.SetValue(item.Key, item.Value);
        //    }
        //    myfun.Invoke(dest);

        //    msg = myfun.GetValue("STATUS").ToString();

        //    foreach (var item in tablenames)
        //    {
        //        list.Add(myfun.GetTable(item));
        //    }

        //    return list;

        //}

        //public object GetValue(string funname, string valuename, Dictionary<string, string> sps, out string msg)
        //{
        //    IRfcFunction myfun = null;
        //    msg = string.Empty;
        //    List<IRfcTable> list = new List<IRfcTable>();
        //    myfun = rfcrep.CreateFunction(funname);

        //    foreach (var item in sps)
        //    {
        //        myfun.SetValue(item.Key, item.Value);
        //    }
        //    myfun.Invoke(dest);

        //    msg = myfun.GetValue("STATUS").ToString();
        //    return myfun.GetValue(valuename);
        //}


        //public List<T> IRcTabeltoList<T>(IRfcTable table) where T : new()
        //{
        //    List<T> listt = new List<T>();
        //    System.Reflection.PropertyInfo[] propertiesT = typeof(T).GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);


        //    for (int i = 0; i < table.Count; i++)
        //    {
        //        T t = new T();
        //        table.CurrentIndex = i;
        //        for (int j = 0; j < table.ElementCount; j++)
        //        {
        //            foreach (System.Reflection.PropertyInfo itemT in propertiesT)
        //            {
        //                if (itemT.Name.ToLower() == table.GetElementMetadata(j).Name.ToLower())
        //                {

        //                    switch (itemT.PropertyType.Name.ToLower())
        //                    {
        //                        case "string":
        //                            itemT.SetValue(t, table.GetString(j), null);
        //                            break;
        //                        case "int":
        //                            itemT.SetValue(t, Convert.ToInt32(table.GetInt(j)), null);
        //                            break;
        //                        case "int32":
        //                            itemT.SetValue(t, Convert.ToInt32(table.GetInt(j)), null);
        //                            break;
        //                        case "datetime":
        //                            itemT.SetValue(t, Convert.ToDateTime(table.GetString(j)), null);

        //                            break;
        //                    }

        //                }

        //            }
        //        }

        //        listt.Add(t);
        //    }

        //    return listt;
        //}



        //public bool getSapFunctionToTable(string funName, Dictionary<string, string> lstParameters, Dictionary<string, Dictionary<string, object>> lstStructures
        //                         , IRfcTable rtbIput, string tableindex
        //                         , List<string> ParameterNamesForOut, out Dictionary<string, string> ParametersOutput
        //                         , List<string> StructureNamesForOut, out Dictionary<string, IRfcStructure> StructureOutputs
        //                         , List<string> tableNamesForOut, out Dictionary<string, IRfcTable> rtbsOutput)
        //{
        //    try
        //    {
        //        RfcRepository repo = rfcrep;                
        //        IRfcFunction Z_RFC_ZCOX = repo.CreateFunction(funName);
        //        RfcSessionManager.BeginContext(dest);
        //        if (lstParameters != null && lstParameters.Count > 0)
        //        {
        //            foreach (KeyValuePair<string, string> item in lstParameters)
        //            {
        //                Z_RFC_ZCOX.SetValue(item.Key, item.Value);
        //            }
        //        }
        //        if (lstStructures != null && lstStructures.Count > 0)
        //        {
        //            foreach (string item in lstStructures.Keys)
        //            {
        //                IRfcStructure _stru = Z_RFC_ZCOX.GetStructure(item);
        //                foreach (KeyValuePair<string, object> _kv in lstStructures[item])
        //                {
        //                    _stru.SetValue(_kv.Key, _kv.Value);
        //                }
        //            }
        //        }
        //        if (rtbIput != null)
        //            Z_RFC_ZCOX.SetValue(tableindex, rtbIput);

        //        Z_RFC_ZCOX.Invoke(dest);
        //        RfcSessionManager.EndContext(dest);

        //        //取出返回的表
        //        if (tableNamesForOut != null && tableNamesForOut.Count > 0)
        //        {
        //            rtbsOutput = new Dictionary<string, IRfcTable>();
        //            foreach (string item in tableNamesForOut)
        //            {
        //                IRfcTable rtb = Z_RFC_ZCOX.GetTable(item);
        //                rtbsOutput.Add(item, rtb);
        //            }
        //        }
        //        else
        //            rtbsOutput = null;

        //        //取出返回参数
        //        if (ParameterNamesForOut != null && ParameterNamesForOut.Count > 0)
        //        {
        //            ParametersOutput = new Dictionary<string, string>();
        //            foreach (string item in ParameterNamesForOut)
        //            {
        //                string retPara = Z_RFC_ZCOX.GetString(item);
        //                ParametersOutput.Add(item, retPara);
        //            }
        //        }
        //        else
        //            ParametersOutput = null;

        //        //取出返回的结构
        //        if (StructureNamesForOut != null && StructureNamesForOut.Count > 0)
        //        {
        //            StructureOutputs = new Dictionary<string, IRfcStructure>();
        //            foreach (string item in StructureNamesForOut)
        //            {
        //                IRfcStructure retStru = Z_RFC_ZCOX.GetStructure(item);
        //                StructureOutputs.Add(item, retStru);
        //            }
        //        }
        //        else
        //            StructureOutputs = null;

        //        //char statue = Z_RFC_ZCOX.GetChar("STATUS");

        //        return "S".Contains("S"); //S 成功,E 错误,W 警告,I 信息,A 中断

        //    }
        //    catch (RfcAbapRuntimeException ex)
        //    {
        //        ParametersOutput = null;
        //        rtbsOutput = null;
        //        StructureOutputs = null;
        //        throw ex;
        //    }
        //}


        //public bool PostSapFunctionFromTable(string funName, Dictionary<string, string> lstParameters
        //    , Dictionary<string, Dictionary<string, object>> lstStructures
        //                         , ref Dictionary<string, string> ParametersOutputs
        //                         , ref Dictionary<string, IRfcStructure> StructureOutputs
        //                         , ref Dictionary<string, IRfcTable> rtbsOutputs
        //                         , string rfcTableName, IRfcTable rfcTable, ref string strErrMsg)
        //{
        //    try
        //    {
        //        RfcRepository repo = rfcrep;
        //        IRfcFunction Z_RFC_ZCOX = repo.CreateFunction(funName);
        //        RfcSessionManager.BeginContext(dest);

        //        if (lstParameters != null && lstParameters.Count > 0)
        //        {
        //            foreach (KeyValuePair<string, string> item in lstParameters)
        //            {
        //                Z_RFC_ZCOX.SetValue(item.Key, item.Value);
        //            }
        //        }

        //        if (lstStructures != null && lstStructures.Count > 0)
        //        {
        //            foreach (string item in lstStructures.Keys)
        //            {
        //                IRfcStructure _stru = Z_RFC_ZCOX.GetStructure(item);
        //                foreach (KeyValuePair<string, object> _kv in lstStructures[item])
        //                {
        //                    _stru.SetValue(_kv.Key, _kv.Value);
        //                }
        //            }
        //        }

        //        if (rfcTable != null && rfcTable.Count > 0)
        //        {
        //            Z_RFC_ZCOX.SetValue(rfcTableName, rfcTable);
        //        }

        //        Z_RFC_ZCOX.Invoke(dest);
        //        RfcSessionManager.EndContext(dest);

        //        //取出返回的表
        //        if (rtbsOutputs != null && rtbsOutputs.Count > 0)
        //        {
        //            for (int i = 0; i < rtbsOutputs.Count; i++)
        //            {
        //                var _item = rtbsOutputs.ElementAt(i);
        //                IRfcTable rtb = Z_RFC_ZCOX.GetTable(_item.Key);
        //                rtbsOutputs[_item.Key] = rtb;
        //            }
        //        }
        //        else
        //            rtbsOutputs = null;

        //        //取出返回的结构
        //        if (StructureOutputs != null && StructureOutputs.Count > 0)
        //        {
        //            for (int i = 0; i < StructureOutputs.Count; i++)
        //            {
        //                var _item = StructureOutputs.ElementAt(i);
        //                IRfcStructure retStru = Z_RFC_ZCOX.GetStructure(_item.Key);
        //                StructureOutputs[_item.Key] = retStru;
        //            }
        //        }
        //        else
        //            StructureOutputs = null;


        //        //char statue = Z_RFC_ZCOX.GetChar("STATUS");
        //        strErrMsg = CreateRETURNs(rtbsOutputs["RETURN"]);
        //        return "S".Contains(CreateRETURNs(rtbsOutputs["RETURN"])); //S 成功,E 错误,W 警告,I 信息,A 中断
        //    }
        //    catch (RfcAbapRuntimeException ex)
        //    {
        //        throw ex;
        //    }
        //}
        ///// <summary>
        ///// 创建rfcable
        ///// </summary>
        ///// <param name="funName"></param>
        ///// <param name="strRfcTableName"></param>
        ///// <returns></returns>
        //public IRfcTable CreateIrfcTable(string funName, string strRfcTableName)
        //{
        //    try
        //    {
        //        RfcRepository repo = rfcrep;
        //        IRfcFunction Z_RFC_ZCOX = repo.CreateFunction(funName);
        //        return Z_RFC_ZCOX.GetTable(strRfcTableName);
        //    }
        //    catch (RfcAbapRuntimeException ex)
        //    {
        //        throw ex;
        //    }

        //}


        ///// <summary>
        ///// 处理返回信息
        ///// </summary>
        ///// <param name="iRfcTable"></param>
        ///// <returns></returns>
        //internal string CreateRETURNs(IRfcTable rtb)
        //{
        //    string item = string.Empty;
        //    List<string> lst = null;
        //    if (rtb != null)
        //    {
        //        if (rtb.RowCount > 0)//if (rtb.RowCount > 0)
        //            lst = new List<string>();
        //        for (int i = 0; i < rtb.RowCount; i++)//for (int i = 0; i < rtb.RowCount; i++)
        //        {


        //            item = rtb[i].GetString("TYPE") + rtb[i].GetString("MESSAGE");

        //            lst.Add(item);
        //        }
        //    }
        //    return item;
        //}

        ///// <summary>
        ///// 操作结果转义
        ///// </summary>
        ///// <param name="p"></param>
        ///// <returns></returns>
        //private string getDoResult(char p)
        //{
        //    switch (p)
        //    {
        //        case 'S':
        //            return "成功";
        //        case 'E':
        //            return "错误";
        //        case 'W':
        //            return "警告";
        //        case 'I':
        //            return "信息";
        //        case 'A':
        //            return "中断";
        //        default:
        //            return string.Empty;
        //    }
        //}

    }


}

