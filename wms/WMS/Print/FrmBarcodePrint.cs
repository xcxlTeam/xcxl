using ExcelLibrary;
using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WMS.Print
{
    public partial class FrmBarcodePrint : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        private Barcode_Model queryMain;
        private List<Barcode_Model> lstMain;

        public FrmBarcodePrint()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);
        }

        private void FrmBarcodePrint_Load(object sender, EventArgs e)
        {
            SetSearchBtn();
            InitForm();
            //BindList();
           if (!Print_Func.CheckPrinter()) return;
        }

        private void tsmiPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                PrintLabel();
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

        private void tsmiImport_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                ImportStock();

                BindList();
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

        private void tsmiDeal_Click(object sender, EventArgs e)
        {
            DealStock();
        }

        private void tsmiChangePrinter_Click(object sender, EventArgs e)
        {
            try
            {
                //this.Cursor = Cursors.WaitCursor;

                Print_Func.ChangePrinter();
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

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;

                    BindList();
                }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                BindList();
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

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        private void dgvList_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll) return;

            cbxSelectAll.Visible = e.NewValue == 0;
        }

        private void cbxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            SelectAll();
        }


        #region Function

        private void InitForm()
        {
            bool isYZ = Common_Var.CurrentUser.LoginDevice.IndexOf("LUCIFER") >= 0;
            if (isYZ && Common_Var.CurrentUser.UserType == 1) tsmiImport.Visible = true;
            if (isYZ && Common_Var.CurrentUser.UserType == 1) tsmiDeal.Visible = true;

            InitMainQuery();

            //BindList();
        }

        private void InitMainQuery()
        {
            _serverMainPage = new DividPage();
            queryMain = new Barcode_Model();
            lstMain = new List<Barcode_Model>();

            queryMain.BATCHNO = "2015091800001";
            queryMain.SN = "15091800001";
            txtBatchNo.Enabled = false;
            txtSN.Enabled = false;
            colCreateTime.Visible = false;
            //colStrVoucherType.Visible = false;
            colDELIVERYNO.Visible = false;
            colPRDVERSION.Visible = false;
            colSUPCODE.Visible = false;
            colSUPNAME.Visible = false;

            pageList.GetShowCountsByDGV(dgvList);
            bsMain.DataSource = queryMain;

            cbxSelectAll.Width = colSelect.Width;
            cbxSelectAll.BackColor = dgvList.ColumnHeadersDefaultCellStyle.BackColor;
            cbxSelectAll.Font = dgvList.ColumnHeadersDefaultCellStyle.Font;
        }

        private void BindList()
        {
            pageList.dDividPage.CurrentPageNumber = 1;
            GetListQueryData();
        }

        private void GetListQueryData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bsMain.EndEdit();

                bool bResult = false;
                string strErr = string.Empty;
                GetQueryMain();

                if (queryMain.StartTime != null && queryMain.EndTime != null)
                {
                    if (queryMain.StartTime.ToDateTime().Date > queryMain.EndTime.ToDateTime().Date)
                    {
                        Common.Common_Func.ErrorMessage("开始日期不能大于结束日期", "查询失败");
                        return;
                    }
                }

                ChensControl.DividPage clientPage = pageList.dDividPage;
                Common.Common_Func.GetServerPageFromClientPage(ref _serverMainPage, clientPage);
                bResult = Print_Func.GetStockBarcodeListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
                Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
                pageList.ShowPage();
                dgvList.DataSource = lstMain;

                if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败");

                if (dgvList.DataSource == null || dgvList.Rows.Count <= 0)
                {
                }
                else
                {
                    dgvList.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                }
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "查询失败");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                cbxSelectAll.Checked = false;
                txtAreaNo.Focus();
            }
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new Barcode_Model(); bsMain.DataSource = queryMain; }
            if (dtpStartTime.Checked) queryMain.StartTime = dtpStartTime.Value;
            else queryMain.StartTime = null;
            if (dtpEndTime.Checked) queryMain.EndTime = dtpEndTime.Value;
            else queryMain.EndTime = null;
        }

        private void ImportStock()
        {
            //if (ExcelLibrary.ExcelLibrary_Func.ReadExcelToListByNPOI(ref lstMain))
            //    dgvList.DataSource = lstMain;

            try
            {
                //int iSize = 5000;
                string tableName = "T_P_IMPORTSTOCK";
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                //lblMassage.Text = "文件读取中...";
                //lblMassage.Refresh();

                Dictionary<string, string> dicDefault = new Dictionary<string, string>();
                dicDefault.Add("STATUS", "1");
                dicDefault.Add("ISDEL", "1");
                dicDefault.Add("IMPORTSTATUS", "0");
                dicDefault.Add("IMPORTDATE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                dicDefault.Add("IMPORTUSER", Common_Var.CurrentUser.UserNo);
                Dictionary<string, string> dicFields = new Dictionary<string, string>();
                dicFields.Add("货位编号", "AREANO");
                dicFields.Add("物料编号", "MATERIALNO");
                //dicFields.Add("物料描述", "MATERIALDESC");
                dicFields.Add("数量", "QTY");
                string strError = string.Empty;
                //List<T_SupplierStockInfo> lstImport = new List<T_SupplierStockInfo>();
                //lblMassage.Text = "数据载入中...";
                //lblMassage.Refresh();

                List<string> lstSql = new List<string>();
                if (ExcelLibrary_Func.ReadExcelToSqlListByNPOI(ref lstSql, tableName, dicFields, dicDefault))
                {
                    this.Refresh();
                    Application.DoEvents();

                    if (lstSql == null || lstSql.Count <= 0)
                    {
                        MessageBox.Show("导入出错,读取的文件内容为空!", "错误");
                        return;
                    }

                    string strFields = lstSql[0].Substring(0, lstSql[0].IndexOf(')') + 1);
                    if (Common_Func.IsIncludeChinese(strFields))
                    {
                        MessageBox.Show("导入出错,读取的文件格式不匹配,找不到对应的列!", "错误");
                        return;
                    }
                    string sql = lstSql.Find(delegate(string temp) { return temp.IndexOf(",,") >= 0; });
                    if (!string.IsNullOrEmpty(sql))
                    {
                        MessageBox.Show("导入出错,读取的文件格式不匹配,不允许导入空值!", "错误");
                        return;
                    }

                    //lblMassage.Text = "数据上传中...";
                    //lblMassage.Refresh();
                    this.Refresh();
                    Application.DoEvents();
                    if (!Common_Func.CheckImportTable(ImportType.Stock, ref strError))
                    {
                        MessageBox.Show("导入出错," + strError, "错误");
                        return;
                    }
                    lstSql.Insert(0, string.Format("DELETE {0} \n", tableName));

                    if (lstSql.Count / Common_Var.OnceImportSize >= 3)
                    {
                        MessageBox.Show("导入数据过于庞大,请选择手工导入", "提示");

                        ExcelLibrary_Func.WriteSqlListToText(lstSql);
                        return;
                    }

                    if (!Common_Func.UpLoadSql(lstSql, ref strError))
                    {
                        MessageBox.Show("导入出错," + strError, "错误");
                        return;
                    }

                    //lblMassage.Text = "数据处理中...";
                    //lblMassage.Refresh();
                    this.Refresh();
                    Application.DoEvents();
                    bool bResult = false;
                    //bResult = Common_Func.DealImport(ImportType.Stock, ref strError);
                    //lblMassage.Text = "导入完成";
                    //lblMassage.Refresh();

                    if (!bResult)
                    {
                        MessageBox.Show("导入出错," + strError, "提示");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("导入成功", "提示");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入失败," + ex.Message, "提示");
            }
            finally
            {
                Cursor = Cursors.Default;
                //lblMassage.Text = "";
                //lblMassage.Refresh();
            }
        }

        private void DealStock()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string strError = string.Empty;
                bool bResult = false;

                //bResult = Common_Func.DealImport(ImportType.Stock, ref strError);

                if (!bResult)
                {
                    MessageBox.Show("导入出错," + strError, "提示");
                    return;
                }
                else
                {
                    MessageBox.Show("导入成功", "提示");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入失败," + ex.Message, "提示");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void PrintLabel()
        {
            btnSearch.Focus();

            if (dgvList.Rows.Count <= 0)
            {
                Common.Common_Func.ErrorMessage("请先选中需要打印的外箱", "打印失败");
                return;
            }

            bool isPrinted = false;

            string strPrintCode = string.Empty;
            int iPrintQty = 0;
            int iPrintCount = 0;
            foreach (DataGridViewRow dgvr in dgvList.Rows)
            {
                if (dgvr.Cells["colSelect"].Value.ToBoolean())
                {
                    if (dgvr.Cells["colPrintQty"].Value == null)
                    {
                        iPrintQty = colPrintQty.DefaultCellStyle.NullValue.ToInt32();
                    }
                    else
                    {
                        try { iPrintQty = Convert.ToInt32(dgvr.Cells["colPrintQty"].Value); }
                        catch { iPrintQty = 0; }
                    }
                    if (iPrintQty <= 0)
                    {
                        Common.Common_Func.ErrorMessage("第" + dgvr.Index + 1 + "行数量输入错误", "打印失败");
                        continue;
                    }

                    isPrinted = true;

                    if (iPrintCount / Print_Var.OutboxPrintNum >= 1 || iPrintCount % Print_Var.OutboxPrintNum == 0)
                    {
                        iPrintCount = 0;
                        if (!string.IsNullOrEmpty(strPrintCode))
                        {
                            Print_Func.SendStringToPrinter(strPrintCode);
                        }

                        strPrintCode = string.Empty;
                    }

                    if (!PrintRow(lstMain[dgvr.Index], iPrintQty, ref strPrintCode)) continue;

                    iPrintCount += iPrintQty;
                }
            }

            if (!isPrinted)
            {
                Common.Common_Func.ErrorMessage("请先选中需要打印的外箱", "打印失败");
                return;
            }
            else
            {
                if (iPrintCount >= 1 && !string.IsNullOrEmpty(strPrintCode))
                {
                    Print_Func.SendStringToPrinter(strPrintCode);
                }

                if (cbxSelectAll.Checked)
                {
                    cbxSelectAll.Checked = false;
                }
                else
                {
                    SelectAll();
                }

                //GetListQueryData();
            }
        }


        private bool PrintRow(Barcode_Model barcode, int iPrintQty, ref string sPrintCode)
        {
            VoucherType type = (VoucherType)barcode.VOUCHERTYPE.ToInt32();
            string strLogo = Print_Func.GetBoxLogoStr(type);
            string strClear = Print_Func.GetBoxClearStr(type);
            string strOnce = Print_Func.GetBoxContentStr(type, barcode);
            if (string.IsNullOrEmpty(strOnce))
            {
                return Common.Common_Func.ErrorMessage("外箱标签 " + barcode.SERIALNO + " 打印失败", "打印失败");
            }


            string strContent = string.Empty;
            for (int i = 1; i <= iPrintQty; i++)
            {
                strContent += strOnce;
            }

            sPrintCode += strLogo;
            sPrintCode += strContent;
            sPrintCode += strClear;
            return true;
        }

        private void SelectAll()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Common.Common_Func.SetSelectAll(dgvList, cbxSelectAll.Checked);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, txtAreaNo, btnSearch, tsmiSearch);
        }

        #endregion

    }
}
