using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChensControl
{
    public class JSModules
    {
        public List<JSModule> modules;
        public void  InitJSMoudles()
        {
            modules = new List<ChensControl.JSModule>();
            ChensControl.JSModule jsmodule;

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "Query";
            jsmodule.Level = "1";
            jsmodule.ParentID = "0";
            jsmodule.Name = "查询管理";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            #region 查询管理子模块

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "100";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Query";
            jsmodule.Name = "收货记录查询";
            jsmodule.moduleClassName = "JingXinWMS.Query.FrmReceiveTransQuery";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "101";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Query";
            jsmodule.Name = "库存查询";
            jsmodule.moduleClassName = "JingXinWMS.Query.FrmStockQuery";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "102";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Query";
            jsmodule.Name = "库存明细";
            jsmodule.moduleClassName = "JingXinWMS.Query.FrmStockDetailQuery";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "103";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Query";
            jsmodule.Name = "入库记录查询";
            jsmodule.moduleClassName = "JingXinWMS.Query.FrmStockInQuery";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "104";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Query";
            jsmodule.Name = "出库记录查询";
            jsmodule.moduleClassName = "JingXinWMS.Query.FrmStockOutQuery";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "105";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Query";
            jsmodule.Name = "移库记录查询";
            jsmodule.moduleClassName = "JingXinWMS.Query.FrmStockMoveQuery";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            //jsmodule = new ChensControl.JSModule();
            //jsmodule.ID = "106";
            //jsmodule.Level = "2";
            //jsmodule.ParentID = "Query";
            //jsmodule.Name = "拼托记录查询";
            //jsmodule.moduleClassName = "JingXinWMS.Query.Frm_TrayOut";
            //jsmodule.OpenFlag = false;
            //modules.Add(jsmodule);
            
            //jsmodule = new ChensControl.JSModule();
            //jsmodule.ID = "111";
            //jsmodule.Level = "2";
            //jsmodule.ParentID = "Query";
            //jsmodule.Name = "拼托详细查询";
            //jsmodule.moduleClassName = "JingXinWMS.Query.Frm_TOIBP";
            //jsmodule.OpenFlag = false;
            //modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "107";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Query";
            jsmodule.Name = "空进空出记录查询";
            jsmodule.moduleClassName = "JingXinWMS.Query.Frm_NullInOut";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "108";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Query";
            jsmodule.Name = "货位使用率查询";
            jsmodule.moduleClassName = "JingXinWMS.Query.Frm_UseProbability";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "109";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Query";
            jsmodule.Name = "空货位查询";
            jsmodule.moduleClassName = "JingXinWMS.Query.Frm_NullArea";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "110";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Query";
            jsmodule.Name = "呆滞库存查询";
            jsmodule.moduleClassName = "JingXinWMS.Query.Frm_StayStock";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);
            #endregion




            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "Warehouse";
            jsmodule.Level = "1";
            jsmodule.ParentID = "0";
            jsmodule.Name = "仓库管理";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            #region 仓库管理子模块

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "201";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Warehouse";
            jsmodule.Name = "快速入库";
            jsmodule.moduleClassName = "JingXinWMS.FastIn.Frmmain_FastIn";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            //jsmodule = new ChensControl.JSModule();
            //jsmodule.ID = "202";
            //jsmodule.Level = "2";
            //jsmodule.ParentID = "Warehouse";
            //jsmodule.Name = "无PO快速入库";
            //jsmodule.moduleClassName = "JingXinWMS.FastInNotHavePO.Frmmain_FastInNotHavePOQuery";
            //jsmodule.OpenFlag = false;
            //modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "203";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Warehouse";
            jsmodule.Name = "快速出库";
            jsmodule.moduleClassName = "JingXinWMS.FastOut.Frmmain_FastOut";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "204";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Warehouse";
            jsmodule.Name = "临时物料";
            jsmodule.moduleClassName = "JingXinWMS.Warehouse.FrmTempMaterialList";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "205";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Warehouse";
            jsmodule.Name = "物料质检";
            jsmodule.moduleClassName = "JingXinWMS.Quality.FrmQualityList";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            #endregion




            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "Check";
            jsmodule.Level = "1";
            jsmodule.ParentID = "0";
            jsmodule.Name = "盘点管理";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            #region 盘点管理子模块

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "301";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Check";
            jsmodule.Name = "盘点总览";
            jsmodule.moduleClassName = "JingXinWMS.Check.FrmCheckALL";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "302";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Check";
            jsmodule.Name = "新建盘点";
            jsmodule.moduleClassName = "JingXinWMS.Check.FrmCheckAdd";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            //jsmodule = new ChensControl.JSModule();
            //jsmodule.ID = "303";
            //jsmodule.Level = "2";
            //jsmodule.ParentID = "Check";
            //jsmodule.Name = "新建盘点";
            //jsmodule.moduleClassName = "JingXinWMS.Check.FrmCheckDeal";
            //jsmodule.OpenFlag = false;
            //modules.Add(jsmodule);

            //jsmodule = new ChensControl.JSModule();
            //jsmodule.ID = "304";
            //jsmodule.Level = "2";
            //jsmodule.ParentID = "Check";
            //jsmodule.Name = "新建盘点";
            //jsmodule.moduleClassName = "JingXinWMS.Check.FrmCheckDetail";
            //jsmodule.OpenFlag = false;
            //modules.Add(jsmodule);
            #endregion




            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "Task";
            jsmodule.Level = "1";
            jsmodule.ParentID = "0";
            jsmodule.Name = "任务看板";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            #region 任务看板子模块

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "401";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Task";
            jsmodule.Name = "入库任务总览";
            jsmodule.moduleClassName = "JingXinWMS.Task.FrmInOverview";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "402";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Task";
            jsmodule.Name = "出库任务总览";
            jsmodule.moduleClassName = "JingXinWMS.Task.FrmOutOverview";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "403";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Task";
            jsmodule.Name = "外协订单过账";
            jsmodule.moduleClassName = "JingXinWMS.Task.FrmOutsourcing";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "404";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Task";
            jsmodule.Name = "生成下架任务";
            jsmodule.moduleClassName = "JingXinWMS.MaterialRequest.FrmMaterialRequestList";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);


            #endregion




            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "Print";
            jsmodule.Level = "1";
            jsmodule.ParentID = "0";
            jsmodule.Name = "标签打印";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            #region 标签打印子模块

            //jsmodule = new ChensControl.JSModule();
            //jsmodule.ID = "500";
            //jsmodule.Level = "2";
            //jsmodule.ParentID = "Print";
            //jsmodule.Name = "打印测试";
            //jsmodule.moduleClassName = "JingXinWMS.Print.FrmPrintTesdt";
            //jsmodule.OpenFlag = false;
            //modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "501";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Print";
            jsmodule.Name = "送货单外箱标签打印";
            jsmodule.moduleClassName = "JingXinWMS.Print.FrmOutBarcodePrint" + ":10";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "502";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Print";
            jsmodule.Name = "生产退料单外箱标签打印";
            jsmodule.moduleClassName = "JingXinWMS.Print.FrmOutBarcodePrint" + ":30";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "503";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Print";
            jsmodule.Name = "生产订单外箱标签打印";
            jsmodule.moduleClassName = "JingXinWMS.Print.FrmOutBarcodePrint" + ":40";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "504";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Print";
            jsmodule.Name = "采购订单内盒标签打印";
            jsmodule.moduleClassName = "JingXinWMS.Print.FrmInnerBarcodePrint" + ":70";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "505";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Print";
            jsmodule.Name = "送检单打印";
            jsmodule.moduleClassName = "JingXinWMS.Print.FrmCensorshipPrint";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "520";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Print";
            jsmodule.Name = "货位标签打印";
            jsmodule.moduleClassName = "JingXinWMS.Print.FrmAreaPrint";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "521";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Print";
            jsmodule.Name = "货位标签补打";
            jsmodule.moduleClassName = "JingXinWMS.Print.FrmAreaRePrint";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);
            
            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "522";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Print";
            jsmodule.Name = "物料标签打印";
            jsmodule.moduleClassName = "JingXinWMS.Print.FrmMaterialPrint";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "523";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Print";
            jsmodule.Name = "物料标签补打";
            jsmodule.moduleClassName = "JingXinWMS.Print.FrmMaterialRePrint";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);
            #endregion

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "Basic";
            jsmodule.Level = "1";
            jsmodule.ParentID = "0";
            jsmodule.Name = "基础设置";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            #region 基础设置子模块

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "601";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Basic";
            jsmodule.Name = "仓库设置";
            jsmodule.moduleClassName = "JingXinWMS.Basic.FrmWarehouseList";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "602";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Basic";
            jsmodule.Name = "库区设置";
            jsmodule.moduleClassName = "JingXinWMS.Basic.FrmHouseList";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "603";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Basic";
            jsmodule.Name = "货位设置";
            jsmodule.moduleClassName = "JingXinWMS.Basic.FrmAreaList";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "604";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Basic";
            jsmodule.Name = "用户设置";
            jsmodule.moduleClassName = "JingXinWMS.Basic.FrmUserList";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);

            jsmodule = new ChensControl.JSModule();
            jsmodule.ID = "605";
            jsmodule.Level = "2";
            jsmodule.ParentID = "Basic";
            jsmodule.Name = "组权限设置";
            jsmodule.moduleClassName = "JingXinWMS.Basic.FrmGroupMenu";
            jsmodule.OpenFlag = false;
            modules.Add(jsmodule);
            #endregion




        }
    }

}
