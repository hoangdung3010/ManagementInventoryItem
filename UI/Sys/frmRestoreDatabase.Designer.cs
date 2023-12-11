namespace FormUI
{
    partial class frmRestoreDatabase
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
            this.cb_sServerName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_sPass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_sUserID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_sPath = new System.Windows.Forms.Button();
            this.tb_sPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_sFile = new System.Windows.Forms.Button();
            this.tb_sFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_sDatabaseName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bt_Run = new System.Windows.Forms.Button();
            this.bt_Exit = new System.Windows.Forms.Button();
            this.cbCheDoXacThuc = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMaDV = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_iYear = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_sServerName
            // 
            this.cb_sServerName.FormattingEnabled = true;
            this.cb_sServerName.Location = new System.Drawing.Point(212, 28);
            this.cb_sServerName.Name = "cb_sServerName";
            this.cb_sServerName.Size = new System.Drawing.Size(333, 21);
            this.cb_sServerName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(73, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Tên máy chủ SQL";
            // 
            // tb_sPass
            // 
            this.tb_sPass.Location = new System.Drawing.Point(212, 141);
            this.tb_sPass.Name = "tb_sPass";
            this.tb_sPass.Size = new System.Drawing.Size(122, 20);
            this.tb_sPass.TabIndex = 6;
            this.tb_sPass.Text = "sa@123456654321";
            this.tb_sPass.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(73, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Mật khẩu SQL";
            // 
            // tb_sUserID
            // 
            this.tb_sUserID.Location = new System.Drawing.Point(212, 116);
            this.tb_sUserID.Name = "tb_sUserID";
            this.tb_sUserID.Size = new System.Drawing.Size(122, 20);
            this.tb_sUserID.TabIndex = 5;
            this.tb_sUserID.Text = "sa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(73, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Định danh SQL";
            // 
            // bt_sPath
            // 
            this.bt_sPath.Location = new System.Drawing.Point(525, 381);
            this.bt_sPath.Name = "bt_sPath";
            this.bt_sPath.Size = new System.Drawing.Size(32, 23);
            this.bt_sPath.TabIndex = 30;
            this.bt_sPath.Text = "......";
            this.bt_sPath.UseVisualStyleBackColor = true;
            this.bt_sPath.Click += new System.EventHandler(this.bt_sPath_Click);
            // 
            // tb_sPath
            // 
            this.tb_sPath.Enabled = false;
            this.tb_sPath.Location = new System.Drawing.Point(225, 384);
            this.tb_sPath.Name = "tb_sPath";
            this.tb_sPath.Size = new System.Drawing.Size(294, 20);
            this.tb_sPath.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(86, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Thư mục chứa dữ liệu";
            // 
            // bt_sFile
            // 
            this.bt_sFile.Location = new System.Drawing.Point(508, 186);
            this.bt_sFile.Name = "bt_sFile";
            this.bt_sFile.Size = new System.Drawing.Size(33, 23);
            this.bt_sFile.TabIndex = 27;
            this.bt_sFile.Text = "......";
            this.bt_sFile.UseVisualStyleBackColor = true;
            this.bt_sFile.Click += new System.EventHandler(this.bt_sFile_Click);
            // 
            // tb_sFile
            // 
            this.tb_sFile.Enabled = false;
            this.tb_sFile.Location = new System.Drawing.Point(208, 188);
            this.tb_sFile.Name = "tb_sFile";
            this.tb_sFile.Size = new System.Drawing.Size(294, 20);
            this.tb_sFile.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(69, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Tệp dữ liệu gốc";
            // 
            // tb_sDatabaseName
            // 
            this.tb_sDatabaseName.Location = new System.Drawing.Point(212, 87);
            this.tb_sDatabaseName.Name = "tb_sDatabaseName";
            this.tb_sDatabaseName.Size = new System.Drawing.Size(333, 20);
            this.tb_sDatabaseName.TabIndex = 4;
            this.tb_sDatabaseName.Text = "ManagementInventoryItem";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(73, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Tên CSDL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 16);
            this.label4.TabIndex = 37;
            this.label4.Text = "1. Thông tin máy chủ cơ sở dữ liệu";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(12, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(201, 16);
            this.label8.TabIndex = 38;
            this.label8.Text = "2. Tệp dữ liệu gốc (file .bak)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(30, 360);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(289, 16);
            this.label9.TabIndex = 39;
            this.label9.Text = "3. Đường dẫn lưu trữ DL sau khi khôi phục";
            // 
            // bt_Run
            // 
            this.bt_Run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Run.Location = new System.Drawing.Point(391, 225);
            this.bt_Run.Name = "bt_Run";
            this.bt_Run.Size = new System.Drawing.Size(71, 23);
            this.bt_Run.TabIndex = 9;
            this.bt_Run.Text = "Thực hiện";
            this.bt_Run.UseVisualStyleBackColor = true;
            this.bt_Run.Click += new System.EventHandler(this.bt_Run_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Exit.Location = new System.Drawing.Point(470, 225);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(71, 23);
            this.bt_Exit.TabIndex = 10;
            this.bt_Exit.Text = "Thoát";
            this.bt_Exit.UseVisualStyleBackColor = true;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // cbCheDoXacThuc
            // 
            this.cbCheDoXacThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCheDoXacThuc.FormattingEnabled = true;
            this.cbCheDoXacThuc.Location = new System.Drawing.Point(212, 55);
            this.cbCheDoXacThuc.Name = "cbCheDoXacThuc";
            this.cbCheDoXacThuc.Size = new System.Drawing.Size(333, 21);
            this.cbCheDoXacThuc.TabIndex = 3;
            this.cbCheDoXacThuc.SelectedIndexChanged += new System.EventHandler(this.cbCheDoXacThuc_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(73, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Chế độ xác thực:";
            // 
            // txtMaDV
            // 
            this.txtMaDV.Location = new System.Drawing.Point(169, 410);
            this.txtMaDV.Name = "txtMaDV";
            this.txtMaDV.Size = new System.Drawing.Size(333, 20);
            this.txtMaDV.TabIndex = 0;
            this.txtMaDV.TextChanged += new System.EventHandler(this.txtMaDV_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Crimson;
            this.label11.Location = new System.Drawing.Point(32, 413);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "(*) MÃ ĐƠN VỊ";
            // 
            // tb_iYear
            // 
            this.tb_iYear.Location = new System.Drawing.Point(169, 436);
            this.tb_iYear.Name = "tb_iYear";
            this.tb_iYear.Size = new System.Drawing.Size(122, 20);
            this.tb_iYear.TabIndex = 1;
            this.tb_iYear.Text = "2017";
            this.tb_iYear.TextChanged += new System.EventHandler(this.tb_iYear_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(30, 436);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Năm làm việc";
            // 
            // frmRestoreDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 253);
            this.Controls.Add(this.tb_iYear);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtMaDV);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbCheDoXacThuc);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_Run);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_sDatabaseName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_sPass);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_sUserID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bt_sPath);
            this.Controls.Add(this.tb_sPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bt_sFile);
            this.Controls.Add(this.tb_sFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_sServerName);
            this.Controls.Add(this.label6);
            this.MaximizeBox = false;
            this.Name = "frmRestoreDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khôi phục dữ liệu";
            this.Load += new System.EventHandler(this.frmRestoreDatabase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_sServerName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_sPass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_sUserID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bt_sPath;
        private System.Windows.Forms.TextBox tb_sPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_sFile;
        private System.Windows.Forms.TextBox tb_sFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_sDatabaseName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bt_Run;
        private System.Windows.Forms.Button bt_Exit;
        private System.Windows.Forms.ComboBox cbCheDoXacThuc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMaDV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_iYear;
        private System.Windows.Forms.Label label12;
    }
}

