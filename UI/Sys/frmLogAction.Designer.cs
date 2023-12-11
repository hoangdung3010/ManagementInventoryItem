namespace FormUI
{
    partial class frmLogAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogAction));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.backgroundWorkerLogAction = new System.ComponentModel.BackgroundWorker();
            this.gunaContextMenuStripMoreButton = new Guna.UI.WinForms.GunaContextMenuStrip();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.txtSearch = new MTControl.MTextEdit();
            this.cboAccount = new MTControl.MLookUpEdit();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnRefresh = new Guna.UI.WinForms.GunaButton();
            this.ucDateRangeFilter = new FormUI.ucDateRange();
            this.btnMore = new Guna.UI.WinForms.GunaButton();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.grdLogAction = new Guna.UI.WinForms.GunaDataGridView();
            this.mDataNavigatorPaging1 = new MTControl.WrapControl.MDataNavigatorPaging();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gunaContextMenuStripMoreButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorkerLogAction
            // 
            this.backgroundWorkerLogAction.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLogAction_DoWork);
            this.backgroundWorkerLogAction.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLogAction_RunWorkerCompleted);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer1.Size = new System.Drawing.Size(1295, 654);
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer3.Panel1.Controls.Add(this.cboAccount);
            this.splitContainer3.Panel1.Controls.Add(this.lblAccount);
            this.splitContainer3.Panel1.Controls.Add(this.lblSearch);
            this.splitContainer3.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainer3.Panel1.Controls.Add(this.ucDateRangeFilter);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnMore);
            this.splitContainer3.Size = new System.Drawing.Size(1295, 50);
            this.splitContainer3.SplitterDistance = 1236;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 42;
            // 
            // txtSearch
            // 
            this.txtSearch.AutoIncrement = false;
            this.txtSearch.Description = null;
            this.txtSearch.Grid = null;
            this.txtSearch.IsCustomHeight = false;
            this.txtSearch.IsReadOnly = false;
            this.txtSearch.IsSetValueManual = false;
            this.txtSearch.Location = new System.Drawing.Point(729, 14);
            this.txtSearch.MaxLength = 0;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RepositoryItem = null;
            this.txtSearch.SetField = null;
            this.txtSearch.Size = new System.Drawing.Size(189, 22);
            this.txtSearch.TabIndex = 64;
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
            this.cboAccount.Location = new System.Drawing.Point(83, 14);
            this.cboAccount.MapColumnName = null;
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.PrimaryKey = null;
            this.cboAccount.QuickSearchName = null;
            this.cboAccount.RepositoryItem = null;
            this.cboAccount.SetField = null;
            this.cboAccount.Size = new System.Drawing.Size(98, 23);
            this.cboAccount.Sort = null;
            this.cboAccount.TabIndex = 42;
            this.cboAccount.ValueDefault = null;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblAccount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblAccount.Location = new System.Drawing.Point(3, 18);
            this.lblAccount.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(71, 15);
            this.lblAccount.TabIndex = 61;
            this.lblAccount.Text = "Người dùng";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSearch.Location = new System.Drawing.Point(629, 17);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(93, 15);
            this.lblSearch.TabIndex = 60;
            this.lblSearch.Text = "Tìm kiếm nhanh";
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
            this.btnRefresh.Location = new System.Drawing.Point(924, 8);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(0, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnRefresh.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnRefresh.OnHoverForeColor = System.Drawing.Color.White;
            this.btnRefresh.OnHoverImage = null;
            this.btnRefresh.OnPressedColor = System.Drawing.Color.Black;
            this.btnRefresh.Size = new System.Drawing.Size(92, 30);
            this.btnRefresh.TabIndex = 58;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ucDateRangeFilter
            // 
            this.ucDateRangeFilter.AutoSize = true;
            this.ucDateRangeFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucDateRangeFilter.FieldName_Changed = null;
            this.ucDateRangeFilter.FieldNames = null;
            this.ucDateRangeFilter.Location = new System.Drawing.Point(184, 7);
            this.ucDateRangeFilter.Margin = new System.Windows.Forms.Padding(0);
            this.ucDateRangeFilter.MaximumSize = new System.Drawing.Size(1112, 58);
            this.ucDateRangeFilter.MinimumSize = new System.Drawing.Size(350, 0);
            this.ucDateRangeFilter.Name = "ucDateRangeFilter";
            this.ucDateRangeFilter.Period_Changed = null;
            this.ucDateRangeFilter.Size = new System.Drawing.Size(442, 36);
            this.ucDateRangeFilter.TabIndex = 63;
            // 
            // btnMore
            // 
            this.btnMore.Anchor = System.Windows.Forms.AnchorStyles.Right;
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
            this.btnMore.Location = new System.Drawing.Point(4, 10);
            this.btnMore.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnMore.MinimumSize = new System.Drawing.Size(0, 3);
            this.btnMore.Name = "btnMore";
            this.btnMore.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnMore.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnMore.OnHoverForeColor = System.Drawing.Color.White;
            this.btnMore.OnHoverImage = null;
            this.btnMore.OnPressedColor = System.Drawing.Color.Black;
            this.btnMore.Size = new System.Drawing.Size(46, 30);
            this.btnMore.TabIndex = 38;
            this.btnMore.Text = "...";
            this.btnMore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(8, 8);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.grdLogAction);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.mDataNavigatorPaging1);
            this.splitContainer4.Size = new System.Drawing.Size(1279, 587);
            this.splitContainer4.SplitterDistance = 533;
            this.splitContainer4.TabIndex = 44;
            // 
            // grdLogAction
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grdLogAction.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLogAction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdLogAction.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grdLogAction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdLogAction.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdLogAction.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLogAction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdLogAction.ColumnHeadersHeight = 26;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdLogAction.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdLogAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLogAction.EnableHeadersVisualStyles = false;
            this.grdLogAction.GridColor = System.Drawing.Color.Gainsboro;
            this.grdLogAction.Location = new System.Drawing.Point(0, 0);
            this.grdLogAction.Margin = new System.Windows.Forms.Padding(0);
            this.grdLogAction.MultiSelect = false;
            this.grdLogAction.Name = "grdLogAction";
            this.grdLogAction.ReadOnly = true;
            this.grdLogAction.RowHeadersVisible = false;
            this.grdLogAction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLogAction.Size = new System.Drawing.Size(1279, 533);
            this.grdLogAction.TabIndex = 16;
            this.grdLogAction.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.grdLogAction.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.grdLogAction.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.grdLogAction.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdLogAction.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.grdLogAction.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.grdLogAction.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grdLogAction.ThemeStyle.GridColor = System.Drawing.Color.Gainsboro;
            this.grdLogAction.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.grdLogAction.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdLogAction.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdLogAction.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grdLogAction.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.grdLogAction.ThemeStyle.HeaderStyle.Height = 26;
            this.grdLogAction.ThemeStyle.ReadOnly = true;
            this.grdLogAction.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grdLogAction.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdLogAction.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdLogAction.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.grdLogAction.ThemeStyle.RowsStyle.Height = 22;
            this.grdLogAction.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.grdLogAction.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdLogAction.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLogAccess_CellClick);
            this.grdLogAction.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdLogAction_MouseClick);
            // 
            // mDataNavigatorPaging1
            // 
            this.mDataNavigatorPaging1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mDataNavigatorPaging1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mDataNavigatorPaging1.Location = new System.Drawing.Point(0, 0);
            this.mDataNavigatorPaging1.Name = "mDataNavigatorPaging1";
            this.mDataNavigatorPaging1.Size = new System.Drawing.Size(1279, 50);
            this.mDataNavigatorPaging1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Size = new System.Drawing.Size(54, 3);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 41;
            // 
            // frmLogAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1295, 654);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogAction";
            this.Text = "Danh mục TTBMM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogAccess_FormClosed);
            this.Load += new System.EventHandler(this.frmLogAction_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogAction_KeyDown);
            this.gunaContextMenuStripMoreButton.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLogAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLogAction;
        private Guna.UI.WinForms.GunaDataGridView grdLogAction;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Guna.UI.WinForms.GunaContextMenuStrip gunaContextMenuStripMoreButton;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private Guna.UI.WinForms.GunaButton btnMore;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblSearch;
        private Guna.UI.WinForms.GunaButton btnRefresh;
        private ucDateRange ucDateRangeFilter;
        private MTControl.MLookUpEdit cboAccount;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private MTControl.WrapControl.MDataNavigatorPaging mDataNavigatorPaging1;
        private MTControl.MTextEdit txtSearch;
    }
}