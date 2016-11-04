using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Stock
{
    public class SaleBillVouch_Model
    {
        string _csbvcode;

        public string csbvcode
        {
            get { return _csbvcode; }
            set { _csbvcode = value; }
        }

        string _sbvid;

        public string sbvid
        {
            get { return _sbvid; }
            set { _sbvid = value; }
        }

        List<SaleBillDetails_Model> _details;

        public List<SaleBillDetails_Model> details
        {
            get { return _details; }
            set { _details = value; }
        }
    }

    public class SaleBillDetails_Model
    {
        string _verifydate;

        public string verifydate
        {
            get { return _verifydate; }
            set { _verifydate = value; }
        }
        string _createdate;

        public string createdate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        string _creater;

        public string creater
        {
            get { return _creater; }
            set { _creater = value; }
        }
        string _autoid;

        public string autoid
        {
            get { return _autoid; }
            set { _autoid = value; }
        }
        string _cinvcode;

        public string cinvcode
        {
            get { return _cinvcode; }
            set { _cinvcode = value; }
        }

        string _cinvname;

        public string cinvname
        {
            get { return _cinvname; }
            set { _cinvname = value; }
        }

        string _cinvstd;

        public string cinvstd
        {
            get { return _cinvstd; }
            set { _cinvstd = value; }
        }

        string _ssocode;

        public string ssocode
        {
            get { return _ssocode; }
            set { _ssocode = value; }
        }

        string _ssorowno;

        public string ssorowno
        {
            get { return _ssorowno; }
            set { _ssorowno = value; }
        }

        decimal _ssoqty;

        public decimal ssoqty
        {
            get { return _ssoqty; }
            set { _ssoqty = value; }
        }

        string _ssbvcode;

        public string ssbvcode
        {
            get { return _ssbvcode; }
            set { _ssbvcode = value; }
        }

        string _ssbvrowno;

        public string ssbvrowno
        {
            get { return _ssbvrowno; }
            set { _ssbvrowno = value; }
        }

        decimal _ssbvqty;

        public decimal ssbvqty
        {
            get { return _ssbvqty; }
            set { _ssbvqty = value; }
        }

        string _dsocode;

        public string dsocode
        {
            get { return _dsocode; }
            set { _dsocode = value; }
        }

        string _dsorowno;

        public string dsorowno
        {
            get { return _dsorowno; }
            set { _dsorowno = value; }
        }

        decimal _dsoqty;

        public decimal dsoqty
        {
            get { return _dsoqty; }
            set { _dsoqty = value; }
        }

        decimal _qty;

        public decimal qty
        {
            get { return _qty; }
            set { _qty = value; }
        }

        string _cWhCode;

        public string cWhCode
        {
            get { return _cWhCode; }
            set { _cWhCode = value; }
        }

        string _cWhName;

        public string cWhName
        {
            get { return _cWhName; }
            set { _cWhName = value; }
        }

        string _cbdefine5;

        public string cbdefine5
        {
            get { return _cbdefine5; }
            set { _cbdefine5 = value; }
        }

        string _cbdefine6;

        public string cbdefine6
        {
            get { return _cbdefine6; }
            set { _cbdefine6 = value; }
        }

        decimal _RealQty;

        public decimal RealQty
        {
            get { return _RealQty; }
            set { _RealQty = value; }
        }
    }
}
