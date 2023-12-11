using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace MTControl
{
    public class MCheckComboBox : DevExpress.XtraEditors.CheckedComboBoxEdit, IControl,IEditControl
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

        public MRepositoryItemCheckedComboBox RepositoryItem { get; set; }

        public MGridControl Grid { get; set; }

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
        #endregion
        #region"Contructor"
        #region"MLookUpEdit"
        static MCheckComboBox()
        {
            MRepositoryItemCheckedComboBox.RegisterMCheckComboBox();
        }
        #endregion
        #endregion
        #region"Sub/Func"
        public void SetParams(Dictionary<string, object> paramsDic)
        {
            if (paramsDic != null)
            {
                this.paramsDic = JsonConvert.SerializeObject(paramsDic);
            }
        }

        /// <summary>
        /// Trả về danh sách các giá trị đã chọn 
        /// </summary>
        /// <returns></returns>
        public string GetValues()
        {
            object objValue = this.Properties.GetCheckedItems();
            if (objValue != null)
            {
                return System.Convert.ToString(this.Properties.GetCheckedItems());
            }
            return null ;
        }

        /// <summary>
        /// Gán giá trị cho control mCheckCombo
        /// </summary>
        /// <param name="strValues"></param>
        public void SetCheckedValues(string strValues){
            if (!string.IsNullOrEmpty(strValues))
            {
                string[] arrValues = strValues.Split(new char[1] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
                this.SetEditValue(string.Join(",", arrValues));
            }
            else
            {
                this.SetEditValue(null);
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
        }


        #endregion
        #region"Ovrrides"
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            RepositoryItem = (this.Tag as MRepositoryItemCheckedComboBox);
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
            }

            List<EditorButton> lst = new List<EditorButton>();
            this.Properties.Buttons.Clear();
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

            SetFont();
        }

        private void Properties_BeforeShowMenu(object sender, BeforeShowMenuEventArgs e)
        {
            e.Menu.Items.Clear();
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
                MCommon.ShowForm(this.QuickSearchName, this.AliasFormQuickAdd, this.DictionaryName, this, sender, e);
            }

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
            get { return Ctype.MCheckComboBox; }
        }

        /// <summary>
        /// Thiết lập giá trị cho control
        /// </summary>
        /// <param name="value">Giá trị cần gán</param>
        /// Create by: dvthang:25.10.2017
        public void SetValue(object value)
        {
            this.SetCheckedValues(Convert.ToString(value));
        }

        /// <summary>
        /// Lấy giá trị của control
        /// </summary>
        /// <returns>Trả về giá trị của control</returns>
        /// Create by: dvthang:25.10.2017
        public object GetValue()
        {
            return this.GetValues();
        }
        #endregion

    }
}
