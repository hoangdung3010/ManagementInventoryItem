using System;

namespace MT.Library
{
    /// <summary>
    /// Dùng để check trùng
    /// </summary>
    /// Create by: dvthang:15.06.2019
    [System.AttributeUsage(System.AttributeTargets.Property,
                       AllowMultiple = true)]
    public class CodeAttribute : Attribute
    {
        public string Name { get; set; }

        public CodeAttribute()
        {

        }
        public CodeAttribute(string _name)
        {

        }
    }
}
