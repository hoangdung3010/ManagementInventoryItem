using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.Collections.Generic;
using DevExpress.XtraEditors.Repository;
using System;
using MTControl;

namespace MTControl
{
    public class MFormQuickSearch : MFormBase
    {
        
        #region"Declare"
        private MLayoutControl mLayoutControl1;
        private MComboBox cboObject;
        private LayoutControlItem layoutControlItem2;
        private MTextEdit txtSeachValue;
        private LayoutControlItem layoutControlItem1;
        private MSimpleButton btnSearch;
        private LayoutControlItem layoutControlItem3;
        private MLayoutControl mLayoutControl2;
        private MGridControl grdQuickSearch;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewColumn;
        private LayoutControlGroup layoutControlGroup2;
        private LayoutControlItem layoutControlItem4;
        private MLayoutControl mLayoutControl3;
        private LayoutControlGroup btnOK;
        private MSimpleButton mSimpleButton2;
        private LayoutControlItem layoutControlItem5;
        private MSimpleButton btnClose;
        private LayoutControlItem layoutControlItem6;
        private MLayoutControl mLayoutControl4;
        private LayoutControlGroup Root;
        private LayoutControlItem layoutControlItem7;
        private LayoutControlGroup layoutControlGroup1;

        //Store load dữ liệu cho grid
        private string storeName;

        public string StoreName
        {
            get { return storeName; }
            set { storeName = value; }
        }

        public bool IsMutiSelect { get; set; }

        public string Columns { get; set; }
        #endregion

        #region"Contructor"
        public MFormQuickSearch()
        {
            InitializeComponent();
            InitGrid();
        }

        public MFormQuickSearch(bool isMutiSelect)
        {
            this.IsMutiSelect = isMutiSelect;
            InitializeComponent();
            InitGrid();
        }

        //Khởi tạo form
        private void InitializeComponent()
        {
            this.mLayoutControl1 = new MTControl.MLayoutControl();
            this.btnSearch = new MTControl.MSimpleButton();
            this.cboObject = new MTControl.MComboBox();
            this.txtSeachValue = new MTControl.MTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.mLayoutControl2 = new MTControl.MLayoutControl();
            this.grdQuickSearch = new MTControl.MGridControl();
            this.grdViewColumn = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.mLayoutControl3 = new MTControl.MLayoutControl();
            this.mLayoutControl4 = new MTControl.MLayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.btnClose = new MTControl.MSimpleButton();
            this.mSimpleButton2 = new MTControl.MSimpleButton();
            this.btnOK = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.mLayoutControl1)).BeginInit();
            this.mLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mLayoutControl2)).BeginInit();
            this.mLayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuickSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mLayoutControl3)).BeginInit();
            this.mLayoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mLayoutControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // mLayoutControl1
            // 
            this.mLayoutControl1.Controls.Add(this.btnSearch);
            this.mLayoutControl1.Controls.Add(this.cboObject);
            this.mLayoutControl1.Controls.Add(this.txtSeachValue);
            this.mLayoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.mLayoutControl1.Name = "mLayoutControl1";
            this.mLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(398, 267, 250, 350);
            this.mLayoutControl1.Root = this.layoutControlGroup1;
            this.mLayoutControl1.Size = new System.Drawing.Size(576, 29);
            this.mLayoutControl1.TabIndex = 0;
            this.mLayoutControl1.Text = "mLayoutControl1";
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnSearch.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSearch.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch.Appearance.Options.UseBackColor = true;
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Appearance.Options.UseForeColor = true;
            this.btnSearch.Description = null;
            this.btnSearch.Image = global::MTControl.Properties.Resources.search;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(462, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.btnSearch.Size = new System.Drawing.Size(110, 25);
            this.btnSearch.StyleController = this.mLayoutControl1;
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_OnClick);
            // 
            // cboObject
            // 
            this.cboObject.SetField = null;
            this.cboObject.DefaultValueEnum = -1;
            this.cboObject.Description = null;
            this.cboObject.EntityName = false;
            this.cboObject.EnumData = null;
            this.cboObject.IsAutoLoad = false;
            this.cboObject.IsSetValueManual = false;
            this.cboObject.LastAcceptedSelectedIndex = 0;
            this.cboObject.Location = new System.Drawing.Point(89, 2);
            this.cboObject.Name = "cboObject";
            this.cboObject.Size = new System.Drawing.Size(112, 25);
            this.cboObject.StyleController = this.mLayoutControl1;
            this.cboObject.TabIndex = 5;
            // 
            // txtSeachValue
            // 
            this.txtSeachValue.SetField = null;
            this.txtSeachValue.Description = null;
            this.txtSeachValue.IsCustomHeight = false;
            this.txtSeachValue.IsSetValueManual = false;
            this.txtSeachValue.Location = new System.Drawing.Point(290, 2);
            this.txtSeachValue.MaxLength = 0;
            this.txtSeachValue.Name = "txtSeachValue";
            this.txtSeachValue.Size = new System.Drawing.Size(168, 25);
            this.txtSeachValue.StyleController = this.mLayoutControl1;
            this.txtSeachValue.TabIndex = 6;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.layoutControlGroup1.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(576, 29);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cboObject;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(127, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 2, 2, 2);
            this.layoutControlItem2.Size = new System.Drawing.Size(203, 29);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Loại đối tượng";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(82, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtSeachValue;
            this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem1.Location = new System.Drawing.Point(203, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(125, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(257, 29);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Mã/Tên";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(82, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnSearch;
            this.layoutControlItem3.Location = new System.Drawing.Point(460, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(116, 29);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(116, 29);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 4, 2, 2);
            this.layoutControlItem3.Size = new System.Drawing.Size(116, 29);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // mLayoutControl2
            // 
            this.mLayoutControl2.Controls.Add(this.grdQuickSearch);
            this.mLayoutControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.mLayoutControl2.Location = new System.Drawing.Point(0, 29);
            this.mLayoutControl2.Name = "mLayoutControl2";
            this.mLayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(448, 225, 250, 350);
            this.mLayoutControl2.Root = this.layoutControlGroup2;
            this.mLayoutControl2.Size = new System.Drawing.Size(576, 380);
            this.mLayoutControl2.TabIndex = 1;
            this.mLayoutControl2.Text = "mLayoutControl2";
            // 
            // grdQuickSearch
            // 
            this.grdQuickSearch.Columns = null;
            this.grdQuickSearch.Description = null;
            this.grdQuickSearch.IsEditable = false;
            this.grdQuickSearch.IsSetValueManual = false;
            this.grdQuickSearch.IsShowDetailButtons = false;
            this.grdQuickSearch.IsShowHorizontalLine = false;
            this.grdQuickSearch.IsShowPaging = false;
            this.grdQuickSearch.IsShowVerticalLine = false;
            this.grdQuickSearch.KeyName = null;
            this.grdQuickSearch.Location = new System.Drawing.Point(6, 6);
            this.grdQuickSearch.MainView = this.grdViewColumn;
            this.grdQuickSearch.Name = "grdQuickSearch";
            this.grdQuickSearch.Size = new System.Drawing.Size(564, 368);
            this.grdQuickSearch.Sort = null;
            this.grdQuickSearch.TabIndex = 4;
            this.grdQuickSearch.TableName = null;
            this.grdQuickSearch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewColumn});
            // 
            // grdViewColumn
            // 
            this.grdViewColumn.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.grdViewColumn.Appearance.EvenRow.BackColor2 = System.Drawing.Color.White;
            this.grdViewColumn.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.grdViewColumn.Appearance.EvenRow.Options.UseBackColor = true;
            this.grdViewColumn.Appearance.EvenRow.Options.UseForeColor = true;
            this.grdViewColumn.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.grdViewColumn.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.grdViewColumn.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grdViewColumn.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grdViewColumn.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grdViewColumn.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.grdViewColumn.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.grdViewColumn.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grdViewColumn.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grdViewColumn.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grdViewColumn.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdViewColumn.Appearance.GroupRow.Options.UseFont = true;
            this.grdViewColumn.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdViewColumn.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdViewColumn.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.grdViewColumn.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grdViewColumn.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grdViewColumn.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grdViewColumn.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdViewColumn.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.grdViewColumn.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.grdViewColumn.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.grdViewColumn.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grdViewColumn.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grdViewColumn.Appearance.OddRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grdViewColumn.Appearance.OddRow.BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.grdViewColumn.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grdViewColumn.Appearance.OddRow.Options.UseBackColor = true;
            this.grdViewColumn.Appearance.OddRow.Options.UseForeColor = true;
            this.grdViewColumn.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdViewColumn.Appearance.Row.Options.UseFont = true;
            this.grdViewColumn.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grdViewColumn.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grdViewColumn.GridControl = this.grdQuickSearch;
            this.grdViewColumn.Name = "grdViewColumn";
            this.grdViewColumn.OptionsBehavior.Editable = false;
            this.grdViewColumn.OptionsBehavior.ReadOnly = true;
            this.grdViewColumn.OptionsCustomization.AllowColumnMoving = false;
            this.grdViewColumn.OptionsCustomization.AllowFilter = false;
            this.grdViewColumn.OptionsCustomization.AllowSort = false;
            this.grdViewColumn.OptionsFind.AllowFindPanel = false;
            this.grdViewColumn.OptionsMenu.EnableColumnMenu = false;
            this.grdViewColumn.OptionsView.EnableAppearanceEvenRow = true;
            this.grdViewColumn.OptionsView.EnableAppearanceOddRow = true;
            this.grdViewColumn.OptionsView.ShowDetailButtons = false;
            this.grdViewColumn.OptionsView.ShowGroupPanel = false;
            this.grdViewColumn.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grdViewColumn.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.layoutControlGroup2.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.layoutControlGroup2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup2.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "Root";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup2.Size = new System.Drawing.Size(576, 380);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.grdQuickSearch;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(568, 372);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // mLayoutControl3
            // 
            this.mLayoutControl3.Controls.Add(this.mLayoutControl4);
            this.mLayoutControl3.Controls.Add(this.btnClose);
            this.mLayoutControl3.Controls.Add(this.mSimpleButton2);
            this.mLayoutControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mLayoutControl3.Location = new System.Drawing.Point(0, 409);
            this.mLayoutControl3.Name = "mLayoutControl3";
            this.mLayoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(448, 104, 250, 350);
            this.mLayoutControl3.Root = this.btnOK;
            this.mLayoutControl3.Size = new System.Drawing.Size(576, 41);
            this.mLayoutControl3.TabIndex = 2;
            this.mLayoutControl3.Text = "mLayoutControl3";
            // 
            // mLayoutControl4
            // 
            this.mLayoutControl4.Location = new System.Drawing.Point(6, 6);
            this.mLayoutControl4.Name = "mLayoutControl4";
            this.mLayoutControl4.Root = this.Root;
            this.mLayoutControl4.Size = new System.Drawing.Size(390, 29);
            this.mLayoutControl4.TabIndex = 6;
            this.mLayoutControl4.Text = "mLayoutControl4";
            // 
            // Root
            // 
            this.Root.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.Root.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Root.AppearanceItemCaption.Options.UseFont = true;
            this.Root.AppearanceItemCaption.Options.UseForeColor = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(390, 29);
            this.Root.TextVisible = false;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Description = null;
            this.btnClose.Image = global::MTControl.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(483, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 29);
            this.btnClose.StyleController = this.mLayoutControl3;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Hủy bỏ";
            this.btnClose.Click += new System.EventHandler(this.btnCancel_OnClick);
            // 
            // mSimpleButton2
            // 
            this.mSimpleButton2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mSimpleButton2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mSimpleButton2.Appearance.Options.UseFont = true;
            this.mSimpleButton2.Appearance.Options.UseForeColor = true;
            this.mSimpleButton2.Description = null;
            this.mSimpleButton2.Image = global::MTControl.Properties.Resources.ok;
            this.mSimpleButton2.Location = new System.Drawing.Point(400, 6);
            this.mSimpleButton2.Name = "mSimpleButton2";
            this.mSimpleButton2.Size = new System.Drawing.Size(79, 29);
            this.mSimpleButton2.StyleController = this.mLayoutControl3;
            this.mSimpleButton2.TabIndex = 4;
            this.mSimpleButton2.Text = "Chọn";
            this.mSimpleButton2.Click += new System.EventHandler(this.btnOK_OnClick);
            // 
            // btnOK
            // 
            this.btnOK.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnOK.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOK.AppearanceItemCaption.Options.UseFont = true;
            this.btnOK.AppearanceItemCaption.Options.UseForeColor = true;
            this.btnOK.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.btnOK.GroupBordersVisible = false;
            this.btnOK.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.btnOK.Location = new System.Drawing.Point(0, 0);
            this.btnOK.Name = "Root";
            this.btnOK.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.btnOK.Size = new System.Drawing.Size(576, 41);
            this.btnOK.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.mSimpleButton2;
            this.layoutControlItem5.Location = new System.Drawing.Point(394, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(83, 33);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(83, 33);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(83, 33);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnClose;
            this.layoutControlItem6.Location = new System.Drawing.Point(477, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(91, 33);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(91, 33);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(91, 33);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.mLayoutControl4;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(394, 33);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // MFormQuickSearch
            // 
            this.ClientSize = new System.Drawing.Size(576, 450);
            this.Controls.Add(this.mLayoutControl3);
            this.Controls.Add(this.mLayoutControl2);
            this.Controls.Add(this.mLayoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MFormQuickSearch";
            this.Text = "Chọn đối tượng";
            this.Load += new System.EventHandler(this.frmFormQuickSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mLayoutControl1)).EndInit();
            this.mLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mLayoutControl2)).EndInit();
            this.mLayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdQuickSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mLayoutControl3)).EndInit();
            this.mLayoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mLayoutControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion


        #region"Sub/Func"
       
        /// <summary>
        /// Tạo động column grid
        /// </summary>
        /// dvthang-03.07.2016
        protected virtual void InitGrid()
        {
            if (!string.IsNullOrEmpty(Columns))
            {
                string[] strColumns = this.Columns.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                if (strColumns != null)
                {

                    foreach (string colName in strColumns)
                    {
                        MGridColumn column = new MGridColumn();
                        column.FieldName = colName;
                        column.Caption = "";//Đọc từ resources ra
                        grdViewColumn.Columns.Add(column);
                        column.Visible = true;
                    }
                    //Nếu cho phép chọn nhiều thì sinh thêm 1 cột IsSelect
                    if (IsMutiSelect)
                    {
                        RepositoryItemCheckEdit checkEdit = grdQuickSearch.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
                        checkEdit.ValueChecked = "True";
                        checkEdit.ValueUnchecked = "False";
                        grdViewColumn.Columns["IsSelect"].ColumnEdit = checkEdit;
                    }

                }
            }
        }

        /// <summary>
        /// Load data cho grid
        /// </summary>
        /// dvthang-03.07.2016
        protected virtual void LoadDataForGrid()
        {
            string vValue = txtSeachValue.Text;

            //todo
            grdQuickSearch.DataSource = null;
        }

        /// <summary>
        /// Load source cho combo tiêu chi tìm kiếm
        /// </summary>
        /// dvthang-03.07.2016
        protected virtual void LoadDataForCombo()
        {
            if (!string.IsNullOrEmpty(Columns))
            {
                string[] strColumns = this.Columns.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                if (strColumns != null)
                {

                    foreach (string colName in strColumns)
                    {
                        cboObject.Properties.Items.Add(colName);
                    }
                }
            }
        }
        #endregion
       
        #region"Ovrrides"

        #endregion

        #region"Event"
        /// <summary>
        /// Load data cho form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// dvthang-03.07.2016
        private void frmFormQuickSearch_Load(object sender, System.EventArgs e)
        {
            LoadDataForCombo();
            LoadDataForGrid();

        }

        /// <summary>
        /// Nhấn nút tìm kiếm trên form sẽ load lại data cho grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// dvthang-03.07.2016
        private void btnSearch_OnClick(object sender, System.EventArgs e)
        {
            LoadDataForGrid();
        }

        /// <summary>
        /// Nhấn nút chọn sẽ đẩy dữ liệu được chọn xuống form danh sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// dvthang-03.07.2016
        private void btnOK_OnClick(object sender, System.EventArgs e)
        {
            MessageBox.Show("Chưa xử lý gì ở đây cả");
            int[] index = grdViewColumn.GetSelectedRows();
            if (index.Length > 0)
            {
                
            }
            else
            {
                MessageBox.Show("Bạn phải chọn ít nhất một bản ghi. Vui lòng kiểm tra lại.");
            }
        }

        /// <summary>
        /// Nhấn nút hủy bỏ thì đóng form lại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// dvthang-03.07.2016
        private void btnCancel_OnClick(object sender, System.EventArgs e)
        {
            this.Close();
           
        }
        #endregion

        #region"Implement"

        #endregion
    }
}
