
namespace FormUI
{
    partial class frmOldUser
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPlaceHolder = new Guna.UI.WinForms.GunaLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboRoleId = new MTControl.MLookUpEdit();
            this.lblRoleId = new Guna.UI.WinForms.GunaLabel();
            this.mtreeLookUpDonVi = new MTControl.MTreeLookUpEdit();
            this.mTreeLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.lblSearchAdvanced = new Guna.UI.WinForms.GunaLabel();
            this.txtSearchUser = new DevExpress.XtraEditors.TextEdit();
            this.btnAddNewUser = new Guna.UI.WinForms.GunaButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mDataNavigatorPaging1 = new MTControl.WrapControl.MDataNavigatorPaging();
            this.flowLayoutPanelUser = new System.Windows.Forms.FlowLayoutPanel();
            this.backgroundWorkerLoadUser = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mtreeLookUpDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchUser.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanelUser);
            this.splitContainer2.Size = new System.Drawing.Size(1178, 669);
            this.splitContainer2.SplitterDistance = 41;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 74;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 238F));
            this.tableLayoutPanel1.Controls.Add(this.lblPlaceHolder, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddNewUser, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1178, 41);
            this.tableLayoutPanel1.TabIndex = 47;
            // 
            // lblPlaceHolder
            // 
            this.lblPlaceHolder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPlaceHolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPlaceHolder.Location = new System.Drawing.Point(3, 12);
            this.lblPlaceHolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.lblPlaceHolder.Name = "lblPlaceHolder";
            this.lblPlaceHolder.Size = new System.Drawing.Size(100, 20);
            this.lblPlaceHolder.TabIndex = 46;
            this.lblPlaceHolder.Text = "Thuộc đơn vị";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboRoleId);
            this.panel2.Controls.Add(this.lblRoleId);
            this.panel2.Controls.Add(this.mtreeLookUpDonVi);
            this.panel2.Controls.Add(this.lblSearchAdvanced);
            this.panel2.Controls.Add(this.txtSearchUser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(109, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(828, 35);
            this.panel2.TabIndex = 45;
            // 
            // cboRoleId
            // 
            this.cboRoleId.AddFields = null;
            this.cboRoleId.AliasFormQuickAdd = null;
            this.cboRoleId.ColumnsExtend = null;
            this.cboRoleId.Description = null;
            this.cboRoleId.DictionaryName = null;
            this.cboRoleId.EntityName = null;
            this.cboRoleId.Grid = null;
            this.cboRoleId.IsAutoLoad = false;
            this.cboRoleId.IsReadOnly = false;
            this.cboRoleId.IsSetValueManual = false;
            this.cboRoleId.KeyStore = null;
            this.cboRoleId.Location = new System.Drawing.Point(325, 7);
            this.cboRoleId.MapColumnName = null;
            this.cboRoleId.Name = "cboRoleId";
            this.cboRoleId.PrimaryKey = null;
            this.cboRoleId.QuickSearchName = null;
            this.cboRoleId.RepositoryItem = null;
            this.cboRoleId.SetField = null;
            this.cboRoleId.Size = new System.Drawing.Size(181, 23);
            this.cboRoleId.Sort = null;
            this.cboRoleId.TabIndex = 49;
            this.cboRoleId.ValueDefault = null;
            this.cboRoleId.EditValueChanged += new System.EventHandler(this.cboRoleId_EditValueChanged);
            // 
            // lblRoleId
            // 
            this.lblRoleId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRoleId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRoleId.Location = new System.Drawing.Point(280, 9);
            this.lblRoleId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.lblRoleId.Name = "lblRoleId";
            this.lblRoleId.Size = new System.Drawing.Size(49, 20);
            this.lblRoleId.TabIndex = 48;
            this.lblRoleId.Text = "Vai trò";
            // 
            // mtreeLookUpDonVi
            // 
            this.mtreeLookUpDonVi.AddFields = null;
            this.mtreeLookUpDonVi.AliasFormQuickAdd = null;
            this.mtreeLookUpDonVi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mtreeLookUpDonVi.CustomSetFields = null;
            this.mtreeLookUpDonVi.Description = null;
            this.mtreeLookUpDonVi.DictionaryName = null;
            this.mtreeLookUpDonVi.EntityName = null;
            this.mtreeLookUpDonVi.Grid = null;
            this.mtreeLookUpDonVi.IsReadOnly = false;
            this.mtreeLookUpDonVi.IsSetValueManual = false;
            this.mtreeLookUpDonVi.KeyStore = null;
            this.mtreeLookUpDonVi.Location = new System.Drawing.Point(3, 6);
            this.mtreeLookUpDonVi.MapColumnName = null;
            this.mtreeLookUpDonVi.Name = "mtreeLookUpDonVi";
            this.mtreeLookUpDonVi.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mtreeLookUpDonVi.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtreeLookUpDonVi.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mtreeLookUpDonVi.Properties.Appearance.Options.UseBackColor = true;
            this.mtreeLookUpDonVi.Properties.Appearance.Options.UseFont = true;
            this.mtreeLookUpDonVi.Properties.Appearance.Options.UseForeColor = true;
            this.mtreeLookUpDonVi.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.mtreeLookUpDonVi.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.mtreeLookUpDonVi.Properties.AutoHeight = false;
            this.mtreeLookUpDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mtreeLookUpDonVi.Properties.ImmediatePopup = true;
            this.mtreeLookUpDonVi.Properties.NullText = "";
            this.mtreeLookUpDonVi.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.mtreeLookUpDonVi.Properties.ReadOnly = true;
            this.mtreeLookUpDonVi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.mtreeLookUpDonVi.Properties.TreeList = this.mTreeLookUpEdit1TreeList;
            this.mtreeLookUpDonVi.QuickSearchName = null;
            this.mtreeLookUpDonVi.RepositoryItem = null;
            this.mtreeLookUpDonVi.SetField = null;
            this.mtreeLookUpDonVi.Size = new System.Drawing.Size(271, 23);
            this.mtreeLookUpDonVi.TabIndex = 0;
            this.mtreeLookUpDonVi.EditValueChanged += new System.EventHandler(this.mtreeLookUpDonVi_EditValueChanged);
            // 
            // mTreeLookUpEdit1TreeList
            // 
            this.mTreeLookUpEdit1TreeList.KeyFieldName = "";
            this.mTreeLookUpEdit1TreeList.Location = new System.Drawing.Point(17, -83);
            this.mTreeLookUpEdit1TreeList.Name = "mTreeLookUpEdit1TreeList";
            this.mTreeLookUpEdit1TreeList.OptionsView.ShowAutoFilterRow = true;
            this.mTreeLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.mTreeLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.mTreeLookUpEdit1TreeList.TabIndex = 0;
            // 
            // lblSearchAdvanced
            // 
            this.lblSearchAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSearchAdvanced.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSearchAdvanced.Location = new System.Drawing.Point(512, 9);
            this.lblSearchAdvanced.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.lblSearchAdvanced.Name = "lblSearchAdvanced";
            this.lblSearchAdvanced.Size = new System.Drawing.Size(100, 20);
            this.lblSearchAdvanced.TabIndex = 47;
            this.lblSearchAdvanced.Text = "Tìm kiếm nhanh";
            // 
            // txtSearchUser
            // 
            this.txtSearchUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearchUser.Location = new System.Drawing.Point(618, 5);
            this.txtSearchUser.MaximumSize = new System.Drawing.Size(205, 26);
            this.txtSearchUser.MinimumSize = new System.Drawing.Size(205, 26);
            this.txtSearchUser.Name = "txtSearchUser";
            this.txtSearchUser.Properties.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.txtSearchUser.Properties.Appearance.Options.UseBorderColor = true;
            this.txtSearchUser.Properties.AutoHeight = false;
            this.txtSearchUser.Size = new System.Drawing.Size(205, 26);
            this.txtSearchUser.TabIndex = 1;
            this.txtSearchUser.ToolTip = "Nhập họ và tên hoặc tên đăng nhập";
            this.txtSearchUser.ToolTipAnchor = DevExpress.Utils.ToolTipAnchor.Cursor;
            this.txtSearchUser.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtSearchUser.TextChanged += new System.EventHandler(this.txtSearchUser_TextChanged);
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddNewUser.AnimationHoverSpeed = 0.07F;
            this.btnAddNewUser.AnimationSpeed = 0.03F;
            this.btnAddNewUser.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnAddNewUser.BorderColor = System.Drawing.Color.Black;
            this.btnAddNewUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewUser.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddNewUser.FocusedColor = System.Drawing.Color.Empty;
            this.btnAddNewUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddNewUser.ForeColor = System.Drawing.Color.White;
            this.btnAddNewUser.Image = null;
            this.btnAddNewUser.ImageSize = new System.Drawing.Size(20, 20);
            this.btnAddNewUser.Location = new System.Drawing.Point(1036, 7);
            this.btnAddNewUser.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(169)))), ((int)(((byte)(25)))));
            this.btnAddNewUser.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAddNewUser.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAddNewUser.OnHoverImage = null;
            this.btnAddNewUser.OnPressedColor = System.Drawing.Color.Black;
            this.btnAddNewUser.Size = new System.Drawing.Size(134, 27);
            this.btnAddNewUser.TabIndex = 0;
            this.btnAddNewUser.Text = "Thêm người dùng";
            this.btnAddNewUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.mDataNavigatorPaging1);
            this.panel1.Location = new System.Drawing.Point(2, 583);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1175, 46);
            this.panel1.TabIndex = 1;
            // 
            // mDataNavigatorPaging1
            // 
            this.mDataNavigatorPaging1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mDataNavigatorPaging1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mDataNavigatorPaging1.Location = new System.Drawing.Point(0, 0);
            this.mDataNavigatorPaging1.Name = "mDataNavigatorPaging1";
            this.mDataNavigatorPaging1.Size = new System.Drawing.Size(1175, 46);
            this.mDataNavigatorPaging1.TabIndex = 0;
            // 
            // flowLayoutPanelUser
            // 
            this.flowLayoutPanelUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelUser.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutPanelUser.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelUser.Name = "flowLayoutPanelUser";
            this.flowLayoutPanelUser.Size = new System.Drawing.Size(1172, 574);
            this.flowLayoutPanelUser.TabIndex = 0;
            // 
            // backgroundWorkerLoadUser
            // 
            this.backgroundWorkerLoadUser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoadUser_DoWork);
            this.backgroundWorkerLoadUser.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoadUser_RunWorkerCompleted);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 669);
            this.Controls.Add(this.splitContainer2);
            this.Name = "frmUser";
            this.Text = "frmUser";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mtreeLookUpDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchUser.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private Guna.UI.WinForms.GunaLabel lblPlaceHolder;
        private DevExpress.XtraEditors.TextEdit txtSearchUser;
        private Guna.UI.WinForms.GunaButton btnAddNewUser;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelUser;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoadUser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private MTControl.WrapControl.MDataNavigatorPaging mDataNavigatorPaging1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaLabel lblSearchAdvanced;
        private MTControl.MTreeLookUpEdit mtreeLookUpDonVi;
        private DevExpress.XtraTreeList.TreeList mTreeLookUpEdit1TreeList;
        private Guna.UI.WinForms.GunaLabel lblRoleId;
        private MTControl.MLookUpEdit cboRoleId;
    }
}