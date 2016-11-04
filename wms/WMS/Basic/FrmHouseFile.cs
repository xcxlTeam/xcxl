using WMS.WebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS.Basic
{
    public partial class FrmHouseFile : Common.FrmBaseDialog
    {
        private HouseInfo _back;
        private HouseInfo _house;
        private WarehouseInfo _warehouse;

        public FrmHouseFile()
        {
            //SetNewModel();

            //_back = Common.Common_Func.ConvertToModel<HouseInfo>(_house);

            InitializeComponent();

            //bsHouse.DataSource = _house;
        }

        public FrmHouseFile(HouseInfo model, WarehouseInfo warehouse)
        {
            if (model == null) model = new HouseInfo();
            _house = model;
            _warehouse = warehouse;
            if (model.ID == 0) SetNewModel();

            _back = Common.Common_Func.ConvertToModel<HouseInfo>(_house);

            InitializeComponent();

            bsHouse.DataSource = _house;
        }

        private void FrmHouseFile_Load(object sender, EventArgs e)
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
            if (this._house.ID == 0)
            {
                this.Text = "新增库区";
            }
            else
            {
                this.Text = "编辑库区";
            }

            BindComboBoxs();

            bsHouse.ResetBindings(false);
            bsHouse.EndEdit();

            txtHouseNo.Focus();
            txtHouseNo.SelectAll();
        }

        private void BindComboBoxs()
        {
            Common.Common_Func.BindComboxBoxByKey(cbbHouseStatus.Name, cbbHouseStatus);
        }

        private void ClearForm()
        {
            _house = new HouseInfo();
            SetNewModel();

            if (_house.WarehouseID == 0) _house.WarehouseID = _back.WarehouseID;

            bsHouse.DataSource = _house;
            bsHouse.EndEdit();

            txtHouseNo.Focus();
        }

        private void SetNewModel()
        {
            if (_house == null) _house = new HouseInfo();
            _house.ID = 0;
            _house.HouseType = 1;
            _house.HouseStatus = 1;
            _house.IsDel = 1;
            _house.AreaCount = 0;
            _house.AreaUsingCount = 0;

            //if (_warehouse != null)
            //{
            //    _house.HouseNo = _warehouse.WarehouseNo;
            //    _house.HouseName = _warehouse.WarehouseName;
            //}
        }

        private void CloseForm()
        {
            if (_house.ID >= 1)
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
            bsHouse.EndEdit();

            if (!Common.Common_Func.EqualsValues(_house, _back))
            {
                DialogResult dr = MessageBox.Show("当前库区已经修改,是否保存当前的改动?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes) return SaveData();
            }

            return true;
        }

        private bool SaveData()
        {
            bsHouse.EndEdit();

            if (!CheckInput()) return false;

            string strErr = string.Empty;
            if (Basic_Func.SaveHouse(ref _house, ref strErr))
            {
                Common.Common_Func.ErrorMessage("库区保存成功！", "保存成功");
                bsHouse.DataSource = _house;
                InitForm();
                _back = Common.Common_Func.ConvertToModel<HouseInfo>(_house);
                return true;
            }
            else
            {
                Common.Common_Func.ErrorMessage(strErr, "保存失败");
                bsHouse.DataSource = _house;
                return false;
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(_house.HouseNo))
            {
                Common.Common_Func.ErrorMessage("库区编号不能为空", "保存失败");
                return false;
            }
            if (string.IsNullOrEmpty(_house.HouseName))
            {
                Common.Common_Func.ErrorMessage("库区名称不能为空", "保存失败");
                return false;
            }
            //if (_house.HouseNo.Length != 3)
            //{
            //    Common.Common_Func.ErrorMessage("库区编号必须为3位", "保存失败");
            //    return false;
            //}

            return true;
        }

        #endregion

        private void txtHouseNo_KeyUp(object sender, KeyEventArgs e)
        {
            //if (!_house.HouseName.EndsWith("货架")) return;

            //string houseno = txtHouseNo.Text.Trim();
            //if (string.IsNullOrEmpty(houseno))
            //{
            //    _house.HouseName = string.Empty;
            //}
            //else
            //{
            //    _house.HouseName = string.Format("{0}货架", houseno);
            //}
        }
    }
}
