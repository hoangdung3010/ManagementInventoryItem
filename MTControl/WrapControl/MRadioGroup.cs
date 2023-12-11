using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MTControl
{
    public class MRadioGroup : DevExpress.XtraEditors.RadioGroup, IControl,IEditControl
        
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
        /// Tự gán value bằng tay nếu =true
        /// </summary>
        private bool isSetValueManual;

        public bool IsSetValueManual
        {
            get { return isSetValueManual; }
            set { isSetValueManual = value; }
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
        #endregion
        #region"Sub/Func"
        #endregion
        #region"Ovrrides"
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.Properties.AutoHeight = false;
            this.Height = MHeight.mscEditControlHeight;
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
            get { return Ctype.MRadioGroup; }
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
    }
}
