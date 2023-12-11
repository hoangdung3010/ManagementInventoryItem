using MT.Data.Rep;
using MTControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class frmDM_Kho : FormUI.MFormList
    {
        #region"Property"
        #endregion

        #region"Contructor"
        public frmDM_Kho()
        {
            InitializeComponent();

            InitGrid();

            ConfigFormDetail = new ConfigFormDetail
            {
                Rep = DBContext.GetRep<DM_KhoRepository>(),
                FormName = "frmDM_KhoDetail",
                Grid= gridKho,
                MToolbarList=mToolbarList1,
                EntityName= "DM_Kho"
            };
        }
        #endregion

        #region"Sub/Func"
        /// <summary>
        /// Khởi tạo các cột trên grid
        /// </summary>
        /// Create by: dvthang:07.03.2017
        private void InitGrid()
        {
           var grd= this.gridKho.GetMGridControl();
            grd.TableName = "DM_Kho";
            grd.ViewName = "View_DM_Kho";
            this.gridKho.KeyName = "Id";
            this.gridKho.AddColumnText("sTenKho", "Tên kho", 200);
            this.gridKho.AddColumnText("sDM_Donvi_Id_Ten", "Thuộc đơn vị", 180);
            this.gridKho.AddColumnText("sGhiChu", "Ghi chú", 200);
        }
        #endregion

        #region"Overrides"
     
        #endregion

        #region"Event"
        private void frmDM_Kho_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        #endregion


    }
}
