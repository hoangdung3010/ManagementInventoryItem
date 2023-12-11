namespace FormUI
{
    partial class frmPrivilege
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrivilege));
            this.lblPrivilegeList = new Guna.UI.WinForms.GunaLabel();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.flowLayoutPanelPermission = new System.Windows.Forms.FlowLayoutPanel();
            this.backgroundWorkerLoadMenu = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gunaControlBoxMaximumOrMiximum = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBoxClose = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBoxHide = new Guna.UI.WinForms.GunaControlBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPrivilegeList
            // 
            this.lblPrivilegeList.AutoSize = true;
            this.lblPrivilegeList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPrivilegeList.ForeColor = System.Drawing.Color.Black;
            this.lblPrivilegeList.Location = new System.Drawing.Point(7, 6);
            this.lblPrivilegeList.Name = "lblPrivilegeList";
            this.lblPrivilegeList.Size = new System.Drawing.Size(266, 21);
            this.lblPrivilegeList.TabIndex = 1;
            this.lblPrivilegeList.Text = "DANH SÁCH QUYỀN CỦA VAI TRÒ";
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this.panel1;
            // 
            // flowLayoutPanelPermission
            // 
            this.flowLayoutPanelPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelPermission.AutoScroll = true;
            this.flowLayoutPanelPermission.Location = new System.Drawing.Point(1, 48);
            this.flowLayoutPanelPermission.Name = "flowLayoutPanelPermission";
            this.flowLayoutPanelPermission.Size = new System.Drawing.Size(940, 598);
            this.flowLayoutPanelPermission.TabIndex = 61;
            // 
            // backgroundWorkerLoadMenu
            // 
            this.backgroundWorkerLoadMenu.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoadMenu_DoWork);
            this.backgroundWorkerLoadMenu.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoadMenu_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.gunaControlBoxMaximumOrMiximum);
            this.panel1.Controls.Add(this.gunaControlBoxClose);
            this.panel1.Controls.Add(this.gunaControlBoxHide);
            this.panel1.Controls.Add(this.lblPrivilegeList);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 40);
            this.panel1.TabIndex = 62;
            // 
            // gunaControlBoxMaximumOrMiximum
            // 
            this.gunaControlBoxMaximumOrMiximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBoxMaximumOrMiximum.Animated = true;
            this.gunaControlBoxMaximumOrMiximum.AnimationHoverSpeed = 0.07F;
            this.gunaControlBoxMaximumOrMiximum.AnimationSpeed = 0.03F;
            this.gunaControlBoxMaximumOrMiximum.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MaximizeBox;
            this.gunaControlBoxMaximumOrMiximum.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(85)))), ((int)(((byte)(244)))));
            this.gunaControlBoxMaximumOrMiximum.IconSize = 12F;
            this.gunaControlBoxMaximumOrMiximum.Location = new System.Drawing.Point(890, 7);
            this.gunaControlBoxMaximumOrMiximum.MaximumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxMaximumOrMiximum.MinimumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxMaximumOrMiximum.Name = "gunaControlBoxMaximumOrMiximum";
            this.gunaControlBoxMaximumOrMiximum.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaControlBoxMaximumOrMiximum.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBoxMaximumOrMiximum.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBoxMaximumOrMiximum.Size = new System.Drawing.Size(20, 20);
            this.gunaControlBoxMaximumOrMiximum.TabIndex = 8;
            // 
            // gunaControlBoxClose
            // 
            this.gunaControlBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBoxClose.Animated = true;
            this.gunaControlBoxClose.AnimationHoverSpeed = 0.07F;
            this.gunaControlBoxClose.AnimationSpeed = 0.03F;
            this.gunaControlBoxClose.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(85)))), ((int)(((byte)(244)))));
            this.gunaControlBoxClose.IconSize = 12F;
            this.gunaControlBoxClose.Location = new System.Drawing.Point(915, 7);
            this.gunaControlBoxClose.MaximumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxClose.MinimumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxClose.Name = "gunaControlBoxClose";
            this.gunaControlBoxClose.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaControlBoxClose.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBoxClose.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBoxClose.Size = new System.Drawing.Size(20, 20);
            this.gunaControlBoxClose.TabIndex = 6;
            // 
            // gunaControlBoxHide
            // 
            this.gunaControlBoxHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBoxHide.Animated = true;
            this.gunaControlBoxHide.AnimationHoverSpeed = 0.07F;
            this.gunaControlBoxHide.AnimationSpeed = 0.03F;
            this.gunaControlBoxHide.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBoxHide.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(85)))), ((int)(((byte)(244)))));
            this.gunaControlBoxHide.IconSize = 12F;
            this.gunaControlBoxHide.Location = new System.Drawing.Point(862, 7);
            this.gunaControlBoxHide.MaximumSize = new System.Drawing.Size(20, 20);
            this.gunaControlBoxHide.Name = "gunaControlBoxHide";
            this.gunaControlBoxHide.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaControlBoxHide.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBoxHide.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBoxHide.Size = new System.Drawing.Size(20, 20);
            this.gunaControlBoxHide.TabIndex = 7;
            // 
            // frmPrivilege
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(941, 648);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanelPermission);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrivilege";
            this.Text = "Privilege User";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrivilege_FormClosed);
            this.Load += new System.EventHandler(this.frmPrivilege_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaLabel lblPrivilegeList;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPermission;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoadMenu;
        private System.Windows.Forms.Panel panel1;
        public Guna.UI.WinForms.GunaControlBox gunaControlBoxMaximumOrMiximum;
        public Guna.UI.WinForms.GunaControlBox gunaControlBoxClose;
        public Guna.UI.WinForms.GunaControlBox gunaControlBoxHide;
    }
}