using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using MT.Data.ViewModels;
using MT.Data.Rep;
using MT.Library.Log;
using MT.Library.UW;
using MTControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MT.Data.BO;

namespace FormUI
{
    public partial class frmLogAction : FormUI.FormUIBase
    {
        #region"Property"
        BindingSource _bs;
        string searchValue = string.Empty;
        DataTable _dt = new DataTable();

        TypeAssistant assistant;

        CheckBox headerCheckBox;

        IOverlaySplashScreenHandle _handler;

        MViewPaging _mViewPaging = new MViewPaging();
        #endregion
        #region"Contructor"
        public frmLogAction()
        {
            InitializeComponent();
            _bs = new BindingSource();
            Init();
        }

        #endregion
        #region"Sub/Func"

        private void Init()
        {
            cboAccount.Properties.DisplayMember = "Text";
            cboAccount.Properties.ValueMember = "Id";
            cboAccount.Properties.Columns.Add(new LookUpColumnInfo("Text", "Tài khoản"));
            cboAccount.Properties.NullText = "Tài khoản";
            cboAccount.Properties.NullValuePrompt = "Tài khoản";
            btnMore.ForeColor = Color.White;
            btnMore.Text = "...";
            

            #region"Thiet cac tham so cho datagridview
            grdLogAction.AutoGenerateColumns = false;
            grdLogAction.ReadOnly = false;
            grdLogAction.AllowUserToAddRows = false;
            DataGridViewTextBoxColumn col;
            grdLogAction.RowHeadersWidth = 20;

            var colCheckBox = MTControl.MColumnDefine.CheckboxColumn("IsChecked", "", 28);
            colCheckBox.ReadOnly = false;
            colCheckBox.ValueType = typeof(bool);
            colCheckBox.FalseValue = 0;
            colCheckBox.TrueValue = 1;
            colCheckBox.MinimumWidth = 28;
            colCheckBox.Frozen = true;
            colCheckBox.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grdLogAction.Columns.Add(colCheckBox);
            col = MTControl.MColumnDefine.TextboxColumn("sCreatedBy", "Tài khoản", 100);
            col.MinimumWidth = 100;
            col.ReadOnly = true;
            col.Frozen = true;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grdLogAction.Columns.Add(col);

            col = MTControl.MColumnDefine.TextboxColumn("FunctionName", "Chức năng", 200);
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            col.ReadOnly = true;
            col.Frozen = true;
            grdLogAction.Columns.Add(col);

            col = MTControl.MColumnDefine.TextboxColumn("LogTime", "Thời gian", 150);
            col.MinimumWidth = 150;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            col.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            col.ReadOnly = true;
            grdLogAction.Columns.Add(col);

            col = MTControl.MColumnDefine.TextboxColumn("ActionName", "Hành động", 100);
            col.MinimumWidth = 100;
            col.ReadOnly = true;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grdLogAction.Columns.Add(col);

            col = MTControl.MColumnDefine.TextboxColumn("EntityInfo", "Tham chiếu", 150);
            col.MinimumWidth = 150;
            col.ReadOnly = true;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grdLogAction.Columns.Add(col);

            col = MTControl.MColumnDefine.TextboxColumn("Description", "Mô tả", 250);
            col.ReadOnly = true;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grdLogAction.Columns.Add(col);

            col = MTControl.MColumnDefine.TextboxColumn("Id", "#", 100);
            colCheckBox.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            col.ReadOnly = true;
            col.Visible = false;
            grdLogAction.Columns.Add(col);


            headerCheckBox = new CheckBox();
            headerCheckBox.Size = new Size(15, 15);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Click += new EventHandler(headerCheckBox_Clicked);
            // Reset properties
            headerCheckBox.Padding = new Padding(0);
            headerCheckBox.Margin = new Padding(0);
            headerCheckBox.Text = "";

            // Add checkbox to datagrid cell
            grdLogAction.Controls.Add(headerCheckBox);
            DataGridViewHeaderCell header = grdLogAction.Columns[0].HeaderCell;
            headerCheckBox.Location = new Point(
                (header.ContentBounds.Left +
                 (header.ContentBounds.Right - header.ContentBounds.Left + headerCheckBox.Size.Width)
                 / 2) + 1,
                (header.ContentBounds.Top +
                 (header.ContentBounds.Bottom - header.ContentBounds.Top + headerCheckBox.Size.Height)
                 / 2));
            grdLogAction.CellContentClick += new DataGridViewCellEventHandler(grdLogAction_CellContentClick);
            grdLogAction.SelectionChanged += new EventHandler(grdLogAction_SelectionChanged);
            #endregion

            grdLogAction.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grdLogAction.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.Program = "Nhật ký hành động";

            ucDateRangeFilter.Period_Changed -= ucDateRangeFilter_PeriodChanged;
            ucDateRangeFilter.Period_Changed += ucDateRangeFilter_PeriodChanged;

            _mViewPaging.SetPagedDataSource(0, mDataNavigatorPaging1, SearchData);
        }


        /// <summary>
        /// Lấy danh sách item được chọn trên grid
        /// </summary>
        /// <returns></returns>
        /// Created by: dvthang: 02.11.2020
        private DataGridViewRow[] GetSelectedItems()
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in grdLogAction.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].EditedFormattedValue))
                {
                    rows.Add(row);
                }
            }

            return rows.ToArray();
        }

        

        /// <summary>
        /// Tìm kiếm giá trị tren màn hình danh sách
        /// </summary>
        private void SearchData()
        {
            if (!backgroundWorkerLogAction.IsBusy)
            {
                if (!ucDateRangeFilter.FromDate.HasValue)
                {
                    MMessage.ShowWarning("Thông tin từ ngày không được bỏ trống.");
                    return;
                }

                if (!ucDateRangeFilter.ToDate.HasValue)
                {
                    MMessage.ShowWarning("Thông tin đến ngày không được bỏ trống.");
                    return;
                }

                if (ucDateRangeFilter.ToDate < ucDateRangeFilter.FromDate)
                {
                    MMessage.ShowWarning("Thông tin từ ngày phải nhỏ đến ngày.");
                    return;
                }
                headerCheckBox.Checked = false;
                string searchValue = txtSearch.Text;
                if (!string.IsNullOrEmpty(searchValue))
                {
                    searchValue = searchValue.Trim();
                }
                _handler = CommonFnUI.ShowProgress(grdLogAction);
                backgroundWorkerLogAction.RunWorkerAsync(new ArgumentSearchLogAction
                {
                    UserId = cboAccount.EditValue!=null? Guid.Parse(cboAccount.EditValue.ToString()):Guid.Empty,
                    SearchValue = searchValue,
                    FromDate = ucDateRangeFilter.FromDate.Value,
                    ToDate = ucDateRangeFilter.ToDate.Value,
                    PageSize= _mViewPaging.PageSize,
                    Page = _mViewPaging.CurrentPage,
                });
            }
        }
        #endregion

        #region"Event"
        private void frmLogAction_Load(object sender, EventArgs e)
        {
            LogHelper.AddEvent(this.UUID, this.Program);

            var sysUserRepository = (SysUserRepository)DBContext.GetRep<SysUserRepository>();
            List<MT.Data.ViewModels.SelectedItem> items = sysUserRepository.GetUsers();
            items.Insert(0, new SelectedItem { GuidId = Guid.Empty, Text = "Tất cả" });
            cboAccount.Properties.ValueMember = "GuidId";
            cboAccount.Properties.DataSource = items;
            ucDateRangeFilter.SetDefaultValue(MT.Library.Enummation.Period.NamNay);
            cboAccount.EditValue = Guid.Empty;
        }

        private void frmLogAccess_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogHelper.UpdateEvent(this.UUID);
            this.Dispose();
        }

        private void frmLogAction_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void backgroundWorkerLogAction_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                var auditingLogRep = (AuditingLogRepository)DBContext.GetRep<AuditingLogRepository>();
                e.Result = auditingLogRep.GetLogAction(e.Argument as ArgumentSearchLogAction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void backgroundWorkerLogAction_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                try
                {
                    ResultPaging resultPaging = e.Result as ResultPaging;
                    _mViewPaging.SetPagedDataSource(resultPaging.Total,mDataNavigatorPaging1, SearchData);
                    _bs = new BindingSource();
                    _bs.DataSource = resultPaging.Data;
                    grdLogAction.DataSource = _bs;
                    if (_bs.Count > 0)
                    {
                        _bs.Position = 0;
                        var currentRow = grdLogAction.SelectedRows[0];
                        var currentCheckBox = (currentRow.Cells[0] as DataGridViewCheckBoxCell);
                        currentCheckBox.Value = true;
                        currentRow.DefaultCellStyle.BackColor = Color.FromArgb(251, 222, 187);

                        if (_bs.Count == 1)
                        {
                            headerCheckBox.Checked = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MMessage.ShowError(ex.Message);
                }
            }
            else
            {
                MMessage.ShowError(e.Error.Message);
            }
            CommonFnUI.CloseProgress(_handler);
        }

        private void grdLogAccess_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void grdLogAction_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = null;
            DataGridViewCheckBoxCell currentCheckBox = null;
            if (grdLogAction.CurrentCell.ColumnIndex == 0)
            {
                return;
            }
            if (Control.ModifierKeys != Keys.Control)
            {
                headerCheckBox.Checked = false;
                foreach (DataGridViewRow item in grdLogAction.Rows)
                {
                    DataGridViewCheckBoxCell chkItem = (item.Cells[0] as DataGridViewCheckBoxCell);
                    chkItem.Value = false;
                    item.DefaultCellStyle.BackColor = Color.White;
                }
            }
            else
            {
                if (_bs.Count > 0 && _bs.Count - 1 == this.GetSelectedItems().Length)
                {
                    headerCheckBox.Checked = true;
                }
                else
                {
                    headerCheckBox.Checked = false;
                }
            }
            currentRow = grdLogAction.Rows[grdLogAction.CurrentCell.RowIndex];
            currentCheckBox = (currentRow.Cells[0] as DataGridViewCheckBoxCell);
            currentCheckBox.Value = true;
            currentRow.DefaultCellStyle.BackColor = Color.FromArgb(251, 222, 187);
        }


        private void grdLogAction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                DataGridViewRow row = grdLogAction.Rows[e.RowIndex];
                if (Convert.ToBoolean(row.Cells[0].EditedFormattedValue) == false)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    headerCheckBox.Checked = false;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(251, 222, 187);
                }

                if (_bs.Count > 0 && _bs.Count == this.GetSelectedItems().Length)
                {
                    headerCheckBox.Checked = true;
                }
            }
        }

        private void cboAccount_EditValueChanged(object sender, EventArgs e)
        {
            SearchData();
        }

        private void ucDateRangeFilter_PeriodChanged(object sender, EventArgs e)
        {
            SearchData();
        }
        

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchData();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            assistant = new TypeAssistant(1000);
            assistant.Idled += assistant_Idled;
            assistant.TextChanged();
        }

        private void assistant_Idled(object sender, EventArgs e)
        {
            this.Invoke(
             new MethodInvoker(() =>
             {
                 SearchData();
             }));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            SearchData();
        }

        private void headerCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            grdLogAction.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in grdLogAction.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells[0] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
                if (headerCheckBox.Checked)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(251, 222, 187);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }


        private void btnPrintSession_Click(object sender, EventArgs e)
        {

        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            gunaContextMenuStripMoreButton.Show(btnMore.PointToScreen(new Point(0, btnMore.Height)));
        }


        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (!CommonFnUI.CheckPermission(MT.Data.FormUIHandle.MSC_CONFIG_LogAction, MT.Library.Enummation.PermissionValue.Delete))
                {
                    MMessage.ShowWarning(MT.Library.CommonKey.MsgNotPermission);
                    return;
                }

                DataGridViewRow[] rows = this.GetSelectedItems();
                if (rows.Length == 0)
                {
                    MMessage.ShowWarning("Bạn vui lòng chọn ít nhất một bản ghi.");
                    return;
                }

                MMessage.ShowQuestion("Bạn có chắc chắn muốn xóa các bản ghi đã chọn không?(Y/N)", (msg) =>
                 {
                     List<AuditingLog> auditingLogs = new List<AuditingLog>();
                     foreach (var item in rows)
                     {
                         Guid id = Guid.Parse(item.Cells["Id"].Value.ToString());
                         auditingLogs.Add(new AuditingLog {Id=id });
                     }

                     var auditingLogRep = (AuditingLogRepository)DBContext.GetRep<AuditingLogRepository>();

                     var rs = auditingLogRep.DeleteData(auditingLogs);
                     if (rs.Success)
                     {
                         headerCheckBox.Checked = false;
                         SearchData();
                     }
                     else
                     {
                         MMessage.ShowError("Đã có lỗi xảy ra");
                     }
                 });

            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }

        private void grdLogAction_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gunaContextMenuStripMoreButton.Show(grdLogAction, new Point(e.X, e.Y));
            }
        }

        #endregion

    }

}