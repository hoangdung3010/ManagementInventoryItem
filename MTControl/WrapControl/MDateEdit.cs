using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MTControl
{
    public class MDateEdit : DevExpress.XtraEditors.DateEdit, IControl,IEditControl
        
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
        /// Tự gán value bằng tay nếu =true
        /// </summary>
        private bool isSetValueManual;

        public bool IsSetValueManual
        {
            get { return isSetValueManual; }
            set { isSetValueManual = value; }
        }
         /// <summary>
        /// Set reaonly cho control
        /// </summary>
        /// Create by: dvthang:07.10.2017
        public bool IsReadOnly { get; set; }
        public MRepositoryDateEdit RepositoryItem { get; set; }
        public MGridControl Grid { get; set; }

       
        #endregion
        #region"Contrutor"
        static MDateEdit()
        {
            MRepositoryDateEdit.RegisterMDateEdit();
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
            RepositoryItem = (this.Tag as MRepositoryDateEdit);
            if (RepositoryItem != null)
            {
                //todo
                this.Grid = RepositoryItem.GridMaster;
                this.Properties.AutoHeight = true;
                this.Properties.BeforeShowMenu -= Properties_BeforeShowMenu;
                this.Properties.BeforeShowMenu += Properties_BeforeShowMenu;
                this.Margin = new Padding(0);
            }
            else
            {
                this.Properties.AutoHeight = false;
                this.Height = MHeight.mscEditControlHeight;
            }
            if (RepositoryItem != null && !this.Grid.IsEditable)
            {
                this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            }
            else
            {
                this.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            }
           
            SetFont();

            if (IsReadOnly)
            {
                SetReadOnly(IsReadOnly);
            }
            this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        private void Properties_BeforeShowMenu(object sender, DevExpress.XtraEditors.Controls.BeforeShowMenuEventArgs e)
        {
            e.Menu.Items.Clear();
        }

        public override string EditorTypeName
        {
            get
            {
                return MRepositoryDateEdit.MDateEdit;
            }
        }

        public new MRepositoryDateEdit Properties
        {
            get { return base.Properties as MRepositoryDateEdit; }
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

        /// <summary>
        /// Bắt event nhấn phím enter trên control
        /// </summary>
        /// <param name="e"></param>
        /// Create by: dvthang:24.09.2017
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
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

     
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (!this.ReadOnly && !string.IsNullOrEmpty(this.Text))
            {
                this.SelectAll();
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
            get { return Ctype.MDateEdit; }
        }

        /// <summary>
        /// Thiết lập giá trị cho control
        /// </summary>
        /// <param name="value">Giá trị cần gán</param>
        /// Create by: dvthang:25.10.2017
        public void SetValue(object value)
        {
            this.EditValue = value;
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
