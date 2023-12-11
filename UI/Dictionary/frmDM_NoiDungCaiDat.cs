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
    public partial class frmDM_NoiDungCaiDat : FormUI.MFormList
    {
        #region"Property"
        #endregion

        #region"Contructor"
        public frmDM_NoiDungCaiDat()
        {
            InitializeComponent();

            InitGrid();

            ConfigFormDetail = new ConfigFormDetail
            {
                Rep = DBContext.GetRep<DM_NoiDungCaiDatRepository>(),
                FormName = "frmDM_NoiDungCaiDatDetail",
                Grid= gridNDCD,
                MToolbarList=mToolbarList1,
                EntityName= "DM_NoiDungCaiDat",
                Title = "Cài đặt"
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
           var grd= this.gridNDCD.GetMGridControl();
            grd.TableName = "DM_NoiDungCaiDat";
            grd.ViewName = "";
            grd.SetMutiSelectRows(true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect);
            this.gridNDCD.KeyName = "Id";
            this.gridNDCD.AddColumnText("sTenNoiDungCaiDat", "Tên ND cài đặt", 200);
            this.gridNDCD.AddColumnText("sGhiChu", "Ghi chú", 200);
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
