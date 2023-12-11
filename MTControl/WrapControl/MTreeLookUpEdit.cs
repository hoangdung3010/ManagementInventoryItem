using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Newtonsoft.Json;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
namespace MTControl
{
    public class MTreeLookUpEdit : DevExpress.XtraEditors.TreeListLookUpEdit, IControl,IEditControl
    {
        #region"Declare"
        private string decription;

        private string columnName;

        public string SetField
        {
            get { return columnName; }
            set { columnName = value; }
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
        /// Tên đối tượng load source
        /// </summary>
        private string entityName;

        public string EntityName
        {
            get { return entityName; }
            set { entityName = value; }
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
        /// Chỉ định store load data
        /// </summary>
        private string keyStore;

        public string KeyStore
        {
            get { return keyStore; }
            set { keyStore = value; }
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

        private TreeListColumnCollection columns;

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

        public MRepositoryItemTreeLookUpEdit RepositoryItem { get; set; }

        public string CustomSetFields { get; set; }

        public MGridControl Grid { get; set; }

        private EditorButton deleteButton;

        private bool IsHideClearValue { get; set; } = false;
        #endregion

        #region"MLookUpEdit"
        #endregion
        #region"Sub/Func"

        /// <summary>
        /// Tạo button mở rộng trên grid
        /// </summary>
        /// Create by: dvthang:21.10.2017
        private void CreateButtonExtend()
        {
            List<EditorButton> lst = new List<EditorButton>();
            this.Properties.Buttons.Clear();
            this.Properties.Buttons.Clear();

            deleteButton = new EditorButton(MTControl.Properties.Resources.edit, ButtonPredefines.Delete);
            deleteButton.Tag = "ClearValue";
            deleteButton.ToolTip = "Xóa";
            deleteButton.Visible = false;
            lst.Add(deleteButton);

            lst.Add(new EditorButton(ButtonPredefines.Combo));
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

        public void SetClearButton()
        {
            if (deleteButton != null)
            {
                if (this.ReadOnly|| IsHideClearValue)
                {
                    deleteButton.Visible = false;
                }
                else
                {
                    deleteButton.Visible = !Equals(this.EditValue, null) &&!string.IsNullOrWhiteSpace(this.Text);
                }
            }
        }

        /// <summary>
        /// Đăng ký event show form QuichSearch hoặc form danh mục thêm nhanh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Create by: dvthang:21.10.2017
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
        /// <summary>
        /// Dùng binding source để đổ dữ liệu cho tree
        /// </summary>
        /// Create by: dvthang:21.10.2017
        public void PushItem(object oEntity)
        {
            object dataSource = this.Properties.DataSource;
            DataTable data = dataSource as DataTable;
            if (data != null)
            {
                DataRow row = data.NewRow();
                TreeListColumnCollection cols= this.Properties.TreeList.Columns;
                if (cols != null)
                {
                    row.BeginEdit();
                    foreach (TreeListColumn col in cols)
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
        /// Căn chỉnh vị trí các text trong column grid(Giữa, trái , phải)
        /// </summary>
        protected void SetDefaultAlignTree()
        {

            foreach (TreeListColumn col in this.Properties.TreeList.Columns)
            {
                Type t = col.GetType();
                if (t.Equals(typeof(string)))
                {
                    //Căn trái dữ liệu
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                }
                else if (t.Equals(typeof(DateTime)) || t.Equals(typeof(DateTime?)))
                {
                    //Căn Giữa dữ liệu
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                else if (t.Equals(typeof(Decimal)) || t.Equals(typeof(Decimal?)))
                {
                    //Căn Phải dữ liệu
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                }
                else if (t.Equals(typeof(Int32)) || t.Equals(typeof(Int32?)))
                {
                    //Căn Phải dữ liệu
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                }
                else if (t.Equals(typeof(float)) || t.Equals(typeof(float?)))
                {
                    //Căn Phải dữ liệu
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                }
                else if (t.Equals(typeof(int)) || t.Equals(typeof(int?)))
                {
                    //Căn Phải dữ liệu
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                }
                //Căn giữa header
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        /// <summary>
        /// Clear hết column trên grid
        /// </summary>
        /// Create by: dvthang:09.04.2017
        public void CleadAllColumn()
        {
            if (columns != null)
            {
                columns.Clear();
            }
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

        /// <summary>
        /// Add column cho treeList
        /// </summary>
        /// <param name="fieldName">Định danh cột</param>
        /// <param name="caption">Tên cột</param>
        /// <param name="width">Độ rộng</param>
        /// <param name="isEnd">=true đánh dấu field cuối cùng được thêm</param>
        /// Create by: dvthang:10.03.2017
        public TreeListColumn AddColumn(string fieldName, string caption, int width, bool isEnd = false)
        {

            if (columns == null)
            {
                columns = this.Properties.TreeList.Columns;
                columns.Clear();
                columns.TreeList.BeginUpdate();
            }
            TreeListColumn col = columns.ColumnByFieldName(fieldName);
            if (col == null)
            {
                col = new TreeListColumn();
                col.FieldName = fieldName;
                col.Caption = caption;
                col.Width = width;
                col.Visible = true;
                columns.Add(col);
                if (isEnd)
                {
                    columns.TreeList.EndUpdate();
                }
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
        #region"Ovrrides"

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            RepositoryItem = (this.Tag as MRepositoryItemTreeLookUpEdit);
            if (RepositoryItem != null)
            {
                this.DictionaryName = RepositoryItem.DictionaryName;
                this.CustomSetFields = RepositoryItem.CustomSetFields;
                this.Grid = RepositoryItem.GridMaster; 
                this.Properties.BeforeShowMenu -= Properties_BeforeShowMenu;
                this.Properties.BeforeShowMenu += Properties_BeforeShowMenu;
            }
            else
            {
                this.Properties.AutoHeight = false;
                this.Height = MHeight.msComboHeight;
                CreateButtonExtend();
            }
            SetFont();
            this.SetDefaultAlignTree();
            this.SetStyleDefault();

            if (RepositoryItem!=null && !this.Grid.IsEditable)
            {
                this.Properties.TreeList.OptionsView.ShowCaption = false;
                this.Properties.TreeList.OptionsView.ShowColumns = false;
            }

            if (IsReadOnly)
            {
                SetReadOnly(IsReadOnly);
            }
            //
            this.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            if (string.IsNullOrWhiteSpace(this.Properties.TreeList.KeyFieldName))
            {
                this.Properties.TreeList.KeyFieldName = this.Properties.ValueMember;
            }
            this.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;

            this.EditValueChanged += treeLookUpEdit_EditValueChanged;
            this.Properties.ActionButtonIndex = 1;
        }

        private void treeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            SetClearButton();
        }

        private void Properties_BeforeShowMenu(object sender, BeforeShowMenuEventArgs e)
        {
            e.Menu.Items.Clear();
        }

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (iCountEnter >= 1 && !this.ReadOnly)
                    {
                        iCountEnter = 0;
                        SendKeys.Send("{TAB}");
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
                            SendKeys.Send("{TAB}");
                        }
                    }
                    break;
                case Keys.Tab:
                    if (RepositoryItem != null && RepositoryItem.GridMaster!=null)
                    {
                        MCommon.GridControlNextCell(RepositoryItem.GridMaster);
                    }
                    else
                    {
                        SendKeys.Send("{TAB}");
                    }
                    break;
                case Keys.Left:
                    if (RepositoryItem != null && RepositoryItem.GridMaster != null)
                    {
                        MCommon.GridControlPreviousCell(RepositoryItem.GridMaster);
                    }
                    break;
                case Keys.Up:
                    if (RepositoryItem != null && RepositoryItem.GridMaster != null)
                    {
                        MCommon.GridControlUpDownCell(RepositoryItem.GridMaster,false);
                    }
                    break;
                case Keys.Down:
                    if (RepositoryItem != null && RepositoryItem.GridMaster != null)
                    {
                        MCommon.GridControlUpDownCell(RepositoryItem.GridMaster, true);
                    }
                    break;
                case Keys.Right:
                    if (RepositoryItem != null && RepositoryItem.GridMaster != null)
                    {
                        MCommon.GridControlNextCell(RepositoryItem.GridMaster);
                    }
                    break;
                case Keys.Delete:
                    this.EditValue = null;
                    SetClearButton();
                    e.Handled = true;
                    break;
                case Keys.A:
                    if (e.Control)
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

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (!this.ReadOnly && !string.IsNullOrEmpty(this.Text))
            {
                this.SelectAll();
            }
        }
        /// <summary>
        /// Thiết lập các thuộc tính mặc định cho control
        /// </summary>
        /// Create by: dvthang:10.03.2017
        private void SetStyleDefault()
        {
            
            this.Properties.TextEditStyle = TextEditStyles.Standard;
            this.Properties.NullText = string.Empty;
            this.Properties.ImmediatePopup = true;
            this.Properties.AutoComplete = true;
            this.Properties.TreeList.OptionsView.ShowAutoFilterRow = true;
            this.Properties.TreeList.OptionsView.ShowColumns = true;
        }
        #endregion
        #region"Implement"
        [Description("Control nhập liệu dạng text")]
        [Category("MTControl")]
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
            get { return Ctype.MTreeLookUpEdit; }
        }

        #region"Contructor"
        #endregion

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
            if (!string.IsNullOrEmpty(this.Text))
            {
                TreeListNode oNode = this.Properties.TreeList.FindNodeByKeyID(this.EditValue);
                if (oNode != null)
                {
                    return oNode[this.MapColumnName];
                }
            }

            return null;
        }

        #endregion
    }
}
