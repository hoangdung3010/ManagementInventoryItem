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
using System.Collections;
namespace MTControl
{
    public class MLookUpEdit : DevExpress.XtraEditors.LookUpEdit, IControl, IEditControl
    {
        #region"Declare"
        private string decription;
        /// <summary>
        /// Tên form Danh mục sẽ hiển thị lên
        /// </summary>
        private string dictionaryName;

        public string DictionaryName
        {
            get { return dictionaryName; }
            set { dictionaryName = value; }
        }


        public string AliasFormQuickAdd
        {
            get { return dictionaryName; }
            set { dictionaryName = value; }
        }
        /// <summary>
        /// Tên form QuickSearch sẽ hiển thị lên
        /// </summary>
        private string quickSearchName;

        public string QuickSearchName
        {
            get { return quickSearchName; }
            set { quickSearchName = value; }
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
            }
        }

        private string columnName;

        public string SetField
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
        }

        private string columnsExtend;

        /// <summary>
        /// Danh sách các cột cần mở rộng
        /// </summary>
        /// Create by:dvthang:28.05.2017
        public string ColumnsExtend
        {
            get { return columnsExtend; }
            set { columnsExtend = value; }
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

        /// <summary>
        /// Đánh đấu cột colum đã được buil roh
        /// </summary>
        private bool isHasBuildColumn;

        public bool IsHasBuildColumn
        {
            get { return isHasBuildColumn; }
        }

        /// <summary>
        /// Chứa danh sách các column trên combo
        /// Create by: dvthang:09.04.2017
        /// </summary>
        private LookUpColumnInfoCollection lookUpColumnInfoConlection;

        /// <summary>
        /// Đếm số lần nhấn phím enter
        /// </summary>
        /// Create by: dvthang:24.09.2017
        private byte iCountEnter = 0;

        /// <summary>
        /// Một số trường đặtbiệt cần mapping giá trị sang cột vào đó thì vieetsowr đây
        /// Create by: dvthang:30.09.2017
        /// </summary>
        public string MapColumnName { get; set; }

        /// <summary>
        /// Danh sách các thông tin cần lấy ra khi lưu ngoài các thông tin được chọn,
        /// Các trường cách nhau bởi dấu phẩy ví dụ khi lưu cần lấy thêm thông tin: Tên vật tư, Đơn vị tính thì để như sau: "sTenVT,sDVT"
        /// Create by: dvthang:04.10.2017 
        /// </summary>
        public string AddFields { get; set; }

        /// <summary>
        /// Set reaonly cho control
        /// </summary>
        /// Create by: dvthang:07.10.2017
        public bool IsReadOnly { get; set; }

        public MRepositoryItemLookUpEdit RepositoryItem { get; set; }

        public MGridControl Grid { get; set; }

        private EditorButton deleteButton;
        public bool IsHideClearValue { get; set; } = false;
        #endregion

        #region"MLookUpEdit"
        static MLookUpEdit()
        {
            MRepositoryItemLookUpEdit.RegisterMLookUpEdit();
        }
        #endregion
        #region"Sub/Func"
        /// <summary>
        /// Dùng binding source để đổ dữ liệu cho grid
        /// </summary>
        /// Create by: dvthang:21.10.2017
        public void PushItem(object oEntity)
        {
            object dataSource = this.Properties.DataSource;
            DataTable data = dataSource as DataTable;
            if (data != null)
            {
                DataRow row = data.NewRow();
                LookUpColumnInfoCollection cols = this.Properties.Columns;
                if (cols != null)
                {
                    row.BeginEdit();
                    foreach (LookUpColumnInfo col in cols)
                    {
                        row[col.FieldName] = MTControl.MCommon.GetValueObject(oEntity, col.FieldName);
                    }
                    row.EndEdit();
                }
                data.Rows.InsertAt(row, 0);
            }
            else
            {
                IList lstData = dataSource as IList;
                if (lstData != null)
                {
                    lstData.Insert(0, oEntity);
                }
            }
        }
        public void SetParams(Dictionary<string, object> paramsDic)
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
        public void SetData(DataTable dt)
        {
            this.Properties.DataSource = dt;
        }

        /// <summary>
        /// Định nghĩa danh sách cột cho combo
        /// </summary>
        public void DefineColumn(Dictionary<string, string> defineCombo)
        {
            //Lấy thông tin cột
            this.SuspendLayout();
            LookUpColumnInfoCollection columnsConfig = this.Properties.Columns;
            List<string> lst = new List<string>();
            columnsConfig.Clear();
            if (!string.IsNullOrEmpty(this.EntityName))
            {
                if (defineCombo.ContainsKey(this.EntityName))
                {
                    var json = defineCombo[this.EntityName];
                    Dictionary<string, string> sData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                    if (sData != null)
                    {
                        if (sData.ContainsKey(Constant.mscDisplayMember))
                        {
                            this.Properties.DisplayMember = sData[Constant.mscDisplayMember];
                            lst.Add(sData[Constant.mscDisplayMember]);
                        }
                        if (sData.ContainsKey(Constant.mscValueMember))
                        {
                            lst.Add(sData[Constant.mscValueMember]);
                        }
                        if (sData.ContainsKey(Constant.mscPrimarykey))
                        {
                            this.PrimaryKey = sData[Constant.mscPrimarykey];
                            this.Properties.ValueMember = sData[Constant.mscPrimarykey];
                            lst.Add(sData[Constant.mscPrimarykey]);
                        }

                        if (sData.ContainsKey(Constant.mscColumns) && !string.IsNullOrEmpty(sData[Constant.mscColumns]))
                        {
                            string columns = sData[Constant.mscColumns];
                            string[] lstConfig = columns.Split(new char[1] { ';' }, System.StringSplitOptions.RemoveEmptyEntries);
                            MCommon.SetAssemblyUI();
                            foreach (string col in lstConfig)
                            {
                                string[] strColConfig = col.Split(new char[1] { '|' }, System.StringSplitOptions.RemoveEmptyEntries);
                                if (strColConfig.Length > 1)
                                {

                                    string strName = MCommon.GetGlobalResources(MCommon.AssemblyUI, MCommon.ResourceComboLooUp, string.Format("{0}_{1}", this.EntityName, strColConfig[0]));
                                    columnsConfig.Add(new LookUpColumnInfo(strColConfig[0], Convert.ToInt32(strColConfig[1]), strName));
                                }
                            }
                        }
                    }
                }
            }
            this.lstColumns = string.Join(",", lst);
            this.isHasBuildColumn = true;//Đánh dấu đã buil rồi lần sau không buil lại nữa
            this.ResumeLayout(false);
        }

        /// <summary>
        /// Thiết chế độ readonly cho control
        /// </summary>
        /// <param name="bEnable">=true thì không cho sửa,ngược lại thì được sửa</param>
        /// Create by: dvthang:09.03.2017
        public void SetReadOnly(bool bEnable)
        {
            this.ReadOnly = bEnable;
            this.Properties.ReadOnly = bEnable;
            if (bEnable)
            {
                this.BackColor = MColor.BackColorDisable;
                this.Properties.AppearanceReadOnly.BackColor = MColor.BackColorDisable;
            }
            else
            {
                this.BackColor = MColor.BackColorEditor;
                this.Properties.AppearanceReadOnly.BackColor = MColor.BackColorEditor;
            }
            SetClearButton();
        }
        #endregion
        #region"Ovrrides"

        /// <summary>
        /// vẽ lại hàm render ra control
        /// </summary>
        /// dvthang-03.07.2016
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.Properties.NullText = string.Empty;
            RepositoryItem = (this.Tag as MRepositoryItemLookUpEdit);

            if (RepositoryItem != null)
            {
                this.DictionaryName = RepositoryItem.DictionaryName;
                this.Properties.DisplayMember = RepositoryItem.DisplayMember;
                this.Properties.ValueMember = RepositoryItem.ValueMember;
                this.Grid = RepositoryItem.GridMaster;
                this.Properties.BeforeShowMenu -= Properties_BeforeShowMenu;
                this.Properties.BeforeShowMenu += Properties_BeforeShowMenu;

                if (!this.Grid.IsEditable)
                {
                    this.Properties.ShowHeader = false;
                }
            }
            else
            {
                this.Properties.AutoHeight = false;
                this.Height = MHeight.msComboHeight;
                List<EditorButton> lst = new List<EditorButton>();
                this.Properties.Buttons.Clear();

                deleteButton = new EditorButton(MTControl.Properties.Resources.edit, ButtonPredefines.Delete);
                deleteButton.Tag = "ClearValue";
                deleteButton.ToolTip = "Xóa";
                deleteButton.Visible = false;
                lst.Add(deleteButton);

                lst.Add(new EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo));
                if (!string.IsNullOrEmpty(QuickSearchName))
                {
                    EditorButton btnQuickSearch = new EditorButton(ButtonPredefines.Search);
                    btnQuickSearch.Tag = "QuickSearch";
                    lst.Add(btnQuickSearch);
                }

                if (!string.IsNullOrEmpty(DictionaryName))
                {
                    EditorButton btnAddDic = new EditorButton(ButtonPredefines.Glyph, MTControl.Properties.Resources.quick_add, null);
                    btnAddDic.Tag = "AddDictionnary";
                    lst.Add(btnAddDic);
                }

                this.Properties.Buttons.AddRange(lst.ToArray());
                if (lst.Count > 1)
                {
                    this.ButtonClick -= new ButtonPressedEventHandler(this.ShowForm);
                    this.ButtonClick += new ButtonPressedEventHandler(this.ShowForm);
                }
            }


            //Chỉnh header ra giữa
            this.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Properties.AppearanceDropDownHeader.ForeColor = MColor.ColorLabel;
            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.EditValueChanged += lookUpEdit_EditValueChanged;

            this.Properties.ActionButtonIndex = 1;

            if (IsReadOnly)
            {
                SetReadOnly(IsReadOnly);
            }
        }

        private void lookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            SetClearButton();
        }

        public void SetClearButton()
        {
            if (deleteButton != null)
            {
                if (this.ReadOnly || IsHideClearValue)
                {
                    deleteButton.Visible = false;
                }
                else
                {
                    deleteButton.Visible = !Equals(this.EditValue, null) && !string.IsNullOrWhiteSpace(this.Text);
                }
            }
        }

        private void Properties_BeforeShowMenu(object sender, BeforeShowMenuEventArgs e)
        {
            e.Menu.Items.Clear();
        }

        /// <summary>
        /// Bắt event nhấn phím enter trên control
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Tab:
                    if (iCountEnter >= 1 && !this.ReadOnly)
                    {
                        iCountEnter = 0;

                        if (RepositoryItem != null)
                        {
                            MCommon.GridControlNextCell(RepositoryItem.GridMaster);
                        }
                        else
                        {
                            SendKeys.Send("{TAB}");
                        }
                    }
                    else
                    {
                        if (!this.ReadOnly)
                        {
                            iCountEnter++;
                            this.ShowPopup();
                        }
                        else
                        {
                            if (RepositoryItem != null)
                            {
                                MCommon.GridControlNextCell(RepositoryItem.GridMaster);
                            }
                            else
                            {
                                SendKeys.Send("{TAB}");
                            }
                        }
                    }

                    break;
                case Keys.Left:
                    if (RepositoryItem != null && RepositoryItem.GridMaster != null)
                    {
                        MCommon.GridControlPreviousCell(RepositoryItem.GridMaster);
                    }
                    break;
                case Keys.Right:
                    if (RepositoryItem != null && RepositoryItem.GridMaster != null)
                    {
                        MCommon.GridControlNextCell(RepositoryItem.GridMaster);
                    }
                    break;
                case Keys.Up:
                    if (RepositoryItem != null && RepositoryItem.GridMaster != null)
                    {
                        MCommon.GridControlUpDownCell(RepositoryItem.GridMaster, false);
                    }
                    break;
                case Keys.Down:
                    if (RepositoryItem != null && RepositoryItem.GridMaster != null)
                    {
                        MCommon.GridControlUpDownCell(RepositoryItem.GridMaster, true);
                    }
                    break;
                case Keys.Delete:
                    this.EditValue = null;
                    SetClearButton();
                    e.Handled = true;
                    break;
                default:
                    if (e.Control && e.KeyCode == Keys.A)
                    {
                        FocusControl();
                    }

                    break;
            }

        }

        /// <summary>
        /// Focus vào control
        /// </summary>
        /// Create by: dvthang:24.09.2017
        public void FocusControl()
        {
            this.Focus();
            this.SelectAll();
        }

        /// <summary>
        /// Đăng ký event show form QuichSearch hoặc form danh mục thêm nhanh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Create by: dvthang:16.10.2016
        private void ShowForm(object sender, ButtonPressedEventArgs e)
        {
            if (!this.ReadOnly)
            {
                if (e.Button != deleteButton)
                {
                    MCommon.ShowForm(this.QuickSearchName, this.AliasFormQuickAdd, this.DictionaryName, this, sender, e);
                }
                else
                {
                    this.EditValue = null;
                    this.DoValidate();
                    SetClearButton();
                }
            }

        }

        public override string EditorTypeName
        {
            get
            {
                return MRepositoryItemLookUpEdit.MLookUpEdit;
            }
        }

        public new MRepositoryItemLookUpEdit Properties
        {
            get { return base.Properties as MRepositoryItemLookUpEdit; }
        }

        /// <summary>
        /// Clear hết column trên grid
        /// </summary>
        /// Create by: dvthang:09.04.2017
        public void CleadAllColumn()
        {
            if (lookUpColumnInfoConlection != null)
            {
                lookUpColumnInfoConlection.Clear();
            }
        }

        /// <summary>
        /// Add column cho comboLookUp
        /// </summary>
        /// <param name="fieldName">Định danh cột</param>
        /// <param name="caption">Tên cột</param>
        /// <param name="width">Độ rộng</param>
        /// <param name="isEnd">=true đánh dấu field cuối cùng được thêm</param>
        /// Create by: dvthang:10.03.2017
        public LookUpColumnInfo AddColumn(string fieldName, string caption, int width, bool isEnd = false)
        {
            if (lookUpColumnInfoConlection == null)
            {
                lookUpColumnInfoConlection = this.Properties.Columns;
                lookUpColumnInfoConlection.Clear();
                this.Properties.BeginUpdate();
            }
            LookUpColumnInfo col = new LookUpColumnInfo();
            col.FieldName = fieldName;
            col.Caption = caption;
            col.Width = width;
            col.Visible = true;
            lookUpColumnInfoConlection.Add(col);
            if (isEnd)
            {
                this.Properties.EndUpdate();
            }
            return col;
        }

        /// <summary>
        /// Lấy thông tin bản ghi được chọn
        /// </summary>
        /// <typeparam name="T">Đối tượng được chọn</typeparam>
        /// Create by: dvthang:09.04.2017
        public T GetRecordSelected<T>()
        {
            T objData = default(T);
            object data = this.GetSelectedDataRow();
            if (data != null)
            {
                objData = (T)data;
            }
            return objData;
        }
        #endregion

        #region "Event"
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
                decription = value;
            }
        }
        public void SetFont()
        {
            this.BackColor = MColor.BackColorEditor;
            this.ForeColor = MColor.ColorLabel;
            this.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// Kiểu của control
        /// </summary>
        /// Create by: dvthang:04.10.2017
        public Ctype Mtype
        {
            get { return Ctype.MLookUpEdit; }
        }

        /// <summary>
        /// Thiết lập giá trị cho control
        /// </summary>
        /// <param name="value">Giá trị cần gán</param>
        /// Create by: dvthang:25.10.2017
        public void SetValue(object value)
        {
            if (!this.IsSetValueManual)
            {
                this.EditValue = value;
            }
        }

        /// <summary>
        /// Lấy giá trị của control
        /// </summary>
        /// <returns>Trả về giá trị của control</returns>
        /// Create by: dvthang:25.10.2017
        public object GetValue()
        {
            if (string.IsNullOrWhiteSpace(this.MapColumnName))
            {
                return this.EditValue;
            }
            object objSelected = this.GetSelectedDataRow();
            if (objSelected != null)
            {
                return MCommon.GetValueObject(objSelected, this.MapColumnName);
            }

            return null;

        }
        #endregion
    }
}
