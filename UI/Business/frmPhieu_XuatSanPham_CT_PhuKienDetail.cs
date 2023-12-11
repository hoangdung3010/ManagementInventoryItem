using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using MT.Data;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Library;
using MT.Library.Extensions;
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
    public partial class frmPhieu_XuatSanPham_CT_PhuKienDetail : FormUI.FormUIBase
    {
        private Phieu_XuatSanPham_CT _Phieu_XuatSanPham_CT;

        private Dictionary<string, IEditControl> dicControls;

        public Dictionary<string, IEditControl> DicControls
        {
            get { return dicControls; }
            set { dicControls = value; }
        }

        public frmPhieu_XuatSanPham_CT_PhuKienDetail(Phieu_XuatSanPham_CT phieu_XuatSanPham_CT)
        {
            InitializeComponent();
            _Phieu_XuatSanPham_CT = phieu_XuatSanPham_CT;
            InitLookup();
            InitGrid();
        }

        #region"Sub/Func"

        /// <summary>
        /// Khởi tạo giá trị combo
        /// </summary>
        private void InitLookup()
        {
            treesDM_DonVi_Id_DonViNhap.Properties.DisplayMember = "sTenDonvi";
            treesDM_DonVi_Id_DonViNhap.Properties.ValueMember = "Id";
            var treeList = treesDM_DonVi_Id_DonViNhap.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            treesDM_DonVi_Id_DonViNhap.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            treesDM_DonVi_Id_DonViNhap.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            treesDM_DonVi_Id_DonViNhap.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_DonViRepository>().GetData(typeof(MT.Data.BO.DM_DonVi));
            treesDM_DonVi_Id_DonViNhap.AliasFormQuickAdd = "DM_DonVi";

            colsDM_Kho_Id.DictionaryName = "DM_Kho";
            colsDM_Kho_Id.AddColumn("sTenKho", "Tên kho", 180);
            colsDM_Kho_Id.Properties.DisplayMember = "sTenKho";
            colsDM_Kho_Id.Properties.ValueMember = "Id";
            colsDM_Kho_Id.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_KhoRepository>().GetData(typeof(MT.Data.BO.DM_Kho), "Id,sTenKho", orderBy: "SortOrder");
            colsDM_Kho_Id.AliasFormQuickAdd = "DM_Kho";

            var dm_SanPhams = DBContext.GetRep<MT.Data.Rep.DM_SanPhamRepository>().GetData(typeof(MT.Data.BO.DM_SanPham), "Id,sMaSanPham,sTenSanPham", orderBy: "SortOrder");
            cbosDM_SanPham_Id.DictionaryName = "DM_SanPham";
            cbosDM_SanPham_Id.AddColumn("sMaSanPham", "Mã sản phẩm", 120);
            cbosDM_SanPham_Id.AddColumn("sTenSanPham", "Tên sản phẩm", 180);
            cbosDM_SanPham_Id.Properties.DataSource = dm_SanPhams;
            cbosDM_SanPham_Id.Properties.DisplayMember = "sTenSanPham";
            cbosDM_SanPham_Id.Properties.ValueMember = "Id";
        }

        /// <summary>
        /// Khởi tạo thông tin grid
        /// </summary>
        private void InitGrid()
        {
            var dm_DonViTinhs = DBContext.GetRep<MT.Data.Rep.DM_DonViTinhRepository>().GetData(typeof(MT.Data.BO.DM_DonViTinh), "Id,sTenDonViTinh", orderBy: "SortOrder");

            //Phụ kiện

            grdPhuKienDetail.GrdDetail.TableName = "Phieu_XuatSanPham_CT_PhuKien";
            grdPhuKienDetail.GrdDetail.KeyName = "Id";
            grdPhuKienDetail.GrdDetail.SetField = "phieu_XuatSanPham_CT_PhuKiens";
            grdPhuKienDetail.GrdDetail.DisableFieldNames = "rThanhTien";

            var colPhuKien = grdPhuKienDetail.GrdDetail.AddColumnText("sDM_PhuKien_Id", "Tên phụ kiện", 180, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left,
                dataType: MTControl.DataTypeColumn.LookUpEdit);

            MRepositoryItemLookUpEdit colsDM_PhuKien_IdPhuKien = (MRepositoryItemLookUpEdit)colPhuKien.ColumnEdit;
            colsDM_PhuKien_IdPhuKien.DictionaryName = "DM_PhuKien";
            colsDM_PhuKien_IdPhuKien.AddColumn("sMaPhuKien", "Mã phụ kiện", 120);
            colsDM_PhuKien_IdPhuKien.AddColumn("sTenPhuKien", "Tên phụ kiện", 180);
            colsDM_PhuKien_IdPhuKien.DataSource = DBContext.GetRep<MT.Data.Rep.DM_PhuKienRepository>().GetData(typeof(MT.Data.BO.DM_PhuKien),
                "Id,sMaPhuKien,sTenPhuKien", orderBy: "SortOrder");
            colsDM_PhuKien_IdPhuKien.DisplayMember = "sTenPhuKien";
            colsDM_PhuKien_IdPhuKien.ValueMember = "Id";

            colPhuKien = grdPhuKienDetail.GrdDetail.AddColumnText("sDM_DonViTinh_Id", "Đơn vị tính", 150, dataType: MTControl.DataTypeColumn.LookUpEdit);

            MRepositoryItemLookUpEdit colssDM_DonViTinh_IdPhuKien = (MRepositoryItemLookUpEdit)colPhuKien.ColumnEdit;
            colssDM_DonViTinh_IdPhuKien.DictionaryName = "DM_DonViTinh";
            colssDM_DonViTinh_IdPhuKien.AddColumn("sTenDonViTinh", "Tên đơn vị tính", 180);
            colssDM_DonViTinh_IdPhuKien.DataSource = dm_DonViTinhs;
            colssDM_DonViTinh_IdPhuKien.DisplayMember = "sTenDonViTinh";
            colssDM_DonViTinh_IdPhuKien.ValueMember = "Id";

            grdPhuKienDetail.GrdDetail.AddColumnText("rSoLuong", "Số lượng", 150, dataType: MTControl.DataTypeColumn.SpinEdit);
            grdPhuKienDetail.GrdDetail.AddColumnText("rDonGia", "Đơn giá", 150, dataType: MTControl.DataTypeColumn.SpinEdit);
            grdPhuKienDetail.GrdDetail.AddColumnText("rThanhTien", "Thành tiền", 150, dataType: MTControl.DataTypeColumn.SpinEdit);
            grdPhuKienDetail.GrdDetail.AddColumnText("sXuatXu", "Xuất xứ", 150);
            grdPhuKienDetail.GrdDetail.AddColumnText("sGhiChu", "Ghi chú", 200);
            grdPhuKienDetail.GrdDetail.CustomRowCellEditing = new EventHandler<DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs>(gridControlCustomRowCellEdit);

            grdPhuKienDetail.GrdDetail.FirstView.CellValueChanged -= FirstView_CellValueChanged;
            grdPhuKienDetail.GrdDetail.FirstView.CellValueChanged += FirstView_CellValueChanged;
        }

        #endregion
        #region"Event"

        private void frmXuatSanPhamCT_PhuKien_Detail_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
            dicControls = new Dictionary<string, IEditControl>();
            dicControls = CommonFnUI.GetAllControls(this, new Dictionary<string, IEditControl>());

            CommonFnUI.BinddingValueIntoControl(_Phieu_XuatSanPham_CT, dicControls);

            CommonFnUI.SetReaOnlyForControlByFormAction(true, dicControls);

            if (!backgroundWorkerLoadChiTietPhuKien.IsBusy)
            {
                backgroundWorkerLoadChiTietPhuKien.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Bắt event cellediting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControlCustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            RepositoryItem repositoryItem = sender as RepositoryItem;
            CustomRowCellGridDetail(repositoryItem.Tag as MGridControl, repositoryItem, e);
        }

        /// <summary>
        /// Bắt event cell của grid thay đổi giá trị
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CustomRowCellValueChangedGridDetail(grdPhuKienDetail.GrdDetail, e);
        }

        /// <summary>
        /// Xử lý event nhấn đồng ý trên form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            _Phieu_XuatSanPham_CT.phieu_XuatSanPham_CT_PhuKiens = grdPhuKienDetail.GrdDetail.GetDataChanges();
            this.Close();
        }

        private void backgroundWorkerLoadChiTietPhuKien_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = DBContext.GetRep<Phieu_XuatSanPham_CTRepository>().GetDetailsByMasterID2("Phieu_XuatSanPham_CT_PhuKien",
                "Phieu_XuatSanPham_CT_PhuKien",
                _Phieu_XuatSanPham_CT.Id);
        }

        private void backgroundWorkerLoadChiTietPhuKien_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result != null)
                {
                    IList datas = (IList)e.Result;

                    IList deleteItems = new List<object>();

                    if (_Phieu_XuatSanPham_CT.phieu_XuatSanPham_CT_PhuKiens != null
                        && _Phieu_XuatSanPham_CT.phieu_XuatSanPham_CT_PhuKiens.Count > 0)
                    {
                        foreach (var oldItem in _Phieu_XuatSanPham_CT.phieu_XuatSanPham_CT_PhuKiens)
                        {
                            Phieu_XuatSanPham_CT_PhuKien castOldItem = (Phieu_XuatSanPham_CT_PhuKien)oldItem;

                            if (castOldItem.MTEntityState == Enummation.MTEntityState.Delete)
                            {
                                deleteItems.Add(castOldItem);
                            }

                            bool isFindData = false;
                            foreach (var dbItem in datas)
                            {
                                Phieu_XuatSanPham_CT_PhuKien castDbItem = (Phieu_XuatSanPham_CT_PhuKien)dbItem;
                                if (castOldItem.Id == castDbItem.Id)
                                {
                                    //Update
                                    if (castOldItem.MTEntityState == Enummation.MTEntityState.Delete)
                                    {
                                        castDbItem.MTEntityState = Enummation.MTEntityState.Delete;
                                    }
                                    else
                                    {
                                        dbItem.CopyObject(castOldItem);
                                    }
                                    isFindData = true;
                                    break;
                                }
                            }
                            if (!isFindData)
                            {
                                datas.Add(castOldItem);
                            }
                        }
                        grdPhuKienDetail.GrdDetail.LoadData(datas);

                        //Lưu lại các bản ghi đã bị xóa
                        grdPhuKienDetail.GrdDetail.SaveRecordDelete(deleteItems);
                    }
                    else
                    {
                        grdPhuKienDetail.GrdDetail.LoadData(datas);
                    }
                }
                else
                {
                    grdPhuKienDetail.GrdDetail.LoadData(null);
                }
            }
            else
            {
                MMessage.ShowError(e.Error.Message);
            }
        }

        #endregion

        #region"Overrides"

        /// <summary>
        /// Custom lại cell của grid
        /// </summary>
        /// <param name="mGridControl"></param>
        /// <param name="e"></param>
        protected void CustomRowCellGridDetail(MGridControl mGridControl, RepositoryItem repository, CustomRowCellEditEventArgs e)
        {
            switch (mGridControl.TableName)
            {
                case "Phieu_XuatSanPham_CT_PhuKien":
                    if (e.Column.FieldName == "sDM_PhuKien_Id")
                    {
                        MRepositoryItemLookUpEdit mRepositoryItemLookUpEdit = (MRepositoryItemLookUpEdit)repository;
                        string where = string.Empty;
                        mRepositoryItemLookUpEdit.DataSource = DBContext.GetRep<MT.Data.Rep.DM_PhuKienRepository>().GetData(typeof(MT.Data.BO.DM_PhuKien),
                         "Id,sMaPhuKien,sTenPhuKien", where: $"sDM_SanPham_Id='{_Phieu_XuatSanPham_CT.sDM_SanPham_Id.Value}'");
                    }
                    break;
            }
        }

        /// <summary>
        /// Thực hiện bắt event tính tổng tiền trên grid chi tiết  TT=rDonGia*SL
        /// </summary>
        /// <param name="mGridControl"></param>
        /// <param name="e"></param>
        protected void CustomRowCellValueChangedGridDetail(MGridControl mGridControl, CellValueChangedEventArgs e)
        {
            switch (mGridControl.TableName)
            {
                case "Phieu_XuatSanPham_CT_PhuKien":
                    if (e.Column.FieldName == "rSoLuong" || e.Column.FieldName == "rDonGia")
                    {
                        var phieu_XuatSanPham_CT_PhuKien = mGridControl.GetRecordByRowSelected<Phieu_XuatSanPham_CT_PhuKien>();
                        mGridControl.FirstView.SetRowCellValue(e.RowHandle, "rThanhTien", phieu_XuatSanPham_CT_PhuKien.rSoLuong * phieu_XuatSanPham_CT_PhuKien.rDonGia);
                    }
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}