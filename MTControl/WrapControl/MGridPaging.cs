using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace MTControl
{
    /// <summary>
    /// Tạo grid phân trang
    /// </summary>
    /// Create by: dvthang:04.03.2017
    public class MGridPaging : DevExpress.XtraEditors.XtraUserControl
    {
        private MGridControl grdPaging;
        private MGridView mGridView1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private MPagingGridControl tbrPaging;

        #region"Declare"


        /// <summary>
        /// Khóa chính của grid
        /// </summary>
        /// Create by: dvthang:08.03.2017
        private string keyName;

        public string KeyName
        {
            get { return keyName; }
            set { keyName = value; grdPaging.KeyName = value; }
        }
        #endregion
        #region"Contructor"
        public MGridPaging()
        {
            InitializeComponent();
            MCommon.SetSkins();
            this.grdPaging.IsShowPaging = true;
        }
        #endregion
        #region"Sub/Func"
        /// <summary>
        /// Focus vào row đầu tiên trên grid
        /// </summary>
        /// Create by: dvthang:19.03.2017
        public void SetFocusRowFirst()
        {
            grdPaging.SetFocusRowFirst();
        }
        /// <summary>
        /// Lấy về giá trị khóa chính của table
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="primaryKeyName"></param>
        /// Create by: dvthang:08.03.2017
        public  T GetValueByRowSelected<T>(string primaryKeyName)
        {
            return grdPaging.GetValueByRowSelected<T>(primaryKeyName);
        }

        /// <summary>
        /// Lấy về giá trị khóa chính của table
        /// </summary>
        /// Create by: dvthang:08.03.2017
        public T GetRecordByRowSelected<T>()
        {
            return grdPaging.GetRecordByRowSelected<T>();
        }

        /// <summary>
        /// Lấy về giá trị khóa chính của table
        /// </summary>
        /// Create by: dvthang:08.03.2017
        public List<T> GetListRecordByRowsSelected<T>()
        {
            return grdPaging.GetListRecordByRowsSelected<T>();
        }

        /// <summary>
        /// Add column vào grid
        /// </summary>
        /// <param name="column">Column của grid</param>
        /// Create by: dvthang:04.03.2017
        public MGridColumn AddColumn(MGridColumn column)
        {
            return this.grdPaging.AddColumn(column);
        }

        /// <summary>
        /// Xóa tất cả các column trên grid
        /// </summary>
        /// Create by: dvthang:19.03.2017
        public void ClearAllColumn()
        {
            this.grdPaging.ClearAllColumn();
        }
        /// <summary>
        /// Add column dạng text vào grid
        /// </summary>
        /// <param name="grd">Tên grid</param>
        /// <param name="fieldName">Tên cột</param>
        /// <param name="caption">Tiêu đề cột</param>
        /// <param name="width">Độ rộng cột</param>
        /// dvthang-08.07.2016
        public MGridColumn AddColumnText(string fieldName, string caption, int width = 50, int visibleIndex = -1,
            DataTypeColumn dataType = DataTypeColumn.None,
            bool isFixWidth = false, FixedStyle fixedStyle = FixedStyle.None,
            bool isRequired=false,int maxLength=0, string enumName="")
        {
            return this.grdPaging.AddColumnText(fieldName, caption, width, visibleIndex, dataType, isFixWidth, 
                fixedStyle, isRequired, maxLength, enumName: enumName);
        }

        /// <summary>
        /// THiết lập chế độ mutiselect row
        /// </summary>
        /// <param name="isMutiSelect">=true thì là Mutiselect, ngược lại chỉ select 1 row</param>
        /// Create by: dvthang:19.03.2017
        public void SetMutiSelectRows(bool isMutiSelect)
        {
            this.grdPaging.SetMutiSelectRows(isMutiSelect);
        }

        /// <summary>
        /// Add column dạng text vào grid
        /// </summary>
        /// <param name="grd">Tên grid</param>
        /// <param name="fieldName">Tên cột</param>
        /// <param name="caption">Tiêu đề cột</param>
        /// <param name="toolTip">toolTip cột</param>
        /// <param name="width">Độ rộng cột</param>
        /// dvthang-08.07.2016
        public MGridColumn AddColumnText(string fieldName, string caption, string toolTip, int width = 50,
            int visibleIndex = -1, DataTypeColumn dataType = DataTypeColumn.None,
            bool isFixWidth = false, FixedStyle fixedStyle = FixedStyle.None,
            bool isRequired = false, int maxLength = 0, string enumName = "")
        {
            return this.grdPaging.AddColumnText(fieldName, caption, toolTip, width, visibleIndex, dataType, 
                isFixWidth, fixedStyle, isRequired,maxLength,enumName);
        }
        /// <summary>
        /// Lấy về đối tượng grd trên form
        /// </summary>
        /// Create by: dvthang:04.03.2017
        public MGridControl GetMGridControl()
        {
            return this.grdPaging;
        }

        /// <summary>
        /// Lấy về đối tượng thanh toolbar paging của gri
        /// </summary>
        /// Create by: dvthang:04.03.2017
        public MPagingGridControl GetMTbrPaging()
        {
            return this.tbrPaging;
        }

        /// <summary>
        /// Ẩn hiện các column trên grid
        /// </summary>
        /// <param name="lstColumns">Danh sách các column cần ẩn</param>
        /// Create by: dvthang:19.03.2017
        public void SetHideColumns(params string[] lstColumns)
        {
            grdPaging.SetHideColumns(lstColumns);
        }

        /// <summary>
        /// Hiển các column trên grid
        /// </summary>
        /// <param name="lstColumns">Danh sách các column cần ẩn</param>
        /// Create by: dvthang:19.03.2017
        public void SetShowColumns(params string[] lstColumns)
        {
            grdPaging.SetShowColumns(lstColumns);
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
        #endregion
        #region"Implement"

        #endregion

        #region"Init form"
        /// <summary>
        /// Khởi tạo các thành phần trên form
        /// </summary>
        private void InitializeComponent()
        {
            this.grdPaging = new MTControl.MGridControl();
            this.mGridView1 = new MTControl.MGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbrPaging = new MTControl.MPagingGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdPaging
            // 
            this.grdPaging.Columns = null;
            this.grdPaging.Description = null;
            this.grdPaging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPaging.IsEditable = false;
            this.grdPaging.IsRemoteFilter = false;
            this.grdPaging.IsSetValueManual = false;
            this.grdPaging.IsShowDetailButtons = false;
            this.grdPaging.IsShowFilter = false;
            this.grdPaging.IsShowHorizontalLine = false;
            this.grdPaging.IsShowPaging = false;
            this.grdPaging.IsShowVerticalLine = false;
            this.grdPaging.KeyName = null;
            this.grdPaging.Location = new System.Drawing.Point(3, 3);
            this.grdPaging.MainView = this.mGridView1;
            this.grdPaging.Name = "grdPaging";
            this.grdPaging.SetField = null;
            this.grdPaging.Size = new System.Drawing.Size(772, 446);
            this.grdPaging.Sort = null;
            this.grdPaging.Sumary = null;
            this.grdPaging.TabIndex = 0;
            this.grdPaging.TableName = null;
            this.grdPaging.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mGridView1});
            this.grdPaging.ViewName = null;
            // 
            // mGridView1
            // 
            this.mGridView1.GridControl = this.grdPaging;
            this.mGridView1.Name = "mGridView1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grdPaging, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(778, 482);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbrPaging);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 455);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 24);
            this.panel1.TabIndex = 1;
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
            this.tbrPaging.Location = new System.Drawing.Point(0, 0);
            this.tbrPaging.Margin = new System.Windows.Forms.Padding(0);
            this.tbrPaging.Name = "tbrPaging";
            this.tbrPaging.Size = new System.Drawing.Size(772, 24);
            this.tbrPaging.TabIndex = 0;
            // 
            // MGridPaging
            // 
            this.AllowDrop = true;
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.Controls.Add(this.tableLayoutPanel1);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "MGridPaging";
            this.Size = new System.Drawing.Size(778, 482);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }       
        #endregion
       
    }


   
}
