namespace FormUI
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.txtDangnhap = new Guna.UI.WinForms.GunaLineTextBox();
            this.pic_Exit = new FontAwesome.Sharp.IconPictureBox();
            this.txtMatkhau = new Guna.UI.WinForms.GunaLineTextBox();
            this.btnLogin = new Guna.UI.WinForms.GunaButton();
            this.btnConfigSQL = new System.Windows.Forms.LinkLabel();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.lblVersion = new System.Windows.Forms.Label();
            this.iconShowPass = new FontAwesome.Sharp.IconPictureBox();
            this.gunaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconShowPass)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.gunaPanel1.Controls.Add(this.gunaLabel2);
            this.gunaPanel1.Controls.Add(this.pictureBox1);
            this.gunaPanel1.Controls.Add(this.gunaLabel1);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(158, 251);
            this.gunaPanel1.TabIndex = 4;
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.DarkOrange;
            this.gunaLabel2.Location = new System.Drawing.Point(14, 157);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(126, 15);
            this.gunaLabel2.TabIndex = 1;
            this.gunaLabel2.Text = "Phần mềm quản lý";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FormUI.Properties.Resources.avatar_product_64;
            this.pictureBox1.Location = new System.Drawing.Point(4, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.ForeColor = System.Drawing.Color.White;
            this.gunaLabel1.Location = new System.Drawing.Point(1, 137);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(155, 20);
            this.gunaLabel1.TabIndex = 0;
            this.gunaLabel1.Text = "TRANG THIẾT BỊ";
            // 
            // txtDangnhap
            // 
            this.txtDangnhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(40)))), ((int)(((byte)(34)))));
            this.txtDangnhap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDangnhap.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtDangnhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDangnhap.ForeColor = System.Drawing.Color.White;
            this.txtDangnhap.LineColor = System.Drawing.Color.Gainsboro;
            this.txtDangnhap.LineSize = 1;
            this.txtDangnhap.Location = new System.Drawing.Point(234, 36);
            this.txtDangnhap.Name = "txtDangnhap";
            this.txtDangnhap.PasswordChar = '\0';
            this.txtDangnhap.SelectedText = "";
            this.txtDangnhap.Size = new System.Drawing.Size(249, 26);
            this.txtDangnhap.TabIndex = 0;
            // 
            // pic_Exit
            // 
            this.pic_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(40)))), ((int)(((byte)(34)))));
            this.pic_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Exit.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.pic_Exit.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.pic_Exit.IconColor = System.Drawing.SystemColors.HighlightText;
            this.pic_Exit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pic_Exit.IconSize = 18;
            this.pic_Exit.Location = new System.Drawing.Point(525, 2);
            this.pic_Exit.Name = "pic_Exit";
            this.pic_Exit.Size = new System.Drawing.Size(22, 18);
            this.pic_Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_Exit.TabIndex = 11;
            this.pic_Exit.TabStop = false;
            this.pic_Exit.Click += new System.EventHandler(this.pic_Exit_Click_1);
            // 
            // txtMatkhau
            // 
            this.txtMatkhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(40)))), ((int)(((byte)(34)))));
            this.txtMatkhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMatkhau.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtMatkhau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMatkhau.ForeColor = System.Drawing.Color.White;
            this.txtMatkhau.LineColor = System.Drawing.Color.Gainsboro;
            this.txtMatkhau.LineSize = 1;
            this.txtMatkhau.Location = new System.Drawing.Point(234, 96);
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.PasswordChar = '●';
            this.txtMatkhau.SelectedText = "";
            this.txtMatkhau.Size = new System.Drawing.Size(225, 26);
            this.txtMatkhau.TabIndex = 1;
            this.txtMatkhau.Text = "Mật khẩu";
            this.txtMatkhau.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.AnimationHoverSpeed = 0.07F;
            this.btnLogin.AnimationSpeed = 0.03F;
            this.btnLogin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(40)))), ((int)(((byte)(34)))));
            this.btnLogin.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnLogin.BorderSize = 1;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogin.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Image = null;
            this.btnLogin.ImageSize = new System.Drawing.Size(20, 20);
            this.btnLogin.Location = new System.Drawing.Point(234, 151);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnLogin.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnLogin.OnHoverForeColor = System.Drawing.Color.White;
            this.btnLogin.OnHoverImage = null;
            this.btnLogin.OnPressedColor = System.Drawing.Color.Black;
            this.btnLogin.Size = new System.Drawing.Size(249, 31);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnConfigSQL
            // 
            this.btnConfigSQL.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnConfigSQL.AutoSize = true;
            this.btnConfigSQL.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfigSQL.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnConfigSQL.Location = new System.Drawing.Point(295, 192);
            this.btnConfigSQL.Name = "btnConfigSQL";
            this.btnConfigSQL.Size = new System.Drawing.Size(127, 15);
            this.btnConfigSQL.TabIndex = 3;
            this.btnConfigSQL.TabStop = true;
            this.btnConfigSQL.Text = "Cấu hình Cơ sở dữ liệu";
            this.btnConfigSQL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnConfigSQL_LinkClicked);
            this.btnConfigSQL.Click += new System.EventHandler(this.btnConfigSQL_Click);
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(231, 222);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblVersion.Size = new System.Drawing.Size(259, 13);
            this.lblVersion.TabIndex = 12;
            this.lblVersion.Text = "Phiên bản R26, phát hành ngày 20/12/2022";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconShowPass
            // 
            this.iconShowPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(40)))), ((int)(((byte)(34)))));
            this.iconShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconShowPass.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.iconShowPass.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.iconShowPass.IconColor = System.Drawing.SystemColors.HighlightText;
            this.iconShowPass.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconShowPass.IconSize = 18;
            this.iconShowPass.Location = new System.Drawing.Point(462, 104);
            this.iconShowPass.Margin = new System.Windows.Forms.Padding(0);
            this.iconShowPass.Name = "iconShowPass";
            this.iconShowPass.Size = new System.Drawing.Size(28, 18);
            this.iconShowPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconShowPass.TabIndex = 14;
            this.iconShowPass.TabStop = false;
            this.iconShowPass.Click += new System.EventHandler(this.iconShowPass_Click);
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(40)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(548, 251);
            this.Controls.Add(this.iconShowPass);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnConfigSQL);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtMatkhau);
            this.Controls.Add(this.pic_Exit);
            this.Controls.Add(this.txtDangnhap);
            this.Controls.Add(this.gunaPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLogin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogin_FormClosed);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconShowPass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        //private FontAwesome.Sharp.IconPictureBox pic_Exit;
        private Guna.UI.WinForms.GunaLineTextBox txtDangnhap;
        private FontAwesome.Sharp.IconPictureBox pic_Exit;
        private Guna.UI.WinForms.GunaLineTextBox txtMatkhau;
        private Guna.UI.WinForms.GunaButton btnLogin;
        private System.Windows.Forms.LinkLabel btnConfigSQL;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private System.Windows.Forms.Label lblVersion;
        private FontAwesome.Sharp.IconPictureBox iconShowPass;
    }
}