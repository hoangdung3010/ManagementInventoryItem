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
    public partial class frmPhuKienDetail : FormUI.FormUIBase
    {
        BaseEntity _masterData;

        string _tableNameDetail = string.Empty;

        string _propertyNameOnMaster = string.Empty;

        Guid _sDM_SanPham_Id;

        private Dictionary<string, IEditControl> dicControls;

        private bool _bKeHoach;

        private string _tablePhuKienPhuThuoc;

        public Dictionary<string, IEditControl> DicControls
        {
            get { return dicControls; }
            set { dicControls = value; }
        }

        MFormBase _mFormCall;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="sDM_SanPham_Id">Id của sản phẩm</param>
        /// <param name="tableNameDetail">Tên bảng chưa phụ kiện(Kế hoặc hoặc phiếu)</param>
        /// <param name="propertyNameOnMaster">Tên thuộc tính chưa danh sách phụ kiên của _masterData</param>
        /// <param name="masterData">Đối tượng chi tiết sản phẩm của (Kế hoạch/phiếu)</param>
        /// <param name="mFormCall">Form gọi</param>
        /// <param name="bKeHoach">Phụ kiện nhập cho kế hoạch hay cho phiếu</param>
        /// <param name="tablePhuKienPhuThuoc">Bảng mà phụ kiện phụ thuộc</param>
        public frmPhuKienDetail(Guid sDM_SanPham_Id,string tableNameDetail,
            string propertyNameOnMaster, 
            BaseEntity masterData,MFormBase mFormCall,
            bool bKeHoach=true,string tablePhuKienPhuThuoc="")
        {
            InitializeComponent();
            _masterData = masterData;
            _tableNameDetail = tableNameDetail;
            _propertyNameOnMaster = propertyNameOnMaster;
            _sDM_SanPham_Id = sDM_SanPham_Id;
            _mFormCall = mFormCall;
            _bKeHoach = bKeHoach;
            _tablePhuKienPhuThuoc = tablePhuKienPhuThuoc;
            InitGrid();
        }

        #region"Sub/Func"
       

        /// <summary>
        /// Khởi tạo thông tin grid
        /// </summary>
        private void InitGrid()
        {
            var dm_DonViTinhs = DBContext.GetRep<MT.Data.Rep.DM_DonViTinhRepository>().GetData(typeof(MT.Data.BO.DM_DonViTinh), "Id,sTenDonViTinh", orderBy: "SortOrder");

            //Phụ kiện

            grdPhuKienDetail.GrdDetail.TableName = _tableNameDetail;
            grdPhuKienDetail.GrdDetail.KeyName = "Id";
            grdPhuKienDetail.GrdDetail.DisableFieldNames = "sDM_DonViTinh_Id,rThanhTien,sXuatXu";
            grdPhuKienDetail.GrdDetail.FuncCustomRecordBeforeAddRow = GridPhuKien_FuncCustomRecordBeforeAddRow;
           var colPhuKien = grdPhuKienDetail.GrdDetail.AddColumnText("sDM_PhuKien_Id", "Tên phụ kiện", 180, isFixWidth: true,
                fixedStyle: DevExpress.XtraGrid.Columns.FixedStyle.Left,
                dataType: MTControl.DataTypeColumn.LookUpEdit,isRequired:true);

            MRepositoryItemLookUpEdit colsDM_PhuKien_IdPhuKien = (MRepositoryItemLookUpEdit)colPhuKien.ColumnEdit;
           
            colsDM_PhuKien_IdPhuKien.AddColumn("sMaPhuKien", "Mã phụ kiện", 120);
            colsDM_PhuKien_IdPhuKien.AddColumn("sTenPhuKien", "Tên phụ kiện", 180);
          
            colsDM_PhuKien_IdPhuKien.DisplayMember = "sTenPhuKien";
            colsDM_PhuKien_IdPhuKien.ValueMember = "Id";
            colsDM_PhuKien_IdPhuKien.DataSource = DBContext.GetRep<MT.Data.Rep.DM_PhuKienRepository>().GetData(typeof(MT.Data.BO.DM_PhuKien),
              "Id,sMaPhuKien,sTenPhuKien", orderBy: "SortOrder");
            if (_bKeHoach)
            {
                colsDM_PhuKien_IdPhuKien.DictionaryName = "DM_PhuKien";
            }
            
            colPhuKien = grdPhuKienDetail.GrdDetail.AddColumnText("sDM_DonViTinh_Id", "Đơn vị tính", 150, dataType: MTControl.DataTypeColumn.LookUpEdit,isRequired:true);

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

        /// <summary>
        /// Bắt hành động gán giá trị default cho cột grid
        /// </summary>
        /// <returns>=true cho addnewrow, ngược lại ko</returns>
        private bool GridPhuKien_FuncCustomRecordBeforeAddRow(object newRecord, MGridControl mGridControl)
        {
            newRecord.SetValue("sDM_SanPham_Id", _masterData.GetValue<Guid>("sDM_SanPham_Id"));
            return true;
        }

        #endregion
        #region"Event"
        private void frmNhapSanPhamMoiCT_PhuKien_Detail_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
            dicControls = new Dictionary<string, IEditControl>();
            dicControls = CommonFnUI.GetAllControls(this, new Dictionary<string, IEditControl>());

            DM_SanPham dM_SanPham = DBContext.GetRep2<DM_SanPhamRepository>().GetDataByID<DM_SanPham>("DM_SanPham",
                _sDM_SanPham_Id, "sMaSanPham,sTenSanPham");

            lblTitleFormDetail.Text = $"Chi tiết phụ kiện của sản phẩm <{dM_SanPham.sMaSanPham} - {dM_SanPham.sTenSanPham}>";

            CommonFnUI.SetReaOnlyForControlByFormAction(true, dicControls);

            if (_mFormCall.FormAction == (int)MTControl.FormAction.View)
            {
                grdPhuKienDetail.GrdDetail.SetReadOnly(true);
                btnSave.Enabled = false;
            }

            if (!_masterData.IsLoaded && _mFormCall.FormAction != (int)MTControl.FormAction.Add)
            {
                if (!backgroundWorkerLoadChiTietPhuKien.IsBusy)
                {
                    backgroundWorkerLoadChiTietPhuKien.RunWorkerAsync();
                }
            }
            else
            {
                object data = _masterData.GetValue(_propertyNameOnMaster);
                if (data != null)
                {
                    grdPhuKienDetail.GrdDetail.LoadData(data as IList);
                }
                else
                {
                    grdPhuKienDetail.GrdDetail.LoadData(null);
                }

                if (grdPhuKienDetail.GrdDetail.FirstView.DataRowCount == 0)
                {
                    grdPhuKienDetail.GrdDetail.AddRow();
                }
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
            IList datas = grdPhuKienDetail.GrdDetail.GetAllData();
            if (datas == null ||datas.Count==0)
            {
                this.Close();
                return;
            }
            foreach (var item in datas)
            {
                item.SetValue("MTEntityState", (int)Enummation.MTEntityState.Add);
            }
            if (CommonFnUI.IsValidateDataChangedGridDetail(grdPhuKienDetail, datas)){
                _masterData.IsLoaded = true;
                _masterData.SetValue(_propertyNameOnMaster, grdPhuKienDetail.GrdDetail.GetAllData());
                this.Close();
            }
        }

        private void backgroundWorkerLoadChiTietPhuKien_DoWork(object sender, DoWorkEventArgs e)
        {
            IBaseRepository baseRepository = DBContext.GetRepByTableName(_masterData.TableName);
            e.Result = baseRepository.GetDetailsByMasterID2(_tableNameDetail,
                _tableNameDetail,
                _masterData.GetIdentity());
        }

        private void backgroundWorkerLoadChiTietPhuKien_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result != null)
                {
                    IList datas = (IList)e.Result;
                    grdPhuKienDetail.GrdDetail.LoadData(datas);
                }
                else
                {
                    grdPhuKienDetail.GrdDetail.LoadData(null);
                }

                if (grdPhuKienDetail.GrdDetail.FirstView.DataRowCount == 0)
                {
                    grdPhuKienDetail.GrdDetail.AddRow();
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
            if (e.Column.FieldName == "sDM_PhuKien_Id")
            {
                
                MRepositoryItemLookUpEdit mRepositoryItemLookUpEdit = (MRepositoryItemLookUpEdit)repository;
                string where = string.Empty;
                if (!string.IsNullOrWhiteSpace(_tablePhuKienPhuThuoc))
                {
                    string viewName = $@"(SELECT PK.Id,PK.sMaPhuKien,PK.sTenPhuKien,PK.SortOrder FROM View_{_tablePhuKienPhuThuoc} M 
                                    JOIN DM_PhuKien PK ON PK.Id=M.sDM_PhuKien_Id
                                    WHERE M.sDM_SanPham_Id='{_masterData.GetValue("sDM_SanPham_Id")}')";
                    mRepositoryItemLookUpEdit.DataSource = DBContext.GetRepByTableName(_tablePhuKienPhuThuoc).GetData(typeof(MT.Data.BO.DM_PhuKien),
                  "Id,sMaPhuKien,sTenPhuKien", orderBy: "SortOrder", viewName: viewName);
                }
                else
                {
                    mRepositoryItemLookUpEdit.DataSource = DBContext.GetRep<MT.Data.Rep.DM_PhuKienRepository>().GetData(typeof(MT.Data.BO.DM_PhuKien),
                    "Id,sMaPhuKien,sTenPhuKien", where: $"sDM_SanPham_Id='{_masterData.GetValue("sDM_SanPham_Id")}'");
                }
            }
        }

        /// <summary>
        /// Thực hiện bắt event tính tổng tiền trên grid chi tiết  TT=rDonGia*SL
        /// </summary>
        /// <param name="mGridControl"></param>
        /// <param name="e"></param>
        protected  void CustomRowCellValueChangedGridDetail(MGridControl mGridControl, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "sDM_PhuKien_Id")
            {
                //gán mặc định đơn vị tính cấp 1 cho sản phẩm
                DM_PhuKienRepository dM_PhuKienRepository = DBContext.GetRep2<DM_PhuKienRepository>();
                DM_PhuKien dM_PhuKien = null;
                if (e.Value != null)
                {
                    dM_PhuKien = dM_PhuKienRepository.GetDataByID<DM_PhuKien>("DM_PhuKien", e.Value, "sDM_DonViTinh_Id,rDonGia,sXuatXu");
                }
                if (dM_PhuKien != null)
                {
                    mGridControl.FirstView.SetRowCellValue(e.RowHandle, "sDM_DonViTinh_Id", dM_PhuKien.sDM_DonViTinh_Id);

                    mGridControl.FirstView.SetRowCellValue(e.RowHandle, "rSoLuong", 1);

                    mGridControl.FirstView.SetRowCellValue(e.RowHandle, "rDonGia", dM_PhuKien.rDonGia);
                    mGridControl.FirstView.SetRowCellValue(e.RowHandle, "sXuatXu", dM_PhuKien.sXuatXu);
                }
            }

            if (e.Column.FieldName == "rSoLuong" || e.Column.FieldName == "rDonGia")
            {
                var ctPhuKien = mGridControl.GetRecordByRowSelected<object>();
                decimal rSoLuong = ctPhuKien.GetValue<decimal>("rSoLuong");
                decimal rDonGia = ctPhuKien.GetValue<decimal>("rDonGia");
                mGridControl.FirstView.SetRowCellValue(e.RowHandle, "rThanhTien", rSoLuong * rDonGia);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        
    }
}
