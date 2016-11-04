using BLL.Common;
using BLL.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.FastInNotHavePO
{
    public class FastInNotHavePO_Func
    {

        //查询数据
        public bool GetFastInNotHavePOInfo(Task_Model taskmo, ref DividPage dividpage, ref List<Task_Model> lsttask, ref string strErrMsg)
        {
            FastInNotHavePO_DB fdb = new FastInNotHavePO_DB();
            return fdb.GetFastInNotHavePOInfo(taskmo, ref dividpage, ref lsttask, ref strErrMsg);
        }
        //如果是临时物料，获取该物料的名称
        public bool GetTempMaterialName(string materialNo, ref string materialDESC)
        {
            FastInNotHavePO_DB fdb = new FastInNotHavePO_DB();
            return fdb.GetTempMaterialName(materialNo,ref materialDESC);
        }

        //新增数据
        public bool InsetMaterialDetail(List<TaskDetails_Model> tDtails, ref string msg)
        {
            FastInNotHavePO_DB fDB = new FastInNotHavePO_DB();
            return fDB.InsetMaterialDetail(tDtails, ref msg);
        }

        //查询当前物料号是否在临时物料表里
        public bool ExistsTempMaterialByMaterialNo(string materialNo)
        {
            FastInNotHavePO_DB fDB = new FastInNotHavePO_DB();
            return fDB.ExistsTempMaterialByMaterialNo(materialNo);
        }
    }
}
