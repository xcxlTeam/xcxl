using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.FastIn
{
    internal class FastIn_Func
    {
        public static List<ComboBoxItem> GetStatusList()
        {
            List<ComboBoxItem> lstItem = new List<ComboBoxItem>();
            lstItem.Add(new ComboBoxItem() { ID = 1, Name = "全部" });
            lstItem.Add(new ComboBoxItem() { ID = 2, Name = "已下发" });
            lstItem.Add(new ComboBoxItem() { ID = 3, Name = "未下发" });
            lstItem.Add(new ComboBoxItem() { ID = 4, Name = "已完成" });
            lstItem.Add(new ComboBoxItem() { ID = 5, Name = "已取消" });
            lstItem.Add(new ComboBoxItem() { ID = 6, Name = "已过账" });
           
            return lstItem; 
        }

        public static void GetServerPageFromClientPage(DividPage serverPage, ChensControl.DividPage clientPage)
        {
            if (serverPage == null) serverPage = new DividPage();
            serverPage.CurrentPageNumber = clientPage.CurrentPageNumber;
            serverPage.CurrentPageShowCounts = clientPage.CurrentPageShowCounts;
        }

        public static void GetClientPageFromServerPage(DividPage serverPage, ref ChensControl.DividPage clientPage)
        {
            if (clientPage == null) clientPage = new ChensControl.DividPage();
            clientPage.RecordCounts = serverPage.RecordCounts;
            clientPage.CurrentPageNumber = serverPage.CurrentPageNumber;
            clientPage.CurrentPageShowCounts = serverPage.CurrentPageShowCounts;
            clientPage.CurrentPageRecordCounts = serverPage.CurrentPageRecordCounts;
            clientPage.PagesCount = serverPage.PagesCount;
        }
    }

    public class ComboBoxItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }


}
