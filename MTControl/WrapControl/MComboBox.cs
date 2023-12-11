using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;
using System;
using System.Windows.Forms;
using System.Linq;

namespace MTControl
{
    public class MComboBox : DevExpress.XtraEditors.ComboBoxEdit, IControl, IEditControl
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
        /// Thuộc tính đánh dấu combo có tự động load data không
        /// </summary>
        [DefaultValue(false)]
        private bool isAutoLoad;

        public bool IsAutoLoad
        {
            get { return isAutoLoad; }
            set { isAutoLoad = value; }
        }


        /// <summary>
        /// Tên bảng load data
        /// </summary>
        private bool entityName;

        public bool EntityName
        {
            get { return entityName; }
            set { entityName = value; }
        }

        /// <summary>
        /// Chỉ định enum cho combo
        /// </summary>
        private string enumData;

        public string EnumData
        {
            get { return enumData; }
            set
            {
                enumData = value;
                if (!string.IsNullOrEmpty(value))
                {
                    this.LoadDataEnumForControlComboEdit();
                }
            }
        }

        /// <summary>
        /// Danh các giá trị của enum 
        /// </summary>
        private Dictionary<int, string> itemEnum=new Dictionary<int, string>();

        public Dictionary<int, string> ItemEnum
        {
            get { return itemEnum; }
        }


        /// <summary>
        /// Cờ lưu trạng thái index trước đó của control
        /// </summary>
        [Browsable(false)]
        public int LastAcceptedSelectedIndex { get; set; }

        /// <summary>
        /// Không có giá trị default cho enum
        /// </summary>
        public bool NoDefaultValue { get; set; } = false;

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
        /// Gán giá trị định cho enum
        /// </summary>
        /// Create by: dvthang:09.04.2017
        private int defaultValueEnum = -1;

        public int DefaultValueEnum
        {
            get { return defaultValueEnum; }
            set { defaultValueEnum = value; }
        }

        /// <summary>
        /// Đếm số lần nhấn phím enter
        /// </summary>
        /// Create by: dvthang:24.09.2017
        private byte iCountEnter = 0;

        /// <summary>
        /// Set reaonly cho control
        /// </summary>
        /// Create by: dvthang:07.10.2017
        public bool IsReadOnly { get; set; }

        public MRepositoryComboBox RepositoryItem { get; set; }
        public MGridControl Grid { get; set; }
        #endregion
        #region"Contructor"
        static MComboBox()
        {
            MRepositoryComboBox.RegisterMComboBox();
        }
        public MComboBox()
        {
        }
        #endregion
        #region"Sub/Func"

        /// <summary>
        /// Lấy về vị trí item được chọn
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int GetSelectedIndex(int value)
        {
            int selectedIndex = 0;
            if (this.itemEnum != null && this.itemEnum.ContainsKey(value))
            {
                int index = -1;
                foreach (KeyValuePair<int, string> keys in this.itemEnum)
                {
                    index++;
                    if (keys.Key == value)
                    {
                        return index;
                    }
                }
            }
            return selectedIndex;
        }
        /// <summary>
        /// Đưa vào vị trí item được chọn
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetSelectedIndex(int value)
        {
            if (this.itemEnum != null && this.itemEnum.ContainsKey(value))
            {
                int index = -1;
                foreach (KeyValuePair<int, string> keys in this.itemEnum)
                {
                    index++;
                    if (keys.Key == value)
                    {
                        this.SelectedIndex = index;
                        this.Refresh();
                        return;// index;
                    }
                }
            }
        }
        #endregion

        #region"Ovrrides"
        /// <summary>
        /// Render lại một số thuộc tính cho control
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            
            RepositoryItem = (this.Tag as MRepositoryComboBox);
            if (RepositoryItem != null)
            {
                this.EnumData = RepositoryItem.EnumData;
                this.Grid = RepositoryItem.GridMaster;
                this.Properties.AutoHeight = true;
                RepositoryItem.ItemAutoHeight = true;
            }
            else
            {
                this.Properties.AutoHeight = false;
                this.Height = MHeight.msComboHeight;
            }

            this.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.Properties.AutoComplete = true;
            this.Properties.HotTrackItems = true;
            this.Properties.ShowDropDown = ShowDropDown.SingleClick;
            this.Properties.UseCtrlScroll = true;
            this.Properties.ValidateOnEnterKey = true;
            this.Properties.BeforeShowMenu -= Properties_BeforeShowMenu;
            this.Properties.BeforeShowMenu += Properties_BeforeShowMenu;
            SetFont();
            if (IsReadOnly)
            {
                SetReadOnly(IsReadOnly);
            }
        }

        private void Properties_BeforeShowMenu(object sender, BeforeShowMenuEventArgs e)
        {
            e.Menu.Items.Clear();
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.KeyCode == Keys.Down)
            {
                this.SelectedIndex += 1;
                if (this.SelectedIndex >= this.ItemEnum.Count)
                {
                    this.SelectedIndex = 0;
                }

            }
            else if (e.KeyCode == Keys.Up)
            {
                this.SelectedIndex -= 1;
                if (this.SelectedIndex < 0)
                {
                    this.SelectedIndex = this.ItemEnum.Count - 1;
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.ClosePopup();
            }
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
                        if (RepositoryItem != null && RepositoryItem.GridMaster != null)
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
                            if (RepositoryItem != null && RepositoryItem.GridMaster != null)
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
        /// Load data cho control lookup
        /// </summary>
        private void LoadDataEnumForControlComboEdit()
        {
            ComboBoxItemCollection col = this.Properties.Items;
            if (!string.IsNullOrEmpty(this.EnumData))
            {
                col.BeginUpdate();
                col.Clear();

                try
                {
                    string enumName = this.EnumData;

                    if (!string.IsNullOrEmpty(enumName))
                    {
                        List<DisplayEnum> lstDisplayEnum = null;
                        //Nếu đã tồn tại giá trị enum roh thì ko load lại nữa
                        if (MCommon.ShareEnum != null && MCommon.ShareEnum.ContainsKey(this.EnumData))
                        {
                            lstDisplayEnum = MCommon.ShareEnum[this.enumData];
                            Dictionary<int, string> itemEnum = new Dictionary<int, string>();
                            int countItem = lstDisplayEnum.Count;
                            for (int i = 0; i < countItem; i++)
                            {
                                DisplayEnum oDisplayEnum = lstDisplayEnum[i];
                                
                                itemEnum.Add(oDisplayEnum.Value, oDisplayEnum.Text);
                                if (!this.itemEnum.ContainsKey(oDisplayEnum.Value))
                                {
                                    this.itemEnum.Add(oDisplayEnum.Value, oDisplayEnum.Text);
                                }
                            }
                        }
                        else
                        {
                            MCommon.SetAssemblyModels();
                            Type t = MCommon.GetEnumType(enumName);
                            if (t != null)
                            {
                                System.Array arrValue = Enum.GetValues(t);
                                System.Array arrName = Enum.GetNames(t);
                                Dictionary<int, string> itemEnum = new Dictionary<int, string>();
                                lstDisplayEnum = new List<DisplayEnum>();
                                for (int i = 0; i < arrValue.Length; i++)
                                {
                                    DisplayEnum objEnum = new DisplayEnum();
                                    objEnum.Value = Convert.ToInt32(arrValue.GetValue(i));
                                    string nameEnum = string.Format("{0}_{1}", enumName, Convert.ToString(arrName.GetValue(i)));
                                    objEnum.Text = MCommon.GetGlobalResources(MCommon.AssemblyEnum, string.Format("{0}.EnumResources", MCommon.AssemblyNameEnum), nameEnum);
                                    
                                    itemEnum.Add(objEnum.Value, objEnum.Text);
                                    this.itemEnum.Add(objEnum.Value, objEnum.Text);
                                    lstDisplayEnum.Add(objEnum);
                                }

                                //Nếu có ENum thì lưu lại
                                if (lstDisplayEnum.Count > 0)
                                {
                                    if (MCommon.ShareEnum == null)
                                    {
                                        MCommon.ShareEnum = new Dictionary<string, List<DisplayEnum>>();
                                    }
                                    MCommon.ShareEnum.Add(this.EnumData, lstDisplayEnum);
                                }
                            }
                        }

                        foreach (var item in this.itemEnum)
                        {
                            col.Add(new DisplayEnum { Value=item.Key,Text=item.Value});
                        }
                        if (!NoDefaultValue)
                        {
                            if (this.defaultValueEnum > -1)
                            {
                                this.SelectedIndex = this.GetSelectedIndex(this.defaultValueEnum);
                            }
                            else
                            {
                                if (this.itemEnum.Count > 0)
                                {
                                    this.SelectedIndex = this.GetSelectedIndex(this.itemEnum.FirstOrDefault(e => true).Key);
                                }
                            }
                        }
                        
                    }

                }
                catch (Exception e)
                {
                    MMessage.ShowError(e.StackTrace);
                }
                finally
                {
                    col.EndUpdate();
                }
            }
            else
            {
                col.Clear();
            }
        }

        public override string EditorTypeName
        {
            get
            {
                return MRepositoryComboBox.MComboBox;
            }
        }

        public new MRepositoryComboBox Properties
        {
            get { return base.Properties as MRepositoryComboBox; }
        }
        #endregion
        #region"Event"

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

        public Ctype Mtype
        {
            get { return Ctype.MComboBox; }
        }

        /// <summary>
        /// Thiết lập giá trị cho control
        /// </summary>
        /// <param name="value">Giá trị cần gán</param>
        /// Create by: dvthang:25.10.2017
        public void SetValue(object value)
        {
            //Nếu là dạng free text
            if (string.IsNullOrEmpty(this.EnumData))
            {
                this.Text = Convert.ToString(value);
            }
            else
            {
                SetSelectedIndex(Convert.ToInt32(value));
            }
        }

        /// <summary>
        /// Lấy giá trị của control
        /// </summary>
        /// <returns>Trả về giá trị của control</returns>
        /// Create by: dvthang:25.10.2017
        public object GetValue()
        {
            object vValue = -1;
            if (string.IsNullOrEmpty(this.EnumData))
            {
                vValue = this.Text;
            }
            else
            {
                if (this.ItemEnum != null)
                {
                    DisplayEnum oDisplayEnum = this.EditValue as DisplayEnum;
                    if (oDisplayEnum != null)
                    {
                        vValue = oDisplayEnum.Value;
                    }
                }

            }
            return vValue;
        }
        #endregion

    }
}
