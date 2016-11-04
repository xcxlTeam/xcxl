using WMS.WebService;
using System;
using System.Windows.Forms;

namespace WMS.Basic
{
    public partial class FrmWarehouseFile : Common.FrmBaseDialog
    {
        private WarehouseInfo _back;
        private WarehouseInfo _warehouse;

        public FrmWarehouseFile()
        {
            //SetNewModel();

            //_back = Common.Common_Func.ConvertToModel<WarehouseInfo>(_warehouse);

            InitializeComponent();

            //bsWarehouse.DataSource = _warehouse;
        }

        public FrmWarehouseFile(WarehouseInfo model)
        {
            if (model == null) model = new WarehouseInfo();
            _warehouse = model;
            if (model.ID == 0) SetNewModel();

            _back = Common.Common_Func.ConvertToModel<WarehouseInfo>(_warehouse);

            InitializeComponent();

            bsWarehouse.DataSource = _warehouse;
        }

        private void FrmWarehouseFile_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            AddData();
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void tsmiSaveAdd_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                ClearForm();
            }
        }

        private void tsmiSaveClose_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                this.Close();
            }
        }

        #region Function

        private void InitForm()
        {
            if (this._warehouse.ID == 0)
            {
                this.Text = "新增仓库";
            }
            else
            {
                this.Text = "编辑仓库";
            }

            BindComboBoxs();

            bsWarehouse.ResetBindings(false);
            bsWarehouse.EndEdit();

            txtWarehouseNo.Focus();
            txtWarehouseNo.SelectAll();
        }

        private void BindComboBoxs()
        {
            Common.Common_Func.BindComboxBoxByKey(cbbWarehouseStatus.Name, cbbWarehouseStatus);
        }

        private void ClearForm()
        {
            _warehouse = new WarehouseInfo();
            SetNewModel();

            bsWarehouse.DataSource = _warehouse;
            bsWarehouse.EndEdit();

            txtWarehouseNo.Focus();
        }

        private void SetNewModel()
        {
            if (_warehouse == null) _warehouse = new WarehouseInfo();
            _warehouse.ID = 0;
            _warehouse.WarehouseType = 1;
            _warehouse.WarehouseStatus = 1;
            _warehouse.HouseCount = 0;
            _warehouse.HouseUsingCount = 0;
            _warehouse.IsDel = 1;
        }

        private void CloseForm()
        {
            if (_warehouse.ID >= 1)
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
            bsWarehouse.EndEdit();

            if (!Common.Common_Func.EqualsValues(_warehouse, _back))
            {
                DialogResult dr = MessageBox.Show("当前仓库已经修改,是否保存当前的改动?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes) return SaveData();
            }

            return true;
        }

        private bool SaveData()
        {
            if (!CheckInput()) return false;

            string strErr = string.Empty;
            if (Basic_Func.SaveWarehouse(ref _warehouse, ref strErr))
            {
                Common.Common_Func.ErrorMessage("仓库保存成功！", "保存成功");
                bsWarehouse.DataSource = _warehouse;
                InitForm();
                _back = Common.Common_Func.ConvertToModel<WarehouseInfo>(_warehouse);
                return true;
            }
            else
            {
                Common.Common_Func.ErrorMessage(strErr, "保存失败");
                bsWarehouse.DataSource = _warehouse;
                return false;
            }
        }

        private bool CheckInput()
        {
            bsWarehouse.EndEdit();

            if (string.IsNullOrEmpty(_warehouse.WarehouseNo))
            {
                Common.Common_Func.ErrorMessage("仓库编号不能为空", "保存失败");
                return false;
            }
            if (string.IsNullOrEmpty(_warehouse.WarehouseName))
            {
                Common.Common_Func.ErrorMessage("仓库名称不能为空", "保存失败");
                return false;
            }
            if (_warehouse.WarehouseNo.Length != 2)
            {
                Common.Common_Func.ErrorMessage("仓库编号必须为2位", "保存失败");
                return false;
            }

            return true;
        }

        #endregion
    }
}
