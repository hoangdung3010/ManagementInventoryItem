namespace FormUI
{
    partial class frmDM_DonVi
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
            MTControl.MButtonName mButtonName1 = new MTControl.MButtonName();
            MTControl.MButtonName mButtonName2 = new MTControl.MButtonName();
            MTControl.MButtonName mButtonName3 = new MTControl.MButtonName();
            MTControl.MButtonName mButtonName4 = new MTControl.MButtonName();
            MTControl.MButtonName mButtonName5 = new MTControl.MButtonName();
            MTControl.MButtonName mButtonName6 = new MTControl.MButtonName();
            MTControl.MButtonName mButtonName7 = new MTControl.MButtonName();
            MTControl.MButtonName mButtonName8 = new MTControl.MButtonName();
            this.backgroundWorkerLoadDonVi = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treePaging = new MTControl.MTreePaging();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new MTControl.MSimpleButton();
            this.txtSearch = new MTControl.MTextEdit();
            this.lblSearch = new System.Windows.Forms.Label();
            this.mToolbarList1 = new MTControl.MToolbarList();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorkerLoadDonVi
            // 
            this.backgroundWorkerLoadDonVi.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoadDonVi_DoWork);
            this.backgroundWorkerLoadDonVi.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoadDonVi_RunWorkerCompleted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.treePaging, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 494);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // treePaging
            // 
            this.treePaging.AllowDrop = true;
            this.treePaging.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treePaging.Appearance.Options.UseFont = true;
            this.treePaging.Appearance.Options.UseTextOptions = true;
            this.treePaging.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.treePaging.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.treePaging.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.treePaging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePaging.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.treePaging.KeyName = null;
            this.treePaging.Location = new System.Drawing.Point(1, 42);
            this.treePaging.Margin = new System.Windows.Forms.Padding(1);
            this.treePaging.Name = "treePaging";
            this.treePaging.Size = new System.Drawing.Size(798, 451);
            this.treePaging.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 35);
            this.panel1.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSearch.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Appearance.Options.UseForeColor = true;
            this.btnSearch.ColumnName = "";
            this.btnSearch.Description = null;
            this.btnSearch.Location = new System.Drawing.Point(245, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 24);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoIncrement = false;
            this.txtSearch.Description = null;
            this.txtSearch.Grid = null;
            this.txtSearch.IsCustomHeight = false;
            this.txtSearch.IsReadOnly = false;
            this.txtSearch.IsSetValueManual = false;
            this.txtSearch.Location = new System.Drawing.Point(96, 8);
            this.txtSearch.MaxLength = 0;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RepositoryItem = null;
            this.txtSearch.SetField = null;
            this.txtSearch.Size = new System.Drawing.Size(142, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.EditValueChanged += new System.EventHandler(this.txtSearch_EditValueChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(8, 11);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(82, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm kiếm nhanh";
            // 
            // mToolbarList1
            // 
            this.mToolbarList1.AllowDrop = true;
            this.mToolbarList1.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.mToolbarList1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.mToolbarList1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.mToolbarList1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mToolbarList1.Appearance.Options.UseBackColor = true;
            this.mToolbarList1.Appearance.Options.UseBorderColor = true;
            this.mToolbarList1.Appearance.Options.UseFont = true;
            this.mToolbarList1.Appearance.Options.UseTextOptions = true;
            this.mToolbarList1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.mToolbarList1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.mToolbarList1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.mToolbarList1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            mButtonName1.BeginGroup = false;
            mButtonName1.Caption = null;
            mButtonName1.CommandName = MTControl.MCommandName.AddNew;
            mButtonName1.Icon = null;
            mButtonName1.Width = 0;
            mButtonName1.XType = null;
            mButtonName2.BeginGroup = false;
            mButtonName2.Caption = null;
            mButtonName2.CommandName = MTControl.MCommandName.Duplicate;
            mButtonName2.Icon = null;
            mButtonName2.Width = 0;
            mButtonName2.XType = null;
            mButtonName3.BeginGroup = false;
            mButtonName3.Caption = null;
            mButtonName3.CommandName = MTControl.MCommandName.View;
            mButtonName3.Icon = null;
            mButtonName3.Width = 0;
            mButtonName3.XType = null;
            mButtonName4.BeginGroup = false;
            mButtonName4.Caption = null;
            mButtonName4.CommandName = MTControl.MCommandName.Edit;
            mButtonName4.Icon = null;
            mButtonName4.Width = 0;
            mButtonName4.XType = null;
            mButtonName5.BeginGroup = false;
            mButtonName5.Caption = null;
            mButtonName5.CommandName = MTControl.MCommandName.Delete;
            mButtonName5.Icon = null;
            mButtonName5.Width = 0;
            mButtonName5.XType = null;
            mButtonName6.BeginGroup = false;
            mButtonName6.Caption = null;
            mButtonName6.CommandName = MTControl.MCommandName.Print;
            mButtonName6.Icon = null;
            mButtonName6.Width = 0;
            mButtonName6.XType = null;
            mButtonName7.BeginGroup = true;
            mButtonName7.Caption = null;
            mButtonName7.CommandName = MTControl.MCommandName.Refresh;
            mButtonName7.Icon = null;
            mButtonName7.Width = 0;
            mButtonName7.XType = null;
            mButtonName8.BeginGroup = true;
            mButtonName8.Caption = null;
            mButtonName8.CommandName = MTControl.MCommandName.Help;
            mButtonName8.Icon = null;
            mButtonName8.Width = 0;
            mButtonName8.XType = null;
            this.mToolbarList1.ButtonNames = new MTControl.MButtonName[] {
        mButtonName1,
        mButtonName2,
        mButtonName3,
        mButtonName4,
        mButtonName5,
        mButtonName6,
        mButtonName7,
        mButtonName8};
            this.mToolbarList1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mToolbarList1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mToolbarList1.Location = new System.Drawing.Point(0, 0);
            this.mToolbarList1.Margin = new System.Windows.Forms.Padding(0);
            this.mToolbarList1.MyEventHandler = null;
            this.mToolbarList1.Name = "mToolbarList1";
            this.mToolbarList1.Size = new System.Drawing.Size(800, 26);
            this.mToolbarList1.TabIndex = 0;
            // 
            // frmDM_DonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mToolbarList1);
            this.Name = "frmDM_DonVi";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.Text = "frmDM_DonVi";
            this.Load += new System.EventHandler(this.frmDM_DonVi_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MTControl.MToolbarList mToolbarList1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MTControl.MTreePaging treePaging;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSearch;
        private MTControl.MSimpleButton btnSearch;
        private MTControl.MTextEdit txtSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoadDonVi;
    }
}