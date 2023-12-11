
namespace FormUI
{
    partial class frmTonDauKy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTonDauKy));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImport = new MTControl.MSimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grd = new MTControl.MGridEditable();
            this.treesDM_DonVi_Id_DonVi = new MTControl.MTreeLookUpEdit();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.mLabel15 = new MTControl.MLabel();
            this.gunaResize1 = new Guna.UI.WinForms.GunaResize(this.components);
            this.gunaDragControl2 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.btnHelp = new MTControl.MSimpleButton();
            this.bgLoadGrid = new System.ComponentModel.BackgroundWorker();
            this.mSimpleButton1 = new MTControl.MSimpleButton();
            this.btnSave = new MTControl.MSimpleButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd.GrdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treesDM_DonVi_Id_DonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.treesDM_DonVi_Id_DonVi);
            this.panel1.Controls.Add(this.mLabel15);
            this.panel1.Location = new System.Drawing.Point(7, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1116, 647);
            this.panel1.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnImport.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnImport.Appearance.Options.UseFont = true;
            this.btnImport.Appearance.Options.UseForeColor = true;
            this.btnImport.ColumnName = "";
            this.btnImport.Description = null;
            this.btnImport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.ImageOptions.Image")));
            this.btnImport.Location = new System.Drawing.Point(1025, 14);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(88, 24);
            this.btnImport.TabIndex = 74;
            this.btnImport.Text = "Nhập khẩu";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.grd);
            this.panel2.Location = new System.Drawing.Point(3, 49);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1110, 591);
            this.panel2.TabIndex = 73;
            // 
            // grd
            // 
            this.grd.AllowDrop = true;
            this.grd.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grd.Appearance.Options.UseFont = true;
            this.grd.Appearance.Options.UseTextOptions = true;
            this.grd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grd.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grd.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // grd.MGridEditable
            // 
            this.grd.GrdDetail.Columns = null;
            this.grd.GrdDetail.ColumnSortInfoCollectionChanged = null;
            this.grd.GrdDetail.Cursor = System.Windows.Forms.Cursors.Default;
            this.grd.GrdDetail.CustomModelFields = null;
            this.grd.GrdDetail.CustomRowCellEditing = null;
            this.grd.GrdDetail.Description = null;
            this.grd.GrdDetail.DisableFieldNames = null;
            this.grd.GrdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.GrdDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grd.GrdDetail.FilterObjects = null;
            this.grd.GrdDetail.FuncCustomRecordBeforeAddRow = null;
            this.grd.GrdDetail.IsEditable = true;
            this.grd.GrdDetail.IsHideActionAdd = false;
            this.grd.GrdDetail.IsRemoteFilter = false;
            this.grd.GrdDetail.IsSetValueManual = false;
            this.grd.GrdDetail.IsShowDetailButtons = false;
            this.grd.GrdDetail.IsShowFilter = false;
            this.grd.GrdDetail.IsShowHorizontalLine = false;
            this.grd.GrdDetail.IsShowPaging = false;
            this.grd.GrdDetail.IsShowVerticalLine = false;
            this.grd.GrdDetail.KeyName = null;
            this.grd.GrdDetail.Location = new System.Drawing.Point(0, 0);
            this.grd.GrdDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grd.GrdDetail.MarkLoading = false;
            this.grd.GrdDetail.Name = "MGridEditable";
            this.grd.GrdDetail.RowCellStyle = null;
            this.grd.GrdDetail.SetField = null;
            this.grd.GrdDetail.Size = new System.Drawing.Size(1110, 559);
            this.grd.GrdDetail.Sort = null;
            this.grd.GrdDetail.StartRemoteFilterRow = null;
            this.grd.GrdDetail.Sumary = null;
            this.grd.GrdDetail.TabIndex = 0;
            this.grd.GrdDetail.TableName = null;
            this.grd.GrdDetail.UserCustomDrawCell = null;
            this.grd.GrdDetail.ValidEditValueChanging = null;
            this.grd.GrdDetail.ViewName = null;
            this.grd.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grd.InvalidText = null;
            this.grd.IsHideActionAdd = false;
            this.grd.IsRequired = false;
            this.grd.Location = new System.Drawing.Point(0, 0);
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(1110, 591);
            this.grd.TabIndex = 0;
            // 
            // treesDM_DonVi_Id_DonVi
            // 
            this.treesDM_DonVi_Id_DonVi.AddFields = null;
            this.treesDM_DonVi_Id_DonVi.AliasFormQuickAdd = null;
            this.treesDM_DonVi_Id_DonVi.CustomSetFields = null;
            this.treesDM_DonVi_Id_DonVi.Description = null;
            this.treesDM_DonVi_Id_DonVi.DictionaryName = null;
            this.treesDM_DonVi_Id_DonVi.EntityName = null;
            this.treesDM_DonVi_Id_DonVi.Grid = null;
            this.treesDM_DonVi_Id_DonVi.IsReadOnly = false;
            this.treesDM_DonVi_Id_DonVi.IsRequired = true;
            this.treesDM_DonVi_Id_DonVi.IsSetValueManual = false;
            this.treesDM_DonVi_Id_DonVi.KeyStore = null;
            this.treesDM_DonVi_Id_DonVi.Location = new System.Drawing.Point(74, 12);
            this.treesDM_DonVi_Id_DonVi.MapColumnName = null;
            this.treesDM_DonVi_Id_DonVi.Name = "treesDM_DonVi_Id_DonVi";
            this.treesDM_DonVi_Id_DonVi.Properties.ActionButtonIndex = 1;
            this.treesDM_DonVi_Id_DonVi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.treesDM_DonVi_Id_DonVi.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treesDM_DonVi_Id_DonVi.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treesDM_DonVi_Id_DonVi.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treesDM_DonVi_Id_DonVi.Properties.Appearance.Options.UseBackColor = true;
            this.treesDM_DonVi_Id_DonVi.Properties.Appearance.Options.UseFont = true;
            this.treesDM_DonVi_Id_DonVi.Properties.Appearance.Options.UseForeColor = true;
            this.treesDM_DonVi_Id_DonVi.Properties.AutoHeight = false;
            this.treesDM_DonVi_Id_DonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, false, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "Xóa", "ClearValue", null, DevExpress.Utils.ToolTipAnchor.Default),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.treesDM_DonVi_Id_DonVi.Properties.ImmediatePopup = true;
            this.treesDM_DonVi_Id_DonVi.Properties.NullText = "";
            this.treesDM_DonVi_Id_DonVi.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.treesDM_DonVi_Id_DonVi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.treesDM_DonVi_Id_DonVi.Properties.TreeList = this.treeList1;
            this.treesDM_DonVi_Id_DonVi.QuickSearchName = null;
            this.treesDM_DonVi_Id_DonVi.RepositoryItem = null;
            this.treesDM_DonVi_Id_DonVi.SetField = "sDM_DonVi_Id_Xuat";
            this.treesDM_DonVi_Id_DonVi.Size = new System.Drawing.Size(438, 23);
            this.treesDM_DonVi_Id_DonVi.TabIndex = 0;
            this.treesDM_DonVi_Id_DonVi.EditValueChanged += new System.EventHandler(this.treesDM_DonVi_Id_DonVi_EditValueChanged);
            // 
            // treeList1
            // 
            this.treeList1.KeyFieldName = "";
            this.treeList1.Location = new System.Drawing.Point(446, 215);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsView.ShowAutoFilterRow = true;
            this.treeList1.OptionsView.ShowIndentAsRowStyle = true;
            this.treeList1.Size = new System.Drawing.Size(400, 200);
            this.treeList1.TabIndex = 0;
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
            this.mLabel15.IsRequired = false;
            this.mLabel15.Location = new System.Drawing.Point(6, 17);
            this.mLabel15.Name = "mLabel15";
            this.mLabel15.Size = new System.Drawing.Size(58, 13);
            this.mLabel15.TabIndex = 1;
            this.mLabel15.Text = "Đơn vị nhập";
            // 
            // gunaResize1
            // 
            this.gunaResize1.TargetForm = this;
            // 
            // gunaDragControl2
            // 
            this.gunaDragControl2.TargetControl = this;
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
            this.btnHelp.Location = new System.Drawing.Point(-205, 664);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(8, 8, 3, 8);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(69, 24);
            this.btnHelp.TabIndex = 13;
            this.btnHelp.Text = "Trợ giúp";
            // 
            // bgLoadGrid
            // 
            this.bgLoadGrid.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoadGrid_DoWork);
            this.bgLoadGrid.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoadGrid_RunWorkerCompleted);
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
            this.mSimpleButton1.Location = new System.Drawing.Point(9, 661);
            this.mSimpleButton1.Margin = new System.Windows.Forms.Padding(8, 8, 3, 8);
            this.mSimpleButton1.Name = "mSimpleButton1";
            this.mSimpleButton1.Size = new System.Drawing.Size(68, 24);
            this.mSimpleButton1.TabIndex = 2;
            this.mSimpleButton1.Text = "Trợ giúp";
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
            this.btnSave.Location = new System.Drawing.Point(1067, 661);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmTonDauKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1134, 695);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.mSimpleButton1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTonDauKy";
            this.Load += new System.EventHandler(this.frmTonDauKy_Load);
            this.Shown += new System.EventHandler(this.frmTonDauKy_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd.GrdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treesDM_DonVi_Id_DonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public MTControl.MSimpleButton btnHelp;
        private MTControl.MLabel mLabel15;
        private Guna.UI.WinForms.GunaResize gunaResize1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl2;
        private System.Windows.Forms.Panel panel1;
        private MTControl.MTreeLookUpEdit treesDM_DonVi_Id_DonVi;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker bgLoadGrid;
        private MTControl.MGridEditable grd;
        public MTControl.MSimpleButton mSimpleButton1;
        public MTControl.MSimpleButton btnSave;
        private MTControl.MSimpleButton btnImport;
    }
}