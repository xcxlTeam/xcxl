using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{

    public partial class Form999 : Form
    {
        localhost.WebService localWebTest = new localhost.WebService();
        public Form999()
        {
            InitializeComponent();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 读1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindData(1);
        }

        private void 读ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindData(5);
        }

        private void 读2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindData(2);
        }

        void bindData(int iNo)
        {
            try
            {
                DataSet ds = new DataSet();
                localWebTest.TestReadData(iNo,out ds);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    #region 乱码转换中文
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        if (ds.Tables[0].Columns.Contains("CHDesc"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["CHDesc"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["CHDesc"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("CHDescr"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["CHDescr"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["CHDescr"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("PCHDesc"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["PCHDesc"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["PCHDesc"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("MCHDesc"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["MCHDesc"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["MCHDesc"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("Allergic"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["Allergic"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["Allergic"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        //ShipAddr1,ShipAddr2,Name,Remark1,Remark2,MoveDescr,
                        if (ds.Tables[0].Columns.Contains("ShipAddr1"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["ShipAddr1"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["ShipAddr1"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("ShipAddr2"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["ShipAddr2"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["ShipAddr2"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("Name"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["Name"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["Name"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("Remark1"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["Remark1"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["Remark1"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("Remark2"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["Remark2"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["Remark2"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("MoveDescr"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["MoveDescr"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["MoveDescr"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        //[lotSendto1],[lotSendto2],[lotSendto3],[lotSendto1b],[lotSendto2b],[lotSendto3b],[lotSendto1c],[lotSendto2c],[lotSendto3c]
                        if (ds.Tables[0].Columns.Contains("lotSendto1"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["lotSendto1"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["lotSendto1"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("lotSendto2"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["lotSendto2"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["lotSendto2"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("lotSendto3"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["lotSendto3"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["lotSendto3"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("lotSendto1b"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["lotSendto1b"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["lotSendto1b"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("lotSendto2b"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["lotSendto2b"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["lotSendto2b"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("lotSendto3b"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["lotSendto3b"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["lotSendto3b"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("lotSendto1c"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["lotSendto1c"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["lotSendto1c"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("lotSendto2c"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["lotSendto2c"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["lotSendto2c"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("lotSendto3c"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["lotSendto3c"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["lotSendto3c"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        //[CHmaterialname],[MoveName],Address,ShipVia
                        if (ds.Tables[0].Columns.Contains("CHmaterialname"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["CHmaterialname"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["CHmaterialname"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("MoveName"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["MoveName"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["MoveName"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("Address"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["Address"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["Address"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                        if (ds.Tables[0].Columns.Contains("ShipVia"))
                        {
                            Byte[] b1 = Encoding.GetEncoding(1252).GetBytes(item["ShipVia"].ToString());//1252对应SQL_Latin1_General_CP1_CI_AS
                            item["ShipVia"] = Encoding.GetEncoding("GB2312").GetString(b1);//转换成新的字符编码
                        }
                    } 
                    #endregion
                    dataGridView1.DataSource = ds.Tables[0];
                    MessageBox.Show("success");
                }
                else
                    MessageBox.Show("no data.");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void 读3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindData(3);
        }

        private void 读BOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindData(4);
        }

        private void 读6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindData(6);
        }

        private void 读7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindData(7);
        }

        private void 读8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindData(8);
        }

        private void 读9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindData(9);
        }

        private void 读10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindData(10);
        }

        private void 读待定移库单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindData(11);
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelLibrary.ExcelLibrary_Func.SaveDataGridViewToExcelByNPOI(dataGridView1, true, false, this.Name);
        }
    }
}
