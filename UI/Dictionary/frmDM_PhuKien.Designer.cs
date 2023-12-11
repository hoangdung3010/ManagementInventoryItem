namespace FormUI
{
    partial class frmDM_PhuKien
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
            this.mToolbarList1 = new MTControl.MToolbarList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridPK = new MTControl.MGridPaging();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.mToolbarList1.ButtonNames = null;
            this.mToolbarList1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mToolbarList1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mToolbarList1.Location = new System.Drawing.Point(0, 0);
            this.mToolbarList1.Margin = new System.Windows.Forms.Padding(0);
            this.mToolbarList1.MyEventHandler = null;
            this.mToolbarList1.Name = "mToolbarList1";
            this.mToolbarList1.Size = new System.Drawing.Size(800, 26);
            this.mToolbarList1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 494);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridPK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 494);
            this.panel2.TabIndex = 0;
            // 
            // gridPK
            // 
            this.gridPK.AllowDrop = true;
            this.gridPK.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridPK.Appearance.Options.UseFont = true;
            this.gridPK.Appearance.Options.UseTextOptions = true;
            this.gridPK.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridPK.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridPK.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridPK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridPK.KeyName = null;
            this.gridPK.Location = new System.Drawing.Point(0, 0);
            this.gridPK.Margin = new System.Windows.Forms.Padding(1);
            this.gridPK.Name = "gridPK";
            this.gridPK.Size = new System.Drawing.Size(800, 494);
            this.gridPK.TabIndex = 0;
            // 
            // frmDM_PhuKien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mToolbarList1);
            this.Name = "frmDM_PhuKien";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.Text = "frmDM_DonVi";
            this.Load += new System.EventHandler(this.frmDM_DonVi_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MTControl.MToolbarList mToolbarList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private MTControl.MGridPaging gridPK;
    }
}