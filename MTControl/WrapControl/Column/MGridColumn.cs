using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System.ComponentModel;
using System.Drawing;

namespace MTControl
{
    public class MGridColumn : DevExpress.XtraGrid.Columns.GridColumn
        
    {
        #region"Declare"
        public bool IsRequired { get; set; }

        public int MaxLength { get; set; }

        public string RepName { get; set; }

        public string EnumName { get; set; }

        /// <summary>
        /// Config bộ lọc filter row
        /// </summary>
        public ConfigFilterEditor FilterEditor { get; set; }

        #endregion
        #region"Sub/Func"
        /// <summary>
        /// Lấy về đối tượng filter
        /// </summary>
        /// <returns></returns>
        public IAutoFilterParseResult<GridColumn> GetParsedAutoFilter()
        {
            return this.ParsedAutoFilter;
        }

        #endregion
        #region"Ovrrides"
        protected override OptionsColumnFilter CreateOptionsFilter()
        {
            return base.CreateOptionsFilter();
        }
        #endregion
        #region"Implement"
        #endregion
    }

    /// <summary>
    /// Thông tin cấu hình bộ lọc filter
    /// </summary>
    public class ConfigFilterEditor
    {
        public DataTypeColumn DataType { get; set; }

        /// <summary>
        /// Tên cột hiển thị khi filter là đang LookUpEdit hoặc GridLookUp hoặc TreeLookupEdit
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        /// Tên bảng dữ liệu(LookUpEdit hoặc GridLookUp hoặc TreeLookupEdit)
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// DataSource nếu có sẵn(LookUpEdit hoặc GridLookUp hoặc TreeLookupEdit)
        /// </summary>
        public object DataSource { get; set; }

        /// <summary>
        /// Thứ tự sắp xếp trên danh sách
        /// </summary>
        public string OrderBy { get; set; }
    }
}
