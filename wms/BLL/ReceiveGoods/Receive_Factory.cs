using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.DeliveryReceive;
using BLL.ProductionReturn;
using BLL.Production;

namespace BLL.ReceiveGoods
{
    public class Receive_Factory
    {
        public static Receive_Post CreateFactoty(int iVoucherType) 
        {
            Receive_Post recPost=null;
            switch (iVoucherType)
            {
                case 10://送货单
                    recPost = new DeliveryReceive_Func();
                    break;
                case 20://生产                     
                    break;
                case 30://生产退料
                    recPost = new ProductionReturn_Func();
                    break;
                case 40://生产订单
                    recPost = new Production_Func();
                    break;
                default:
                    break;
            }
            return recPost;
        }

        
    }
}
