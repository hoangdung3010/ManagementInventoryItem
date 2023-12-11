using MTControl;
namespace FormUI
{
    partial class MFormHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFormHelp));
            this.rTBContent = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rTBContent
            // 
            this.rTBContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTBContent.Location = new System.Drawing.Point(0, 0);
            this.rTBContent.Name = "rTBContent";
            this.rTBContent.Size = new System.Drawing.Size(639, 467);
            this.rTBContent.TabIndex = 0;
            this.rTBContent.Text = "";
            // 
            // MFormHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 467);
            this.Controls.Add(this.rTBContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MFormHelp";
            this.Text = "Trợ giúp";
            this.Load += new System.EventHandler(this.MFormHelp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rTBContent;

    }
}