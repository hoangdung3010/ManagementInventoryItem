namespace MTControl
{
    partial class MPagingGridControl
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
            this.mLayoutControl1 = new MTControl.MLayoutControl();
            this.lblPage = new MTControl.MLabel();
            this.btnLastPage = new MTControl.MSimpleButton();
            this.btnNext = new MTControl.MSimpleButton();
            this.btnPrevious = new MTControl.MSimpleButton();
            this.btnFirst = new MTControl.MSimpleButton();
            this.cboComboPageSize = new MTControl.MComboBox();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.mLayoutControl1)).BeginInit();
            this.mLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // mLayoutControl1
            // 
            this.mLayoutControl1.AutoScroll = false;
            this.mLayoutControl1.Controls.Add(this.lblPage);
            this.mLayoutControl1.Controls.Add(this.btnLastPage);
            this.mLayoutControl1.Controls.Add(this.btnNext);
            this.mLayoutControl1.Controls.Add(this.btnPrevious);
            this.mLayoutControl1.Controls.Add(this.btnFirst);
            this.mLayoutControl1.Controls.Add(this.cboComboPageSize);
            this.mLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.mLayoutControl1.Name = "mLayoutControl1";
            this.mLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(621, 90, 250, 350);
            this.mLayoutControl1.Root = this.layoutControlGroup1;
            this.mLayoutControl1.Size = new System.Drawing.Size(707, 30);
            this.mLayoutControl1.TabIndex = 0;
            this.mLayoutControl1.Text = "mLayoutControl1";
            // 
            // lblPage
            // 
            this.lblPage.Appearance.BackColor = System.Drawing.Color.White;
            this.lblPage.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPage.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPage.Description = null;
            this.lblPage.Location = new System.Drawing.Point(2, 2);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(445, 26);
            this.lblPage.StyleController = this.mLayoutControl1;
            this.lblPage.TabIndex = 10;
            // 
            // btnLastPage
            // 
            this.btnLastPage.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnLastPage.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLastPage.Appearance.Options.UseFont = true;
            this.btnLastPage.Appearance.Options.UseForeColor = true;
            this.btnLastPage.Description = null;
            this.btnLastPage.Image = global::MTControl.Properties.Resources.page_last;
            this.btnLastPage.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnLastPage.Location = new System.Drawing.Point(679, 2);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(26, 26);
            this.btnLastPage.StyleController = this.mLayoutControl1;
            this.btnLastPage.TabIndex = 9;
            this.btnLastPage.Tag = "Last";
            this.btnLastPage.ToolTip = "Trang cuối";
            // 
            // btnNext
            // 
            this.btnNext.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnNext.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNext.Appearance.Options.UseFont = true;
            this.btnNext.Appearance.Options.UseForeColor = true;
            this.btnNext.Description = null;
            this.btnNext.Image = global::MTControl.Properties.Resources.page_next;
            this.btnNext.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnNext.Location = new System.Drawing.Point(649, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(26, 26);
            this.btnNext.StyleController = this.mLayoutControl1;
            this.btnNext.TabIndex = 8;
            this.btnNext.Tag = "Next";
            this.btnNext.ToolTip = "Trang sau";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnPrevious.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrevious.Appearance.Options.UseFont = true;
            this.btnPrevious.Appearance.Options.UseForeColor = true;
            this.btnPrevious.Description = null;
            this.btnPrevious.Image = global::MTControl.Properties.Resources.page_prev;
            this.btnPrevious.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPrevious.Location = new System.Drawing.Point(619, 2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(26, 26);
            this.btnPrevious.StyleController = this.mLayoutControl1;
            this.btnPrevious.TabIndex = 6;
            this.btnPrevious.Tag = "Previous";
            this.btnPrevious.ToolTip = "Trang trước";
            // 
            // btnFirst
            // 
            this.btnFirst.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnFirst.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnFirst.Appearance.Options.UseFont = true;
            this.btnFirst.Appearance.Options.UseForeColor = true;
            this.btnFirst.Description = null;
            this.btnFirst.Image = global::MTControl.Properties.Resources.page_first;
            this.btnFirst.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnFirst.Location = new System.Drawing.Point(589, 2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(26, 26);
            this.btnFirst.StyleController = this.mLayoutControl1;
            this.btnFirst.TabIndex = 5;
            this.btnFirst.Tag = "First";
            this.btnFirst.ToolTip = "Trang đầu";
            // 
            // cboComboPageSize
            // 
            this.cboComboPageSize.SetField = null;
            this.cboComboPageSize.Description = null;
            this.cboComboPageSize.EntityName = false;
            this.cboComboPageSize.EnumData = null;
            this.cboComboPageSize.IsAutoLoad = false;
            this.cboComboPageSize.IsSetValueManual = false;
            this.cboComboPageSize.LastAcceptedSelectedIndex = -1;
            this.cboComboPageSize.Location = new System.Drawing.Point(515, 2);
            this.cboComboPageSize.Name = "cboComboPageSize";
            this.cboComboPageSize.Size = new System.Drawing.Size(70, 26);
            this.cboComboPageSize.StyleController = this.mLayoutControl1;
            this.cboComboPageSize.TabIndex = 4;
            this.cboComboPageSize.SelectedIndexChanged += new System.EventHandler(this.cboComboPageSize_SelectedIndexChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceItemCaption.BackColor = System.Drawing.Color.White;
            this.layoutControlGroup1.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.layoutControlGroup1.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(707, 30);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cboComboPageSize;
            this.layoutControlItem1.Location = new System.Drawing.Point(449, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(138, 30);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(138, 30);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(138, 30);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Số bản ghi";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(61, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnFirst;
            this.layoutControlItem2.Location = new System.Drawing.Point(587, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(30, 30);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(30, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(30, 30);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnPrevious;
            this.layoutControlItem3.Location = new System.Drawing.Point(617, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(30, 30);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(30, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(30, 30);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnNext;
            this.layoutControlItem5.Location = new System.Drawing.Point(647, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(30, 30);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(30, 30);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(30, 30);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnLastPage;
            this.layoutControlItem6.Location = new System.Drawing.Point(677, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(30, 30);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(30, 30);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(30, 30);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lblPage;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(4, 20);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(449, 30);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // MPagingGridControl
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mLayoutControl1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MPagingGridControl";
            this.Size = new System.Drawing.Size(707, 30);
            ((System.ComponentModel.ISupportInitialize)(this.mLayoutControl1)).EndInit();
            this.mLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MLayoutControl mLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private MSimpleButton btnFirst;
        private MComboBox cboComboPageSize;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private MSimpleButton btnPrevious;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private MSimpleButton btnNext;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private MSimpleButton btnLastPage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private MLabel lblPage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
