using WMS.WebService;
using WMS.Common;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;


namespace WMS.Basic
{
    public partial class FrmUserFile : Common.FrmBaseDialog
    {
        private UserInfo _back;
        private UserInfo _user;

        public FrmUserFile()
        {
            //SetNewModel();

            //_back = Common.Common_Func.ConvertToModel<UserInfo>(_user);

            InitializeComponent();

            //bsUser.DataSource = _user;
        }

        public FrmUserFile(UserInfo model)
        {
            if (model == null) model = new UserInfo();
            _user = model;
            if (model.ID == 0) SetNewModel();

            _back = Common.Common_Func.ConvertToModel<UserInfo>(_user);

            InitializeComponent();

            bsUser.DataSource = _user;
        }

        private void FrmUserFile_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            if (!SaveChange()) return;

            ClearForm();
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

        private void cbxBIsReceive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbxBIsPick_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbxSelectAllGroup_CheckedChanged(object sender, EventArgs e)
        {
            SelectAllGroup();
        }

        private void cbxSelectAllWarehouse_CheckedChanged(object sender, EventArgs e)
        {
            SelectAllWarehouse();
        }

        #region Function
        private void InitForm()
        {
            cbxSelectAllGroup.Location = new Point(lvGroup.Location.X + 3, lvGroup.Location.Y - 25);
            cbxSelectAllWarehouse.Location = new Point(lvWarehouse.Location.X + 3, lvWarehouse.Location.Y - 25);

            if (this._user.ID == 0)
            {
                this.Text = "新增用户";
                txtPassword.Enabled = true;
                txtRePassword.Enabled = true;
            }
            else
            {
                this.Text = "编辑用户";
                txtPassword.Enabled = Common_Var.CurrentUser.BIsAdmin || Common_Var.CurrentUser.ID == _user.ID;
                txtRePassword.Enabled = Common_Var.CurrentUser.BIsAdmin || Common_Var.CurrentUser.ID == _user.ID;
            }

            BindComboBoxs();

            GetGroupData();

            GetWarehouseData();

            bsUser.ResetBindings(false);
            bsUser.EndEdit();

            txtUserNo.Focus();
            txtUserNo.SelectAll();
        }

        private void ClearForm()
        {
            _user = new UserInfo();
            SetNewModel();

            bsUser.DataSource = _user;
            bsUser.EndEdit();

            BindComboBoxs();

            txtPassword.Enabled = true;
            txtRePassword.Enabled = true;
            txtUserNo.Focus();
        }

        private void SetNewModel()
        {
            if (_user == null) _user = new UserInfo();
            _user.ID = 0;
            _user.UserType = 2;
            _user.UserStatus = 1;
            _user.Sex = 1;
            _user.IsPick = 1;
            _user.IsReceive = 1;
            _user.IsQuality = 1;
            _user.IsDel = 1;
        }

        private void CloseForm()
        {
            if (_user.ID >= 1)
            {
                if (!SaveChange()) return;
            }

            this.Close();
        }

        private void BindComboBoxs()
        {
            Common.Common_Func.BindComboxBoxByKey(cbbSex.Name, cbbSex);

            Common.Common_Func.BindComboxBoxByKey(cbbUserStatus.Name, cbbUserStatus);
        }

        private bool SaveChange()
        {
            bsUser.EndEdit();

            if (!Common.Common_Func.EqualsValues(_user, _back))
            {
                DialogResult dr = MessageBox.Show("当前用户已经修改,是否保存当前的改动?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes) return SaveData();
            }

            return true;
        }

        private void GetGroupData()
        {
            string strError = string.Empty;
            List<UserGroupInfo> lstGroup = new List<UserGroupInfo>();
            if (Basic_Func.GetUserGroupListByUser(ref lstGroup, _user, true, ref strError))
            {
                _user.lstUserGroup = lstGroup;
            }
            else
            {
                Common_Func.ErrorMessage(strError, "获取用户组失败");
                return;
            }

            SetGroupData();
        }

        private void SetGroupData()
        {
            lvGroup.Items.Clear();
            if (_user == null || _user.lstUserGroup == null || _user.lstUserGroup.Count <= 0) return;

            bool isAllChecked = true;
            ListViewItem item;
            foreach (UserGroupInfo group in _user.lstUserGroup)
            {
                if (!group.BIsChecked) isAllChecked = false;

                item = new ListViewItem();
                item.Checked = group.BIsChecked;
                item.Text = group.UserGroupName;
                item.Tag = group.ID;
                lvGroup.Items.Add(item);
            }
            lvGroup.Refresh();

            cbxSelectAllGroup.Checked = isAllChecked;
        }

        private string GetGroupCode()
        {
            string strGroupCode = string.Empty;
            if (lvGroup.Items != null && lvGroup.Items.Count >= 1)
            {
                foreach (ListViewItem item in lvGroup.Items)
                {
                    if (item.Checked)
                    {
                        strGroupCode += item.Tag + ",";
                    }
                }
            }
            else
            {
                return null;
            }

            if (string.IsNullOrEmpty(strGroupCode)) return null;
            else strGroupCode = strGroupCode.Trim(',');

            return strGroupCode;
        }

        private void GetWarehouseData()
        {
            string strError = string.Empty;
            List<WarehouseInfo> lstWarehouse = new List<WarehouseInfo>();
            if (Basic_Func.GetWarehouseListByUser(ref lstWarehouse, _user, true, ref strError))
            {
                _user.lstWarehouse = lstWarehouse;
            }
            else
            {
                Common_Func.ErrorMessage(strError, "获取用户仓库失败");
                return;
            }

            SetWarehouseData();
        }

        private void SetWarehouseData()
        {
            lvWarehouse.Items.Clear();
            if (_user == null || _user.lstWarehouse == null || _user.lstWarehouse.Count <= 0) return;

            bool isAllChecked = true;
            ListViewItem item;
            foreach (WarehouseInfo warehouse in _user.lstWarehouse)
            {
                if (!warehouse.BIsChecked) isAllChecked = false;

                item = new ListViewItem();
                item.Checked = warehouse.BIsChecked;
                item.Text = warehouse.WarehouseName;
                item.Tag = warehouse.ID;
                lvWarehouse.Items.Add(item);
            }
            lvWarehouse.Refresh();

            cbxSelectAllWarehouse.Checked = isAllChecked;
        }

        private string GetWarehouseCode()
        {
            string strWarehouseCode = string.Empty;
            if (lvWarehouse.Items != null && lvWarehouse.Items.Count >= 1)
            {
                foreach (ListViewItem item in lvWarehouse.Items)
                {
                    if (item.Checked)
                    {
                        strWarehouseCode += item.Tag + ",";
                    }
                }
            }
            else
            {
                return null;
            }

            if (string.IsNullOrEmpty(strWarehouseCode)) return null;
            else strWarehouseCode = strWarehouseCode.Trim(',');

            return strWarehouseCode;
        }

        private bool SaveData()
        {
            bsUser.EndEdit();

            _user.PinYin = PinYinConvert.Get(_user.UserName);
            if (_user.Password == _back.Password)
            {
                //_user.Password = Basic_Func.JiaMi(_user.Password);
                //_user.RePassword = Basic_Func.JiaMi(_user.RePassword);

                _user.Password = "不要加密或更新";
                _user.RePassword = "不要加密或更新";
            }
            _user.IsReceive = _user.BIsReceive.ToInt32();
            _user.IsQuality = _user.BIsQuality.ToInt32();
            _user.IsPick = _user.BIsPick.ToInt32();
            _user.GroupCode = GetGroupCode();
            _user.WarehouseCode = GetWarehouseCode();

            if (!CheckInput()) return false;

            string strErr = string.Empty;
            if (Basic_Func.SaveUser(ref _user, ref strErr))
            {
                Common.Common_Func.ErrorMessage("数据保存成功！", "保存成功");
                bsUser.DataSource = _user;
                InitForm();
                _back = Common.Common_Func.ConvertToModel<UserInfo>(_user);
                return true;
            }
            else
            {
                Common.Common_Func.ErrorMessage(strErr, "保存失败");
                bsUser.DataSource = _user;
                return false;
            }
        }

        private bool CheckInput()
        {
            if (_user.UserStatus <= 0)
            {
                return Common.Common_Func.ErrorMessage("用户状态必须设置", "保存失败");
            }
            if (string.IsNullOrEmpty(_user.UserNo))
            {
                return Common.Common_Func.ErrorMessage("用户编号不能为空", "保存失败");
            }
            if (string.IsNullOrEmpty(_user.UserName))
            {
                return Common.Common_Func.ErrorMessage("用户名称不能为空", "保存失败");
            }
            if (string.IsNullOrEmpty(_user.Password))
            {
                return Common.Common_Func.ErrorMessage("密码不能为空", "保存失败");
            }
            if (!_user.Password.Equals(_user.RePassword))
            {
                return Common.Common_Func.ErrorMessage("确认密码与用户密码不一致", "保存失败");
            }
            //if (string.IsNullOrEmpty(_user.GroupCode))
            //{
            //    return Common.Common_Func.ErrorMessage("用户组必须选择", "保存失败");
            //}
            if (string.IsNullOrEmpty(_user.WarehouseCode))
            {
                return Common.Common_Func.ErrorMessage("用户仓库必须选择", "保存失败");
            }

            return true;
        }

        private void SelectAllGroup()
        {
            if (lvGroup.Items == null) return;

            foreach (ListViewItem item in lvGroup.Items)
            {
                item.Checked = cbxSelectAllGroup.Checked;
            }
        }

        private void SelectAllWarehouse()
        {
            if (lvWarehouse.Items == null) return;

            foreach (ListViewItem item in lvWarehouse.Items)
            {
                item.Checked = cbxSelectAllWarehouse.Checked;
            }
        }

        private void CheckReceive()
        {
            if (cbxBIsReceive.Checked && _user.ID >= 1)
            {
            }
        }

        private void CheckPick()
        {
            if (cbxBIsPick.Checked && _user.ID >= 1)
            {
            }
        }

        #endregion
    }
}
