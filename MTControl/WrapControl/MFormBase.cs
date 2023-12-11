using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using System;

namespace MTControl
{
    public class MFormBase :Form
    {
        #region"Declare"
        /// <summary>
        /// Hành động thực hiện là add,watch, edit,delete
        /// </summary>
        private int formAction;

        public int FormAction
        {
            get { return formAction; }
            set { formAction = value; }
        }

        private object controlCallForm;

        public object ControlCallForm
        {
            get { return controlCallForm; }
            set { controlCallForm = value; }
        }

        /// <summary>
        /// Form cha của form hiện tại
        /// </summary>
        private Form parentFrm;

        public Form ParentFrm
        {
            get { return parentFrm; }
            set { parentFrm = value; }
        }

        /// <summary>
        /// Id bản ghi khi nhấn xem, sửa, xóa
        /// </summary>
        private object formId;

        public object FormId
        {
            get { return formId; }
            set { formId = value; }
        }

        private string entityName;

        /// <summary>
        /// Đối tượng master chỉ định
        /// </summary>
        public string EntityName
        {
            get { return entityName; }
            set { entityName = value; }
        }

        /// <summary>
        /// Khóa chính của bảng
        /// </summary>
        private string primaryKeyName;

        public string PrimaryKeyName
        {
            get { return primaryKeyName; }
            set { primaryKeyName = value; }
        }

        private MGridControl grdCallBack;

        public MGridControl GrdCallBack
        {
            get { return grdCallBack; }
            set { grdCallBack = value; }
        }

        /// <summary>
        /// Thêm nhanh đối tượng
        /// </summary>
        /// Create by: dvthang:21.10.2017
        public bool IsQuickAdd { get; set; }

        public string Program { get; set; }

        public string UUID { get; set; } = Guid.NewGuid().ToString();

        #endregion
        #region"Contructor"
        public MFormBase()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.White;
            //Túy biến giao diện cảnh báo
            Localizer.Active = new VietnameEditorsLocalizer();
            // Tùy biến giao diện Grid
            GridLocalizer.Active = new MyGridLocalizer();
        }


        //Khởi tạo form
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFormBase));
            this.SuspendLayout();
            // 
            // MFormBase
            // 
            this.KeyPreview = true;
            this.Name = "MFormBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MFormBase_Load);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Event chạy lần đầu khi form được khởi tạo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Create by: dvthang:05.03.2017
        private void MFormBase_Load(object sender, EventArgs e)
        {
        }
        #endregion
        #region"Sub/Func"
        #endregion
        #region"Ovrrides"
        #endregion
        #region"Implement"

        #endregion
    }
}
