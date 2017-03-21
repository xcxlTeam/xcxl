using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS.WebService;

namespace WMS.Basic
{
    public partial class FrmP2BFile : Common.FrmBaseDialog
    {

        private Preparation _back;
        private Preparation _preparation;
        private List<Building> _lstBuilding;

        public FrmP2BFile()
        {
            InitializeComponent();
        }

        public FrmP2BFile(Preparation model)
        {
            if (model == null) model = new Preparation();
            _preparation = model;
            if (model.ID == 0) SetNewModel();

            _back = Common.Common_Func.ConvertToModel<Preparation>(_preparation);

            InitializeComponent();
            bsPreparation.DataSource = _preparation;
        }
        private void FrmP2BFile_Load(object sender, EventArgs e)
        {
            InitForm();
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

        private void cbbBuildingLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lstBuilding != null && _lstBuilding.Count>0)
                _preparation.bid = _lstBuilding[cbbBuildingLst.SelectedIndex].ID;
        }

        private void txtpCode_TextChanged(object sender, EventArgs e)
        {
            _preparation.pCode = txtpCode.Text.Trim();
        }

        private void txtpName_TextChanged(object sender, EventArgs e)
        {
            _preparation.pName = txtpName.Text.Trim();
        }

        #region Function
        private void SetNewModel()
        {
            if (_preparation == null) _preparation = new Preparation();
            _preparation.ID = 0;
            _preparation.IsDel = 1;
        }
        private void InitForm()
        {
            if (this._preparation.ID == 0)
            {
                this.Text = "新增制法";
            }
            else
            {
                this.Text = "编辑制法";
            }

            BindComboBoxs();

            bsPreparation.ResetBindings(false);
            bsPreparation.EndEdit();

            txtpCode.Focus();
            txtpCode.SelectAll();
        }

        private void BindComboBoxs()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Building _building = new Building();

                bool bResult = false;
                string strErr = string.Empty;

                bResult = Basic_Func.GetBuildingList(ref _lstBuilding, _building, ref strErr);

                cbbBuildingLst.DataSource = _lstBuilding;
                cbbBuildingLst.DisplayMember = "bName";
                cbbBuildingLst.ValueMember = "ID";

                if(_preparation.bid!=0)
                {
                    for (int i = 0; i < _lstBuilding.Count-1; i++)
                    {
                        if (_lstBuilding[i].ID == _preparation.bid)
                        { 
                            cbbBuildingLst.SelectedIndex = i;
                            break;
                        }
                    }
                }
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

        private void CloseForm()
        {
            if (_preparation.ID >= 1)
            {
                if (!SaveChange()) return;
            }

            this.Close();
        }

        private bool SaveChange()
        {
            bsPreparation.EndEdit();

            if (!Common.Common_Func.EqualsValues(_preparation, _back))
            {
                DialogResult dr = MessageBox.Show("当前制法已经修改,是否保存当前的改动?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes) return SaveData();
            }

            return true;
        }

        private bool SaveData()
        {
            if (!CheckInput()) return false;

            string strErr = string.Empty;
            if (Basic_Func.SavePreparation(ref _preparation, ref strErr))
            {
                Common.Common_Func.ErrorMessage("制法保存成功！", "保存成功");
                bsPreparation.DataSource = _preparation;
                InitForm();
                _back = Common.Common_Func.ConvertToModel<Preparation>(_preparation);
                return true;
            }
            else
            {
                Common.Common_Func.ErrorMessage(strErr, "保存失败");
                bsPreparation.DataSource = _preparation;
                return false;
            }
        }

        private bool CheckInput()
        {
            if (_preparation.bid != _lstBuilding[cbbBuildingLst.SelectedIndex].ID)
                _preparation.bid = _lstBuilding[cbbBuildingLst.SelectedIndex].ID;
            bsPreparation.EndEdit();

            if (string.IsNullOrEmpty(_preparation.pCode))
            {
                Common.Common_Func.ErrorMessage("制法编号不能为空", "保存失败");
                return false;
            }
            if (string.IsNullOrEmpty(_preparation.pName))
            {
                Common.Common_Func.ErrorMessage("制法名称不能为空", "保存失败");
                return false;
            }
            if (_preparation.pCode.Length < 2)
            {
                Common.Common_Func.ErrorMessage("制法编号必须不少于2位", "保存失败");
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            _preparation = new Preparation();
            SetNewModel();

            bsPreparation.DataSource = _preparation;
            bsPreparation.EndEdit();

            txtpCode.Focus();
        }
        #endregion






    }
}
