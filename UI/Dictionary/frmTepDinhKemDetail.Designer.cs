namespace FormUI.Dictionary
{
    partial class frmTepDinhKemDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTepDinhKemDetail));
            this.btnSourcePath = new FontAwesome.Sharp.IconPictureBox();
            this.txtsTen = new MTControl.MTextEdit();
            this.mLabel5 = new MTControl.MLabel();
            this.mLabel3 = new MTControl.MLabel();
            this.mLabel1 = new MTControl.MLabel();
            this.txtsGhiChu = new MTControl.MTextEdit();
            this.mLabel8 = new MTControl.MLabel();
            this.txtChooseFile = new MTControl.MTextEdit();
            this.mLabel2 = new MTControl.MLabel();
            this.btnAccept = new MTControl.MSimpleButton();
            this.btnCancel = new MTControl.MSimpleButton();
            this.spinEditSize = new MTControl.MSpinEdit();
            this.mLabel4 = new MTControl.MLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnSourcePath)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSourcePath
            // 
            this.btnSourcePath.BackColor = System.Drawing.Color.Transparent;
            this.btnSourcePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSourcePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnSourcePath.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            this.btnSourcePath.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnSourcePath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSourcePath.IconSize = 24;
            this.btnSourcePath.Location = new System.Drawing.Point(499, 18);
            this.btnSourcePath.Name = "btnSourcePath";
            this.btnSourcePath.Size = new System.Drawing.Size(28, 24);
            this.btnSourcePath.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSourcePath.TabIndex = 31;
            this.btnSourcePath.TabStop = false;
            this.btnSourcePath.Click += new System.EventHandler(this.btnSourcePath_Click);
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
            this.txtsTen.Location = new System.Drawing.Point(115, 75);
            this.txtsTen.MaxLength = 255;
            this.txtsTen.Name = "txtsTen";
            this.txtsTen.RepositoryItem = null;
            this.txtsTen.SetField = "sTen";
            this.txtsTen.Size = new System.Drawing.Size(513, 22);
            this.txtsTen.TabIndex = 24;
            // 
            // mLabel5
            // 
            this.mLabel5.AllowHtmlString = true;
            this.mLabel5.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel5.Appearance.Options.UseFont = true;
            this.mLabel5.Appearance.Options.UseForeColor = true;
            this.mLabel5.Appearance.Options.UseTextOptions = true;
            this.mLabel5.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel5.ColumnName = "";
            this.mLabel5.Description = null;
            this.mLabel5.IsRequired = true;
            this.mLabel5.Location = new System.Drawing.Point(16, 80);
            this.mLabel5.Name = "mLabel5";
            this.mLabel5.Size = new System.Drawing.Size(47, 16);
            this.mLabel5.TabIndex = 30;
            this.mLabel5.Text = "Tên mẫu<color=255, 0, 0><size=13>*</size></color>";
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
            this.mLabel3.IsRequired = false;
            this.mLabel3.Location = new System.Drawing.Point(275, 51);
            this.mLabel3.Name = "mLabel3";
            this.mLabel3.Size = new System.Drawing.Size(19, 13);
            this.mLabel3.TabIndex = 29;
            this.mLabel3.Text = "(Kb)";
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
            this.mLabel1.Location = new System.Drawing.Point(16, 51);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(31, 13);
            this.mLabel1.TabIndex = 28;
            this.mLabel1.Text = "Độ lớn";
            // 
            // txtsGhiChu
            // 
            this.txtsGhiChu.AutoIncrement = false;
            this.txtsGhiChu.Description = null;
            this.txtsGhiChu.Grid = null;
            this.txtsGhiChu.IsCustomHeight = false;
            this.txtsGhiChu.IsReadOnly = false;
            this.txtsGhiChu.IsSetValueManual = false;
            this.txtsGhiChu.Location = new System.Drawing.Point(115, 105);
            this.txtsGhiChu.MaxLength = 255;
            this.txtsGhiChu.Name = "txtsGhiChu";
            this.txtsGhiChu.RepositoryItem = null;
            this.txtsGhiChu.SetField = "sGhiChu";
            this.txtsGhiChu.Size = new System.Drawing.Size(513, 22);
            this.txtsGhiChu.TabIndex = 25;
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
            this.mLabel8.Location = new System.Drawing.Point(16, 110);
            this.mLabel8.Name = "mLabel8";
            this.mLabel8.Size = new System.Drawing.Size(36, 13);
            this.mLabel8.TabIndex = 27;
            this.mLabel8.Text = "Ghi chú";
            // 
            // txtChooseFile
            // 
            this.txtChooseFile.AutoIncrement = false;
            this.txtChooseFile.Description = null;
            this.txtChooseFile.Grid = null;
            this.txtChooseFile.IsCustomHeight = false;
            this.txtChooseFile.IsReadOnly = true;
            this.txtChooseFile.IsRequired = true;
            this.txtChooseFile.IsSetValueManual = false;
            this.txtChooseFile.Location = new System.Drawing.Point(115, 18);
            this.txtChooseFile.MaxLength = 255;
            this.txtChooseFile.Name = "txtChooseFile";
            this.txtChooseFile.RepositoryItem = null;
            this.txtChooseFile.SetField = "sTenGoc";
            this.txtChooseFile.Size = new System.Drawing.Size(378, 22);
            this.txtChooseFile.TabIndex = 22;
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
            this.mLabel2.Location = new System.Drawing.Point(16, 23);
            this.mLabel2.Name = "mLabel2";
            this.mLabel2.Size = new System.Drawing.Size(91, 16);
            this.mLabel2.TabIndex = 26;
            this.mLabel2.Text = "Tên tệp đính kèm<color=255, 0, 0><size=13>*</size></color>";
            // 
            // btnAccept
            // 
            this.btnAccept.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(107)))), ((int)(((byte)(151)))));
            this.btnAccept.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(107)))), ((int)(((byte)(151)))));
            this.btnAccept.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btnAccept.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnAccept.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAccept.Appearance.Options.UseBackColor = true;
            this.btnAccept.Appearance.Options.UseBorderColor = true;
            this.btnAccept.Appearance.Options.UseFont = true;
            this.btnAccept.Appearance.Options.UseForeColor = true;
            this.btnAccept.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(194)))));
            this.btnAccept.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(194)))));
            this.btnAccept.AppearanceHovered.BorderColor = System.Drawing.Color.Black;
            this.btnAccept.AppearanceHovered.Options.UseBackColor = true;
            this.btnAccept.AppearanceHovered.Options.UseBorderColor = true;
            this.btnAccept.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(87)))), ((int)(((byte)(123)))));
            this.btnAccept.AppearancePressed.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(87)))), ((int)(((byte)(123)))));
            this.btnAccept.AppearancePressed.BorderColor = System.Drawing.Color.Black;
            this.btnAccept.AppearancePressed.Options.UseBackColor = true;
            this.btnAccept.AppearancePressed.Options.UseBorderColor = true;
            this.btnAccept.ColumnName = "";
            this.btnAccept.Description = null;
            this.btnAccept.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.ImageOptions.Image")));
            this.btnAccept.Location = new System.Drawing.Point(552, 189);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(76, 24);
            this.btnAccept.TabIndex = 32;
            this.btnAccept.Text = "Đồng ý";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
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
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(480, 189);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 24);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // spinEditSize
            // 
            this.spinEditSize.DataType = MTControl.FormatType.None;
            this.spinEditSize.DecimalCount = ((byte)(0));
            this.spinEditSize.Description = null;
            this.spinEditSize.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditSize.Grid = null;
            this.spinEditSize.IsReadOnly = true;
            this.spinEditSize.IsRequired = true;
            this.spinEditSize.IsSetValueManual = false;
            this.spinEditSize.Location = new System.Drawing.Point(115, 48);
            this.spinEditSize.Name = "spinEditSize";
            this.spinEditSize.SetField = "fSize";
            this.spinEditSize.Size = new System.Drawing.Size(154, 22);
            this.spinEditSize.TabIndex = 34;
            // 
            // mLabel4
            // 
            this.mLabel4.AllowHtmlString = true;
            this.mLabel4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel4.Appearance.Options.UseFont = true;
            this.mLabel4.Appearance.Options.UseForeColor = true;
            this.mLabel4.Appearance.Options.UseTextOptions = true;
            this.mLabel4.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel4.ColumnName = "";
            this.mLabel4.Description = null;
            this.mLabel4.IsRequired = false;
            this.mLabel4.IsTitleForm = true;
            this.mLabel4.Location = new System.Drawing.Point(16, 143);
            this.mLabel4.Name = "mLabel4";
            this.mLabel4.Size = new System.Drawing.Size(621, 22);
            this.mLabel4.TabIndex = 35;
            this.mLabel4.Text = "Lưu ý: Bạn chỉ được phép tải tệp có dung lượng tối đa: 10240 Kb hoặc 10 (Mb)";
            // 
            // frmTepDinhKemDetail
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(644, 223);
            this.Controls.Add(this.mLabel4);
            this.Controls.Add(this.spinEditSize);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnSourcePath);
            this.Controls.Add(this.txtsTen);
            this.Controls.Add(this.mLabel5);
            this.Controls.Add(this.mLabel3);
            this.Controls.Add(this.mLabel1);
            this.Controls.Add(this.txtsGhiChu);
            this.Controls.Add(this.mLabel8);
            this.Controls.Add(this.txtChooseFile);
            this.Controls.Add(this.mLabel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTepDinhKemDetail";
            this.Text = "Thông tin tệp đính kèm";
            this.Load += new System.EventHandler(this.frmTepDinhKemDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSourcePath)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox btnSourcePath;
        private MTControl.MTextEdit txtsTen;
        private MTControl.MLabel mLabel5;
        private MTControl.MLabel mLabel3;
        private MTControl.MLabel mLabel1;
        private MTControl.MTextEdit txtsGhiChu;
        private MTControl.MLabel mLabel8;
        private MTControl.MTextEdit txtChooseFile;
        private MTControl.MLabel mLabel2;
        public MTControl.MSimpleButton btnAccept;
        public MTControl.MSimpleButton btnCancel;
        private MTControl.MSpinEdit spinEditSize;
        private MTControl.MLabel mLabel4;
    }
}