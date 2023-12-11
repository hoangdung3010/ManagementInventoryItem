using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;

namespace MTControl
{
    /// <summary>
    /// Tạo tree phân trang
    /// </summary>
    /// Create by: dvthang:04.03.2017
    public class MTreePaging : DevExpress.XtraEditors.XtraUserControl
    {
        
        #region"Declare"
        private TableLayoutPanel tableLayoutPanel1;
        private MTreeView treeList;
        private MPagingGridControl tbrPaging;
        /// <summary>
        /// Khóa chính của grid
        /// </summary>
        /// Create by: dvthang:08.03.2017
        private string keyName;

        public string KeyName
        {
            get { return keyName; }
            set { keyName = value; treeList.KeyName = value; }
        }
        #endregion
        #region"Contructor"
        public MTreePaging()
        {
            InitializeComponent();
            MCommon.SetSkins();
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
            return treeList.GetValueByRowSelected<T>(column);
        }

        /// <summary>
        ///Lấy về thông tin bản ghi được chọn trên treeList
        /// </summary>
        /// Create by: dvthang:08.03.2017
        public T GetDataByRowSelected<T>()
        {
            return treeList.GetDataByRowSelected<T>();
        }

        /// <summary>
        ///Lấy về tất cả các thông tin được chọn được chọn trên treeList
        /// </summary>
        /// Create by: dvthang:08.03.2017
        public List<T> GetListDataByRowsSelected<T>()
        {
            return treeList.GetListDataByRowsSelected<T>();
        }
       
        /// <summary>
        /// Add column vào tree
        /// </summary>
        /// <param name="column">Column của tree</param>
        /// Create by: dvthang:04.03.2017
        public TreeListColumn AddColumn(TreeListColumn column)
        {
            return treeList.AddColumn(column);
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
            bool isFixWidth=false, DevExpress.XtraTreeList.Columns.FixedStyle fixedStyle=DevExpress.XtraTreeList.Columns.FixedStyle.None)
        {
            return treeList.AddColumnText(fieldName, caption, width, dataType, isFixWidth, fixedStyle);
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
        public TreeListColumn AddColumnText(string fieldName, string caption, string toolTip,int width = 50, DataTypeColumn dataType = DataTypeColumn.None, 
            bool isFixWidth = false, DevExpress.XtraTreeList.Columns.FixedStyle fixedStyle = DevExpress.XtraTreeList.Columns.FixedStyle.None)
        {
            return treeList.AddColumnText(fieldName, caption, toolTip, width, dataType, isFixWidth, fixedStyle);
        }

        /// <summary>
        /// Lấy về đối tượng grd trên form
        /// </summary>
        /// Create by: dvthang:04.03.2017
        public MTreeView GetMTreeControl()
        {
            return this.treeList;
        }

        /// <summary>
        /// Lấy về đối tượng thanh toolbar paging của gri
        /// </summary>
        /// Create by: dvthang:04.03.2017
        public MPagingGridControl GetMTbrPaging()
        {
            return this.tbrPaging;
        }
        #endregion
        #region"Ovrrides"
       
        /// <summary>
        /// ovrides lại hàm render control
        /// </summary>
        /// dvthang-17.07.2016
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);

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
        /// <summary>
        /// Ẩn hiện các column trên grid
        /// </summary>
        /// <param name="lstColumns">Danh sách các column cần ẩn</param>
        /// Create by: dvthang:19.03.2017
        public void SetHideColumns(params string[] lstColumns)
        {
            if (treeList != null)
            {
                treeList.SetHideColumns(lstColumns);
            }
        }

        /// <summary>
        /// Hiển thị các column trên grid
        /// </summary>
        /// <param name="lstColumns">Danh sách các column cần ẩn</param>
        /// Create by: dvthang:19.03.2017
        public void SetShowColumns(params string[] lstColumns)
        {
            if (treeList != null)
            {
                treeList.SetShowColumns(lstColumns);
            }
        }

        #endregion
        #region"Implement"

        #endregion

        #region"Init form"
        /// <summary>
        /// Khởi tạo các thành phần trên form
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbrPaging = new MTControl.MPagingGridControl();
            this.treeList = new MTControl.MTreeView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tbrPaging, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.treeList, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(778, 488);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbrPaging
            // 
            this.tbrPaging.AllowDrop = true;
            this.tbrPaging.Appearance.BackColor = System.Drawing.Color.White;
            this.tbrPaging.Appearance.BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.tbrPaging.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tbrPaging.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbrPaging.Appearance.Options.UseBackColor = true;
            this.tbrPaging.Appearance.Options.UseBorderColor = true;
            this.tbrPaging.Appearance.Options.UseFont = true;
            this.tbrPaging.Appearance.Options.UseTextOptions = true;
            this.tbrPaging.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tbrPaging.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tbrPaging.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.tbrPaging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbrPaging.EventHandlerPaging = null;
            this.tbrPaging.EventHandlerShowRecord = null;
            this.tbrPaging.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbrPaging.Location = new System.Drawing.Point(0, 465);
            this.tbrPaging.Margin = new System.Windows.Forms.Padding(0);
            this.tbrPaging.Name = "tbrPaging";
            this.tbrPaging.Size = new System.Drawing.Size(778, 23);
            this.tbrPaging.TabIndex = 0;
            // 
            // treeList
            // 
            this.treeList.Appearance.BandPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.BandPanel.Options.UseFont = true;
            this.treeList.Appearance.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.Caption.Options.UseFont = true;
            this.treeList.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.treeList.Appearance.Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.Empty.Options.UseFont = true;
            this.treeList.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.treeList.Appearance.EvenRow.BackColor2 = System.Drawing.Color.White;
            this.treeList.Appearance.EvenRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treeList.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeList.Appearance.EvenRow.Options.UseFont = true;
            this.treeList.Appearance.EvenRow.Options.UseForeColor = true;
            this.treeList.Appearance.FilterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.FilterPanel.Options.UseFont = true;
            this.treeList.Appearance.FixedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.FixedLine.Options.UseFont = true;
            this.treeList.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.treeList.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.treeList.Appearance.FocusedCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.treeList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeList.Appearance.FocusedCell.Options.UseFont = true;
            this.treeList.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeList.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.treeList.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.treeList.Appearance.FocusedRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.treeList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeList.Appearance.FocusedRow.Options.UseFont = true;
            this.treeList.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treeList.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.FooterPanel.Options.UseFont = true;
            this.treeList.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.GroupButton.Options.UseFont = true;
            this.treeList.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.GroupFooter.Options.UseFont = true;
            this.treeList.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(199)))), ((int)(((byte)(231)))));
            this.treeList.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(199)))), ((int)(((byte)(231)))));
            this.treeList.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(199)))), ((int)(((byte)(231)))));
            this.treeList.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treeList.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.treeList.Appearance.HeaderPanel.Options.UseFont = true;
            this.treeList.Appearance.HeaderPanelBackground.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.HeaderPanelBackground.Options.UseFont = true;
            this.treeList.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.treeList.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.treeList.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treeList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeList.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treeList.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treeList.Appearance.HorzLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.HorzLine.Options.UseFont = true;
            this.treeList.Appearance.OddRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.treeList.Appearance.OddRow.BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.treeList.Appearance.OddRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treeList.Appearance.OddRow.Options.UseBackColor = true;
            this.treeList.Appearance.OddRow.Options.UseFont = true;
            this.treeList.Appearance.OddRow.Options.UseForeColor = true;
            this.treeList.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.Preview.Options.UseFont = true;
            this.treeList.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.Row.Options.UseFont = true;
            this.treeList.Appearance.SelectedRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.SelectedRow.Options.UseFont = true;
            this.treeList.Appearance.Separator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.Separator.Options.UseFont = true;
            this.treeList.Appearance.TreeLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.TreeLine.Options.UseFont = true;
            this.treeList.Appearance.VertLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treeList.Appearance.VertLine.Options.UseFont = true;
            this.treeList.Description = null;
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.KeyName = null;
            this.treeList.Location = new System.Drawing.Point(0, 0);
            this.treeList.Margin = new System.Windows.Forms.Padding(0);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.ReadOnly = true;
            this.treeList.OptionsCustomization.AllowColumnMoving = false;
            this.treeList.OptionsFind.AllowFindPanel = false;
            this.treeList.OptionsMenu.EnableColumnMenu = false;
            this.treeList.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList.OptionsView.EnableAppearanceOddRow = true;
            this.treeList.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this.treeList.Size = new System.Drawing.Size(778, 465);
            this.treeList.Sumary = null;
            this.treeList.TabIndex = 1;
            this.treeList.TableName = null;
            this.treeList.ViewName = null;
            // 
            // MTreePaging
            // 
            this.AllowDrop = true;
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.Controls.Add(this.tableLayoutPanel1);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "MTreePaging";
            this.Size = new System.Drawing.Size(778, 488);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            this.ResumeLayout(false);

        }       
        #endregion
       
    }


   
}
