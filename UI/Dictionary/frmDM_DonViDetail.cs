using MT.Data.BO;
using MT.Data.Rep;
using MT.Library;
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
    public partial class frmDM_DonViDetail : FormUI.MFormDictionnaryDetail
    {
        public frmDM_DonViDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<DM_DonViRepository>(),
                    EntityName = "DM_DonVi",
                    Title = "Đơn vị"
                };
            }

            
            InitLookup();
        }

        #region"Sub/Func"
       

        protected override void SaveSucess(bool isSaveNew)
        {
            base.SaveSucess(isSaveNew);
            if (isSaveNew)
            {
                InitLookup();

                var picLists = (List<DM_PickList>)DBContext.GetRep2<DM_PickListRepository>().GetData(typeof(DM_PickList), "sTen", $"PickListType=1", "SortOrder");
                cboTenCotBaoCao.Properties.Items.Clear();
                cboTenCotBaoCao.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                cboTenCotBaoCao.Properties.Items.AddRange(picLists.Select(m => m.sTen).ToList());
            }
        }

        /// <summary>
        /// Khởi tạo các giá trị của lookup
        /// </summary>
        private void InitLookup()
        {
            mtreeLookupDonViCha.Properties.DisplayMember = "sTenDonvi";
            mtreeLookupDonViCha.Properties.ValueMember = "Id";
            var treeList = mtreeLookupDonViCha.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            mtreeLookupDonViCha.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            mtreeLookupDonViCha.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            mtreeLookupDonViCha.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_DonViRepository>().GetData(typeof(MT.Data.BO.DM_DonVi),
                columns: "Id,sParentId,sMaDonvi,sTenDonvi", orderBy: "sMaDonvi");

        }
        #endregion
        #region"Event"
        private void frmDM_DonViDetail_Load(object sender, EventArgs e)
        {
            var picLists = (List<DM_PickList>)DBContext.GetRep2<DM_PickListRepository>().GetData(typeof(DM_PickList),"sTen",$"PickListType=1", "SortOrder");
            cboTenCotBaoCao.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            cboTenCotBaoCao.Properties.Items.AddRange(picLists.Select(m=>m.sTen).ToList());
        }

        private void mtreeLookupDonViCha_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (e.NewValue != e.OldValue)
                {
                    Guid gDonViId=Guid.Empty;
                    if (e.NewValue != null && Guid.TryParse(e.NewValue.ToString(),out gDonViId))
                    {
                        txtsMaDonvi.EditValue = ((DM_DonViRepository)ConfigFormDetail.Rep).SinhMaDonVi(gDonViId, Enummation.MTEntityState.Add);
                    }
                    else
                    {
                        txtsMaDonvi.EditValue = ((DM_DonViRepository)ConfigFormDetail.Rep).SinhMaDonVi(gDonViId, Enummation.MTEntityState.Add);
                    }
                }
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }

        }
        private void mtreeLookupDonViCha_EditValueChanged(object sender, EventArgs e)
        {
            switch (this.FormAction)
            {
                case (int)MT.Library.Enummation.MTEntityState.Add:
                    if (mtreeLookupDonViCha.EditValue != null)
                    {
                        rdoLoaiCon.SetReadOnly(false);
                        rdoLoaiCon.SetValue(1);
                    }
                    else
                    {
                        rdoLoaiCon.SetValue(null);
                    }
                    break;
                case (int)MT.Library.Enummation.MTEntityState.Edit:
                    if (mtreeLookupDonViCha.EditValue == null)
                    {
                        rdoLoaiCon.SetValue(null);
                    }
                    break;
            }
        }
        #endregion
        #region"Overrides"
        protected override void SetViewModeControlByFromAction()
        {
            base.SetViewModeControlByFromAction();
            txtsMaDonvi.SetReadOnly(true);
            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.View:
                case (int)MTControl.FormAction.Edit:
                    mtreeLookupDonViCha.SetReadOnly(true);
                    break;
            }

        }

        /// <summary>
        /// Custom dữ liệu trước khi binding
        /// </summary>
        /// <returns></returns>
        protected override BaseEntity PrepareDataBeforeBindDataForm()
        {
            var currentData =(MT.Data.BO.DM_DonVi)base.PrepareDataBeforeBindDataForm();
            string sMaDonVi = string.Empty;
            switch (this.FormAction)
            {
                case (int)MTControl.FormAction.Add:
                    sMaDonVi = ((DM_DonViRepository)ConfigFormDetail.Rep).SinhMaDonVi(currentData.sParentId, Enummation.MTEntityState.Add);
                    currentData.SetValue("sMaDonvi", sMaDonVi);
                    currentData.SetValue("sDM_LoaiDonVi_Id", Guid.Parse("56342b60-50a1-4e95-93a5-0943789fb342"));
                    break;
                case (int)MTControl.FormAction.Duplicate:
                    sMaDonVi = ((DM_DonViRepository)ConfigFormDetail.Rep).SinhMaDonVi(Guid.Parse(this.FormId.ToString()), Enummation.MTEntityState.Duplicate);
                    currentData.SetValue("sMaDonvi", sMaDonVi);
                    currentData.SetValue("sDM_LoaiDonVi_Id", Guid.Parse("56342b60-50a1-4e95-93a5-0943789fb342"));
                    break;
            }
          
            return currentData;
        }


        #endregion

        
    }
}
