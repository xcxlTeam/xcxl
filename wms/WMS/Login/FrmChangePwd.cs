using WMS.Basic;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS.Login
{
    public partial class FrmChangePwd : Common.FrmBasic
    {
        private UserInfo _back;
        private UserInfo _user;

        public FrmChangePwd()
        {
            _user = Common.Common_Func.ConvertToModel<UserInfo>(Common.Common_Var.CurrentUser);

            _back = Common.Common_Func.ConvertToModel<UserInfo>(Common.Common_Var.CurrentUser);

            InitializeComponent();

            bsMain.DataSource = _user;
        }

        public FrmChangePwd(UserInfo model)
        {
            _user = model;

            _back = Common.Common_Func.ConvertToModel<UserInfo>(_user);

            InitializeComponent();

            bsMain.DataSource = _user;
        }
        private void FrmChangePwd_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #region Function

        private void InitForm()
        {
            bsMain.ResetBindings(false);
            bsMain.EndEdit();

            txtPassword.Focus();
            txtPassword.SelectAll();
        }

        private bool SaveData()
        {
            bsMain.EndEdit();

            if (_user.Password != _back.Password)
            {
                _user.Password = Basic_Func.JiaMi(_user.Password);
                _user.RePassword = Basic_Func.JiaMi(_user.RePassword);
            }
            else
            {
                Common.Common_Func.ErrorMessage("密码未做任何修改！", "保存失败");
                return false;
            }

            if (!CheckInput()) return false;

            string strErr = string.Empty;
            if (Login_Func.ChangeUserPassword(_user, ref strErr))
            {
                if (_user.ID == Common.Common_Var.CurrentUser.ID)
                {
                    Common.Common_Func.ErrorMessage("密码修改成功,请重新登陆！", "保存成功");
                    Application.Exit();
                }
                else
                {
                    Common.Common_Func.ErrorMessage("数据保存成功！", "保存成功");
                    InitForm();
                }
                return true;
            }
            else
            {
                Common.Common_Func.ErrorMessage(strErr, "保存失败");
                return false;
            }
        }

        private bool CheckInput()
        {
            if (_user.ID <= 0)
            {
                return Common.Common_Func.ErrorMessage("用户信息获取不正确", "保存失败");
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
                return Common.Common_Func.ErrorMessage("确认密码与新用户密码不一致", "保存失败");
            }
            if (_user.Password.Equals(Basic_Func.JiaMi(Common.Common_Var.DefaultPwd)))
            {
                return Common.Common_Func.ErrorMessage("不能修改为默认密码", "保存失败");
            }

            return true;
        }

        #endregion
    }
}
