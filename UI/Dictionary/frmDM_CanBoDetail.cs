using MT.Data.Rep;
using MT.Library;
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
    public partial class frmDM_CanBoDetail : FormUI.MFormDictionnaryDetail
    {
        public frmDM_CanBoDetail()
        {
            InitializeComponent();

            if (ConfigFormDetail == null)
            {
                ConfigFormDetail = new ConfigFormDetail
                {
                    Rep = DBContext.GetRep<DM_CanBoRepository>(),
                    EntityName = "DM_CanBo",
                    Title = "Cán bộ"
                };
            }

            InitLookup();
        }

        #region"Sub/Func"

        /// <summary>
        /// Khởi tạo các giá trị của lookup
        /// </summary>
        private void InitLookup()
        {
            mTreeLookUpDonVi.Properties.DisplayMember = "sTenDonvi";
            mTreeLookUpDonVi.Properties.ValueMember = "Id";
            var treeList = mTreeLookUpDonVi.Properties.TreeList;
            treeList.KeyFieldName = "Id";
            treeList.ParentFieldName = "sParentId";
            mTreeLookUpDonVi.AddColumn("sMaDonvi", "Mã đơn vị", 120);
            mTreeLookUpDonVi.AddColumn("sTenDonvi", "Tên đơn vị", 180, true);
            mTreeLookUpDonVi.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_DonViRepository>().GetData(typeof(MT.Data.BO.DM_DonVi));
            mTreeLookUpDonVi.AliasFormQuickAdd = "DM_DonVi";

            mLookUpEditChucVu.Properties.DisplayMember = "sTenChucVu";
            mLookUpEditChucVu.Properties.ValueMember = "Id";
            mLookUpEditChucVu.AddColumn("sTenChucVu", "Tên chức vụ", 180, true);
            mLookUpEditChucVu.Properties.DataSource = DBContext.GetRep<MT.Data.Rep.DM_ChucVuRepository>().GetData(typeof(MT.Data.BO.DM_ChucVu),
                columns: "Id,sTenChucVu", orderBy: "sTenChucVu");
            mLookUpEditChucVu.AliasFormQuickAdd = "DM_ChucVu";
        }

        protected override void SetViewModeControlByFromAction()
        {
            base.SetViewModeControlByFromAction();
            txtsTenCanBo.SetReadOnly(true);
        }

        /// <summary>
        /// Hiển thị tên đầy đủ
        /// </summary>
        private void SetFullName()
        {
            txtsTenCanBo.EditValue = txtsHoVaDem.Text + " " + txtsTen.Text;
        }
        #endregion
        #region"Event"
        private void frmDM_CanBo_Load(object sender, EventArgs e)
        {
           
        }
        private void txtsHoVaDem_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                SetFullName();
            }
        }

        private void txtsTen_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                SetFullName();
            }
        }
        #endregion


    }
}
