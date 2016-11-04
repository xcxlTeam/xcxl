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
    public partial class FrmTempMaterialAlter : Common.FrmBaseDialog
    {
        private TempMaterialInfo _tempmaterial;
        private TempMaterialInfo _sapmaterial;

        public FrmTempMaterialAlter()
        {
            //_tempmaterial = new TempMaterialInfo();

            InitializeComponent();

            //bsTempMaterial.DataSource = _tempmaterial;
        }
        public FrmTempMaterialAlter(TempMaterialInfo model)
        {
            _tempmaterial = model;

            InitializeComponent();

            bsTempMaterial.DataSource = _tempmaterial;
        }

        private void FrmTempInventoryAlter_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            if (SaveData()) this.Close();
        }

        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTempMaterialNo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtMaterialNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    this.Cursor = Cursors.WaitCursor;

                    GetSAPMaterial();
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

        #region Function

        private void InitForm()
        {
            _sapmaterial = new TempMaterialInfo();

            bsTempMaterial.ResetBindings(false);
            bsTempMaterial.EndEdit();

            txtMaterialNo.Focus();
            txtMaterialNo.SelectAll();
        }

        private void GetSAPMaterial()
        {
            _sapmaterial = new TempMaterialInfo();
            _sapmaterial.MaterialNo = txtMaterialNo.Text.Trim();
            string strError = string.Empty;
            if (Warehouse_Func.GetMaterialInfo(ref _sapmaterial, ref strError))
            {
                _tempmaterial.MaterialNo = _sapmaterial.MaterialNo;
                _tempmaterial.MaterialDesc = _sapmaterial.MaterialDesc;
            }
            else
            {
                _sapmaterial = null;
                _tempmaterial.MaterialDesc = "";

                MessageBox.Show(strError, "获取SAP物料失败");
            }
        }

        private bool SaveData()
        {
            bsTempMaterial.EndEdit();

            if (!string.IsNullOrEmpty(_tempmaterial.MaterialNo) || _sapmaterial == null || _tempmaterial.MaterialNo != _tempmaterial.MaterialNo)
            {
                GetSAPMaterial();
            }

            if (_sapmaterial == null || string.IsNullOrEmpty(_tempmaterial.MaterialDesc)) return false;

            if (!CheckInput()) return false;

            string strErr = string.Empty;
            if (Warehouse_Func.SaveTempMaterial(ref _tempmaterial, ref strErr))
            {
                Common.Common_Func.ErrorMessage("临时物料替换成功！", "保存成功");
                bsTempMaterial.DataSource = _tempmaterial;
                InitForm();
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
            if (string.IsNullOrEmpty(_tempmaterial.TempMaterialNo))
            {
                return Common.Common_Func.ErrorMessage("临时物料编号不能为空", "保存失败");
            }
            if (string.IsNullOrEmpty(_tempmaterial.TempMaterialDesc))
            {
                return Common.Common_Func.ErrorMessage("临时物料名称不能为空", "保存失败");
            }

            if (_tempmaterial.ID == 0)
            {
                return Common.Common_Func.ErrorMessage("临时物料信息获取失败", "保存失败");
            }
            else if (_sapmaterial == null || string.IsNullOrEmpty(_sapmaterial.MaterialDesc))
            {
                return Common.Common_Func.ErrorMessage("SAP物料信息获取失败", "保存失败");
            }
            else
            {
                _tempmaterial.ReplaceUser = Common.Common_Var.CurrentUser.UserNo;
                _tempmaterial.ReplaceTime = DateTime.Now;
            }

            return true;
        }

        #endregion
    }
}
