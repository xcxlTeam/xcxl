using BLL.Basic.User;
using BLL.DeliveryReceive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ReceiveGoods
{
    public class Receive_Post
    {
        public virtual bool ReceiveInfoPostToSAP(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg)
        {
            return true;
        }

        public virtual bool CreateReceiveAndShelveTask(ref DeliveryReceive_Model DeliveryInfo, UserInfo userModel, ref string strErrMsg) 
        {
            return true;
        }

        public virtual string CreateMessage(DeliveryReceive_Model DeliveryInfo,bool bTask,string strTaskErrMsg) 
        {
            return string.Empty;
        }

    }
}
