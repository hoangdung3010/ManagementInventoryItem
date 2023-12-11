using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class ConfigImportMapping
    {
        #region Instance Properties

        public int Id { get; set; }

        public bool IsRequired { get; set; }

        public string Mapping { get; set; }

        public string TableName { get; set; }

        public string FieldName { get; set; }

        public int DataType { get; set; }

        public string Description { get; set; }

        public int Width { get; set; }

        public bool IsLock { get; set; }

        public bool IsLookup { get; set; }

        /// <summary>
        /// Bảng lookup
        /// </summary>
        public string LookupTableName { get; set; }

        /// <summary>
        /// Cột lookup hiển thị
        /// </summary>
        public string LookupColumnName { get; set; }

        /// <summary>
        /// Tên cột mã của bảng lookup
        /// </summary>
        public string LookupColumnCode { get; set; }

        /// <summary>
        /// Giá trị cột là duy nhất dùng để check trùng
        /// </summary>
        public bool IsUnique { get; set; }

        /// <summary>
        /// Không tự động insert danh mục
        /// </summary>
        public bool AutoInsert { get; set; }

        /// <summary>
        /// Sẽ không lưu vào DB
        /// </summary>
        public bool IgnoreDB { get; set; }
        #endregion Instance Properties
    }

}
