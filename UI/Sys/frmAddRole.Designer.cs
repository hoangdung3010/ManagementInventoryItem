namespace FormUI
{
    partial class frmAddRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddRole));
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rdUnAvaiable = new Guna.UI.WinForms.GunaRadioButton();
            this.rdAvaiable = new Guna.UI.WinForms.GunaRadioButton();
            this.btnSave = new Guna.UI.WinForms.GunaButton();
            this.txtRoleName = new Guna.UI.WinForms.GunaLineTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.gunaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(80)))), ((int)(((byte)(141)))));
            this.gunaPanel1.Controls.Add(this.iconPictureBox1);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(137, 204);
            this.gunaPanel1.TabIndex = 1;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(80)))), ((int)(((byte)(141)))));
            this.iconPictureBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserMd;
            this.iconPictureBox1.IconColor = System.Drawing.Color.WhiteSmoke;
            this.iconPictureBox1.IconSize = 116;
            this.iconPictureBox1.Location = new System.Drawing.Point(3, 73);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(134, 116);
            this.iconPictureBox1.TabIndex = 6;
            this.iconPictureBox1.TabStop = false;
            // 
            // rdUnAvaiable
            // 
            this.rdUnAvaiable.BackColor = System.Drawing.Color.White;
            this.rdUnAvaiable.BaseColor = System.Drawing.SystemColors.Control;
            this.rdUnAvaiable.CheckedOffColor = System.Drawing.Color.Gray;
            this.rdUnAvaiable.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.rdUnAvaiable.FillColor = System.Drawing.Color.White;
            this.rdUnAvaiable.Location = new System.Drawing.Point(420, 108);
            this.rdUnAvaiable.Name = "rdUnAvaiable";
            this.rdUnAvaiable.Size = new System.Drawing.Size(87, 20);
            this.rdUnAvaiable.TabIndex = 2;
            this.rdUnAvaiable.Tag = "Status";
            this.rdUnAvaiable.Text = "Tạm ngưng";
            // 
            // rdAvaiable
            // 
            this.rdAvaiable.BackColor = System.Drawing.Color.White;
            this.rdAvaiable.BaseColor = System.Drawing.SystemColors.Control;
            this.rdAvaiable.Checked = true;
            this.rdAvaiable.CheckedOffColor = System.Drawing.Color.Gray;
            this.rdAvaiable.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.rdAvaiable.FillColor = System.Drawing.Color.White;
            this.rdAvaiable.Location = new System.Drawing.Point(225, 108);
            this.rdAvaiable.Name = "rdAvaiable";
            this.rdAvaiable.Size = new System.Drawing.Size(82, 20);
            this.rdAvaiable.TabIndex = 1;
            this.rdAvaiable.Tag = "Status";
            this.rdAvaiable.Text = "Hoạt động";
            // 
            // btnSave
            // 
            this.btnSave.AnimationHoverSpeed = 0.07F;
            this.btnSave.AnimationSpeed = 0.03F;
            this.btnSave.BaseColor = System.Drawing.Color.White;
            this.btnSave.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnSave.BorderSize = 1;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.FocusedColor = System.Drawing.Color.Empty;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSave.Image = null;
            this.btnSave.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSave.Location = new System.Drawing.Point(225, 152);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnSave.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSave.OnHoverImage = null;
            this.btnSave.OnPressedColor = System.Drawing.Color.Black;
            this.btnSave.Size = new System.Drawing.Size(282, 27);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu";
            this.btnSave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRoleName
            // 
            this.txtRoleName.BackColor = System.Drawing.Color.White;
            this.txtRoleName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRoleName.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtRoleName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRoleName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRoleName.LineColor = System.Drawing.Color.Gainsboro;
            this.txtRoleName.LineSize = 1;
            this.txtRoleName.Location = new System.Drawing.Point(225, 61);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.PasswordChar = '\0';
            this.txtRoleName.SelectedText = "";
            this.txtRoleName.Size = new System.Drawing.Size(282, 26);
            this.txtRoleName.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTitle.Location = new System.Drawing.Point(256, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(154, 21);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "THÊM MỚI VAI TRÒ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(142, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Trạng thái :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(143, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Vai trò :";
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.White;
            this.iconPictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconPictureBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.iconPictureBox2.IconColor = System.Drawing.SystemColors.WindowText;
            this.iconPictureBox2.IconSize = 15;
            this.iconPictureBox2.Location = new System.Drawing.Point(502, 2);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(17, 15);
            this.iconPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPictureBox2.TabIndex = 60;
            this.iconPictureBox2.TabStop = false;
            this.iconPictureBox2.Click += new System.EventHandler(this.pic_Exit_Click);
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this;
            // 
            // frmAddRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(519, 204);
            this.Controls.Add(this.rdUnAvaiable);
            this.Controls.Add(this.rdAvaiable);
            this.Controls.Add(this.gunaPanel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddRole";
            this.Text = "Thêm mới TTBMM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddRooms_FormClosed);
            this.Load += new System.EventHandler(this.frmAddRooms_Load);
            this.gunaPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Guna.UI.WinForms.GunaRadioButton rdUnAvaiable;
        private Guna.UI.WinForms.GunaRadioButton rdAvaiable;
        private Guna.UI.WinForms.GunaButton btnSave;
        private Guna.UI.WinForms.GunaLineTextBox txtRoleName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
    }
}