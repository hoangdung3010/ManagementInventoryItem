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
    public partial class frmDM_ChucVu : FormUI.MFormList
    {
        #region"Property"
        #endregion

        #region"Contructor"
        public frmDM_ChucVu()
        {
            InitializeComponent();

            InitGrid();

            ConfigFormDetail = new ConfigFormDetail
            {
                Rep = DBContext.GetRep<DM_ChucVuRepository>(),
                FormName = "frmDM_ChucVuDetail",
                Grid= gridMaster,
                MToolbarList=mToolbarList1,
                EntityName= "DM_ChucVu",
                Title="Chức vụ"
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
           var grd= this.gridMaster.GetMGridControl();
            grd.CustomModelFields = "IsSystem";
            grd.TableName = "DM_ChucVu";
            grd.Sort = "SortOrder";
            grd.SetMutiSelectRows(true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect);
            this.gridMaster.KeyName = "Id";
            this.gridMaster.AddColumnText("sTenChucVu", "Tên chức vụ", 200);
            var col=  this.gridMaster.AddColumnText("sGhiChu", "Ghi chú",-1);
            col.BestFit();
        }
        #endregion

        #region"Overrides"
        #endregion

        #region"Event"
        private void frmDM_DonVi_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        #endregion


    }
}
