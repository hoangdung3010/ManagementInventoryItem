using MT.Library.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
namespace MT.Library
{
    public class BaseEntity
    {
        private PropertyInfo[] _properties;

        private Type _type;

        private string _tableName;


        public Type EntityType()
        {
            if (_type == null)
            {
                _type = this.GetType();
            }
            return _type;
        }

        [JsonIgnore]
        [IgnoreLog]
        public string TableName
        {
            get
            {
                
                if (string.IsNullOrEmpty(_tableName))
                {
                    var attr = this.EntityType().GetCustomAttributes(typeof(TableNameAttribute), true).FirstOrDefault() as TableNameAttribute;
                    if (attr != null)
                    {
                        _tableName = attr.TableName;
                    }
                    else
                    {
                        _tableName = this.EntityType().Name;
                    }
                }
                return _tableName;
            }
        }

        /// <summary>
        /// Lưu tổng số bản ghi của grid
        /// </summary>
        [JsonIgnore]
        [IgnoreLog]
        public int TotalRecords { get; set; }

        public PropertyInfo[] GetProperties()
        {
            if (_properties == null)
            {
                _properties = this.EntityType().GetProperties();
            }
            return _properties;
        }

        /// <summary>
        /// Trạng thái của object
        /// </summary>
        /// Create by: dvthang:20.04.2017
        [IgnoreLog]
        public Enummation.MTEntityState MTEntityState { get; set; }

        /// <summary>
        /// Ví trị của object trong gridcontrol
        /// </summary>
        /// Create by: dvthang:26.04.2021
        [JsonIgnore]
        [IgnoreLog]
        public int RowHandle { get; set; }

        /// <summary>
        /// Đánh dấu object là temp
        /// </summary>
        /// Create by: dvthang:10.10.2021
        [JsonIgnore]
        [IgnoreLog]
        public bool IsTemp { get; set; } 

        /// <summary>
        ///  Cờ đánh dấu là đã load: Đã load, ngược lại chưa load
        /// </summary>
        /// Create by: dvthang:26.04.2021
        [JsonIgnore]
        [IgnoreLog]
        public bool IsLoaded { get; set; }

        /// <summary>
        /// Id của số tự tăng chứng từ
        /// </summary>
        [JsonIgnore]
        [IgnoreLog]
        public long SequenceVoucherId { get; set; }

        /// <summary>
        /// Gía trị ban đầu của đối tượng
        /// </summary>
        /// Create by: dvthang:20.04.2017
        [JsonIgnore]
        [IgnoreLog]
        public object OldData { get; set; }

        private string _primarykeyName;

        /// <summary>
        /// Tên của khóa chính
        /// </summary>
        /// <returns>Tên khóa</returns>
        /// Create by: dvthang:20.04.2017
        public string GetPrimaryKeyName()
        {
            if (string.IsNullOrEmpty(this._primarykeyName))
            {
                PropertyInfo[] properties = this.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    KeyAttribute keyAttr = property.GetCustomAttribute<KeyAttribute>(true);
                    if (keyAttr != null)
                    {
                        this._primarykeyName = property.Name;
                        return this._primarykeyName;
                    }
                }
            }
            if (string.IsNullOrEmpty(this._primarykeyName))
            {
                this._primarykeyName = "Id";
            }
            return this._primarykeyName;
        }

        /// <summary>
        /// Lấy về giá trị của khóa chính
        /// </summary>
        /// <returns>Giá trị của khóa</returns>
        /// Create by:dvthang:20.04.2017
        public object GetIdentity()
        {
            if (string.IsNullOrEmpty(this._primarykeyName))
            {
                PropertyInfo[] properties = this.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    KeyAttribute keyAttr = property.GetCustomAttribute<KeyAttribute>(true);
                    if (keyAttr != null)
                    {
                        this._primarykeyName = property.Name;
                        return property.GetValue(this);
                    }
                    else
                    {
                        this._primarykeyName = "Id";
                    }
                }
            }
            return this.EntityType().GetProperty(this._primarykeyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(this);
        }

        /// <summary>
        /// Lấy về giá trị của khóa chính
        /// </summary>
        /// <returns>Giá trị của khóa</returns>
        /// Create by:dvthang:20.04.2017
        public void SetIdentity(object value)
        {
            if (string.IsNullOrEmpty(this._primarykeyName))
            {
                PropertyInfo[] properties = this.GetProperties();
                KeyAttribute keyAttr = null;
                PropertyInfo propertyInfoPrimaryKey=null;
                foreach (PropertyInfo property in properties)
                {
                    keyAttr = property.GetCustomAttribute<KeyAttribute>(true);
                    if (keyAttr != null)
                    {
                        this._primarykeyName = property.Name;
                        propertyInfoPrimaryKey = property;
                        break;
                    }
                }

                if (keyAttr == null)
                {
                    this._primarykeyName = "Id";
                }
                this[this._primarykeyName] = value;
            }
            else
            {
                this.EntityType().GetProperty(this._primarykeyName).SetValue(this, value);
            }

        }

        /// <summary>
        /// Kiểm tra giá trị khóa có phải là kiểu tự tăng hay không
        /// </summary>
        /// Create by:dvthang:20.04.2017
        public bool HasIdentity()
        {
            bool isIdentity = false;
            if (string.IsNullOrEmpty(this._primarykeyName))
            {
                PropertyInfo[] properties = this.GetProperties();

                foreach (PropertyInfo pi in properties)
                {
                    KeyAttribute keyAttr = pi.GetCustomAttribute<KeyAttribute>(true);
                    if (keyAttr != null)
                    {
                        this._primarykeyName = pi.Name;
                        if (pi.PropertyType != typeof(Guid))
                        {
                            isIdentity = true;
                        }
                        break;
                    }
                }
            }
            else
            {
                PropertyInfo pi = this.EntityType().GetProperty(this._primarykeyName,  BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (pi.PropertyType != typeof(Guid))
                {
                    isIdentity = true;
                }
            }
            return isIdentity;
        }

        /// <summary>
        /// Kiểm tra thuộc tính có tồn tài không
        /// </summary>
        /// Create by:dvthang:31.03.2021
        public bool ExistsProperty(string propertyName)
        {
            PropertyInfo property = this.EntityType().GetProperty(propertyName,BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gán giá trị cho object
        /// </summary>
        public void SetValue(string propertyName, object value)
        {
            MT.Library.Extensions.ExtensionMethod.SetValue(this, propertyName, value);
        }

        /// <summary>
        /// Đọc giá trị của properties
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public object GetValue(string propertyName)
        {
            return MT.Library.Extensions.ExtensionMethod.GetValue<object>(this, propertyName);
        }

        /// <summary>
        /// Copy object
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        [JsonIgnore]
        [IgnoreLog]
        public bool IsAuditLog { get; set; } = true;
        [IgnoreLog]
        public DateTime? dCreatedDate { get; set; }
        [IgnoreLog]
        public DateTime? dModifiedDate { get; set; }
        [IgnoreLog]
        public string sModifiedBy { get; set; }
        [IgnoreLog]
        public string sCreatedBy { get; set; }
        
        /// <summary>
        /// Danh sách các bảng detail
        /// </summary>
        [JsonIgnore]
        [IgnoreLog]
        public string[] DetailConfig { get; set; }

        /// <summary>
        /// Lấy về thông tin mô tả của đối tượng
        /// </summary>
        /// <returns></returns>
        /// Create by: dvthang:26.09.2017
        public virtual string GetDescriptionSummary()
        {
            string strValue = string.Empty;
            var attrs = GetCodeAttributes();
            if (attrs != null)
            {
                string[] sumary = new string[attrs.Count];
                int i = 0;
                foreach (var item in attrs)
                {
                    sumary[i++] = Convert.ToString(this.GetValue(item.Key));
                }


                return string.Join(" - ", sumary);
            }
            return strValue;
        }

        private Dictionary<string, CodeAttribute> _codeAttrs = null;

        /// <summary>
        /// Lấy về danh code attr
        /// </summary>
        /// <param name="entity">Thông tin đối tượng</param>
        /// Create by: dvthang:15.06.2019
        public Dictionary<string, CodeAttribute> GetCodeAttributes()
        {
            if (_codeAttrs != null && _codeAttrs.Count > 0)
            {
                return _codeAttrs;
            }
            _codeAttrs = new Dictionary<string, CodeAttribute>();
            var props = this.GetProperties();
            foreach (var prop in props)
            {
                CodeAttribute attr = prop.GetCustomAttribute<CodeAttribute>();
                if (attr != null)
                {
                    _codeAttrs.Add(prop.Name, attr);
                }
            }
            return _codeAttrs;
        }


        /// <summary>
        /// Thực hiện ghi log cho đối tượng
        /// </summary>
        /// <returns>Mô tả về log</returns>
        /// Create by: dvthang:26.09.2017
        public virtual string GetDescriptionLog()
        {
            StringBuilder strBuilder = new StringBuilder();
            if (this.OldData != null)
            {
                //Lấy danh sách các thuộc tính của đối tượng được ghi log
                IEnumerable<PropertyInfo> lstInfo = this.GetProperties().Where(m => m.GetCustomAttribute<IgnoreLogAttribute>() == null
                     && m.GetCustomAttribute<KeyAttribute>() == null
                     && m.PropertyType != typeof(Guid) && m.PropertyType != typeof(Guid?));
                if (lstInfo != null)
                {
                    string strNewValue = string.Empty;
                    string strOldValue = string.Empty;
                    object newValue = null;
                    object oldValue = null;
                    string fileName = string.Empty;
                    string tableName = this.GetType().Name;
                    foreach (PropertyInfo info in lstInfo)
                    {
                        try
                        {
                            fileName = info.Name;

                            if (!MT.Library.CommonKey.CreatedDate.Equals(fileName)
                                && !MT.Library.CommonKey.CreatedBy.Equals(fileName)
                                 && !MT.Library.CommonKey.ModifiedBy.Equals(fileName)
                                && !MT.Library.CommonKey.ModifiedDate.Equals(fileName)
                                && !MT.Library.CommonKey.Item.Equals(fileName))
                            {
                                newValue = info.GetValue(this);
                                oldValue = info.GetValue(this.OldData);
                                if (newValue == null)
                                {
                                    newValue = "";
                                }
                                if (oldValue == null)
                                {
                                    oldValue = "";
                                }
                                if (!object.Equals(newValue, oldValue) && !object.ReferenceEquals(newValue, oldValue))
                                {
                                    string strLog = this.WriteLogByProperty(tableName, info, newValue, oldValue);
                                    if (!string.IsNullOrEmpty(strLog))
                                    {
                                        strBuilder.Append(strLog);
                                    }

                                }
                            }
                        }
                        catch 
                        {
                            //todo
                        }
                    }
                }
            }
            return strBuilder.ToString();
        }

        /// <summary>
        /// Custom ghi log cho từng thuộc tính
        /// </summary>
        /// <param name="info">Thông tin của thuộc tính</param>
        /// <param name="newValue">Giá trị mới</param>
        /// <param name="oldValue">Giá trị cũ</param>
        /// <returns></returns>
        /// Trả về log của từng thuộc tính
        public virtual string WriteLogByProperty(string tableName, PropertyInfo info,
            object newValue, object oldValue
           )
        {
            string strNewValue = GetFormatValue(info, newValue);
            string strOldValue = GetFormatValue(info, oldValue);
            string key = string.Format("{0}_{1}", tableName, info.Name);
            string textResource = string.Empty;
            SessionData.Resources.TryGetValue(key.ToLower(), out textResource);
            if(string.IsNullOrEmpty(textResource) && info.Name.LastIndexOf("_Ten")>-1)
            {
                key = string.Format("{0}_{1}", tableName, info.Name.Substring(0, info.Name.LastIndexOf("_Ten")));
                SessionData.Resources.TryGetValue(key.ToLower(), out textResource);
            }
            if (!string.IsNullOrEmpty(textResource))
            {
                return string.Format("Thông tin <{0}> bị sửa từ ({1}) thành ({2}); ", textResource, strOldValue, strNewValue);
            }
            return string.Empty;
        }
        /// <summary>
        /// Lấy giá trị của control sau khi đã format
        /// </summary>
        /// <param name="info">Thông tin thuộc tính </param>
        /// <param name="value">Giá trị của thuộc tính</param>
        /// <returns>Trả về giá trị đã được format</returns>
        private string GetFormatValue(PropertyInfo info, object value)
        {
            string strValue = string.Empty;
            Type type = info.PropertyType;
            if (type == typeof(decimal)
                || type == typeof(decimal?)
                || type == typeof(Decimal)
                || type == typeof(Decimal?))
            {
                if (value != null)
                {
                    strValue = value.ToString();
                }
            }
            else if (type == typeof(double)
               || type == typeof(double?)
               || type == typeof(Double)
               || type == typeof(Double?))
            {
                if (value != null)
                {
                    strValue = value.ToString();
                }
            }
            else if (type == typeof(int)
              || type == typeof(int?)
              || type == typeof(Int32)
              || type == typeof(Int32?))
            {
                strValue = GetValueInterger(info, value);
            }
            else if (type == typeof(Int64)
             || type == typeof(Int64?)
             || type == typeof(Int16)
             || type == typeof(Int16?))
            {
                strValue = GetValueInterger(info, value);
            }
            else if (type == typeof(byte)
            || type == typeof(byte?)
            || type == typeof(Byte)
            || type == typeof(Byte?))
            {
                strValue = GetValueInterger(info, value);
            }
            else if (type == typeof(bool)
            || type == typeof(bool?)
            || type == typeof(Boolean)
            || type == typeof(Boolean?))
            {
                strValue = GetValueBool(info, value);
            }
            else if (type == typeof(DateTime)
                || type == typeof(DateTime?))
            {
                if (value != null)
                {
                    strValue = Convert.ToDateTime(value).ToString("dd/MM/yyyy");
                }
            }
            else if (type == typeof(string)
               || type == typeof(String))
            {
                strValue = value.ToString();
            }
            return strValue;
        }

        /// <summary>
        /// Lấy về log của giá trị kiểu số nguyên
        /// </summary>
        /// <returns>Trả về giá trị đã format kiểu số nguyên</returns>
        /// Create by: dvthang:26.09.2017
        private string GetValueInterger(PropertyInfo info, object value)
        {
            string strValue = string.Empty;
            if (value != null)
            {
                var attribute = Attribute.GetCustomAttribute(info, typeof(EnumLogAttribute));
                EnumLogAttribute enumLog = attribute as EnumLogAttribute;
                if (enumLog != null)
                {
                    string fieldName = enumLog.FieldName;
                    string strKeyText = string.Format("{0}_{1}", fieldName, value);
                    MT.Library.SessionData.Resources.TryGetValue(strKeyText.ToLower(),out strValue);
                }
                else
                {
                    strValue = value.ToString();
                }
            }
            return strValue;
        }

        /// <summary>
        /// Lấy về log của giá trị kiểu số nguyên
        /// </summary>
        /// <returns>Trả về giá trị đã format kiểu số nguyên</returns>
        /// Create by: dvthang:26.09.2017
        private string GetValueBool(PropertyInfo info, object value)
        {
            string strValue = string.Empty;
            if (value != null && !"".Equals(value))
            {
                var attribute = Attribute.GetCustomAttribute(info, typeof(AliasDisplayLogAttribute));
                AliasDisplayLogAttribute aliasLog = attribute as AliasDisplayLogAttribute;
                bool bValue = Convert.ToBoolean(value);
                if (aliasLog != null)
                {
                    if (bValue)
                    {
                        strValue = aliasLog.YesAlias;
                    }
                    else
                    {
                        strValue = aliasLog.NoAlias;
                    }
                }
                else
                {
                    if (bValue)
                    {
                        strValue = "Có";
                    }
                    else
                    {
                        strValue = "Không";
                    }
                }
            }
            return strValue;
        }

        /// <summary>
        /// Lấy về khóa ngoại của bảng khi biết tên bảng
        /// </summary>
        /// <param name="tableName">Tên bảng có khóa ngoại</param>
        /// <returns>Giá trị của khóa</returns>
        /// Create by:dvthang:20.04.2017
        public ForeignKeyAttribute GetForeignKey(string tableName)
        {
            ForeignKeyAttribute keyAttr = this.GetType().GetCustomAttributes<ForeignKeyAttribute>()
                    .FirstOrDefault(m => tableName.Equals(m.TableName, StringComparison.OrdinalIgnoreCase));
            if (keyAttr != null)
            {
                return keyAttr;
            }
            return null;
        }
        /// <summary>
        /// Sử dụng store để lưu
        /// </summary>
        [IgnoreLog]
        public bool UsedProc { get; set; }

        /// <summary>
        /// Tên thủ tục Insert
        /// </summary>
        [IgnoreLog]
        public string ProcInsertName { get; set; }

        /// <summary>
        /// Tên thủ tục update
        /// </summary>
        [IgnoreLog]
        public string ProcUpdateName { get; set; }

        /// <summary>
        /// Tên thủ tục xóa
        /// </summary>
        [IgnoreLog]
        public string ProcDeleteName { get; set; }

        // Indexer declaration
        public object this[string propertyName]
        {
            get
            {
                return MT.Library.Extensions.ExtensionMethod.GetValue<object>(this, propertyName);
            }
            set
            {
                MT.Library.Extensions.ExtensionMethod.SetValue(this, propertyName, value);
            }
        }

        /// <summary>
        /// Lỗi khi nhập khẩu
        /// </summary>
        [IgnoreLog]
        public string ImportError { get; set; }

        /// <summary>
        /// Bản ghi hợp lệ
        /// </summary>
        [IgnoreLog]
        public bool ImportValid { get; set; }

        [IgnoreLog]
        public IList TepDinhKems { get; set; }

    }
}
