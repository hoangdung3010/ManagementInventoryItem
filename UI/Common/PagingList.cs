using DevExpress.XtraGrid.Views.Grid;
using FormUI.Common;
using MT.Data;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Library;
using MT.Library.Extensions;
using MT.Library.UW;
using MTControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormUI
{
    /// <summary>
    /// Class để phân trang cho grid
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// Create by: dvthang:05.03.2017
    public class PagingList: IDisposable
    {
        #region"Declare"

        /// <summary>
        /// Đánh dấu có phải load lại data không, mặc định bằng true là là không, ngược lại là có 
        /// </summary>
        private bool isReload;
        /// <summary>
        /// Đánh dấu có tự động load grid hay không, mặc định  là luôn load
        /// </summary>
        public bool IsAutoBind;
        /// <summary>
        /// Thuộc tính dánh dấu tự giải phóng các đối tượng của class
        /// </summary>
        private bool disposed;
        /// <summary>
        /// Đối tượng grd load dữ liệu
        /// </summary>
        private MGridControl grd;

        /// <summary>
        /// Đối tượng grid phân trang(Sử dụng userControl)
        /// </summary>
        /// Create by: dvthang:04.03.2017
        private MGridPaging pagingControl;

        public MGridPaging PagingControl
        {
            get { return pagingControl; }
            set { pagingControl = value; }
        }


        /// <summary>
        /// Số phần tử hiển thị trên 1 trang
        /// </summary>
        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        /// <summary>
        /// Trang hiện tại
        /// </summary>
        private int currentPage;

        public int CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; }
        }

        /// <summary>
        /// Tổng số trang
        /// </summary>
        private int totalPage;

        /// <summary>
        /// Lấy bắt đầu từ bản ghi số bao nhiêu
        /// </summary>
        private int start;

        /// <summary>
        /// Điều kiện load data
        /// </summary>
        private string where;

        public string Where
        {
            get { return where; }
            set { where = value; }
        }

        /// <summary>
        /// Tổng số bản ghi trả về
        /// </summary>
        private int totalCount;

        public int TotalCount
        {
            get { return totalCount; }
        }

        private MFormBase formParent;

        public MFormBase FormParent
        {
            get { return formParent; }
            set { formParent = value; }
        }
        private MBindingSource binddingSource;

        /// <summary>
        /// Đối tượng thao tác dữ liệu
        /// </summary>
        /// Create by: dvthang:04.03.2017
        private IBaseRepository baseRepository;

        public IBaseRepository BaseRepository
        {
            get { return baseRepository; }
            set { baseRepository = value; }
        }

        /// <summary>
        /// Sắp trên trên grid
        /// </summary>
        private string sort;

        public string Sort
        {
            get { return sort; }
            set { sort = value; }
        }

        /// <summary>
        /// Danh sách các cột cần lấy lên grid
        /// </summary>
        private string columns;

        public string Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        /// <summary>
        /// Đối tượng để tạo thread load data cho grid
        /// </summary>
        private BackgroundWorker worker = null;

        /// <summary>
        /// Danh sách các tham số truyền thêm vào store
        /// </summary>
        /// Create by: dvthang:11.03.2017
        private object[] param;

        /// <summary>
        /// Sau khi data cho grid xong thì gọi hàm này
        /// </summary>
        /// Create by: dvthang:11.03.2017
        public EventHandler<EventLoadDataFinishArgs> LoadDataFinish;

        /// <summary>
        /// Sum trên grid
        /// </summary>
        private Dictionary<string, object> dicSummary;
        #endregion

        #region"Contructor"
        /// <summary>
        /// Hàm khởi tạo không tham số
        /// </summary>
        public PagingList()
        {

            this.binddingSource = new MBindingSource();
            this.currentPage = 1;
            this.totalPage = 0;
            this.totalCount = 0;
            this.where = string.Empty;
            this.start = 0;
            this.pageSize = this.pagingControl.GetMTbrPaging().GetPageSize();
            this.IsAutoBind = true;
            this.grd = this.pagingControl.GetMGridControl();
            this.sort = this.grd.Sort;
            this.columns = this.grd.Columns;
            this.dicSummary = new Dictionary<string, object>();
            this.pagingControl.GetMTbrPaging().EventHandlerPaging -= btnPaging_Click;
            this.pagingControl.GetMTbrPaging().EventHandlerPaging += btnPaging_Click;
            this.pagingControl.GetMTbrPaging().EventHandlerShowRecord -= cboShowRecord_Changed;
            this.pagingControl.GetMTbrPaging().EventHandlerShowRecord += cboShowRecord_Changed;
            if (!string.IsNullOrWhiteSpace(this.pagingControl.GetMGridControl().Sumary))
            {
                this.pagingControl.GetMGridControl().FirstView.OptionsView.ShowFooter = true;
            }
            this.grd.IsRemoteFilter = true;
            this.grd.FirstView.CustomSummaryCalculate -= FirstView_CustomSummaryCalculate;
            this.grd.FirstView.CustomSummaryCalculate+=FirstView_CustomSummaryCalculate;

            //Bắt event filter row trên grid
            this.grd.StartRemoteFilterRow -= new EventHandler(StartRemoteFilterRow);
            this.grd.StartRemoteFilterRow += new EventHandler(StartRemoteFilterRow);

            this.grd.ColumnSortInfoCollectionChanged -= new EventHandler(ColumnSortInfoCollectionChanged);
            this.grd.ColumnSortInfoCollectionChanged += new EventHandler(ColumnSortInfoCollectionChanged);


            //Đăng ký event xử lý riêng cho worker
            worker = new BackgroundWorker();
            worker.DoWork -= worker_DoWork;
            worker.RunWorkerCompleted -= worker_Completed;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_Completed;
        }

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="pagingControl"></param>
        /// <param name="gridcontrol"></param>
        /// <param name="gridViewControl"></param>
        /// <param name="columns"></param>
        public PagingList(MGridPaging pagingControl)
        {
            this.pagingControl = pagingControl;
            this.currentPage = 1;
            this.totalPage = 0;
            this.totalCount = 0;
            this.where = string.Empty;
            this.start = 0;
            this.pageSize = this.pagingControl.GetMTbrPaging().GetPageSize();
            this.IsAutoBind = true;
            this.binddingSource = new MBindingSource();
            this.grd = this.pagingControl.GetMGridControl();
            this.sort = this.grd.Sort;
            this.columns = this.grd.Columns;
            this.dicSummary = new Dictionary<string, object>();
            this.pagingControl.GetMTbrPaging().EventHandlerPaging -= btnPaging_Click;
            this.pagingControl.GetMTbrPaging().EventHandlerPaging += btnPaging_Click;

            this.pagingControl.GetMTbrPaging().EventHandlerShowRecord -= cboShowRecord_Changed;
            this.pagingControl.GetMTbrPaging().EventHandlerShowRecord += cboShowRecord_Changed;

            if (!string.IsNullOrWhiteSpace(this.pagingControl.GetMGridControl().Sumary))
            {
                this.pagingControl.GetMGridControl().FirstView.OptionsView.ShowFooter = true;
            }

            this.grd.IsRemoteFilter = true;
            this.grd.FirstView.CustomSummaryCalculate -= FirstView_CustomSummaryCalculate;
            this.grd.FirstView.CustomSummaryCalculate += FirstView_CustomSummaryCalculate;

            //Bắt event filter row trên grid
            this.grd.StartRemoteFilterRow -= new EventHandler(StartRemoteFilterRow);
            this.grd.StartRemoteFilterRow += new EventHandler(StartRemoteFilterRow);

            ////Đăng ký event xử lý riêng cho worker
            worker = new BackgroundWorker();
            worker.DoWork -= worker_DoWork;
            worker.RunWorkerCompleted -= worker_Completed;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_Completed;
        }

        /// <summary>
        /// Bắt event Sort trên grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColumnSortInfoCollectionChanged(object sender, EventArgs e)
        {
            MGridView mGridView = (MGridView)this.grd.FirstView;
            sort = string.Empty;
            if (mGridView.SortedColumns != null && mGridView.SortedColumns.Count > 0)
            {
                List<string> lstSorts = new List<string>();
                foreach (MGridColumn item in mGridView.SortedColumns)
                {
                    if ("Ascending".Equals(item.SortOrder.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        lstSorts.Add($"[{item.FieldName}] ASC");
                    }
                    else
                    {
                        lstSorts.Add($"[{item.FieldName}] DESC");
                    }
                }
                sort = string.Join(",", lstSorts);
            }
            LoadData();
        }



        /// <summary>
        /// Bắt event filterrow trên grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartRemoteFilterRow(object sender,EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~PagingList()
        {
            this.Dispose(false);
        }
        #endregion

        #region"Load Data cho grid master"
        /// <summary>
        /// Chạy thread load data
        /// </summary>
        /// Create by: dvthang:05.03.2017
        private void RunWorker(bool isExport=false)
        {
            if (!isReload && this.worker != null)
            {
                if (!this.worker.IsBusy)
                {
                    string strColumnNames = string.Empty;

                    if (string.IsNullOrWhiteSpace(grd.KeyName))
                    {
                        grd.KeyName = "Id";
                    }

                    HashSet<string> colNames = new HashSet<string>()
                    {
                        grd.KeyName
                    };
                    if (string.IsNullOrWhiteSpace(columns))
                    {
                        foreach (DevExpress.XtraGrid.Columns.GridColumn col in grd.FirstView.Columns)
                        {
                            colNames.Add($"[{col.FieldName}]");
                        }

                        strColumnNames = string.Join(",", colNames);
                    }
                    else
                    {
                        var arrSplitColumn = columns.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        strColumnNames = string.Join(",", arrSplitColumn.Select(m => $"[{m}]"));
                    }

                    if (!string.IsNullOrWhiteSpace(grd.CustomModelFields))
                    {
                        var arrSplitCustomModelFields = grd.CustomModelFields.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        strColumnNames += "," + string.Join(",", arrSplitCustomModelFields.Select(m => $"[{m}]"));
                    }

                    var gridView = (MGridView)grd.FirstView;
                    string filterRowQuery = CustomActiveFilterString(grd);
                    string buildWhereFilter = string.Empty;

                    if (!string.IsNullOrWhiteSpace(filterRowQuery))
                    {
                        if (string.IsNullOrWhiteSpace(where))
                        {
                            buildWhereFilter = filterRowQuery;
                        }
                        else
                        {
                            if (filterRowQuery.Trim().StartsWith("AND"))
                            {
                                buildWhereFilter = where + " " + filterRowQuery;
                            }
                            else
                            {
                                buildWhereFilter = where + " AND " + filterRowQuery;
                            }
                        }
                    }
                    else
                    {
                        buildWhereFilter = where;
                    }

                    //Kiểm tra nếu có bản ghi được chọn thì chỉ xuất khẩu bản ghi chọ, ngược lại xuất khẩu hết danh sách
                    if (isExport)
                    {
                        var datas = grd.GetListRecordByRowsSelected<object>();
                        string[] ids = new string[datas.Count];
                        if (datas?.Count > 0)
                        {
                            int i = 0;
                            string primaryKeyName = string.Empty;
                            foreach (var item in datas)
                            {
                                primaryKeyName = string.IsNullOrWhiteSpace(grd.KeyName) ? "Id" : grd.KeyName;
                                object id = item.GetValue<object>(primaryKeyName);
                                ids[i++] = $"'{id.ToString()}'";
                            }

                            if (!string.IsNullOrWhiteSpace(buildWhereFilter))
                            {
                                buildWhereFilter += $" AND T.[{primaryKeyName}] IN({string.Join(",", ids)})";
                            }
                            else
                            {
                                buildWhereFilter = $" T.[{primaryKeyName}] IN({string.Join(",", ids)})";
                            }
                        }
                    }

                    if (string.IsNullOrWhiteSpace(sort))
                    {
                        sort = MT.Library.CommonKey.ModifiedDate+" DESC";
                    }

                    ArgumentGrid argumentGrid = new ArgumentGrid
                    {
                        Sumary=grd.Sumary,
                        KeyName=grd.KeyName,
                        ViewName= string.IsNullOrWhiteSpace(grd.ViewName) ? this.grd.TableName : grd.ViewName,
                        Columns= strColumnNames,
                        Where= buildWhereFilter,
                        Sort=sort,
                        IsExport=isExport
                    };
                    this.grd.FirstView.ShowLoadingPanel();
                    this.grd.MarkLoading = true;
                    this.worker.RunWorkerAsync(argumentGrid);
                }
                //Đánh dấu được load
                isReload = false;
            }
        }

        /// <summary>
        /// Load data cho grid
        /// </summary>
        /// <returns>dvthang-30/07/2016</returns>
        private object LoadPage(ArgumentGrid argumentGrid)
        {
            try
            {
                if (PageSize > 0 && CurrentPage > 0)
                {
                    start = (CurrentPage - 1) * PageSize;
                }
                else
                {
                    start = 0;
                }
                this.dicSummary = new Dictionary<string, object>();
                if (!string.IsNullOrWhiteSpace(argumentGrid.Sumary))
                {
                    string[] colsSumary = argumentGrid.Sumary.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var item in colsSumary)
                    {
                        if (!dicSummary.ContainsKey(item.Trim()))
                        {
                            dicSummary[item.Trim()] = 0;
                        }
                    }
                }

                if (argumentGrid.IsExport)
                {
                    return baseRepository.GetAllData(argumentGrid.ViewName, argumentGrid.Sort,argumentGrid.Where, argumentGrid.Columns);
                }
                else
                {
                    return baseRepository.GetDataPaging(argumentGrid.ViewName, argumentGrid.Sort, start,
                  PageSize, argumentGrid.Where, argumentGrid.Columns,
                  ref this.totalCount, ref this.dicSummary);
                }
            }
            catch (Exception e)
            {
                CommonFnUI.HandleException(e);
            }

            return null;
        }

        /// <summary>
        /// Tạo lại bộ lọc 
        /// </summary>
        /// <param name="mGridControl">GridControl</param>
        /// <returns>Chuỗi query</returns>
       private string CustomActiveFilterString(MGridControl mGridControl)
        {
            var filterObjects = grd.FilterObjects;
            if(filterObjects==null || filterObjects.Count == 0)
            {
                return string.Empty;
            }
            StringBuilder builder = new StringBuilder();
            foreach (var item in filterObjects)
            {
                
                var mGridColumn =(MGridColumn)grd.FirstView.Columns[item.FieldName];
              
                switch (item.Condition)
                {
                    case DevExpress.XtraEditors.ColumnAutoFilterCondition.Contains:
                        if (MT.Library.Utility.CheckForSQLInjection(item.Value.ToString()))
                        {
                            throw new Exception("SQL Injection");
                        }
                        
                        builder.Append($" AND [{item.FieldName}] LIKE N'%{MT.Library.Utility.AddChar(item.Value.ToString())}%'");
                        break;
                    case DevExpress.XtraEditors.ColumnAutoFilterCondition.DoesNotContain:
                        if (MT.Library.Utility.CheckForSQLInjection(item.Value.ToString()))
                        {
                            throw new Exception("SQL Injection");
                        }
                        builder.Append($" AND [{item.FieldName}] NOT LIKE N'%{MT.Library.Utility.AddChar(item.Value.ToString())}%'");
                        break;
                    case DevExpress.XtraEditors.ColumnAutoFilterCondition.Like:
                        if (MT.Library.Utility.CheckForSQLInjection(item.Value.ToString()))
                        {
                            throw new Exception("SQL Injection");
                        }
                        builder.Append($" AND [{item.FieldName}] LIKE N'%{MT.Library.Utility.AddChar(item.Value.ToString())}%'");
                        break;
                    case DevExpress.XtraEditors.ColumnAutoFilterCondition.NotLike:
                        if (MT.Library.Utility.CheckForSQLInjection(item.Value.ToString()))
                        {
                            throw new Exception("SQL Injection");
                        }
                        builder.Append($" AND [{item.FieldName}] NOT LIKE N'%{MT.Library.Utility.AddChar(item.Value.ToString())}%'");
                        break;
                    case DevExpress.XtraEditors.ColumnAutoFilterCondition.BeginsWith:
                        if (MT.Library.Utility.CheckForSQLInjection(item.Value.ToString()))
                        {
                            throw new Exception("SQL Injection");
                        }
                        builder.Append($" AND [{item.FieldName}] LIKE N'{MT.Library.Utility.AddChar(item.Value.ToString())}%'");
                        break;
                    case DevExpress.XtraEditors.ColumnAutoFilterCondition.EndsWith:
                        if (MT.Library.Utility.CheckForSQLInjection(item.Value.ToString()))
                        {
                            throw new Exception("SQL Injection");
                        }
                        builder.Append($" AND [{item.FieldName}] LIKE N'%{MT.Library.Utility.AddChar(item.Value.ToString())}'");
                        break;
                    case DevExpress.XtraEditors.ColumnAutoFilterCondition.Less:


                        if (mGridColumn.UnboundType == DevExpress.Data.UnboundColumnType.DateTime)
                        {
                            builder.Append($" AND [{item.FieldName}] < '{Convert.ToDateTime(item.Value.ToString()).ToString("yyyy/MM/dd")}'");
                        }
                        else
                        {
                            //Kiểu số
                            builder.Append($" AND [{item.FieldName}] < {item.Value}");
                        }
                        break;
                    case DevExpress.XtraEditors.ColumnAutoFilterCondition.LessOrEqual:
                        if (mGridColumn.UnboundType == DevExpress.Data.UnboundColumnType.DateTime)
                        {
                            builder.Append($" AND [{item.FieldName}] <= '{Convert.ToDateTime(item.Value.ToString()).ToString("yyyy/MM/dd")}'");
                        }
                        else
                        {
                            //Kiểu số
                            builder.Append($" AND [{item.FieldName}] <= {item.Value}");
                        }
                        break;
                    case DevExpress.XtraEditors.ColumnAutoFilterCondition.Greater:
                        if (mGridColumn.UnboundType == DevExpress.Data.UnboundColumnType.DateTime)
                        {
                            builder.Append($" AND [{item.FieldName}] > '{Convert.ToDateTime(item.Value.ToString()).ToString("yyyy/MM/dd")}'");
                        }
                        else
                        {
                            //Kiểu số
                            builder.Append($" AND [{item.FieldName}] > {item.Value}");
                        }
                        break;
                    case DevExpress.XtraEditors.ColumnAutoFilterCondition.GreaterOrEqual:
                        if (mGridColumn.UnboundType == DevExpress.Data.UnboundColumnType.DateTime)
                        {
                            builder.Append($" AND [{item.FieldName}] >= '{Convert.ToDateTime(item.Value.ToString()).ToString("yyyy/MM/dd")}'");
                        }
                        else
                        {
                            //Kiểu số
                            builder.Append($" AND [{item.FieldName}] >= {item.Value}");
                        }
                        break;
                    case DevExpress.XtraEditors.ColumnAutoFilterCondition.Equals:
                        if (mGridColumn.UnboundType == DevExpress.Data.UnboundColumnType.DateTime)
                        {
                            var startOfDay = Convert.ToDateTime(item.Value.ToString()).StartOfDay();
                            builder.Append($" AND ([{item.FieldName}] >= '{startOfDay.ToString("yyyy/MM/dd")}' AND [{item.FieldName}]<'{startOfDay.AddDays(1).ToString("yyyy/MM/dd")}')");
                        }
                        else if(mGridColumn.UnboundType == DevExpress.Data.UnboundColumnType.Decimal
                            || mGridColumn.UnboundType == DevExpress.Data.UnboundColumnType.Integer
                            || mGridColumn.UnboundType == DevExpress.Data.UnboundColumnType.Boolean)
                        {
                            //Kiểu số
                            builder.Append($" AND [{item.FieldName}] = {item.Value}");
                        }
                        else
                        {
                            //string
                            builder.Append($" AND [{item.FieldName}] = N'{MT.Library.Utility.AddChar(item.Value.ToString())}'");
                        }
                        break;
                    case DevExpress.XtraEditors.ColumnAutoFilterCondition.DoesNotEqual:
                        if (mGridColumn.UnboundType == DevExpress.Data.UnboundColumnType.DateTime)
                        {
                            var startOfDay = Convert.ToDateTime(item.Value.ToString()).StartOfDay();
                            builder.Append($" AND ([{item.FieldName}] < '{startOfDay.ToString("yyyy/MM/dd")}' OR [{item.FieldName}]>'{startOfDay.ToString("yyyy/MM/dd")}')");
                        }
                        else if (mGridColumn.UnboundType == DevExpress.Data.UnboundColumnType.Decimal
                            || mGridColumn.UnboundType == DevExpress.Data.UnboundColumnType.Integer
                            || mGridColumn.UnboundType == DevExpress.Data.UnboundColumnType.Boolean)
                        {
                            //Kiểu số
                            builder.Append($" AND [{item.FieldName}] <> {item.Value}");
                        }
                        else
                        {
                            //string
                            builder.Append($" AND [{item.FieldName}] <> N'{MT.Library.Utility.AddChar(item.Value.ToString())}'");
                        }
                        break;
                }

            }
            return builder.ToString();
        }


        /// <summary>
        /// Đổ dữ liệu lên grid
        /// </summary>
        /// Create by: dvthang:04.03.2017
        private void BindingDataForGrd(object dataSource)
        {
            binddingSource.DataSource = dataSource;
            this.grd.DataSource = binddingSource;
            this.totalPage = ((Int32)this.totalCount / this.PageSize) + (this.totalCount % this.PageSize == 0 ? 0 : 1);
            this.SetDisplayPageInfo();
            //Luôn mặc định row đầu tiên sẽ được select
            if (this.totalCount > 0)
            {
                this.grd.FirstView.FocusedRowHandle = 0;
                this.grd.FirstView.SelectRow(0);
            }

            if (formParent != null)
            {

                if (formParent is MFormList)
                {
                    MFormList frm = formParent as MFormList;
                }
            }
        }
        #endregion

        #region"Xử lý paging cho grid master"

        /// <summary>
        /// Thêm tham số vào store Paging
        /// </summary>
        /// <param name="param">Danh sách tham số</param>
        /// Create by: dvthang:11.03.2017
        public void AddParams(params object[] param)
        {
            this.param = param;
        }

        /// <summary>
        /// Thiết lập trang đang xem trên grid
        /// </summary>
        /// Create by: dvthang:04.03.2017
        public void SetDisplayPageInfo()
        {
            if (this.pagingControl != null)
            {
                this.pagingControl.GetMTbrPaging().SetDisplayPageInfo(this.CurrentPage, this.totalPage, (int)this.totalCount);
            }

        }

        /// <summary>
        /// Thực hiện sang trang khác xem dữ liệu
        /// </summary>
        /// Create by: dvthang:04.03.2017
        public void NextPage()
        {
            CurrentPage = CurrentPage + 1;
            if (CurrentPage > totalPage)
            {
                CurrentPage = totalPage;
                isReload = true;
            }
            else
            {
                isReload = false;
            }
        }

        /// <summary>
        /// Thực hiện về trang trước xem dữ liệu
        /// </summary>
        /// Create by: dvthang:04.03.2017
        public void PreviousPage()
        {
            CurrentPage = CurrentPage - 1;
            if (CurrentPage < 1)
            {
                CurrentPage = 1;
                start = PageSize;
                isReload = true;
            }
            else
            {
                start = PageSize * CurrentPage;
                isReload = false;
            }
        }

        /// <summary>
        /// Chuyển về trang đầu tiên
        /// </summary>
        /// Create by: dvthang:04.03.2017
        public void FirstPage()
        {
            if (CurrentPage == 1)
            {
                isReload = true;
            }
            CurrentPage = 1;
            start = 0;
        }

        /// <summary>
        /// Chuyển về trang cuối cùng
        /// </summary>
        /// Create by: dvthang:04.03.2017
        public void LastPage()
        {
            if (currentPage == totalPage)
            {
                isReload = true;
                return;
            }
            CurrentPage = totalPage;
            start = PageSize * (CurrentPage - 1);
        }

        /// <summary>
        /// Thiết lập điều kiện filter trên grid
        /// </summary>
        /// Create by: dvthang:05.03.2017
        public void SetWhere(string sWhere)
        {
            this.where = sWhere;
        }

        /// <summary>
        /// Thực hiện lọc data trên grid
        /// </summary>
        /// Create by: dvthang:05.03.2017
        public void LoadData()
        {
            this.start = 0;
            this.currentPage = 1;
            RunWorker();
        }

        /// <summary>
        /// Thực hiện export dữ liệu
        /// </summary>
        public void ExportData()
        {
            RunWorker(true);
        }

        /// <summary>
        /// Thực hiện lưu data vào excel
        /// </summary>
        private void PushDataToExcel(DataSet dataSet)
        {
            //todo
            using (IUnitOfWork unitOfWork = new MT.Library.UW.UnitOfWork(MT.Library.SessionData.ConnectString))
            {
                //0. Create Rep
                var rep = MT.Data.FactoryReport.Create(unitOfWork, $"XuatKhau_{grd.TableName}Repository" );
                if(rep==null)
                {
                    rep = new BaseReportRepository(unitOfWork);
                }    
                //1. Tạo header excel                
                var configExcel = new ConfigExcel();
                //2. Lưu dữ liệu vào excel
                string pathFileName = $@"Temp\{SysDateTime.Instance.Now().ToString("ddMMyyyyhhmmss")}.xls";

                List<HeaderTable> headerTables = new List<HeaderTable>();
                HashSet<string> hsCols = new HashSet<string>();

                Dictionary<string, string> defineColumnWithEnum = new Dictionary<string, string>();

                foreach (MGridColumn item in grd.FirstView.Columns)
                {
                    if (!item.Visible)
                    {
                        continue;
                    }
                    hsCols.Add(item.FieldName);
                    headerTables.Add(new HeaderTable { DataIndex = item.FieldName, HeaderText = item.Caption, Width = item.Width });
                    if (!string.IsNullOrWhiteSpace(item.EnumName))
                    {
                        defineColumnWithEnum.Add(item.FieldName, item.EnumName);
                    }
                }
                configExcel.DefineColumnWithEnum = defineColumnWithEnum;
                configExcel.HeaderTables = headerTables;
                configExcel.HeaderPositionIndex = 1;
                configExcel.IsFixedHeight = false;
                //Gán lại thứ tự các cột
                configExcel.ShowColumnsOrder = hsCols;
                rep.CreateExcel(pathFileName);
                var excelFile= rep.CreateReport(configExcel, pathFileName, dataSet);

                excelFile.Save(pathFileName);
                //3. Open file excel
                MTLib.Utility.OpenFile(pathFileName);
            }
        }
       
        #endregion



        #region"Event"
        /// <summary>
        /// Event Sumdata trên grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Create by: dvthang:12.03.2017
        private void FirstView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            var item = e.Item as DevExpress.XtraGrid.GridColumnSummaryItem;
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                if (item != null && this.dicSummary.ContainsKey(item.FieldName))
                {
                    e.TotalValue = this.dicSummary[item.FieldName];
                    e.TotalValueReady = true;
                }
            }
        }
        /// <summary>
        /// Gọi hàm load data cho grid
        /// </summary>
        /// <param name="sender"></param>
        /// Create by: dvthang:04.03.2017
        private void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ArgumentGrid argumentGrid = e.Argument as ArgumentGrid;
            if (argumentGrid.IsExport)
            {
                e.Result =new ResultGrid { DataSource = this.LoadPage(argumentGrid), IsExport = true };
            }
            else
            {
                e.Result = new ResultGrid { DataSource = this.LoadPage(argumentGrid), IsExport = false };
            }
           
        }

        /// <summary>
        /// Nạp data cho grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Create by: dvthang:04.03.2017
        private void worker_Completed(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.grd.FirstView.HideLoadingPanel();
            if (e.Error == null)
            {
                ResultGrid resultGrid = e.Result as ResultGrid;
                if (resultGrid.IsExport)
                {
                    var ds = resultGrid.DataSource as DataSet;
                    PushDataToExcel(ds);                    
                }
                else
                {
                    this.BindingDataForGrd(resultGrid.DataSource);
                    if (LoadDataFinish != null)
                    {
                        LoadDataFinish(sender, new EventLoadDataFinishArgs(this.binddingSource));
                    }
                }
            }
            else
            {
                MMessage.ShowError(e.Error.Message);
            }
            this.grd.MarkLoading = false;
        }

       
        /// <summary>
        /// Sử lý event cho các thay đổi số Item trên 1 trang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Create by: dvthang:05.03.2017
        private void cboShowRecord_Changed(object sender, EventArgs e)
        {
            if (sender != null)
            {
                this.isReload = false;
                if (this.pagingControl != null)
                {
                    this.pagingControl.Invoke(new Action(() =>
                      {
                          this.PageSize = this.pagingControl.GetMTbrPaging().GetPageSize();
                          this.currentPage = 1;
                          this.start = 0;
                      }));
                }
            }
            this.RunWorker();
        }

        /// <summary>
        /// Sử lý event cho các button liên quan đến phân trang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Create by: dvthang:05.03.2017
        private void btnPaging_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                MSimpleButton btn = sender as MSimpleButton;

                if (btn != null)
                {
                    switch (btn.Tag.ToString())
                    {
                        case "First":
                            this.FirstPage();
                            break;
                        case "Previous":
                            this.PreviousPage();
                            break;
                        case "Next":
                            this.NextPage();
                            break;
                        case "Last":
                            this.LastPage();
                            break;
                    }
                    this.RunWorker();
                }

            }
        }
        #endregion

        #region"Implement"
        /// <summary>
        /// The dispose method that implements IDisposable.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Tự cài đặt hàm dispose cho class
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    if (this.formParent != null)
                    {
                        formParent.Dispose();
                    }
                    if (this.binddingSource != null)
                    {
                        binddingSource.Dispose();
                    }
                    if (this.worker != null)
                    {
                        worker.Dispose();
                    }
                    if (this.pagingControl != null)
                    {
                        pagingControl.Dispose();
                    }
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }
        #endregion
    }
}
