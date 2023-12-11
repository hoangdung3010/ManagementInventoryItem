namespace FormUI
{
    partial class ucDateRange
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
            this.lblFrom = new Guna.UI.WinForms.GunaLabel();
            this.lblTo = new Guna.UI.WinForms.GunaLabel();
            this.cboPeriod = new MTControl.MLookUpEdit();
            this.dteFrom = new MTControl.MDateEdit();
            this.dteTo = new MTControl.MDateEdit();
            this.SuspendLayout();
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFrom.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblFrom.Location = new System.Drawing.Point(110, 7);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(20, 15);
            this.lblFrom.TabIndex = 31;
            this.lblFrom.Text = "Từ";
            // 
            // lblTo
            // 
            this.lblTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTo.Location = new System.Drawing.Point(242, 7);
            this.lblTo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(28, 15);
            this.lblTo.TabIndex = 32;
            this.lblTo.Text = "Đến";
            // 
            // cboPeriod
            // 
            this.cboPeriod.AddFields = null;
            this.cboPeriod.AliasFormQuickAdd = null;
            this.cboPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cboPeriod.ColumnsExtend = null;
            this.cboPeriod.Description = null;
            this.cboPeriod.DictionaryName = null;
            this.cboPeriod.EntityName = null;
            this.cboPeriod.Grid = null;
            this.cboPeriod.IsAutoLoad = false;
            this.cboPeriod.IsReadOnly = false;
            this.cboPeriod.IsSetValueManual = false;
            this.cboPeriod.KeyStore = null;
            this.cboPeriod.Location = new System.Drawing.Point(4, 5);
            this.cboPeriod.MapColumnName = null;
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.PrimaryKey = null;
            this.cboPeriod.QuickSearchName = null;
            this.cboPeriod.RepositoryItem = null;
            this.cboPeriod.SetField = null;
            this.cboPeriod.Size = new System.Drawing.Size(100, 23);
            this.cboPeriod.Sort = null;
            this.cboPeriod.TabIndex = 35;
            this.cboPeriod.ValueDefault = null;
            this.cboPeriod.EditValueChanged += new System.EventHandler(this.cboPeriod_EditValueChanged);
            // 
            // dteFrom
            // 
            this.dteFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dteFrom.Description = null;
            this.dteFrom.EditValue = null;
            this.dteFrom.Grid = null;
            this.dteFrom.IsReadOnly = false;
            this.dteFrom.IsSetValueManual = false;
            this.dteFrom.Location = new System.Drawing.Point(136, 5);
            this.dteFrom.Name = "dteFrom";
            this.dteFrom.RepositoryItem = null;
            this.dteFrom.SetField = null;
            this.dteFrom.Size = new System.Drawing.Size(100, 22);
            this.dteFrom.TabIndex = 34;
            this.dteFrom.EditValueChanged += new System.EventHandler(this.dteFrom_EditValueChanged);
            // 
            // dteTo
            // 
            this.dteTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dteTo.Description = null;
            this.dteTo.EditValue = null;
            this.dteTo.Grid = null;
            this.dteTo.IsReadOnly = false;
            this.dteTo.IsSetValueManual = false;
            this.dteTo.Location = new System.Drawing.Point(276, 5);
            this.dteTo.Name = "dteTo";
            this.dteTo.RepositoryItem = null;
            this.dteTo.SetField = null;
            this.dteTo.Size = new System.Drawing.Size(100, 22);
            this.dteTo.TabIndex = 33;
            this.dteTo.EditValueChanged += new System.EventHandler(this.dteTo_EditValueChanged);
            // 
            // ucDateRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.cboPeriod);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dteFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.dteTo);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(400, 32);
            this.MinimumSize = new System.Drawing.Size(200, 26);
            this.Name = "ucDateRange";
            this.Size = new System.Drawing.Size(383, 32);
            this.Load += new System.EventHandler(this.ucDateRange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MTControl.MLookUpEdit cboPeriod;
        private Guna.UI.WinForms.GunaLabel lblFrom;
        private MTControl.MDateEdit dteFrom;
        private Guna.UI.WinForms.GunaLabel lblTo;
        private MTControl.MDateEdit dteTo;
    }
}
