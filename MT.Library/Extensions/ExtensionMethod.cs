using MT.Library.BO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MT.Library.Extensions
{
    public static class ExtensionMethod
    {
        /// <summary>
        /// Lấy giá trị của control
        /// </summary>
        /// <typeparam name="T">Kiểu giá trị trả về</typeparam>
        /// <param name="oEntity">Entity</param>
        /// <param name="fieldName">Tên cột</param>
        /// <returns>Giá trị của thuộc tính</returns>
        /// Create by: dvthang:21.10.2017
        public static T GetValue<T>(this object oEntity, string fieldName)
        {
            T t = default(T);

            PropertyInfo info = oEntity.GetType().GetProperty(fieldName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (info != null)
            {
                object oValue = info.GetValue(oEntity,null);
                if (oValue != null)
                {
                    t = oValue.ChangeType<T>();
                }
            }
            return t;
        }

        /// <summary>
        /// Gán giá trị cho object
        /// </summary>
        /// Create by: dvthang:21.10.2017
        public static void SetValue(this object entity, string fieldName, object value)
        {
            PropertyInfo info = entity.GetType().GetProperty(fieldName, BindingFlags.SetProperty
                | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (info != null && info.CanWrite)
            {
                info.SetValue(entity, value.ChangeType(info.PropertyType), null);
            }
        }

        /// <summary>
        /// Copy tất cả property của object sang object khác
        /// </summary>
        /// Create by: dvthang:21.10.2017
        public static void CopyObject(this object originEntity,object newEntity)
        {
            var pInfos = originEntity.GetType().GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).Where(p => p.GetIndexParameters().Length == 0);
            foreach (var p in pInfos)
            {
                originEntity.SetValue(p.Name, newEntity.GetValue<object>(p.Name));
            }
        }

        /// <summary>
        /// Lấy về kiểu dữ liệu của thuộc tính
        /// </summary>
        /// <param name="entity">Tên đối tượng</param>
        /// <param name="propertyName"></param>
        /// <returns>Create by: dvthang:06.03.2017</returns>
        public static Type GetPropertyType<T>(this T entity, string propertyName)
        {
            PropertyInfo pInfo = entity.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (pInfo != null)
            {
                Type type = pInfo.PropertyType;
                return type;
            }
            return null;
        }

        /// <summary>
        /// CHuyển kiểu dữ liệu cho object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns>Trả về giá trị</returns>
        /// Create by: dvthang:23.10.2017
        public static T ChangeType<T>(this object value)
        {
            return (T)ChangeType(value, typeof(T));
        }

        /// <summary>
        /// CHuyển kiểu dữ liệu cho object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns>Trả về giá trị</returns>
        /// Create by: dvthang:23.10.2017
        public static object ChangeType(this object value, Type conversion)
        {
            Type type = Nullable.GetUnderlyingType(conversion) ?? conversion;
            try
            {
                if (value == null && type.IsGenericType)
                {
                    return Activator.CreateInstance(type);
                }
                if (value == null || string.IsNullOrEmpty(value.ToString()))
                {
                    return null;
                }
                if (type == value.GetType())
                {
                    return value;
                }
                if (type.IsEnum)
                {
                    if (value is string)
                    {
                        return Enum.Parse(type, value as string);
                    }
                    else
                    {
                        return Enum.ToObject(type, value);
                    }
                }
                if (type.IsInterface && type.IsGenericType)
                {
                    Type innerType = type.GetGenericArguments()[0];
                    object innerValue = ChangeType(value, innerType);
                    return Activator.CreateInstance(conversion, new object[] { innerType });
                }
                if (value is string && conversion == typeof(Guid))
                {
                    Guid vVal;
                    Guid.TryParse(value.ToString(), out vVal);
                    return vVal;
                }
                if (type == typeof(bool))
                {
                    bool boolValue;
                    if (bool.TryParse(value.ToString(), out boolValue))
                    {
                        return boolValue;
                    }
                    else
                    {
                        int intValue;
                        if (int.TryParse(value.ToString(), out intValue))
                        {
                            return System.Convert.ChangeType(intValue, type);
                        }
                    }
                }
                if (!(value is IConvertible))
                {
                    return value;
                }

                return Convert.ChangeType(value, type);
            }
            catch (FormatException ex)
            {
                return type.GetDefaultValue();
            }
        }

        /// <summary>
        /// Xử lý lỗi SQL Injection
        /// </summary>
        /// <param name="value">Chuỗi cần xử lý</param>
        /// <returns>Trả về chuỗi sau khi đã xử lý</returns>
        /// Create by: dvthang:05.11.2017
        public static string ProcessSQLInjetion(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                string[] sqlCheckList = {
                    "--",";--",";","/*","*/","@@","@","char","nchar","varchar","nvarchar",
                    "alter","begin","cast","create","cursor","declare","delete","drop",
                    "end","exec","execute", "fetch","insert","kill","select","sys","sysobjects",
                    "syscolumns","table","update"};

                value = value.Replace("'", "''");
                value = value.Replace("%", "[%]");
                value = value.Replace("[", "[[]");
                value = value.Replace("_", "[_]");

                for (int i = 0; i <= sqlCheckList.Length - 1; i++)
                {
                    if ((value.IndexOf(sqlCheckList[i], StringComparison.OrdinalIgnoreCase) >= 0))
                    {
                        value = value.Replace(sqlCheckList[i], "");
                    }
                }
            }
            return value;
        }

        
        /// <summary>
        /// Thực hiện nén chuỗi string
        /// </summary>
        /// <param name="text">CHuỗi cần nén</param>
        /// Trả về nội dung chuỗi sau khi nén
        public static string CompressString(this string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            MemoryStream ms = new MemoryStream();
            using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
            {
                zip.Write(buffer, 0, buffer.Length);
            }

            ms.Position = 0;
            MemoryStream outStream = new MemoryStream();

            byte[] compressed = new byte[ms.Length];
            ms.Read(compressed, 0, compressed.Length);

            byte[] gzBuffer = new byte[compressed.Length + 4];
            System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
            System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
            return Convert.ToBase64String(gzBuffer);
        }

        /// <summary>
        /// Thực hiện giải nén chuỗi
        /// </summary>
        /// <param name="data">CHuỗi cần giải nén</param>
        /// TRả về danh sách dữ liệu trước khi nén
        public static string DecompressString(this string data)
        {
            byte[] compressed = Convert.FromBase64String(data);
            using (var compressedStream = new MemoryStream(compressed))
            {
                byte[] lengthBytes = new byte[4];
                compressedStream.Read(lengthBytes, 0, 4);

                var length = BitConverter.ToInt32(lengthBytes, 0);
                using (var decompressionStream = new GZipStream(compressedStream,
                    CompressionMode.Decompress))
                {
                    var result = new byte[length];
                    decompressionStream.Read(result, 0, length);
                    return Encoding.UTF8.GetString(result);
                }
            }
        }

        /// <summary>
        /// Chuyển dữ liệu từ datatable về List<Dictionary<string, object>>
        /// </summary>
        /// <param name="dt">Data table</param>
        /// <returns>Create by: dvthang:27.11.2016</returns>
        public static List<Dictionary<string, object>> ToListDic(this DataTable dt)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
            }
            return rows;
        }

        /// <summary>
        /// Chuyển dữ liệu từ datatable về List<Dictionary<string, object>>
        /// </summary>
        /// <param name="dt">Data table</param>
        /// <returns>Create by: dvthang:27.11.2016</returns>
        public static List<Dictionary<string, object>> ToListDic(this IDataReader dataReader)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            if (dataReader != null)
            {
                int countColumn = dataReader.FieldCount;
                while (dataReader.Read())
                {
                    row = new Dictionary<string, object>();
                    for (int i = 0; i < countColumn; i++)
                    {
                        row.Add(dataReader.GetName(i), dataReader.GetValue(i));
                    }
                    rows.Add(row);
                }
            }
            return rows;
        }

        /// <summary>
        /// Trả về kiểu object từ dữ liệu datareader
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="_dr">datareader</param>
        /// <returns>Create by: dvthang:27.11.2016</returns>
        public static T ToObject<T>(this IDataReader _dr)
        {
            T objTarget = default(T);
            if (_dr == null) return objTarget;
            return _dr.ToListObject<T>().FirstOrDefault();
        }

        /// <summary>
        /// Trả về list object từ DataReader
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="_dr">DataReader</param>
        /// <returns>Create by:dvthang:27.11.2016</returns>
        public static List<T> ToListObject<T>(this IDataReader _dr) 
        {
            List<T> _list = new List<T>();
            if (_dr == null) return _list;

            Type rs = typeof(T);

            bool isClass = !rs.IsValueType && !rs.Name.Equals("String");


            int countColumn = _dr.FieldCount;

            
            if (isClass)
            {
                Dictionary<string, PropertyInfo> dicDicPropertyInfo = null;
                while (_dr.Read())
                {
                    T objTarget = Activator.CreateInstance<T>();

                    if (dicDicPropertyInfo == null)
                    {
                        dicDicPropertyInfo = GetDicPropertyInfo<T>(_dr, objTarget, countColumn);
                    }
                    foreach (var pair in dicDicPropertyInfo)
                    {
                        string columnName = pair.Key;
                        PropertyInfo property = pair.Value;
                        if (!object.Equals(_dr[columnName], DBNull.Value))
                        {
                            property.SetValue(objTarget, _dr[columnName].ChangeType(property.PropertyType), null);
                        }
                        else
                        {
                            property.SetValue(objTarget, null);
                        }
                    }
                    _list.Add(objTarget);
                }
            }
            else
            {
                while (_dr.Read())
                {
                    if (!_dr.IsDBNull(0))
                    {
                        object vVal = _dr.GetValue(0);
                        _list.Add((T)vVal.ChangeType(rs));
                    }
                }
             }
            return _list;
        }

        
        /// <summary>
        /// Lấy về thông tin reflector của đối tượng
        /// </summary>
        /// <typeparam name="T">Thông tin đối tượng</typeparam>
        /// <param name="_dr">Thông tin reader</param>
        /// Created by: dvthang: 15.03.2020
        private static Dictionary<string, PropertyInfo> GetDicPropertyInfo<T>(this IDataReader _dr, T objTarget, int countColumn)
        {
            Dictionary<string, PropertyInfo> dicDicPropertyInfo = new Dictionary<string, PropertyInfo>();
            for (int i = 0; i < countColumn; i++)
            {
                string nameColumn = _dr.GetName(i);
                PropertyInfo property = objTarget.GetType().GetProperty(nameColumn, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property != null && !dicDicPropertyInfo.ContainsKey(nameColumn))
                {
                    dicDicPropertyInfo.Add(nameColumn, property);
                }
            }
            return dicDicPropertyInfo;
        }

        /// <summary>
        /// Lấy về thông tin reflector của đối tượng
        /// </summary>
        /// <typeparam name="T">Thông tin đối tượng</typeparam>
        /// <param name="_dr">Thông tin reader</param>
        /// Created by: dvthang: 15.03.2020
        private static Dictionary<string, PropertyInfo> GetDicPropertyInfo(this IDataReader _dr, Type type, int countColumn)
        {
            Dictionary<string, PropertyInfo> dicDicPropertyInfo = new Dictionary<string, PropertyInfo>();
            for (int i = 0; i < countColumn; i++)
            {
                string nameColumn = _dr.GetName(i);
                PropertyInfo property = type.GetProperty(nameColumn, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property != null && !dicDicPropertyInfo.ContainsKey(nameColumn))
                {
                    dicDicPropertyInfo.Add(nameColumn, property);
                }
            }
            return dicDicPropertyInfo;
        }

        /// <summary>
        /// Lấy về thông tin reflector của đối tượng
        /// </summary>
        /// <typeparam name="T">Thông tin đối tượng</typeparam>
        /// <param name="_table">Thông tin table</param>
        /// Created by: dvthang: 15.03.2020
        private static Dictionary<string, PropertyInfo> GetDicPropertyInfo<T>(this DataTable _table, T objTarget)
        {
            Dictionary<string, PropertyInfo> dicDicPropertyInfo = new Dictionary<string, PropertyInfo>();
            foreach (DataColumn col in _table.Columns)
            {
                string nameColumn = col.ColumnName;
                PropertyInfo property = objTarget.GetType().GetProperty(nameColumn, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property != null && !dicDicPropertyInfo.ContainsKey(nameColumn))
                {
                    dicDicPropertyInfo.Add(nameColumn, property);
                }
            }
            return dicDicPropertyInfo;
        }

        /// <summary>
        /// Trả về list object từ DataTable
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="_dr">DataTable</param>
        /// <returns>Create by:dvthang:27.11.2016</returns>
        public static List<T> ToListObject<T>(this DataTable _table)
        {
            List<T> _list = new List<T>();
            if (_table == null) return _list;
            DataColumnCollection dataCol = _table.Columns;

            Dictionary<string, PropertyInfo> dicDicPropertyInfo = null;

            foreach (DataRow dr in _table.Rows)
            {
                T objTarget = Activator.CreateInstance<T>();
                if (dicDicPropertyInfo == null)
                {
                    dicDicPropertyInfo = GetDicPropertyInfo<T>(_table, objTarget);
                }
                foreach (var pair in dicDicPropertyInfo)
                {
                    string columnName = pair.Key;
                    PropertyInfo property = pair.Value;
                    if (!object.Equals(dr[columnName], DBNull.Value))
                    {
                        property.SetValue(objTarget, dr[columnName].ChangeType(property.PropertyType), null);
                    }
                    else
                    {
                        property.SetValue(objTarget, null);
                    }
                }
                _list.Add(objTarget);
            }
            return _list;
        }

        /// <summary>
        /// Lấy về giá trị của cell trong datarow
        /// </summary>
        /// <param name="dataRow">DataRow</param>
        /// <returns></returns>
        public static T GetRowCellValue<T>(this DataRow dataRow,string fieldName)
        {
            if (dataRow == null  || !dataRow.Table.Columns.Contains(fieldName) || dataRow.IsNull(fieldName))
            {
                return default(T);
            }
            return dataRow.Field<T>(fieldName);
        }

        /// <summary>
        /// Trả về object từ datatable
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns>Create by: dvthang:27.11.2016</returns>
        public static T ToObject<T>(this DataTable dt)
        {
            T objTarget = Activator.CreateInstance<T>();
            if (dt.Rows.Count > 0)
            {
                DataColumnCollection columns = dt.Columns;
                foreach (DataRow dr in dt.Rows)
                {

                    foreach (DataColumn col in columns)
                    {
                        PropertyInfo property = objTarget.GetType().GetProperty(col.ColumnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                        if (property != null)
                        {
                            if (!object.Equals(dr[col.ColumnName], DBNull.Value))
                            {
                                property.SetValue(objTarget, dr[col.ColumnName].ChangeType(property.PropertyType), null);
                            }
                            else
                            {
                                property.SetValue(objTarget, null);
                            }

                        }

                    }
                }
            }
            return objTarget;
        }

        /// Chuyen file sang thư mục khác
        /// </summary>
        /// <param name="sourceFile">đường dẫn file nguồn</param>
        /// <param name="destFile">Đường dẫn file đích</param>
        /// Create by: dvthang:27.11.2016
        public static void MoveFile(this string sourceFile, string destFile)
        {
            try
            {
                if (System.IO.File.Exists(sourceFile))
                {
                    System.IO.File.Copy(sourceFile, destFile, true);
                    System.IO.File.Delete(sourceFile);
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Copy file sang thư mục khác
        /// </summary>
        /// <param name="sourceFile">đường dẫn file nguồn</param>
        /// <param name="destFile">Đường dẫn file đích</param>
        /// Create by: dvthang:27.11.2016
        public static void DeleteFile(this string sourceFile)
        {
            try
            {
                if (System.IO.Directory.Exists(sourceFile))
                {
                    System.IO.File.Delete(sourceFile);
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Tạo thư mục
        /// </summary>
        /// <param name="Dir"></param>
        /// <returns>dvthang-07.05.2016</returns>
        public static Boolean CreateDirectory(this string Dir)
        {
            if (Directory.Exists(Dir) == false)
            {
                try
                {
                    Directory.CreateDirectory(Dir);
                    return true;
                }
                catch (IOException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return false;
        }
        /// <summary>
        /// Converts list of items into typed list of item of new type
        /// </summary>
        /// <example><code>
        /// Consider source to be List<object>, newItemType is typeof(string), so resulting list wil have type List<string>
        /// </code></example>
        /// <param name="newItemType">New item type</param>
        /// <param name="source">List of objects</param>
        /// <returns>Typed List object</returns>
        public static IList ToListObject(this IDataReader _dr, Type newItemType)
        {
            var listType = typeof(List<>);
            var genericListType = listType.MakeGenericType(newItemType);

            var _list = (IList)Activator.CreateInstance(genericListType);

            if (_dr == null) return _list;

            int countColumn = _dr.FieldCount;
            Dictionary<string, PropertyInfo> dicDicPropertyInfo = null;
            while (_dr.Read())
            {
                object objTarget = Activator.CreateInstance(newItemType);

                if (dicDicPropertyInfo == null)
                {
                    dicDicPropertyInfo = GetDicPropertyInfo(_dr, newItemType, countColumn);
                }
                foreach (var pair in dicDicPropertyInfo)
                {
                    string columnName = pair.Key;
                    PropertyInfo property = pair.Value;
                    if (!object.Equals(_dr[columnName], DBNull.Value))
                    {
                        property.SetValue(objTarget, _dr[columnName].ChangeType(property.PropertyType), null);
                    }
                    else
                    {
                        property.SetValue(objTarget, null);
                    }
                }
                _list.Add(objTarget);
            }

            return _list;
        }

        /// <summary>
        /// KIểm tra chuỗi có chưa các ký tự đặc biệt không
        /// </summary>
        /// <param name="input">Chuỗi string</param>
        /// Create by: dvthang:13.10.2018
        public static bool IsSpecialCharacters(this string input)
        {
            if (input.Any(ch => !Char.IsLetterOrDigit(ch)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// hàm lấy giá trị default theo kiểu giữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu giữ liệu</typeparam>
        /// Create by: dvthang:16.08.2019
        public static T GetDefaultValue<T>()
        {
            Expression<Func<T>> e = Expression.Lambda<Func<T>>(
                Expression.Default(typeof(T))
            );
            return e.Compile()();
        }

        /// <summary>
        /// hàm lấy giá trị default theo kiểu giữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu giữ liệu</typeparam>
        /// Create by: dvthang:16.08.2019
        public static object GetDefaultValue(this Type type)
        {
            if (type == null) throw new ArgumentNullException("type");
            Expression<Func<object>> e = Expression.Lambda<Func<object>>(
                Expression.Convert(
                    Expression.Default(type), typeof(object)
                )
            );
            return e.Compile()();
        }

        /// <summary>
        /// Thực hiện convert từ data sang cây dạng tree
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu convert</typeparam>
        /// <param name="trees">Danh sách data dạng tree</param>
        /// <returns>Danh sách tree</returns>
        /// Create by: dvthang:4.4.2021
        public static IList<T> ToTreeInt<T>(this List<T> trees) where T : MTTree<int>
        {
            if (trees == null)
            {
                return null;
            }
            var dictionary = trees.ToDictionary(n => n.Id, n => n);
            var rootTree = new List<T>();
            foreach (var item in dictionary.Select(item => item.Value))
            {
                T parent = null;
                if (item.ParentId.HasValue && dictionary.TryGetValue(item.ParentId.Value, out parent))
                {
                    if (parent.Data == null)
                        parent.Data = new List<T>();
                    item.Expanded = true;
                    if (dictionary.Any(x => x.Value.ParentId.HasValue && x.Value.ParentId == item.Id))
                    {
                        item.Leaf = false;
                        item.Expanded = true;
                    }
                    else
                    {
                        item.Leaf = true;
                        item.Expanded = null;
                    }
                    parent.Data.Add(item);
                }
                else
                {
                    if (dictionary.Any(x => x.Value.ParentId.HasValue && x.Value.ParentId == item.Id))
                    {
                        item.Leaf = false;
                        item.Expanded = true;
                    }
                    else
                    {
                        item.Leaf = true;
                        item.Expanded = null;
                    }
                    rootTree.Add(item);
                }

            }
            return rootTree;
        }

        /// <summary>
        /// Thực hiện convert từ data sang cây dạng tree
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu convert</typeparam>
        /// <param name="trees">Danh sách data dạng tree</param>
        /// <returns>Danh sách tree</returns>
        /// Create by: dvthang:4.4.2021
        public static IList<T> ToTreeGuid<T>(this List<T> trees) where T : MTTree<Guid>
        {
            if (trees == null)
            {
                return null;
            }
            var dictionary = trees.ToDictionary(n => n.Id, n => n);
            var rootTree = new List<T>();
            foreach (var item in dictionary.Select(item => item.Value))
            {
                T parent = null;
                if (item.ParentId.HasValue && dictionary.TryGetValue(item.ParentId.Value, out parent))
                {
                    if (parent.Data == null)
                        parent.Data = new List<T>();
                    item.Expanded = true;
                    if (dictionary.Any(x => x.Value.ParentId.HasValue && x.Value.ParentId == item.Id))
                    {
                        item.Leaf = false;
                        item.Expanded = true;
                    }
                    else
                    {
                        item.Leaf = true;
                        item.Expanded = null;
                    }
                    parent.Data.Add(item);
                }
                else
                {
                    if (dictionary.Any(x => x.Value.ParentId.HasValue && x.Value.ParentId == item.Id))
                    {
                        item.Leaf = false;
                        item.Expanded = true;
                    }
                    else
                    {
                        item.Leaf = true;
                        item.Expanded = null;
                    }
                    rootTree.Add(item);
                }

            }
            return rootTree;
        }

        /// <summary>
        /// Lấy về thời điểm đầu tiên của ngày
        /// </summary>
        /// <param name="dateTime">Ngày hiện tại</param>
        /// <returns></returns>
        public static string StartDate(this DateTime currentDate)
        {
            return currentDate.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Lấy về thời điểm đầu tiên của ngày
        /// </summary>
        /// <param name="dateTime">Ngày hiện tại</param>
        /// <returns></returns>
        public static string EndDate(this DateTime currentDate)
        {
            return (new DateTime(currentDate.Year,currentDate.Month,currentDate.Day,23,59,59)).ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// Hàm thực hiện chuyển dữ liệu từ danh sách sang datatable
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu</typeparam>
        /// <param name="data">Dữ liệu cần chuyển</param>
        /// <returns>Trả về cấu trúc datatable</returns>
        public static DataTable ToDataTable<T>(this List<T> data)
        {
            PropertyDescriptorCollection properties =TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
               
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }

        /// <summary>
        /// Hàm thực hiện chuyển dữ liệu từ danh sách sang datatable
        /// </summary>
        /// <typeparam name="type">Kiểu dữ liệu</typeparam>
        /// <param name="data">Dữ liệu cần chuyển</param>
        /// <param name="cols">Danh sách cột</param>
        /// <returns>Trả về cấu trúc datatable</returns>
        public static DataTable ToDataTable(Type type, IList data,params string[] cols)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(type);
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                if(cols?.Length>0)
                {
                    if (cols.Contains(prop.Name))
                    {
                        table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                    }
                    
                }
                else
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
            }

            foreach (var item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    if (cols?.Length > 0)
                    {
                        if (cols.Contains(prop.Name))
                        {
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        }

                    }
                    else
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    }

                    
                }
                table.Rows.Add(row);
            }
            return table;
        }

        /// <summary>
        /// Băm chuỗi ra md5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CreateMD5(this string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Add or update dictionary
        /// </summary>
        /// <param name="dicData"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddOrUpdate<T>(this Dictionary<string,T> dicData,string key,T value)
        {
            if (!dicData.ContainsKey(key))
            {
                dicData.Add(key, value);
            }
            else
            {
                dicData[key] = value;
            }
        }

        /// <summary>
        /// Lấy value của dictionary
        /// </summary>
        /// <param name="dicData"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static T GetValueOfDictionary<T>(this Dictionary<string, object> dicData, string key)
        {
            try
            {
                if (!dicData.ContainsKey(key))
                {
                    return default(T);
                }
                else
                {
                    var val = dicData[key];
                    if (val == null)
                    {
                        return default(T);
                    }
                    if (typeof(T) == typeof(object))
                    {
                        return (T)val;
                    }
                    
                    return (T)Convert.ChangeType(val,typeof(T));
                }
            }
            catch
            {
               return default(T);
            }
        }

        /// <summary>
        /// Lấy value của dictionary
        /// </summary>
        /// <param name="dicData"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static T GetValueOfDictionary<T>(this Dictionary<string, T> dicData, string key)
        {
            if (!dicData.ContainsKey(key))
            {
                return default(T);
            }
            else
            {
                var val = dicData[key];
                if (val == null)
                {
                    return default(T);
                }
                return val;
            }
        }

        /// <summary>
        /// Lấy thời điểm đầu tiên của ngày
        /// </summary>
        public static DateTime StartOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
        }

        /// <summary>
        /// Lấy thời điểm cuối ngày
        /// </summary>
        public static DateTime EndOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59,999);
        }
    }

}
