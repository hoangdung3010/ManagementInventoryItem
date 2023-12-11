using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraTreeList.ViewInfo;
using System;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraEditors.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using System.Collections.Generic;
using DevExpress.XtraTreeList;
using DevExpress.XtraEditors.Controls;

namespace MTControl
{
    public class MTreeView : DevExpress.XtraTreeList.TreeList, IControl
    {
        #region"Declare"
        private string decription;
        private LoadingPanel loadingPanel = null;
        private bool drawLoading = false;

        internal bool DrawLoadingAnimation {
            get {
                return drawLoading;
            }
            set {
                drawLoading = value;
                Invalidate();
            }
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
        /// Danh sách các cột cần sumary
        /// </summary>
        private string sumary;

        public string Sumary
        {
            get { return sumary; }
            set { sumary = value; }
        }
        public string CustomModelFields { get; set; }
        #endregion
        #region"Contructor"
        public MTreeView()
        {
            loadingPanel = new LoadingPanel(this);
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }
        #endregion
        #region"Sub/Func"
        /// <summary>
        /// Lấy về giá trị của cột
        /// </summary>
        /// <param name="column">Cột trên treeList</param>
        /// Create by: dvthang:08.03.2017
        public T GetValueByRowSelected<T>(TreeListColumn column)
        {
            T value = default(T);
            TreeListNode node = this.FocusedNode;
            if (node != null)
            {
                value = (T)node.GetValue(column);
            }
            return value;
        }

        /// <summary>
        ///Lấy về thông tin bản ghi được chọn trên treeList
        /// </summary>
        /// Create by: dvthang:08.03.2017
        public T GetDataByRowSelected<T>()
        {
            if (this.FocusedNode != null)
            {
                return (T)this.GetDataRecordByNode(this.FocusedNode);
            }
            return default(T);
        }

        /// <summary>
        ///Lấy về tất cả các thông tin được chọn được chọn trên treeList
        /// </summary>
        /// Create by: dvthang:08.03.2017
        public List<T> GetListDataByRowsSelected<T>()
        {
            var nodes = this.Selection;
            List<T> lstData = new List<T>();
            foreach (TreeListNode node in nodes)
            {
                lstData.Add((T)this.GetDataRecordByNode(node));
            }
            return null;
        }

        /// <summary>
        /// Add column vào tree
        /// </summary>
        /// <param name="column">Column của tree</param>
        /// Create by: dvthang:04.03.2017
        public TreeListColumn AddColumn(TreeListColumn column)
        {
            if (column != null)
            {
                this.Columns.Add(column);
            }
            return column;
        }

        /// <summary>
        /// Add column dạng text vào tree
        /// </summary>
        /// <param name="grd">Tên grid</param>
        /// <param name="fieldName">Tên cột</param>
        /// <param name="caption">Tiêu đề cột</param>
        /// <param name="width">Độ rộng cột</param>
        /// dvthang-08.07.2016
        public TreeListColumn AddColumnText(string fieldName, string caption, int width = 50, DataTypeColumn dataType = DataTypeColumn.None,
            bool isFixWidth=false, DevExpress.XtraTreeList.Columns.FixedStyle fixedStyle = DevExpress.XtraTreeList.Columns.FixedStyle.None)
        {
            TreeListColumn col = new TreeListColumn();
            col.FieldName = fieldName;
            col.Caption = caption;
            col.Visible = true;
            col.OptionsColumn.FixedWidth = isFixWidth;
            col.Fixed = fixedStyle;
            col.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            switch (dataType)
            {
                case DataTypeColumn.MemoEdit:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
                    break;
                case DataTypeColumn.SpinEdit:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
                    break;
                case DataTypeColumn.TimeEdit:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
                    break;
                case DataTypeColumn.DateEdit:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
                    break;
                case DataTypeColumn.ComboBox:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                    break;
                case DataTypeColumn.GridLookUpEdit:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
                    break;
                case DataTypeColumn.HyperLinkEdit:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
                    break;
                case DataTypeColumn.LookUpEdit:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                    break;
                case DataTypeColumn.ImageComboBox:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                    break;
            }
            if (width > 0)
            {
                col.Width = width;
            }
            this.Columns.Add(col);
            return col;
        }

        /// <summary>
        /// Add column dạng text vào tree
        /// </summary>
        /// <param name="grd">Tên grid</param>
        /// <param name="fieldName">Tên cột</param>
        /// <param name="caption">Tiêu đề cột</param>
        /// <param name="toolTip">toolTip cột</param>
        /// <param name="width">Độ rộng cột</param>
        /// dvthang-08.07.2016
        public TreeListColumn AddColumnText(string fieldName, string caption, string toolTip, int width = 50, DataTypeColumn dataType = DataTypeColumn.None,
            bool isFixWidth = false, DevExpress.XtraTreeList.Columns.FixedStyle fixedStyle = DevExpress.XtraTreeList.Columns.FixedStyle.None)
        {
            TreeListColumn col = this.AddColumnText(fieldName, caption, width, dataType, isFixWidth, fixedStyle);
            col.ToolTip = toolTip;
            return col;
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
                    TreeListColumn col = this.Columns.ColumnByFieldName(fieldName);
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
                    TreeListColumn col = this.Columns.ColumnByFieldName(fieldName);
                    if (col != null)
                    {
                        col.Visible = true;
                        col.VisibleIndex = visibleIndex;
                        visibleIndex++;
                    }
                }
            }
        }

        /// <summary>
        /// Căn chỉnh vị trí các text trong column grid(Giữa, trái , phải)
        /// </summary>
        protected void SetDefaultAlignTree()
        {

            foreach (TreeListColumn col in this.Columns)
            {
                Type t = col.GetType();
                if (t.Equals(typeof(string)))
                {
                    //Căn trái dữ liệu
                    col.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                }
                else if (t.Equals(typeof(DateTime)) || t.Equals(typeof(DateTime?)))
                {
                    //Căn Giữa dữ liệu
                    col.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.DateTime;
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                else if (t.Equals(typeof(Decimal)) || t.Equals(typeof(Decimal?)))
                {
                    //Căn Phải dữ liệu
                    col.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Decimal;
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                }
                else if (t.Equals(typeof(Int32)) || t.Equals(typeof(Int32?)))
                {
                    //Căn Phải dữ liệu
                    col.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Integer;
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                }
                else if (t.Equals(typeof(float)) || t.Equals(typeof(float?)))
                {
                    //Căn Phải dữ liệu
                    col.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Decimal;
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                }
                else if (t.Equals(typeof(int)) || t.Equals(typeof(int?)))
                {
                    //Căn Phải dữ liệu
                    col.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Integer;
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                }
                //Căn giữa header
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                col.OptionsColumn.AllowEdit = false;
                col.OptionsColumn.ReadOnly = true;
            }
            this.OptionsBehavior.ReadOnly = true;
            this.OptionsBehavior.Editable = false;
            this.OptionsMenu.ShowExpandCollapseItems = false;

        }

        /// <summary>
        /// Thiết lập style cho control
        /// </summary>
        /// Create by: dvthang:05.03.2017
        protected virtual void SetDefaultStyleTree()
        {
            //Màu nền của header
            this.Appearance.HeaderPanel.BackColor = MColor.HeaderGridBackColor;
            this.Appearance.HeaderPanel.BackColor2 = MColor.HeaderGridBackColor;
            this.Appearance.HeaderPanel.BorderColor = MColor.BorderHeaderGridColor;
            //Thiết lập màu nền khi foucus vào row
            this.Appearance.FocusedRow.BackColor = MColor.FocusBackColor;
            this.Appearance.FocusedRow.BackColor2 = MColor.FocusBackColor;
            this.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            //Thiết lập màu nền khi focus vào Cell
            this.Appearance.FocusedCell.BackColor = MColor.FocusBackColor;
            this.Appearance.FocusedCell.BackColor2 = MColor.FocusBackColor;
            this.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            //Thiết lập màu active row khi focus vào các control khác
            this.Appearance.HideSelectionRow.BackColor = MColor.FocusBackColor;
            this.Appearance.HideSelectionRow.BackColor2 = MColor.FocusBackColor;
            this.Appearance.HideSelectionRow.ForeColor = Color.Black;

            //Set style cho các dòng chẵn lẻ
            this.Appearance.EvenRow.BackColor = MColor.GridEvenRowBackColor;
            this.Appearance.EvenRow.BackColor2 = MColor.GridEvenRowBackColor;
            this.Appearance.EvenRow.ForeColor = Color.Black;

            this.Appearance.OddRow.BackColor = MColor.GridOldRowBackColor;
            this.Appearance.OddRow.BackColor2 = MColor.GridOldRowBackColor;
            this.Appearance.OddRow.ForeColor = Color.Black;

            this.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            //Không hiển thì khung hình chữ nhật viền chấm chấm khi focus
            //Thiết lập khoảng cách từ border đến nội dung các cell
            //Thiết lập không cho di chuyển cột trên grid
            this.OptionsCustomization.AllowColumnMoving = false;
            //Enable style cho các dòng chẵn lẻ
            this.OptionsView.EnableAppearanceEvenRow = true;
            this.OptionsView.EnableAppearanceOddRow = true;
            //Không hiển thị menu trên column khi nhấn chuột phải
            this.OptionsMenu.EnableColumnMenu = false;
            //Không cho hiển thị panel tìm kiếm (Người dùng nhấn control F)
            this.OptionsFind.AllowFindPanel = false;


            this.Appearance.Row.Font = new System.Drawing.Font(MFont.mscSysFontName, MSize.mscSysFontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Appearance.HeaderPanel.Font = new System.Drawing.Font(MFont.mscSysFontName, MSize.mscSysFontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);

        }

        /// <summary>
        /// Vẽ lại control
        /// </summary>
        ///Create by: dvthang:05.03.2017
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if (drawLoading) {
                loadingPanel.Bounds = e.ClipRectangle;
                loadingPanel.Draw(new DevExpress.Utils.Drawing.GraphicsCache(e.Graphics));
            }
        }

        /// <summary>
        /// Hiển thị mask
        /// </summary>
        /// Create by: dvthang:05.03.2017
        public override void ShowLoadingPanel() {
            DrawLoadingAnimation = true;
        }

        /// <summary>
        /// Ẩn mask
        /// </summary>
        /// Create by: dvthang:05.03.2017
        public override void HideLoadingPanel() {
            DrawLoadingAnimation = false;
        }

        /// <summary>
        /// Focus vào node đầu tiên trên treeview
        /// </summary>
        /// Create by: dvthang:05.03.2017
        public void SetFirstNode()
        {
            this.CollapseAll();
            if (this.Nodes != null && this.Nodes.Count > 0)
            {
                TreeListNode firstNode = this.GetNodeByVisibleIndex(0);
                this.SetFocusedNode(firstNode);
            }
        }
        #endregion
        #region"Ovrrides"
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetDefaultStyleTree();
            SetDefaultAlignTree();
            SetFont();

            this.PopupMenuShowing -= treeView_PopupMenuShowing;
            this.PopupMenuShowing += treeView_PopupMenuShowing;
        }

        private void treeView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu.MenuType == DevExpress.XtraTreeList.Menu.TreeListMenuType.AutoFilter)
            {
                TreeList treeList = sender as TreeList;
                TreeListHitInfo hitInfo = treeList.CalcHitInfo(e.Point);
                TreeListColumn col = hitInfo.Column;

                switch (col.UnboundType)
                {
                    case DevExpress.XtraTreeList.Data.UnboundColumnType.Bound:
                    case DevExpress.XtraTreeList.Data.UnboundColumnType.String:
                        VisibleMenuGridColumnFilterStringAndInterger(e);
                        break;
                    case DevExpress.XtraTreeList.Data.UnboundColumnType.Decimal:
                    case DevExpress.XtraTreeList.Data.UnboundColumnType.DateTime:
                    case DevExpress.XtraTreeList.Data.UnboundColumnType.Integer:
                        VisibleMenuGridColumnFilterStringAndInterger(e);
                        var menuFilterClauseContains = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseContains)];
                        if (menuFilterClauseContains != null)
                        {
                            menuFilterClauseContains.Visible = false;
                        }

                        var menuFilterClauseBeginsWith = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseBeginsWith)];
                        if (menuFilterClauseBeginsWith != null)
                        {
                            menuFilterClauseBeginsWith.Visible = false;
                        }

                        var menuFilterClauseEndsWith = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseEndsWith)];
                        if (menuFilterClauseEndsWith != null)
                        {
                            menuFilterClauseEndsWith.Visible = false;
                        }

                        var menuFilterClauseDoesNotContain = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseDoesNotContain)];
                        if (menuFilterClauseDoesNotContain != null)
                        {
                            menuFilterClauseDoesNotContain.Visible = false;
                        }
                        break;
                }

                return;
            }

        }


        void VisibleMenuGridColumnFilterStringAndInterger(PopupMenuShowingEventArgs e)
        {
            var menuFilterClauseLike = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseLike)];
            if (menuFilterClauseLike != null)
            {
                menuFilterClauseLike.Visible = false;
            }

            var menuFilterClauseNotLike = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseNotLike)];
            if (menuFilterClauseNotLike != null)
            {
                menuFilterClauseNotLike.Visible = false;
            }

            var menuFilterClauseLess = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseLess)];
            if (menuFilterClauseLess != null)
            {
                menuFilterClauseLess.Visible = false;
            }

            var menuFilterClauseLessOrEqual = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseLessOrEqual)];
            if (menuFilterClauseLessOrEqual != null)
            {
                menuFilterClauseLessOrEqual.Visible = false;
            }

            var menuFilterClauseGreater = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseGreater)];
            if (menuFilterClauseGreater != null)
            {
                menuFilterClauseGreater.Visible = false;
            }

            var menuFilterClauseGreaterOrEqual = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseGreaterOrEqual)];
            if (menuFilterClauseGreaterOrEqual != null)
            {
                menuFilterClauseGreaterOrEqual.Visible = false;
            }
        }

        /// <summary>
        /// Thực hiện nhảy Tab khi nhấn Enter
        /// </summary>
        /// <param name="e"></param>
        /// CreatebBy-laipv.19.08.2017
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }
        #endregion
        #region"Implement"
        [Description("Control nhập hiển thị danh sách dạng cây")]
        [Category("MControl")]
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
        public void SetFont()
        {
            this.BackColor = MColor.BackColorEditor;
            this.ForeColor = MColor.ColorLabel;
            foreach (AppearanceObject ap in this.Appearance)
            {
                ap.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);
            }

        }


        public Ctype Mtype
        {
            get { return Ctype.MTreeView; }
        }
        #endregion


       
    }
}
