
namespace MTControl.WrapControl
{
    partial class MDataNavigatorPaging
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataNavigator1 = new DevExpress.XtraEditors.DataNavigator();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.cboComboPageSize = new MTControl.MComboBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 45);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 345F));
            this.tableLayoutPanel1.Controls.Add(this.dataNavigator1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(974, 45);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.dataNavigator1.Appearance.Options.UseFont = true;
            this.dataNavigator1.Buttons.Append.Visible = false;
            this.dataNavigator1.Buttons.CancelEdit.Visible = false;
            this.dataNavigator1.Buttons.EndEdit.Visible = false;
            this.dataNavigator1.Buttons.Remove.Visible = false;
            this.dataNavigator1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.dataNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataNavigator1.Location = new System.Drawing.Point(632, 3);
            this.dataNavigator1.Name = "dataNavigator1";
            this.dataNavigator1.Size = new System.Drawing.Size(339, 39);
            this.dataNavigator1.TabIndex = 0;
            this.dataNavigator1.Text = "dataNavigator1";
            this.dataNavigator1.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.cboComboPageSize);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.lblPageSize);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(623, 39);
            this.panel2.TabIndex = 3;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(10, 8);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(147, 22);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Tổng = 0 bản ghi";
            // 
            // lblPageSize
            // 
            this.lblPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageSize.Location = new System.Drawing.Point(445, 7);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(96, 22);
            this.lblPageSize.TabIndex = 1;
            this.lblPageSize.Text = "Số bản ghi";
            this.lblPageSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboComboPageSize
            // 
            this.cboComboPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboComboPageSize.DefaultValueEnum = -1;
            this.cboComboPageSize.Description = null;
            this.cboComboPageSize.EntityName = false;
            this.cboComboPageSize.EnumData = null;
            this.cboComboPageSize.Grid = null;
            this.cboComboPageSize.IsAutoLoad = false;
            this.cboComboPageSize.IsReadOnly = false;
            this.cboComboPageSize.IsSetValueManual = false;
            this.cboComboPageSize.LastAcceptedSelectedIndex = -1;
            this.cboComboPageSize.Location = new System.Drawing.Point(547, 8);
            this.cboComboPageSize.Name = "cboComboPageSize";
            this.cboComboPageSize.RepositoryItem = null;
            this.cboComboPageSize.SetField = null;
            this.cboComboPageSize.Size = new System.Drawing.Size(70, 23);
            this.cboComboPageSize.TabIndex = 5;
            // 
            // MDataNavigatorPaging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel1);
            this.Name = "MDataNavigatorPaging";
            this.Size = new System.Drawing.Size(974, 45);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.DataNavigator dataNavigator1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MComboBox cboComboPageSize;
    }
}
