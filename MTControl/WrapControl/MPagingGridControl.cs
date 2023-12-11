using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MTControl
{
    public partial class MPagingGridControl : MXtraUserControl
    {
        #region"Declare"
        public EventHandler EventHandlerPaging { get; set; }

        public EventHandler EventHandlerShowRecord { get; set; }
        #endregion
        #region"Contructor"
        public MPagingGridControl()
        {
            InitializeComponent();
            this.Load += new EventHandler(MPagingGridControl_Load);
            this.btnFirst.Click+=new EventHandler(btnPaging_Click);
            this.btnPrevious.Click += new EventHandler(btnPaging_Click);
            this.btnNext.Click += new EventHandler(btnPaging_Click);
            this.btnLastPage.Click += new EventHandler(btnPaging_Click);

            this.cboComboPageSize.Properties.Items.AddRange(new string[5] {"Tất cả", "50", "100", "150","200" });
            this.cboComboPageSize.EditValue = 100;
            this.cboComboPageSize.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        #endregion
        #region"Sub/Func"
        /// <summary>
        /// Lấy về số bản ghi hiển thị trên 1 trang
        /// </summary>
        /// <returns></returns>
        public int GetPageSize()
        {
            int pageSize = -1;
            string strValue=Convert.ToString(cboComboPageSize.EditValue);
            if (!int.TryParse(strValue, out pageSize))
            {
                pageSize = -1;
            }
            return pageSize;
        }

        /// <summary>
        /// Lấy về số bản ghi hiển thị trên 1 trang
        /// </summary>
        /// <returns></returns>
        public void SetPageSize(int pageSize)
        {
            if (pageSize == -1)
            {
                cboComboPageSize.SelectedIndex = 0;
            }
            else
            {
                cboComboPageSize.EditValue = pageSize.ToString();
            }
            
        }

        /// <summary>
        /// Thiết lập trang đang xem trên grid
        /// </summary>
        public void SetDisplayPageInfo(int currentPage,int totalPage,int totalCount)
        {
            if (totalPage > 0)
            {
                lblPage.Text = string.Format("Tổng= {0} bản ghi. Trang {1}/{2}", totalCount, currentPage == 0 ? 1 : currentPage, totalPage == 0 ? 1 : totalPage);
            }
            else
            {
                lblPage.Text = string.Format("Tổng= {0} bản ghi.", totalCount);
            }
        }
        #endregion
        #region"Event"
        /// <summary>
        /// Sự kiện khi form được load lên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MPagingGridControl_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Sử lý event cho các button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPaging_Click(object sender, EventArgs e)
        {
            if (this.EventHandlerPaging != null)
            {
                this.EventHandlerPaging(sender,e);
            }
        }
        #endregion

        /// <summary>
        /// Chọn số bản ghi hiển thị trên 1 trang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboComboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.EventHandlerShowRecord != null)
            {
                this.EventHandlerShowRecord(sender, e);
            }
        }
    }
}
