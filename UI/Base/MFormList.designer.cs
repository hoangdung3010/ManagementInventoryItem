namespace FormUI
{
    partial class MFormList
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

            try
            {
                
                if (frmDetail != null)
                {
                    frmDetail.Dispose();
                }

                if (BgWorkerDetails != null)
                {
                    foreach (var item in BgWorkerDetails)
                    {
                        item.Value.Dispose();
                    }
                }
            }
            catch
            {
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFormList));
            this.SuspendLayout();
            // 
            // MFormList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 443);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MFormList";
            this.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.Text = "MFormList";
            this.Load += new System.EventHandler(this.MFormList_Load);
            this.ResumeLayout(false);

        }

        #endregion

    }
}