using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChensControl
{
    public class DividPage
    {
        public DividPage()
        { }

        public DividPage(int DefaultPageShowCounts)
        {
            this.CurrentPageShowCounts = DefaultPageShowCounts;
        }

        private int _DefaultPageShowCounts = 10;

        public int DefaultPageShowCounts
        {
            get { return _DefaultPageShowCounts; }
            set { _DefaultPageShowCounts = value; }
        }

        private int _RecordCounts = 0;
        /// <summary>
        /// 记录总数
        /// </summary>
        public int RecordCounts 
        {
            get
            {
                return _RecordCounts;
            }
            set
            {
                _RecordCounts = value;
            }
        }


        private int _CurrentPageRecordCounts ;
        /// <summary>
        /// 当前页记录数
        /// </summary>
        public int CurrentPageRecordCounts
        {
            get
            {
                return _CurrentPageRecordCounts;
            }

            set
            {
                _CurrentPageRecordCounts = value;
            }
        }

        private int _CurrentPageShowCounts = 10;
        /// <summary>
        /// 当前页显示行数
        /// </summary>
        public int CurrentPageShowCounts
        {
            get
            {
                return _CurrentPageShowCounts;
            }

            set
            {
                _CurrentPageShowCounts = value;
            }
        }

        private int _CurrentPageNumber = 1;
        /// <summary>
        /// 当前页数
        /// </summary>
        public int CurrentPageNumber
        {
            get
            {
                return _CurrentPageNumber;
            }

            set
            {
                _CurrentPageNumber = value;
            }
        }

        private int _PagesCount;
        /// <summary>
        /// 总页数
        /// </summary>
        public int PagesCount
        {
            get
            {
                return _PagesCount;
            }

            set
            {
                _PagesCount = value;
            }
        }

        /// <summary>
        /// 是否能link首页
        /// </summary>
        /// <returns></returns>
        public bool CanLinkFirst()
        {
            if (_RecordCounts > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 能否link上页
        /// </summary>
        /// <returns></returns>
        public bool CanLinkPrevious()
        {

            if (_CurrentPageNumber > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  能否Link下页
        /// </summary>
        /// <returns></returns>
        public bool CanLinkNext()
        {
            if (_RecordCounts > 0 && _CurrentPageNumber < _PagesCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 能否Link末页
        /// </summary>
        /// <returns></returns>
        public bool CanLinkLast()
        {
            if (_RecordCounts > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到记录数的描述
        /// </summary>
        /// <returns></returns>
        public string GetRecordsDescribe()
        {
            if (_RecordCounts > 0)
            {
                return _CurrentPageRecordCounts.ToString() + "/" + _RecordCounts.ToString();
            }
            else
            {
                return "没有数据";
            }
        }

        /// <summary>
        /// 得到页数的描述文本
        /// </summary>
        /// <returns></returns>
        public string GetPagesDescribe()
        {
            if (_RecordCounts > 0)
            {
                return _CurrentPageNumber.ToString() + "/" + _PagesCount.ToString();
            }
            else
            {
                return "";
            }
        }


    }
}
