using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MTControl
{
    [Designer(typeof(MGridEditableDesigner))] 
    public partial class MGridEditable : MXtraUserControl
    {
        #region"Declare"
        private  MGridControl grdDetail;

        public bool IsRequired { get; set; }

        /// <summary>
        /// Nội dùng thông báo lỗi
        /// </summary>
        public string InvalidText { get; set; }

        public bool IsHideActionAdd { get; set; }

        /// <summary>
        /// Hàm thực hiện custom lại dữ liệu trước khi add dòng vào grid
        /// </summary>
        public Func<object, MGridControl, bool> FuncCustomActionOnGrid
        {
            get; set;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public  MGridControl GrdDetail
        {
            get {
                if (grdDetail == null)
                {
                    grdDetail = new MGridControl();
                    grdDetail.IsEditable = true;
                    grdDetail.Dock = DockStyle.Fill;
                    grdDetail.FirstView.OptionsSelection.MultiSelect = true;
                    grdDetail.FirstView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
                    panelCenter.Controls.Clear();
                    grdDetail.Padding = new Padding(0);
                    grdDetail.Margin = new Padding(0);
                    grdDetail.SetReadOnly(false);
                    panelCenter.Controls.Add(grdDetail);
                }
                grdDetail.IsHideActionAdd = this.IsHideActionAdd;
                return grdDetail; 
            }
            set { grdDetail = value; }
        }

       
        #endregion
        public MGridEditable()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Kiểu của control
        /// </summary>
        /// Create by: dvthang:04.10.2017
        public Ctype MType
        {
            get
            {
                return Ctype.MGridEditable;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(FuncCustomActionOnGrid!=null && FuncCustomActionOnGrid(sender, this.grdDetail))
            {
                return;
            }
            this.GrdDetail.AddRow();
            btnDel.Enabled = true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.GrdDetail.FirstView.FocusedRowHandle >= 0)
            {
                if (FuncCustomActionOnGrid != null && FuncCustomActionOnGrid(sender, this.grdDetail))
                {
                    return;
                }

                this.GrdDetail.DeleteRow();

                if (this.GrdDetail.FirstView.DataRowCount == 0)
                {
                    btnDel.Enabled = false ;
                }
            }
            else
            {
                MMessage.ShowWarning("Bạn chưa chọn bản ghi để xóa");
            }
        }

        /// <summary>
        /// Thiết lập trạng thái của control
        /// </summary>
        /// <param name="isReadOnly"></param>
        public void SetReadOnly(bool isReadOnly)
        {
            this.grdDetail.SetReadOnly(isReadOnly);
            btnAdd.Enabled = !isReadOnly;
            btnDel.Enabled = !isReadOnly;
        }

        private void MGridEditable_Load(object sender, EventArgs e)
        {
            if (grdDetail.FirstView.Columns.Count > 0)
            {
                var col = grdDetail.FirstView.Columns[0];
                col.SummaryItem.DisplayFormat = "Tổng = {0} bản ghi";
                col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                grdDetail.FirstView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                grdDetail.FirstView.OptionsView.ShowFooter = true;
            }

            if (IsHideActionAdd)
            {
                btnAdd.Hide();
                btnDel.Location = new Point(btnAdd.Location.X, btnAdd.Location.Y);
            }
        }
    }

    public class MGridEditableDesigner : ParentControlDesigner 
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            MGridEditable uc = component as MGridEditable;
            uc.GrdDetail = new MGridControl();
            uc.GrdDetail.IsEditable = true;
            uc.GrdDetail.Dock = DockStyle.Fill;
            uc.panelCenter.Controls.Clear();
            uc.panelCenter.Controls.Add(uc.GrdDetail);
            this.EnableDesignMode(uc.GrdDetail, "MGridEditable");
        }
    }

   
 
}
