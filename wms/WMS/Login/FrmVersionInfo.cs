using ExcelLibrary;
using WMS.Common;
using WMS.WebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace WMS.Login
{
    public partial class FrmVersionInfo : Common.FrmBaseDialog
    {
        private AppVersionInfo _appversion;
        private bool _showupdate;

        public FrmVersionInfo(AppVersionInfo appversion, bool showupdate = true)
        {
            InitializeComponent();

            _appversion = appversion;
            _showupdate = showupdate;
        }

        private void FrmVersionInfo_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StartUpdate();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Function

        private void InitForm()
        {
            _appversion.VersionDesc = _appversion.VersionDesc.Replace("\\n", Environment.NewLine);
            bsMain.DataSource = _appversion;

            if (_showupdate)
            {
                btnUpdate.Visible = btnUpdate.Enabled = true;
                btnCancel.Visible = btnCancel.Enabled = false;
                btnUpdate.Focus();
            }
            else
            {
                btnUpdate.Visible = btnUpdate.Enabled = false;
                btnCancel.Visible = btnCancel.Enabled = true;
                btnCancel.Focus();
            }

        }

        private void StartUpdate()
        {
            System.Diagnostics.Process.Start(_appversion.UpdateAppPath, null);
            this.Close();
        }
        #endregion

    }
}
