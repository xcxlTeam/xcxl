using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS.Print
{
    class MyQuery
    {
        string _str;

        public string Str
        {
            get { return _str; }
            set { _str = value; }
        }
    }
    public partial class FrmQueryPrintSerialNo : Form
    {
        public FrmQueryPrintSerialNo()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            WebService.ArrayOfString querylist = null;
            string strErrMsg = "";
            if(!WMS.Common.WMSWebService.service.QueryPrintSerialNo(txtBatchNo.Text, ref querylist, ref strErrMsg))
            {
                MessageBox.Show(strErrMsg);
                return;
            }
            List<MyQuery> mylist = new List<MyQuery>();
            foreach(string str in querylist)
            {
                MyQuery myquery = new MyQuery();
                myquery.Str = str;
                mylist.Add(myquery);
            }
            dataGridView1.DataSource = mylist;
            dataGridView1.Columns[0].HeaderText = "查询结果";
            dataGridView1.Columns[0].Width = 300;
            dataGridView1.Refresh();
        }
    }
}
