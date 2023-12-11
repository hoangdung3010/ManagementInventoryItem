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
    public partial class frmLogAccess : FormUI.FormUIBase
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
        public frmLogAccess()
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
            cboAccount.Properties.Columns.Add(new LookUpColumnInfo("Text", "Người dùng"));
            cboAccount.Properties.ShowHeader = false;
            btnMore.Text = "...";
            btnMore.ForeColor = Color.White;

            #region"Thiet cac tham so cho datagridview
            grdLogAccess.AutoGenerateColumns = false;
            grdLogAccess.ReadOnly = false;
            grdLogAccess.AllowUserToAddRows = false;
            DataGridViewTextBoxColumn col;
            grdLogAccess.RowHeadersWidth = 20;

            var colCheckBox = MTControl.MColumnDefine.CheckboxColumn("IsChecked", "", 28);
            colCheckBox.ReadOnly = false;
            colCheckBox.ValueType = typeof(bool);
            colCheckBox.FalseValue = 0;
            colCheckBox.TrueValue = 1;
            colCheckBox.MinimumWidth = 28;
            colCheckBox.Frozen = true;
            colCheckBox.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grdLogAccess.Columns.Add(colCheckBox);
            col = MTControl.MColumnDefine.TextboxColumn("UserName", "Tài khoản", 100);
            col.MinimumWidth = 100;
            col.ReadOnly = true;
            col.Frozen = true;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grdLogAccess.Columns.Add(col);
            col = MTControl.MColumnDefine.TextboxColumn("Program", "Chức năng", 200);
            col.ReadOnly = true;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdLogAccess.Columns.Add(col);
            col = MTControl.MColumnDefine.TextboxColumn("Datein", "Ngày giờ vào", 150);
            col.MinimumWidth = 150;
            col.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            col.ReadOnly = true;
            grdLogAccess.Columns.Add(col);
            col = MTControl.MColumnDefine.TextboxColumn("Dateout", "Ngày giờ ra", 150);
            col.MinimumWidth = 150;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            col.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            col.ReadOnly = true;
            grdLogAccess.Columns.Add(col);
            col = MTControl.MColumnDefine.TextboxColumn("Dateuse", "Thời gian sử dụng(s)", 150);
            col.MinimumWidth = 150;
            col.ReadOnly = true;
            col.DefaultCellStyle.Format = "HH:mm:ss";
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grdLogAccess.Columns.Add(col);

            col = MTControl.MColumnDefine.TextboxColumn("Id", "#", 100);
            colCheckBox.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            col.ReadOnly = true;
            col.Visible = false;
            grdLogAccess.Columns.Add(col);

            headerCheckBox = new CheckBox();
            headerCheckBox.Size = new Size(15, 15);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Click += new EventHandler(headerCheckBox_Clicked);
            // Reset properties
            headerCheckBox.Padding = new Padding(0);
            headerCheckBox.Margin = new Padding(0);
            headerCheckBox.Text = "";

            // Add checkbox to datagrid cell
            grdLogAccess.Controls.Add(headerCheckBox);
            DataGridViewHeaderCell header = grdLogAccess.Columns[0].HeaderCell;
            headerCheckBox.Location = new Point(
                (header.ContentBounds.Left +
                 (header.ContentBounds.Right - header.ContentBounds.Left + headerCheckBox.Size.Width)
                 / 2) + 1,
                (header.ContentBounds.Top +
                 (header.ContentBounds.Bottom - header.ContentBounds.Top + headerCheckBox.Size.Height)
                 / 2));
            grdLogAccess.CellContentClick += new DataGridViewCellEventHandler(grdLogAccess_CellContentClick);
            grdLogAccess.SelectionChanged += new EventHandler(grdLogAccess_SelectionChanged);
            ucDateRangeFilter.Period_Changed -= ucDateRangeFilter_PeriodChanged;
            ucDateRangeFilter.Period_Changed += ucDateRangeFilter_PeriodChanged;
            #endregion



            this.Program = "Nhật ký truy cập";

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
            foreach (DataGridViewRow row in grdLogAccess.Rows)
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
            if (!backgroundWorkerLogAccess.IsBusy)
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
                if (!string.IsNullOrWhiteSpace(searchValue))
                {
                    searchValue = searchValue.Trim();
                }
                _handler = CommonFnUI.ShowProgress(grdLogAccess);
                backgroundWorkerLogAccess.RunWorkerAsync(new ArgumentSearchLogAccess
                {
                    UserId = cboAccount.EditValue != null ? Guid.Parse(cboAccount.EditValue.ToString()) : Guid.Empty,
                    UserName = cboAccount.EditValue != null ?string.Empty: cboAccount.Text,
                    Program = searchValue,
                    FromDate = ucDateRangeFilter.FromDate.Value,
                    ToDate = ucDateRangeFilter.ToDate.Value,
                    Page = _mViewPaging.CurrentPage,
                    PageSize = _mViewPaging.PageSize
                }) ;
            }
        }
        #endregion

        #region"Event"
        private void frmLogAccess_Load(object sender, EventArgs e)
        {
            LogHelper.AddEvent(this.UUID, this.Program);

            SysUserRepository sysUserRepository=(SysUserRepository)DBContext.GetRep<SysUserRepository>();
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

        private void frmLogAccess_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void backgroundWorkerLogAccess_DoWork(object sender, DoWorkEventArgs e)
        {
            ArgumentSearchLogAccess argumentSearchLogAccess = e.Argument as ArgumentSearchLogAccess;
            LogAccessRepository logAccessRepository = (LogAccessRepository)DBContext.GetRep<LogAccessRepository>();
            e.Result = logAccessRepository.GetLogAccess(argumentSearchLogAccess);
        }

        private void backgroundWorkerLogAccess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                try
                {
                    _bs = new BindingSource();

                    ResultPaging resultPaging = e.Result as ResultPaging;

                    _mViewPaging.SetPagedDataSource(resultPaging.Total, mDataNavigatorPaging1, SearchData);

                    _bs.DataSource = resultPaging.Data;
                    grdLogAccess.DataSource = _bs;
                    if (_bs.Count > 0)
                    {
                        _bs.Position = 0;
                        var currentRow = grdLogAccess.SelectedRows[0];
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
        private void grdLogAccess_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = null;
            DataGridViewCheckBoxCell currentCheckBox = null;
            if (grdLogAccess.CurrentCell.ColumnIndex == 0)
            {
                return;
            }
            if (Control.ModifierKeys != Keys.Control)
            {
                headerCheckBox.Checked = false;
                foreach (DataGridViewRow item in grdLogAccess.Rows)
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
            currentRow = grdLogAccess.Rows[grdLogAccess.CurrentCell.RowIndex];
            currentCheckBox = (currentRow.Cells[0] as DataGridViewCheckBoxCell);
            currentCheckBox.Value = true;
            currentRow.DefaultCellStyle.BackColor = Color.FromArgb(251, 222, 187);
        }

        private void grdLogAccess_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                DataGridViewRow row = grdLogAccess.Rows[e.RowIndex];
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchData();
            }
        }
        private void assistant_Idled(object sender, EventArgs e)
        {
            this.Invoke(
             new MethodInvoker(() =>
             {
                 SearchData();
             }));
        }

        private void ucDateRangeFilter_PeriodChanged(object sender, EventArgs e)
        {
            SearchData();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void headerCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            grdLogAccess.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in grdLogAccess.Rows)
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



        private void btnMore_Click(object sender, EventArgs e)
        {
            gunaContextMenuStripMoreButton.Show(btnMore.PointToScreen(new Point(0, btnMore.Height)));
        }


        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (!CommonFnUI.CheckPermission(MT.Data.FormUIHandle.MSC_CONFIG_LogAccess, MT.Library.Enummation.PermissionValue.Delete))
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
                     List<NHATKY> nHATKies = new List<NHATKY>();
                     foreach (var item in rows)
                     {
                         long id = Convert.ToInt64(item.Cells["Id"].Value);
                         nHATKies.Add(new NHATKY {Id=id });
                     }
                     var logAccessRepository = (LogAccessRepository)DBContext.GetRep<LogAccessRepository>();
                     var rs= logAccessRepository.DeleteData(nHATKies);
                     if (rs.Success)
                     {
                         headerCheckBox.Checked = false;
                         SearchData();
                     }
                     else
                     {
                         if (!string.IsNullOrEmpty(rs.UserMsg))
                         {
                             MMessage.ShowWarning(rs.UserMsg);
                         }
                     }
                 });

            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }


        private void grdLogAccess_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                gunaContextMenuStripMoreButton.Show(grdLogAccess, new Point(e.X, e.Y));
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            assistant = new TypeAssistant(1000);
            assistant.Idled += assistant_Idled;
            assistant.TextChanged();
        }

        #endregion


    }

}