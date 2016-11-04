using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChensControl
{
    public class JSModule
    {
        private string _ID;

        /// <summary>
        /// 模块自己的ID
        /// </summary>
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        /// <summary>
        /// 父模块的ID
        /// </summary>
        public string ParentID
        {
            get;
            set;
        }

       
        /// <summary>
        /// 模块的级别，1代表1级菜单，2代表2级菜单
        /// </summary>
        public string Level
        {
            get;
            set;
        }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 一级菜单打开或二级菜单选中的标志，true代表打开，false代表没打开
        /// </summary>
        public bool OpenFlag
        {
            get;
            set;
        }

        //一级菜单模块对应的按钮
        public ChensMenuButton1 menuButton1
        {
            get;
            set;
        }

        /// <summary>
        /// 窗体路径
        /// 带参数的窗体加:后拼接,多个参数用,分隔,只接受string类型参数.例如: PC_WMS.Print.FrmOrderPrint:10
        /// </summary>
        public string moduleClassName
        {
            get;
            set;
        }

        

    }

    
}
