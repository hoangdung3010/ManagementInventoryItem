using DevExpress.XtraGrid.Views.Grid;
using MT.Data.Rep;
using MT.Library;
using MTControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FormUI
{
    /// <summary>
    /// Class để phân trang cho grid
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// Create by: dvthang:05.03.2017
    public class PagingTreeList
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
        private MTreeView tree;

        /// <summary>
        /// Đối tượng grid phân trang(Sử dụng userControl)
        /// </summary>
        /// Create by: dvthang:04.03.2017
        private MTreePaging pagingControl;

        public MTreePaging PagingControl
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
        public MBindingSource BinddingSource
        {
            get { return binddingSource; }
            set { binddingSource = value; }
        }

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
        #endregion

        #region"Contructor"
        /// <summary>
        /// Hàm khởi tạo không tham số
        /// </summary>
        public PagingTreeList()
        {

            this.binddingSource = new MBindingSource();
            this.currentPage = 1;
            this.totalPage = 0;
            this.totalCount = 0;
            this.where = string.Empty;
            this.start = 0;
            this.pageSize = this.pagingControl.GetMTbrPaging().GetPageSize();
            this.IsAutoBind = true;
            this.tree = this.pagingControl.GetMTreeControl();
            this.pagingControl.GetMTbrPaging().EventHandlerPaging -= btnPaging_Click;
            this.pagingControl.GetMTbrPaging().EventHandlerPaging += btnPaging_Click;
            this.pagingControl.GetMTbrPaging().EventHandlerShowRecord -= cboShowRecord_Changed;
            this.pagingControl.GetMTbrPaging().EventHandlerShowRecord += cboShowRecord_Changed;
            
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
        ///dvthang:05.03.2017
        public PagingTreeList(MTreePaging pagingControl)
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
            this.tree = this.pagingControl.GetMTreeControl();
            this.pagingControl.GetMTbrPaging().EventHandlerPaging -= btnPaging_Click;
            this.pagingControl.GetMTbrPaging().EventHandlerPaging += btnPaging_Click;

            this.pagingControl.GetMTbrPaging().EventHandlerShowRecord -= cboShowRecord_Changed;
            this.pagingControl.GetMTbrPaging().EventHandlerShowRecord += cboShowRecord_Changed;

            ////Đăng ký event xử lý riêng cho worker
            worker = new BackgroundWorker();
            worker.DoWork -= worker_DoWork;
            worker.RunWorkerCompleted -= worker_Completed;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_Completed;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~PagingTreeList()
        {
            this.Dispose(false);
        }
        #endregion

        #region"Load Data cho grid master"
        /// <summary>
        /// Chạy thread load data
        /// </summary>
        /// Create by: dvthang:05.03.2017
        private void RunWorker()
        {
            if (!isReload && this.worker != null)
            {
                if (!this.worker.IsBusy)
                {
                    this.tree.ShowLoadingPanel();
                    this.worker.RunWorkerAsync();
                }
                
                //Đánh dấu được load
                isReload = false;
            }
        }

        /// <summary>
        /// Load data cho grid
        /// </summary>
        /// <returns>dvthang-30/07/2016</returns>
        private void LoadPage()
        {
            try
            {
                
                this.tree.Invoke(new Action(() =>
                {
                    if (PageSize > 0 && CurrentPage > 0)
                    {
                        start = (CurrentPage - 1) * PageSize;
                    }
                    else
                    {
                        start = 0;
                    }
                    Dictionary<string,object> dicSummary=new Dictionary<string,object>();
                    if (!string.IsNullOrWhiteSpace(tree.Sumary))
                    {
                        string[] colsSumary = tree.Sumary.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var item in colsSumary)
                        {
                            if (!dicSummary.ContainsKey(item.Trim()))
                            {
                                dicSummary[item.Trim()] = 0;
                            }
                        }
                    }

                    if (string.IsNullOrWhiteSpace(tree.KeyName))
                    {
                        tree.KeyName = "Id";
                    }

                    HashSet<string> colNames = new HashSet<string>()
                    {
                        tree.KeyName,"sParentId"
                    };
                    string strColumnNames = string.Empty;
                    if (string.IsNullOrWhiteSpace(columns))
                    {
                        foreach (DevExpress.XtraTreeList.Columns.TreeListColumn col in tree.Columns)
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

                    if (!string.IsNullOrWhiteSpace(tree.CustomModelFields))
                    {
                        var arrSplitCustomModelFields = tree.CustomModelFields.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        strColumnNames += "," + string.Join(",", arrSplitCustomModelFields.Select(m => $"[{m}]"));
                    }


                    var lstData = baseRepository.GetDataPaging(string.IsNullOrWhiteSpace(tree.ViewName) ? this.tree.TableName : tree.ViewName,
                        sort, start, PageSize, where, strColumnNames, ref this.totalCount, ref dicSummary);
                    binddingSource.DataSource = lstData;
                }));
            }
            catch (Exception e)
            {
                CommonFnUI.HandleException(e);
            }
        }

        /// <summary>
        /// Đổ dữ liệu lên tree
        /// </summary>
        /// Create by: dvthang:04.03.2017
        private void BindingDataForGrd()
        {
            this.tree.Invoke(new Action(() =>
            {
                this.tree.DataSource = binddingSource;
               
                this.totalPage = ((Int32)this.totalCount / this.PageSize) + (this.totalCount % this.PageSize == 0 ? 0 : 1);
                this.tree.HideLoadingPanel();
                this.SetDisplayPageInfo();
                //Luôn mặc định row đầu tiên sẽ được select
                if (this.totalCount > 0)
                {
                    this.tree.SetFirstNode();
                }
                this.tree.ExpandAll();
                if (formParent != null)
                {

                    if (formParent is MFormList)
                    {
                        MFormList frm = formParent as MFormList;
                    }
                }
            }));
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
            MMessage.ShowInfor("Tính năng đang phát triển");
        }
        #endregion

        #region"Load Data cho mà hình grid Detail theo  dòng master được chọn"
        /// <summary>
        /// Load data cho grd detail theo master
        /// </summary>
        /// <param name="grdDetail">Tên của grid Detail</param>
        /// <param name="entityName">Tên bảng hoặc view của Detail</param>
        /// Create by: dvthang:04.03.2017
        public void LoadDataGridDetail(DevExpress.XtraTab.XtraTabPage tabPage, MGridControl grdDetail, object id, string entityName)
        {
            GridView view = grdDetail.FirstView;
            view.ShowLoadingPanel();
            grdDetail.DataSource = baseRepository.GetDataTableDetailByMasterId(string.IsNullOrWhiteSpace(tree.ViewName) ? this.tree.TableName : tree.ViewName,
                $"{entityName}Id", id);
            view.HideLoadingPanel();
            tabPage.Tag = id.ToString();
        }
        #endregion

        #region"Event"

        /// <summary>
        /// Gọi hàm load data cho grid
        /// </summary>
        /// <param name="sender"></param>
        /// Create by: dvthang:04.03.2017
        private void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            this.LoadPage();
        }

        /// <summary>
        /// Nạp data cho grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Create by: dvthang:04.03.2017
        private void worker_Completed(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.BindingDataForGrd();
            if (LoadDataFinish != null)
            {
                LoadDataFinish(sender, new EventLoadDataFinishArgs(this.binddingSource));
            }
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
