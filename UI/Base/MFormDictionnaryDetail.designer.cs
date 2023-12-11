using MTControl;
using DevExpress.XtraLayout;
namespace FormUI
{
    partial class MFormDictionnaryDetail
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

        //Khởi tạo form
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFormDictionnaryDetail));
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.iconPictureBoxMaximize = new FontAwesome.Sharp.IconPictureBox();
            this.pic_Exit = new FontAwesome.Sharp.IconPictureBox();
            this.lblTitleFormDetail = new MTControl.MLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnHelp = new MTControl.MSimpleButton();
            this.btnCancel = new MTControl.MSimpleButton();
            this.btnSave = new MTControl.MSimpleButton();
            this.btnSaveNew = new MTControl.MSimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Exit)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.tableLayoutPanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(26, 27);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(50, 20);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(50, 20);
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this.pnlHeader;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.Controls.Add(this.iconPictureBoxMaximize);
            this.pnlHeader.Controls.Add(this.pic_Exit);
            this.pnlHeader.Controls.Add(this.lblTitleFormDetail);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.ForeColor = System.Drawing.SystemColors.WindowText;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(791, 50);
            this.pnlHeader.TabIndex = 9;
            // 
            // iconPictureBoxMaximize
            // 
            this.iconPictureBoxMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBoxMaximize.BackColor = System.Drawing.Color.WhiteSmoke;
            this.iconPictureBoxMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconPictureBoxMaximize.ForeColor = System.Drawing.SystemColors.WindowText;
            this.iconPictureBoxMaximize.IconChar = FontAwesome.Sharp.IconChar.Wrench;
            this.iconPictureBoxMaximize.IconColor = System.Drawing.SystemColors.WindowText;
            this.iconPictureBoxMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBoxMaximize.IconSize = 15;
            this.iconPictureBoxMaximize.Location = new System.Drawing.Point(753, 0);
            this.iconPictureBoxMaximize.Name = "iconPictureBoxMaximize";
            this.iconPictureBoxMaximize.Size = new System.Drawing.Size(17, 15);
            this.iconPictureBoxMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPictureBoxMaximize.TabIndex = 78;
            this.iconPictureBoxMaximize.TabStop = false;
            this.iconPictureBoxMaximize.Click += new System.EventHandler(this.iconPictureBoxMaximize_Click);
            // 
            // pic_Exit
            // 
            this.pic_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Exit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pic_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Exit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.pic_Exit.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.pic_Exit.IconColor = System.Drawing.SystemColors.WindowText;
            this.pic_Exit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pic_Exit.IconSize = 15;
            this.pic_Exit.Location = new System.Drawing.Point(774, 0);
            this.pic_Exit.Name = "pic_Exit";
            this.pic_Exit.Size = new System.Drawing.Size(17, 15);
            this.pic_Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_Exit.TabIndex = 77;
            this.pic_Exit.TabStop = false;
            this.pic_Exit.Click += new System.EventHandler(this.pic_Exit_Click);
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
            this.lblTitleFormDetail.Location = new System.Drawing.Point(8, 16);
            this.lblTitleFormDetail.Name = "lblTitleFormDetail";
            this.lblTitleFormDetail.Size = new System.Drawing.Size(101, 22);
            this.lblTitleFormDetail.TabIndex = 0;
            this.lblTitleFormDetail.Text = "Tiêu đề form";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(791, 303);
            this.panel3.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBottom.Controls.Add(this.tableLayoutPanelBottom);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 353);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(791, 39);
            this.pnlBottom.TabIndex = 8;
            // 
            // tableLayoutPanelBottom
            // 
            this.tableLayoutPanelBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanelBottom.ColumnCount = 5;
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelBottom.Controls.Add(this.btnHelp, 0, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.btnCancel, 4, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.btnSave, 3, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.btnSaveNew, 2, 0);
            this.tableLayoutPanelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBottom.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanelBottom.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelBottom.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            this.tableLayoutPanelBottom.RowCount = 1;
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBottom.Size = new System.Drawing.Size(791, 39);
            this.tableLayoutPanelBottom.TabIndex = 0;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
            this.btnHelp.Location = new System.Drawing.Point(8, 8);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(8, 8, 3, 8);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(69, 23);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "Trợ giúp";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.btnCancel.Location = new System.Drawing.Point(717, 8);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
            this.btnSave.Location = new System.Drawing.Point(622, 8);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu && Thoát";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.btnSaveNew.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSaveNew.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(107)))), ((int)(((byte)(151)))));
            this.btnSaveNew.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(107)))), ((int)(((byte)(151)))));
            this.btnSaveNew.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btnSaveNew.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSaveNew.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSaveNew.Appearance.Options.UseBackColor = true;
            this.btnSaveNew.Appearance.Options.UseBorderColor = true;
            this.btnSaveNew.Appearance.Options.UseFont = true;
            this.btnSaveNew.Appearance.Options.UseForeColor = true;
            this.btnSaveNew.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(194)))));
            this.btnSaveNew.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(194)))));
            this.btnSaveNew.AppearanceHovered.BorderColor = System.Drawing.Color.Black;
            this.btnSaveNew.AppearanceHovered.Options.UseBackColor = true;
            this.btnSaveNew.AppearanceHovered.Options.UseBorderColor = true;
            this.btnSaveNew.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(87)))), ((int)(((byte)(123)))));
            this.btnSaveNew.AppearancePressed.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(87)))), ((int)(((byte)(123)))));
            this.btnSaveNew.AppearancePressed.BorderColor = System.Drawing.Color.Black;
            this.btnSaveNew.AppearancePressed.Options.UseBackColor = true;
            this.btnSaveNew.AppearancePressed.Options.UseBorderColor = true;
            this.btnSaveNew.ColumnName = "";
            this.btnSaveNew.Description = null;
            this.btnSaveNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveNew.ImageOptions.Image")));
            this.btnSaveNew.Location = new System.Drawing.Point(520, 8);
            this.btnSaveNew.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(93, 23);
            this.btnSaveNew.TabIndex = 0;
            this.btnSaveNew.Text = "Lưu && Thêm";
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // MFormDictionnaryDetail
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(791, 392);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MFormDictionnaryDetail";
            this.Load += new System.EventHandler(this.MFormDictionnaryDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Exit)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.tableLayoutPanelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LayoutControlItem layoutControlItem4;
        private LayoutControlItem layoutControlItem5;
        protected MLabel lblTitleFormDetail;
        protected System.Windows.Forms.Panel pnlHeader;
        public MSimpleButton btnCancel;
        public MSimpleButton btnHelp;
        public MSimpleButton btnSave;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanelBottom;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Panel pnlBottom;
        private FontAwesome.Sharp.IconPictureBox pic_Exit;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBoxMaximize;
        public MSimpleButton btnSaveNew;
    }
}