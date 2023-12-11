
namespace FormUI
{
    partial class frmRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRole));
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lblPlaceHolder = new Guna.UI.WinForms.GunaLabel();
            this.btnAddRole = new Guna.UI.WinForms.GunaButton();
            this.txtSearchRole = new DevExpress.XtraEditors.TextEdit();
            this.gridRole = new Guna.UI.WinForms.GunaDataGridView();
            this.RoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPermission = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colXoa = new System.Windows.Forms.DataGridViewLinkColumn();
            this.backgroundWorkerRole = new System.ComponentModel.BackgroundWorker();
            this.gunaContextMenuStripMoreButton = new Guna.UI.WinForms.GunaContextMenuStrip();
            this.rolePermissionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.thêmMớiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRole)).BeginInit();
            this.gunaContextMenuStripMoreButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.White;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer3.Panel1.Controls.Add(this.lblPlaceHolder);
            this.splitContainer3.Panel1.Controls.Add(this.btnAddRole);
            this.splitContainer3.Panel1.Controls.Add(this.txtSearchRole);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer3.Panel2.Controls.Add(this.gridRole);
            this.splitContainer3.Panel2.Padding = new System.Windows.Forms.Padding(8);
            this.splitContainer3.Size = new System.Drawing.Size(1118, 651);
            this.splitContainer3.SplitterDistance = 46;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 3;
            // 
            // lblPlaceHolder
            // 
            this.lblPlaceHolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPlaceHolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPlaceHolder.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPlaceHolder.Location = new System.Drawing.Point(4, 17);
            this.lblPlaceHolder.MaximumSize = new System.Drawing.Size(93, 15);
            this.lblPlaceHolder.Name = "lblPlaceHolder";
            this.lblPlaceHolder.Size = new System.Drawing.Size(93, 15);
            this.lblPlaceHolder.TabIndex = 48;
            this.lblPlaceHolder.Text = "Tìm kiếm nhanh";
            // 
            // btnAddRole
            // 
            this.btnAddRole.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddRole.AnimationHoverSpeed = 0.07F;
            this.btnAddRole.AnimationSpeed = 0.03F;
            this.btnAddRole.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnAddRole.BorderColor = System.Drawing.Color.Black;
            this.btnAddRole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRole.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddRole.FocusedColor = System.Drawing.Color.Empty;
            this.btnAddRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddRole.ForeColor = System.Drawing.Color.White;
            this.btnAddRole.Image = null;
            this.btnAddRole.ImageSize = new System.Drawing.Size(20, 20);
            this.btnAddRole.Location = new System.Drawing.Point(1017, 10);
            this.btnAddRole.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnAddRole.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAddRole.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAddRole.OnHoverImage = null;
            this.btnAddRole.OnPressedColor = System.Drawing.Color.Black;
            this.btnAddRole.Size = new System.Drawing.Size(92, 27);
            this.btnAddRole.TabIndex = 47;
            this.btnAddRole.Text = "Thêm mới";
            this.btnAddRole.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // txtSearchRole
            // 
            this.txtSearchRole.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSearchRole.Location = new System.Drawing.Point(103, 11);
            this.txtSearchRole.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.txtSearchRole.MaximumSize = new System.Drawing.Size(188, 26);
            this.txtSearchRole.MinimumSize = new System.Drawing.Size(188, 26);
            this.txtSearchRole.Name = "txtSearchRole";
            this.txtSearchRole.Properties.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.txtSearchRole.Properties.Appearance.Options.UseBorderColor = true;
            this.txtSearchRole.Properties.AutoHeight = false;
            this.txtSearchRole.Size = new System.Drawing.Size(188, 26);
            this.txtSearchRole.TabIndex = 45;
            this.txtSearchRole.ToolTip = "Nhập vai trò";
            this.txtSearchRole.ToolTipAnchor = DevExpress.Utils.ToolTipAnchor.Cursor;
            this.txtSearchRole.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtSearchRole.TextChanged += new System.EventHandler(this.txtSearchRole_TextChanged);
            // 
            // gridUser
            // 
            this.gridRole.AllowUserToAddRows = false;
            this.gridRole.AllowUserToDeleteRows = false;
            this.gridRole.AllowUserToOrderColumns = true;
            this.gridRole.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.gridRole.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridRole.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridRole.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gridRole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridRole.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridRole.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRole.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridRole.ColumnHeadersHeight = 26;
            this.gridRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridRole.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoleName,
            this.colActive,
            this.colPermission,
            this.colEdit,
            this.colXoa});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridRole.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRole.EnableHeadersVisualStyles = false;
            this.gridRole.GridColor = System.Drawing.Color.Gainsboro;
            this.gridRole.Location = new System.Drawing.Point(8, 8);
            this.gridRole.Margin = new System.Windows.Forms.Padding(8);
            this.gridRole.Name = "gridUser";
            this.gridRole.ReadOnly = true;
            this.gridRole.RowHeadersVisible = false;
            this.gridRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRole.Size = new System.Drawing.Size(1102, 588);
            this.gridRole.TabIndex = 0;
            this.gridRole.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.gridRole.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gridRole.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gridRole.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gridRole.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gridRole.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gridRole.ThemeStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.gridRole.ThemeStyle.GridColor = System.Drawing.Color.Gainsboro;
            this.gridRole.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.gridRole.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridRole.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridRole.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gridRole.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridRole.ThemeStyle.HeaderStyle.Height = 26;
            this.gridRole.ThemeStyle.ReadOnly = true;
            this.gridRole.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gridRole.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridRole.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridRole.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.gridRole.ThemeStyle.RowsStyle.Height = 22;
            this.gridRole.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.gridRole.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gridRole.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRole_CellContentClick);
            this.gridRole.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridRole_MouseDown);
            // 
            // RoleName
            // 
            this.RoleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RoleName.DataPropertyName = "RoleName";
            this.RoleName.HeaderText = "Vai trò";
            this.RoleName.Name = "RoleName";
            this.RoleName.ReadOnly = true;
            // 
            // colActive
            // 
            this.colActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colActive.DataPropertyName = "StatusName";
            this.colActive.HeaderText = "Trạng thái";
            this.colActive.Name = "colActive";
            this.colActive.ReadOnly = true;
            this.colActive.Width = 184;
            // 
            // colPermission
            // 
            this.colPermission.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPermission.DataPropertyName = "Id";
            this.colPermission.HeaderText = "";
            this.colPermission.Name = "colPermission";
            this.colPermission.ReadOnly = true;
            this.colPermission.Text = "Phân quyền";
            this.colPermission.UseColumnTextForLinkValue = true;
            this.colPermission.Width = 80;
            // 
            // colEdit
            // 
            this.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEdit.DataPropertyName = "Id";
            this.colEdit.HeaderText = "";
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Text = "Sửa";
            this.colEdit.UseColumnTextForLinkValue = true;
            this.colEdit.Width = 30;
            // 
            // colXoa
            // 
            this.colXoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colXoa.DataPropertyName = "Id";
            this.colXoa.HeaderText = "";
            this.colXoa.Name = "colXoa";
            this.colXoa.ReadOnly = true;
            this.colXoa.Text = "Xóa";
            this.colXoa.UseColumnTextForLinkValue = true;
            this.colXoa.Width = 30;
            // 
            // backgroundWorkerRole
            // 
            this.backgroundWorkerRole.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRole_DoWork);
            this.backgroundWorkerRole.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRole_RunWorkerCompleted);
            // 
            // gunaContextMenuStripMoreButton
            // 
            this.gunaContextMenuStripMoreButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rolePermissionToolStripMenuItem,
            this.toolStripSeparator3,
            this.thêmMớiToolStripMenuItem,
            this.sửaToolStripMenuItem,
            this.xóaToolStripMenuItem,
            this.toolStripSeparator2});
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
            this.gunaContextMenuStripMoreButton.Size = new System.Drawing.Size(138, 104);
            // 
            // rolePermissionToolStripMenuItem
            // 
            this.rolePermissionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rolePermissionToolStripMenuItem.Image")));
            this.rolePermissionToolStripMenuItem.Name = "rolePermissionToolStripMenuItem";
            this.rolePermissionToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.rolePermissionToolStripMenuItem.Text = "Phân quyền";
            this.rolePermissionToolStripMenuItem.Click += new System.EventHandler(this.rolePermissionToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(134, 6);
            // 
            // thêmMớiToolStripMenuItem
            // 
            this.thêmMớiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thêmMớiToolStripMenuItem.Image")));
            this.thêmMớiToolStripMenuItem.Name = "thêmMớiToolStripMenuItem";
            this.thêmMớiToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.thêmMớiToolStripMenuItem.Text = "Thêm mới";
            this.thêmMớiToolStripMenuItem.Click += new System.EventHandler(this.thêmMớiToolStripMenuItem_Click);
            // 
            // sửaToolStripMenuItem
            // 
            this.sửaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sửaToolStripMenuItem.Image")));
            this.sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
            this.sửaToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.sửaToolStripMenuItem.Text = "Sửa";
            this.sửaToolStripMenuItem.Click += new System.EventHandler(this.sửaToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("xóaToolStripMenuItem.Image")));
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(134, 6);
            // 
            // frmRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 651);
            this.Controls.Add(this.splitContainer3);
            this.Name = "frmRole";
            this.Text = "frmRole";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRole_FormClosed);
            this.Load += new System.EventHandler(this.frmRole_Load);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchRole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRole)).EndInit();
            this.gunaContextMenuStripMoreButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer3;
        private DevExpress.XtraEditors.TextEdit txtSearchRole;
        private Guna.UI.WinForms.GunaDataGridView gridRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActive;
        private System.Windows.Forms.DataGridViewLinkColumn colPermission;
        private System.Windows.Forms.DataGridViewLinkColumn colEdit;
        private System.Windows.Forms.DataGridViewLinkColumn colXoa;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRole;
        private Guna.UI.WinForms.GunaContextMenuStrip gunaContextMenuStripMoreButton;
        private System.Windows.Forms.ToolStripMenuItem rolePermissionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem thêmMớiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private Guna.UI.WinForms.GunaButton btnAddRole;
        private Guna.UI.WinForms.GunaLabel lblPlaceHolder;
    }
}