using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using FormUI.Base;
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
    public partial class frmEmployeeAccessLevel : MXTraForm
    {
        SysUser sysUser;

        List<DM_DonVi> dM_DonVis = new List<DM_DonVi>();
        public frmEmployeeAccessLevel(SysUser sysUser)
        {
            InitializeComponent();
            this.sysUser = sysUser;
        }

        /// <summary>
        /// Khởi tạo các cột trên tree
        /// </summary>
        /// Create by: dvthang:07.03.2017
        private void InitTree()
        {
            //
            mTreeViewOrg.OptionsBehavior.ReadOnly = true;
            mTreeViewOrg.OptionsView.ShowAutoFilterRow = true;
            mTreeViewOrg.OptionsBehavior.EnableFiltering = true;
            mTreeViewOrg.KeyName = "Id";
            mTreeViewOrg.TableName = "DM_DonVi";
            mTreeViewOrg.ParentFieldName = "sParentId";
            mTreeViewOrg.KeyFieldName = "Id";
            mTreeViewOrg.AddColumnText("sMaDonvi", "Mã đơn vị", 150, isFixWidth: true, fixedStyle: DevExpress.XtraTreeList.Columns.FixedStyle.Left);
            mTreeViewOrg.AddColumnText("sTenDonvi", "Tên đơn vị", 300);
            mTreeViewOrg.AddColumnText("sDM_LoaiDonVi_Id_Ten", "Loại đơn vị", 200);
            mTreeViewOrg.AddColumnText("sGhiChu", "Ghi chú", 250);
            mTreeViewOrg.OptionsView.CheckBoxStyle = DefaultNodeCheckBoxStyle.Check;
            mTreeViewOrg.OptionsBehavior.AllowRecursiveNodeChecking = true;
        }

        private void frmEmployeeAccessLevel_Load(object sender, EventArgs e)
        {
            InitTree();
            dM_DonVis = DBContext.GetRep2<MT.Data.Rep.DM_DonViRepository>().GetRecursiveOrgById(MT.Library.SessionData.OrganizationUnitId);
            mTreeViewOrg.DataSource = dM_DonVis;
            mTreeViewOrg.SetFirstNode();
            mTreeViewOrg.ExpandAll();

            var rep = DBContext.GetRep2<EmployeeAccessLevelRepository>();
            List<Guid> guids = rep.GetAccessLevelByEmployeeId(this.sysUser.Id);

            if (guids?.Count > 0)
            {
                foreach (var item in guids)
                {
                    TreeListNode node = mTreeViewOrg.FindNodeByFieldValue("Id", item);
                    if (node != null)
                    {
                        mTreeViewOrg.SetNodeCheckState(node, CheckState.Checked, false);
                    }

                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Thực hiện lưu mức truy cập dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<TreeListNode> list = mTreeViewOrg.GetAllCheckedNodes();

                List<Guid> orgIds = new List<Guid>();

                foreach (TreeListNode node in list)
                {
                    orgIds.Add(Guid.Parse(node["Id"].ToString()));
                }
                var rep = DBContext.GetRep2<EmployeeAccessLevelRepository>();
                rep.SaveEmployeeAccessLevel(this.sysUser.Id, orgIds);

                MMessage.ShowInfor("Lưu thành công");

                this.Close();
            }
            catch (Exception ex)
            {
                CommonFnUI.HandleException(ex);
            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            if (dM_DonVis?.Count > 0)
            {
                foreach (var item in dM_DonVis)
                {
                    CheckNode(item, CheckState.Checked);
                }
            }
        }

        private void btnUncheck_Click(object sender, EventArgs e)
        {
            if (dM_DonVis?.Count > 0)
            {
                foreach (var item in dM_DonVis)
                {
                    CheckNode(item, CheckState.Unchecked);
                }
            }
        }

        /// <summary>
        /// Thực hiện chọn node
        /// </summary>
        /// <param name="dM_DonVi">Đơn vị</param>
        /// <param name="checkState">Trạng thái của node</param>
        private void CheckNode(DM_DonVi dM_DonVi,CheckState checkState)
        {
            TreeListNode node = mTreeViewOrg.FindNodeByFieldValue("Id", dM_DonVi.Id);
            if (node != null)
            {
                mTreeViewOrg.SetNodeCheckState(node, checkState, false);
            }
        }
        private void btnDefault_Click(object sender, EventArgs e)
        {
            if (dM_DonVis?.Count > 0)
            {
                DM_DonVi dM_DonVi = dM_DonVis.Find(m => m.Id == sysUser.OrganizationUnitId.Value);
                if (dM_DonVi != null)
                {
                    string code = dM_DonVi.sMaDonvi;
                    foreach (var item in dM_DonVis)
                    {
                        CheckNode(item, CheckState.Unchecked);
                        //Đơn vị con cấp 1
                        if (item.sMaDonvi.StartsWith(code) && code.Length + 2 == item.sMaDonvi.Length)
                        {
                            CheckNode(item, CheckState.Checked);
                            continue;
                        }
                        //Đơn vị cùng cấp
                        if (code.Length == item.sMaDonvi.Length)
                        {
                            CheckNode(item, CheckState.Checked);
                            continue;
                        }
                        //Đơn vị cha cấp 1
                        if (code.Length >= 4)
                        {
                            string codeParent = code.Substring(0, code.Length - 2);
                            //Cha cấp 1
                            if (item.sMaDonvi == codeParent)
                            {
                                CheckNode(item, CheckState.Checked);
                            }
                        }

                    }
                }
            }

        }
    }
}
