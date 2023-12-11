using MTControl;
using DevExpress.XtraLayout;
namespace FormUI
{
    partial class MFormBusinessDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFormBusinessDetail));
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gunaControlBoxMaximumOrMiximum = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBoxClose = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBoxHide = new Guna.UI.WinForms.GunaControlBox();
            this.gunaResize1 = new Guna.UI.WinForms.GunaResize(this.components);
            this.gunaDragControl2 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.btnHelp = new MTControl.MSimpleButton();
            this.lblTitleFormDetail = new MTControl.MLabel();
            this.btnCancel = new MTControl.MSimpleButton();
            this.btnSave = new MTControl.MSimpleButton();
            this.btnSaveNew = new MTControl.MSimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
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
            // gunaControlBoxMaximumOrMiximum
            // 
            this.gunaControlBoxMaximumOrMiximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBoxMaximumOrMiximum.Animated = true;
            this.gunaControlBoxMaximumOrMiximum.AnimationHoverSpeed = 0.07F;
            this.gunaControlBoxMaximumOrMiximum.AnimationSpeed = 0.03F;
            this.gunaControlBoxMaximumOrMiximum.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MaximizeBox;
            this.gunaControlBoxMaximumOrMiximum.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(85)))), ((int)(((byte)(244)))));
            this.gunaControlBoxMaximumOrMiximum.IconSize = 12F;
            this.gunaControlBoxMaximumOrMiximum.Location = new System.Drawing.Point(694, 1);
            this.gunaControlBoxMaximumOrMiximum.MaximumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxMaximumOrMiximum.MinimumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxMaximumOrMiximum.Name = "gunaControlBoxMaximumOrMiximum";
            this.gunaControlBoxMaximumOrMiximum.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaControlBoxMaximumOrMiximum.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBoxMaximumOrMiximum.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBoxMaximumOrMiximum.Size = new System.Drawing.Size(20, 20);
            this.gunaControlBoxMaximumOrMiximum.TabIndex = 5;
            // 
            // gunaControlBoxClose
            // 
            this.gunaControlBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBoxClose.Animated = true;
            this.gunaControlBoxClose.AnimationHoverSpeed = 0.07F;
            this.gunaControlBoxClose.AnimationSpeed = 0.03F;
            this.gunaControlBoxClose.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(85)))), ((int)(((byte)(244)))));
            this.gunaControlBoxClose.IconSize = 12F;
            this.gunaControlBoxClose.Location = new System.Drawing.Point(719, 1);
            this.gunaControlBoxClose.MaximumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxClose.MinimumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxClose.Name = "gunaControlBoxClose";
            this.gunaControlBoxClose.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaControlBoxClose.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBoxClose.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBoxClose.Size = new System.Drawing.Size(20, 20);
            this.gunaControlBoxClose.TabIndex = 3;
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
            this.gunaControlBoxHide.Location = new System.Drawing.Point(666, 1);
            this.gunaControlBoxHide.MaximumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxHide.Name = "gunaControlBoxHide";
            this.gunaControlBoxHide.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaControlBoxHide.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBoxHide.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBoxHide.Size = new System.Drawing.Size(20, 20);
            this.gunaControlBoxHide.TabIndex = 4;
            // 
            // gunaResize1
            // 
            this.gunaResize1.TargetForm = this;
            // 
            // gunaDragControl2
            // 
            this.gunaDragControl2.TargetControl = this;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
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
            this.btnHelp.Location = new System.Drawing.Point(8, 360);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(8, 8, 3, 8);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(69, 24);
            this.btnHelp.TabIndex = 8;
            this.btnHelp.Text = "Trợ giúp";
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
            this.lblTitleFormDetail.Location = new System.Drawing.Point(5, 1);
            this.lblTitleFormDetail.Name = "lblTitleFormDetail";
            this.lblTitleFormDetail.Size = new System.Drawing.Size(101, 22);
            this.lblTitleFormDetail.TabIndex = 0;
            this.lblTitleFormDetail.Text = "Tiêu đề form";
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
            this.btnCancel.Location = new System.Drawing.Point(670, 360);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
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
            this.btnSave.Location = new System.Drawing.Point(575, 360);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 24);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu && Thoát";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.btnSaveNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnSaveNew.Location = new System.Drawing.Point(474, 360);
            this.btnSaveNew.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(93, 24);
            this.btnSaveNew.TabIndex = 5;
            this.btnSaveNew.Text = "Lưu && Thêm";
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // MFormBusinessDetail
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(746, 392);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblTitleFormDetail);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gunaControlBoxMaximumOrMiximum);
            this.Controls.Add(this.btnSaveNew);
            this.Controls.Add(this.gunaControlBoxClose);
            this.Controls.Add(this.gunaControlBoxHide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MFormBusinessDetail";
            this.Load += new System.EventHandler(this.MFormDictionnaryDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LayoutControlItem layoutControlItem4;
        private LayoutControlItem layoutControlItem5;
        protected MLabel lblTitleFormDetail;
        public MSimpleButton btnHelp;
        public MSimpleButton btnCancel;
        public MSimpleButton btnSave;
        public MSimpleButton btnSaveNew;
        private Guna.UI.WinForms.GunaResize gunaResize1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl2;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        public Guna.UI.WinForms.GunaControlBox gunaControlBoxMaximumOrMiximum;
        public Guna.UI.WinForms.GunaControlBox gunaControlBoxHide;
        public Guna.UI.WinForms.GunaControlBox gunaControlBoxClose;
    }
}