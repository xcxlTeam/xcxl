using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JXBLL.IQCWebservice;

namespace JXBLL.Tool
{
    public class IQCWebCommon
    {
        public static IQCWebCommon WebCon;
        public IQCWebservice.IQCWebService IQCWeb;
        

        private IQCWebCommon(string strIQCUrl,int iTimeOut)
        {
            IQCWeb = new IQCWebService();
            IQCWeb.Url = strIQCUrl;
            IQCWeb.Timeout = iTimeOut;
        }

        public static IQCWebCommon GetCommon(string strIQCUrl, int iTimeOut)
        {
            if (WebCon == null)
            {
                WebCon = new IQCWebCommon(strIQCUrl,iTimeOut);
            }
            return WebCon;
        }

    }
}
