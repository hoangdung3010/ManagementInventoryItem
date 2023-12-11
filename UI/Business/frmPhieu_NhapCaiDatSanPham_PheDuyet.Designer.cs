
namespace FormUI
{
    partial class frmPhieu_NhapCaiDatSanPham_PheDuyet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieu_NhapCaiDatSanPham_PheDuyet));
            this.panel1 = new System.Windows.Forms.Panel();
            this.mGroupControl1 = new MTControl.MGroupControl();
            this.grdPhieuXuatCD = new MTControl.MGridEditable();
            this.cboiTrangThaiDuyet = new MTControl.MComboBox();
            this.txtsLyDoDuyet = new MTControl.MTextEdit();
            this.mLabel16 = new MTControl.MLabel();
            this.mLabel15 = new MTControl.MLabel();
            this.gunaControlBoxMaximumOrMiximum = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBoxClose = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBoxHide = new Guna.UI.WinForms.GunaControlBox();
            this.gunaResize1 = new Guna.UI.WinForms.GunaResize(this.components);
            this.gunaDragControl2 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.mSimpleButton1 = new MTControl.MSimpleButton();
            this.btnHelp = new MTControl.MSimpleButton();
            this.btnCancel = new MTControl.MSimpleButton();
            this.btnSave = new MTControl.MSimpleButton();
            this.lblTitleFormDetail = new MTControl.MLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mGroupControl1)).BeginInit();
            this.mGroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPhieuXuatCD.GrdDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.mGroupControl1);
            this.panel1.Controls.Add(this.cboiTrangThaiDuyet);
            this.panel1.Controls.Add(this.txtsLyDoDuyet);
            this.panel1.Controls.Add(this.mLabel16);
            this.panel1.Controls.Add(this.mLabel15);
            this.panel1.Location = new System.Drawing.Point(7, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 408);
            this.panel1.TabIndex = 66;
            // 
            // mGroupControl1
            // 
            this.mGroupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mGroupControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mGroupControl1.Appearance.Options.UseForeColor = true;
            this.mGroupControl1.ColumnName = "";
            this.mGroupControl1.Controls.Add(this.grdPhieuXuatCD);
            this.mGroupControl1.Description = null;
            this.mGroupControl1.Location = new System.Drawing.Point(9, 73);
            this.mGroupControl1.Name = "mGroupControl1";
            this.mGroupControl1.Size = new System.Drawing.Size(890, 325);
            this.mGroupControl1.TabIndex = 66;
            this.mGroupControl1.Text = "Danh sách phiếu";
            // 
            // grdPhieuXuatCD
            // 
            this.grdPhieuXuatCD.AllowDrop = true;
            this.grdPhieuXuatCD.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdPhieuXuatCD.Appearance.Options.UseFont = true;
            this.grdPhieuXuatCD.Appearance.Options.UseTextOptions = true;
            this.grdPhieuXuatCD.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdPhieuXuatCD.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdPhieuXuatCD.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grdPhieuXuatCD.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // grdPhieuXuatCD.MGridEditable
            // 
            this.grdPhieuXuatCD.GrdDetail.Columns = null;
            this.grdPhieuXuatCD.GrdDetail.ColumnSortInfoCollectionChanged = null;
            this.grdPhieuXuatCD.GrdDetail.CustomModelFields = null;
            this.grdPhieuXuatCD.GrdDetail.CustomRowCellEditing = null;
            this.grdPhieuXuatCD.GrdDetail.Description = null;
            this.grdPhieuXuatCD.GrdDetail.DisableFieldNames = null;
            this.grdPhieuXuatCD.GrdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPhieuXuatCD.GrdDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdPhieuXuatCD.GrdDetail.FilterObjects = null;
            this.grdPhieuXuatCD.GrdDetail.FuncCustomRecordBeforeAddRow = null;
            this.grdPhieuXuatCD.GrdDetail.IsEditable = true;
            this.grdPhieuXuatCD.GrdDetail.IsHideActionAdd = false;
            this.grdPhieuXuatCD.GrdDetail.IsRemoteFilter = false;
            this.grdPhieuXuatCD.GrdDetail.IsSetValueManual = false;
            this.grdPhieuXuatCD.GrdDetail.IsShowDetailButtons = false;
            this.grdPhieuXuatCD.GrdDetail.IsShowFilter = false;
            this.grdPhieuXuatCD.GrdDetail.IsShowHorizontalLine = false;
            this.grdPhieuXuatCD.GrdDetail.IsShowPaging = false;
            this.grdPhieuXuatCD.GrdDetail.IsShowVerticalLine = false;
            this.grdPhieuXuatCD.GrdDetail.KeyName = null;
            this.grdPhieuXuatCD.GrdDetail.Location = new System.Drawing.Point(0, 0);
            this.grdPhieuXuatCD.GrdDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdPhieuXuatCD.GrdDetail.MarkLoading = false;
            this.grdPhieuXuatCD.GrdDetail.Name = "MGridEditable";
            this.grdPhieuXuatCD.GrdDetail.RowCellStyle = null;
            this.grdPhieuXuatCD.GrdDetail.SetField = null;
            this.grdPhieuXuatCD.GrdDetail.Size = new System.Drawing.Size(886, 270);
            this.grdPhieuXuatCD.GrdDetail.Sort = null;
            this.grdPhieuXuatCD.GrdDetail.StartRemoteFilterRow = null;
            this.grdPhieuXuatCD.GrdDetail.Sumary = null;
            this.grdPhieuXuatCD.GrdDetail.TabIndex = 0;
            this.grdPhieuXuatCD.GrdDetail.TableName = null;
            this.grdPhieuXuatCD.GrdDetail.UserCustomDrawCell = null;
            this.grdPhieuXuatCD.GrdDetail.ValidEditValueChanging = null;
            this.grdPhieuXuatCD.GrdDetail.ViewName = null;
            this.grdPhieuXuatCD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdPhieuXuatCD.InvalidText = null;
            this.grdPhieuXuatCD.IsHideActionAdd = false;
            this.grdPhieuXuatCD.IsRequired = false;
            this.grdPhieuXuatCD.Location = new System.Drawing.Point(2, 21);
            this.grdPhieuXuatCD.Name = "grdPhieuXuatCD";
            this.grdPhieuXuatCD.Size = new System.Drawing.Size(886, 302);
            this.grdPhieuXuatCD.TabIndex = 0;
            // 
            // cboiTrangThaiDuyet
            // 
            this.cboiTrangThaiDuyet.DefaultValueEnum = -1;
            this.cboiTrangThaiDuyet.Description = null;
            this.cboiTrangThaiDuyet.EntityName = false;
            this.cboiTrangThaiDuyet.EnumData = null;
            this.cboiTrangThaiDuyet.Grid = null;
            this.cboiTrangThaiDuyet.IsAutoLoad = false;
            this.cboiTrangThaiDuyet.IsReadOnly = false;
            this.cboiTrangThaiDuyet.IsRequired = true;
            this.cboiTrangThaiDuyet.IsSetValueManual = false;
            this.cboiTrangThaiDuyet.LastAcceptedSelectedIndex = 0;
            this.cboiTrangThaiDuyet.Location = new System.Drawing.Point(113, 16);
            this.cboiTrangThaiDuyet.Name = "cboiTrangThaiDuyet";
            this.cboiTrangThaiDuyet.NoDefaultValue = false;
            this.cboiTrangThaiDuyet.RepositoryItem = null;
            this.cboiTrangThaiDuyet.SetField = "iTrangThaiDuyet";
            this.cboiTrangThaiDuyet.Size = new System.Drawing.Size(178, 23);
            this.cboiTrangThaiDuyet.TabIndex = 62;
            // 
            // txtsLyDoDuyet
            // 
            this.txtsLyDoDuyet.AutoIncrement = false;
            this.txtsLyDoDuyet.Description = null;
            this.txtsLyDoDuyet.Grid = null;
            this.txtsLyDoDuyet.IsCustomHeight = false;
            this.txtsLyDoDuyet.IsReadOnly = false;
            this.txtsLyDoDuyet.IsSetValueManual = false;
            this.txtsLyDoDuyet.Location = new System.Drawing.Point(113, 45);
            this.txtsLyDoDuyet.MaxLength = 255;
            this.txtsLyDoDuyet.Name = "txtsLyDoDuyet";
            this.txtsLyDoDuyet.RepositoryItem = null;
            this.txtsLyDoDuyet.SetField = "sLyDoXetDuyet";
            this.txtsLyDoDuyet.Size = new System.Drawing.Size(393, 22);
            this.txtsLyDoDuyet.TabIndex = 63;
            // 
            // mLabel16
            // 
            this.mLabel16.AllowHtmlString = true;
            this.mLabel16.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel16.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel16.Appearance.Options.UseFont = true;
            this.mLabel16.Appearance.Options.UseForeColor = true;
            this.mLabel16.Appearance.Options.UseTextOptions = true;
            this.mLabel16.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel16.ColumnName = "";
            this.mLabel16.Description = null;
            this.mLabel16.IsRequired = false;
            this.mLabel16.Location = new System.Drawing.Point(9, 49);
            this.mLabel16.Name = "mLabel16";
            this.mLabel16.Size = new System.Drawing.Size(26, 13);
            this.mLabel16.TabIndex = 65;
            this.mLabel16.Text = "Lý do";
            // 
            // mLabel15
            // 
            this.mLabel15.AllowHtmlString = true;
            this.mLabel15.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel15.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel15.Appearance.Options.UseFont = true;
            this.mLabel15.Appearance.Options.UseForeColor = true;
            this.mLabel15.Appearance.Options.UseTextOptions = true;
            this.mLabel15.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel15.ColumnName = "";
            this.mLabel15.Description = null;
            this.mLabel15.IsRequired = true;
            this.mLabel15.Location = new System.Drawing.Point(9, 20);
            this.mLabel15.Name = "mLabel15";
            this.mLabel15.Size = new System.Drawing.Size(51, 16);
            this.mLabel15.TabIndex = 64;
            this.mLabel15.Text = "Trạng thái<color=255, 0, 0><size=13>*</size></color>";
            // 
            // gunaControlBoxMaximumOrMiximum
            // 
            this.gunaControlBoxMaximumOrMiximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBoxMaximumOrMiximum.Animated = true;
            this.gunaControlBoxMaximumOrMiximum.AnimationHoverSpeed = 0.07F;
            this.gunaControlBoxMaximumOrMiximum.AnimationSpeed = 0.03F;
            this.gunaControlBoxMaximumOrMiximum.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MaximizeBox;
            this.gunaControlBoxMaximumOrMiximum.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(85)))), ((int)(((byte)(244)))));
            this.gunaControlBoxMaximumOrMiximum.IconSize = 12F;
            this.gunaControlBoxMaximumOrMiximum.Location = new System.Drawing.Point(877, 0);
            this.gunaControlBoxMaximumOrMiximum.MaximumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxMaximumOrMiximum.MinimumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxMaximumOrMiximum.Name = "gunaControlBoxMaximumOrMiximum";
            this.gunaControlBoxMaximumOrMiximum.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaControlBoxMaximumOrMiximum.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBoxMaximumOrMiximum.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBoxMaximumOrMiximum.Size = new System.Drawing.Size(20, 20);
            this.gunaControlBoxMaximumOrMiximum.TabIndex = 8;
            // 
            // gunaControlBoxClose
            // 
            this.gunaControlBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBoxClose.Animated = true;
            this.gunaControlBoxClose.AnimationHoverSpeed = 0.07F;
            this.gunaControlBoxClose.AnimationSpeed = 0.03F;
            this.gunaControlBoxClose.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(85)))), ((int)(((byte)(244)))));
            this.gunaControlBoxClose.IconSize = 12F;
            this.gunaControlBoxClose.Location = new System.Drawing.Point(902, 0);
            this.gunaControlBoxClose.MaximumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxClose.MinimumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxClose.Name = "gunaControlBoxClose";
            this.gunaControlBoxClose.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaControlBoxClose.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBoxClose.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBoxClose.Size = new System.Drawing.Size(20, 20);
            this.gunaControlBoxClose.TabIndex = 6;
            // 
            // gunaControlBoxHide
            // 
            this.gunaControlBoxHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBoxHide.Animated = true;
            this.gunaControlBoxHide.AnimationHoverSpeed = 0.07F;
            this.gunaControlBoxHide.AnimationSpeed = 0.03F;
            this.gunaControlBoxHide.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBoxHide.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(85)))), ((int)(((byte)(244)))));
            this.gunaControlBoxHide.IconSize = 12F;
            this.gunaControlBoxHide.Location = new System.Drawing.Point(849, 0);
            this.gunaControlBoxHide.MaximumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxHide.Name = "gunaControlBoxHide";
            this.gunaControlBoxHide.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaControlBoxHide.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBoxHide.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBoxHide.Size = new System.Drawing.Size(20, 20);
            this.gunaControlBoxHide.TabIndex = 7;
            // 
            // gunaResize1
            // 
            this.gunaResize1.TargetForm = this;
            // 
            // gunaDragControl2
            // 
            this.gunaDragControl2.TargetControl = this;
            // 
            // mSimpleButton1
            // 
            this.mSimpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mSimpleButton1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.mSimpleButton1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.mSimpleButton1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.mSimpleButton1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mSimpleButton1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mSimpleButton1.Appearance.Options.UseBackColor = true;
            this.mSimpleButton1.Appearance.Options.UseBorderColor = true;
            this.mSimpleButton1.Appearance.Options.UseFont = true;
            this.mSimpleButton1.Appearance.Options.UseForeColor = true;
            this.mSimpleButton1.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.mSimpleButton1.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.mSimpleButton1.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.mSimpleButton1.AppearanceHovered.Options.UseBackColor = true;
            this.mSimpleButton1.AppearanceHovered.Options.UseBorderColor = true;
            this.mSimpleButton1.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.mSimpleButton1.AppearancePressed.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.mSimpleButton1.AppearancePressed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.mSimpleButton1.AppearancePressed.Options.UseBackColor = true;
            this.mSimpleButton1.AppearancePressed.Options.UseBorderColor = true;
            this.mSimpleButton1.ColumnName = "";
            this.mSimpleButton1.Description = null;
            this.mSimpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mSimpleButton1.ImageOptions.Image")));
            this.mSimpleButton1.Location = new System.Drawing.Point(9, 441);
            this.mSimpleButton1.Margin = new System.Windows.Forms.Padding(8, 8, 3, 8);
            this.mSimpleButton1.Name = "mSimpleButton1";
            this.mSimpleButton1.Size = new System.Drawing.Size(68, 24);
            this.mSimpleButton1.TabIndex = 14;
            this.mSimpleButton1.Text = "Trợ giúp";
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnHelp.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnHelp.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnHelp.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnHelp.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnHelp.Appearance.Options.UseBackColor = true;
            this.btnHelp.Appearance.Options.UseBorderColor = true;
            this.btnHelp.Appearance.Options.UseFont = true;
            this.btnHelp.Appearance.Options.UseForeColor = true;
            this.btnHelp.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnHelp.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnHelp.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.btnHelp.AppearanceHovered.Options.UseBackColor = true;
            this.btnHelp.AppearanceHovered.Options.UseBorderColor = true;
            this.btnHelp.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnHelp.AppearancePressed.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnHelp.AppearancePressed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnHelp.AppearancePressed.Options.UseBackColor = true;
            this.btnHelp.AppearancePressed.Options.UseBorderColor = true;
            this.btnHelp.ColumnName = "";
            this.btnHelp.Description = null;
            this.btnHelp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.ImageOptions.Image")));
            this.btnHelp.Location = new System.Drawing.Point(-205, 441);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(8, 8, 3, 8);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(69, 24);
            this.btnHelp.TabIndex = 13;
            this.btnHelp.Text = "Trợ giúp";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnCancel.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnCancel.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseBorderColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnCancel.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnCancel.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.btnCancel.AppearanceHovered.Options.UseBackColor = true;
            this.btnCancel.AppearanceHovered.Options.UseBorderColor = true;
            this.btnCancel.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnCancel.AppearancePressed.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.btnCancel.AppearancePressed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnCancel.AppearancePressed.Options.UseBackColor = true;
            this.btnCancel.AppearancePressed.Options.UseBorderColor = true;
            this.btnCancel.ColumnName = "";
            this.btnCancel.Description = null;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(847, 441);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 24);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(107)))), ((int)(((byte)(151)))));
            this.btnSave.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(107)))), ((int)(((byte)(151)))));
            this.btnSave.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseBorderColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(194)))));
            this.btnSave.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(194)))));
            this.btnSave.AppearanceHovered.BorderColor = System.Drawing.Color.Black;
            this.btnSave.AppearanceHovered.Options.UseBackColor = true;
            this.btnSave.AppearanceHovered.Options.UseBorderColor = true;
            this.btnSave.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(87)))), ((int)(((byte)(123)))));
            this.btnSave.AppearancePressed.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(87)))), ((int)(((byte)(123)))));
            this.btnSave.AppearancePressed.BorderColor = System.Drawing.Color.Black;
            this.btnSave.AppearancePressed.Options.UseBackColor = true;
            this.btnSave.AppearancePressed.Options.UseBorderColor = true;
            this.btnSave.ColumnName = "";
            this.btnSave.Description = null;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(784, 441);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 24);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitleFormDetail
            // 
            this.lblTitleFormDetail.AllowHtmlString = true;
            this.lblTitleFormDetail.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitleFormDetail.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitleFormDetail.Appearance.Options.UseFont = true;
            this.lblTitleFormDetail.Appearance.Options.UseForeColor = true;
            this.lblTitleFormDetail.Appearance.Options.UseTextOptions = true;
            this.lblTitleFormDetail.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblTitleFormDetail.ColumnName = "";
            this.lblTitleFormDetail.Description = null;
            this.lblTitleFormDetail.IsRequired = false;
            this.lblTitleFormDetail.IsTitleForm = true;
            this.lblTitleFormDetail.Location = new System.Drawing.Point(7, 2);
            this.lblTitleFormDetail.Name = "lblTitleFormDetail";
            this.lblTitleFormDetail.Size = new System.Drawing.Size(130, 22);
            this.lblTitleFormDetail.TabIndex = 9;
            this.lblTitleFormDetail.Text = "Phê duyệt phiếu";
            // 
            // frmPhieu_NhapCaiDatSanPham_PheDuyet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(923, 472);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mSimpleButton1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitleFormDetail);
            this.Controls.Add(this.gunaControlBoxMaximumOrMiximum);
            this.Controls.Add(this.gunaControlBoxClose);
            this.Controls.Add(this.gunaControlBoxHide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPhieu_NhapCaiDatSanPham_PheDuyet";
            this.Shown += new System.EventHandler(this.frmPhieu_NhapCaiDatSanPham_PheDuyet_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mGroupControl1)).EndInit();
            this.mGroupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPhieuXuatCD.GrdDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI.WinForms.GunaControlBox gunaControlBoxMaximumOrMiximum;
        public Guna.UI.WinForms.GunaControlBox gunaControlBoxClose;
        public Guna.UI.WinForms.GunaControlBox gunaControlBoxHide;
        protected MTControl.MLabel lblTitleFormDetail;
        public MTControl.MSimpleButton btnHelp;
        public MTControl.MSimpleButton btnCancel;
        public MTControl.MSimpleButton btnSave;
        public MTControl.MSimpleButton mSimpleButton1;
        private MTControl.MComboBox cboiTrangThaiDuyet;
        private MTControl.MTextEdit txtsLyDoDuyet;
        private MTControl.MLabel mLabel15;
        private MTControl.MLabel mLabel16;
        private Guna.UI.WinForms.GunaResize gunaResize1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl2;
        private System.Windows.Forms.Panel panel1;
        private MTControl.MGroupControl mGroupControl1;
        private MTControl.MGridEditable grdPhieuXuatCD;
    }
}