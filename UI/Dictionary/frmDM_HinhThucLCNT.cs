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
    public partial class frmDM_HinhThucLCNT : FormUI.MFormList
    {
        #region"Property"
        #endregion

        #region"Contructor"
        public frmDM_HinhThucLCNT()
        {
            InitializeComponent();

            InitGrid();

            ConfigFormDetail = new ConfigFormDetail
            {
                Rep = DBContext.GetRep<DM_HinhThucLCNTRepository>(),
                FormName = "frmDM_HinhThucLCNTDetail",
                Grid= gridMaster,
                MToolbarList=mToolbarList1,
                EntityName= "DM_HinhThucLCNT",
                Title="Hình thức chỉ định nhà thầu"
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
           var grd= this.gridMaster.GetMGridControl();
            
            grd.TableName = "DM_HinhThucLCNT";
            grd.SetMutiSelectRows(true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect);
            this.gridMaster.KeyName = "Id";
            this.gridMaster.AddColumnText("sTenHinhThucLCNT", "Tên hình thức LCNT", "Tên hình thức lập chỉ định nhà thầu", 200);
            var col=  this.gridMaster.AddColumnText("sGhiChu", "Ghi chú",200);
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
