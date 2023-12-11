using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MT.Library.Enummation;
using DevExpress.XtraEditors.Controls;
using MT.Data.Rep;

namespace FormUI
{
    public partial class ucDateRange : UserControl
    {
        List<MT.Data.ViewModels.SelectedItem> _fieldNames = null;
        DateTime? _fromDate;

        DateTime? _toDate;

        int _periodValue;


        EventHandler _period_Changed;

        EventHandler _fieldName_Changed;

        bool _isSetDefault = false;

        public EventHandler Period_Changed
        {
            get
            {
                return _period_Changed;
            }
            set
            {
                _period_Changed = value;
            }
        }

        public EventHandler FieldName_Changed
        {
            get
            {
                return _fieldName_Changed;
            }
            set
            {
                _fieldName_Changed = value;
            }
        }

        public List<MT.Data.ViewModels.SelectedItem> FieldNames
        {
            get
            {
                return _fieldNames;
            }
            set
            {
                _fieldNames = value;
            }
        }

        public DateTime? FromDate
        {
            get
            {
                if (dteFrom.EditValue == null)
                {
                    _fromDate= null;
                    return _fromDate;
                }
                _fromDate = Convert.ToDateTime(dteFrom.EditValue);
                return _fromDate;
            }
        }
        public DateTime? ToDate
        {
            get
            {
                if (dteTo.EditValue == null)
                {
                    _toDate = null;
                    return _fromDate;
                }
                _toDate = Convert.ToDateTime(dteTo.EditValue);
                return _toDate;
            }
        }

        public int PeriodValue
        {
            get
            {
                return _periodValue;
            }
        }

        public ucDateRange()
        {
            InitializeComponent();
            cboPeriod.Properties.DisplayMember = "Text";
            cboPeriod.Properties.ValueMember = "Id";
            var columnCode = cboPeriod.Properties.Columns.Add(new LookUpColumnInfo("Text", "Thời gian"));
            Type enumType = typeof(MT.Library.Enummation.Period);
            var names = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType);
            List<MT.Data.ViewModels.SelectedItem> items = new List<MT.Data.ViewModels.SelectedItem>();
            for (int i = 0; i < names.Length; i++)
            {
                int val = (int)values.GetValue(i);
                var memInfo = enumType.GetMember(enumType.GetEnumName(val));
                var descriptionAttribute = memInfo[0]
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute;
                string text = string.Empty;
                if (descriptionAttribute != null)
                {
                    text = descriptionAttribute.Description;
                }
                items.Add(new MT.Data.ViewModels.SelectedItem { Id = val, Text = text });
            }
            cboPeriod.Properties.DataSource = items;
        }

        /// <summary>
        /// Gán giá trị default cho kỳ báo cáo
        /// </summary>
        /// <param name="period"></param>
        public void SetDefaultValue(MT.Library.Enummation.Period period)
        {
            cboPeriod.EditValue = (int)period;
            _periodValue = (int)period;

            _isSetDefault = true;
        }

        private void cboPeriod_EditValueChanged(object sender, EventArgs e)
        {
            DateTime currentDate = SysDateTime.Instance.Now();
            int value = int.Parse(cboPeriod.EditValue.ToString());
            _periodValue = value;
            dteFrom.Enabled = true;
            dteTo.Enabled = true;
            //chkTime.Checked = false;
            var tuple=MT.Library.Utility.GetDateRangeByPeriod(value);
            _fromDate = tuple.Item1;
            _toDate = tuple.Item2;
            if (_fromDate.HasValue)
            {
                dteFrom.EditValue = _fromDate.Value;
            }
            else
            {
                dteFrom.EditValue = null;
            }
            if (_toDate.HasValue)
            {
                dteTo.EditValue = _toDate.Value;
            }
            else
            {
                dteTo.EditValue = null;
            }

            if (_period_Changed != null)
            {
                _period_Changed(sender, e);
            }
        }

        
        private void dteFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (dteFrom.EditValue != null)
            {
                _fromDate = Convert.ToDateTime(dteFrom.EditValue);
                _fromDate = new DateTime(_fromDate.Value.Year, _fromDate.Value.Month, _fromDate.Value.Day, 0, 0, 0, 0);
            }
            else
            {
                _fromDate = null;
            }
        }

        private void dteTo_EditValueChanged(object sender, EventArgs e)
        {

            if (dteTo.EditValue != null)
            {
                _toDate = Convert.ToDateTime(dteTo.EditValue);
                _toDate = new DateTime(_toDate.Value.Year, _toDate.Value.Month, _toDate.Value.Day, 23, 59, 59, 999);
            }
            else
            {
                _toDate = null;
            }
        }

        private void ucDateRange_Load(object sender, EventArgs e)
        {
            cboPeriod.IsHideClearValue = true;
            SetDefaultValue(Period.NamNay);
        }

        /// <summary>
        /// Thiết lập setfield cho các control trên from
        /// </summary>
        /// <param name="setFieldFromDate"></param>
        /// <param name="setFieldToDate"></param>
        /// <param name="setFieldPeriod"></param>
        public void SetField(string setFieldFromDate,string setFieldToDate,string setFieldPeriod)
        {
            dteFrom.SetField = setFieldFromDate;
            dteTo.SetField = setFieldToDate;
            cboPeriod.SetField = setFieldPeriod;
        }

        /// <summary>
        /// Event thay đổi option search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTime_CheckedChanged(object sender, EventArgs e)
        {
            //ResizeUc(chkTime.Checked);
        }

        /// <summary>
        /// Thay đổi kích thước form
        /// </summary>
        /// <param name="timeChecked">=true: Check hiển thị giờ</param>
        public void ResizeUc(bool timeChecked)
        {
            if (timeChecked)
            {
                dteFrom.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
                dteFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
                dteFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
                dteFrom.Properties.EditMask = "dd/MM/yyyy HH:mm:ss";
                dteFrom.Width = 130;
                dteTo.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
                dteTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
                dteTo.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
                dteTo.Width = 130;
                dteTo.Properties.EditMask = "dd/MM/yyyy HH:mm:ss";
               
            }
            else
            {
                dteFrom.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
                dteFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
                dteFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
                dteFrom.Properties.EditMask = "dd/MM/yyyy";
                dteFrom.Width = 81;
                dteTo.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
                dteTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
                dteTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
                dteTo.Properties.EditMask = "dd/MM/yyyy";
                dteTo.Width = 81;
               
            }
            dteFrom.Update();
            dteTo.Update();
            this.Update();
        }

    }
}
