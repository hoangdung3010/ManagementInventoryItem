using System;

namespace MT.Library
{
    /// <summary>
    /// Chỉ định foreign key của bảng
    /// </summary>
    /// Create by: dvthang:26.09.2017
    [AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    public class ForeignKeyAttribute : Attribute
    {
        public string TableName { get; set; }

        public string ForeignKeyName { get; set; }

        public ForeignKeyAttribute(string tableName, string foreignKeyName)
        {
            this.TableName = tableName;
            this.ForeignKeyName = foreignKeyName;
        }
    }
}
