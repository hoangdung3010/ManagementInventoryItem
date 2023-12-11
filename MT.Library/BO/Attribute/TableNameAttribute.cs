using System;

namespace MT.Library
{
    /// <summary>
    /// Thuộc tính chỉ định tên table của entity
    /// </summary>
    /// Create by: dvthang:26.09.2017
    [AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    public class TableNameAttribute : Attribute
    {
        public string TableName { get; set; }

        public TableNameAttribute()
        {

        }
        public TableNameAttribute(string _tableName)
        {
            this.TableName = _tableName;
        }
    }
}
