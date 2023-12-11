
namespace FormUI
{
    partial class frmDM_CanBoDetail
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
            this.txtsTenCanBo = new MTControl.MTextEdit();
            this.mLabel3 = new MTControl.MLabel();
            this.txtsMaCanBo = new MTControl.MTextEdit();
            this.mLabel2 = new MTControl.MLabel();
            this.mLabel1 = new MTControl.MLabel();
            this.txtsDienThoai = new MTControl.MTextEdit();
            this.mLabel4 = new MTControl.MLabel();
            this.mLabel6 = new MTControl.MLabel();
            this.txtsEmail = new MTControl.MTextEdit();
            this.mLookUpEditChucVu = new MTControl.MLookUpEdit();
            this.mLabel7 = new MTControl.MLabel();
            this.mTreeLookUpDonVi = new MTControl.MTreeLookUpEdit();
            this.mTreeLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.mLabel8 = new MTControl.MLabel();
            this.txtsGhiChu = new MTControl.MTextEdit();
            this.txtsHoVaDem = new MTControl.MTextEdit();
            this.mLabel9 = new MTControl.MLabel();
            this.txtsTen = new MTControl.MTextEdit();
            this.mLabel10 = new MTControl.MLabel();
            this.pnlHeader.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).BeginInit();
            this.SuspendLayout();
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
            this.lblTitleFormDetail.Size = new System.Drawing.Size(140, 22);
            this.lblTitleFormDetail.Text = "Danh mục cán bộ";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(570, 56);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtsTen);
            this.panel3.Controls.Add(this.mLabel10);
            this.panel3.Controls.Add(this.txtsHoVaDem);
            this.panel3.Controls.Add(this.mLabel9);
            this.panel3.Controls.Add(this.mTreeLookUpDonVi);
            this.panel3.Controls.Add(this.mLookUpEditChucVu);
            this.panel3.Controls.Add(this.mLabel7);
            this.panel3.Controls.Add(this.mLabel4);
            this.panel3.Controls.Add(this.txtsEmail);
            this.panel3.Controls.Add(this.mLabel6);
            this.panel3.Controls.Add(this.txtsDienThoai);
            this.panel3.Controls.Add(this.mLabel1);
            this.panel3.Controls.Add(this.txtsGhiChu);
            this.panel3.Controls.Add(this.mLabel8);
            this.panel3.Controls.Add(this.txtsTenCanBo);
            this.panel3.Controls.Add(this.mLabel3);
            this.panel3.Controls.Add(this.txtsMaCanBo);
            this.panel3.Controls.Add(this.mLabel2);
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Size = new System.Drawing.Size(570, 238);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 294);
            this.pnlBottom.Size = new System.Drawing.Size(570, 39);
            // 
            // txtsTenCanBo
            // 
            this.txtsTenCanBo.AutoIncrement = false;
            this.txtsTenCanBo.Description = null;
            this.txtsTenCanBo.Grid = null;
            this.txtsTenCanBo.IsCustomHeight = false;
            this.txtsTenCanBo.IsReadOnly = false;
            this.txtsTenCanBo.IsRequired = true;
            this.txtsTenCanBo.IsSetValueManual = false;
            this.txtsTenCanBo.Location = new System.Drawing.Point(90, 79);
            this.txtsTenCanBo.MaxLength = 255;
            this.txtsTenCanBo.Name = "txtsTenCanBo";
            this.txtsTenCanBo.RepositoryItem = null;
            this.txtsTenCanBo.SetField = "sTenCanBo";
            this.txtsTenCanBo.Size = new System.Drawing.Size(453, 22);
            this.txtsTenCanBo.TabIndex = 3;
            // 
            // mLabel3
            // 
            this.mLabel3.AllowHtmlString = true;
            this.mLabel3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel3.Appearance.Options.UseFont = true;
            this.mLabel3.Appearance.Options.UseForeColor = true;
            this.mLabel3.Appearance.Options.UseTextOptions = true;
            this.mLabel3.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel3.ColumnName = "";
            this.mLabel3.Description = null;
            this.mLabel3.IsRequired = true;
            this.mLabel3.Location = new System.Drawing.Point(12, 83);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(52, 16);
            this.mLabel3.TabIndex = 9;
            this.mLabel3.Text = "Họ và tên<color=255, 0, 0><size=13>*</size></color>";
            // 
            // txtsMaCanBo
            // 
            this.txtsMaCanBo.AutoIncrement = false;
            this.txtsMaCanBo.Description = null;
            this.txtsMaCanBo.Grid = null;
            this.txtsMaCanBo.IsCustomHeight = false;
            this.txtsMaCanBo.IsReadOnly = false;
            this.txtsMaCanBo.IsRequired = true;
            this.txtsMaCanBo.IsSetValueManual = false;
            this.txtsMaCanBo.Location = new System.Drawing.Point(90, 21);
            this.txtsMaCanBo.MaxLength = 255;
            this.txtsMaCanBo.Name = "txtsMaCanBo";
            this.txtsMaCanBo.RepositoryItem = null;
            this.txtsMaCanBo.SetField = "sMaCanBo";
            this.txtsMaCanBo.Size = new System.Drawing.Size(184, 22);
            this.txtsMaCanBo.TabIndex = 0;
            // 
            // mLabel2
            // 
            this.mLabel2.AllowHtmlString = true;
            this.mLabel2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel2.Appearance.Options.UseFont = true;
            this.mLabel2.Appearance.Options.UseForeColor = true;
            this.mLabel2.Appearance.Options.UseTextOptions = true;
            this.mLabel2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel2.ColumnName = "";
            this.mLabel2.Description = null;
            this.mLabel2.IsRequired = true;
            this.mLabel2.Location = new System.Drawing.Point(13, 26);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(56, 16);
            this.mLabel2.TabIndex = 8;
            this.mLabel2.Text = "Mã cán bộ<color=255, 0, 0><size=13>*</size></color>";
            // 
            // mLabel1
            // 
            this.mLabel1.AllowHtmlString = true;
            this.mLabel1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel1.Appearance.Options.UseFont = true;
            this.mLabel1.Appearance.Options.UseForeColor = true;
            this.mLabel1.Appearance.Options.UseTextOptions = true;
            this.mLabel1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel1.ColumnName = "";
            this.mLabel1.Description = null;
            this.mLabel1.IsRequired = false;
            this.mLabel1.Location = new System.Drawing.Point(12, 172);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(63, 13);
            this.mLabel1.TabIndex = 10;
            this.mLabel1.Text = "Số điện thoại";
            // 
            // txtsDienThoai
            // 
            this.txtsDienThoai.AutoIncrement = false;
            this.txtsDienThoai.Description = null;
            this.txtsDienThoai.Grid = null;
            this.txtsDienThoai.IsCustomHeight = false;
            this.txtsDienThoai.IsReadOnly = false;
            this.txtsDienThoai.IsSetValueManual = false;
            this.txtsDienThoai.Location = new System.Drawing.Point(89, 167);
            this.txtsDienThoai.MaxLength = 255;
            this.txtsDienThoai.Name = "txtsDienThoai";
            this.txtsDienThoai.RepositoryItem = null;
            this.txtsDienThoai.SetField = "sDienThoai";
            this.txtsDienThoai.Size = new System.Drawing.Size(184, 22);
            this.txtsDienThoai.TabIndex = 6;
            // 
            // mLabel4
            // 
            this.mLabel4.AllowHtmlString = true;
            this.mLabel4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel4.Appearance.Options.UseFont = true;
            this.mLabel4.Appearance.Options.UseForeColor = true;
            this.mLabel4.Appearance.Options.UseTextOptions = true;
            this.mLabel4.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel4.ColumnName = "";
            this.mLabel4.Description = null;
            this.mLabel4.IsRequired = true;
            this.mLabel4.Location = new System.Drawing.Point(12, 140);
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.Size = new System.Drawing.Size(45, 16);
            this.mLabel4.TabIndex = 12;
            this.mLabel4.Text = "Chức vụ<color=255, 0, 0><size=13>*</size></color>";
            // 
            // mLabel6
            // 
            this.mLabel6.AllowHtmlString = true;
            this.mLabel6.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel6.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel6.Appearance.Options.UseFont = true;
            this.mLabel6.Appearance.Options.UseForeColor = true;
            this.mLabel6.Appearance.Options.UseTextOptions = true;
            this.mLabel6.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel6.ColumnName = "";
            this.mLabel6.Description = null;
            this.mLabel6.IsRequired = false;
            this.mLabel6.Location = new System.Drawing.Point(281, 172);
            this.mLabel6.Name = "mLabel6";
            this.mLabel6.Size = new System.Drawing.Size(25, 13);
            this.mLabel6.TabIndex = 11;
            this.mLabel6.Text = "Email";
            // 
            // txtsEmail
            // 
            this.txtsEmail.AutoIncrement = false;
            this.txtsEmail.Description = null;
            this.txtsEmail.Grid = null;
            this.txtsEmail.IsCustomHeight = false;
            this.txtsEmail.IsMail = true;
            this.txtsEmail.IsReadOnly = false;
            this.txtsEmail.IsSetValueManual = false;
            this.txtsEmail.Location = new System.Drawing.Point(314, 167);
            this.txtsEmail.MaxLength = 255;
            this.txtsEmail.Name = "txtsEmail";
            this.txtsEmail.RepositoryItem = null;
            this.txtsEmail.SetField = "sEmail";
            this.txtsEmail.Size = new System.Drawing.Size(228, 22);
            this.txtsEmail.TabIndex = 7;
            // 
            // mLookUpEditChucVu
            // 
            this.mLookUpEditChucVu.AddFields = null;
            this.mLookUpEditChucVu.AliasFormQuickAdd = null;
            this.mLookUpEditChucVu.ColumnsExtend = null;
            this.mLookUpEditChucVu.Description = null;
            this.mLookUpEditChucVu.DictionaryName = null;
            this.mLookUpEditChucVu.EntityName = null;
            this.mLookUpEditChucVu.Grid = null;
            this.mLookUpEditChucVu.IsAutoLoad = false;
            this.mLookUpEditChucVu.IsReadOnly = false;
            this.mLookUpEditChucVu.IsRequired = true;
            this.mLookUpEditChucVu.IsSetValueManual = false;
            this.mLookUpEditChucVu.KeyStore = null;
            this.mLookUpEditChucVu.Location = new System.Drawing.Point(90, 137);
            this.mLookUpEditChucVu.MapColumnName = null;
            this.mLookUpEditChucVu.Name = "mLookUpEditChucVu";
            this.mLookUpEditChucVu.PrimaryKey = null;
            this.mLookUpEditChucVu.QuickSearchName = null;
            this.mLookUpEditChucVu.RepositoryItem = null;
            this.mLookUpEditChucVu.SetField = "sDM_ChucVu_Id";
            this.mLookUpEditChucVu.Size = new System.Drawing.Size(184, 23);
            this.mLookUpEditChucVu.Sort = null;
            this.mLookUpEditChucVu.TabIndex = 8;
            this.mLookUpEditChucVu.ValueDefault = null;
            // 
            // mLabel7
            // 
            this.mLabel7.AllowHtmlString = true;
            this.mLabel7.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel7.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel7.Appearance.Options.UseFont = true;
            this.mLabel7.Appearance.Options.UseForeColor = true;
            this.mLabel7.Appearance.Options.UseTextOptions = true;
            this.mLabel7.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel7.ColumnName = "";
            this.mLabel7.Description = null;
            this.mLabel7.IsRequired = true;
            this.mLabel7.Location = new System.Drawing.Point(10, 112);
            this.mLabel7.Name = "mLabel7";
            this.mLabel7.Size = new System.Drawing.Size(69, 16);
            this.mLabel7.TabIndex = 13;
            this.mLabel7.Text = "Thuộc đơn vị<color=255, 0, 0><size=13>*</size></color>";
            // 
            // mTreeLookUpDonVi
            // 
            this.mTreeLookUpDonVi.AddFields = null;
            this.mTreeLookUpDonVi.AliasFormQuickAdd = null;
            this.mTreeLookUpDonVi.CustomSetFields = null;
            this.mTreeLookUpDonVi.Description = null;
            this.mTreeLookUpDonVi.DictionaryName = null;
            this.mTreeLookUpDonVi.EntityName = null;
            this.mTreeLookUpDonVi.Grid = null;
            this.mTreeLookUpDonVi.IsReadOnly = false;
            this.mTreeLookUpDonVi.IsRequired = true;
            this.mTreeLookUpDonVi.IsSetValueManual = false;
            this.mTreeLookUpDonVi.KeyStore = null;
            this.mTreeLookUpDonVi.Location = new System.Drawing.Point(90, 109);
            this.mTreeLookUpDonVi.MapColumnName = null;
            this.mTreeLookUpDonVi.Name = "mTreeLookUpDonVi";
            this.mTreeLookUpDonVi.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mTreeLookUpDonVi.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeLookUpDonVi.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mTreeLookUpDonVi.Properties.Appearance.Options.UseBackColor = true;
            this.mTreeLookUpDonVi.Properties.Appearance.Options.UseFont = true;
            this.mTreeLookUpDonVi.Properties.Appearance.Options.UseForeColor = true;
            this.mTreeLookUpDonVi.Properties.AutoHeight = false;
            this.mTreeLookUpDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mTreeLookUpDonVi.Properties.ImmediatePopup = true;
            this.mTreeLookUpDonVi.Properties.NullText = "";
            this.mTreeLookUpDonVi.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.mTreeLookUpDonVi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.mTreeLookUpDonVi.Properties.TreeList = this.mTreeLookUpEdit1TreeList;
            this.mTreeLookUpDonVi.QuickSearchName = null;
            this.mTreeLookUpDonVi.RepositoryItem = null;
            this.mTreeLookUpDonVi.SetField = "sDM_DonVi_Id";
            this.mTreeLookUpDonVi.Size = new System.Drawing.Size(452, 23);
            this.mTreeLookUpDonVi.TabIndex = 5;
            // 
            // mTreeLookUpEdit1TreeList
            // 
            this.mTreeLookUpEdit1TreeList.KeyFieldName = "";
            this.mTreeLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.mTreeLookUpEdit1TreeList.Name = "mTreeLookUpEdit1TreeList";
            this.mTreeLookUpEdit1TreeList.OptionsView.ShowAutoFilterRow = true;
            this.mTreeLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.mTreeLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.mTreeLookUpEdit1TreeList.TabIndex = 0;
            // 
            // mLabel8
            // 
            this.mLabel8.AllowHtmlString = true;
            this.mLabel8.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel8.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel8.Appearance.Options.UseFont = true;
            this.mLabel8.Appearance.Options.UseForeColor = true;
            this.mLabel8.Appearance.Options.UseTextOptions = true;
            this.mLabel8.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel8.ColumnName = "";
            this.mLabel8.Description = null;
            this.mLabel8.IsRequired = false;
            this.mLabel8.Location = new System.Drawing.Point(13, 201);
            this.mLabel8.Name = "mLabel8";
            this.mLabel8.Size = new System.Drawing.Size(36, 13);
            this.mLabel8.TabIndex = 15;
            this.mLabel8.Text = "Ghi chú";
            // 
            // txtsGhiChu
            // 
            this.txtsGhiChu.AutoIncrement = false;
            this.txtsGhiChu.Description = null;
            this.txtsGhiChu.Grid = null;
            this.txtsGhiChu.IsCustomHeight = false;
            this.txtsGhiChu.IsReadOnly = false;
            this.txtsGhiChu.IsSetValueManual = false;
            this.txtsGhiChu.Location = new System.Drawing.Point(90, 196);
            this.txtsGhiChu.MaxLength = 255;
            this.txtsGhiChu.Name = "txtsGhiChu";
            this.txtsGhiChu.RepositoryItem = null;
            this.txtsGhiChu.SetField = "sGhiChu";
            this.txtsGhiChu.Size = new System.Drawing.Size(453, 22);
            this.txtsGhiChu.TabIndex = 9;
            // 
            // txtsHoVaDem
            // 
            this.txtsHoVaDem.AutoIncrement = false;
            this.txtsHoVaDem.Description = null;
            this.txtsHoVaDem.Grid = null;
            this.txtsHoVaDem.IsCustomHeight = false;
            this.txtsHoVaDem.IsReadOnly = false;
            this.txtsHoVaDem.IsRequired = true;
            this.txtsHoVaDem.IsSetValueManual = false;
            this.txtsHoVaDem.Location = new System.Drawing.Point(90, 49);
            this.txtsHoVaDem.MaxLength = 155;
            this.txtsHoVaDem.Name = "txtsHoVaDem";
            this.txtsHoVaDem.RepositoryItem = null;
            this.txtsHoVaDem.SetField = "sHoVaDem";
            this.txtsHoVaDem.Size = new System.Drawing.Size(184, 22);
            this.txtsHoVaDem.TabIndex = 1;
            this.txtsHoVaDem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtsHoVaDem_EditValueChanging);
            // 
            // mLabel9
            // 
            this.mLabel9.AllowHtmlString = true;
            this.mLabel9.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel9.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel9.Appearance.Options.UseFont = true;
            this.mLabel9.Appearance.Options.UseForeColor = true;
            this.mLabel9.Appearance.Options.UseTextOptions = true;
            this.mLabel9.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel9.ColumnName = "";
            this.mLabel9.Description = null;
            this.mLabel9.IsRequired = true;
            this.mLabel9.Location = new System.Drawing.Point(13, 54);
            this.mLabel9.Name = "mLabel9";
            this.mLabel9.Size = new System.Drawing.Size(56, 16);
            this.mLabel9.TabIndex = 17;
            this.mLabel9.Text = "Họ và đệm<color=255, 0, 0><size=13>*</size></color>";
            // 
            // txtsTen
            // 
            this.txtsTen.AutoIncrement = false;
            this.txtsTen.Description = null;
            this.txtsTen.Grid = null;
            this.txtsTen.IsCustomHeight = false;
            this.txtsTen.IsReadOnly = false;
            this.txtsTen.IsRequired = true;
            this.txtsTen.IsSetValueManual = false;
            this.txtsTen.Location = new System.Drawing.Point(311, 49);
            this.txtsTen.MaxLength = 100;
            this.txtsTen.Name = "txtsTen";
            this.txtsTen.RepositoryItem = null;
            this.txtsTen.SetField = "sTen";
            this.txtsTen.Size = new System.Drawing.Size(232, 22);
            this.txtsTen.TabIndex = 2;
            this.txtsTen.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtsTen_EditValueChanging);
            // 
            // mLabel10
            // 
            this.mLabel10.AllowHtmlString = true;
            this.mLabel10.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel10.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel10.Appearance.Options.UseFont = true;
            this.mLabel10.Appearance.Options.UseForeColor = true;
            this.mLabel10.Appearance.Options.UseTextOptions = true;
            this.mLabel10.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel10.ColumnName = "";
            this.mLabel10.Description = null;
            this.mLabel10.IsRequired = true;
            this.mLabel10.Location = new System.Drawing.Point(281, 54);
            this.mLabel10.Name = "mLabel10";
            this.mLabel10.Size = new System.Drawing.Size(22, 16);
            this.mLabel10.TabIndex = 19;
            this.mLabel10.Text = "Tên<color=255, 0, 0><size=13>*</size></color>";
            // 
            // frmDM_CanBoDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 333);
            this.Name = "frmDM_CanBoDetail";
            this.Text = "frmDM_DonViDetail";
            this.Load += new System.EventHandler(this.frmDM_CanBo_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MTControl.MTextEdit txtsTenCanBo;
        private MTControl.MLabel mLabel3;
        private MTControl.MTextEdit txtsMaCanBo;
        private MTControl.MLabel mLabel2;
        private MTControl.MLabel mLabel4;
        private MTControl.MTextEdit txtsEmail;
        private MTControl.MLabel mLabel6;
        private MTControl.MTextEdit txtsDienThoai;
        private MTControl.MLabel mLabel1;
        private MTControl.MLookUpEdit mLookUpEditChucVu;
        private MTControl.MLabel mLabel7;
        private MTControl.MTreeLookUpEdit mTreeLookUpDonVi;
        private DevExpress.XtraTreeList.TreeList mTreeLookUpEdit1TreeList;
        private MTControl.MTextEdit txtsGhiChu;
        private MTControl.MLabel mLabel8;
        private MTControl.MTextEdit txtsTen;
        private MTControl.MLabel mLabel10;
        private MTControl.MTextEdit txtsHoVaDem;
        private MTControl.MLabel mLabel9;
    }
}