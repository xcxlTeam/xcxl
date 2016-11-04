using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Common
{
    public class Common_Var
    {
        public static string SolutionName;

        public static string AppVersion;

        public static UserInfo CurrentUser;

        public const string DefaultPwd = "123456";

        public const int OnceImportSize = 3000;
    }

    public enum ImportType
    {
        Area = 1,

        Stock = 2,
    }

    public enum VoucherType
    {
        /// <summary>
        /// 任意单据      AnyVoucher
        /// </summary>
        任意单据 = 0,

        /// <summary>
        /// 送货单         DeliveryOrder
        /// </summary>
        送货单 = 10,

        /// <summary>
        /// 移库单         TransitOrder
        /// </summary>
        移库单 = 20,

        /// <summary>
        /// 生产退料        ProductGeneral
        /// </summary>
        生产退料 = 30,

        /// <summary>
        /// 生产订单        ProductionOrder
        /// </summary>
        生产订单 = 40,

        /// <summary>
        /// 快速入库        FastIn
        /// </summary>
        无过账快速入 = 50,

        /// <summary>
        /// 无单号快速入库  FastInNotPO
        /// </summary>
        需过账快速入 = 60,

        /// <summary>
        /// 采购订单        PurchaseOrder
        /// </summary>
        采购订单 = 70,

        无过账快速出 = 80,

        需过账快速出 = 90,

        检验退料单 = 100,
    }

    public enum TaskType
    {
        全部 = 0,

        已下发 = 2,

        未下发 = 3,

        已完成 = 4,

        已取消 = 5,

        SAP已过账 = 6,

        已过账 = 7,

        已分配 = 9,

        未分配 = 10,

        已复核 = 11
    }

    public enum PostStatus
    {
        全部 = 0,

        未过账 = 1,

        部分过账 = 2,

        已过账 = 3,

        无过账 = 4
    }
}