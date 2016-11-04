using WMS.WebService;
using WMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PrintLibrary;
using System.Xml;

namespace WMS.Print
{
    public partial class FrmInitMaterialPrint : Form
    {
        string filename;
        private DividPage _serverMainPage;
        private Stock_Model queryMain;
        private List<ImportPrint_Model> lstMain;
        private ImportPrint_Model currentDetail;
        public FrmInitMaterialPrint()
        {
            InitializeComponent();
        }
        public static DataTable LoadExcelToDataTable(string filename, string worksheetname)
        {
            DataTable table;
            //连接字符串  
            String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filename + ";" + "Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            OleDbConnection myConn = new OleDbConnection(sConnectionString);
            string strCom = " SELECT * FROM [" + worksheetname + "$]";
            myConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
            table = new DataTable();
            myCommand.Fill(table);
            myConn.Close();
            return table;
        }

        private void tsmiImport_Click(object sender, EventArgs e)
        {
            try
            {
                //导入Excel
                OpenFileDialog openFile = new OpenFileDialog();
                filename = "";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    filename = openFile.FileNames[0];
                }

                if (filename != "")
                {
                    if (!filename.Substring(filename.Length - 4).Equals(".xls") && !filename.Substring(filename.Length - 5).Equals(".xlsx"))
                    {
                        MessageBox.Show("该文件不是指定文件类型！");
                        filename = "";
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("该文件不是指定文件类型或配置文件错误！");
                    return;
                }
                string table = filename.Substring(filename.LastIndexOf("_", filename.Length) + 1, filename.LastIndexOf(".", filename.Length) - filename.LastIndexOf("_", filename.Length) - 1);
                //将Excel表中的数据导入到Datatable中  
                DataTable dt = LoadExcelToDataTable(filename, "Sheet1");
                List<Stock_Model> list = new List<Stock_Model>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Stock_Model stockmodel = new Stock_Model();
                    stockmodel.MaterialNo = dt.Rows[i]["物料号"].ToString();
                    stockmodel.MaterialDesc = dt.Rows[i]["U8规格型号"].ToString();
                    stockmodel.WarehouseNo = dt.Rows[i]["货位编号"].ToString().Split('-')[0];
                    stockmodel.HouseNo = dt.Rows[i]["货位编号"].ToString().Split('-')[1];
                    stockmodel.AreaNo = dt.Rows[i]["货位编号"].ToString();// dt.Rows[i]["货位编号"].ToString().Split('-')[2] + "-" + dt.Rows[i]["货位编号"].ToString().Split('-')[3];
                    stockmodel.Qty = dt.Rows[i]["数量"].ToInt32();
                    stockmodel.cvencode = dt.Rows[i]["供应商代码"].ToString();
                    list.Add(stockmodel);
                }
                string strErrMsg = "";
                if (!WMS.Common.WMSWebService.service.ImportMaterialStock(list, ref strErrMsg))
                {
                    MessageBox.Show("导入数据失败:" + strErrMsg);
                    return;
                }
                else
                {
                    MessageBox.Show("导入成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入数据失败:" + ex.Message);
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ChensControl.DividPage clientPage = pageList.dDividPage;
                DividPage _serverMainPage = new DividPage();
                Common.Common_Func.GetServerPageFromClientPage(ref _serverMainPage, clientPage);
                queryMain = new Stock_Model();
                if (txtWhereMaterialNo.Text.Trim().Length > 0)//物料号
                {
                    queryMain.MaterialNo = txtWhereMaterialNo.Text.Trim();
                }
                if (txtWhereWarehouseNo.Text.Trim().Length > 0)//库存仓库
                {
                    queryMain.WarehouseNo = txtWhereWarehouseNo.Text.Trim();
                }
                if (txtWhereHouseNo.Text.Trim().Length > 0)//库存库区
                {
                    queryMain.HouseNo = txtWhereHouseNo.Text.Trim();
                }
                if (txtWhereAreaNo.Text.Trim().Length > 0)//库存货位
                {
                    queryMain.AreaNo = txtWhereAreaNo.Text.Trim();
                }
                //queryMain.BatchNo = "期初";
                string strErrMsg = "";
                bool bResult = WMS.Common.WMSWebService.service.GetImportMaterialStockByPage(ref lstMain, queryMain, ref _serverMainPage, Common.Common_Var.CurrentUser, ref strErrMsg);
                Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
                pageList.ShowPage();
                bsMain.DataSource = lstMain;
                if (bResult == false)
                {
                    Common.Common_Func.ErrorMessage(strErrMsg, "程序异常");
                    return;
                }
                pageList_ChensPageChange(null, null);
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "程序异常");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lstMain != null && dgvList.SelectedRows.Count > 0)
            {
                txtMaterialNo.Text = lstMain[dgvList.SelectedRows[0].Index].MaterialNo;
                txtMaterialDesc.Text = lstMain[dgvList.SelectedRows[0].Index].MaterialDesc;
                txtcinvstd.Text = lstMain[dgvList.SelectedRows[0].Index].MaterialStd;
                if (lstMain[dgvList.SelectedRows[0].Index].ImportQty - lstMain[dgvList.SelectedRows[0].Index].PrintQty > 0)
                {
                    txtBatchQty.Text = (lstMain[dgvList.SelectedRows[0].Index].ImportQty - lstMain[dgvList.SelectedRows[0].Index].PrintQty).ToString();
                }
                else
                {
                    txtBatchQty.Text = "1";
                }
                txtOutPackQty.Text = "1";
                txtPrintQty.Text = "2";
                currentDetail = lstMain[dgvList.SelectedRows[0].Index];
            }
        }

        private void 原料标签打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDetail != null)
            {
                if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtOutPackQty.Text))
                {
                    MessageBox.Show("外箱包装量必须是正整数");
                    return;
                }
                if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtPrintQty.Text))
                {
                    MessageBox.Show("打印份数必须是正整数");
                    return;
                }
                if (!new System.Text.RegularExpressions.Regex(@"^[0-9]\d*$").IsMatch(txtBatchQty.Text))
                {
                    MessageBox.Show("打印数量必须是正整数");
                    return;
                }
                //生成条码
                string strErrMsg = "";
                WebService.MaterialLabel_Model label = new WebService.MaterialLabel_Model();
                label.prdversion = "3";
                label.labeltype = "09";
                label.outpackqty = txtOutPackQty.Text;
                label.materialno = currentDetail.MaterialNo;
                label.materialdesc = currentDetail.MaterialDesc;
                label.invstd = currentDetail.MaterialStd;
                label.cvencode = currentDetail.cvencode != null ? currentDetail.cvencode : "";
                label.cvenabbname = currentDetail.cvenname != null ? currentDetail.cvenname : "";
                Stock_Model stockmodel = new Stock_Model();
                stockmodel.AreaNo = currentDetail.AreaNo;
                stockmodel.MaterialNo = currentDetail.MaterialNo;
                stockmodel.MaterialDesc = currentDetail.MaterialDesc;
                stockmodel.MaterialStd = currentDetail.MaterialStd;
                stockmodel.WarehouseNo = currentDetail.WarehouseNo;
                stockmodel.HouseNo = currentDetail.HouseNo;
                List<WebService.MaterialLabel_Model> label_lst = null;
                if (!WMS.Common.WMSWebService.service.CreateInitialMaterialBarcode(stockmodel, label, Convert.ToInt16(txtBatchQty.Text), ref label_lst, ref strErrMsg))
                {
                    MessageBox.Show("生成条码失败:" + strErrMsg);
                    return;
                }
                int printqty = Convert.ToInt16(txtPrintQty.Text);
                int count = Convert.ToInt16(txtBatchQty.Text);
                for (int j = 0; j < printqty; j++)
                {
                    for (int i = 0; i < count; i++)
                    {
                        string printStr = "";
                        //将文本框中的内容按行转成图片
                        StringBuilder ReturnBarcodeCMD = new StringBuilder(10240);
                        RawPrinterHelper.GETFONTHEX("货位：" + label_lst[i].Locale, "宋体", "txt1", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                        printStr += ReturnBarcodeCMD;
                        if (label_lst[i].cvenabbname.Length > 0)
                        {
                            if (label_lst[i].cvenabbname.Length > 6)
                            {
                                RawPrinterHelper.GETFONTHEX("供应商：" + label_lst[i].cvenabbname.Substring(0, 6), "宋体", "txt2", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                                printStr += ReturnBarcodeCMD;
                                RawPrinterHelper.GETFONTHEX(label_lst[i].cvenabbname.Substring(6), "宋体", "txt3", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                                printStr += ReturnBarcodeCMD;
                            }
                            else
                            {
                                RawPrinterHelper.GETFONTHEX("供应商：" + label_lst[i].cvenabbname, "宋体", "txt2", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                                printStr += ReturnBarcodeCMD;
                            }
                        }
                        RawPrinterHelper.GETFONTHEX("物料编码：" + label_lst[i].materialno, "宋体", "txt4", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                        printStr += ReturnBarcodeCMD;
                        if (label_lst[i].materialdesc.Length > 8)
                        {
                            RawPrinterHelper.GETFONTHEX("物料名称：" + label_lst[i].materialdesc.Substring(0, 8), "宋体", "txt5", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                            printStr += ReturnBarcodeCMD;
                            RawPrinterHelper.GETFONTHEX(label_lst[i].materialdesc.Substring(8), "宋体", "txt6", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                            printStr += ReturnBarcodeCMD;
                        }
                        else
                        {
                            RawPrinterHelper.GETFONTHEX("物料名称：" + label_lst[i].materialdesc, "宋体", "txt5", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                            printStr += ReturnBarcodeCMD;
                        }
                        if (label_lst[i].invstd.Length > 8)
                        {
                            RawPrinterHelper.GETFONTHEX("规格型号：" + label_lst[i].invstd.Substring(0, 8), "宋体", "txt7", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                            printStr += ReturnBarcodeCMD;
                            RawPrinterHelper.GETFONTHEX(label_lst[i].invstd.Substring(8), "宋体", "txt8", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                            printStr += ReturnBarcodeCMD;
                        }
                        else
                        {
                            RawPrinterHelper.GETFONTHEX("规格型号：" + label_lst[i].invstd, "宋体", "txt7", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                            printStr += ReturnBarcodeCMD;
                        }
                        //RawPrinterHelper.GETFONTHEX("生产日期：" + dtpBatchNo.Value.ToString("yyyy/MM/dd"), "宋体", "txt9", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                        //printStr += ReturnBarcodeCMD;
                        RawPrinterHelper.GETFONTHEX("包装量：" + label_lst[i].outpackqty, "宋体", "txt10", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                        printStr += ReturnBarcodeCMD;
                        RawPrinterHelper.GETFONTHEX("箱号:" + label_lst[i].Remark, "宋体", "txt11", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                        printStr += ReturnBarcodeCMD;
                        RawPrinterHelper.GETFONTHEX(label_lst[i].BarcodeExpress, "宋体", "txt12", 0, 26, 14, 1, 0, ReturnBarcodeCMD);
                        printStr += ReturnBarcodeCMD;
                        printStr += "^XA^MMT^PW559^LL0559^LS0";
                        printStr += "^FT160,66^XGtxt1,1,1^FS";
                        if (label_lst[i].cvenabbname.Length > 0)
                        {
                            printStr += "^FT160,120^XGtxt2,1,1^FS";
                            if (label_lst[i].cvenabbname.Length > 6)
                            {
                                printStr += "^FT270,150^XGtxt3,1,1^FS";
                            }
                        }
                        printStr += "^FT32,226^XGtxt4,1,1^FS";
                        printStr += "^FT32,268^XGtxt5,1,1^FS";
                        if (label_lst[i].materialdesc.Length > 8)
                        {
                            printStr += "^FT165,296^XGtxt6,1,1^FS";
                        }
                        printStr += "^FT32,332^XGtxt7,1,1^FS";
                        if (label_lst[i].invstd.Length > 8)
                        {
                            printStr += "^FT165,360^XGtxt8,1,1^FS";
                        }
                        //printStr += "^FT32,400^XGtxt9,1,1^FS";
                        printStr += "^FT32,462^XGtxt10,1,1^FS";
                        printStr += "^FT32,522^XGtxt11,1,1^FS";
                        printStr += "^FT330,522^XGtxt12,1,1^FS";
                        printStr += "^FO10,10^GB530,530,4^FS";
                        printStr += "^FO10,170^GB530,0,4^FS";
                        //printStr += "^FT45,167^BQN,2,5";
                        //printStr += "^FDMA," + label_lst[i].cpoid + "^FS";
                        printStr += "^FT400,500^BQN,2,4";
                        printStr += "^FDMA," + label_lst[i].barcode + "^FS";
                        printStr += "^PQ1,0,1,Y^XZ";
                        printStr += "^XA^IDtxt1^FS^XZ";
                        if (label_lst[i].cvenabbname.Length > 0)
                        {
                            printStr += "^XA^IDtxt2^FS^XZ";
                            if (label_lst[i].cvenabbname.Length > 6)
                            {
                                printStr += "^XA^IDtxt3^FS^XZ";
                            }
                        }
                        printStr += "^XA^IDtxt4^FS^XZ";
                        printStr += "^XA^IDtxt5^FS^XZ";
                        if (label_lst[i].materialdesc.Length > 8)
                        {
                            printStr += "^XA^IDtxt6^FS^XZ";
                        }
                        printStr += "^XA^IDtxt7^FS^XZ";
                        if (label_lst[i].invstd.Length > 8)
                        {
                            printStr += "^XA^IDtxt8^FS^XZ";
                        }
                        //printStr += "^XA^IDtxt9^FS^XZ";
                        printStr += "^XA^IDtxt10^FS^XZ";
                        printStr += "^XA^IDtxt11^FS^XZ";
                        printStr += "^XA^IDtxt12^FS^XZ";
                        string xPath = "/configuration/appSettings//add[@key='Printer']";
                        XmlDocument doc = new XmlDocument();
                        string exeFileName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                        doc.Load(exeFileName + ".exe.config");
                        XmlNode node = doc.SelectSingleNode(xPath);
                        RawPrinterHelper.SendStringToPrinter(node.Attributes["value"].Value.ToString(), printStr);
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
        }

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bsMain.EndEdit();
                string strErr = string.Empty;

                if (queryMain == null) { queryMain = new Stock_Model(); bsMain.DataSource = queryMain; }

                ChensControl.DividPage clientPage = pageList.dDividPage;
                Common.Common_Func.GetServerPageFromClientPage(ref _serverMainPage, clientPage);
                bool bResult = WMS.Common.WMSWebService.service.GetImportMaterialStockByPage(ref lstMain, queryMain, ref _serverMainPage, Common.Common_Var.CurrentUser, ref strErr);
                Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
                pageList.ShowPage();
                dgvList.DataSource = lstMain;

                if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败");
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "查询失败");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
