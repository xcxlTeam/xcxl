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
    public partial class FrmGroupFile : Common.FrmBaseDialog
    {
        private UserGroupInfo _back;
        private UserGroupInfo _group;

        public FrmGroupFile()
        {
            //SetNewModel();

            //_back = Common.Common_Func.ConvertToModel<UserGroupInfo>(_group);

            InitializeComponent();

            //bsGroup.DataSource = _group;
        }

        public FrmGroupFile(UserGroupInfo model)
        {
            if (model == null) model = new UserGroupInfo();
            _group = model;
            if (model.ID == 0) SetNewModel();

            _back = Common.Common_Func.ConvertToModel<UserGroupInfo>(_group);

            InitializeComponent();

            bsGroup.DataSource = _group;
        }

        private void FrmGroupFile_Load(object sender, EventArgs e)
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
            if (Common.Common_Var.CurrentUser.UserType != 1) cbbUserGroupType.Enabled = false;

            if (this._group.ID == 0)
            {
                this.Text = "新增用户组";
            }
            else
            {
                this.Text = "编辑用户组";
            }

            BindComboBoxs();

            bsGroup.ResetBindings(false);
            bsGroup.EndEdit();

            txtGroupNo.Focus();
            txtGroupNo.SelectAll();
        }

        private void BindComboBoxs()
        {
            Common.Common_Func.BindComboxBoxByKey(cbbUserGroupType.Name, cbbUserGroupType);

            Common.Common_Func.BindComboxBoxByKey(cbbUserGroupStatus.Name, cbbUserGroupStatus);
        }

        private void ClearForm()
        {
            _group = new UserGroupInfo();
            SetNewModel();

            bsGroup.DataSource = _group;
            bsGroup.EndEdit();

            txtGroupNo.Focus();
        }

        private void SetNewModel()
        {
            if (_group == null) _group = new UserGroupInfo();
            _group.ID = 0;
            _group.UserGroupType = 2;
            _group.UserGroupStatus = 1;
            _group.IsDel = 1;
        }

        private void CloseForm()
        {
            if (_group.ID >= 1)
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
            bsGroup.EndEdit();

            if (!Common.Common_Func.EqualsValues(_group, _back))
            {
                DialogResult dr = MessageBox.Show("当前用户组已经修改,是否保存当前的改动?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes) return SaveData();
            }

            return true;
        }

        private bool SaveData()
        {
            bsGroup.EndEdit();

            if (!CheckInput()) return false;

            string strErr = string.Empty;
            if (Basic_Func.SaveUserGroup(ref _group, ref strErr))
            {
                Common.Common_Func.ErrorMessage("用户组保存成功！", "保存成功");
                bsGroup.DataSource = _group;
                InitForm();
                _back = Common.Common_Func.ConvertToModel<UserGroupInfo>(_group);
                return true;
            }
            else
            {
                Common.Common_Func.ErrorMessage(strErr, "保存失败");
                bsGroup.DataSource = _group;
                return false;
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(_group.UserGroupNo))
            {
                Common.Common_Func.ErrorMessage("用户组编号不能为空", "保存失败");
                return false;
            }
            if (string.IsNullOrEmpty(_group.UserGroupName))
            {
                Common.Common_Func.ErrorMessage("用户组名称不能为空", "保存失败");
                return false;
            }

            return true;
        }

        #endregion
    }
}
