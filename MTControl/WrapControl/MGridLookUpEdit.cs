using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Newtonsoft.Json;
using DevExpress.XtraEditors.Controls;
using System;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Mask;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;


namespace MTControl
{
    public class MGridLookUpEdit : DevExpress.XtraEditors.GridLookUpEdit, IControl,IEditControl
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
        /// Danh sách column trên grid
        /// </summary>
        /// Create by: dvthang:21.10.2017
        private GridColumnCollection GridColumns = null;

        /// <summary>
        /// Tên form Danh mục sẽ hiển thị lên
        /// </summary>
        private string dictionaryName;

        public string DictionaryName
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

        public string AliasFormQuickAdd
        {
            get { return dictionaryName; }
            set { dictionaryName = value; }
        }

       public  MRepositoryItemGridLookUpEdit RepositoryItem { get; set; }

        public MGridControl Grid { get; set; }

        private EditorButton deleteButton;

        public bool IsHideClearValue { get; set; } = false;

        static MGridLookUpEdit()
        {
            MRepositoryItemGridLookUpEdit.RegisterMGridLookUpEdit();
        }

        public override string EditorTypeName
        {
            get { return MRepositoryItemGridLookUpEdit.MGridLookUpEdit; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new MRepositoryItemGridLookUpEdit Properties
        {
            get
            {
                return base.Properties as MRepositoryItemGridLookUpEdit;
            }
        }


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
                GridColumnCollection cols = this.Properties.View.Columns;
                if (cols != null)
                {
                    row.BeginEdit();
                    foreach (GridColumn col in cols)
                    {
                        var oVal = MTControl.MCommon.GetValueObject(oEntity, col.FieldName);
                        row[col.FieldName] = oVal??DBNull.Value;
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
        #region"Sub/Func"
           
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

        public void SetParams(Dictionary<string, object> paramsDic)
        {
            if (paramsDic != null)
            {
                this.paramsDic = JsonConvert.SerializeObject(paramsDic);
            }
        }

        /// <summary>
        /// Clear hết column trên grid
        /// </summary>
        /// Create by: dvthang:09.04.2017
        public void CleadAllColumn()
        {
            if (GridColumns != null)
            {
                GridColumns.Clear();
            }
        }

        /// <summary>
        /// Add column cho gridColum
        /// </summary>
        /// <param name="fieldName">Định danh cột</param>
        /// <param name="caption">Tên cột</param>
        /// <param name="width">Độ rộng</param>
        /// Create by: dvthang:21.09.2017
        public MGridColumn AddColumn(string fieldName, string caption, int width = -1, bool isEnd = false)
        {
            if (this.GridColumns == null)
            {
                this.GridColumns = this.Properties.View.Columns;
                this.GridColumns.Clear();
                this.Properties.BeginUpdate();
            }
            MGridColumn col = new MGridColumn();
            col.FieldName = fieldName;
            col.Caption = caption;
            col.Visible = true;
            if (width > 0)
            {
                col.Width = width;
            }
            this.GridColumns.Add(col);
            if (isEnd)
            {
                this.Properties.EndUpdate();
            }
            return col;
        }

        #endregion
        #region"Ovrrides"
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.Properties.AutoHeight = false;

            RepositoryItem = (this.Tag as MRepositoryItemGridLookUpEdit);
            if (RepositoryItem != null)
            {
                this.DictionaryName = RepositoryItem.DictionaryName;
                this.Properties.DisplayMember = RepositoryItem.DisplayMember;
                this.Properties.ValueMember = RepositoryItem.ValueMember;
                this.Grid = RepositoryItem.GridMaster;
                this.Properties.BeforeShowMenu -= Properties_BeforeShowMenu;
                this.Properties.BeforeShowMenu += Properties_BeforeShowMenu;
            }
            else
            {
                this.Properties.AutoHeight = false;
                this.Height = MHeight.msComboHeight;
                this.CreateButtonExtend();
            }

            SetFont();
            this.Properties.TextEditStyle = TextEditStyles.Standard;
            this.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.Properties.ImmediatePopup = true;
            this.Properties.View.OptionsView.ShowAutoFilterRow = true;
            this.Properties.View.OptionsView.ShowColumnHeaders = true;
            this.Properties.View.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.Properties.View.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            this.Properties.NullText = string.Empty;
            this.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

            this.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;

            this.EditValueChanged += gridLookUpEdit_EditValueChanged;
            this.Properties.ActionButtonIndex = 1;

            this.Properties.View.PopupMenuShowing -= gridView_PopupMenuShowing;
            this.Properties.View.PopupMenuShowing += gridView_PopupMenuShowing;

            this.Properties.View.BestFitColumns();

        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            MGridView.ProcessPopupMenuShowing(e);
        }

        private void gridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            SetClearButton();
        }

        private void Properties_BeforeShowMenu(object sender, BeforeShowMenuEventArgs e)
        {
            e.Menu.Items.Clear();
        }

        /// <summary>
        /// Tạo button mở rộng trên grid
        /// </summary>
        /// Create by: dvthang:21.10.2017
        private void CreateButtonExtend()
        {
            List<EditorButton> lst = new List<EditorButton>();
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
                EditorButton btnAddDic = new EditorButton(ButtonPredefines.Glyph,MTControl.Properties.Resources.quick_add,null);
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
        /// Thực hiện nhảy Tab khi nhấn Enter
        /// </summary>
        /// <param name="e"></param>
        /// CreatebBy-dvthang.24.09.2017
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Tab:
                    if (iCountEnter >= 1 || !this.ReadOnly)
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

        /// Focus vào control
        /// </summary>
        /// Create by: dvthang:24.09.2017
        public void FocusControl()
        {
            this.Focus();
            this.SelectAll();
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
                decription = value;
            }
        }
        public void SetFont()
        {
            this.BackColor = MColor.BackColorEditor;
            this.ForeColor = MColor.ColorLabel;
            this.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        #endregion

        /// <summary>
        /// Kiểu của control
        /// </summary>
        /// Create by: dvthang:04.10.2017
        public Ctype Mtype
        {
            get { return Ctype.MGridLookUpEdit; }
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
    }
}
