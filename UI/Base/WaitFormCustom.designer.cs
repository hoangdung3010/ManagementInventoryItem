namespace FormUI
{
    partial class WaitFormCustom
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
            this.mPictureEdit1 = new MTControl.MPictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.mPictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mPictureEdit1
            // 
            this.mPictureEdit1.EditValue = global::FormUI.Properties.Resources.loading;
            this.mPictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.mPictureEdit1.Name = "mPictureEdit1";
            this.mPictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.mPictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.mPictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.mPictureEdit1.Size = new System.Drawing.Size(79, 69);
            this.mPictureEdit1.TabIndex = 1;
            // 
            // WaitFormCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(79, 67);
            this.Controls.Add(this.mPictureEdit1);
            this.Name = "WaitFormCustom";
            this.ShowOnTopMode = DevExpress.XtraWaitForm.ShowFormOnTopMode.AboveParent;
            this.Text = "Đang tải";
            ((System.ComponentModel.ISupportInitialize)(this.mPictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MTControl.MPictureEdit mPictureEdit1;
    }
}