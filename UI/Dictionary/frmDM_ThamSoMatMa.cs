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
    public partial class frmDM_ThamSoMatMa : FormUI.MFormList
    {
        #region"Property"
        #endregion

        #region"Contructor"
        public frmDM_ThamSoMatMa()
        {
            InitializeComponent();

            InitGrid();

            ConfigFormDetail = new ConfigFormDetail
            {
                Rep = DBContext.GetRep<DM_ThamSoMatMaRepository>(),
                FormName = "frmDM_ThamSoMatMaDetail",
                Grid = gridTSMM,
                MToolbarList = mToolbarList1,
                EntityName = "DM_ThamSoMatMa",
                Title = "Tham số mật mã"
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
            var grd = this.gridTSMM.GetMGridControl();
            grd.TableName = "DM_ThamSoMatMa";
            grd.ViewName = "View_DM_ThamSoMatMa";
            grd.SetMutiSelectRows(true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect);
            this.gridTSMM.KeyName = "Id";
            var col=this.gridTSMM.AddColumnText("sMaThamSoMatMa", "Mã TSMM","Mã tham số mật mã", 100, isFixWidth: true);
            this.gridTSMM.AddColumnText("sTenThamSoMatMa", "Tên TSMM","Tên tham số mật mã", 200);
            this.gridTSMM.AddColumnText("iThoiHanSuDung", "Thời hạn SD","Thời hạn sử dụng", 100);
            col=this.gridTSMM.AddColumnText("iDonViThoiGianHieuLuc", "Đơn vị t.gian", 80);
            col.EnumName = "iDonViThoiGianHieuLuc";
            this.gridTSMM.AddColumnText("dNgayHieuLuc", "Ngày hiệu lực", 100);
            this.gridTSMM.AddColumnText("dNgayHetHan", "Ngày hết hạn", 100);
            this.gridTSMM.AddColumnText("sGhiChu", "Ghi chú", 250);
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
                        frmImportData.ImportDataType = ImportDataType.DM_ThamSoMatMa;
                        frmImportData.ShowDialog();
                    }
                    break;
            }
        }
        #endregion

        #region"Event"
        private void frmDM_DonVi_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        #endregion


    }
}
