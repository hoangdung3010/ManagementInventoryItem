using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Mask;
using System.Globalization;
using System.Threading;
using DevExpress.XtraEditors.Controls;

namespace MTControl
{
    [ToolboxItem(true)]
    public class MSpinEdit : DevExpress.XtraEditors.SpinEdit, IControl,IEditControl
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

        public decimal MaxValue
        {
            get { return 9999999999999999; }
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

        private FormatType dataType;

        public FormatType DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }

        /// <summary>
        /// Set reaonly cho control
        /// </summary>
        /// Create by: dvthang:07.10.2017
        public  bool IsReadOnly { get; set; }

        /// <summary>
        /// Hiển thị số chữ số sau phần thập phần
        /// </summary>
        public byte DecimalCount { get; set; }
        string decimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;

        MRepositorySpinEdit RepositoryItem { get; set; }
        public MGridControl Grid { get; set; }
        #endregion
        #region"Contructor"
        static MSpinEdit()
        {
            MRepositorySpinEdit.RegisterMSpinEdit();
        }
        public MSpinEdit()
        {
            this.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            SetFont();
        }
        #endregion
        #region"Sub/Func"
        /// <summary>
        /// Thiết chế độ readonly cho control
        /// </summary>
        /// <param name="bEnable">=true thid không cho sửa,ngược lại thì được sửa</param>
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
            RepositoryItem = (this.Tag as MRepositorySpinEdit);
            if (RepositoryItem != null)
            {
                //todo
                this.Grid = RepositoryItem.GridMaster;
                this.Properties.BeforeShowMenu -= Properties_BeforeShowMenu;
                this.Properties.BeforeShowMenu += Properties_BeforeShowMenu;
            }
            else
            {
                this.Properties.AutoHeight = false;
                this.Height = MHeight.mscEditControlHeight;
            }

            if (IsReadOnly)
            {
                SetReadOnly(IsReadOnly);
            }
            this.FormatValue();
        }

        private void Properties_BeforeShowMenu(object sender, BeforeShowMenuEventArgs e)
        {
            e.Menu.Items.Clear();
        }


        /// <summary>
        /// Thực hiện nhảy Tab khi nhấn Enter
        /// </summary>
        /// <param name="e"></param>
        /// CreatebBy-laipv.19.08.2017
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar.Equals('.') || e.KeyChar.Equals(','))
            {
                e.KeyChar = ((System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentCulture).NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
            }
        }
        public override string EditorTypeName
        {
            get
            {
                return MRepositorySpinEdit.MSpinEdit;
            }
        }

        public new MRepositorySpinEdit Properties
        {
            get { return base.Properties as MRepositorySpinEdit; }
        }

        /// <summary>
        /// Format gía trị hiển thị trên cotrol
        /// </summary>
        private void FormatValue()
        {
            bool isDesignMode = DesignMode || IsDesignMode || (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            if (!isDesignMode)
            {
                if (this.DataType == FormatType.None)
                {
                    if (!string.IsNullOrEmpty(SetField))
                    {
                        if (SetField.StartsWith("iSL", StringComparison.OrdinalIgnoreCase))
                        {
                            this.DataType = FormatType.QuanlityInt;
                        }
                        else if (SetField.StartsWith("rSL", StringComparison.OrdinalIgnoreCase))
                        {
                            this.DataType = FormatType.QuanlityFloat;
                        }
                        else if (SetField.StartsWith("rDG", StringComparison.OrdinalIgnoreCase))
                        {
                            this.DataType = FormatType.UnitPrice;
                        }
                        else if (SetField.StartsWith("rTT", StringComparison.OrdinalIgnoreCase))
                        {
                            this.dataType = FormatType.Amount;
                        }
                        else if (SetField.StartsWith("rTL", StringComparison.OrdinalIgnoreCase) || SetField.StartsWith("rDM", StringComparison.OrdinalIgnoreCase))
                        {
                            this.DataType = FormatType.Coefficient;
                        }
                    }
                }
                CultureInfo oCultureInfo = MCommon.GetCurrentCultureInfo();
                string sFormatString = MCommon.GetFormatStringCustom(this.dataType,DecimalCount);
                this.Properties.Buttons.Clear();
                this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                this.Properties.DisplayFormat.Format = oCultureInfo;

                this.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                this.Properties.Mask.MaskType = MaskType.Numeric;

                this.Properties.DisplayFormat.FormatString = sFormatString;
                this.Properties.EditFormat.FormatString = sFormatString;
                this.Properties.EditMask = sFormatString;
                this.Properties.Mask.ShowPlaceHolders = false;
                this.Properties.Mask.UseMaskAsDisplayFormat = true;

                this.Properties.IsFloatValue = true;
            }
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
            get
            {
                return Ctype.MSpinEdit;
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
