using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using MT.Data;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Library;
using MTControl;
using System;
using System.Collections;
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
    public partial class frmKH_CaiDatSanPhamDetail : FormUI.MFormBusinessDetail
    {
        DM_DonViRepository dM_DonViRepository;
        public frmKH_CaiDatSanPhamDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<KH_CaiDatSanPhamRepository>(),
                    EntityName = "KH_CaiDatSanPham",
                    Title = "Kế hoạch cài đặt sản phẩm"
                };
            }

            GrdDetails = new Dictionary<string, MTControl.MGridEditable>
            {
                {"KH_CaiDatSanPham_CT",grdSanPham }
            };
            this.ControlTepDinhKem = ucTepDinhKem1;
            InitRep();
            InitLookup();
            InitGrid();
        }

        #region"Sub/Func"
        /// <summary>
        /// Khởi tạo đối tượng kết nối db
        /// </summary>
        private void InitRep()
        {
            dM_DonViRepository = (DM_DonViRepository)DBContext.GetRep<MT.Data.Rep.DM_DonViRepository>();
        }
        /// <summary>
        /// Khởi tạo giá trị combo
        /// </summary>
        private void InitLookup()
        {
            treesDM_DonVi_Id_DonViXayDungKH.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_DonViXayDungKH.Properties.ValueMember = "Id";
            var treeList = treesDM_DonVi_Id_DonViXayDungKH.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            treesDM_DonVi_Id_DonViXayDungKH.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_DonViXayDungKH.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);

            var donviXayDungKH = dM_DonViRepository.GetDonViConCap1VaDonViCungCap(MT.Library.SessionData.OrganizationUnitId);

            treesDM_DonVi_Id_DonViXayDungKH.Properties.DataSource = donviXayDungKH;


            // Đơn vị xuất
            cbosDM_DonVi_Id_DonViXuat.Properties.DisplayMember = "sTenDonvi";
            cbosDM_DonVi_Id_DonViXuat.Properties.ValueMember = "Id";
            var treeListDonViXuat = cbosDM_DonVi_Id_DonViXuat.Properties.TreeList;
            treeListDonViXuat.KeyFieldName = "Id";
            treeListDonViXuat.ParentFieldName = "sParentId";
            cbosDM_DonVi_Id_DonViXuat.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            cbosDM_DonVi_Id_DonViXuat.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            cbosDM_DonVi_Id_DonViXuat.Properties.DataSource = donviXayDungKH;
            cbosDM_DonVi_Id_DonViXuat.AliasFormQuickAdd = "DM_DonVi";

            // Đơn vị nhập
            cbosDM_DonVi_Id_DonViNhap.Properties.DisplayMember = "sTenDonvi";
            cbosDM_DonVi_Id_DonViNhap.Properties.ValueMember = "Id";
            var treeListDonViNhap = cbosDM_DonVi_Id_DonViXuat.Properties.TreeList;
            treeListDonViNhap.KeyFieldName = "Id";
            treeListDonViNhap.ParentFieldName = "sParentId";
            cbosDM_DonVi_Id_DonViNhap.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            cbosDM_DonVi_Id_DonViNhap.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            cbosDM_DonVi_Id_DonViNhap.Properties.DataSource = donviXayDungKH;
            cbosDM_DonVi_Id_DonViNhap.AliasFormQuickAdd = "DM_DonVi";



            var dsCanBo = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                                 columns: "Id,sMaCanBo,sTenCanBo", orderBy: "sMaCanBo");

            // Người lập KH
            cbosDM_CanBo_Id_NguoiLapKH.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiLapKH.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiLapKH.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiLapKH.Properties.DataSource = dsCanBo;

            // Người duyệt
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_NguoiDuyet.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_NguoiDuyet.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = dsCanBo;
            cbosDM_CanBo_Id_NguoiDuyet.AliasFormQuickAdd = "DM_CanBo";

            // Thủ trưởng đơn vị
            cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DisplayMember = "sTenCanBo";
            cbosDM_CanBo_Id_ThuTruongDonVi.Properties.ValueMember = "Id";
            cbosDM_CanBo_Id_ThuTruongDonVi.AddColumn("sTenCanBo", "Tên", 180, true);
            cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DataSource = dsCanBo;
            cbosDM_CanBo_Id_ThuTruongDonVi.AliasFormQuickAdd = "DM_CanBo";

            cboEnumiDonViThoiGianHieuLuc.EnumData = "iDonViThoiGianHieuLuc";

        }


        /// <summary>
        /// Khởi tạo thông tin grid
        /// </summary>
        private void InitGrid()
        {
            var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham), "Id,sMaSanPham,sTenSanPham,sDM_NhomSanPham_Id_Ten", orderBy: "sDM_NhomSanPham_Id_Ten,sMaSanPham", viewName: "View_DM_SanPham");

            var dm_DonViTinhs = DBContext.GetRep<MT.Data.Rep.DM_DonViTinhRepository>().GetData(typeof(MT.Data.BO.DM_DonViTinh), "Id,sTenDonViTinh", orderBy: "SortOrder");
            //Sản phẩm
            grdSanPham.GrdDetail.TableName = "KH_CaiDatSanPham_CT";
            grdSanPham.GrdDetail.KeyName = "Id";
            grdSanPham.GrdDetail.SetField = "khCaiDatSanPham_CTs";
            grdSanPham.GrdDetail.FirstView.OptionsNavigation.EnterMoveNextColumn = true;
            grdSanPham.GrdDetail.ValidEditValueChanging = grdSanPham_ValidEditValueChanging;
            grdSanPham.IsRequired = true;
            grdSanPham.InvalidText = "Danh sách sản phẩm không được bỏ trống";

            var col = grdSanPham.GrdDetail.AddColumnText("sDM_SanPham_Id", "Tên sản phẩm", 250, isFixWidth: true,
               fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left,
               dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_SanPham_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_SanPham_Id.DictionaryName = "DM_SanPham";
            colsDM_SanPham_Id.AddColumn("sMaSanPham", "Mã sản phẩm", 120);
            colsDM_SanPham_Id.AddColumn("sTenSanPham", "Tên sản phẩm", 180);
            colsDM_SanPham_Id.AddColumn("sDM_NhomSanPham_Id_Ten", "Nhóm sản phẩm", 180);
            colsDM_SanPham_Id.DataSource = dm_SanPhams;
            colsDM_SanPham_Id.DisplayMember = "sTenSanPham";
            colsDM_SanPham_Id.ValueMember = "Id";
            colsDM_SanPham_Id.BestFitMode = BestFitMode.BestFitResizePopup;

            col = grdSanPham.GrdDetail.AddColumnText("sDM_DonViTinh_Id", "Đơn vị tính", 150, dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_DonViTinh_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_DonViTinh_Id.DictionaryName = "DM_DonViTinh";
            colsDM_DonViTinh_Id.AddColumn("sTenDonViTinh", "Tên đơn vị tính", 180);
            colsDM_DonViTinh_Id.DataSource = dm_DonViTinhs;
            colsDM_DonViTinh_Id.DisplayMember = "sTenDonViTinh";
            colsDM_DonViTinh_Id.ValueMember = "Id";


            //// Nội dung cài đặt
            col = grdSanPham.GrdDetail.AddColumnText("sDM_NoiDungCaiDat_Id", "Nội dung CĐ", toolTip: "Nội dung cài đặt", 150,
               dataType: MTControl.DataTypeColumn.LookUpEdit, isRequired: true);

            MRepositoryItemLookUpEdit colsDM_NoiDungCaiDat_Id = (MRepositoryItemLookUpEdit)col.ColumnEdit;
            colsDM_NoiDungCaiDat_Id.DictionaryName = "DM_NoiDungCaiDat";
            colsDM_NoiDungCaiDat_Id.AddColumn("sTenNoiDungCaiDat", "Nội dung cài đặt", 180);
            colsDM_NoiDungCaiDat_Id.DataSource = DBContext.GetRep<MT.Data.Rep.DM_NoiDungCaiDatRepository>()
                .GetData(typeof(MT.Data.BO.DM_NoiDungCaiDat), "Id,sTenNoiDungCaiDat", orderBy: "SortOrder"); ;
            colsDM_NoiDungCaiDat_Id.DisplayMember = "sTenNoiDungCaiDat";
            colsDM_NoiDungCaiDat_Id.ValueMember = "Id";


            grdSanPham.GrdDetail.AddColumnText("rSoLuong", "Số lượng", 150, dataType: MTControl.DataTypeColumn.SpinEdit);
            grdSanPham.GrdDetail.AddColumnText("sGhiChu", "Ghi chú", 250, maxLength: 255);


            col = grdSanPham.GrdDetail.AddColumnText("Id", "Hành động", 100, dataType: MTControl.DataTypeColumn.Button,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Right);

            MRepositoryItemButtonEdit colsAction = (MRepositoryItemButtonEdit)col.ColumnEdit;
            colsAction.TextEditStyle = TextEditStyles.HideTextEditor;
            colsAction.Buttons.Clear();
            var editorButton = new EditorButton(ButtonPredefines.Glyph, "Phụ kiện", 80, true, true, false, null);
            editorButton.Appearance.ForeColor = Color.White;
            editorButton.AppearanceHovered.ForeColor = Color.Black;
            editorButton.AppearancePressed.ForeColor = Color.Black;
            colsAction.Buttons.Add(editorButton);
            colsAction.ButtonClick += ColsActionPhuKien_ButtonClick;
        }

        /// <summary>
        /// Validate giá trị trước khi gán cho grid
        /// </summary>
        /// <param name="gridColumn"></param>
        /// <param name="e"></param>
        /// <returns>=true cho gán,ngược lại ko cho gán</returns>
        private bool grdSanPham_ValidEditValueChanging(DevExpress.XtraGrid.Columns.GridColumn gridColumn, ChangingEventArgs e)
        {
            if (gridColumn.FieldName != "sDM_SanPham_Id")
            {
                object sDM_SanPhamId = grdSanPham.GrdDetail.FirstView.GetRowCellValue(grdSanPham.GrdDetail.FirstView.FocusedRowHandle, "sDM_SanPham_Id");
                if (sDM_SanPhamId == null || Guid.Empty.ToString().Equals(sDM_SanPhamId.ToString()))
                {
                    MMessage.ShowWarning("Bạn phải chọn thông tin sản phẩm trước.");
                    return false;
                }
            }

            return true;
        }
        #endregion
        #region"Event"
        /// <summary>
        /// Click hiển thị form nhập chi tiết phụ kiện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColsActionPhuKien_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //Bắt bắt chọn sản phẩm roh thì mới cho nhập phụ kiện
            var KH_CaiDatSanPham_CT = grdSanPham.GrdDetail.GetRecordByRowSelected<KH_CaiDatSanPham_CT>();
            if (KH_CaiDatSanPham_CT.sDM_SanPham_Id.HasValue && !KH_CaiDatSanPham_CT.sDM_SanPham_Id.Value.Equals(Guid.Empty))
            {

                frmPhuKienDetail frmPhuKienDetail = new frmPhuKienDetail(KH_CaiDatSanPham_CT.sDM_SanPham_Id.Value,
                    "KH_CaiDatSanPham_CT_PhuKien", "khCaiDatSanPham_CT_PhuKiens", KH_CaiDatSanPham_CT, this);
                frmPhuKienDetail.ShowDialog();
            }
            else
            {
                MMessage.ShowWarning("Bạn phải chọn sản phẩm trước khi nhập thông tin chi tiết phụ kiện");
            }
        }

        #endregion

        #region"Overrides"

        /// <summary>
        /// Thực hiện validate chi tiết sản phẩm trước khi lưu
        /// </summary>
        /// <param name="mGridEditable"></param>
        /// <param name="dataChanged">Danh sách dữ liệu thay đổi</param>
        /// <returns></returns>
        protected override bool IsValidateDataChangedGridDetail(MGridEditable mGridEditable, System.Collections.IList dataChanged)
        {
            var valid = base.IsValidateDataChangedGridDetail(mGridEditable, dataChanged);

            if (valid && dataChanged != null)
            {
                List<KH_CaiDatSanPham_CT> datas = mGridEditable.GrdDetail.GetAllData<KH_CaiDatSanPham_CT>();
                foreach (var item in dataChanged)
                {
                    var castItem = (KH_CaiDatSanPham_CT)item;
                    // Truong 2022
                    KH_CaiDatSanPham_CT findBysID = datas.Find(m => m.sDM_SanPham_Id.Equals(castItem.sDM_SanPham_Id) && m.Id != castItem.Id);
                    if (findBysID != null)
                    {
                        MMessage.ShowWarning($"Sản phẩm <{castItem.sDM_SanPham_Id_Ten}> đang bị lặp nhiều lần, cần gộp chung lại!");
                        valid = false;
                        break;
                    }
                    // end Truong2022
                    if (castItem.MTEntityState == Enummation.MTEntityState.Delete)
                    {
                        continue;
                    }

                    if (datas.Find(m => m.sDM_SanPham_Id.Value.Equals(castItem.sDM_SanPham_Id)
                      && m.Id != castItem.Id) != null)
                    {
                        valid = false;
                        DM_SanPham dM_SanPham = DBContext.GetRep2<KH_CaiDatSanPhamRepository>().GetDataByID<DM_SanPham>("DM_SanPham", castItem.sDM_SanPham_Id, "sMaSanPham,sTenSanPham");
                        DM_DonViTinh dM_DonViTinh = DBContext.GetRep2<KH_CaiDatSanPhamRepository>().GetDataByID<DM_DonViTinh>("DM_DonViTinh", castItem.sDM_DonViTinh_Id, "sTenDonViTinh");
                        string msg = $@"Bạn không được phép nhập trùng thông tin sản phẩm <{dM_SanPham.sMaSanPham} - {dM_SanPham.sTenSanPham}> với đơn vị tính là <{dM_DonViTinh.sTenDonViTinh}>";
                        MMessage.ShowWarning(msg);
                        break;
                    }
                }
            }

            return valid;
        }

        /// <summary>
        /// Custom lại cell của grid
        /// </summary>
        /// <param name="mGridControl"></param>
        /// <param name="e"></param>
        protected override void CustomRowCellGridDetail(MGridControl mGridControl, RepositoryItem repository, CustomRowCellEditEventArgs e)
        {
            base.CustomRowCellGridDetail(mGridControl, repository, e);
            switch (mGridControl.TableName)
            {
                case "KH_CaiDatSanPham_CT":
                    if (e.Column.FieldName == "sDM_SanPham_Id")
                    {
                        // Truong 2022
                        MRepositoryItemLookUpEdit repositoryItemLookUpEdit = (MRepositoryItemLookUpEdit)repository;
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(cbosDM_DonVi_Id_DonViXuat.GetValue())))
                        {
                            Guid sDM_Donvi_Id = Guid.Parse(Convert.ToString(cbosDM_DonVi_Id_DonViXuat.GetValue()));// this.CurrentData.GetValue("sDM_DonVi_Id_DonViXuat");
                            List<MT.Data.BO.DM_SanPham> dm_SanPhams = (List<DM_SanPham>)GhiSoKho.GetSanPhamTonTrongKho((Guid)sDM_Donvi_Id);
                            if (dm_SanPhams == null || dm_SanPhams.Count <= 0)
                            {
                                MMessage.ShowWarning($"Không còn sản phẩm nào trong kho");
                                repositoryItemLookUpEdit.DataSource = null;
                            }
                            else
                            {
                                repositoryItemLookUpEdit.DataSource = dm_SanPhams;
                            }
                        }
                        else
                        {
                            MMessage.ShowWarning($"Bạn phải chọn Đơn vị xuất trước");
                        }
                    }

                    break;
            }
        }

        /// <summary>
        /// Thực hiện bắt event tính tổng tiền trên grid chi tiết  TT=rDonGia*SL
        /// </summary>
        /// <param name="mGridControl"></param>
        /// <param name="e"></param>
        protected override void CustomRowCellValueChangedGridDetail(MGridControl mGridControl, CellValueChangedEventArgs e)
        {
            base.CustomRowCellValueChangedGridDetail(mGridControl, e);

            switch (mGridControl.TableName)
            {
                case "KH_CaiDatSanPham_CT":
                    var khCaiDatSanPham_CT = mGridControl.GetRecordByRowSelected<KH_CaiDatSanPham_CT>();
                    if (e.Column.FieldName == "sDM_SanPham_Id")
                    {
                        // Truong2022
                        List<MT.Data.BO.KH_CaiDatSanPham_CT> kH_CaiDatSanPham_CTs = grdSanPham.GrdDetail.GetAllData<MT.Data.BO.KH_CaiDatSanPham_CT>();
                        KH_CaiDatSanPham_CT findBysID = kH_CaiDatSanPham_CTs.Find(m => m.sDM_SanPham_Id.Equals(khCaiDatSanPham_CT.sDM_SanPham_Id) && m.Id != khCaiDatSanPham_CT.Id);
                        if (findBysID != null)
                        {
                            MMessage.ShowWarning($"Sản phẩm <{findBysID.sDM_SanPham_Id_Ten}> đã tồn tại");
                        }
                        // end Truong2022
                        //gán mặc định đơn vị tính cấp 1 cho sản phẩm
                        DM_SanPhamRepository dM_SanPhamRepository = DBContext.GetRep2<DM_SanPhamRepository>();
                        DM_SanPham dM_SanPham = null;
                        if (e.Value != null)
                        {
                            dM_SanPham = dM_SanPhamRepository.GetDataByID<DM_SanPham>("DM_SanPham", e.Value, "sDM_DonViTinh_Id_Cap1,rDonGia_Cap1");
                        }
                        if (dM_SanPham != null)
                        {
                            khCaiDatSanPham_CT.sDM_DonViTinh_Id = dM_SanPham.sDM_DonViTinh_Id_Cap1;
                            khCaiDatSanPham_CT.rSoLuong = 1;
                            khCaiDatSanPham_CT.rDonGia = dM_SanPham.rDonGia_Cap1;
                            khCaiDatSanPham_CT.rThanhTien = dM_SanPham.rDonGia_Cap1;
                            //Gán mặc định phụ kiện theo sản phẩm
                            if (!khCaiDatSanPham_CT.IsLoaded && khCaiDatSanPham_CT.MTEntityState == Enummation.MTEntityState.Add)
                            {

                                var phukiensCuaSanPham = (List<DM_PhuKien>)DBContext.GetRep2<DM_PhuKienRepository>()
                                                                .GetData(typeof(DM_PhuKien), "Id,sDM_SanPham_Id,sDM_DonViTinh_Id,rSoLuong,rDonGia"
                                                                , where: $"sDM_SanPham_Id='{khCaiDatSanPham_CT.sDM_SanPham_Id.Value}'"
                                                                , orderBy: "SortOrder");
                                List<KH_CaiDatSanPham_CT_PhuKien> phukienCuaKeHoachNhapMoi = new List<KH_CaiDatSanPham_CT_PhuKien>();
                                if (phukiensCuaSanPham != null)
                                {
                                    foreach (var item in phukiensCuaSanPham)
                                    {
                                        phukienCuaKeHoachNhapMoi.Add(new KH_CaiDatSanPham_CT_PhuKien
                                        {
                                            Id = Guid.NewGuid(),
                                            rSoLuongPhuKienTren1SP = item.rSoLuong,
                                            rSoLuong = khCaiDatSanPham_CT.rSoLuong * item.rSoLuong,
                                            MTEntityState = Enummation.MTEntityState.Add,
                                            sDM_DonViTinh_Id = item.sDM_DonViTinh_Id,
                                            sDM_PhuKien_Id = item.Id,
                                            rDonGia = item.rDonGia,
                                            rThanhTien = khCaiDatSanPham_CT.rSoLuong * item.rSoLuong * item.rDonGia,
                                            sDM_SanPham_Id = item.sDM_SanPham_Id
                                        });
                                    }
                                }
                                khCaiDatSanPham_CT.khCaiDatSanPham_CT_PhuKiens = phukienCuaKeHoachNhapMoi;
                                khCaiDatSanPham_CT.IsLoaded = true;
                            }

                        }
                    }

                    if (e.Column.FieldName == "sDM_DonViTinh_Id")
                    {
                        if (e.Value != null)
                        {
                            DM_SanPhamRepository dM_SanPhamRepository = DBContext.GetRep2<DM_SanPhamRepository>();
                            DM_SanPham dM_SanPham = null;
                            //Nếu chọn đơn vị tính cấp 2 thì lấy giá của đơn vị tính cấp 2
                            dM_SanPham = dM_SanPhamRepository.GetDataByID<DM_SanPham>("DM_SanPham",
                                mGridControl.FirstView.GetRowCellValue(e.RowHandle, "sDM_SanPham_Id"),
                                "sDM_DonViTinh_Id_Cap1,sDM_DonViTinh_Id_Cap2,rDonGia_Cap1,rDonGia_Cap2");

                            if (dM_SanPham != null)
                            {
                                if (Guid.Parse(e.Value.ToString()) == dM_SanPham.sDM_DonViTinh_Id_Cap1.Value)
                                {
                                    khCaiDatSanPham_CT.rDonGia = dM_SanPham.rDonGia_Cap1;
                                    khCaiDatSanPham_CT.rThanhTien = dM_SanPham.rDonGia_Cap1 * khCaiDatSanPham_CT.rSoLuong;
                                }
                                else if (dM_SanPham.sDM_DonViTinh_Id_Cap2.HasValue && Guid.Parse(e.Value.ToString()) == dM_SanPham.sDM_DonViTinh_Id_Cap2.Value)
                                {
                                    khCaiDatSanPham_CT.rDonGia = dM_SanPham.rDonGia_Cap2;
                                    khCaiDatSanPham_CT.rThanhTien = dM_SanPham.rDonGia_Cap2 * khCaiDatSanPham_CT.rSoLuong;
                                }
                            }
                        }

                    }

                    if (e.Column.FieldName == "rSoLuong" || e.Column.FieldName == "rDonGia")
                    {

                        khCaiDatSanPham_CT.rThanhTien = khCaiDatSanPham_CT.rSoLuong * khCaiDatSanPham_CT.rDonGia;

                        //Tính lại số lượng phụ kiện theo số lượng sản phẩm
                        if (!khCaiDatSanPham_CT.IsLoaded && khCaiDatSanPham_CT.MTEntityState == Enummation.MTEntityState.Add)
                        {
                            if (khCaiDatSanPham_CT.khCaiDatSanPham_CT_PhuKiens != null)
                            {
                                foreach (var item in khCaiDatSanPham_CT.khCaiDatSanPham_CT_PhuKiens)
                                {
                                    KH_CaiDatSanPham_CT_PhuKien ctPhuKien = ((KH_CaiDatSanPham_CT_PhuKien)item);
                                    ctPhuKien.rSoLuong = khCaiDatSanPham_CT.rSoLuong * ctPhuKien.rSoLuongPhuKienTren1SP;
                                }
                            }
                        }

                    }
                    break;
            }
        }
        /// <summary>
        /// Thực hiện thiết lập mode control theo action
        /// </summary>
        protected override void SetViewModeControlByFromAction()
        {
            base.SetViewModeControlByFromAction();
            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    treesDM_DonVi_Id_DonViXayDungKH.SetReadOnly(false);
                    break;
                default:
                    treesDM_DonVi_Id_DonViXayDungKH.SetReadOnly(true);
                    break;
            }
            cbosDM_CanBo_Id_NguoiLapKH.SetReadOnly(true);
        }

        /// <summary>
        /// Sau khi binding giá trị xong thì xử lý tiếp
        /// </summary>
        protected override void BindingDataIntoFormSucces()
        {
            base.BindingDataIntoFormSucces();

            //Lấy danh sách tham chiếu
            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Edit:
                case (int)MTControl.FormAction.View:
                    ucThamChieu.sObjectId = Guid.Parse(this.CurrentData.GetIdentity().ToString());
                    ucThamChieu.sTenBangCanCu = "KH_CaiDatSanPham";
                    ucThamChieu.LoadData();
                    break;
            }
        }


        /// <summary>
        /// Xử lý dữ liệu trước khi binding lên form
        /// </summary>
        /// <returns></returns>
        protected override BaseEntity PrepareDataBeforeBindDataForm()
        {
            var currentData = (KH_CaiDatSanPham)base.PrepareDataBeforeBindDataForm();
            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Add:
                case (int)MTControl.FormAction.Duplicate:
                    currentData.sDM_DonVi_Id_DonViXayDungKH = MT.Library.SessionData.OrganizationUnitId;
                    currentData.iThoiGianHieuLuc = 60;
                    currentData.iDonViThoiGianHieuLuc = (int)iDonViThoiGianHieuLuc.Ngay;
                    currentData.dNgayKeHoach = SysDateTime.Instance.Now();
                    currentData.sDM_CanBo_Id_NguoiLapKH = MT.Library.SessionData.UserId;
                    currentData.iTrangThaiDuyet = (int)MT.Data.iTrangThaiDuyetPNM.ChoDuyet;
                    break;
            }

            return currentData;
        }
        private void cbosDM_CanBo_Id_NguoiDuyet_QueryPopUp(object sender, CancelEventArgs e)
        {
            cbosDM_CanBo_Id_NguoiDuyet.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                    columns: "Id,sTenCanBo", viewName: "View_DM_CanBo",
                    where: $"sDM_DonVi_Id='{MT.Library.SessionData.OrganizationUnitId}' AND iDictionaryKey IN({(int)MT.Data.iChucVu.TruongPhong},{(int)MT.Data.iChucVu.PhoTruongPhong})", orderBy: "sTen");
        }

        private void cbosDM_CanBo_Id_ThuTruongDonVi_QueryPopUp(object sender, CancelEventArgs e)
        {
            /*cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                    columns: "Id,sMaCanBo,sTenCanBo", where: $"Id= (select Id from DM_CanBo where sDM_DonVi_Id in (select sParentId from DM_DonVi where Id='{MT.Library.SessionData.OrganizationUnitId}'))", orderBy: "sMaCanBo");*/

            string chucVu = $" AND iDictionaryKey IN({ (int)MT.Data.iChucVu.TruongPhong},{ (int)MT.Data.iChucVu.PhoTruongPhong},{ (int)MT.Data.iChucVu.PhoCucTruong},{ (int)MT.Data.iChucVu.CucTruong})";
            cbosDM_CanBo_Id_ThuTruongDonVi.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_CanBoRepository>().GetData(typeof(MT.Data.BO.DM_CanBo),
                    columns: "Id,sMaCanBo,sTenCanBo",
                    where: $"Id in (select Id from View_DM_CanBo where sDM_DonVi_Id in (select sParentId from DM_DonVi where Id='{MT.Library.SessionData.OrganizationUnitId}') {chucVu})", orderBy: "sMaCanBo");
        }
        /// <summary>
        /// Thiết lập các tham số trước khi in
        /// </summary>
        /// <param name="configExcel"></param>
        /// <param name="configReport"></param>
        protected override void SetConfigBeforePrint(ConfigExcel configExcel, ConfigReport configReport)
        {
            base.SetConfigBeforePrint(configExcel, configReport);
            //Đối tượng xử lý nghiệp vụ IN
            configReport.RepName = "Print_KH_CaiDatSanPham_DetailRepository";
            //Định danh mẫu in trong bảng ReportData
            configReport.DictionaryKey = MT.Data.ReportDictionaryKey.RP_Print_KH_CaiDatSanPhamDetail;

            //Danh sách các cột trên table
            configExcel.ShowColumnsOrder = new HashSet<string>
            {
                "sSTT","sDM_SanPham_Id_Ten",
                "sDM_DonViTinh_Id_Ten","rSoLuong",
                "sDM_NoiDungCaiDat_Id_Ten",
                "sXuatXu",
            };

        }

        #endregion


    }
}
