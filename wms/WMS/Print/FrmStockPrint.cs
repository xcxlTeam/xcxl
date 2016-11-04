using ExcelLibrary;
using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS.Print
{
    public partial class FrmStockPrint : Common.FrmBasic
    {
        string filename;
        private DividPage _serverMainPage;
        private Stock_Model queryMain;
        private List<ImportPrint_Model> lstMain;
        private ImportPrint_Model currentDetail;
        public FrmStockPrint()
        {
            InitializeComponent();
            dgvList.DataSource = bsMain;
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void tsmiImport_Click(object sender, EventArgs e)
        {
            try{
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
                    list.Add(stockmodel);
                }
                string strErrMsg = "";
                if(!WMS.Common.WMSWebService.service.ImportStock(list, ref strErrMsg))
                {
                    MessageBox.Show("导入数据失败:" + strErrMsg);
                    return;
                }
                else
                {
                    MessageBox.Show("导入成功");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("导入数据失败:" + ex.Message);
                return;
            }
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (lstMain != null && dgvList.SelectedRows.Count > 0)
            //{
            //    txtMaterialNo.Text = lstMain[dgvList.SelectedRows[0].Index].MaterialNo;
            //    txtMaterialDesc.Text = lstMain[dgvList.SelectedRows[0].Index].MaterialDesc;
            //    txtcinvstd.Text = lstMain[dgvList.SelectedRows[0].Index].MaterialDesc;
            //    //txtcinvstd.Text = "";
            //    txtBatchQty.Text = lstMain[dgvList.SelectedRows[0].Index].Qty.ToString();
            //    txtOutPackQty.Text = "1";
            //    txtPrintQty.Text = "1";
            //    currentDetail = lstMain[dgvList.SelectedRows[0].Index];
            //}
        }

        private void tsmiPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvList_Click(object sender, EventArgs e)
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
                bool bResult = WMS.Common.WMSWebService.service.GetImportPrintStockByPage(ref lstMain, queryMain, ref _serverMainPage, Common.Common_Var.CurrentUser, ref strErr);
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

        private void button1_Click(object sender, EventArgs e)
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
                bool bResult = WMS.Common.WMSWebService.service.GetImportPrintStockByPage(ref lstMain, queryMain, ref _serverMainPage, Common.Common_Var.CurrentUser, ref strErrMsg);
                Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
                pageList.ShowPage();
                bsMain.DataSource = lstMain;
                if (bResult == false)
                {
                    Common.Common_Func.ErrorMessage(strErrMsg, "程序异常");
                    return;
                }
                //txtWhereMaterialNo.Text = "";
                //txtWhereWarehouseNo.Text = "";
                //txtWhereHouseNo.Text = "";
                //txtWhereAreaNo.Text = "";
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

        private void 删除已导库存ToolStripMenuItem_Click(object sender, EventArgs e)
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
                    list.Add(stockmodel);
                }
                string strErrMsg = "";
                if (!WMS.Common.WMSWebService.service.RemoveStock(list, ref strErrMsg))
                {
                    MessageBox.Show("删除数据失败:" + strErrMsg);
                    return;
                }
                else
                {
                    MessageBox.Show("删除成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除数据失败:" + ex.Message);
                return;
            }
        }

        private void 有货位标签ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintStock(1);
        }

        private void 无货位标签ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintStock(0);
        }

        void PrintStock(int model)
        {
            if (currentDetail != null)
            {
                try
                {
                    if(model == 0)
                    {
                        //验证
                        if (new System.Text.RegularExpressions.Regex(@"[\u4e00-\u9fa5]").IsMatch(txtcinvstd.Text))
                        {
                            MessageBox.Show("规格型号中包含有中文");
                            txtcinvstd.SelectAll();
                            txtcinvstd.Focus();
                            return;
                        }
                    }
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
                    List<WebService.ProductLabel_Model> label_lst = null;
                    WebService.ProductLabel_Model label = new WebService.ProductLabel_Model();
                    label.invstd = txtcinvstd.Text;
                    label.Remark = "内部使用";
                    label.labeltype = "15";//国内的成品外箱
                    label.outpackqty = txtOutPackQty.Text;
                    label.materialno = txtMaterialNo.Text;
                    label.materialdesc = txtMaterialDesc.Text;
                    Stock_Model stockmodel = new Stock_Model();
                    stockmodel.AreaNo = currentDetail.AreaNo;
                    stockmodel.MaterialNo = currentDetail.MaterialNo;
                    stockmodel.MaterialDesc = currentDetail.MaterialDesc;
                    stockmodel.MaterialStd = currentDetail.MaterialStd;
                    stockmodel.WarehouseNo = currentDetail.WarehouseNo;
                    stockmodel.HouseNo = currentDetail.HouseNo;
                    if (!WMS.Common.WMSWebService.service.CreateInitialProductBarcode(stockmodel, label, Convert.ToInt16(txtBatchQty.Text), ref label_lst, ref strErrMsg))
                    {
                        MessageBox.Show("生成条码失败:" + strErrMsg);
                        return;
                    }
                    int printqty = Convert.ToInt16(txtPrintQty.Text);
                    List<WebService.ProductLabel_Model> list = new List<WebService.ProductLabel_Model>();
                    for (int i = 0; i < label_lst.Count; i++)
                    {
                        label_lst[i].qrbarcode = Print_Func.ConvertImageToString(Print_Func.CreateQRCode(label_lst[i].barcode));
                        for (int j = 0; j < printqty; j++)
                        {
                            list.Add(label_lst[i]);
                        }
                    }
                    FrmStockLabelPrint frm = new FrmStockLabelPrint(model, list);
                    frm.ShowDialog();
                    txtWhereMaterialNo.Text = "";
                    txtWhereWarehouseNo.Text = "";
                    txtWhereHouseNo.Text = "";
                    txtWhereAreaNo.Text = "";
                    btnSearch_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
