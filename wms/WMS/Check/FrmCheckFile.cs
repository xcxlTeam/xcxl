using WMS.WebService;
using WMS.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace WMS.Check
{
    public partial class FrmCheckFile : Common.FrmBaseDialog
    {
        private System.Drawing.Size showsize;

        private bool isInit;
        private CheckInfo _back;
        private CheckInfo _check;

        private DividPage _serverListPage;
        private CheckDetailsInfo queryList;
        private List<CheckDetailsInfo> lstMain;
        private DividPage _serverSelectPage;
        private CheckDetailsInfo querySelect;
        private List<CheckDetailsInfo> lstSelect;
        private List<UserInfo> lstKeeper;

        public FrmCheckFile()
        {
            InitializeComponent();
            showsize = this.Size;
        }

        public FrmCheckFile(CheckInfo model)
        {
            if (model == null) model = new CheckInfo();
            _check = model;
            if (model.ID == 0) SetNewModel();

            _back = Common.Common_Func.ConvertToModel<CheckInfo>(_check);

            InitializeComponent();
            showsize = this.Size;
            // TODO: Complete member initialization

            bsMain.DataSource = _check;
        }

        private void FrmCheckFile_Load(object sender, EventArgs e)
        {
            this.Size = showsize;

            InitForm();
        }

        private void tsmiSaveClose_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                this.Close();
            }
        }

        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void cbbCheckType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInit) return;

            SetTabPageByType();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                BindSelect();
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "程序异常", 3);
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

                    BindSelect();
                }
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "程序异常", 3);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0) return;

            DataGridView dgv = sender as DataGridView;
            if (dgv.Name == dgvList.Name) return;

            bool bSelect = dgv[e.ColumnIndex, e.RowIndex].Value.ToBoolean();
            if (lstMain == null) lstMain = new List<CheckDetailsInfo>();
            CheckDetailsInfo item = lstSelect[e.RowIndex];
            if (bSelect)
            {
                if (_check.CheckType == 5 && lstMain != null && lstMain.Count >= 1)
                {
                    if (lstMain.Exists(t => t.Keeper != item.Keeper))
                    {
                        if (!Common.Common_Func.DialogMessage("当前选中项与已选盘点项的保管员不一致,是否清除之前选择的盘点项?", "提示"))
                        {
                            item.BIsChecked = !item.BIsChecked;
                            return;
                        }
                        else
                        {
                            lstMain = new List<CheckDetailsInfo>();
                        }
                    }
                }

                //if (lstMain.Contains(item)) return;
                CheckDetailsInfo temp = lstMain.FirstOrDefault(t => t.WarehouseNo == item.WarehouseNo && t.HouseNo == item.HouseNo && t.AreaNo == item.AreaNo && t.MaterialNo == item.MaterialNo);
                if (temp != null) return;
                lstMain.Add(item);
            }
            else
            {
                CheckDetailsInfo temp = lstMain.FirstOrDefault(t => t.WarehouseNo == item.WarehouseNo && t.HouseNo == item.HouseNo && t.AreaNo == item.AreaNo && t.MaterialNo == item.MaterialNo);
                if (temp == null) return;

                lstMain.Remove(temp);
            }
        }

        private void page_ChensPageChange(object sender, EventArgs e)
        {
            GetSelectQueryData();
        }

        private void pageList_ChensPageChange(object sender, EventArgs e)
        {
            GetListQueryData();
        }

        private void tcFile_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == tpDetail.Name)
            {
                BindList();
            }
        }

        private void dgvWarehouse_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll) return;

            cbxWSelectAll.Visible = e.NewValue == 0;
        }

        private void dgvHouse_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll) return;

            cbxHSelectAll.Visible = e.NewValue == 0;
        }

        private void dgvArea_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll) return;

            cbxASelectAll.Visible = e.NewValue == 0;
        }

        private void dgvMaterial_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll) return;

            cbxMSelectAll.Visible = e.NewValue == 0;
        }

        private void dgvKeeperMaterial_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll) return;

            cbxKSelectAll.Visible = e.NewValue == 0;
        }

        private void cbxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = sender as CheckBox;
            if (cbx == null) return;

            if (!SelectAll(cbx))
            {
            }
        }

        #region Function

        private void InitForm()
        {
            isInit = true;

            if (this._check.ID == 0)
            {
                this.Text = "新增盘点";
                pageList.Visible = false;
            }
            else
            {
                cbbCheckType.Enabled = false;
                if (_check.BIsMainCheck && _check.CheckStatus == 1)
                {
                    this.Text = "编辑盘点";
                    pageList.Visible = false;
                }
                else
                {
                    this.Text = "查看盘点";
                    tsmiSaveClose.Visible = false;
                    gbHeader.Enabled = false;
                }
            }

            BindComboBoxs();

            InitSelectQuery();

            bsMain.ResetBindings(false);
            bsMain.EndEdit();

            SetTabPageByType();

            //BindList();
            isInit = false;

            cbbCheckType.Focus();
            cbbCheckType.SelectAll();
        }

        private void InitSelectQuery()
        {
            lstMain = new List<CheckDetailsInfo>();
            querySelect = new CheckDetailsInfo();

            pageWarehouse.AutoGetRows(dgvWarehouse);
            pageHouse.AutoGetRows(dgvHouse);
            pageArea.AutoGetRows(dgvArea);
            pageMaterial.AutoGetRows(dgvMaterial);
            pageList.AutoGetRows(dgvList);

            bsSelect.DataSource = querySelect;
            bsSelect.EndEdit();
        }

        private void BindComboBoxs()
        {
            Common.Common_Func.BindComboxBoxByKey(cbbCheckType.Name, cbbCheckType);

            Common_Func.BindComboBoxAddAll(Check_Func.GetIsDifference(), cbbADifference);

            Common_Func.BindComboBoxAddAll(Check_Func.GetIsDifference(), cbbHDifference);

            Common_Func.BindComboBoxAddAll(Check_Func.GetIsDifference(), cbbWDifference);

            Common_Func.BindComboBoxAddAll(Check_Func.GetIsDifference(), cbbMDifference);

            Common_Func.BindComboBoxAddAll(Check_Func.GetIsDifference(), cbbKDifference);

            BindKeeperList();

            bsMain.ResetBindings(false);
            bsMain.EndEdit();

        }

        private void BindKeeperList()
        {
            string strError = string.Empty;
            //lstKeeper = FastTask.FastTask_Func.GetTempKeeperList(ref strError);
            if (lstKeeper == null || lstKeeper.Count <= 0)
            {
                lstKeeper = new List<UserInfo>();

                if (string.IsNullOrEmpty(strError))
                {
                    Common_Func.ErrorMessage("获取保管员信息错误!", "保管员获取失败", 2);
                }
                else
                {
                    Common_Func.ErrorMessage(strError, "保管员获取失败", 2);
                }
            }

            string[] arrKeeper = new string[lstKeeper.Count];
            int i = 0;
            foreach (UserInfo keeper in lstKeeper)
            {
                arrKeeper[i++] = keeper.UserName;
            }

            cbbKKeeper.DataSource = lstKeeper;
            cbbKKeeper.DisplayMember = "UserName";
            cbbKKeeper.ValueMember = "UserNo";
            cbbKKeeper.DropDownStyle = ComboBoxStyle.DropDown;
            cbbKKeeper.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbbKKeeper.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbKKeeper.AutoCompleteCustomSource.AddRange(arrKeeper);
        }

        private void ClearForm()
        {
            _check = new CheckInfo();
            SetNewModel();

            bsMain.DataSource = _check;
            bsMain.EndEdit();

            cbbCheckType.Focus();
        }

        private void SetNewModel()
        {
            if (_check == null) _check = new CheckInfo();
            _check.ID = 0;
            _check.CheckNo = string.Format("P{0}XXXXX", DateTime.Now.ToString("yyyyMM"));
            _check.CheckType = 1;
            _check.CheckStatus = 1;
            _check.CheckStyle = 1;
            _check.BIsMainCheck = true;
            _check.IsDel = 1;
            _check.lstDetails = new List<CheckDetailsInfo>();
        }

        private void CloseForm()
        {
            if (_check.ID >= 1)
            {
                if (!SaveChange()) return;
            }

            this.Close();
        }

        private void AddData()
        {
            if (!SaveChange()) return;

            ClearForm();
        }

        private bool SaveChange()
        {
            bsMain.EndEdit();

            if (_check.CheckStatus != 1) return true;

            if (!Common.Common_Func.EqualsValues(_check, _back))
            {
                if (Common.Common_Func.DialogMessage("当前盘点已经修改,是否保存当前的改动?", "提示")) return SaveData();
            }

            return true;
        }

        private bool SaveData()
        {
            bsMain.EndEdit();
            tcFile.SelectedTab = tpDetail;
            _check.lstDetails = lstMain;

            if (!CheckInput()) return false;

            if (_check.CheckType == 5) _check.DutyUser = querySelect.Keeper;
            else _check.DutyUser = Common_Var.CurrentUser.UserNo;

            string strErr = string.Empty;
            if (Check_Func.SaveCheck(ref _check, ref strErr))
            {
                Common.Common_Func.ErrorMessage(string.Format("盘点单保存成功！{0}盘点单号为：【{1}】", Environment.NewLine, _check.CheckNo), "保存成功");
                bsMain.DataSource = _check;
                InitForm();
                _back = Common.Common_Func.ConvertToModel<CheckInfo>(_check);
                return true;
            }
            else
            {
                Common.Common_Func.ErrorMessage(strErr, "保存失败", 2);
                bsMain.DataSource = _check;
                return false;
            }
        }

        private bool CheckInput()
        {
            if (lstMain == null || lstMain.Count <= 0)
            {
                return Common.Common_Func.ErrorMessage("应至少选择一项盘点信息", "提示");
            }

            if (_check.lstDetails == null || _check.lstDetails.Count <= 0)
            {
                return Common_Func.ErrorMessage("盘点信息必须勾选", "保存失败", 2);
            }

            return true;
        }

        private void SetTabPageByType()
        {
            bsMain.EndEdit();

            if (_check.CheckType != querySelect.CheckType)
            {
                #region 换页初始化

                lstMain = new List<CheckDetailsInfo>();
                querySelect = new CheckDetailsInfo();

                bsSelect.DataSource = querySelect;
                bsSelect.EndEdit();

                lstSelect = new List<CheckDetailsInfo>();
                dgvWarehouse.DataSource = null;
                dgvHouse.DataSource = null;
                dgvArea.DataSource = null;
                dgvMaterial.DataSource = null;
                dgvKeeperMaterial.DataSource = null;

                cbxWSelectAll.Checked = false;
                cbxHSelectAll.Checked = false;
                cbxASelectAll.Checked = false;
                cbxMSelectAll.Checked = false;
                cbxKSelectAll.Checked = false;
                #endregion
            }

            SetShownControl();
        }

        private void SetShownControl()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                tcFile.Enabled = false;
                tcFile.TabPages.Remove(tpWarehouse);
                tcFile.TabPages.Remove(tpHouse);
                tcFile.TabPages.Remove(tpArea);
                tcFile.TabPages.Remove(tpMaterial);
                tcFile.TabPages.Remove(tpKeeper);

                if (_check.CheckStatus != 1 || !_check.BIsMainCheck)
                {
                    tpDetail.Text = "盘点信息";
                }
                else
                {
                    #region 编辑状态不显示扫描信息
                    scanQtyDataGridViewTextBoxColumn.Visible = false;
                    statusDataGridViewTextBoxColumn.Visible = false;
                    strStatusDataGridViewTextBoxColumn.Visible = false;
                    operatorDataGridViewTextBoxColumn.Visible = false;
                    operationTimeDataGridViewTextBoxColumn.Visible = false;
                    profitLossDataGridViewTextBoxColumn.Visible = false;
                    differenceQtyDataGridViewTextBoxColumn.Visible = false;
                    haveDiffDataGridViewTextBoxColumn.Visible = false;
                    strHaveDiffDataGridViewTextBoxColumn.Visible = false;

                    #endregion
                }

                switch (_check.CheckType)
                {
                    case 1:
                        #region 按仓库
                        keeperDataGridViewTextBoxColumn.Visible = false;
                        warehouseNoDataGridViewTextBoxColumn.Visible = true;
                        warehouseNameDataGridViewTextBoxColumn.Visible = true;
                        houseNoDataGridViewTextBoxColumn.Visible = false;
                        houseNameDataGridViewTextBoxColumn.Visible = false;
                        areaNoDataGridViewTextBoxColumn.Visible = false;
                        areaNameDataGridViewTextBoxColumn.Visible = false;
                        materialNoDataGridViewTextBoxColumn.Visible = false;
                        materialDescDataGridViewTextBoxColumn.Visible = false;
                        materialStdDataGridViewTextBoxColumn.Visible = false;


                        if (_check.CheckStatus == 1 && _check.BIsMainCheck)
                        {
                            dgvWarehouse.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

                            tcFile.TabPages.Insert(0, tpWarehouse);
                            tcFile.SelectedTab = tpWarehouse;
                        }
                        else
                        {
                            tcFile.SelectedTab = tpDetail;
                        }
                        txtWWarehouse.Focus();
                        txtWWarehouse.SelectAll();

                        #endregion
                        break;

                    case 2:
                        #region 按库区
                        keeperDataGridViewTextBoxColumn.Visible = false;
                        warehouseNoDataGridViewTextBoxColumn.Visible = true;
                        warehouseNameDataGridViewTextBoxColumn.Visible = true;
                        houseNoDataGridViewTextBoxColumn.Visible = true;
                        houseNameDataGridViewTextBoxColumn.Visible = true;
                        areaNoDataGridViewTextBoxColumn.Visible = false;
                        areaNameDataGridViewTextBoxColumn.Visible = false;
                        materialNoDataGridViewTextBoxColumn.Visible = false;
                        materialDescDataGridViewTextBoxColumn.Visible = false;
                        materialStdDataGridViewTextBoxColumn.Visible = false;

                        if (_check.CheckStatus == 1 && _check.BIsMainCheck)
                        {
                            dgvHouse.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

                            tcFile.TabPages.Insert(0, tpHouse);
                            tcFile.SelectedTab = tpHouse;
                        }
                        else
                        {
                            tcFile.SelectedTab = tpDetail;
                        }
                        txtHWarehouse.Focus();
                        txtHWarehouse.SelectAll();

                        #endregion
                        break;

                    case 3:
                        #region 按货位
                        keeperDataGridViewTextBoxColumn.Visible = false;
                        warehouseNoDataGridViewTextBoxColumn.Visible = true;
                        warehouseNameDataGridViewTextBoxColumn.Visible = true;
                        houseNoDataGridViewTextBoxColumn.Visible = true;
                        houseNameDataGridViewTextBoxColumn.Visible = true;
                        areaNoDataGridViewTextBoxColumn.Visible = true;
                        areaNameDataGridViewTextBoxColumn.Visible = true;
                        materialNoDataGridViewTextBoxColumn.Visible = false;
                        materialDescDataGridViewTextBoxColumn.Visible = false;
                        materialStdDataGridViewTextBoxColumn.Visible = false;

                        if (_check.CheckStatus == 1 && _check.BIsMainCheck)
                        {
                            dgvArea.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

                            tcFile.TabPages.Insert(0, tpArea);
                            tcFile.SelectedTab = tpArea;
                        }
                        else
                        {
                            tcFile.SelectedTab = tpDetail;
                        }
                        txtAWarehouse.Focus();
                        txtAWarehouse.SelectAll();

                        #endregion
                        break;

                    case 4:
                        #region 按物料
                        keeperDataGridViewTextBoxColumn.Visible = false;
                        warehouseNoDataGridViewTextBoxColumn.Visible = true;
                        warehouseNameDataGridViewTextBoxColumn.Visible = true;
                        houseNoDataGridViewTextBoxColumn.Visible = false;
                        houseNameDataGridViewTextBoxColumn.Visible = false;
                        areaNoDataGridViewTextBoxColumn.Visible = false;
                        areaNameDataGridViewTextBoxColumn.Visible = false;
                        materialNoDataGridViewTextBoxColumn.Visible = true;
                        materialDescDataGridViewTextBoxColumn.Visible = true;
                        materialStdDataGridViewTextBoxColumn.Visible = true;

                        if (_check.CheckStatus == 1 && _check.BIsMainCheck)
                        {
                            dgvMaterial.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

                            tcFile.TabPages.Insert(0, tpMaterial);
                            tcFile.SelectedTab = tpMaterial;
                        }
                        else
                        {
                            tcFile.SelectedTab = tpDetail;
                        }
                        txtMWarehouse.Focus();
                        txtMWarehouse.SelectAll();

                        #endregion
                        break;

                    case 5:
                        #region 按保管员
                        keeperDataGridViewTextBoxColumn.Visible = true;
                        warehouseNoDataGridViewTextBoxColumn.Visible = true;
                        warehouseNameDataGridViewTextBoxColumn.Visible = true;
                        houseNoDataGridViewTextBoxColumn.Visible = false;
                        houseNameDataGridViewTextBoxColumn.Visible = false;
                        areaNoDataGridViewTextBoxColumn.Visible = false;
                        areaNameDataGridViewTextBoxColumn.Visible = false;
                        materialNoDataGridViewTextBoxColumn.Visible = true;
                        materialDescDataGridViewTextBoxColumn.Visible = true;
                        materialStdDataGridViewTextBoxColumn.Visible = true;

                        if (_check.CheckStatus == 1 && _check.BIsMainCheck)
                        {
                            dgvKeeperMaterial.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

                            tcFile.TabPages.Insert(0, tpKeeper);
                            tcFile.SelectedTab = tpKeeper;
                        }
                        else
                        {
                            tcFile.SelectedTab = tpDetail;
                        }

                        if (string.IsNullOrEmpty(querySelect.Keeper))
                        {
                            querySelect.Keeper = _check.DutyUser;
                        }

                        txtKKeeper.Focus();
                        txtKKeeper.SelectAll();

                        #endregion
                        break;

                    default:
                        tcFile.SelectedTab = tpDetail;
                        break;
                }
            }
            finally
            {
                tcFile.Enabled = true;
                querySelect.CheckType = _check.CheckType;

                Cursor.Current = Cursors.Default;
            }
        }


        private void BindSelect()
        {
            pageWarehouse.dDividPage.CurrentPageNumber = 1;
            pageHouse.dDividPage.CurrentPageNumber = 1;
            pageArea.dDividPage.CurrentPageNumber = 1;
            pageMaterial.dDividPage.CurrentPageNumber = 1;
            pageKeeper.dDividPage.CurrentPageNumber = 1;

            GetSelectQueryData();
        }

        private void GetSelectQueryData()
        {
            TextBox txt = txtWWarehouse;
            ChensControl.ChensPage page = pageWarehouse;
            DataGridView dgv = dgvWarehouse;
            CheckBox cbx = cbxWSelectAll;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                bsMain.EndEdit();
                bsSelect.EndEdit();

                bool bResult = false;
                string strError = string.Empty;
                GetQuerySelect();

                #region 获取当前选项卡
                switch (querySelect.CheckType)
                {
                    case 1:
                        txt = txtWWarehouse;
                        page = pageWarehouse;
                        dgv = dgvWarehouse;
                        cbx = cbxWSelectAll;
                        if (dtpWStockStartTime.Checked) querySelect.StartTime = dtpWStockStartTime.Value; else querySelect.StartTime = null;
                        if (dtpWStockEndTime.Checked) querySelect.EndTime = dtpWStockEndTime.Value; else querySelect.EndTime = null;
                        break;

                    case 2:
                        txt = txtHWarehouse;
                        page = pageHouse;
                        dgv = dgvHouse;
                        cbx = cbxHSelectAll;
                        if (dtpHStockStartTime.Checked) querySelect.StartTime = dtpHStockStartTime.Value; else querySelect.StartTime = null;
                        if (dtpHStockEndTime.Checked) querySelect.EndTime = dtpHStockEndTime.Value; else querySelect.EndTime = null;
                        break;

                    case 3:
                        txt = txtAWarehouse;
                        page = pageArea;
                        dgv = dgvArea;
                        cbx = cbxASelectAll;
                        if (dtpAStockStartTime.Checked) querySelect.StartTime = dtpAStockStartTime.Value; else querySelect.StartTime = null;
                        if (dtpAStockEndTime.Checked) querySelect.EndTime = dtpAStockEndTime.Value; else querySelect.EndTime = null;
                        break;

                    case 4:
                        txt = txtMWarehouse;
                        page = pageMaterial;
                        dgv = dgvMaterial;
                        cbx = cbxMSelectAll;
                        if (dtpMStockStartTime.Checked) querySelect.StartTime = dtpMStockStartTime.Value; else querySelect.StartTime = null;
                        if (dtpMStockEndTime.Checked) querySelect.EndTime = dtpMStockEndTime.Value; else querySelect.EndTime = null;
                        break;

                    case 5:
                        if (string.IsNullOrEmpty(querySelect.Keeper))
                        {
                            Common.Common_Func.ErrorMessage("保管员必须输入", "查询失败", 2);
                            return;
                        }

                        txt = txtKKeeper;
                        page = pageKeeper;
                        dgv = dgvKeeperMaterial;
                        cbx = cbxMSelectAll;
                        if (dtpKStockStartTime.Checked) querySelect.StartTime = dtpKStockStartTime.Value; else querySelect.StartTime = null;
                        if (dtpKStockEndTime.Checked) querySelect.EndTime = dtpKStockEndTime.Value; else querySelect.EndTime = null;
                        break;

                    default:
                        return;
                }

                #endregion

                if (querySelect.StartTime != null && querySelect.EndTime != null)
                {
                    if (querySelect.StartTime.ToDateTime().Date > querySelect.EndTime.ToDateTime().Date)
                    {
                        Common.Common_Func.ErrorMessage("开始日期不能大于结束日期", "查询失败", 2);
                        return;
                    }
                }

                if (lstSelect == null || lstSelect.Count <= 0) cbx.Checked = false;
                ChensControl.DividPage clientPage = page.dDividPage;
                Common.Common_Func.GetServerPageFromClientPage(ref _serverSelectPage, clientPage);
                bResult = Check_Func.GetCheckDetailsSelectListByPage(ref lstSelect, querySelect, ref _serverSelectPage, ref strError);
                Common.Common_Func.GetClientPageFromServerPage(_serverSelectPage, ref clientPage);
                SetChecked();
                page.ShowPage();
                dgv.DataSource = lstSelect;

                if (!bResult || !string.IsNullOrEmpty(strError))
                {
                    lstSelect = new List<CheckDetailsInfo>();
                    dgv.DataSource = lstSelect;
                    Common.Common_Func.ErrorMessage(strError, "查询失败", 2);
                }
            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "查询失败", 2);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                txt.Focus();
            }
        }

        private void SetChecked()
        {
            //if (_check.ID == 0) return;
            if (lstSelect == null || lstSelect.Count <= 0) return;

            switch (_check.CheckType)
            {
                case 1:
                    lstSelect.Join(lstMain, s => s.WarehouseNo, m => m.WarehouseNo, (s, m) => s).ToList().ForEach(t => t.BIsChecked = true);
                    break;

                case 2:
                    lstSelect.Join(lstMain, s => s.WarehouseNo + s.HouseNo, m => m.WarehouseNo + m.HouseNo, (s, m) => s).ToList().ForEach(t => t.BIsChecked = true);
                    break;

                case 3:
                    lstSelect.Join(lstMain, s => s.AreaNo, m => m.AreaNo, (s, m) => s).ToList().ForEach(t => t.BIsChecked = true);
                    break;

                case 4:
                    lstSelect.Join(lstMain, s => s.MaterialNo, m => m.MaterialNo, (s, m) => s).ToList().ForEach(t => t.BIsChecked = true);
                    break;

                case 5:
                    lstSelect.Join(lstMain, s => s.Keeper + s.WarehouseNo + s.MaterialNo, m => m.Keeper + m.WarehouseNo + m.MaterialNo, (s, m) => s).ToList().ForEach(t => t.BIsChecked = true);
                    break;
            }
        }

        private void GetQuerySelect()
        {
            if (querySelect == null) { querySelect = new CheckDetailsInfo(); bsSelect.DataSource = querySelect; }
            querySelect.CheckType = _check.CheckType;
            querySelect.CheckID = _check.ID;
        }

        private void BindList()
        {
            pageList.dDividPage.CurrentPageNumber = 1;
            pageList.DefaultPageShowCounts = -1;

            GetListQueryData();
        }

        private void GetListQueryData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bsMain.EndEdit();

                bool bResult = false;
                string strError = string.Empty;
                GetQueryList();

                if (_check.ID == 0)     //新增不取值
                {
                    lstMain = (from m in lstMain orderby m.StockTime descending, m.WarehouseNo, m.HouseNo, m.AreaNo, m.MaterialNo select m).ToList();
                    dgvList.DataSource = lstMain;
                    bResult = true;
                }
                else if (_check.CheckStatus == 1 && lstMain != null && lstMain.Count >= 1)  //编辑为空时取值
                {
                    lstMain = (from m in lstMain orderby m.StockTime descending, m.WarehouseNo, m.HouseNo, m.AreaNo, m.MaterialNo select m).ToList();
                    dgvList.DataSource = lstMain;
                    bResult = true;
                }
                else
                {
                    ChensControl.DividPage clientPage = pageList.dDividPage;
                    Common.Common_Func.GetServerPageFromClientPage(ref _serverListPage, clientPage);
                    if (!pageList.Visible) _serverListPage.CurrentPageShowCounts = -1;
                    bResult = Check_Func.GetCheckDetailsListByPage(ref lstMain, queryList, ref _serverListPage, ref strError);
                    Common.Common_Func.GetClientPageFromServerPage(_serverListPage, ref clientPage);
                    pageList.ShowPage();
                    dgvList.DataSource = lstMain;
                }

                if (!bResult || !string.IsNullOrEmpty(strError)) Common.Common_Func.ErrorMessage(strError, "查询失败", 2);

            }
            catch (Exception ex)
            {
                Common.Common_Func.ErrorMessage(ex.Message, "查询失败", 2);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GetQueryList()
        {
            if (queryList == null) { queryList = new CheckDetailsInfo(); }
            queryList.CheckID = _check.ID;
            if (_check.CheckStatus == 1) queryList.CheckType = _check.CheckType; else queryList.CheckType = 0;
        }

        private bool SelectAll(CheckBox cbx)
        {
            if (lstSelect == null || lstSelect.Count <= 0) return false;

            foreach (CheckDetailsInfo item in lstSelect)
            {
                lstMain.RemoveAll(t => t.WarehouseNo == item.WarehouseNo && t.HouseNo == item.HouseNo && t.AreaNo == item.AreaNo && t.MaterialNo == item.MaterialNo);

                item.BIsChecked = cbx.Checked;
                if (cbx.Checked)
                {
                    lstMain.Add(item);
                }
            }

            dgvWarehouse.Refresh();
            dgvHouse.Refresh();
            dgvArea.Refresh();
            dgvMaterial.Refresh();
            dgvKeeperMaterial.Refresh();

            return true;
        }



        #endregion

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            ExcelLibrary.ExcelLibrary_Func.SaveDataGridViewToExcelByNPOI(dgvList, true, false, this.Name);
        }
    }
}
