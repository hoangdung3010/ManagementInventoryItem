namespace FormUI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitBody = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnlLeftMenuMain = new System.Windows.Forms.Panel();
            this.pnlSliderBarBottom = new System.Windows.Forms.Panel();
            this.datetime_calendar = new Guna.UI.WinForms.GunaDateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.Panel_Title = new Guna.UI.WinForms.GunaPanel();
            this.iconBtnCollapseMenu = new FontAwesome.Sharp.IconButton();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_InfoUser = new DevExpress.XtraEditors.SimpleButton();
            this.picAvatar = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.btnAddRole = new Guna.UI.WinForms.GunaButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pic_Exit = new FontAwesome.Sharp.IconPictureBox();
            this.pic_Minimize = new FontAwesome.Sharp.IconPictureBox();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitBody)).BeginInit();
            this.splitBody.SuspendLayout();
            this.pnlSliderBarBottom.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.SuspendLayout();
            this.Panel_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Minimize)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitBody);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1250, 675);
            this.panel2.TabIndex = 0;
            // 
            // splitBody
            // 
            this.splitBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitBody.Location = new System.Drawing.Point(0, 0);
            this.splitBody.Name = "splitBody";
            this.splitBody.Panel1.Controls.Add(this.pnlLeftMenuMain);
            this.splitBody.Panel1.Controls.Add(this.pnlSliderBarBottom);
            this.splitBody.Panel1.Text = "Panel1";
            this.splitBody.Panel2.Controls.Add(this.panel3);
            this.splitBody.Panel2.Controls.Add(this.pnlBody);
            this.splitBody.Panel2.Text = "Panel2";
            this.splitBody.ScrollBarSmallChange = 3;
            this.splitBody.ShowSplitGlyph = DevExpress.Utils.DefaultBoolean.True;
            this.splitBody.Size = new System.Drawing.Size(1250, 675);
            this.splitBody.SplitterPosition = 215;
            this.splitBody.TabIndex = 0;
            // 
            // pnlLeftMenuMain
            // 
            this.pnlLeftMenuMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLeftMenuMain.AutoScroll = true;
            this.pnlLeftMenuMain.AutoSize = true;
            this.pnlLeftMenuMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.pnlLeftMenuMain.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftMenuMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLeftMenuMain.Name = "pnlLeftMenuMain";
            this.pnlLeftMenuMain.Size = new System.Drawing.Size(225, 1314);
            this.pnlLeftMenuMain.TabIndex = 7;
            // 
            // pnlSliderBarBottom
            // 
            this.pnlSliderBarBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSliderBarBottom.Controls.Add(this.datetime_calendar);
            this.pnlSliderBarBottom.Location = new System.Drawing.Point(0, 1314);
            this.pnlSliderBarBottom.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSliderBarBottom.Name = "pnlSliderBarBottom";
            this.pnlSliderBarBottom.Size = new System.Drawing.Size(455, 36);
            this.pnlSliderBarBottom.TabIndex = 0;
            // 
            // datetime_calendar
            // 
            this.datetime_calendar.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(66)))));
            this.datetime_calendar.BorderColor = System.Drawing.Color.Silver;
            this.datetime_calendar.BorderSize = 0;
            this.datetime_calendar.CustomFormat = null;
            this.datetime_calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datetime_calendar.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.datetime_calendar.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.datetime_calendar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.datetime_calendar.ForeColor = System.Drawing.Color.White;
            this.datetime_calendar.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.datetime_calendar.Location = new System.Drawing.Point(0, 0);
            this.datetime_calendar.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.datetime_calendar.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.datetime_calendar.Name = "datetime_calendar";
            this.datetime_calendar.OnHoverBaseColor = System.Drawing.Color.White;
            this.datetime_calendar.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.datetime_calendar.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.datetime_calendar.OnPressedColor = System.Drawing.Color.Black;
            this.datetime_calendar.Size = new System.Drawing.Size(455, 36);
            this.datetime_calendar.TabIndex = 6;
            this.datetime_calendar.Text = "8:38:08 AM";
            this.datetime_calendar.Value = new System.DateTime(2020, 8, 5, 8, 38, 8, 538);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(45)))));
            this.panel3.Controls.Add(this.lblDescription);
            this.panel3.Controls.Add(this.lblVersion);
            this.panel3.Location = new System.Drawing.Point(0, 652);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1025, 22);
            this.panel3.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(3, 4);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDescription.Size = new System.Drawing.Size(293, 13);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Đăng nhập: 20/12/2022 18:10:00, Đơn vị: CQLNV";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblVersion.Location = new System.Drawing.Point(761, 4);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblVersion.Size = new System.Drawing.Size(259, 13);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Phiên bản R26, phát hành ngày 20/12/2022";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBody.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1023, 651);
            this.pnlBody.TabIndex = 1;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 54);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainerMain.Panel2Collapsed = true;
            this.splitContainerMain.Size = new System.Drawing.Size(1250, 675);
            this.splitContainerMain.SplitterDistance = 649;
            this.splitContainerMain.SplitterWidth = 1;
            this.splitContainerMain.TabIndex = 24;
            // 
            // Panel_Title
            // 
            this.Panel_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(45)))));
            this.Panel_Title.Controls.Add(this.iconBtnCollapseMenu);
            this.Panel_Title.Controls.Add(this.gunaLabel2);
            this.Panel_Title.Controls.Add(this.pictureBox1);
            this.Panel_Title.Controls.Add(this.gunaLabel1);
            this.Panel_Title.Controls.Add(this.lblMainTitle);
            this.Panel_Title.Controls.Add(this.flowLayoutPanel1);
            this.Panel_Title.Controls.Add(this.panel1);
            this.Panel_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Title.Location = new System.Drawing.Point(0, 0);
            this.Panel_Title.Name = "Panel_Title";
            this.Panel_Title.Size = new System.Drawing.Size(1250, 54);
            this.Panel_Title.TabIndex = 1;
            // 
            // iconBtnCollapseMenu
            // 
            this.iconBtnCollapseMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconBtnCollapseMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconBtnCollapseMenu.IconChar = FontAwesome.Sharp.IconChar.AlignJustify;
            this.iconBtnCollapseMenu.IconColor = System.Drawing.Color.White;
            this.iconBtnCollapseMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconBtnCollapseMenu.IconSize = 30;
            this.iconBtnCollapseMenu.Location = new System.Drawing.Point(190, 12);
            this.iconBtnCollapseMenu.Name = "iconBtnCollapseMenu";
            this.iconBtnCollapseMenu.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.iconBtnCollapseMenu.Size = new System.Drawing.Size(30, 30);
            this.iconBtnCollapseMenu.TabIndex = 25;
            this.iconBtnCollapseMenu.UseVisualStyleBackColor = true;
            this.iconBtnCollapseMenu.Click += new System.EventHandler(this.iconBtnCollapseMenu_Click);
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gunaLabel2.Location = new System.Drawing.Point(61, 28);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(107, 15);
            this.gunaLabel2.TabIndex = 24;
            this.gunaLabel2.Text = "Phần mềm quản lý";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FormUI.Properties.Resources.avatar_product_32;
            this.pictureBox1.Location = new System.Drawing.Point(3, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.Color.White;
            this.gunaLabel1.Location = new System.Drawing.Point(46, 8);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(131, 17);
            this.gunaLabel1.TabIndex = 22;
            this.gunaLabel1.Text = "TRANG THIẾT BỊ";
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.Location = new System.Drawing.Point(236, 22);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(71, 20);
            this.lblMainTitle.TabIndex = 21;
            this.lblMainTitle.Text = "Tiêu đề";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btn_InfoUser);
            this.flowLayoutPanel1.Controls.Add(this.picAvatar);
            this.flowLayoutPanel1.Controls.Add(this.btnAddRole);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(949, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(299, 30);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btn_InfoUser
            // 
            this.btn_InfoUser.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btn_InfoUser.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btn_InfoUser.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_InfoUser.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_InfoUser.Appearance.Options.UseBackColor = true;
            this.btn_InfoUser.Appearance.Options.UseBorderColor = true;
            this.btn_InfoUser.Appearance.Options.UseFont = true;
            this.btn_InfoUser.Appearance.Options.UseForeColor = true;
            this.btn_InfoUser.Appearance.Options.UseTextOptions = true;
            this.btn_InfoUser.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btn_InfoUser.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btn_InfoUser.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btn_InfoUser.AppearanceHovered.Options.UseBackColor = true;
            this.btn_InfoUser.AutoSize = true;
            this.btn_InfoUser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_InfoUser.ImageOptions.Image")));
            this.btn_InfoUser.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btn_InfoUser.Location = new System.Drawing.Point(261, 3);
            this.btn_InfoUser.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btn_InfoUser.Name = "btn_InfoUser";
            this.btn_InfoUser.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_InfoUser.Size = new System.Drawing.Size(38, 22);
            this.btn_InfoUser.TabIndex = 16;
            this.btn_InfoUser.Text = "cy";
            this.btn_InfoUser.ToolTip = "Đổi mật khẩu";
            this.btn_InfoUser.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_InfoUser_MouseClick);
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picAvatar.BaseColor = System.Drawing.Color.White;
            this.picAvatar.Location = new System.Drawing.Point(228, 0);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(30, 30);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 14;
            this.picAvatar.TabStop = false;
            this.picAvatar.UseTransfarantBackground = false;
            // 
            // btnAddRole
            // 
            this.btnAddRole.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddRole.AnimationHoverSpeed = 0.07F;
            this.btnAddRole.AnimationSpeed = 0.03F;
            this.btnAddRole.BackColor = System.Drawing.Color.Transparent;
            this.btnAddRole.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnAddRole.BorderColor = System.Drawing.Color.Black;
            this.btnAddRole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRole.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddRole.FocusedColor = System.Drawing.Color.Empty;
            this.btnAddRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddRole.ForeColor = System.Drawing.Color.White;
            this.btnAddRole.Image = null;
            this.btnAddRole.ImageSize = new System.Drawing.Size(20, 20);
            this.btnAddRole.Location = new System.Drawing.Point(129, 3);
            this.btnAddRole.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnAddRole.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAddRole.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAddRole.OnHoverImage = null;
            this.btnAddRole.OnPressedColor = System.Drawing.Color.Black;
            this.btnAddRole.Radius = 13;
            this.btnAddRole.Size = new System.Drawing.Size(92, 27);
            this.btnAddRole.TabIndex = 48;
            this.btnAddRole.Text = "Xem tồn kho";
            this.btnAddRole.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pic_Exit);
            this.panel1.Controls.Add(this.pic_Minimize);
            this.panel1.Location = new System.Drawing.Point(946, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 54);
            this.panel1.TabIndex = 20;
            // 
            // pic_Exit
            // 
            this.pic_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.pic_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Exit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.pic_Exit.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.pic_Exit.IconColor = System.Drawing.Color.WhiteSmoke;
            this.pic_Exit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pic_Exit.IconSize = 17;
            this.pic_Exit.Location = new System.Drawing.Point(283, 0);
            this.pic_Exit.Name = "pic_Exit";
            this.pic_Exit.Size = new System.Drawing.Size(17, 17);
            this.pic_Exit.TabIndex = 9;
            this.pic_Exit.TabStop = false;
            this.pic_Exit.Click += new System.EventHandler(this.pic_Exit_Click);
            // 
            // pic_Minimize
            // 
            this.pic_Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.pic_Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Minimize.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.pic_Minimize.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.pic_Minimize.IconColor = System.Drawing.Color.WhiteSmoke;
            this.pic_Minimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pic_Minimize.IconSize = 17;
            this.pic_Minimize.Location = new System.Drawing.Point(265, 1);
            this.pic_Minimize.Name = "pic_Minimize";
            this.pic_Minimize.Size = new System.Drawing.Size(17, 17);
            this.pic_Minimize.TabIndex = 9;
            this.pic_Minimize.TabStop = false;
            this.pic_Minimize.Click += new System.EventHandler(this.pic_Minimize_Click);
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(1250, 729);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.Panel_Title);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Phần mềm quản lý phiên thẩm vấn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitBody)).EndInit();
            this.splitBody.ResumeLayout(false);
            this.pnlSliderBarBottom.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.Panel_Title.ResumeLayout(false);
            this.Panel_Title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Minimize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaPanel Panel_Title;
        private FontAwesome.Sharp.IconPictureBox pic_Minimize;
        private FontAwesome.Sharp.IconPictureBox pic_Exit;
        private Guna.UI.WinForms.GunaCirclePictureBox picAvatar;
        private DevExpress.XtraEditors.SimpleButton btn_InfoUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SplitContainerControl splitBody;
        private System.Windows.Forms.Panel pnlLeftMenuMain;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlSliderBarBottom;
        private Guna.UI.WinForms.GunaDateTimePicker datetime_calendar;
        private FontAwesome.Sharp.IconButton iconBtnCollapseMenu;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaButton btnAddRole;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblDescription;
    }
}

