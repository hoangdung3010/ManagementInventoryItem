using MT.Data;
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
    public partial class frmDM_ChungThuSo : FormUI.MFormList
    {
        #region"Property"
        #endregion

        #region"Contructor"
        public frmDM_ChungThuSo()
        {
            InitializeComponent();

            InitGrid();

            ConfigFormDetail = new ConfigFormDetail
            {
                Rep = DBContext.GetRep<DM_ChungThuSoRepository>(),
                FormName = "frmDM_ChungThuSoDetail",
                Grid= gridCTS,
                MToolbarList=mToolbarList1,
                EntityName= "DM_ChungThuSo",
                Title = "Chứng thư số"
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
           var grd= this.gridCTS.GetMGridControl();
            grd.TableName = "DM_ChungThuSo";
            grd.ViewName = "View_DM_ChungThuSo";
            grd.Sort = "sMaCTS";
            grd.SetMutiSelectRows(true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect);
            this.gridCTS.KeyName = "Id";
            this.gridCTS.AddColumnText("sMaCTS", "Mã CTS","Mã chứng thư số", 120);
            this.gridCTS.AddColumnText("sHoSo", "Hồ sơ", 180);
            this.gridCTS.AddColumnText("sMaVach", "Mã vạch", 100);
            this.gridCTS.AddColumnText("sSerialNumber", "Serial number", 100);
            this.gridCTS.AddColumnText("sPassword", "Mật khẩu", 100);
            this.gridCTS.AddColumnText("sMasterCode", "MasterCode", 150);
            this.gridCTS.AddColumnText("sChuNhan", "Chủ nhân", 200);
            this.gridCTS.AddColumnText("sEmail", "Email", 100);
            this.gridCTS.AddColumnText("sTenToChucCap1", "Tổ chức cấp 1", 200);
            this.gridCTS.AddColumnText("sTenToChucCap2", "Tổ chức cấp 2", 200);
            this.gridCTS.AddColumnText("sTenToChucCap3", "Tổ chức cấp 3", 200);
            this.gridCTS.AddColumnText("sTenToChucCap4", "Tổ chức cấp 4", 200);
            this.gridCTS.AddColumnText("sDiaChi", "Địa chỉ", 200);
            this.gridCTS.AddColumnText("sTenNguoi", "Người thực hiện", 200);
            this.gridCTS.AddColumnText("dNgayBatDau", "Ngày thực hiện", 80);
            this.gridCTS.AddColumnText("dNgayKetThuc", "Ngày kết thúc", 80);
            this.gridCTS.AddColumnText("sGhiChu", "Ghi chú", 250);
        }
        #endregion

        #region"Overrides"
        /// <summary>
        /// Ẩn hiện các nút trên Toolbar
        /// </summary>
        /// <param name="mToolbar"></param>
        /// <param name="mBindingSource"></param>
        protected override void CustomSetEnableButtonOnToolbar(MToolbarList mToolbar, MBindingSource mBindingSource)
        {
            base.CustomSetEnableButtonOnToolbar(mToolbar, mBindingSource);
            SetEnableButtonOnToolbar(MCommandName.Import, true);
        }
        protected override void ProcessItemClick(int tag, object sender)
        {
            base.ProcessItemClick(tag, sender);
            switch (tag)
            {
                case (int)MTControl.MCommandName.Import:
                    using (frmImportData frmImportData = new frmImportData())
                    {
                        frmImportData.ImportDataType = ImportDataType.DM_ChungThuSo;
                        frmImportData.ShowDialog();
                    }
                    break;
            }
        }
        #endregion

        #region"Event"
        private void frmDM_ChungThuSo_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        #endregion


    }
}
