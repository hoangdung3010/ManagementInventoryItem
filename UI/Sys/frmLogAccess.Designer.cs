namespace FormUI
{
    partial class frmLogAccess
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogAccess));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ucDateRangeFilter = new FormUI.ucDateRange();
            this.btnRefresh = new Guna.UI.WinForms.GunaButton();
            this.txtSearch = new MTControl.MTextEdit();
            this.cboAccount = new MTControl.MLookUpEdit();
            this.lblSearch2 = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.btnMore = new Guna.UI.WinForms.GunaButton();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.grdLogAccess = new Guna.UI.WinForms.GunaDataGridView();
            this.mDataNavigatorPaging1 = new MTControl.WrapControl.MDataNavigatorPaging();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.backgroundWorkerLogAccess = new System.ComponentModel.BackgroundWorker();
            this.gunaContextMenuStripMoreButton = new Guna.UI.WinForms.GunaContextMenuStrip();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            this.gunaContextMenuStripMoreButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1340, 654);
            this.splitContainer1.SplitterDistance = 53;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1340, 53);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.ucDateRangeFilter);
            this.splitContainer3.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainer3.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer3.Panel1.Controls.Add(this.cboAccount);
            this.splitContainer3.Panel1.Controls.Add(this.lblSearch2);
            this.splitContainer3.Panel1.Controls.Add(this.lblAccount);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnMore);
            this.splitContainer3.Size = new System.Drawing.Size(1340, 53);
            this.splitContainer3.SplitterDistance = 1284;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 45;
            // 
            // ucDateRangeFilter
            // 
            this.ucDateRangeFilter.AutoSize = true;
            this.ucDateRangeFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucDateRangeFilter.FieldName_Changed = null;
            this.ucDateRangeFilter.FieldNames = null;
            this.ucDateRangeFilter.Location = new System.Drawing.Point(178, 8);
            this.ucDateRangeFilter.Margin = new System.Windows.Forms.Padding(0);
            this.ucDateRangeFilter.MaximumSize = new System.Drawing.Size(467, 37);
            this.ucDateRangeFilter.MinimumSize = new System.Drawing.Size(233, 30);
            this.ucDateRangeFilter.Name = "ucDateRangeFilter";
            this.ucDateRangeFilter.Period_Changed = null;
            this.ucDateRangeFilter.Size = new System.Drawing.Size(460, 34);
            this.ucDateRangeFilter.TabIndex = 17;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AnimationHoverSpeed = 0.07F;
            this.btnRefresh.AnimationSpeed = 0.03F;
            this.btnRefresh.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnRefresh.BorderColor = System.Drawing.Color.Black;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRefresh.FocusedColor = System.Drawing.Color.Empty;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = null;
            this.btnRefresh.ImageSize = new System.Drawing.Size(20, 20);
            this.btnRefresh.Location = new System.Drawing.Point(923, 9);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(0, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnRefresh.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnRefresh.OnHoverForeColor = System.Drawing.Color.White;
            this.btnRefresh.OnHoverImage = null;
            this.btnRefresh.OnPressedColor = System.Drawing.Color.Black;
            this.btnRefresh.Size = new System.Drawing.Size(81, 30);
            this.btnRefresh.TabIndex = 52;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnRefresh.Click += new System.EventHandler(this.headerCheckBox_Clicked);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoIncrement = false;
            this.txtSearch.Description = null;
            this.txtSearch.Grid = null;
            this.txtSearch.IsCustomHeight = false;
            this.txtSearch.IsReadOnly = false;
            this.txtSearch.IsSetValueManual = false;
            this.txtSearch.Location = new System.Drawing.Point(740, 13);
            this.txtSearch.MaxLength = 0;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RepositoryItem = null;
            this.txtSearch.SetField = null;
            this.txtSearch.Size = new System.Drawing.Size(167, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cboAccount
            // 
            this.cboAccount.AddFields = null;
            this.cboAccount.AliasFormQuickAdd = null;
            this.cboAccount.ColumnsExtend = null;
            this.cboAccount.Description = null;
            this.cboAccount.DictionaryName = null;
            this.cboAccount.EntityName = null;
            this.cboAccount.Grid = null;
            this.cboAccount.IsAutoLoad = false;
            this.cboAccount.IsReadOnly = false;
            this.cboAccount.IsSetValueManual = false;
            this.cboAccount.KeyStore = null;
            this.cboAccount.Location = new System.Drawing.Point(90, 14);
            this.cboAccount.MapColumnName = null;
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.PrimaryKey = null;
            this.cboAccount.QuickSearchName = null;
            this.cboAccount.RepositoryItem = null;
            this.cboAccount.SetField = null;
            this.cboAccount.Size = new System.Drawing.Size(85, 23);
            this.cboAccount.Sort = null;
            this.cboAccount.TabIndex = 0;
            this.cboAccount.ValueDefault = null;
            this.cboAccount.EditValueChanged += new System.EventHandler(this.cboAccount_EditValueChanged);
            // 
            // lblSearch2
            // 
            this.lblSearch2.AutoSize = true;
            this.lblSearch2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSearch2.Location = new System.Drawing.Point(641, 17);
            this.lblSearch2.Name = "lblSearch2";
            this.lblSearch2.Size = new System.Drawing.Size(93, 15);
            this.lblSearch2.TabIndex = 53;
            this.lblSearch2.Text = "Tìm kiếm nhanh";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblAccount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblAccount.Location = new System.Drawing.Point(13, 18);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(71, 15);
            this.lblAccount.TabIndex = 55;
            this.lblAccount.Text = "Người dùng";
            // 
            // btnMore
            // 
            this.btnMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMore.AnimationHoverSpeed = 0.07F;
            this.btnMore.AnimationSpeed = 0.03F;
            this.btnMore.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnMore.BorderColor = System.Drawing.Color.Black;
            this.btnMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMore.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMore.FocusedColor = System.Drawing.Color.Empty;
            this.btnMore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMore.ForeColor = System.Drawing.Color.White;
            this.btnMore.Image = null;
            this.btnMore.ImageSize = new System.Drawing.Size(20, 20);
            this.btnMore.Location = new System.Drawing.Point(5, 12);
            this.btnMore.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnMore.MinimumSize = new System.Drawing.Size(0, 4);
            this.btnMore.Name = "btnMore";
            this.btnMore.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnMore.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnMore.OnHoverForeColor = System.Drawing.Color.White;
            this.btnMore.OnHoverImage = null;
            this.btnMore.OnPressedColor = System.Drawing.Color.Black;
            this.btnMore.Size = new System.Drawing.Size(45, 31);
            this.btnMore.TabIndex = 44;
            this.btnMore.Text = "...";
            this.btnMore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(8, 8);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.grdLogAccess);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.mDataNavigatorPaging1);
            this.splitContainer4.Size = new System.Drawing.Size(1324, 584);
            this.splitContainer4.SplitterDistance = 535;
            this.splitContainer4.TabIndex = 42;
            // 
            // grdLogAccess
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grdLogAccess.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLogAccess.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdLogAccess.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.grdLogAccess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdLogAccess.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdLogAccess.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLogAccess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdLogAccess.ColumnHeadersHeight = 26;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdLogAccess.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdLogAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLogAccess.EnableHeadersVisualStyles = false;
            this.grdLogAccess.GridColor = System.Drawing.Color.Gainsboro;
            this.grdLogAccess.Location = new System.Drawing.Point(0, 0);
            this.grdLogAccess.MultiSelect = false;
            this.grdLogAccess.Name = "grdLogAccess";
            this.grdLogAccess.ReadOnly = true;
            this.grdLogAccess.RowHeadersVisible = false;
            this.grdLogAccess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLogAccess.Size = new System.Drawing.Size(1324, 535);
            this.grdLogAccess.TabIndex = 16;
            this.grdLogAccess.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.grdLogAccess.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.grdLogAccess.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.grdLogAccess.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdLogAccess.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.grdLogAccess.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.grdLogAccess.ThemeStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.grdLogAccess.ThemeStyle.GridColor = System.Drawing.Color.Gainsboro;
            this.grdLogAccess.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.grdLogAccess.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdLogAccess.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdLogAccess.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grdLogAccess.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.grdLogAccess.ThemeStyle.HeaderStyle.Height = 26;
            this.grdLogAccess.ThemeStyle.ReadOnly = true;
            this.grdLogAccess.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grdLogAccess.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdLogAccess.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdLogAccess.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.grdLogAccess.ThemeStyle.RowsStyle.Height = 22;
            this.grdLogAccess.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.grdLogAccess.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdLogAccess.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLogAccess_CellClick);
            this.grdLogAccess.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdLogAccess_MouseClick);
            // 
            // mDataNavigatorPaging1
            // 
            this.mDataNavigatorPaging1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mDataNavigatorPaging1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mDataNavigatorPaging1.Location = new System.Drawing.Point(0, 0);
            this.mDataNavigatorPaging1.Name = "mDataNavigatorPaging1";
            this.mDataNavigatorPaging1.Size = new System.Drawing.Size(1324, 45);
            this.mDataNavigatorPaging1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(11, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Size = new System.Drawing.Size(54, 3);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 41;
            // 
            // backgroundWorkerLogAccess
            // 
            this.backgroundWorkerLogAccess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLogAccess_DoWork);
            this.backgroundWorkerLogAccess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLogAccess_RunWorkerCompleted);
            // 
            // gunaContextMenuStripMoreButton
            // 
            this.gunaContextMenuStripMoreButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem});
            this.gunaContextMenuStripMoreButton.Name = "gunaContextMenuStripMoreButton";
            this.gunaContextMenuStripMoreButton.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.gunaContextMenuStripMoreButton.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaContextMenuStripMoreButton.RenderStyle.ColorTable = null;
            this.gunaContextMenuStripMoreButton.RenderStyle.RoundedEdges = true;
            this.gunaContextMenuStripMoreButton.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.gunaContextMenuStripMoreButton.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaContextMenuStripMoreButton.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gunaContextMenuStripMoreButton.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.gunaContextMenuStripMoreButton.RenderStyle.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.SystemDefault;
            this.gunaContextMenuStripMoreButton.Size = new System.Drawing.Size(95, 26);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("xóaToolStripMenuItem.Image")));
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // frmLogAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 654);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogAccess";
            this.Text = "Danh mục TTBMM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogAccess_FormClosed);
            this.Load += new System.EventHandler(this.frmLogAccess_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogAccess_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLogAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gunaContextMenuStripMoreButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLogAccess;
        private Guna.UI.WinForms.GunaDataGridView grdLogAccess;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Guna.UI.WinForms.GunaContextMenuStrip gunaContextMenuStripMoreButton;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaButton btnMore;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label lblSearch2;
        private System.Windows.Forms.Label lblAccount;
        private Guna.UI.WinForms.GunaButton btnRefresh;
        private MTControl.MLookUpEdit cboAccount;
        private MTControl.MTextEdit txtSearch;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private MTControl.WrapControl.MDataNavigatorPaging mDataNavigatorPaging1;
        private ucDateRange ucDateRangeFilter;
    }
}