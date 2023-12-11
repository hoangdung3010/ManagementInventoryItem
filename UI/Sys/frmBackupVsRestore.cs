using FormUI.Base;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.WindowsAPICodePack.Dialogs;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Library.UW;
using MTControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class frmBackupVsRestore : MXTraForm
    {
        public frmBackupVsRestore()
        {
            InitializeComponent();
        }

        private void btnExecuteBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFolderBackup.Text))
                {
                    MMessage.ShowWarning("Bạn vui lòng chọn thư mục để lưu tệp sao lưu.");
                    return;
                }

                if (!IsValidPath(txtFolderBackup.Text))
                {
                    MMessage.ShowWarning("Đường dẫn thư mục chứa tệp sao lưu không được chứa các kí tự đặc biệt.");
                    return;
                }
                pbBackup.Value = 0;
                btnExecuteBackup.Enabled = false;
                if (!bgWKBackup.IsBusy)
                {
                    DBContext.GetRep2<DBOptionRepository>().SaveDBOption(MT.Data.ConstantDBOption.MSC_PATH_SAVE_BACKUP, 
                        txtFolderBackup.Text.Trim(), MT.Library.SessionData.UserId);
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    bgWKBackup.RunWorkerAsync(txtFolderBackup.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
                btnExecuteBackup.Enabled = true;
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }


        private void btnExecuteRestore_Click(object sender, EventArgs e)
        {
            try
            {
               
                
                var rowSelected=grdRestore.GetRecordByRowSelected<BackupHistory>();
                if (rowSelected == null)
                {
                    MMessage.ShowWarning("Bạn vui lòng tệp dữ liệu muốn phục hồi.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPathData.Text))
                {
                    MMessage.ShowWarning("Bạn chưa chọn thư mục muốn lưu sở dữ liệu phục hồi.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtDatabaseName.Text))
                {
                    MMessage.ShowWarning("Bạn phải đặt tên cơ sở dữ liệu phục hồi.");
                    return;
                }


                rowSelected.PathSaveData = txtPathData.Text.Trim();

                if (!IsValidPath(rowSelected.PathSaveData))
                {
                    MMessage.ShowWarning("Đường dẫn thư mục lưu dữ liệu không được chứa các kí tự đặc biệt.");
                    return;
                }
                

                rowSelected.DatabaseName = txtDatabaseName.Text.Trim();
                if (!IsValidDatabaseName(rowSelected.DatabaseName))
                {
                    MMessage.ShowWarning("Tên cơ sở dữ liệu không được chứa các kí tự đặc biệt.");
                    return;
                }

                if (!bgWKRestore.IsBusy)
                {
                    DBContext.GetRep2<DBOptionRepository>().SaveDBOption(MT.Data.ConstantDBOption.MSC_DATABASENAME_RESTORE,
                       rowSelected.DatabaseName, MT.Library.SessionData.UserId);
                    DBContext.GetRep2<DBOptionRepository>().SaveDBOption(MT.Data.ConstantDBOption.MSC_PATH_SAVE_RESTORE_DB,
                       rowSelected.PathSaveData, MT.Library.SessionData.UserId);

                    btnExecuteRestore.Enabled = false;
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    bgWKRestore.RunWorkerAsync(rowSelected);
                }
                
            }
            catch (Exception ex)
            {
                btnExecuteRestore.Enabled = true;
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                MMessage.ShowError(ex.Message);
            }
        }

        

        /// <summary>
        /// Kiểm tra database có hợp lệ không
        /// </summary>
        /// <param name="str"></param>
        /// <returns>=true hợp lệ, ngược lại không hợp lệ</returns>
        private bool IsValidDatabaseName(string str)
        {
            foreach (var item in str)
            {
                if (!((item >= 'a' && item <= 'z')
                      || (item >= 'A' && item <= 'Z')
                      || (item >= '0' && item <= '9')
                      || item == '_'))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra đường dẫn có hợp lệ không
        /// </summary>
        /// <param name="str"></param>
        /// <returns>=true hợp lệ, ngược lại không hợp lệ</returns>
        private bool IsValidPath(string str)
        {
            foreach (var item in str)
            {
                if (!((item >= 'a' && item <= 'z')
                      || (item >= 'A' && item <= 'Z')
                      || (item >= '0' && item <= '9')
                      || item == '_'
                      || item == '\\'
                      || item == ':'))
                    return false;
            }
            return true;
        }
        private void btnSelectFolderBackup_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = @"C:\";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                DirectoryInfo dir = new DirectoryInfo(dialog.FileName);
                txtFolderBackup.Text = dir.ToString();
                Properties.Settings.Default.PathFolderBackup = txtFolderBackup.Text;
            }
        }

        private void frmBackupVsRestore_Load(object sender, EventArgs e)
        {
           var dboptionPathSaveBackup= DBContext.GetRep2<DBOptionRepository>().GetDBOptionByOptionId(MT.Data.ConstantDBOption.MSC_PATH_SAVE_BACKUP,
               MT.Library.SessionData.UserId);

            if (dboptionPathSaveBackup != null)
            {
                txtFolderBackup.Text = dboptionPathSaveBackup.OptionValue;
            }
            else
            {
                txtFolderBackup.Text = "C:\\Data";
            }
            var dboptionPathSaveRestoredb = DBContext.GetRep2<DBOptionRepository>().GetDBOptionByOptionId(MT.Data.ConstantDBOption.MSC_PATH_SAVE_RESTORE_DB,
               MT.Library.SessionData.UserId);

            if (dboptionPathSaveRestoredb != null)
            {
                txtPathData.Text = dboptionPathSaveRestoredb.OptionValue;
            }

            var dboptionDatabaseNameRestore = DBContext.GetRep2<DBOptionRepository>().GetDBOptionByOptionId(MT.Data.ConstantDBOption.MSC_DATABASENAME_RESTORE,
               MT.Library.SessionData.UserId);

            if (dboptionDatabaseNameRestore != null)
            {
                txtDatabaseName.Text = dboptionDatabaseNameRestore.OptionValue;
            }
            lblStatusBackup.Text = string.Empty;
            lblStatusRestore.Text = string.Empty;

            var grd = this.grdRestore;
            grd.KeyName = "Id";
            var col = grdRestore.AddColumnText("sBackupName", "Tên tệp sao lưu", "Tên tệp sao lưu", 350, isFixWidth: true);
            grdRestore.AddColumnText("dCreatedDate", "Ngày tạo", "Ngày tạo", 120);
            grdRestore.AddColumnText("fSize", "Kích thước(Kb)", "Kích thước(Kb)", 150);
            grdRestore.FirstView.OptionsBehavior.Editable = false;
            grdRestore.FirstView.OptionsSelection.EnableAppearanceFocusedCell = true;
            grdRestore.FirstView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus;
            grdRestore.SetMutiSelectRows(false, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect);
            grdRestore.IsShowFilter = true;
            LoadDataBackup();
        }

        /// <summary>
        /// Load dữ liệu backup
        /// </summary>
        void LoadDataBackup()
        {
            if (!bgLoadDataBackup.IsBusy)
            {
                bgLoadDataBackup.RunWorkerAsync();
            }
        }
        
        private void bgWKBackup_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWKBackup.ReportProgress(10);
            var now = SysDateTime.Instance.Now();
            string backupName = "ManagementInventoryItem" + "_" + now.ToString("ddMMyyyy_HH.mm.ss") + ".bak";

            string physicalName = Path.Combine(e.Argument.ToString(), backupName);

            string sConnectionString = MTLib.Utility.ConnectionString("master", MT.Library.SessionData.UserData, MT.Library.SessionData.PassData, MT.Library.SessionData.ServerName, 0);
            BackupHistory backupHistory = new BackupHistory
            {
                sBackupName=backupName,
                sFileName= physicalName,
                sUserId= MT.Library.SessionData.UserId,
                dCreatedDate= now,
                sCreatedBy= MT.Library.SessionData.UserName,
                MTEntityState=MT.Library.Enummation.MTEntityState.Add
            };
            using (IUnitOfWork ofWork = new UnitOfWork(sConnectionString))
            {
                string query = "SELECT phyname FROM sysdevices WHERE name=@DataBaseName";
                var phynames = ofWork.Query<string>(query, new { DataBaseName = MT.Library.SessionData.DataBaseName });
                if (phynames?.Count > 0)
                {
                    foreach (var item in phynames)
                    {
                        MTLib.Utility.DropDevice(ofWork, MT.Library.SessionData.DataBaseName);
                    }
                }
                bgWKBackup.ReportProgress(20);
                System.Threading.Thread.Sleep(300);
                MTLib.Utility.AddDumDevice(ofWork, MT.Library.SessionData.DataBaseName, physicalName);

                bgWKBackup.ReportProgress(40);
                System.Threading.Thread.Sleep(300);
                MTLib.Utility.AddDumDevice(ofWork, MT.Library.SessionData.DataBaseName, physicalName);

                bgWKBackup.ReportProgress(90);
                System.Threading.Thread.Sleep(300);
            

                if (bgWKBackup.CancellationPending)
                {
                    e.Cancel = true;
                    bgWKBackup.ReportProgress(0);
                    return;
                }
                query = $@"SELECT top 1 CONVERT(VARCHAR, CONVERT(DECIMAL(18, 1), backup_size / 1024))
                        FROM msdb.dbo.backupset
                        WHERE database_name = @DatabaseName
                        order by backup_finish_date DESC";

                var backup_size = ofWork.QueryFirstOrDefault<float>(query, new {DatabaseName= MT.Library.SessionData.DataBaseName });
                backupHistory.fSize = backup_size;
                e.Result = backupHistory;
            }
            bgWKBackup.ReportProgress(100);
        }

        private void bgWKBackup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                lblStatusBackup.Text = "Sao lưu đã bị hủy.";
            }
            if (e.Error != null)
            {
                lblStatusBackup.Text = "Đã có lỗi xảy ra. Vui lòng kiểm tra lại các thiết lập liên quan đến cơ sở dữ liệu.";
            }
            else
            {
                if (e.Result != null)
                {
                    DBContext.GetRep2<BackupHistoryRepository>().SaveData(e.Result as BackupHistory);
                }
            }
            btnExecuteBackup.Enabled = true;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            LoadDataBackup();
        }

        private void bgWKRestore_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWKRestore.ReportProgress(10);
            BackupHistory backupHistory = e.Argument as BackupHistory;
            MTLib.Utility.CloseAllConnection(MT.Library.SessionData.DataBaseName, MT.Library.SessionData.ConnectString);
            string sConnectionString = MTLib.Utility.ConnectionString("master", MT.Library.SessionData.UserData, MT.Library.SessionData.PassData, MT.Library.SessionData.ServerName, 0);

            MTLib.Utility.RestoreDB(backupHistory.DatabaseName, backupHistory.sFileName, backupHistory.PathSaveData, sConnectionString);

            bgWKRestore.ReportProgress(90);
            System.Threading.Thread.Sleep(300);

            if (bgWKRestore.CancellationPending)
            {
                e.Cancel = true;
                bgWKRestore.ReportProgress(0);
                return;
            }
            bgWKRestore.ReportProgress(100);
           
        }

        private void bgWKRestore_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnExecuteRestore.Enabled = true;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            if (e.Cancelled)
            {
                lblStatusRestore.Text = "Thao tác phục hồi dữ liệu đã bị hủy.";

                return;
            }
            if (e.Error != null)
            {
                lblStatusRestore.Text = "Đã có lỗi xảy ra. Vui lòng kiểm tra lại các thiết lập liên quan đến cơ sở dữ liệu.";
            }
            else
            {
                lblStatusRestore.Text = "Phục hồi thành công";
            }
           
        }

        private void bgWKBackup_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbBackup.Invoke((MethodInvoker)delegate
            {
                pbBackup.Value = e.ProgressPercentage;
                pbBackup.Update();

            });

            lblStatusBackup.Invoke((MethodInvoker)delegate
            {
                lblStatusBackup.Text = $"{e.ProgressPercentage }%";
            });
        }

        private void bgWKRestore_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbRestore.Invoke((MethodInvoker)delegate
            {
                pbRestore.Value = e.ProgressPercentage;
                pbRestore.Update();

            });

            lblStatusRestore.Invoke((MethodInvoker)delegate
            {
                lblStatusRestore.Text = $"{e.ProgressPercentage }%";
            });
        }

        private void bgLoadDataBackup_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = DBContext.GetRep2<BackupHistoryRepository>().GetData(typeof(BackupHistory),
                where: $"sUserId='{MT.Library.SessionData.UserId}'",
                orderBy: "dCreatedDate DESC");
        }

        private void bgLoadDataBackup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            grdRestore.DataSource = e.Result;
        }
    }
}
