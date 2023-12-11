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
    public partial class frmDM_MangLienLac : FormUI.MFormList
    {
        #region"Property"
        #endregion

        #region"Contructor"
        public frmDM_MangLienLac()
        {
            InitializeComponent();

            InitGrid();

            ConfigFormDetail = new ConfigFormDetail
            {
                Rep = DBContext.GetRep<DM_MangLienLacRepository>(),
                FormName = "frmDM_MangLienLacDetail",
                Grid= gridMLL,
                MToolbarList=mToolbarList1,
                EntityName= "DM_MangLienLac",
                Title = "Mạng liên lạc"
            };

           mToolbarList1.ButtonNames = new MButtonName[]
           {
                new MButtonName{CommandName=MCommandName.AddNew},
                new MButtonName{CommandName=MCommandName.Duplicate},
                new MButtonName{CommandName=MCommandName.View},
                new MButtonName{CommandName=MCommandName.Edit},
                new MButtonName{CommandName=MCommandName.Delete},
                new MButtonName{CommandName=MCommandName.Import,BeginGroup=true},
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
           var grd= this.gridMLL.GetMGridControl();
            grd.TableName = "DM_MangLienLac";
            grd.ViewName = "View_DM_MangLienLac";
            grd.SetMutiSelectRows(true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect);
            this.gridMLL.KeyName = "Id";
            this.gridMLL.AddColumnText("sMaMangLienLac", "Mã mạng liên lạc", 100,isFixWidth:true);
            this.gridMLL.AddColumnText("sTenMangLienLac", "Tên mạng liên lạc", 200);
            this.gridMLL.AddColumnText("sDM_ThamSoMatMa_Id_Ten", "Tham số mật mã", 200);
            this.gridMLL.AddColumnText("sGhiChu", "Ghi chú", 200);
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
