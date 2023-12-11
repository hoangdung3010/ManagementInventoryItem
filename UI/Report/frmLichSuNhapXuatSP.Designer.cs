
namespace FormUI
{
    partial class frmLichSuNhapXuatSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLichSuNhapXuatSP));
            this.panel2 = new System.Windows.Forms.Panel();
            this.grdMaster = new MTControl.MGridPaging();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new MTControl.MSimpleButton();
            this.txtsMaVach = new MTControl.MTextEdit();
            this.mLabel1 = new MTControl.MLabel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.grdMaster);
            this.panel2.Location = new System.Drawing.Point(5, 45);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 614);
            this.panel2.TabIndex = 1;
            // 
            // grdMaster
            // 
            this.grdMaster.AllowDrop = true;
            this.grdMaster.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdMaster.Appearance.Options.UseFont = true;
            this.grdMaster.Appearance.Options.UseTextOptions = true;
            this.grdMaster.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdMaster.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdMaster.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grdMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMaster.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdMaster.KeyName = null;
            this.grdMaster.Location = new System.Drawing.Point(0, 0);
            this.grdMaster.Margin = new System.Windows.Forms.Padding(1);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.Size = new System.Drawing.Size(1020, 614);
            this.grdMaster.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtsMaVach);
            this.panel1.Controls.Add(this.mLabel1);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 39);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSearch.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Appearance.Options.UseForeColor = true;
            this.btnSearch.ColumnName = "";
            this.btnSearch.Description = null;
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.Location = new System.Drawing.Point(410, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 24);
            this.btnSearch.TabIndex = 34;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtsMaVach
            // 
            this.txtsMaVach.AutoIncrement = false;
            this.txtsMaVach.Description = null;
            this.txtsMaVach.Grid = null;
            this.txtsMaVach.IsCustomHeight = false;
            this.txtsMaVach.IsReadOnly = false;
            this.txtsMaVach.IsSetValueManual = false;
            this.txtsMaVach.Location = new System.Drawing.Point(57, 10);
            this.txtsMaVach.MaxLength = 0;
            this.txtsMaVach.Name = "txtsMaVach";
            this.txtsMaVach.RepositoryItem = null;
            this.txtsMaVach.SetField = null;
            this.txtsMaVach.Size = new System.Drawing.Size(347, 22);
            this.txtsMaVach.TabIndex = 1;
            this.txtsMaVach.EditValueChanged += new System.EventHandler(this.txtsMaVach_EditValueChanged);
            this.txtsMaVach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsMaVach_KeyDown);
            // 
            // mLabel1
            // 
            this.mLabel1.AllowHtmlString = true;
            this.mLabel1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel1.Appearance.Options.UseFont = true;
            this.mLabel1.Appearance.Options.UseForeColor = true;
            this.mLabel1.Appearance.Options.UseTextOptions = true;
            this.mLabel1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mLabel1.ColumnName = "";
            this.mLabel1.Description = null;
            this.mLabel1.IsRequired = false;
            this.mLabel1.Location = new System.Drawing.Point(9, 13);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(41, 13);
            this.mLabel1.TabIndex = 0;
            this.mLabel1.Text = "Mã vạch";
            // 
            // frmLichSuNhapXuatSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1025, 662);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLichSuNhapXuatSP";
            this.Text = "frmLichSuNhapXuatSP";
            this.Load += new System.EventHandler(this.frmLichSuNhapXuatSP_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MTControl.MLabel mLabel1;
        private MTControl.MTextEdit txtsMaVach;
        private MTControl.MSimpleButton btnSearch;
        private System.Windows.Forms.Panel panel2;
        private MTControl.MGridPaging grdMaster;
    }
}