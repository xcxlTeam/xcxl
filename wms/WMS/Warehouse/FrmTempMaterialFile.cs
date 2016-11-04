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


namespace WMS.Warehouse
{
    public partial class FrmTempMaterialFile : Common.FrmBaseDialog
    {
        private TempMaterialInfo _back;
        private TempMaterialInfo _tempmaterial;

        public FrmTempMaterialFile()
        {
            //SetNewModel();

            //_back = Common.Common_Func.ConvertToModel<TempMaterialInfo>(_tempmaterial);

            InitializeComponent();

            //bsTempMaterial.DataSource = _tempmaterial;
        }

        public FrmTempMaterialFile(TempMaterialInfo model)
        {
            if (model == null) model = new TempMaterialInfo();
            _tempmaterial = model;
            if (model.ID == 0) SetNewModel();

            _back = Common.Common_Func.ConvertToModel<TempMaterialInfo>(_tempmaterial);

            InitializeComponent();

            bsTempMaterial.DataSource = _tempmaterial;
        }

        private void FrmTempInventoryFile_Load(object sender, EventArgs e)
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
            if (this._tempmaterial.ID == 0)
            {
                this.Text = "新增临时物料";
                lblTempMaterialNo.Visible = false;
                txtTempMaterialNo.Visible = false;
            }
            else
            {
                this.Text = "编辑临时物料";
            }

            BindComboBoxs();

            bsTempMaterial.ResetBindings(false);
            bsTempMaterial.EndEdit();
        }

        private void BindComboBoxs()
        {

        }

        private void ClearForm()
        {
            _tempmaterial = new TempMaterialInfo();
            SetNewModel();

            string strError = string.Empty;
            //Warehouse_Func.GetTempMaterialNo(ref _tempmaterial, ref strError);
            bsTempMaterial.DataSource = _tempmaterial;
            bsTempMaterial.EndEdit();

            txtTempMaterialNo.Focus();
        }

        private void SetNewModel()
        {
            if (_tempmaterial == null) _tempmaterial = new TempMaterialInfo();
            _tempmaterial.ID = 0;
            _tempmaterial.TempMaterialStatus = 1;
            _tempmaterial.IsDel = 1;
        }

        private void CloseForm()
        {
            if (_tempmaterial.ID >= 1)
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
            bsTempMaterial.EndEdit();

            if (!Common.Common_Func.EqualsValues(_tempmaterial, _back))
            {
                DialogResult dr = MessageBox.Show("当前临时物料已经修改,是否保存当前的改动?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes) return SaveData();
            }

            return true;
        }

        private bool SaveData()
        {
            bsTempMaterial.EndEdit();

            if (!CheckInput()) return false;

            string strErr = string.Empty;
            if (Warehouse_Func.SaveTempMaterial(ref _tempmaterial, ref strErr))
            {
                Common.Common_Func.ErrorMessage("临时物料保存成功！" + Environment.NewLine + "临时物料编号为：" + _tempmaterial.TempMaterialNo, "保存成功");
                bsTempMaterial.DataSource = _tempmaterial;
                InitForm();
                _back = Common.Common_Func.ConvertToModel<TempMaterialInfo>(_tempmaterial);
                return true;
            }
            else
            {
                Common.Common_Func.ErrorMessage(strErr, "保存失败");
                bsTempMaterial.DataSource = _tempmaterial;
                return false;
            }
        }

        private bool CheckInput()
        {
            //if (string.IsNullOrEmpty(_tempmaterial.TempMaterialNo))
            //{
            //    Common.Common_Func.ErrorMessage("临时物料编号不能为空", "保存失败");
            //    return false;
            //}
            if (string.IsNullOrEmpty(_tempmaterial.TempMaterialDesc))
            {
                Common.Common_Func.ErrorMessage("临时物料描述不能为空", "保存失败");
                return false;
            }

            return true;
        }

        #endregion
    }
}
