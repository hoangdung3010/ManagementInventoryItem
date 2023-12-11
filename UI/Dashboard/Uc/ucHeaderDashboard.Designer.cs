
namespace FormUI.Dashboard
{
    partial class ucHeaderDashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucHeaderDashboard));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSettings = new Guna.UI.WinForms.GunaButton();
            this.btnRefresh = new Guna.UI.WinForms.GunaButton();
            this.panelSubParam = new System.Windows.Forms.Panel();
            this.bgWorkerLoadData = new System.ComponentModel.BackgroundWorker();
            this.lblTitleDashboard = new MTControl.MLabel();
            this.lblSubTitle = new MTControl.MLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelSubParam.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelSubParam);
            this.splitContainer1.Size = new System.Drawing.Size(803, 77);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSettings);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.lblTitleDashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 40);
            this.panel1.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.AnimationHoverSpeed = 0.07F;
            this.btnSettings.AnimationSpeed = 0.03F;
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BaseColor = System.Drawing.Color.Gainsboro;
            this.btnSettings.BorderColor = System.Drawing.Color.Black;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSettings.FocusedColor = System.Drawing.Color.Empty;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSettings.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSettings.Location = new System.Drawing.Point(761, 3);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnSettings.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSettings.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSettings.OnHoverImage = null;
            this.btnSettings.OnPressedColor = System.Drawing.Color.Black;
            this.btnSettings.Radius = 4;
            this.btnSettings.Size = new System.Drawing.Size(38, 31);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.AnimationHoverSpeed = 0.07F;
            this.btnRefresh.AnimationSpeed = 0.03F;
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BaseColor = System.Drawing.Color.Gainsboro;
            this.btnRefresh.BorderColor = System.Drawing.Color.Black;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRefresh.FocusedColor = System.Drawing.Color.Empty;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnRefresh.ImageSize = new System.Drawing.Size(20, 20);
            this.btnRefresh.Location = new System.Drawing.Point(717, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnRefresh.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnRefresh.OnHoverForeColor = System.Drawing.Color.White;
            this.btnRefresh.OnHoverImage = null;
            this.btnRefresh.OnPressedColor = System.Drawing.Color.Black;
            this.btnRefresh.Radius = 4;
            this.btnRefresh.Size = new System.Drawing.Size(38, 31);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelSubParam
            // 
            this.panelSubParam.BackColor = System.Drawing.Color.White;
            this.panelSubParam.Controls.Add(this.lblSubTitle);
            this.panelSubParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSubParam.Location = new System.Drawing.Point(0, 0);
            this.panelSubParam.Name = "panelSubParam";
            this.panelSubParam.Size = new System.Drawing.Size(803, 36);
            this.panelSubParam.TabIndex = 0;
            // 
            // bgWorkerLoadData
            // 
            this.bgWorkerLoadData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerLoadData_DoWork);
            this.bgWorkerLoadData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerLoadData_RunWorkerCompleted);
            // 
            // lblTitleDashboard
            // 
            this.lblTitleDashboard.AllowHtmlString = true;
            this.lblTitleDashboard.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitleDashboard.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitleDashboard.Appearance.Options.UseFont = true;
            this.lblTitleDashboard.Appearance.Options.UseForeColor = true;
            this.lblTitleDashboard.Appearance.Options.UseTextOptions = true;
            this.lblTitleDashboard.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblTitleDashboard.ColumnName = "";
            this.lblTitleDashboard.Description = null;
            this.lblTitleDashboard.IsRequired = false;
            this.lblTitleDashboard.IsTitleForm = true;
            this.lblTitleDashboard.Location = new System.Drawing.Point(12, 9);
            this.lblTitleDashboard.Name = "lblTitleDashboard";
            this.lblTitleDashboard.Size = new System.Drawing.Size(130, 22);
            this.lblTitleDashboard.TabIndex = 2;
            this.lblTitleDashboard.Text = "Tiêu đề báo cáo";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AllowHtmlString = true;
            this.lblSubTitle.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSubTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSubTitle.Appearance.Options.UseFont = true;
            this.lblSubTitle.Appearance.Options.UseForeColor = true;
            this.lblSubTitle.Appearance.Options.UseTextOptions = true;
            this.lblSubTitle.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblSubTitle.ColumnName = "";
            this.lblSubTitle.Description = null;
            this.lblSubTitle.IsRequired = false;
            this.lblSubTitle.Location = new System.Drawing.Point(12, 11);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(49, 13);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Tháng này";
            // 
            // ucHeaderDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucHeaderDashboard";
            this.Size = new System.Drawing.Size(803, 77);
            this.Load += new System.EventHandler(this.ucHeaderDashboard_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSubParam.ResumeLayout(false);
            this.panelSubParam.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public MTControl.MLabel lblTitleDashboard;
        public System.Windows.Forms.Panel panelSubParam;
        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaButton btnRefresh;
        private Guna.UI.WinForms.GunaButton btnSettings;
        private System.ComponentModel.BackgroundWorker bgWorkerLoadData;
        private MTControl.MLabel lblSubTitle;
    }
}
