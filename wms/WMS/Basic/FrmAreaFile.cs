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
    public partial class FrmAreaFile : Common.FrmBaseDialog
    {
        private AreaInfo _back;
        private AreaInfo _area;
        private HouseInfo _house;

        public FrmAreaFile()
        {
            //SetNewModel();

            //_back = Common.Common_Func.ConvertToModel<AreaInfo>(_area);

            InitializeComponent();

            //bsArea.DataSource = _area;
        }

        public FrmAreaFile(AreaInfo model, HouseInfo house)
        {
            if (model == null) model = new AreaInfo();
            _area = model;
            _house = house;
            if (model.ID == 0) SetNewModel();

            _back = Common.Common_Func.ConvertToModel<AreaInfo>(_area);

            InitializeComponent();

            bsArea.DataSource = _area;
        }

        private void FrmAreaFile_Load(object sender, EventArgs e)
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
            if (this._area.ID == 0)
            {
                this.Text = "新增货位";
                txtAreaNoLeft.Text = _area.AreaNo;
            }
            else
            { 
                this.Text = "编辑货位";
                string[] array_str = _area.AreaNo.Split('-');
                txtAreaNoLeft.Text = array_str[0] + '-' + array_str[1];//_area.AreaNo.Substring(0, 4);
                txtAreaNoRight.Text = _area.AreaNo.Substring(array_str[0].Length + array_str[1].Length + 2);//_area.AreaNo.Remove(0, 4);
            }

            BindComboBoxs();

            bsArea.ResetBindings(false);
            bsArea.EndEdit();

            txtAreaNoRight.Focus();
            txtAreaNoRight.SelectAll();
        }

        private void BindComboBoxs()
        {
            Common.Common_Func.BindComboxBoxByKey(cbbAreaType.Name, cbbAreaType);
            Common.Common_Func.BindComboxBoxByKey(cbbAreaStatus.Name, cbbAreaStatus);
        }

        private void ClearForm()
        {
            _area = new AreaInfo();
            SetNewModel();

            if (_area.HouseID == 0) _area.HouseID = _back.HouseID;

            bsArea.DataSource = _area;
            bsArea.EndEdit();
            txtAreaNoLeft.Text = _area.AreaNo;

            txtAreaNoRight.Focus();
        }

        private void SetNewModel()
        {
            if (_area == null) _area = new AreaInfo();
            _area.ID = 0;
            _area.AreaType = 1;
            _area.AreaStatus = 1;
            _area.IsDel = 1;

            if (_house != null)
            {
                _area.AreaNo = string.Format("{0}-{1}", _house.WarehouseNo, _house.HouseNo);
                //_area.AreaName = string.Format("{0}{1}", _house.WarehouseName, _house.HouseName);
            }
        }

        private void CloseForm()
        {
            if (_area.ID >= 1)
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
            bsArea.EndEdit();

            if (!Common.Common_Func.EqualsValues(_area, _back))
            {
                DialogResult dr = MessageBox.Show("当前货位已经修改,是否保存当前的改动?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes) return SaveData();
            }

            return true;
        }

        private bool SaveData()
        {
            bsArea.EndEdit();

            _area.AreaNo = string.Format("{0}-{1}", txtAreaNoLeft.Text, txtAreaNoRight.Text);
            _area.AreaName = txtAreaName.Text;
            if (!CheckInput()) return false;
            //_area.AreaStatus = 1;
            //_area.IsDel = 1;
            _area.CreateTime = DateTime.Today;
            string strErr = string.Empty;
            if (Basic_Func.SaveArea(ref _area, ref strErr))
            {
                Common.Common_Func.ErrorMessage("货位保存成功！", "保存成功");
                bsArea.DataSource = _area;
                InitForm();
                _back = Common.Common_Func.ConvertToModel<AreaInfo>(_area);
                return true;
            }
            else
            {
                Common.Common_Func.ErrorMessage(strErr, "保存失败");
                bsArea.DataSource = _area;
                return false;
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(_area.AreaNo))
            {
                Common.Common_Func.ErrorMessage("货位编号不能为空", "保存失败");
                return false;
            }
            if (string.IsNullOrEmpty(_area.AreaName))
            {
                Common.Common_Func.ErrorMessage("货位名称不能为空", "保存失败");
                return false;
            }
            //if (_area.AreaNo.Length != 9)
            //{
            //    Common.Common_Func.ErrorMessage("货位编号必须为九位", "保存失败");
            //    return false;
            //}

            return true;
        }

        #endregion

        private void txtAreaNoRight_KeyUp(object sender, KeyEventArgs e)
        {
            //if (!_area.AreaName.StartsWith(string.Format("{0}{1}", _house.WarehouseName, _house.HouseName))) return;

            //string areano = txtAreaNoRight.Text.Trim();
            //if (string.IsNullOrEmpty(areano)) return;

            //if (areano.Length == 2)
            //{
            //    _area.AreaName = string.Format("{0}{1}{2}层", _house.WarehouseName, _house.HouseName, areano);
            //}
            //else if (areano.Length >= 4)
            //{
            //    _area.AreaName = string.Format("{0}{1}{2}层{3}格", _house.WarehouseName, _house.HouseName, areano.Substring(0, 2), areano.Substring(2, 2));
            //}
            //else
            //{
            //    _area.AreaName = string.Format("{0}{1}", _house.WarehouseName, _house.HouseName);
            //}
        }

        private void txtAreaName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Escape)
            //{
            //    if (_house != null)
            //    {
            //        _area.AreaNo = string.Format("{0}{1}", _house.WarehouseNo, _house.HouseNo);
            //        _area.AreaName = string.Format("{0}{1}", _house.WarehouseName, _house.HouseName);
            //    }
            //}
        }
    }
}
