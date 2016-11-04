using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Common
{
    public class ComboBoxItem
    {
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class DividPage
    {
        public DividPage()
        {
            _RecordCounts = 0;
            _CurrentPageNumber = 1;
            _PagesCount = 2;
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


        private int _CurrentPageRecordCounts;
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

        private int _CurrentPageShowCounts = 20;
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

        private int _CurrentPageNumber;
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
    }
}
