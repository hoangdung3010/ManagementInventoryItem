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
    public partial class frmDM_CanBo : FormUI.MFormList
    {
        #region"Property"
        #endregion

        #region"Contructor"
        public frmDM_CanBo()
        {
            InitializeComponent();

            InitGrid();

            ConfigFormDetail = new ConfigFormDetail
            {
                Rep = DBContext.GetRep<DM_CanBoRepository>(),
                FormName = "frmDM_CanBoDetail",
                Grid = gridCB,
                MToolbarList = mToolbarList1,
                EntityName = "DM_CanBo",
                Title = "Cán bộ"
            };
            mToolbarList1.ButtonNames = new MButtonName[]
            {
                new MButtonName{CommandName=MCommandName.AddNew},
                new MButtonName{CommandName=MCommandName.Duplicate},
                new MButtonName{CommandName=MCommandName.View},
                new MButtonName{CommandName=MCommandName.Edit},
                new MButtonName{CommandName=MCommandName.Delete,BeginGroup=true},
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
            var grd = this.gridCB.GetMGridControl();
            grd.TableName = "DM_CanBo";
            grd.ViewName = "View_DM_CanBo";
            grd.SetMutiSelectRows(true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect);
            grd.IsShowFilter = true;
            this.gridCB.KeyName = "Id";
            this.gridCB.AddColumnText("sMaCanBo", "Mã cán bộ", 100, isFixWidth: true);
            this.gridCB.AddColumnText("sTenCanBo", "Họ và tên", 200);
            this.gridCB.AddColumnText("sEmail", "Email", 200);
            this.gridCB.AddColumnText("sDienThoai", "Điện thoại", 100);
            this.gridCB.AddColumnText("sDM_ChucVu_Id_Ten", "Chức vụ", 200);
            this.gridCB.AddColumnText("sDM_DonVi_Id_Ten", "Thuộc đơn vị", 200);
            this.gridCB.AddColumnText("sGhiChu", "Ghi chú", 200);
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
