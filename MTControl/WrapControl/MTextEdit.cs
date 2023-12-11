using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace MTControl
{
    [ToolboxItem(true)]
    public class MTextEdit:DevExpress.XtraEditors.TextEdit,IControl,IEditControl
        
    {
        #region"Declare"
        private string decription;
        private bool selectAllOnFocus = true;
        private bool selectAllDone = false;
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
        /// phải nhập đúng địa chỉ email
        /// </summary>
        private bool isMail;

        [DefaultValue(false)]
        public bool IsMail
        {
            get { return isMail; }
            set { isMail = value; }
        }


        /// <summary>
        /// Độ dài tối đa để nhập
        /// </summary>
        private int maxLength;

        public int MaxLength
        {
            get { return maxLength; }
            set { maxLength = value; }
        }

        private string columnName;

        public string SetField
        {
            get { return columnName; }
            set { columnName = value; }
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
        /// Có cho custom chiều cao của textbox hay không,=true là có,
        /// ngược lại thì không
        /// </summary>
        private bool isCustomHeight;

        public bool IsCustomHeight
        {
            get { return isCustomHeight; }
            set { isCustomHeight = value; }
        }

        /// <summary>
        /// Set reaonly cho control
        /// </summary>
        /// Create by: dvthang:07.10.2017
        public bool IsReadOnly { get; set; }

       public MRepositoryTextEdit RepositoryItem { get; set; }
        public MGridControl Grid { get; set; }

        /// <summary>
        /// Số tự tăng
        /// </summary>
        public bool AutoIncrement { get; set; }
        #endregion
        #region"Contrutor"
        static MTextEdit()
        {
            MRepositoryTextEdit.RegisterMTextEdit();
        }
        #endregion
        #region"Sub/Func"
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
            RepositoryItem = (this.Tag as MRepositoryTextEdit);
            if (RepositoryItem != null)
            {
                this.Margin = new Padding(0);
                this.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                this.Grid = RepositoryItem.GridMaster;
            }
            else
            {
                this.Properties.AutoHeight = false;
                this.Height = MHeight.mscEditControlHeight;
                this.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            }
            SetFont();

            if (IsReadOnly)
            {
                SetReadOnly(IsReadOnly);
            }

            if (AutoIncrement)
            {
                this.Validating += MTextEdit_Validating;
                this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                this.Properties.Appearance.Options.UseTextOptions = true;
                this.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                this.Properties.AppearanceDisabled.Options.UseTextOptions = true;
                this.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                this.Properties.AppearanceFocused.Options.UseTextOptions = true;
                this.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                this.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            }

            this.Properties.BeforeShowMenu -= Properties_BeforeShowMenu;
            this.Properties.BeforeShowMenu += Properties_BeforeShowMenu;

        }

        private void Properties_BeforeShowMenu(object sender, BeforeShowMenuEventArgs e)
        {
            e.Menu.Items.Clear();
        }

        private void MTextEdit_Validating(object sender, CancelEventArgs e)
        {
            if (AutoIncrement && EditValue!=null)
            {
                long d;
                e.Cancel = !long.TryParse(EditValue.ToString(), out d);
                if (!e.Cancel) {
                    if (d < 10)
                    {
                        this.EditValue= d.ToString().PadLeft(2, '0');
                    }
                    else
                    {
                        this.EditValue = d;
                    }
                }
                else
                {
                    this.ErrorText = "Không đúng định dạng số";
                }
                   
            }
        }

        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            if (selectAllOnFocus && this.EditValue!=null)
            {
                this.SelectionStart = 0;
                this.SelectionLength = this.EditValue.ToString().Length;
                this.SelectAll();
                if (RepositoryItem == null)
                {
                    this.Properties.AppearanceFocused.BorderColor = MColor.BorderColorFocusEditor;
                    this.Properties.AppearanceFocused.Options.UseBorderColor = true;
                }
                selectAllDone = true;
            }
        }

        protected override void OnLeave(System.EventArgs e)
        {
            base.OnLeave(e);
            selectAllDone = false;
            if (RepositoryItem == null)
            {
                this.Properties.Appearance.BorderColor = MColor.BorderColorDefaultEditor;
                this.Properties.Appearance.Options.UseBorderColor = true;
            }
               
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (selectAllOnFocus && !selectAllDone && this.SelectionLength == 0)
            {
                selectAllDone = true;
                this.SelectAll();
            }
        }

        

        /// <summary>
        /// Type của control
        /// </summary>
        /// Create by: dvthang:05.03.2017
        public override string EditorTypeName
        {
            get
            {
                return MRepositoryTextEdit.MTextEdit;
            }
        }

        public new MRepositoryTextEdit Properties
        {
            get { return base.Properties as MRepositoryTextEdit; }
        }

        #endregion
        #region"Event"
        /// <summary>
        /// Bắt event nhấn phím enter trên control
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (RepositoryItem != null && RepositoryItem.GridMaster != null)
                    {
                        if(RepositoryItem.CustomEventEnter!=null)
                        {
                            if (!RepositoryItem.CustomEventEnter(RepositoryItem, this))
                            {
                                MCommon.GridControlNextCell(RepositoryItem.GridMaster);
                            }
                        }
                        else
                        {
                            MCommon.GridControlNextCell(RepositoryItem.GridMaster);
                        }
                    }
                    else
                    {
                        SendKeys.Send("{TAB}");
                    }
                    break;
                case Keys.Tab:
                    if (RepositoryItem != null && RepositoryItem.GridMaster != null)
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
        public  void FocusControl()
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
                decription=value;
            }
        }
        public void SetFont()
        {
            this.BackColor = MColor.BackColorEditor;
            this.ForeColor = MColor.ColorLabel;
            this.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);
        }
        public void SendTab()
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
            get
            {
                return Ctype.MTextEdit;
            }
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
            return this.EditValue;
        }
        #endregion
    }
}
