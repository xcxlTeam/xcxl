using ExcelLibrary;
using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace WMS.Basic
{
    public partial class FrmAreaList : Common.FrmBasic
    {
        private DividPage _serverMainPage;
        private HouseInfo queryMain;
        private List<HouseInfo> lstMain;
        private DividPage _serverDetailsPage;
        private AreaInfo queryDetails;
        private List<AreaInfo> lstDetails;

        public FrmAreaList()
        {
            InitializeComponent();

            Common.Common_Func.DelDataGridViewSortable(dgvList);
            Common.Common_Func.DelDataGridViewSortable(dgvDetail);
        }

        private void FrmAreaList_Load(object sender, EventArgs e)
        {
            SetSearchBtn();

            InitForm();
        }

        private void FrmAreaList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Common_Func.RemoveTabPageForm(this);
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            AddArea();
        }

        private void tsmiDel_Click(object sender, EventArgs e)
        {
            DelArea();
        }

        private void tsmiImport_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                ImportArea();

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

        private void tsmiDownload_Click(object sender, EventArgs e)
        {
            DownloadTemplates();
        }

        private void tsmiPrintArea_Click(object sender, EventArgs e)
        {
            Print.FrmAreaPrint frm = new Print.FrmAreaPrint();
            Common_Func.ShowTabPageForm(this, frm);
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
            BindList();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BindDetails(e);
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EditArea(e);
        }

        private void pageDetail_ChensPageChange(object sender, EventArgs e)
        {
            GetDetailsQueryData();
        }

        #region Function

        private void InitForm()
        {
            InitMainQuery();

            InitDetailsQuery();

            //BindList();
        }

        private void InitMainQuery()
        {
            _serverMainPage = new DividPage();
            queryMain = new HouseInfo();
            lstMain = new List<HouseInfo>();

            pageList.GetShowCountsByDGV(dgvList);
            bsMain.DataSource = queryMain;
        }

        private void InitDetailsQuery()
        {
            _serverDetailsPage = new DividPage();
            queryDetails = new AreaInfo();
            lstDetails = new List<AreaInfo>();

            pageDetail.GetShowCountsByDGV(dgvDetail);

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

                ChensControl.DividPage clientPage = pageList.dDividPage;
                Common.Common_Func.GetServerPageFromClientPage(ref _serverMainPage, clientPage);
                bResult = Basic_Func.GetHouseListByPage(ref lstMain, queryMain, ref _serverMainPage, ref strErr);
                Common.Common_Func.GetClientPageFromServerPage(_serverMainPage, ref clientPage);
                pageList.ShowPage();
                dgvList.DataSource = lstMain;

                if (!bResult || !string.IsNullOrEmpty(strErr)) Common.Common_Func.ErrorMessage(strErr, "查询失败");

                if (dgvList.DataSource == null || dgvList.Rows.Count <= 0)
                {
                    lstDetails = new List<AreaInfo>();
                    dgvDetail.DataSource = lstDetails;
                    return;
                }
                else
                {
                    //dgvList.CurrentCell = dgvList[0, 0];
                    pageDetail.dDividPage.CurrentPageNumber = 1;
                    GetDetailsQueryData();
                }

            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "查询失败");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                txtWarehouseNo.Focus();
            }
        }

        private void GetQueryMain()
        {
            if (queryMain == null) { queryMain = new HouseInfo(); bsMain.DataSource = queryMain; }
        }

        private void BindDetails(DataGridViewCellEventArgs e)
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList, e)) return;

            pageDetail.dDividPage.CurrentPageNumber = 1;
            GetDetailsQueryData();
        }

        private void GetDetailsQueryData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool bResult = false;
                string strErr = string.Empty;
                GetQueryDetails();

                ChensControl.DividPage clientPage = pageDetail.dDividPage;
                Common.Common_Func.GetServerPageFromClientPage(ref _serverDetailsPage, clientPage);
                bResult = Basic_Func.GetAreaListByPage(ref lstDetails, queryDetails, ref _serverDetailsPage, ref strErr);
                Common.Common_Func.GetClientPageFromServerPage(_serverDetailsPage, ref clientPage);
                pageDetail.ShowPage();
                dgvDetail.DataSource = lstDetails;

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

        private void GetQueryDetails()
        {
            if (queryDetails == null) queryDetails = new AreaInfo();
            queryDetails.HouseID = lstMain[dgvList.CurrentCell.RowIndex].ID;
            queryDetails.WarehouseNo = queryMain.WarehouseNo;
            queryDetails.HouseNo = queryMain.HouseNo;
            queryDetails.AreaNo = queryMain.AreaNo;
            queryDetails.Creater = txtCreater.Text.Trim();
            if (dtpStartTime.Checked) queryDetails.StartTime = dtpStartTime.Value;
            else queryDetails.StartTime = null;
            if (dtpEndTime.Checked) queryDetails.EndTime = dtpEndTime.Value;
            else queryDetails.EndTime = null;
        }

        private void AddArea()
        {
            if (!Common.Common_Func.CheckDgvOper(dgvList))
            {
                Common.Common_Func.ErrorMessage("请先选中一行库区", "删除失败");
                return;
            }

            AreaInfo house = new AreaInfo() { ID = 0, HouseID = lstMain[dgvList.CurrentCell.RowIndex].ID };

            ShowFileForm(house);
        }

        private void DelArea()
        {
            if (!Common.Common_Func.CheckDgvOper(dgvDetail))
            {
                Common.Common_Func.ErrorMessage("请先选中一行货位", "删除失败");
                return;
            }

            DeleteDetailsRow(dgvDetail.CurrentCell.RowIndex);
        }

        private void DeleteDetailsRow(int iRowIndex)
        {
            AreaInfo area = GetDetailsRowModel(iRowIndex);
            if (area == null) return;

            if (MessageBox.Show(string.Format("是否确认删除货位【{0}】?", area.AreaName), "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No) return;

            try
            {
                if (area.IsDel != 2)
                {
                    string strErr = string.Empty;
                    if (!Basic_Func.DeleteAreaByID(area, ref strErr))
                    {
                        Common.Common_Func.ErrorMessage(strErr, "删除失败");
                        return;
                    }
                }

                Common.Common_Func.ErrorMessage("删除货位成功", "删除成功");
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message);
            }
            finally
            {
                GetListQueryData();
            }
        }

        private void EditArea(DataGridViewCellEventArgs e)
        {
            if (!Common.Common_Func.CheckDgvOper(dgvDetail, e, "编辑")) return;

            EditDetailsRow(e.RowIndex);
        }

        private void EditDetailsRow(int iRowIndex)
        {
            AreaInfo area = GetDetailsRowModel(iRowIndex);
            if (area == null) return;

            ShowFileForm(area);
        }

        private AreaInfo GetDetailsRowModel(int iRowIndex)
        {
            string strErr = string.Empty;
            AreaInfo area = new AreaInfo();
            area.ID = lstDetails[iRowIndex].ID;

            if (!Basic_Func.GetAreaByID(ref area, ref strErr))
            {
                Common.Common_Func.ErrorMessage(strErr, "读取失败");
                GetListQueryData();
                return null;
            }

            return area;
        }

        private void ShowFileForm(AreaInfo area)
        {
            HouseInfo house = GetBelongHouse(area.HouseID);
            if (house == null) return;

            using (FrmAreaFile frm = new FrmAreaFile(area, house))
            {
                frm.ShowDialog();
            }

            this.Refresh();
            Application.DoEvents();

            GetListQueryData();
        }

        private HouseInfo GetBelongHouse(int HouseID)
        {
            HouseInfo house = new HouseInfo();

            if (HouseID <= 0)
            {
                Common.Common_Func.ErrorMessage("获取库区信息失败", "错误");
                return null;
            }
            else
            {
                string strError = string.Empty;
                house = new HouseInfo() { ID = HouseID };

                if (!Basic_Func.GetHouseByID(ref house, ref strError))
                {
                    Common.Common_Func.ErrorMessage(strError, "错误");
                    return null;
                }
            }

            return house;
        }

        private void ImportArea()
        {
            //if (ExcelLibrary.ExcelLibrary_Func.ReadExcelToListByNPOI(ref lstMain))
            //    dgvList.DataSource = lstMain;

            try
            {
                //int iSize = 5000;
                string tableName = "T_P_IMPORTAREA";
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                //lblMassage.Text = "文件读取中...";
                //lblMassage.Refresh();

                Dictionary<string, string> dicDefault = new Dictionary<string, string>();
                dicDefault.Add("WAREHOUSESTATUS", "1");
                dicDefault.Add("HOUSESTATUS", "1");
                dicDefault.Add("AREASTATUS", "1");
                dicDefault.Add("IMPORTSTATUS", "0");
                dicDefault.Add("IMPORTDATE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                dicDefault.Add("IMPORTUSER", Common_Var.CurrentUser.UserNo);
                dicDefault.Add("AREATYPENAME", "正式货位");
                Dictionary<string, string> dicFields = new Dictionary<string, string>();
                dicFields.Add("仓库编号", "WAREHOUSENO");
                dicFields.Add("仓库名称", "WAREHOUSENAME");
                dicFields.Add("库区编号", "HOUSENO");
                dicFields.Add("库区名称", "HOUSENAME");
                dicFields.Add("货位编号", "AREANO");
                dicFields.Add("货位名称", "AREANAME");
                dicFields.Add("货位类型", "AREATYPENAME");
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
                    if (!Common_Func.CheckImportTable(ImportType.Area, ref strError))
                    {
                        MessageBox.Show("导入出错," + strError, "错误");
                        return;
                    }
                    lstSql.Insert(0, string.Format("DELETE {0} \n", tableName));

                    if (lstSql.Count / Common_Var.OnceImportSize >= 2)
                    {
                        MessageBox.Show("导入数据过于庞大,请拆分后导入", "提示");

                        //ExcelLibrary_Func.WriteSqlListToText(lstSql);
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
                    //bResult = Common_Func.DealImport(ImportType.Area, ref strError);
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

        private void DownloadTemplates()
        {
            string strError = string.Empty;
            List<WarehouseInfo> lstWH = new List<WarehouseInfo>();
            if (!Basic_Func.GetWarehouseList(ref lstWH, new WarehouseInfo(), ref strError))
            {
                MessageBox.Show(strError);
                return;
            }
            if (lstWH == null || lstWH.Count <= 0)
            {
                MessageBox.Show("未获取到任何仓库");
                return;
            }

            DataSet dsWH = ConvertList2DataSet(lstWH);

            string path = "货位导入格式";
            if (!Common_Func.ShowSaveDialog(ref path, "xlsx")) return;

            byte[] bArea;
            bool isXSSF = Path.GetExtension(path).ToLower() == (".xlsx");
            bArea = isXSSF ? Properties.Resources.AreaTemplateXLSX : Properties.Resources.AreaTemplateXLS;
            if (Common_Func.SaveBytesToFile(path, bArea))
            {
                ExcelLibrary_Func.AddDataSetToExcelByNPOI(path, dsWH);

                if (MessageBox.Show(string.Format("文件已成功保存到【{0}】！{1}是否直接打开?", path, Environment.NewLine), "保存成功", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(path);
                }
            }
        }

        private DataSet ConvertList2DataSet(List<WarehouseInfo> lstWH)
        {
            DataSet ds = new DataSet("WarehouseInfo");
            DataTable dt = new DataTable("仓库");
            dt.Columns.Add("仓库编号", typeof(string));
            dt.Columns.Add("仓库名称", typeof(string));

            DataRow dr;
            foreach (WarehouseInfo wh in lstWH)
            {
                dr = dt.NewRow();
                dr["仓库编号"] = wh.WarehouseNo;
                dr["仓库名称"] = wh.WarehouseName;
                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);

            return ds;
        }

        private void SetSearchBtn()
        {
            Common.Common_Func.SetSearchBtn(this, txtAreaNo, btnSearch, tsmiSearch);
        }

        #endregion

    }
}
