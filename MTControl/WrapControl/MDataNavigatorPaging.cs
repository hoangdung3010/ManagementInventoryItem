using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTControl.WrapControl
{
    public partial class MDataNavigatorPaging : UserControl
    {
        public MDataNavigatorPaging()
        {
            InitializeComponent();

            this.cboComboPageSize.Properties.Items.AddRange(new string[] { "10","20", "50", "100", "150", "200" });
            this.cboComboPageSize.EditValue = 100;
            this.cboComboPageSize.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            lblTotal.ForeColor = Color.Black;
            lblPageSize.ForeColor = Color.Black;
            lblTotal.Text = "Tổng số: 0 bản ghi";
        }

        #region"Sub/Func"
        public DataNavigator GetDataNavigator()
        {
            return dataNavigator1;
        }

        public MComboBox GetComboPageSize()
        {
            return cboComboPageSize;
        }

        /// <summary>
        /// Lấy về số bản ghi hiển thị trên 1 trang
        /// </summary>
        /// <returns></returns>
        public int GetPageSize()
        {
            int pageSize = -1;
            string strValue = Convert.ToString(cboComboPageSize.EditValue);
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
        public void SetDisplayPageInfo(int totalCount)
        {
            lblTotal.Text = string.Format("Tổng= {0} bản ghi.", totalCount);
        }

        #endregion
       
    }
}
