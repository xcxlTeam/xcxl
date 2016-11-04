using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.MaterialRequestProduct;
using BLL.MaterialRequest;
using BLL.MaterialRequestOutSide;

namespace BLL.OutStock
{
    public class OutStock_Factory
    {
        public static OutStock_Post CreateFactoty(int iVoucherType)
        {
            OutStock_Post ostPost = null;
            switch (iVoucherType)
            {
                case 80://生产补料
                    ostPost = new MaterialRequest_Func();
                    break;
                case 90://生产 转储   
                    ostPost = new MaterialRequest_Func();
                    break;
                case 100://研发领料
                    ostPost = new MaterialRequest_Func();
                    break;
                case 110://成本中心领料
                    ostPost = new MaterialRequest_Func();
                    break;
                case 120://生产作业单领料
                    ostPost = new MaterialRequestProduct_Func();
                    break;
                case 130://外协领料
                    ostPost = new MaterialRequestOutSide_Func();
                    break;
                default:
                    break;
            }
            return ostPost;
        }
    }
}
