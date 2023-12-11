using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Dynamic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
namespace MTControl
{
    [ToolboxItem(true)]
    public class MSearchLookUpEdit:DevExpress.XtraEditors.SearchLookUpEdit,IControl
        
    {
        #region"Declare"
        private string decription;

        private bool isShowAddDictionnary;

        [DefaultValue(false)]
        public bool IsShowAddDictionnary
        {
            get { return isShowAddDictionnary; }
            set { isShowAddDictionnary = value; this.OnCreateControl(); }
        }

        private bool isShowQuickSearch;

        [DefaultValue(false)]
        public bool IsShowQuickSearch
        {
            get { return isShowQuickSearch; }
            set { isShowQuickSearch = value; this.OnCreateControl(); }
        }

        private bool isMutiSelect;

        [DefaultValue(false)]
        public bool IsMutiSelect
        {
            get { return isMutiSelect; }
            set { isMutiSelect = value; }
        }

        private string entityName;

        public string EntityName
        {
            get { return this.entityName; }
            set
            {
                entityName = value;
                if (!string.IsNullOrEmpty(value))
                {
                    this.DefineColumn();
                }
            }
        }

        private string columnName;

        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }

        private object valueDefault;

        public object ValueDefault
        {
            get { return valueDefault; }
            set { valueDefault = value; }
        }

        /// <summary>
        /// Có tự động load data hay không
        /// </summary>
        private bool isAutoLoad;

        public bool IsAutoLoad
        {
            get { return isAutoLoad; }
            set { isAutoLoad = value; }
        }

        /// <summary>
        /// Sử dụng để validate không cho bỏ trống
        /// </summary>
        private bool isRequired;

        [DefaultValue(false)]
        public bool IsRequired
        {
            get { return isRequired; }
            set { isRequired = value; }
        }

        /// <summary>
        /// Danh sách các cột cần lấy ra
        /// </summary>
        private string lstColumns;

        public string LstColumns
        {
            get { return lstColumns; }
            set {
                    if (!string.IsNullOrEmpty(value))
                    {
                        lstColumns = value;
                    } 
                
            }
        }
        /// <summary>
        /// Danh sách các caption
        /// </summary>
        private string lstCaptionColumns;

        public string LstCaptionColumns
        {
            get { return lstCaptionColumns; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    lstCaptionColumns = value;
                }

            }
        }
        /// <summary>
        /// Sắp xếp theo tiêu chí
        /// </summary>
        private string sort;

        public string Sort
        {
            get { return sort; }
            set { sort = value; }
        }

        /// <summary>
        /// Giá trị khóa chính của combo
        /// </summary>
        private string primaryKey;

        public string PrimaryKey
        {
            get { return primaryKey; }
            set { primaryKey = value; }
        }

        /// <summary>
        /// Giá trị trong DicStoreDanhMuc=> tìm được store cho combo
        /// </summary>
        private string keyStore;

        public string KeyStore
        {
            get { return keyStore; }
            set { keyStore = value; }
        }

        /// <summary>
        /// Params truyền lên service để load data cho combo
        /// </summary>
        private string paramsDic;
        private DevExpress.XtraGrid.Views.Grid.GridView fPropertiesView;
        //private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit fProperties;
        //private DevExpress.XtraGrid.Views.Grid.GridView fPropertiesView;

        public string ParamsDic
        {
            get { return paramsDic; }
        }
        /// <summary>
        /// Tự gán value bằng tay nếu =true
        /// </summary>
        private bool isSetValueManual;

        public bool IsSetValueManual
        {
            get { return isSetValueManual; }
            set { isSetValueManual = value; }
        }
        #endregion

        #region"MSearchLookUpEdit"
        static MSearchLookUpEdit()
        {
            MRepositoryItemLookUpEdit.RegisterMLookUpEdit();
        }
        #endregion
        #region"Sub/Func"

        public void SetParams(Dictionary<string,object> paramsDic)
        {
            if (paramsDic != null)
            {
                this.paramsDic = JsonConvert.SerializeObject(paramsDic);
            }
        }

        /// <summary>
        /// Gán source cho combo
        /// </summary>
        /// <param name="data"></param>
        /// dvthang-03.07.2016
        public  void SetData(DataTable dt)
        {
            //Thiết lập cột
            DefineColumn();
            //
            
            this.Properties.DataSource = dt;
            if (valueDefault != null)
            {
                this.EditValue = valueDefault;
            }
        }
        /// <summary>
        /// Định nghĩa danh sách cột cho combo
        /// </summary>
        public void DefineColumn()
        {
            //Lấy thông tin cột
            this.SuspendLayout();
            //Xóa hết các cột
            this.Properties.View.Columns.Clear();
            //Đưa các cột vào
            GridColumn column = new GridColumn();
            //
            if (!String.IsNullOrEmpty(lstColumns))
            {
                string[] lstConfig = lstColumns.Split(new char[1] { ';' }, System.StringSplitOptions.RemoveEmptyEntries);
                string[] lstCaptionConfig = lstCaptionColumns.Split(new char[1] { ';' }, System.StringSplitOptions.RemoveEmptyEntries);
                if (lstConfig.Length == lstCaptionConfig.Length)
                {
                    for (int i = 0; i < lstConfig.Length; i++)
                    {
                        //Đưa cột
                        column = this.Properties.View.Columns.AddField(lstConfig[i].ToString());
                        column.Caption = lstCaptionConfig[i].ToString();
                        //Ẩn hiện
                        column.Visible = true;
                    }
                }
            }

            this.ResumeLayout(false);
        }

        #endregion
        #region"Ovrrides"

        /// <summary>
        /// vẽ lại hàm render ra control
        /// </summary>
        /// dvthang-03.07.2016
        protected override void OnCreateControl()
        {
            this.Properties.Buttons.Clear();
            this.Properties.ButtonClick -= new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.mLookup_ButtonClick);
            base.OnCreateControl();
           
            this.Properties.NullText = string.Empty;

            this.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});

            if (this.IsShowQuickSearch)
            {
                DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
                DevExpress.XtraEditors.Controls.EditorButton btnQuickSearch = new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, global::MTControl.Properties.Resources.search, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F), serializableAppearanceObject1, "", "QuickSearch", null, true);
                if (this.Properties.Buttons.IndexOf(btnQuickSearch) < 0)
                {
                    this.Properties.Buttons.Add(btnQuickSearch);

                }

            }
            
            if (this.IsShowAddDictionnary)
            {
                DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
                DevExpress.XtraEditors.Controls.EditorButton btnAddDictionnary = new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, global::MTControl.Properties.Resources.quick_add, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.A), serializableAppearanceObject2, "", "AddDictionnary", null, true);
                if (this.Properties.Buttons.IndexOf(btnAddDictionnary) < 0)
                {
                    this.Properties.Buttons.Add(btnAddDictionnary);

                }
            }
            if (this.IsShowQuickSearch || this.IsShowAddDictionnary)
            {
                this.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.mLookup_ButtonClick);
            }
            
            this.Properties.AutoHeight = false;
            this.Height = MHeight.mscEditControlHeight;
            //Chỉnh header ra giữa
            //this.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //this.Properties.AppearanceDropDownHeader.ForeColor = MColor.ColorLabel;
            //
            SetFont();
        }

        /// <summary>
        /// Thực hiện nhảy Tab khi nhấn Enter
        /// </summary>
        /// <param name="e"></param>
        /// CreatebBy-laipv.19.08.2017
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }
        //public override string EditorTypeName
        //{
        //    get
        //    {
        //        return MRepositoryItemLookUpEdit.MLookUpEdit;
        //    }
        //}
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region "Event"
        private void mLookup_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton button = e.Button;
            if (button != null && button.Tag != null)
            {
                switch (button.Tag.ToString())
                {
                    case "QuickSearch":
                        using (MFormQuickSearch frm = new MFormQuickSearch(this.IsMutiSelect))
                        {
                            frm.ShowDialog();
                        }
                        break;
                    case "AddDictionnary":
                        XtraMessageBox.Show("Chưa làm gì cả");
                        break;
                }
            }
        }
        #endregion

        #region"Implement"
        [Description("Control nhập liệu dạng text")]
        [Category("CustomControl")]
        public string Description
        {
            get
            {
                return decription;
            }
            set
            {
                decription=value;
            }
        }
        public void SetFont()
        {
            this.BackColor = MColor.BackColorEditor;
            this.ForeColor = MColor.ColorLabel;
            this.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        public Ctype Mtype
        {
            get { return Ctype.MSearchLookUpEdit; }
        }
        #endregion

        private void InitializeComponent()
        {
            this.fProperties = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.fPropertiesView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fPropertiesView)).BeginInit();
            this.SuspendLayout();
        }


       
    }
}
