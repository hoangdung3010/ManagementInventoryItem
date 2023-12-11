namespace FormUI
{
    partial class frmConfigSQL
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
            this.cbCheDoXacThuc = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnInitDatabase = new Guna.UI.WinForms.GunaButton();
            this.btnSave = new Guna.UI.WinForms.GunaButton();
            this.btnCheck = new Guna.UI.WinForms.GunaButton();
            this.txtPassword = new Guna.UI.WinForms.GunaLineTextBox();
            this.txtLogin = new Guna.UI.WinForms.GunaLineTextBox();
            this.txtDatabase = new Guna.UI.WinForms.GunaLineTextBox();
            this.pic_Exit = new FontAwesome.Sharp.IconPictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.cbServer = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Exit)).BeginInit();
            this.gunaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCheDoXacThuc
            // 
            this.cbCheDoXacThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCheDoXacThuc.FormattingEnabled = true;
            this.cbCheDoXacThuc.Location = new System.Drawing.Point(281, 98);
            this.cbCheDoXacThuc.Name = "cbCheDoXacThuc";
            this.cbCheDoXacThuc.Size = new System.Drawing.Size(282, 23);
            this.cbCheDoXacThuc.TabIndex = 47;
            this.cbCheDoXacThuc.SelectedIndexChanged += new System.EventHandler(this.cbCheDoXacThuc_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(149, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 15);
            this.label10.TabIndex = 48;
            this.label10.Text = "Chế độ xác thực:";
            // 
            // btnInitDatabase
            // 
            this.btnInitDatabase.AnimationHoverSpeed = 0.07F;
            this.btnInitDatabase.AnimationSpeed = 0.03F;
            this.btnInitDatabase.BaseColor = System.Drawing.Color.White;
            this.btnInitDatabase.BorderColor = System.Drawing.Color.DimGray;
            this.btnInitDatabase.BorderSize = 1;
            this.btnInitDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInitDatabase.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnInitDatabase.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnInitDatabase.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInitDatabase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnInitDatabase.Image = null;
            this.btnInitDatabase.ImageSize = new System.Drawing.Size(20, 20);
            this.btnInitDatabase.Location = new System.Drawing.Point(143, 277);
            this.btnInitDatabase.Name = "btnInitDatabase";
            this.btnInitDatabase.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnInitDatabase.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnInitDatabase.OnHoverForeColor = System.Drawing.Color.White;
            this.btnInitDatabase.OnHoverImage = null;
            this.btnInitDatabase.OnPressedColor = System.Drawing.Color.Black;
            this.btnInitDatabase.Size = new System.Drawing.Size(132, 31);
            this.btnInitDatabase.TabIndex = 46;
            this.btnInitDatabase.Text = "KHỞI TẠO DỮ LIỆU";
            this.btnInitDatabase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnInitDatabase.Click += new System.EventHandler(this.btnInitDatabase_Click);
            // 
            // btnSave
            // 
            this.btnSave.AnimationHoverSpeed = 0.07F;
            this.btnSave.AnimationSpeed = 0.03F;
            this.btnSave.BaseColor = System.Drawing.Color.White;
            this.btnSave.BorderColor = System.Drawing.Color.DimGray;
            this.btnSave.BorderSize = 1;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSave.Image = null;
            this.btnSave.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSave.Location = new System.Drawing.Point(425, 277);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnSave.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSave.OnHoverImage = null;
            this.btnSave.OnPressedColor = System.Drawing.Color.Black;
            this.btnSave.Size = new System.Drawing.Size(138, 31);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "LƯU";
            this.btnSave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.AnimationHoverSpeed = 0.07F;
            this.btnCheck.AnimationSpeed = 0.03F;
            this.btnCheck.BaseColor = System.Drawing.Color.White;
            this.btnCheck.BorderColor = System.Drawing.Color.DimGray;
            this.btnCheck.BorderSize = 1;
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCheck.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnCheck.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCheck.Image = null;
            this.btnCheck.ImageSize = new System.Drawing.Size(20, 20);
            this.btnCheck.Location = new System.Drawing.Point(281, 277);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnCheck.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnCheck.OnHoverForeColor = System.Drawing.Color.White;
            this.btnCheck.OnHoverImage = null;
            this.btnCheck.OnPressedColor = System.Drawing.Color.Black;
            this.btnCheck.Size = new System.Drawing.Size(138, 31);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "KIỂM TRA KẾT NỐI";
            this.btnCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPassword.LineColor = System.Drawing.Color.Gainsboro;
            this.txtPassword.LineSize = 1;
            this.txtPassword.Location = new System.Drawing.Point(281, 231);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(282, 26);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.White;
            this.txtLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLogin.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLogin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLogin.LineColor = System.Drawing.Color.Gainsboro;
            this.txtLogin.LineSize = 1;
            this.txtLogin.Location = new System.Drawing.Point(281, 180);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.PasswordChar = '\0';
            this.txtLogin.SelectedText = "";
            this.txtLogin.Size = new System.Drawing.Size(282, 26);
            this.txtLogin.TabIndex = 2;
            // 
            // txtDatabase
            // 
            this.txtDatabase.BackColor = System.Drawing.Color.White;
            this.txtDatabase.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDatabase.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtDatabase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDatabase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDatabase.LineColor = System.Drawing.Color.Gainsboro;
            this.txtDatabase.LineSize = 1;
            this.txtDatabase.Location = new System.Drawing.Point(281, 135);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.PasswordChar = '\0';
            this.txtDatabase.SelectedText = "";
            this.txtDatabase.Size = new System.Drawing.Size(282, 26);
            this.txtDatabase.TabIndex = 1;
            // 
            // pic_Exit
            // 
            this.pic_Exit.BackColor = System.Drawing.Color.White;
            this.pic_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Exit.ForeColor = System.Drawing.SystemColors.MenuText;
            this.pic_Exit.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.pic_Exit.IconColor = System.Drawing.SystemColors.MenuText;
            this.pic_Exit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pic_Exit.IconSize = 16;
            this.pic_Exit.Location = new System.Drawing.Point(566, 0);
            this.pic_Exit.Name = "pic_Exit";
            this.pic_Exit.Size = new System.Drawing.Size(22, 16);
            this.pic_Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_Exit.TabIndex = 45;
            this.pic_Exit.TabStop = false;
            this.pic_Exit.Click += new System.EventHandler(this.pic_Exit_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(267, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(207, 21);
            this.label7.TabIndex = 10;
            this.label7.Text = "CẤU HÌNH CƠ SỞ DỮ LIỆU";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(149, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Mật khẩu :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(149, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tên người dùng :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(149, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tên cơ sở dữ liệu :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(149, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên máy chủ SQL :";
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.gunaPanel1.Controls.Add(this.iconPictureBox1);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(137, 339);
            this.gunaPanel1.TabIndex = 11;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Cogs;
            this.iconPictureBox1.IconColor = System.Drawing.Color.WhiteSmoke;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 116;
            this.iconPictureBox1.Location = new System.Drawing.Point(0, 69);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(134, 116);
            this.iconPictureBox1.TabIndex = 6;
            this.iconPictureBox1.TabStop = false;
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this;
            // 
            // cbServer
            // 
            this.cbServer.FormattingEnabled = true;
            this.cbServer.Location = new System.Drawing.Point(281, 55);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(282, 23);
            this.cbServer.TabIndex = 49;
            // 
            // frmConfigSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 339);
            this.Controls.Add(this.cbServer);
            this.Controls.Add(this.cbCheDoXacThuc);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnInitDatabase);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.pic_Exit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gunaPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmConfigSQL";
            this.Text = "Đổi mật khẩu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmConfigSQL_FormClosed);
            this.Load += new System.EventHandler(this.frmConfigSQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Exit)).EndInit();
            this.gunaPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox pic_Exit;
        private Guna.UI.WinForms.GunaLineTextBox txtDatabase;
        private Guna.UI.WinForms.GunaLineTextBox txtLogin;
        private Guna.UI.WinForms.GunaLineTextBox txtPassword;
        private Guna.UI.WinForms.GunaButton btnCheck;
        private Guna.UI.WinForms.GunaButton btnSave;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private Guna.UI.WinForms.GunaButton btnInitDatabase;
        private System.Windows.Forms.ComboBox cbCheDoXacThuc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbServer;
    }
}