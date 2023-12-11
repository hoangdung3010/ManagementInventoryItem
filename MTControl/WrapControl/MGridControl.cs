using System.ComponentModel;
using System.Drawing;
using System;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Collections;
using System.Reflection;
using Newtonsoft.Json;
using DevExpress.XtraGrid.Registrator;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using System.Linq;
using DevExpress.XtraEditors.Filtering;
using MT.Library.UW;
using MTControl.Models;
using DevExpress.Data;

namespace MTControl
{
    public class MGridControl : DevExpress.XtraGrid.GridControl
    {
        #region"Declare"
        private string decription;
        private bool isShowVerticalLine;
        private bool isShowHorizontalLine;
        private bool isShowDetailButtons;

        private bool bGotFocus;

        public bool IsShowDetailButtons
        {
            get { return isShowDetailButtons; }
            set { isShowDetailButtons = value; }
        }



        [DefaultValue(true)]
        public bool IsShowHorizontalLine
        {
            get { return isShowHorizontalLine; }
            set { isShowHorizontalLine = value; }
        }

        [DefaultValue(true)]
        public bool IsShowVerticalLine
        {
            get { return isShowVerticalLine; }
            set { isShowVerticalLine = value; }
        }
        /// <summary>
        /// Tên table lấy dữ liệu
        /// </summary>
        private string tableName;

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }


        /// <summary>
        /// Tên view lấy dữ liệu
        /// </summary>
        private string viewName;

        public string ViewName
        {
            get { return viewName; }
            set { viewName = value; }
        }


        /// <summary>
        /// Tên thuộc tính dùng để binding dữ liệu lên control
        /// </summary>
        private string setField;

        public string SetField
        {
            get { return setField; }
            set { setField = value; }
        }

        public bool _isInitAlignGrid = false;


        /// <summary>
        /// Danh sách các cột cần sumary
        /// </summary>
        private string sumary;

        public string Sumary
        {
            get { return sumary; }
            set { sumary = value; }
        }

        /// <summary>
        /// Sắp xếp dữ liệu theo tiêu chí gì
        /// </summary>
        private string sort;

        public string Sort
        {
            get { return sort; }
            set { sort = value; }
        }

        /// <summary>
        /// Overrides lại hàm gán data
        /// </summary>
        public override object DataSource
        {
            get
            {
                return base.DataSource;
            }
            set
            {
                base.DataSource = value;

                if (this.lstRowDelete != null)
                {
                    this.lstRowDelete = new List<object>();
                }
                if (!_isInitAlignGrid)
                {
                    _isInitAlignGrid = true;
                    SetDefaultAlignGrid();
                }
            }
        }


        private Dictionary<string, RepositoryItem> _cacheRepFilter = new Dictionary<string, RepositoryItem>();

        /// <summary>
        /// Có phân trang cho grid không
        /// Mặc định là không phân trang
        /// </summary>
        [DefaultValue(false)]
        private bool isShowPaging;

        public bool IsShowPaging
        {
            get { return isShowPaging; }
            set { isShowPaging = value; }
        }

        /// <summary>
        /// Danh sách tất cả columns trên grid
        /// </summary>
        private string columns;

        public string Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        /// <summary>
        /// Khóa chính của bảng
        /// </summary>
        private string keyName;

        public string KeyName
        {
            get { return keyName; }
            set { keyName = value; }
        }
        /// <summary>
        /// Có cho phép sửa trực tiếp trên grid hay không, mặc định là không
        /// </summary>
        private bool isEditable;

        public bool IsEditable
        {
            get { return isEditable; }
            set { isEditable = value; this.OnCreateControl(); }
        }

        /// <summary>
        /// Lấy về View đầu tiên của grid
        /// </summary>
        public GridView FirstView
        {
            get { return this.Views?.Count > 0 ? (GridView)this.Views.FirstOrDefault() : null; }
        }

        /// <summary>
        /// Biến để lưu thông tin grd đang ở mode nào(Xem hoặc sửa)
        /// </summary>
        private bool ModeReadOnly = true;

        private IList lstRowDelete;

        public IList LstRowDelete
        {
            get { return lstRowDelete; }
        }

        /// <summary>
        /// Đối tượng quản lý datasource của grid
        /// </summary>
        IBindingList bindingListData;

        public IBindingList BindingListData
        {
            get { return bindingListData; }
        }

        /// <summary>
        /// Phục vụ cho việc kiểm tra record nào đang ở mode sửa để lấy lên cất
        /// </summary>
        private IList lstTemp;
        private GridView gridView1;

        /// <summary>
        /// Tự gán value bằng tay nếu =true
        /// </summary>
        private bool isSetValueManual;

        public bool IsSetValueManual
        {
            get { return isSetValueManual; }
            set { isSetValueManual = value; }
        }
        private Type type = null;

        /// <summary>
        /// Mặc định sẽ thực hiện filter local
        /// </summary>
        public bool IsRemoteFilter { get; set; }

        /// <summary>
        /// Có hiển thị filter trên grid không
        /// </summary>
        public bool IsShowFilter { get; set; }

        //Bắt event custom rowcell
        private System.EventHandler<RowCellStyleEventArgs> rowCellStyle;

        public System.EventHandler<RowCellStyleEventArgs> RowCellStyle
        {
            get { return rowCellStyle; }
            set { rowCellStyle = value; }
        }

        //Bắt event filter row
        private System.EventHandler startRemoteFilterRow;

        public System.EventHandler StartRemoteFilterRow
        {
            get { return startRemoteFilterRow; }
            set { startRemoteFilterRow = value; }
        }

        //Bắt event sort tren grid
        private System.EventHandler columnSortInfoCollectionChanged;

        public System.EventHandler ColumnSortInfoCollectionChanged
        {
            get { return columnSortInfoCollectionChanged; }
            set { columnSortInfoCollectionChanged = value; }
        }


        private System.EventHandler<RowCellCustomDrawEventArgs> userCustomDrawCell;

        public System.EventHandler<RowCellCustomDrawEventArgs> UserCustomDrawCell
        {
            get { return userCustomDrawCell; }
            set { userCustomDrawCell = value; }
        }



        //Bắt event custom rowcell
        private System.EventHandler<CustomRowCellEditEventArgs> customRowCellEditing;

        public System.EventHandler<CustomRowCellEditEventArgs> CustomRowCellEditing
        {
            get { return customRowCellEditing; }
            set { customRowCellEditing = value; }
        }

        /// <summary>
        /// Hàm thực hiện custom lại dữ liệu trước khi add dòng vào grid
        /// </summary>
        public Func<object, MGridControl, bool> FuncCustomRecordBeforeAddRow
        {
            get; set;
        }
        /// <summary>
        /// Danh sách các field không được edit. cách nhau bởi dấu |
        /// </summary>
        public string DisableFieldNames { get; set; }

        ContextMenuStrip _contextMenuStrip = null;

        /// <summary>
        /// Danh sách thuộc tính của model cần lấy về thêm, cách nhau bởi dấu ","
        /// </summary>
        public string CustomModelFields { get; set; }

        /// <summary>
        /// Thực hiện validate trước khi gán giá trị cho cell của grid
        /// </summary>
        public Func<DevExpress.XtraGrid.Columns.GridColumn, ChangingEventArgs, bool> ValidEditValueChanging { get; set; }

        public bool IsHideActionAdd { get; set; }

        /// <summary>
        /// Đánh dấu là đang loading
        /// </summary>
        public bool MarkLoading { get; set; }

        /// <summary>
        /// Bộ lọc của grid
        /// </summary>
        public List<FilterObject> FilterObjects { get; set; }
        #endregion

        #region"Contructor"
        public MGridControl()
        {

            this.CreateInstanceBindingList();
        }

        #endregion
        #region"Sub/Func"
        /// <summary>
        /// Lấy về giá trị khóa chính của table
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="primaryKeyName"></param>
        /// Create by: dvthang:08.03.2017
        public T GetValueByRowSelected<T>(string primaryKeyName)
        {
            T id = default(T);
            GridView view = this.FirstView;
            if (view.GetSelectedRows().Length > 0)
            {
                id = (T)view.GetRowCellValue(view.GetSelectedRows()[0], primaryKeyName);
            }
            return id;
        }

        /// <summary>
        /// Lấy về giá trị khóa chính của table
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="primaryKeyName"></param>
        /// Create by: dvthang:08.03.2017
        public T GetRecordByRowSelected<T>()
        {
            T data = default(T);
            GridView view = this.FirstView;
            if (view.FocusedRowHandle > -1)
            {
                data = (T)view.GetRow(view.FocusedRowHandle);
            }
            return data;
        }

        /// <summary>
        /// Lấy về giá trị khóa chính của table
        /// </summary>
        /// Create by: dvthang:08.03.2017
        public List<T> GetListRecordByRowsSelected<T>()
        {
            List<T> lstData = new List<T>();
            GridView view = this.FirstView;
            int[] lstIndex = view.GetSelectedRows();
            for (int i = 0; i < view.SelectedRowsCount; i++)
            {
                if (lstIndex[i] >= 0)
                {
                    lstData.Add((T)view.GetRow(lstIndex[i]));
                }
            }
            return lstData;
        }

        /// <summary>
        /// Add column vào grid
        /// </summary>
        /// <param name="column">Column của grid</param>
        /// Create by: dvthang:04.03.2017
        public MGridColumn AddColumn(MGridColumn column)
        {
            if (column != null)
            {
                this.FirstView.Columns.Add(column);
            }
            return column;
        }

        /// <summary>
        /// Thực hiện lưu lại các bản ghi bị xóa
        /// </summary>
        public void SaveRecordDelete(IList deleteItems)
        {
            if (this.lstRowDelete == null)
            {
                this.lstRowDelete = new List<object>();
            }
            foreach (var item in deleteItems)
            {
                this.lstRowDelete.Add(item);
            }
        }

        /// <summary>
        /// Add column dạng text vào grid
        /// </summary>
        /// <param name="grd">Tên grid</param>
        /// <param name="fieldName">Tên cột</param>
        /// <param name="caption">Tiêu đề cột</param>
        /// <param name="width">Độ rộng cột</param>
        /// dvthang-08.07.2016
        public MGridColumn AddColumnText(string fieldName, string caption, int width = 50,
            int visibleIndex = -1, DataTypeColumn dataType = DataTypeColumn.None, bool isFixWidth = false,
            FixedStyle fixedStyle = FixedStyle.None, bool isRequired = false, int maxLength = 0, string enumName = "")
        {
            MGridColumn col = new MGridColumn();
            col.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            col.FieldName = fieldName;
            col.Caption = caption;
            col.Visible = true;
            col.Fixed = fixedStyle;
            col.IsRequired = isRequired;
            col.MaxLength = maxLength;
            col.OptionsColumn.FixedWidth = isFixWidth;
            if (!string.IsNullOrWhiteSpace(enumName))
            {
                col.EnumName = enumName;
            }
            if (visibleIndex > -1)
            {
                col.VisibleIndex = visibleIndex;
            }
            if (this.FirstView.Editable)
            {
                RepositoryItem repositoryItem;
                switch (dataType)
                {
                    case DataTypeColumn.MemoEdit:
                        col.UnboundType = DevExpress.Data.UnboundColumnType.String;
                        break;
                    case DataTypeColumn.SpinEdit:
                        repositoryItem = new MRepositorySpinEdit
                        {
                            GridMaster = this,
                            IsRequired = isRequired,
                            FieldName = fieldName,
                            IsOrigin = true
                        };
                        col.ColumnEdit = repositoryItem;

                        col.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                        col.RepName = typeof(MRepositorySpinEdit).Name;
                        col.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                        this.RepositoryItems.Add(repositoryItem);
                        break;
                    case DataTypeColumn.TimeEdit:
                        repositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
                        col.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                        col.ColumnEdit = repositoryItem;
                        this.RepositoryItems.Add(repositoryItem);
                        col.RepName = typeof(RepositoryItemTimeEdit).Name;
                        col.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
                        break;
                    case DataTypeColumn.DateEdit:
                        repositoryItem = new MRepositoryDateEdit
                        {
                            GridMaster = this,
                            IsRequired = isRequired,
                            FieldName = fieldName,
                            AutoHeight = true,
                            IsOrigin = true
                        };
                        col.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                        col.ColumnEdit = repositoryItem;
                        col.RepName = typeof(MRepositoryDateEdit).Name;
                        col.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
                        this.RepositoryItems.Add(repositoryItem);
                        break;
                    case DataTypeColumn.ComboBox:
                        repositoryItem = new MRepositoryComboBox
                        {
                            GridMaster = this,
                            IsRequired = isRequired,
                            AutoHeight = true,
                            FieldName = fieldName,
                            IsOrigin = true,
                            EnumData = enumName
                        };
                        col.RepName = typeof(MRepositoryComboBox).Name;
                        col.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                        col.ColumnEdit = repositoryItem;
                        col.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                        this.RepositoryItems.Add(repositoryItem);
                        break;
                    case DataTypeColumn.GridLookUpEdit:
                        repositoryItem = new MRepositoryItemGridLookUpEdit
                        {
                            GridMaster = this,
                            IsRequired = isRequired,
                            FieldName = fieldName,
                            IsOrigin = true

                        };
                        col.RepName = typeof(MRepositoryItemGridLookUpEdit).Name;
                        col.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                        col.ColumnEdit = repositoryItem;
                        col.UnboundType = DevExpress.Data.UnboundColumnType.String;
                        this.RepositoryItems.Add(repositoryItem);
                        break;
                    case DataTypeColumn.HyperLinkEdit:
                        repositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
                        col.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
                        col.ColumnEdit = repositoryItem;
                        col.RepName = typeof(RepositoryItemHyperLinkEdit).Name;
                        col.UnboundType = DevExpress.Data.UnboundColumnType.String;
                        this.RepositoryItems.Add(repositoryItem);
                        break;
                    case DataTypeColumn.LookUpEdit:
                        repositoryItem = new MRepositoryItemLookUpEdit
                        {
                            GridMaster = this,
                            IsRequired = isRequired,
                            FieldName = fieldName,
                            IsOrigin = true,
                            EnumData = enumName
                        };
                        col.RepName = typeof(MRepositoryItemLookUpEdit).Name;
                        col.ColumnEdit = repositoryItem;
                        col.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                        col.UnboundType = DevExpress.Data.UnboundColumnType.String;
                        this.RepositoryItems.Add(repositoryItem);
                        break;
                    case DataTypeColumn.CheckedComboBox:
                        repositoryItem = new MRepositoryItemCheckedComboBox
                        {
                            GridMaster = this,
                            IsRequired = isRequired,
                            FieldName = fieldName,
                            IsOrigin = true
                        };
                        col.RepName = typeof(MRepositoryItemCheckedComboBox).Name;
                        col.ColumnEdit = repositoryItem;
                        col.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                        col.UnboundType = DevExpress.Data.UnboundColumnType.String;
                        this.RepositoryItems.Add(repositoryItem);
                        break;
                    case DataTypeColumn.ImageComboBox:
                        col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                        col.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                        break;
                    case DataTypeColumn.TreeLookUpEdit:
                        repositoryItem = new MRepositoryItemTreeLookUpEdit
                        {
                            GridMaster = this,
                            IsRequired = isRequired,
                            FieldName = fieldName,
                            IsOrigin = true
                        };
                        col.RepName = typeof(MRepositoryItemTreeLookUpEdit).Name;
                        col.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                        col.ColumnEdit = repositoryItem;
                        col.UnboundType = DevExpress.Data.UnboundColumnType.String;
                        this.RepositoryItems.Add(repositoryItem);
                        break;
                    default:
                        if (dataType != DataTypeColumn.Button)
                        {
                            repositoryItem = new MRepositoryTextEdit
                            {
                                GridMaster = this,
                                MaxLength = maxLength,
                                FieldName = fieldName,
                                IsOrigin = true
                            };
                            col.RepName = typeof(MRepositoryTextEdit).Name;
                            col.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
                            col.ColumnEdit = repositoryItem;

                            this.RepositoryItems.Add(repositoryItem);
                        }
                        break;
                }
            }

            if (dataType == DataTypeColumn.Button)
            {
                var repositoryItemButtonEdit = new MRepositoryItemButtonEdit();
                col.ColumnEdit = repositoryItemButtonEdit;
                col.AppearanceCell.Options.HighPriority = true;
                repositoryItemButtonEdit.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                repositoryItemButtonEdit.Appearance.TextOptions.VAlignment = VertAlignment.Center;
                col.OptionsColumn.AllowEdit = false;
                this.RepositoryItems.Add(repositoryItemButtonEdit);
            }

            if (width > 0)
            {
                col.OptionsColumn.FixedWidth = true;
                col.Width = width;
            }
            else
            {
                col.BestFit();
            }

            if (!string.IsNullOrWhiteSpace(DisableFieldNames))
            {

                string[] fieldNames = DisableFieldNames.ToLower().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (fieldNames.Contains(col.FieldName.ToLower()))
                {
                    col.OptionsColumn.AllowEdit = false;
                    col.OptionsColumn.ReadOnly = true;
                    col.AppearanceCell.BackColor = MColor.BackColorDisable;
                    col.AppearanceCell.BackColor2 = MColor.BackColorDisable;
                    col.AppearanceHeader.BackColor = MColor.BackColorDisable;
                    col.AppearanceHeader.BackColor2 = MColor.BackColorDisable;
                }
            }

            this.FirstView.Columns.Add(col);
            return col;
        }

        /// <summary>
        /// Add column dạng text vào grid
        /// </summary>
        /// <param name="grd">Tên grid</param>
        /// <param name="fieldName">Tên cột</param>
        /// <param name="caption">Tiêu đề cột</param>
        /// <param name="width">Độ rộng cột</param>
        /// dvthang-08.07.2016
        public MGridColumn AddColumnText(string fieldName, string caption, string toolTip,
            int width = 50, int visibleIndex = -1, DataTypeColumn dataType = DataTypeColumn.None,
             bool isFixWidth = false, FixedStyle fixedStyle = FixedStyle.None,
             bool isRequired = false, int maxLength = 0, string enumName = "")
        {
            MGridColumn col = this.AddColumnText(fieldName, caption, width, visibleIndex, dataType, isFixWidth, fixedStyle, isRequired, maxLength, enumName);
            col.ToolTip = toolTip;
            return col;
        }
        /// <summary>
        /// Add column dạng text vào grid
        /// </summary>
        /// <param name="grd">Tên grid</param>
        /// <param name="fieldName">Tên cột</param>
        /// <param name="caption">Tiêu đề cột</param>
        /// <param name="width">Độ rộng cột</param>
        /// dvthang-08.07.2016
        public MGridColumn AddColumnTextWithFormat(string fieldName, string caption, string toolTip, int width = 50,
            int visibleIndex = -1, DataTypeColumn dataType = DataTypeColumn.None, int edit = -1,
            bool isFixWidth = false, FixedStyle fixedStyle = FixedStyle.None)
        {
            MGridColumn col = this.AddColumnText(fieldName, caption, width, visibleIndex, dataType, isFixWidth, fixedStyle);
            if (edit > -1)
            {
                col.OptionsColumn.ReadOnly = false;
            }
            else
            {
                col.OptionsColumn.ReadOnly = true;
            }
            //
            col.ToolTip = toolTip;
            return col;
        }
        /// <summary>
        /// Xóa tất cả các column trên grid
        /// </summary>
        /// Create by: dvthang:19.03.2017
        public void ClearAllColumn()
        {
            GridView view = this.FirstView;
            if (view != null)
            {
                this.RepositoryItems.Clear();
                view.Columns.Clear();
            }
        }

        /// <summary>
        /// THiết lập chế độ mutiselect row
        /// </summary>
        /// <param name="isMutiSelect">=true thì là Mutiselect, ngược lại chỉ select 1 row</param>
        /// Create by: dvthang:19.03.2017
        public void SetMutiSelectRows(bool isMutiSelect, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode selectMode = GridMultiSelectMode.RowSelect)
        {
            GridView view = this.FirstView;
            if (view != null)
            {
                view.OptionsSelection.MultiSelect = isMutiSelect;
                view.OptionsSelection.MultiSelectMode = selectMode;
            }
        }



        /// <summary>
        /// Gán datasource cho grid
        /// </summary>
        /// <param name="lstObject"></param>
        public void LoadData(IList lstObject, bool isNewInstance = true)
        {
            this.lstTemp = lstObject;
            this.CreateInstanceBindingList(isNewInstance);
            if (lstObject != null)
            {
                foreach (var item in lstObject)
                {
                    if (this.type == null)
                    {
                        this.type = item.GetType();
                    }
                    int entityState = (int)MCommon.GetValueObject(item, "MTEntityState");
                    if (this.type != null && entityState != (int)MTControl.FormAction.Delete)
                    {
                        MethodInfo method = this.type.GetMethod("Clone");

                        if (method != null)
                        {
                            var cloneData = method.Invoke(item, null);
                            this.bindingListData.Add(cloneData);
                        }
                    }
                }
            }
            else
            {
                if (this.bindingListData != null)
                {
                    //Xóa hết các đối tượng cũ đi
                    this.bindingListData.Clear();
                }

            }
            this.DataSource = this.bindingListData;
        }

        /// <summary>
        /// Lấy về tất cả dữ liệu trên grid
        /// </summary>
        /// <returns></returns>
        public IList GetAllData()
        {
            IList datas = new List<object>();
            if (this.bindingListData != null)
            {
                int i = 0;
                foreach (var record in this.bindingListData)
                {
                    //Nếu mà thằng cuối cùng và mã vạch trống thì bỏ qua không lấy
                    if (i == this.bindingListData.Count - 1)
                    {
                        if (MCommon.ExistsProperty(record, "sMaVach"))
                        {
                            var sMaVach = MCommon.GetValueObject(record, "sMaVach");
                            if (sMaVach == null || string.IsNullOrWhiteSpace(sMaVach.ToString()))
                            {
                                continue;
                            }
                        }
                    }

                    MCommon.SetValue(record, "RowHandle", i);
                    datas.Add(record);
                    i++;
                }
            }
            return datas;
        }

        /// <summary>
        /// Lấy về tất cả dữ liệu trên grid
        /// </summary>
        /// <returns></returns>
        public List<T> GetAllData<T>()
        {
            List<T> datasClone = new List<T>();
            IList datasOrigin = this.DataSource as IList;
            if (datasOrigin != null)
            {
                int i = 0;
                foreach (var record in datasOrigin)
                {
                    //Nếu mà thằng cuối cùng và mã vạch trống thì bỏ qua không lấy
                    if (i == datasOrigin.Count - 1)
                    {
                        if (MCommon.ExistsProperty(record, "sMaVach"))
                        {
                            var sMaVach = MCommon.GetValueObject(record, "sMaVach");
                            if (sMaVach == null || string.IsNullOrWhiteSpace(sMaVach.ToString()))
                            {
                                continue;
                            }
                        }
                    }

                    MCommon.SetValue(record, "RowHandle", i);
                    datasClone.Add((T)record);
                    i++;
                }
            }
            return datasClone;
        }

        /// <summary>
        /// Lấy về toàn bộ các row thay đổi trên grid
        /// </summary>
        /// <returns></returns>
        public IList GetDataChanges()
        {
            IList lst = new List<object>();
            if (this.bindingListData != null)
            {
                int i = 0;
                foreach (var record in this.bindingListData)
                {
                    //Bản ghi cuối cùng và có mã vạch trống thì bỏ không lấy
                    if (i == this.bindingListData.Count - 1)
                    {
                        if(MCommon.ExistsProperty(record, "sMaVach"))
                        {
                            var sMaVach = MCommon.GetValueObject(record, "sMaVach");
                            if (sMaVach == null || string.IsNullOrWhiteSpace(sMaVach.ToString()))
                            {
                                continue;
                            }
                        }
                    }
                    int entityState = (int)MCommon.GetValueObject(record, "MTEntityState");
                    if (entityState == (int)MTControl.FormAction.Add || entityState == (int)MTControl.FormAction.Edit)
                    {
                        MCommon.SetValue(record, "RowHandle", i);
                        lst.Add(record);
                    }
                    else if (this.lstTemp != null && entityState == (int)MTControl.FormAction.None)
                    {
                        var id = MCommon.GetIdentity(record);
                        foreach (var recordTemp in this.lstTemp)
                        {
                            var idOther = MCommon.GetIdentity(recordTemp);
                            if (object.Equals(id, idOther) && !MCommon.CompareObject(recordTemp, record))
                            {
                                MCommon.SetValue(record, "MTEntityState", (int)MTControl.FormAction.Edit);
                                MCommon.SetValue(record, "RowHandle", i);
                                lst.Add(record);
                                break;
                            }
                        }
                    }

                    MCommon.SetValue(record, "SortOrder", (i + 1));
                    i++;
                }
                //Cật nhật những record đã bị xóa
                if (lstRowDelete != null)
                {
                    foreach (var record in lstRowDelete)
                    {
                        MCommon.SetValue(record, "MTEntityState", (int)MTControl.FormAction.Delete);
                        lst.Add(record);
                    }
                }
            }
            return lst;
        }


        /// <summary>
        /// Lấy về toàn bộ các row thay đổi trên grid
        /// </summary>
        /// <returns></returns>
        public List<T> GetDataChanges<T>()
        {
            List<T> lst = new List<T>();
            if (this.bindingListData != null)
            {
                int i = 0;
                foreach (var record in this.bindingListData)
                {
                    //Bản ghi cuối cùng và có mã vạch trống thì bỏ không lấy
                    if (i == this.bindingListData.Count - 1)
                    {
                        if (MCommon.ExistsProperty(record, "sMaVach"))
                        {
                            var sMaVach = MCommon.GetValueObject(record, "sMaVach");
                            if (sMaVach == null || string.IsNullOrWhiteSpace(sMaVach.ToString()))
                            {
                                continue;
                            }
                        }
                    }
                    MCommon.SetValue(record, "SortOrder", (i + 1));
                    int entityState = (int)MCommon.GetValueObject(record, "MTEntityState");
                    if (entityState == (int)MTControl.FormAction.Add || entityState == (int)MTControl.FormAction.Edit)
                    {
                        lst.Add((T)record);
                    }
                    else if (this.lstTemp != null && entityState == (int)MTControl.FormAction.None)
                    {
                        var id = MCommon.GetIdentity(record);
                        foreach (var recordTemp in this.lstTemp)
                        {
                            var idOther = MCommon.GetIdentity(recordTemp);
                            if (object.Equals(id, idOther) && !MCommon.CompareObject(recordTemp, record))
                            {
                                MCommon.SetValue(record, "MTEntityState", (int)MTControl.FormAction.Edit);
                                lst.Add((T)record);
                                break;
                            }
                        }
                    }

                    i++;
                }
                //Cật nhật những record đã bị xóa
                if (lstRowDelete != null)
                {
                    foreach (var record in lstRowDelete)
                    {
                        MCommon.SetValue(record, "MTEntityState", (int)MTControl.FormAction.Delete);
                        lst.Add((T)record);
                    }
                }
            }
            return lst;
        }

        /// <summary>
        /// Tạo thể hiện của binddingsource
        /// </summary>
        private void CreateInstanceBindingList(bool isNewInstance = false/*Nếu giá trị =true thì luôn luôn khởi tạo object*/)
        {
            if (!string.IsNullOrEmpty(this.tableName) && (isNewInstance || this.bindingListData == null))
            {
                string asseblyModels = MCommon.AssemblyNameModels;
                MCommon.SetAssemblyModels();
                Type type = MCommon.AssemblyModels.GetType(string.Format("{0}.BO.{1}", asseblyModels, this.TableName));
                if (type != null)
                {
                    Type listType = typeof(BindingList<>).MakeGenericType(new[] { type });
                    this.bindingListData = (IBindingList)Activator.CreateInstance(listType);
                }
            }
        }

        /// <summary>
        /// Căn chỉnh các cột trên grid theo đúng kiểu dữ liệu
        /// </summary>
        protected virtual void SetDefaultStyleGrid()
        {

            if (this.Views.Count > 0)
            {
                foreach (DevExpress.XtraGrid.Views.Grid.GridView vView in this.Views)
                {

                    if (!this.IsShowDetailButtons)
                    {
                        vView.OptionsView.ShowDetailButtons = false;
                    }
                    //Màu nền của header
                    vView.Appearance.HeaderPanel.BackColor = MColor.HeaderGridBackColor;
                    vView.Appearance.HeaderPanel.BackColor2 = MColor.HeaderGridBackColor;
                    vView.Appearance.HeaderPanel.BorderColor = MColor.BorderHeaderGridColor;


                    //Thiết lập màu active row khi focus vào các control khác
                    vView.Appearance.HideSelectionRow.Options.UseBackColor = true;
                    vView.Appearance.HideSelectionRow.Options.UseFont = true;
                    vView.Appearance.HideSelectionRow.Options.UseForeColor = true;
                    vView.Appearance.HideSelectionRow.Options.UseBorderColor = true;
                    vView.Appearance.HideSelectionRow.BackColor = MColor.FocusBackColor;
                    vView.Appearance.HideSelectionRow.BackColor2 = MColor.FocusBackColor;
                    vView.Appearance.HideSelectionRow.ForeColor = Color.Black;

                    //Set style cho các dòng chẵn lẻ
                    vView.Appearance.EvenRow.Options.UseBackColor = true;
                    vView.Appearance.EvenRow.Options.UseFont = true;
                    vView.Appearance.EvenRow.Options.UseForeColor = true;
                    vView.Appearance.EvenRow.Options.UseBorderColor = true;
                    vView.Appearance.EvenRow.BackColor = MColor.GridEvenRowBackColor;
                    vView.Appearance.EvenRow.BackColor2 = MColor.GridEvenRowBackColor;
                    vView.Appearance.EvenRow.ForeColor = Color.Black;

                    vView.Appearance.OddRow.Options.UseBackColor = true;
                    vView.Appearance.OddRow.Options.UseFont = true;
                    vView.Appearance.OddRow.Options.UseForeColor = true;
                    vView.Appearance.OddRow.Options.UseBorderColor = true;
                    vView.Appearance.OddRow.BackColor = MColor.GridOldRowBackColor;
                    vView.Appearance.OddRow.BackColor2 = MColor.GridOldRowBackColor;
                    vView.Appearance.OddRow.ForeColor = Color.Black;

                    //Không hiển thì khung hình chữ nhật viền chấm chấm khi focus
                    vView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
                    //Thiết lập khoảng cách từ border đến nội dung các cell
                    vView.UserCellPadding = new System.Windows.Forms.Padding(0);
                    //Thiết lập không cho di chuyển cột trên grid
                    vView.OptionsCustomization.AllowColumnMoving = false;
                    //Không cho phép sort trên grid
                    vView.OptionsCustomization.AllowSort = !this.IsEditable;
                    //Không hiển thị control fillter trên grid
                    vView.OptionsCustomization.AllowFilter = false;
                    //Không cho phép chỉnh sửa kích thước form
                    vView.OptionsCustomization.AllowRowSizing = false;
                    //Enable style cho các dòng chẵn lẻ
                    vView.OptionsView.EnableAppearanceEvenRow = true;
                    vView.OptionsView.EnableAppearanceOddRow = true;
                    //Không hiển thị menu trên column khi nhấn chuột phải
                    vView.OptionsMenu.EnableColumnMenu = !this.IsEditable;
                    //Không cho hiển thị panel tìm kiếm (Người dùng nhấn control F)
                    vView.OptionsFind.AllowFindPanel = false;

                    vView.Appearance.Row.Font = new System.Drawing.Font(MFont.mscSysFontName, MSize.mscSysFontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                    vView.Appearance.GroupRow.Font = new System.Drawing.Font(MFont.mscSysFontName, MSize.mscSysFontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                    vView.Appearance.HeaderPanel.Font = new System.Drawing.Font(MFont.mscSysFontName, MSize.mscSysFontSizeHeaderGrid, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);

                    vView.OptionsView.ShowGroupPanel = false;

                    // Make the grid read-only.
                    vView.OptionsBehavior.Editable = false;
                    // Prevent the focused cell from being highlighted.
                    vView.OptionsSelection.EnableAppearanceFocusedCell = true;
                    vView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus;
                    if (this.IsEditable)
                    {
                        vView.OptionsBehavior.ReadOnly = false;
                        vView.OptionsBehavior.Editable = true;
                        vView.OptionsSelection.EnableAppearanceFocusedCell = true;
                        vView.OptionsSelection.MultiSelect = false;
                        vView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
                    }
                    else
                    {
                        vView.OptionsBehavior.ReadOnly = true;
                        vView.OptionsBehavior.Editable = false;

                        vView.Appearance.Row.BackColor = Color.White;
                        vView.Appearance.Row.BackColor2 = Color.White;
                        vView.Appearance.Row.ForeColor = System.Drawing.Color.Black;

                        //Thiết lập màu nền khi focus vào Cell
                        vView.Appearance.FocusedCell.BackColor = MColor.FocusBackColor;
                        vView.Appearance.FocusedCell.BackColor2 = MColor.FocusBackColor;
                        vView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
                        // Draw a dotted focus rectangle around the entire row.
                        //Thiết lập màu nền khi foucus vào row
                        vView.Appearance.FocusedRow.BackColor = MColor.FocusBackColor;
                        vView.Appearance.FocusedRow.BackColor2 = MColor.FocusBackColor;
                        vView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
        }

        /// <summary>
        /// Căn chỉnh vị trí các text trong column grid(Giữa, trái , phải)
        /// </summary>
        protected void SetDefaultAlignGrid()
        {

            List<string> lstColumns = new List<string>();
            if (this.Views.Count > 0)
            {
                foreach (DevExpress.XtraGrid.Views.Grid.GridView vView in this.Views)
                {
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in vView.Columns)
                    {
                        MGridColumn mGridColumn = (MGridColumn)col;
                        if (this.IsShowPaging)
                        {
                            mGridColumn.SortMode = ColumnSortMode.Custom;
                        }
                        lstColumns.Add(col.FieldName);
                        Type t = col.ColumnType;
                        if (col.FieldName == "STT" || col.FieldName == "Rownum")
                        {
                            col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            col.OptionsFilter.AllowFilter = false;
                            continue;
                        }
                        if (t.Equals(typeof(string)) || t.Equals(typeof(String)))
                        {
                            //Căn trái dữ liệu
                            col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                            col.UnboundType = DevExpress.Data.UnboundColumnType.String;
                            if (this.IsShowFilter && col.OptionsFilter.AllowFilter)
                            {
                                col.OptionsFilter.AllowAutoFilter = true;
                                col.OptionsFilter.ImmediateUpdateAutoFilter = false;
                                if (mGridColumn.FilterEditor != null && mGridColumn.FilterEditor.DataType != DataTypeColumn.None)
                                {
                                    col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
                                }
                                else
                                {
                                    col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                                }

                            }

                        }
                        else if (t.Equals(typeof(DateTime)) || t.Equals(typeof(DateTime?)))
                        {
                            //Căn Giữa dữ liệu
                            col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            col.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            col.DisplayFormat.FormatString = "dd/MM/yyyy";
                            if (this.IsShowFilter && col.OptionsFilter.AllowFilter)
                            {

                                col.OptionsFilter.AllowAutoFilter = true;
                                col.OptionsFilter.ImmediateUpdateAutoFilter = false;
                                col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
                            }
                        }
                        else if (t.Equals(typeof(Decimal)) || t.Equals(typeof(Decimal?)))
                        {
                            //Căn Phải dữ liệu
                            col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                            col.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                            if (this.IsShowFilter && col.OptionsFilter.AllowFilter)
                            {
                                col.OptionsFilter.AllowAutoFilter = false;
                                col.OptionsFilter.ImmediateUpdateAutoFilter = false;
                                col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
                            }
                        }
                        else if (t.Equals(typeof(Int32)) || t.Equals(typeof(Int32?)))
                        {
                            //Căn Phải dữ liệu
                            if (string.IsNullOrWhiteSpace(((MGridColumn)col).EnumName))
                            {
                                col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                            }
                            else
                            {
                                col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                            }

                            col.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                            if (this.IsShowFilter && col.OptionsFilter.AllowFilter)
                            {
                                col.OptionsFilter.AllowAutoFilter = true;
                                col.OptionsFilter.ImmediateUpdateAutoFilter = false;
                                col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
                            }
                        }
                        else if (t.Equals(typeof(float)) || t.Equals(typeof(float?)))
                        {
                            //Căn Phải dữ liệu
                            col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                            col.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                            if (this.IsShowFilter && col.OptionsFilter.AllowFilter)
                            {
                                col.OptionsFilter.AllowAutoFilter = true;
                                col.OptionsFilter.ImmediateUpdateAutoFilter = false;
                                col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
                            }
                        }
                        else if (t.Equals(typeof(decimal)) || t.Equals(typeof(decimal?)))
                        {
                            //Căn Phải dữ liệu
                            col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                            col.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                            if (this.IsShowFilter && col.OptionsFilter.AllowFilter)
                            {
                                col.OptionsFilter.AllowAutoFilter = true;
                                col.OptionsFilter.ImmediateUpdateAutoFilter = false;
                                col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
                            }
                        }

                        else if (t.Equals(typeof(int)) || t.Equals(typeof(int?)))
                        {
                            //Căn Phải dữ liệu
                            if (string.IsNullOrWhiteSpace(((MGridColumn)col).EnumName))
                            {
                                col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                            }
                            else
                            {
                                col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                            }
                            col.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
                            if (this.IsShowFilter && col.OptionsFilter.AllowFilter)
                            {
                                col.OptionsFilter.AllowAutoFilter = true;
                                col.OptionsFilter.ImmediateUpdateAutoFilter = false;
                                col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
                            }
                        }

                        //Định dạng hiển thị trên grid
                        SetDisplayFormatForColumn(col);
                        //Căn giữa header
                        col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        if (!col.OptionsColumn.AllowEdit)
                        {
                            col.AppearanceCell.BackColor = MColor.BackColorDisable;
                        }
                    }

                    if (!this.IsShowPaging && !this.isEditable)
                    {
                        if (vView.Columns.Count > 0)
                        {
                            var col = vView.Columns[0];
                            col.SummaryItem.DisplayFormat = "Tổng = {0} bản ghi";
                            col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                            vView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                            vView.OptionsView.ShowFooter = true;
                        }
                    }

                }
            }
            if (!string.IsNullOrEmpty(this.KeyName))
            {
                lstColumns.Add(this.KeyName);
            }
            if (string.IsNullOrEmpty(this.columns))
            {
                this.columns = string.Join(",", lstColumns);
            }
        }

        /// <summary>
        /// Đăng ký event show form QuichSearch hoặc form danh mục thêm nhanh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Create by: dvthang:16.10.2016
        private void ShowForm(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton button = e.Button;
            if (button != null && button.Tag != null)
            {
                MFormBase frm = null;
                string tab = Convert.ToString(button.Tag);
                string[] arrTab = tab.Split(new char[1] { '_' }, StringSplitOptions.RemoveEmptyEntries);

                switch (arrTab[0])
                {
                    case "QuickSearch":
                        frm = MCommon.FindFormByName(arrTab[1]);
                        if (frm != null)
                        {
                            frm.ControlCallForm = this;
                            frm.Show();
                        }
                        break;
                    case "AddDictionnary":
                        frm = MCommon.FindFormByName(arrTab[1]);
                        if (frm != null)
                        {
                            frm.ControlCallForm = this;
                            frm.Show();
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Định dạng kiểu hiển thị của column trên grid
        /// </summary>
        /// <param name="column">Column của grid</param>
        private void SetDisplayFormatForColumn(GridColumn column)
        {
            try
            {
                string fieldName = column.FieldName;
                FormatType dataType = FormatType.QuanlityInt;
                if (!string.IsNullOrEmpty(fieldName))
                {
                    if (fieldName.StartsWith("iSL", StringComparison.OrdinalIgnoreCase)
                        || fieldName.StartsWith("iSoLuong", StringComparison.OrdinalIgnoreCase))
                    {
                        dataType = FormatType.QuanlityFloat;
                        column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        column.DisplayFormat.FormatString = MCommon.GetFormatStringCustom(dataType);
                        if (this.IsShowFilter && column.OptionsFilter.AllowFilter)
                        {

                            column.OptionsFilter.AllowAutoFilter = true;
                            column.OptionsFilter.ImmediateUpdateAutoFilter = false;
                            column.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
                        }
                    }
                    else if (fieldName.StartsWith("rSL", StringComparison.OrdinalIgnoreCase)
                        || fieldName.StartsWith("rSoLuong", StringComparison.OrdinalIgnoreCase))
                    {
                        dataType = FormatType.QuanlityFloat;
                        column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        column.DisplayFormat.FormatString = MCommon.GetFormatStringCustom(dataType);
                        if (this.IsShowFilter && column.OptionsFilter.AllowFilter)
                        {

                            column.OptionsFilter.AllowAutoFilter = true;
                            column.OptionsFilter.ImmediateUpdateAutoFilter = false;
                            column.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
                        }
                    }
                    else if (fieldName.StartsWith("rDG", StringComparison.OrdinalIgnoreCase)
                        || fieldName.StartsWith("rDonGia", StringComparison.OrdinalIgnoreCase))
                    {
                        column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        dataType = FormatType.UnitPrice;
                        column.DisplayFormat.FormatString = MCommon.GetFormatStringCustom(dataType);
                        if (this.IsShowFilter && column.OptionsFilter.AllowFilter)
                        {

                            column.OptionsFilter.AllowAutoFilter = true;
                            column.OptionsFilter.ImmediateUpdateAutoFilter = false;
                            column.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
                        }
                    }
                    else if (fieldName.StartsWith("rTT", StringComparison.OrdinalIgnoreCase)
                        || fieldName.StartsWith("rThanhTien", StringComparison.OrdinalIgnoreCase))
                    {
                        column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        dataType = FormatType.Amount;
                        column.DisplayFormat.FormatString = MCommon.GetFormatStringCustom(dataType);
                        if (this.IsShowFilter && column.OptionsFilter.AllowFilter)
                        {
                            column.OptionsFilter.AllowAutoFilter = true;
                            column.OptionsFilter.ImmediateUpdateAutoFilter = false;
                            column.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
                        }
                    }
                    else if (fieldName.StartsWith("rTL", StringComparison.OrdinalIgnoreCase)
                        || fieldName.StartsWith("rTyLe", StringComparison.OrdinalIgnoreCase))
                    {
                        column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        dataType = FormatType.Coefficient;
                        column.DisplayFormat.FormatString = MCommon.GetFormatStringCustom(dataType);
                        if (this.IsShowFilter && column.OptionsFilter.AllowFilter)
                        {

                            column.OptionsFilter.AllowAutoFilter = true;
                            column.OptionsFilter.ImmediateUpdateAutoFilter = false;
                            column.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
                        }
                    }
                    else if (fieldName.StartsWith("iNam", StringComparison.OrdinalIgnoreCase))
                    {
                        column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        dataType = FormatType.Year;
                        column.DisplayFormat.FormatString = MCommon.GetFormatStringCustom(dataType);
                        if (this.IsShowFilter && column.OptionsFilter.AllowFilter)
                        {

                            column.OptionsFilter.AllowAutoFilter = true;
                            column.OptionsFilter.ImmediateUpdateAutoFilter = false;
                            column.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
                        }
                    }

                }
            }
            catch (Exception e)
            {
                MMessage.ShowError(e.StackTrace);
            }
        }

        /// <summary>
        /// Thêm row mới cho grid
        /// </summary>
        /// <param name="grdView"></param>
        public void AddRow(bool allowCloneRow = true)
        {
            if (this.ModeReadOnly)
            {
                return;
            }
            GridColumnCollection colectionColumn = this.FirstView.Columns;
            this.CreateInstanceBindingList();
            if (this.bindingListData != null)
            {
                int oldRowIndex = this.bindingListData.Count - 1;
                object newRecord = this.bindingListData.AddNew();

                object oldRecord = null;

                int rowHandle = this.bindingListData.Count - 1;
                if (rowHandle > -1)
                {
                    if (this.bindingListData.Count > 1)
                    {
                        if (allowCloneRow)
                        {
                            oldRecord = this.bindingListData[oldRowIndex];
                            foreach (DevExpress.XtraGrid.Columns.GridColumn col in colectionColumn)
                            {
                                MCommon.SetValue(newRecord, col.FieldName, MCommon.GetValueObject(oldRecord, col.FieldName));
                            }
                        }

                    }

                    MCommon.SetValue(newRecord, "IsTemp", true);
                    MCommon.SetValue(newRecord, "MTEntityState", (int)MTControl.FormAction.Add);
                    MCommon.SetValue(newRecord, "Id", Guid.NewGuid());

                    if (FuncCustomRecordBeforeAddRow != null && !FuncCustomRecordBeforeAddRow(newRecord, this))
                    {
                        return;
                    }

                    ((MGridView)this.FirstView).RaiseEventCellValueChanged = true;
                    if (colectionColumn != null)
                    {
                        foreach (DevExpress.XtraGrid.Columns.GridColumn col in colectionColumn)
                        {
                            var vVal = MCommon.GetValueObject(newRecord, col.FieldName);
                            this.FirstView.SetRowCellValue(rowHandle, col, vVal);
                        }
                    }
                    ((MGridView)this.FirstView).RaiseEventCellValueChanged = false;

                    //Danh dấu là mode thêm
                    this.FirstView.UpdateCurrentRow();
                    this.FirstView.FocusedRowHandle = rowHandle;
                    if (colectionColumn != null && colectionColumn.Count > 0)
                    {
                        this.FirstView.FocusedColumn = colectionColumn[0];
                        this.FirstView.ShowEditor();
                    }
                }

            }
        }

        /// <summary>
        /// Thiết lập các giá trị cho row trên grid
        /// </summary>
        /// <param name="rowHandle"></param>
        /// <param name="fieldName">Tên trường cần update</param>
        /// <param name="value">Giá trị</param>
        /// Create by: dvthang:05.11.2016
        public void SetValueCell(int rowHandle, string fieldName, object value)
        {
            if (rowHandle > -1 && this.bindingListData?.Count > 0)
            {
                object entity = this.bindingListData[rowHandle];
                MCommon.SetValue(entity, fieldName, value);
                if(value!=null && !DBNull.Value.Equals(value) && !"".Equals(value.ToString().Trim()))
                {
                    MCommon.SetValue(entity, "IsTemp", false);
                }
               
                this.FirstView.SetRowCellValue(rowHandle, fieldName, value);
            }
        }

        /// <summary>
        /// Xóa row được chọn trên grid đi
        /// </summary>
        /// <param name="grdView"></param>
        public void DeleteRow()
        {
            if (this.ModeReadOnly)
            {
                return;
            }
            this.CreateInstanceBindingList();
            if (this.bindingListData != null)
            {
                if (this.FirstView.FocusedRowHandle > -1)
                {

                    //Lưu thông tin row bị xóa trên grid
                    object record = this.FirstView.GetRow(this.FirstView.FocusedRowHandle);
                    int entityState = (int)MCommon.GetValueObject(record, "MTEntityState");
                    if (entityState == (int)MTControl.FormAction.None || entityState == (int)MTControl.FormAction.Edit)
                    {
                        SaveRecordDelete(new List<object> { record });
                    }
                    this.FirstView.BeginDataUpdate();
                    this.bindingListData.RemoveAt(this.FirstView.FocusedRowHandle);
                    this.FirstView.EndDataUpdate();
                }
            }
        }

        /// <summary>
        /// Có sửa các row trên grid không ,=true không cho sửa, false cho sửa
        /// </summary>
        /// <param name="bValue"></param>
        public void SetReadOnly(bool bEnable)
        {
            this.ModeReadOnly = bEnable;
            foreach (DevExpress.XtraGrid.Views.Grid.GridView vView in this.Views)
            {
                if (bEnable)
                {
                    vView.Appearance.FocusedCell.BackColor = MColor.BackColorDisable;
                    vView.Appearance.FocusedCell.BackColor2 = MColor.BackColorDisable;
                }
                else
                {
                    vView.Appearance.FocusedCell.BackColor = MColor.BackColorEditor;
                    vView.Appearance.FocusedCell.BackColor2 = MColor.BackColorEditor;
                }
                vView.Appearance.FocusedCell.Options.UseBackColor = true;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in vView.Columns)
                {
                    if (col.ColumnEdit != null && col.ColumnEdit is MTControl.MRepositoryItemButtonEdit)
                    {
                        col.OptionsColumn.AllowEdit = true;
                        continue;
                    }
                    if (bEnable)
                    {
                        col.OptionsColumn.AllowEdit = !bEnable;
                    }
                    else
                    {
                        if (col.Visible && !col.OptionsColumn.ReadOnly)
                        {
                            col.OptionsColumn.AllowEdit = !bEnable;
                        }
                    }
                    if (col.OptionsColumn.ReadOnly)
                    {
                        col.AppearanceCell.BackColor = MColor.BackColorDisable;
                        col.AppearanceCell.BackColor2 = MColor.BackColorDisable;
                        col.AppearanceCell.Options.UseBackColor = true;
                        col.OptionsColumn.AllowFocus = false;
                    }

                }
            }
        }

        /// <summary>
        /// Thiết lập focus vào cell đã chọn
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="rowHandle"></param>
        public void SetFocusCell(string fieldName, int rowHandle)
        {
            if (this.FirstView != null)
            {
                this.FirstView.FocusedRowHandle = rowHandle;
                this.FirstView.FocusedColumn = this.FirstView.Columns[fieldName];
                this.FirstView.ShowEditor();
            }
        }

        /// <summary>
        /// Focus vào row đầu tiên trên grid
        /// </summary>
        /// Create by: dvthang:19.03.2017
        public void SetFocusRowFirst()
        {
            if (this.FirstView != null && this.FirstView.DataRowCount > 0)
            {
                this.FirstView.FocusedRowHandle = 0;
                this.FirstView.SelectRow(0);
            }
        }

        /// <summary>
        /// Ẩn hiện các column trên grid
        /// </summary>
        /// <param name="lstColumns">Danh sách các column cần ẩn</param>
        /// Create by: dvthang:19.03.2017
        public void SetHideColumns(params string[] lstColumns)
        {
            if (lstColumns != null)
            {
                foreach (string fieldName in lstColumns)
                {
                    GridColumn col = this.FirstView.Columns.ColumnByFieldName(fieldName);
                    if (col != null)
                    {
                        col.Visible = false;
                        col.VisibleIndex = -1;
                    }
                }
            }
        }

        /// <summary>
        /// Hiển thị các column trên grid
        /// </summary>
        /// <param name="lstColumns">Danh sách các column cần ẩn</param>
        /// Create by: dvthang:19.03.2017
        public void SetShowColumns(params string[] lstColumns)
        {
            if (lstColumns != null)
            {
                int visibleIndex = 0;
                foreach (string fieldName in lstColumns)
                {
                    GridColumn col = this.FirstView.Columns.ColumnByFieldName(fieldName);
                    if (col != null)
                    {
                        col.Visible = true;
                        col.VisibleIndex = visibleIndex;
                        visibleIndex++;
                    }
                }
            }
        }
        #endregion
        #region"Event"

        /// <summary>
        /// Xử lý thêm event sau khi grid load xong
        /// </summary>
        protected override void OnLoaded()
        {
            base.OnLoaded();
            this.FirstView.OptionsView.ColumnAutoWidth = false;
            this.FirstView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.FirstView.ColumnPanelRowHeight = -1;

            //gridView1_CustomRowCellEditForEditing
            this.FirstView.CustomRowCellEditForEditing -= FirstView_CustomRowCellEditForEditing;
            this.FirstView.CustomRowCellEditForEditing += FirstView_CustomRowCellEditForEditing;


            this.FirstView.RowCellStyle -= FirstView_RowCellStyle;
            this.FirstView.RowCellStyle += FirstView_RowCellStyle;

            if (this.IsEditable)
            {

                this.MouseClick -= Grid_MouseClick;
                this.MouseClick += Grid_MouseClick;

                //Đăng ký envet foucus vào row
                this.FirstView.ShownEditor -= FirstView_ShownEditor;
                this.FirstView.ValidatingEditor -= FirstView_ValidateEditor;

                this.FirstView.ShowingEditor -= FirstView_ShowingEditor;
                this.FirstView.ShowingEditor += FirstView_ShowingEditor;
               
                this.FirstView.ShownEditor += FirstView_ShownEditor;
                this.FirstView.ValidatingEditor += FirstView_ValidateEditor;
                
            }

            this.FirstView.InvalidRowException -= FirstView_InvalidRowException;
            this.FirstView.InvalidRowException += FirstView_InvalidRowException;

            this.FirstView.CustomDrawCell -= FirstView_CustomDrawCell;
            this.FirstView.CustomDrawCell += FirstView_CustomDrawCell;

            this.FirstView.MouseUp -= FirstView_MouseUp;
            this.FirstView.MouseUp += FirstView_MouseUp; 
            
            this.FirstView.KeyDown -= FirstView_KeyDown;
            this.FirstView.KeyDown += FirstView_KeyDown;
        }

        private void FirstView_KeyDown(object sender, KeyEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) != null
                    && view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() != String.Empty)
                    Clipboard.SetText(view.GetFocusedRowCellDisplayText(view.FocusedColumn));
                e.Handled = true;
            }
        }



        /// <summary>
        /// Bắt event nhấn vào row của grid xử lý modelselection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
            {
                return;
            }

            if (this.FirstView.OptionsSelection.MultiSelect && this.FirstView.OptionsSelection.MultiSelectMode == GridMultiSelectMode.CheckBoxRowSelect)
            {
                var calcHitInfo = view.CalcHitInfo(e.Location);
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (calcHitInfo.HitTest == GridHitTest.RowCell && view.Columns.Contains(calcHitInfo.Column))
                    {
                        view.ClearSelection();
                        view.SelectRow(calcHitInfo.RowHandle);
                    }
                }
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    ((DXMouseEventArgs)e).Handled = true;
                }
            }


        }

        /// <summary>
        /// Custom lại nội dung hiển thị trên cell grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            MGridColumn col = e.Column as MGridColumn;
            if (col == null)
            {
                return;
            }
            if (this.FirstView.IsFilterRow(e.RowHandle) && col.FilterEditor != null)
            {
                if (e.CellValue == null)
                {
                    e.DisplayText = string.Empty;
                }
                else
                {
                    switch (col.FilterEditor.DataType)
                    {
                        case DataTypeColumn.DateEdit:
                            e.DisplayText = Convert.ToDateTime(e.CellValue).ToString("dd/MM/yyyy");
                            break;
                        case DataTypeColumn.ComboBox:
                            if (!string.IsNullOrWhiteSpace(col.EnumName))
                            {
                                e.DisplayText = MCommon.GetDisplayEnum(col.EnumName, Convert.ToInt32(e.CellValue))?.Text;
                            }
                            break;
                    }
                }

                return;
            }
            if (!string.IsNullOrWhiteSpace(col.EnumName) && e.CellValue != null)
            {
                int iValue = 0;
                int.TryParse(e.CellValue.ToString(), out iValue);
                e.DisplayText = MCommon.GetDisplayEnum(col.EnumName, iValue)?.Text;
                return;
            }

            if (userCustomDrawCell != null)
            {
                UserCustomDrawCell(sender, e);
            }

        }

        /// <summary>
        /// Click chuột phải vào thì hiển thị contextmenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.ModeReadOnly == false || this.isEditable)
            {
                if (e.Button == MouseButtons.Right)
                {
                    //Không phải là mode xem thì cho hiển thị
                    if (_contextMenuStrip == null)
                    {
                        _contextMenuStrip = new ContextMenuStrip();

                        if (IsHideActionAdd)
                        {
                            MCommon.CreateContextMenu(sender as GridView, _contextMenuStrip, new MButtonName[]
                                   {
                                        new MButtonName{CommandName=MCommandName.Delete}
                                   }, new EventHandler(contextMenu_OnClick));
                        }
                        else
                        {
                            MCommon.CreateContextMenu(sender as GridView, _contextMenuStrip, new MButtonName[]
                                   {
                                        new MButtonName{CommandName=MCommandName.AddNew},
                                        new MButtonName{CommandName=MCommandName.Delete}
                                   }, new EventHandler(contextMenu_OnClick));
                        }


                    }

                    _contextMenuStrip.Show(this, new Point(e.X, e.Y));
                }
            }
        }

        /// <summary>
        /// Thực hiện custom rowcell style
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (!string.IsNullOrWhiteSpace(DisableFieldNames))
                {
                    string[] fieldNames = DisableFieldNames.ToLower().Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries);

                    if (fieldNames.Contains(e.Column.FieldName.ToLower()))
                    {
                        e.Column.AppearanceCell.BackColor = MColor.BackColorDisable;
                        e.Column.AppearanceCell.BackColor2 = MColor.BackColorDisable;
                        e.Column.AppearanceCell.Options.UseBackColor = true;
                        e.Column.AppearanceCell.Options.UseBorderColor = true;
                        e.Column.AppearanceCell.Options.HighPriority = true;
                    }
                }

                if (e.Column.ColumnEdit is MRepositoryItemButtonEdit)
                {
                    e.Appearance.BackColor = Color.FromArgb(2, 107, 151);
                    e.Appearance.BackColor2 = Color.FromArgb(2, 107, 151);
                    e.Appearance.BorderColor = Color.FromArgb(2, 107, 151);
                    e.Appearance.ForeColor = Color.White;
                    e.Appearance.Options.UseForeColor = true;
                    e.Appearance.Options.UseBackColor = true;
                }

                if (rowCellStyle != null)
                {
                    RowCellStyle(sender, e);
                }
            }
        }

        /// <summary>
        /// Custom hành động editor cell trên grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstView_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DisableFieldNames))
            {
                GridView view = sender as GridView;
                string[] fieldNames = DisableFieldNames.ToLower().Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (fieldNames.Contains(view.FocusedColumn.FieldName.ToLower()))
                {
                    e.Cancel = true;
                }
            }
        }



        /// <summary>
        /// Tạo đối tượng control filter row khi click vào row filter
        /// </summary>
        /// <param name="mGridColumn">Thông tin column</param>
        /// <returns>Trả về repository tạo filter row</returns>
        public RepositoryItem CreateFilterRowByColumnType(MGridColumn mGridColumn)
        {
            var type = mGridColumn.ColumnType;
            if (type == typeof(decimal) || type == typeof(decimal?)
               || type == typeof(Decimal) || type == typeof(Decimal?)
               || type == typeof(float) || type == typeof(float?))
            {
                return new MRepositorySpinEdit
                {
                    GridMaster = this,
                    Tag = this,
                    Padding = new Padding(0),
                    MaskBoxPadding = new Padding(0),
                    AutoHeight = true,
                    IsEditorFilterRow = true
                };
            }

            if (type == typeof(DateTime) || type == typeof(DateTime?))
            {
                return new MRepositoryDateEdit
                {
                    GridMaster = this,
                    Tag = this,
                    Padding = new Padding(0),
                    MaskBoxPadding = new Padding(0),
                    AutoHeight = true,
                    IsEditorFilterRow = true
                };
            }

            if ((type == typeof(int) || type == typeof(int?)))
            {
                if (!string.IsNullOrWhiteSpace(mGridColumn.EnumName))
                {
                    return new MRepositoryItemLookUpEdit
                    {
                        GridMaster = this,
                        Tag = this,
                        EnumData = mGridColumn.EnumName,
                        Padding = new Padding(0),
                        MaskBoxPadding = new Padding(0),
                        AutoHeight = true,
                        IsEditorFilterRow = true
                    };
                }
                else
                {
                    return new MRepositorySpinEdit
                    {
                        GridMaster = this,
                        Tag = this,
                        Padding = new Padding(0),
                        MaskBoxPadding = new Padding(0),
                        AutoHeight = true,
                        IsEditorFilterRow = true
                    };
                }
            }

            return new MRepositoryTextEdit
            {
                GridMaster = this,
                Tag = this,
                AutoHeight = true,
                IsEditorFilterRow = true
            };
        }

        /// <summary>
        /// Xử lý event focus vào cell của grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstView_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {

            if (this.IsShowFilter && this.FirstView.IsFilterRow(e.RowHandle))
            {
                MGridColumn mGridColumn = (MGridColumn)e.Column;
                if (mGridColumn.FilterEditor != null && mGridColumn.FilterEditor.DataType != DataTypeColumn.None)
                {
                    if (_cacheRepFilter.ContainsKey(mGridColumn.FieldName))
                    {
                        e.RepositoryItem = _cacheRepFilter[mGridColumn.FieldName];
                        return;
                    }
                    if (mGridColumn.FilterEditor.DataSource == null && !string.IsNullOrWhiteSpace(mGridColumn.FilterEditor.TableName))
                    {

                        if (MT.Library.Utility.CheckForSQLInjection(mGridColumn.FilterEditor.TableName))
                        {
                            throw new Exception("SQL Injection");
                        }
                        string sColumnNames = $"Id,{mGridColumn.FilterEditor.DisplayText}";
                        if (mGridColumn.FilterEditor.DataType == DataTypeColumn.TreeLookUpEdit)
                        {
                            sColumnNames += ",sParentId";
                        }
                        using (IUnitOfWork unitOfWork = new UnitOfWork(MT.Library.SessionData.ConnectString))
                        {
                            string query = $@"SELECT {sColumnNames} FROM {mGridColumn.FilterEditor.TableName}";

                            if (!string.IsNullOrWhiteSpace(mGridColumn.FilterEditor.OrderBy))
                            {
                                if (MT.Library.Utility.CheckForSQLInjection(mGridColumn.FilterEditor.OrderBy))
                                {
                                    throw new Exception("SQL Injection");
                                }
                                query += $" ORDER BY {mGridColumn.FilterEditor.OrderBy}";
                            }

                            mGridColumn.FilterEditor.DataSource = unitOfWork.QueryDataTable(query);
                        }

                    }
                    switch (mGridColumn.FilterEditor.DataType)
                    {
                        case DataTypeColumn.TreeLookUpEdit:
                            var treeRep = new MRepositoryItemTreeLookUpEdit
                            {
                                GridMaster = this,
                                Tag = this,
                                Padding = new Padding(0),
                                MaskBoxPadding = new Padding(0),
                                AutoHeight = true,
                                DataSource = mGridColumn.FilterEditor.DataSource,
                                DisplayMember = mGridColumn.FilterEditor.DisplayText,
                                ValueMember = mGridColumn.FilterEditor.DisplayText,
                                IsEditorFilterRow = true
                            };
                            var treeList = treeRep.TreeList;
                            treeList.KeyFieldName = "Id";
                            treeList.ParentFieldName = "sParentId";
                            treeRep.AddColumn(mGridColumn.FilterEditor.DisplayText);

                            e.RepositoryItem = treeRep;
                            break;
                        case DataTypeColumn.GridLookUpEdit:
                            var gridLookUp = new MRepositoryItemGridLookUpEdit
                            {
                                GridMaster = this,
                                Tag = this,
                                Padding = new Padding(0),
                                MaskBoxPadding = new Padding(0),
                                AutoHeight = true,
                                DataSource = mGridColumn.FilterEditor.DataSource,
                                DisplayMember = mGridColumn.FilterEditor.DisplayText,
                                ValueMember = mGridColumn.FilterEditor.DisplayText,
                                IsEditorFilterRow = true
                            };
                            gridLookUp.AddColumn(mGridColumn.FilterEditor.DisplayText, "");
                            e.RepositoryItem = gridLookUp;
                            break;
                        case DataTypeColumn.LookUpEdit:
                            var lookupEdit = new MRepositoryItemLookUpEdit
                            {
                                GridMaster = this,
                                Tag = this,
                                Padding = new Padding(0),
                                MaskBoxPadding = new Padding(0),
                                AutoHeight = true,
                                DataSource = mGridColumn.FilterEditor.DataSource,
                                DisplayMember = mGridColumn.FilterEditor.DisplayText,
                                ValueMember = mGridColumn.FilterEditor.DisplayText,
                                IsEditorFilterRow = true
                            };
                            lookupEdit.AddColumn(mGridColumn.FilterEditor.DisplayText, "");
                            e.RepositoryItem = lookupEdit;
                            break;
                        case DataTypeColumn.ComboBox:
                            e.RepositoryItem = new MRepositoryItemLookUpEdit
                            {
                                GridMaster = this,
                                Tag = this,
                                Padding = new Padding(0),
                                MaskBoxPadding = new Padding(0),
                                AutoHeight = true,
                                EnumData = mGridColumn.EnumName,
                                IsEditorFilterRow = true
                            };
                            break;
                        case DataTypeColumn.DateEdit:
                            e.RepositoryItem = new MRepositoryDateEdit
                            {
                                GridMaster = this,
                                Tag = this,
                                Padding = new Padding(0),
                                MaskBoxPadding = new Padding(0),
                                AutoHeight = true,
                                IsEditorFilterRow = true
                            };
                            break;
                        case DataTypeColumn.SpinEdit:
                            e.RepositoryItem = new MRepositorySpinEdit
                            {
                                GridMaster = this,
                                Tag = this,
                                Padding = new Padding(0),
                                MaskBoxPadding = new Padding(0),
                                AutoHeight = true,
                                IsEditorFilterRow = true
                            };
                            break;
                        default:
                            e.RepositoryItem = new MRepositoryTextEdit
                            {
                                GridMaster = this,
                                Tag = this,
                                Padding = new Padding(0),
                                MaskBoxPadding = new Padding(0),
                                AutoHeight = true,
                                IsEditorFilterRow = true
                            };
                            break;
                    }

                    if (!_cacheRepFilter.ContainsKey(mGridColumn.FieldName))
                    {
                        _cacheRepFilter.Add(mGridColumn.FieldName, e.RepositoryItem);
                    }
                }
                else
                {
                    e.RepositoryItem = CreateFilterRowByColumnType(mGridColumn);
                }
                return;
            }
            if (this.IsEditable && !this.FirstView.IsFilterRow(e.RowHandle))
            {
                GridView view = sender as GridView;
                if (e.RowHandle == view.FocusedRowHandle)
                {
                    var oldRepository = this.RepositoryItems[e.Column.VisibleIndex];
                    RepositoryItem newRepository = null;
                    switch (oldRepository.EditorTypeName)
                    {
                        case "MTreeLookUpEdit":
                            var repositoryItemTreeLookUpEdit = new MRepositoryItemTreeLookUpEdit
                            {
                                GridMaster = this
                            };
                            repositoryItemTreeLookUpEdit.ButtonClick -= new ButtonPressedEventHandler(repositoryItemTreeLookUpEdit.ShowForm);
                            repositoryItemTreeLookUpEdit.ButtonClick += new ButtonPressedEventHandler(repositoryItemTreeLookUpEdit.ShowForm);
                            newRepository = repositoryItemTreeLookUpEdit;
                            break;
                        case "MLookUpEdit":
                            var mRepositoryItemLookUpEdit = new MRepositoryItemLookUpEdit
                            {
                                GridMaster = this
                            };
                            mRepositoryItemLookUpEdit.ButtonClick -= new ButtonPressedEventHandler(mRepositoryItemLookUpEdit.ShowForm);
                            mRepositoryItemLookUpEdit.ButtonClick += new ButtonPressedEventHandler(mRepositoryItemLookUpEdit.ShowForm);
                            newRepository = mRepositoryItemLookUpEdit;
                            break;
                        case "MGridLookUpEdit":
                            var repositoryItemGridLookUpEdit = new MRepositoryItemGridLookUpEdit
                            {
                                GridMaster = this
                            };
                            repositoryItemGridLookUpEdit.ButtonClick -= new ButtonPressedEventHandler(repositoryItemGridLookUpEdit.ShowForm);
                            repositoryItemGridLookUpEdit.ButtonClick += new ButtonPressedEventHandler(repositoryItemGridLookUpEdit.ShowForm);
                            newRepository = repositoryItemGridLookUpEdit;
                            break;
                        case "MComboBox":
                            newRepository = new MRepositoryComboBox
                            {
                                GridMaster = this,
                                FieldName = e.Column.FieldName
                            };
                            break;
                        case "MSpinEdit":
                            newRepository = new MRepositorySpinEdit
                            {
                                GridMaster = this
                            };
                            break;
                        case "MDateEdit":
                            newRepository = new MRepositoryDateEdit
                            {
                                GridMaster = this
                            };
                            break;
                        case "MButtonEdit":
                            newRepository = new MRepositoryItemButtonEdit
                            {
                                GridMaster = this,
                                TextEditStyle = TextEditStyles.HideTextEditor
                            };
                            break;
                        case "MCheckComboBox":
                            newRepository = new MRepositoryItemCheckedComboBox
                            {
                                GridMaster = this
                            };
                            break;
                        default:
                            newRepository = new MRepositoryTextEdit
                            {
                                GridMaster = this
                            };
                            break;

                    }
                    var repositoryClone = this.RepositoryItems[e.Column.VisibleIndex];
                    newRepository.Assign(repositoryClone);
                    if (CustomRowCellEditing != null)
                    {
                        newRepository.Tag = this;
                        CustomRowCellEditing(newRepository, e);
                    }
                    e.RepositoryItem = newRepository;
                }
            }
        }


        /// <summary>
        /// Xử lý validate Cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstView_ValidateEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;

                GridColumn col = view.FocusedColumn;
                if (col != null)
                {

                    Type t = col.ColumnType;
                    if (t.Equals(typeof(decimal)) || t.Equals(typeof(Decimal)) || t.Equals(typeof(Int32)) || t.Equals(typeof(int)))
                    {
                        if (col.ColumnEdit != null && col.ColumnEdit is RepositoryItemSpinEdit)
                        {
                            RepositoryItemSpinEdit editor = col.ColumnEdit as RepositoryItemSpinEdit;
                            if (editor != null)
                            {
                                if (this.FirstView.GetRowCellValue(view.FocusedRowHandle, col) != null && MCommon.IsNumeric(this.FirstView.GetRowCellValue(view.FocusedRowHandle, col).ToString()))
                                {
                                    decimal value = decimal.Parse(this.FirstView.GetRowCellValue(view.FocusedRowHandle, col).ToString());
                                    decimal maxValue = editor.MaxValue == 0 ? 9999999999999999 : editor.MaxValue;
                                    decimal minValue = editor.MinValue;
                                    if (value > maxValue || value < minValue)
                                    {
                                        e.Valid = false;
                                        e.ErrorText = string.Format("{0} vượt quá giới hạn cho phép. Xin vui lòng kiểm tra lại.", !string.IsNullOrEmpty(col.ToolTip) ? col.ToolTip : col.Caption);
                                    }
                                    else
                                    {
                                        e.Valid = true;
                                        e.ErrorText = string.Empty;
                                    }
                                }
                                else
                                {
                                    e.Valid = false;
                                    e.ErrorText = "Giá trị không hợp lệ!";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Chặn event lỗi khi sửa cell trên grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            try
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
                MMessage.ShowError(e.ErrorText);
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Khi nhấn vào cell thì select all tất cả các giá trị
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstView_ShownEditor(object sender, EventArgs e)
        {
            if (sender is GridView)
            {
                GridView view = sender as GridView;
                if (view.ActiveEditor != null)
                {
                    bGotFocus = true;
                    view.ActiveEditor.MouseUp -= ActiveEditor_MouseUp;
                    view.ActiveEditor.MouseUp += ActiveEditor_MouseUp;
                }
            }

        }

        /// <summary>
        /// Khi active vào control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActiveEditor_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.FirstView.Editable && bGotFocus)
            {
                IEditControl editControl = sender as IEditControl;
                if (editControl == null)
                {
                    return;
                }
                switch (editControl.Mtype)
                {
                    case Ctype.MSpinEdit:
                        if (!((MSpinEdit)sender).ReadOnly && !string.IsNullOrWhiteSpace(((MSpinEdit)sender).Text))
                        {
                            ((MSpinEdit)sender).SelectAll();
                        }
                        break;
                    case Ctype.MTextEdit:
                        if (!((MTextEdit)sender).ReadOnly && !string.IsNullOrWhiteSpace(((MTextEdit)sender).Text))
                        {
                            ((MTextEdit)sender).SelectAll();
                        }
                        break;
                    case Ctype.MDateEdit:
                        if (!((MDateEdit)sender).ReadOnly && !string.IsNullOrWhiteSpace(((MDateEdit)sender).Text))
                        {
                            ((MDateEdit)sender).SelectAll();
                        }
                        break;
                    case Ctype.MTreeLookUpEdit:
                        if (!((MTreeLookUpEdit)sender).ReadOnly && !string.IsNullOrWhiteSpace(((MTreeLookUpEdit)sender).Text))
                        {
                            ((MTreeLookUpEdit)sender).SelectAll();
                        }
                        break;
                    case Ctype.MLookUpEdit:
                        if (!((MLookUpEdit)sender).ReadOnly && !string.IsNullOrWhiteSpace(((MLookUpEdit)sender).Text))
                        {
                            ((MLookUpEdit)sender).SelectAll();
                        }
                        break;
                }
                bGotFocus = false;
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn vào button trên contextmenu của grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenu_OnClick(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            if (toolStripMenuItem != null && toolStripMenuItem.Tag != null)
            {
                switch ((int)toolStripMenuItem.Tag)
                {
                    case (int)MCommandName.AddNew:
                        this.AddRow();
                        break;
                    case (int)MCommandName.Delete:
                        this.DeleteRow();
                        break;
                }

            }

        }

        #endregion

        #region"Ovrrides"
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            bool isDesignMode = DesignMode || IsDesignMode || (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            if (!isDesignMode)
            {

                if (this.IsShowFilter)
                {
                    this.FirstView.OptionsFilter.AllowFilterEditor = true;
                    this.FirstView.OptionsView.ShowAutoFilterRow = true;
                    this.FirstView.OptionsMenu.ShowAutoFilterRowItem = true;
                }


                SetDefaultStyleGrid();

                SetFont();
            }
        }

        /// <summary>
        /// Thực hiện undo data của grid về giá trị ban đầu
        /// </summary>
        /// Create by: dvthang:10.06.2018
        public void RejectChanges()
        {
            if (this.lstTemp != null)
            {
                if (this.bindingListData != null)
                {
                    this.bindingListData.Clear();
                }
                this.LoadData(lstTemp, false);
            }
        }

        /// <summary>
        /// Commit các thay đổi trên grid
        /// </summary>
        /// Create by: dvthang:10.06.2018
        public void CommitChanges()
        {
            if (this.bindingListData != null && this.lstTemp != null)
            {
                this.lstTemp = new List<object>();
                int totalCount = this.bindingListData.Count;
                for (int i = 0; i < totalCount; i++)
                {
                    MethodInfo method = this.type.GetMethod("Clone");
                    if (method != null)
                    {
                        var item = this.bindingListData[i];
                        MCommon.SetValue(item, "MTEntityState", (int)MTControl.FormAction.None);
                        this.lstTemp.Add(method.Invoke(item, null));
                    }
                }
                this.lstRowDelete = null;
            }

        }

        /// <summary>
        /// Xử lý event tab trên grid
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="onlyEvent"></param>
        /// <returns></returns>
        /// Create by: dvthang:10.06.2018
        protected void Grid_ProcessGridKey(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                GridControl grid = sender as GridControl;

                GridView view = grid.FocusedView as GridView;

                if ((e.Modifiers == Keys.None && view.IsLastRow && view.FocusedColumn.VisibleIndex == view.VisibleColumns.Count - 1)

                    || (e.Modifiers == Keys.Shift && view.IsFirstRow && view.FocusedColumn.VisibleIndex == 0))
                {

                    if (view.IsEditing)
                    {
                        view.CloseEditor();
                    }
                    grid.SelectNextControl(grid, e.Modifiers == Keys.None, false, false, true);
                    e.Handled = true;

                }

            }

        }

        /// <summary>
        /// Tạo viewcustom cho grid
        /// </summary>
        /// <returns></returns>
        protected override BaseView CreateDefaultView()
        {
            return CreateView("MGridView");
        }
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new MGridViewInfoRegistrator());
        }

        #endregion
        #region"Implement"

        [Description("Control hiển thị danh sách dạng lưới")]
        [Category("MTControl")]
        public string Description
        {
            get
            {
                return decription;
            }
            set
            {
                decription = value;
            }
        }

        /// <summary>
        /// Đặt font chữ cho grid
        /// </summary>
        /// Create by: dvthang:21.05.2017
        private void SetFont()
        {
            float sizeFont = MSize.mscSysFontSize;
            this.ForeColor = MColor.ColorLabel;
            this.Font = new Font(MFont.mscSysFontName, sizeFont, FontStyle.Regular, GraphicsUnit.Pixel);
        }
        #endregion

        private void InitializeComponent()
        {
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this;
            this.gridView1.Name = "gridView1";
            // 
            // MGridControl
            // 
            this.MainView = this.gridView1;
            this.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
        /// <summary>
        /// Kiểu của control
        /// </summary>
        /// Create by: dvthang:04.10.2017
        public Ctype MType
        {
            get
            {
                return Ctype.MGridControl;
            }
        }
    }
}

