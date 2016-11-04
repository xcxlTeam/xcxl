using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.OutStock
{
    public class OutStockDetails_Model
    {
        /// <summary>
        /// 明细表ID
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// 主表ID
        /// </summary>
        public int OutStock_ID { set; get; }

        public string VoucherNo { get; set; }

        public string VoucherTypeName { get; set; }

        public string MaterialNo { get; set; }

        public string MaterialDesc { get; set; }

        public string MaterialStd { get; set; }

        public string RowNo { get; set; } //PO行号

        public string Plant { get; set; }

        public string PlantName { get; set; }

        public string StorageLoc { get; set; }

        public string Unit { get; set; }//单位

        public string PrdVersion { get; set; } //对应版本号

        public bool OKSelect { get; set; }

        public string MoveType { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        public double OutStockQty { get; set; }

        /// <summary>
        /// WMS已领料数量
        /// </summary>
        public double OldOutStockQty { get; set; }

        /// <summary>
        /// SAP记录的已发料数量
        /// </summary>
        public double OldOutStockQtySAP { get; set; }

        /// <summary>
        /// SAP记录的待发料数量
        /// </summary>
        public double WaitOutStockQty { get; set; }

        /// <summary>
        /// SAP余量库存
        /// </summary>
        public double RemainStockQtySAP { get; set; }

        /// <summary>
        /// WMS可领料领料数量
        /// </summary>
        public double? CurrentOutStockQty { get; set; }

        /// <summary>
        /// 反冲项目(不领料)
        /// </summary>
        public string ProRecoil { get; set; }

        /// <summary>
        /// 虚拟项目（不领料）
        /// </summary>
        public string ProVirtual { get; set; }

        /// <summary>
        /// 删除项目(不领料)
        /// </summary>
        public string ProDel { get; set; }

        /// <summary>
        /// 预留号
        /// </summary>
        public string ReserveNumber { get; set; }

        /// <summary>
        /// 预留行号
        /// </summary>
        public string ReserveRowNo { get; set; }

        /// <summary>
        /// 需求跟踪号
        /// </summary>
        public string TrackNo { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 补料原因
        /// </summary>
        public string RequstReason { get; set; }

        /// <summary>
        /// 物料对应保管员及库位
        /// </summary>
        public List<Material.Material_Model> lstMaterialKeeper { get; set; }

        /// <summary>
        /// 物料保管员编码
        /// </summary>
        public string MaterialKeeperNo { get; set; }

        /// <summary>
        /// 物料保管员名称
        /// </summary>
        public string MaterialKeeperName { get; set; }

        /// <summary>
        /// 物料备注，有备注的物料不能合并
        /// </summary>
        public string Remark { get; set; }
    }
}
