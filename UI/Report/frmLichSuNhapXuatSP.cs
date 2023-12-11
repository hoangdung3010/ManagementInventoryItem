using DevExpress.XtraEditors.Repository;
using MT.Data.BO;
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
    public partial class frmLichSuNhapXuatSP : FormUI.FormUIBase
    {
        TypeAssistant assistant;

        private PagingList _pagingList = null;
        #region"Constructor"
        public frmLichSuNhapXuatSP()
        {
            InitializeComponent();
            InitGrid();

            _pagingList = new PagingList(this.grdMaster)
            {
                BaseRepository = DBContext.GetRep<SoKhoRepository>()
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
            var grd = this.grdMaster.GetMGridControl();
            grd.ViewName = "View_SoKho";
            grd.Sort = "dNgayPhieu DESC";
            grd.CustomModelFields = "sPhieu_Id";
            this.grdMaster.KeyName = "Id";
            grd.IsShowFilter = true;
            grd.FirstView.OptionsView.RowAutoHeight = true;
            var col=this.grdMaster.AddColumnText("sMaVach", "Mã vạch", "Mã vạch", 120, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            this.grdMaster.AddColumnText("sDM_SanPham_Ma", "Mã sản phẩm", "Mã sản phẩm", 120, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left);
            this.grdMaster.AddColumnText("sDM_SanPham_Id_Ten", "Tên sản phẩm", "Tên sản phẩm", 250);
            this.grdMaster.AddColumnText("sDM_DonViTinh_Id_Ten", "Đơn vị tính", 80);
            col=this.grdMaster.AddColumnText("iLoaiPhieu", "Loại phiếu", 150);
            col.EnumName = "iLoaiPhieu";
            col=this.grdMaster.AddColumnText("sMa", "Số phiếu", 100,dataType:DataTypeColumn.HyperLinkEdit);
            this.grdMaster.AddColumnText("dNgayPhieu", "Ngày phiếu", 80);
            col=this.grdMaster.AddColumnText("sDM_DonVi_Id_Xuat_Ten", "Đơn vị xuất", 180);
            col.ColumnEdit = new RepositoryItemMemoEdit()
            {
                WordWrap = true,
                AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True
            };
            col=this.grdMaster.AddColumnText("sDM_DonVi_Id_Nhap_Ten", "Đơn vị nhập", 180);
            col.ColumnEdit = new RepositoryItemMemoEdit()
            {
                WordWrap = true,
                AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True
            };
            this.grdMaster.AddColumnText("sGhiChu2", "Chi tiết", 360);
            this.grdMaster.AddColumnText("sGhiChu", "Ghi chú", 360);
            grd.FirstView.RowCellClick += FirstView_RowCellClick;
        }

        /// <summary>
        /// Bắt event nhấn vào số phiếu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "sMa")
            {
                SoKho soKho = this.grdMaster.GetMGridControl().GetRecordByRowSelected<SoKho>();
                string entityName = string.Empty;
                string title = string.Empty;
                switch (soKho.iLoaiPhieu)
                {
                    case (int)MT.Data.iLoaiPhieu.NhapMoi:
                        entityName = "Phieu_NhapSanPhamMoi";
                        title = "Phiếu nhập mới sản phẩm";
                        break;
                    case (int)MT.Data.iLoaiPhieu.NhapSP:
                        entityName = "Phieu_NhapSanPham";
                        title = "Phiếu nhập sản phẩm";
                        break;
                    case (int)MT.Data.iLoaiPhieu.XuatSP:

                        entityName = "Phieu_XuatSanPham";
                        title = "Phiếu xuất sản phẩm";
                        break;
                    case (int)MT.Data.iLoaiPhieu.XuatMuon:
                    case (int)MT.Data.iLoaiPhieu.XuatTra:
                        entityName = "Phieu_XuatMuonTra";
                        title = "Phiếu xuất cho mượn/trả";
                        break;
                    case (int)MT.Data.iLoaiPhieu.XuatSCĐi:
                    case (int)MT.Data.iLoaiPhieu.XuatSCTraVeSauSC:
                        entityName = "Phieu_XuatSuaChuaSanPham";
                        title = "Phiếu xuất đi sửa chữa";
                        break;
                    case (int)MT.Data.iLoaiPhieu.XuatĐiCĐ:
                    case (int)MT.Data.iLoaiPhieu.XuatTraSauCĐ:
                        entityName = "Phieu_XuatCaiDatSanPham";
                        title = "Phiếu xuất cài đặt";
                        break;
                    case (int)MT.Data.iLoaiPhieu.NhapMuon:
                    case (int)MT.Data.iLoaiPhieu.NhapNhanVe:
                        entityName = "Phieu_NhapMuonTra";
                        title = "Phiếu nhập mượn/trả";
                        break;
                    case (int)MT.Data.iLoaiPhieu.NhapNhanVeSauCĐ:
                    case (int)MT.Data.iLoaiPhieu.NhapVaoCĐ:
                        entityName = "Phieu_NhapCaiDatSanPham";
                        title = "Phiếu nhập cài đặt";
                        break;
                    case (int)MT.Data.iLoaiPhieu.NhapVaoSC:
                    case (int)MT.Data.iLoaiPhieu.NhapSCNhanVeSauSC:
                        entityName = "Phieu_NhapSuaChuaSanPham";
                        title = "Phiếu nhập sửa chữa";
                        break;
                    case (int)MT.Data.iLoaiPhieu.NhapBH:
                    case (int)MT.Data.iLoaiPhieu.NhapNhanVeSauBH:
                        entityName = "Phieu_NhapBaoHanhSanPham";
                        title = "Phiếu nhập bảo hành";
                        break;

                    case (int)MT.Data.iLoaiPhieu.XuatTraSauBH:
                    case (int)MT.Data.iLoaiPhieu.XuatBH:
                        entityName = "Phieu_XuatBaoHanhSanPham";
                        title = "Phiếu xuất bảo hành";
                        break;

                    case (int)MT.Data.iLoaiPhieu.NhapThuHoi:
                        entityName = "Phieu_NhapTHTH";
                        title = "Phiếu nhập thu hồi/tiêu hủy";
                        break;
                    case (int)MT.Data.iLoaiPhieu.XuatThuHoi:
                    case (int)MT.Data.iLoaiPhieu.XuatHuy:
                        entityName = "Phieu_XuatTHTH";
                        title = "Phiếu xuất thu hồi/tiêu hủy";
                        break;

                }
                if (string.IsNullOrWhiteSpace(entityName))
                {
                    return;
                }

                ConfigFormDetail configFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRepByTableName(entityName),
                    FormName = $"frm{entityName}Detail",
                    EntityName = entityName,
                    Title = title
                };
                Type type = Type.GetType($"FormUI.{configFormDetail.FormName},FormUI");
                var frmDetail = (FormUI.FormUIBase)Activator.CreateInstance(type);
                frmDetail.FormAction = (int)MTControl.FormAction.View;
                frmDetail.EntityName = configFormDetail.EntityName;
                frmDetail.ConfigFormDetail = configFormDetail;
                frmDetail.FormId = soKho.sPhieu_Id;
                frmDetail.ShowDialog();
                frmDetail.Dispose();
            }
        }

        /// <summary>
        /// Tìm vết của hàng hóa
        /// </summary>
        private void FindData(string sMaVach)
        {
            if (MT.Library.Utility.CheckForSQLInjection(sMaVach))
            {
                MMessage.ShowError($"Mã vạch <{sMaVach}> không được chưa các ký tự đặc biệt");
                return;
            }
            if (!string.IsNullOrWhiteSpace(sMaVach))
            {
                _pagingList.SetWhere($"sMaVach='{sMaVach}'");
            }
            else
            {
                _pagingList.SetWhere("");
            }
            _pagingList.LoadData();

        }
        #endregion

        #region"Event"
        /// <summary>
        /// Nhầm tìm kiếm lọc theo mã vạch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindData(txtsMaVach.Text);
        }

        private void txtsMaVach_EditValueChanged(object sender, EventArgs e)
        {
            assistant = new TypeAssistant(1000);
            assistant.Idled += assistant_Idled;
            assistant.TextChanged();
        }

        private void assistant_Idled(object sender, EventArgs e)
        {
            this.Invoke(
             new MethodInvoker(() =>
             {
                 FindData(txtsMaVach.Text);
             }));
        }

        private void frmLichSuNhapXuatSP_Load(object sender, EventArgs e)
        {
            //FindData(txtsMaVach.Text);
        }

        private void txtsMaVach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindData(txtsMaVach.Text);
            }
        }
        #endregion


    }
}
