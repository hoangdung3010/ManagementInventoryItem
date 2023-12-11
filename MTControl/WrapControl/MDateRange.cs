using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MTControl
{
    public class MDateRange : DevExpress.XtraEditors.XtraUserControl
    {
        #region"Declare"
        private MLayoutControl mLayoutControl1;
        private MComboBox cboDate;
        private MDateEdit dteToDate;
        private MDateEdit dteFromDate;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;

        /// <summary>
        /// Danh sách resource combo kỳ báo cáo
        /// </summary>
        private string enumData;

        public string EnumData
        {
            get { return enumData; }
            set { enumData = value; }
        }
        #endregion
        #region"Contructor"
        public MDateRange()
        {
            InitializeComponent();
            this.Load+=MDateRange_Load;
            MCommon.SetSkins();
        }
        #endregion
        #region"Sub/Func"
        /// <summary>
        /// Lấy về combo kỳ báo cáo
        /// </summary>
        /// <returns></returns>
        public MComboBox GetCboDate()
        {
            return this.cboDate;
        }

        /// <summary>
        /// Lấy về control từ ngày
        /// </summary>
        /// <returns></returns>
        public MDateEdit GetDteFromDate()
        {
            return this.dteFromDate;
        }

        /// <summary>
        /// Lấy về control đến ngày
        /// </summary>
        /// <returns></returns>
        public MDateEdit GetDteToDate()
        {
            return this.dteToDate;
        }


        #endregion
        #region"Ovrrides"
       
        /// <summary>
        /// ovrides lại hàm render control
        /// </summary>
        /// dvthang-17.07.2016
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);

        }
        /// <summary>
        /// Thực hiện nhảy Tab khi nhấn Enter
        /// </summary>
        /// <param name="e"></param>
        /// CreatebBy-laipv.19.08.2017
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }
        #endregion
        #region"Implement"

        #endregion
        private void InitializeComponent()
        {
            this.mLayoutControl1 = new MTControl.MLayoutControl();
            this.cboDate = new MTControl.MComboBox();
            this.dteToDate = new MTControl.MDateEdit();
            this.dteFromDate = new MTControl.MDateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.mLayoutControl1)).BeginInit();
            this.mLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // mLayoutControl1
            // 
            this.mLayoutControl1.Controls.Add(this.cboDate);
            this.mLayoutControl1.Controls.Add(this.dteToDate);
            this.mLayoutControl1.Controls.Add(this.dteFromDate);
            this.mLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.mLayoutControl1.Name = "mLayoutControl1";
            this.mLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(561, 175, 250, 350);
            this.mLayoutControl1.Root = this.layoutControlGroup1;
            this.mLayoutControl1.Size = new System.Drawing.Size(660, 40);
            this.mLayoutControl1.TabIndex = 0;
            this.mLayoutControl1.Text = "mLayoutControl1";
            // 
            // cboDate
            // 
            this.cboDate.SetField = null;
            this.cboDate.Description = null;
            this.cboDate.EntityName = false;
            this.cboDate.EnumData = null;
            this.cboDate.IsAutoLoad = false;
            this.cboDate.IsSetValueManual = false;
            this.cboDate.LastAcceptedSelectedIndex = -1;
            this.cboDate.Location = new System.Drawing.Point(80, 6);
            this.cboDate.Name = "cboDate";
            this.cboDate.Size = new System.Drawing.Size(124, 28);
            this.cboDate.StyleController = this.mLayoutControl1;
            this.cboDate.TabIndex = 6;
            this.cboDate.SelectedIndexChanged += new System.EventHandler(this.cboDate_SelectedIndexChanged);
            // 
            // dteToDate
            // 
            this.dteToDate.SetField = null;
            this.dteToDate.Description = null;
            this.dteToDate.EditValue = null;
            this.dteToDate.IsSetValueManual = false;
            this.dteToDate.Location = new System.Drawing.Point(502, 6);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Size = new System.Drawing.Size(152, 28);
            this.dteToDate.StyleController = this.mLayoutControl1;
            this.dteToDate.TabIndex = 5;
            this.dteToDate.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.dteToDate_EditValueChanging);
            // 
            // dteFromDate
            // 
            this.dteFromDate.SetField = null;
            this.dteFromDate.Description = null;
            this.dteFromDate.EditValue = null;
            this.dteFromDate.IsSetValueManual = false;
            this.dteFromDate.Location = new System.Drawing.Point(282, 6);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Size = new System.Drawing.Size(142, 28);
            this.dteFromDate.StyleController = this.mLayoutControl1;
            this.dteFromDate.TabIndex = 4;
            this.dteFromDate.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.dteFromDate_EditValueChanging);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.layoutControlGroup1.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup1.Size = new System.Drawing.Size(660, 40);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dteFromDate;
            this.layoutControlItem1.Location = new System.Drawing.Point(202, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(220, 32);
            this.layoutControlItem1.Text = "Từ ngày";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(71, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dteToDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(422, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(230, 32);
            this.layoutControlItem2.Text = "Đến ngày";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(71, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cboDate;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(202, 32);
            this.layoutControlItem3.Text = "Kỳ báo cáo";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(71, 16);
            // 
            // MDateRange
            // 
            this.AllowDrop = true;
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.Controls.Add(this.mLayoutControl1);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "MDateRange";
            this.Size = new System.Drawing.Size(660, 40);
            ((System.ComponentModel.ISupportInitialize)(this.mLayoutControl1)).EndInit();
            this.mLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #region"Event"
        /// <summary>
        /// Xử lý khi form được load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MDateRange_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.EnumData))
            {
                //Load lên danh sách kỳ báo cáo
                this.cboDate.EnumData = this.enumData;
            }
        }

        /// <summary>
        /// Xử lý event khi thay đổi kỳ báo cáo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cboDate.SelectedIndex;
            if (index > -1)
            {
                int period = cboDate.GetSelectedIndex(index);
                MCommon.SetDateRangeByPeriod(period, dteFromDate, dteToDate);
            }
        }

        /// <summary>
        /// Bắt event sửa giá trị control từ ngày
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dteFromDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
            }
        }

        /// <summary>
        /// Bắt event xử lý giá trị control đến ngày
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dteToDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
            }
        }
        #endregion
    }
}
