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
    public partial class frmDM_PhuKien : FormUI.MFormList
    {
        #region"Property"
        #endregion

        #region"Contructor"
        public frmDM_PhuKien()
        {
            InitializeComponent();

            InitGrid();

            ConfigFormDetail = new ConfigFormDetail
            {
                Rep = DBContext.GetRep<DM_PhuKienRepository>(),
                FormName = "frmDM_PhuKienDetail",
                Grid= gridPK,
                MToolbarList=mToolbarList1,
                EntityName= "DM_PhuKien",
                Title = "Phụ kiện"
            };
            mToolbarList1.ButtonNames = new MButtonName[]
             {
                new MButtonName{CommandName=MCommandName.AddNew},
                new MButtonName{CommandName=MCommandName.Duplicate},
                new MButtonName{CommandName=MCommandName.View},
                new MButtonName{CommandName=MCommandName.Edit},
                new MButtonName{CommandName=MCommandName.Delete},
                new MButtonName{CommandName=MCommandName.Excel,BeginGroup=true},
                new MButtonName{CommandName=MCommandName.Refresh,BeginGroup=true},
                new MButtonName{CommandName=MCommandName.Help,BeginGroup=true}
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
           var grd= this.gridPK.GetMGridControl();
            grd.TableName = "DM_PhuKien";
            grd.ViewName = "View_DM_PhuKien";
            grd.SetMutiSelectRows(true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect);
            this.gridPK.KeyName = "Id";
            this.gridPK.AddColumnText("sDM_SanPham_Id_Ten", "Sản phẩm", 200,isFixWidth: true);
            this.gridPK.AddColumnText("rSoLuong", "Số lượng", 100);
            this.gridPK.AddColumnText("sMaPhuKien", "Mã phụ kiện", 100);
            this.gridPK.AddColumnText("sTenPhuKien", "Tên phụ kiện", 200);
            this.gridPK.AddColumnText("sDM_DonViTinh_Id_Ten", "Đơn vị tính", 100);
            this.gridPK.AddColumnText("rDonGia", "Đơn giá", 200);
            this.gridPK.AddColumnText("sXuatXu", "Xuất sứ",150);
            this.gridPK.AddColumnText("sGhiChu", "Ghi chú", 200);
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
