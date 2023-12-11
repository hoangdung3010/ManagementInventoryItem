using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static MT.Library.Enummation;

namespace MT.Library
{
   public static class Utility
    {
        public static string CreateMD5(this string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Thiết lập kiểu json dạng isodate và giờ theo giờ server
        /// </summary>
        /// dvthang-03.10.2016
        public static JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings { 
                DateFormatHandling = DateFormatHandling.IsoDateFormat, 
                MissingMemberHandling = MissingMemberHandling.Ignore, 
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }

        /// <summary>
        /// Convert chuyển json về dạng object
        /// </summary>
        /// <typeparam name="T">Kiểu object</typeparam>
        /// <param name="value">Chuỗi json</param>
        /// <returns>dvthang-02.10.2016</returns>
        public static T DeserializeObject<T>(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value, GetJsonSerializerSettings());
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Convert chuyển json về dạng object
        /// </summary>
        /// <typeparam name="T">Kiểu object</typeparam>
        /// <param name="value">Chuỗi json</param>
        /// <returns>dvthang-02.10.2016</returns>
        public static object DeserializeObject(string value, Type type)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject(value, type, GetJsonSerializerSettings());
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Convert chuyển object về dạng chuỗi json
        /// </summary>
        /// <param name="value">Object cần chuyển đổi</param>
        /// <returns>dvthang-02.10.2016</returns>
        public static string SerializeObject(object value)
        {
            if (value != null)
            {
                return JsonConvert.SerializeObject(value, GetJsonSerializerSettings());
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Lấy về chuỗi kết nối đến DB
        /// </summary>
        /// <returns>Create by:dvthang:27.11.2016</returns>
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public static string Decrypt(string strToDecrypt)
        {
            return AesCryptoService.Decrypt(strToDecrypt);
        }

        public static string Encrypt(string strToEncrypt)
        {
            return AesCryptoService.Encrypt(strToEncrypt);
        }

        public static string EncrytMD5(string data)
        {
            byte[] bytes = Encoding.Default.GetBytes(data);
            MD5 md = new MD5CryptoServiceProvider();
            return Convert.ToBase64String(md.ComputeHash(bytes));
        }

        // Fields
        private static string[] badChars = new string[] { "'or", "'1'=1", ";", "--", "'", "xp_", "[", "%", "/*", "*/","'",
                "char", "nchar", "varchar",
                "nvarchar", "alter", "begin", "cast", "create", "cursor", "declare", "delete", "drop", "end", "exec",
                "execute", "fetch", "insert", "kill", "select", "sys", "sysobjects", "syscolumns", "table", "update",
                "truncate","reconfigure","waitfor","xp_cmdshell","union","information_schema"};

        // Methods
        public static string AddChar(string inputSQL)
        {
            string str = inputSQL;
            for (int i = 0; i < badChars.Length; i++)
            {
                if (badChars[i].ToString() == "'")
                {
                    str = str.Replace(badChars[i], "''");
                }
                else
                {
                    str = str.Replace(badChars[i], "[" + badChars[i] + "]");
                }
            }
            return str;
        }

        public static string DeleteChar(string inputSQL)
        {
            string str = inputSQL;
            for (int i = 0; i < badChars.Length; i++)
            {
                str = str.Replace(badChars[i], "");
            }
            return str;
        }

        /// <summary>
        /// Hàm phát hiện SQL Injection
        /// </summary>
        /// <param name="userInput">Chuối đầu vào</param>
        /// <returns>true là injection, ngược lại thì không</returns>
        public static bool CheckForSQLInjection(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return false;
            }

            bool isSQLInjection = false;
            return isSQLInjection;
            string[] sqlCheckList = {"char", "nchar", "varchar", 
                "nvarchar", "alter", "begin", "cast", "create", "cursor", "declare", "delete", "drop", "end", "exec",
                "execute", "fetch", "insert", "kill", "select", "sys", "sysobjects", "syscolumns", "table", "update",
                "truncate","reconfigure","waitfor","xp_cmdshell","union","information_schema"
            };
            string[] _commentTagSets = new string[7] { "--", ";--", ";", "/*", "*/", "@@", "@" };
            string checkString = userInput.Trim();
            foreach (var item in _commentTagSets)
            {
                checkString = checkString.Replace(item, "");
            }

            for (int i = 0; i <= sqlCheckList.Length - 1; i++)
            {
                if (checkString.IndexOf(sqlCheckList[i] +" ",StringComparison.OrdinalIgnoreCase) >-1
                    || checkString.IndexOf(" "+sqlCheckList[i], StringComparison.OrdinalIgnoreCase) > -1)
                {
                    isSQLInjection = true;
                    break;
                }
            }

            return isSQLInjection;
        
        }

        /// <summary>
        /// Lấy giá trị enum từ enumName
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu</typeparam>
        /// <param name="value">Tên enum</param>
        /// <param name="defaultValue">Giá trị mặc định</param>
        /// <returns></returns>
        public static T ParseEnum<T>(string value, T defaultValue) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");
            if (string.IsNullOrEmpty(value)) return defaultValue;

            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (item.ToString().ToLower().Equals(value.Trim().ToLower())) return item;
            }
            return defaultValue;
        }

        /// <summary>
        /// Build sort column trên grid
        /// </summary>
        /// <param name="sorts"></param>
        public static string BuildSort(HashSet<Sorting> sorts)
        {
            string expressionSort = "";
            if (sorts != null)
            {
                StringBuilder builder = new StringBuilder();
                string direction = "ASC";
                foreach (var sort in sorts)
                {
                    if (sort.Direction == Direction.DESC)
                    {
                        direction = "DESC";
                    }
                    if (CheckForSQLInjection(sort.ColumnName))
                    {
                        throw new Exception($"Detect SQL Injection: {sort.ColumnName}");
                    }
                    builder.AppendFormat(" {0} {1},", sort.ColumnName, direction);
                }
                if (builder.Length > 0)
                {
                    string strBuider = builder.ToString();
                    expressionSort = strBuider.Substring(0, strBuider.Length - 1);
                }
            }

            return expressionSort;
        }

        /// <summary>
        /// Build sort column trên grid, ngược với điều kiện truyền vào
        /// </summary>
        public static string BuildSortReverse(HashSet<Sorting> sorts)
        {
            string expressionSort = "";
            if (sorts != null)
            {
                StringBuilder builder = new StringBuilder();
                string direction = "ASC";
                foreach (var sort in sorts)
                {
                    if (sort.Direction == Direction.DESC)
                    {
                        direction = "ASC";
                    }
                    else
                    {
                        direction = "DESC";
                    }
                    if (CheckForSQLInjection(sort.ColumnName))
                    {
                        throw new Exception($"Detect SQL Injection: {sort.ColumnName}");
                    }
                    builder.AppendFormat(" {0} {1},", sort.ColumnName, direction);
                }
                if (builder.Length > 0)
                {
                    string strBuider = builder.ToString();
                    expressionSort = strBuider.Substring(0, strBuider.Length - 1);
                }
            }

            return expressionSort;
        }

        /// <summary>
        /// Kiểm tra mã vạch có hợp lệ không
        /// </summary>
        /// <param name="sMaVach"></param>
        /// <returns></returns>
        public static bool ValidsMaVach(string sMaVach)
        {
            if (string.IsNullOrWhiteSpace(sMaVach))
            {
                return false;
            }
            string strRegex = @"^[0-9]{15}$";
            Regex re = new Regex(strRegex);

            if (re.IsMatch(sMaVach))
            {
                return true;
            }

            return false;
        }

        /// Chuyển phần nguyên của số thành chữ
        /// 
        /// Số double cần chuyển thành chữ
        /// Chuỗi kết quả chuyển từ số
        public static string NumberToText(object inputNumber, bool suffix = true)
        {
            if (inputNumber==null ||"".Equals(inputNumber.ToString())
                || "0".Equals(inputNumber.ToString()))
            {
                return string.Empty;
            }
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber =decimal.Parse(inputNumber.ToString()).ToString("#");
            decimal number = Convert.ToDecimal(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result + (suffix ? " đồng chẵn" : "");
        }
   
        /// <summary>
        /// Hàm thực hiện format value theo kiểu dữ liệu
        /// </summary>
        /// <param name="value">Giá trị</param>
        public static string FormatValue(object value)
        {
            if (value == null|| "0".Equals(value.ToString()))
            {
                return string.Empty;
            }
            Type type = value.GetType();
            switch (type.Name)
            {
                case "Char":
                case "String":
                    return value.ToString();
                case "DateTime":
                    return Convert.ToDateTime(value).ToString("dd/MM/yyyy");
                case "TimeSpan":
                    return Convert.ToDateTime(value).ToString("dd/MM/yyyy");
                case "Byte":
                    return value.ToString();
                case "Decimal":
                    if (decimal.Parse(value.ToString()) == 0)
                    {
                        return string.Empty;
                    }
                    return String.Format("{0:#,#0}", value);
                case "Double":
                    if (double.Parse(value.ToString()) == 0)
                    {
                        return string.Empty;
                    }
                    return String.Format("{0:#,#0}", value);
                case "Int16":
                    if (Int16.Parse(value.ToString()) == 0)
                    {
                        return string.Empty;
                    }
                    return value.ToString();
                case "Int32":
                    if (Int32.Parse(value.ToString()) == 0)
                    {
                        return string.Empty;
                    }
                    return value.ToString();
                case "SByte":
                    if (Int16.Parse(value.ToString()) == 0)
                    {
                        return string.Empty;
                    }
                    return value.ToString();
                case "Single":
                    if (float.Parse(value.ToString()) == 0)
                    {
                        return string.Empty;
                    }
                    return String.Format("{0:#,##0}", value);
                case "UInt16":
                    if (UInt16.Parse(value.ToString()) == 0)
                    {
                        return string.Empty;
                    }
                    return value.ToString();
                case "UInt32":
                    if (UInt32.Parse(value.ToString()) == 0)
                    {
                        return string.Empty;
                    }
                    return value.ToString();
                case "Int64":
                    if (Int64.Parse(value.ToString()) == 0)
                    {
                        return string.Empty;
                    }
                    return value.ToString();
                case "UInt64":
                    if (UInt64.Parse(value.ToString()) == 0)
                    {
                        return string.Empty;
                    }
                    return value.ToString();
            }
            return value.ToString();
        }

        /// <summary>
        /// Lấy về chuỗi kết nối đến DB
        /// </summary>
        /// <returns>Create by:dvthang:27.11.2016</returns>
        public static T GetAppSettings<T>(string key, object defaultValue = null)
        {
            try
            {
                string sValue = ConfigurationManager.AppSettings[key];
                return (T)MT.Library.Extensions.ExtensionMethod.ChangeType(sValue, typeof(T));
            }
            catch (Exception)
            {
                return (T)defaultValue;
            }

        }

        /// <summary>
        /// Hàm kiểm tra quyển của ứng dụng
        /// </summary>
        /// <returns>true: Có quyền, ngược lại không có quyền</returns>
        /// Created by: dvthang: 07.11.2020
        public static bool CheckPermission(string formId, params MT.Library.Enummation.PermissionValue[] permissionValue)
        {
            var rolePermission = MT.Library.SessionData.RolePermissions.Find(m => m.FormId.Equals(formId));
            if (rolePermission == null)
            {
                return false;
            }

            foreach (var item in permissionValue)
            {
                if ((rolePermission.Permission & (int)item) == (int)item)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Lấy về khoảng thời gian theo tham số kỳ báo cáo
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public static Tuple<DateTime?, DateTime?> GetDateRangeByPeriod(int period)
        {
            DateTime? _fromDate = null;
            DateTime? _toDate = null;
            DateTime currentDate = DateTime.Now;
            switch (period)
            {
                case (int)Period.HomNay:
                    _fromDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day);
                    _toDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 23, 59, 59, 999);
                    break;
                case (int)Period.HomQua:
                    _fromDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day - 1);
                    _toDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day - 1, 23, 59, 59, 999);
                    break;
                case (int)Period.TuanNay:
                    DayOfWeek day = DateTime.Now.DayOfWeek;
                    int days = day - DayOfWeek.Monday;
                    _fromDate = DateTime.Now.AddDays(-days);
                    _toDate = _fromDate.Value.AddDays(6);
                    break;
                case (int)Period.TuanTruoc:
                    DayOfWeek day2 = DateTime.Now.DayOfWeek;
                    int days2 = day2 - DayOfWeek.Monday;
                    _fromDate = DateTime.Now.AddDays(-days2).AddDays(-6);
                    _toDate = _fromDate.Value.AddDays(6);
                    _toDate = new DateTime(_toDate.Value.Year, _toDate.Value.Month, _toDate.Value.Day, 23, 59, 59, 999);
                    break;
                case (int)Period.ThangNay:
                    _fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    _toDate = _fromDate.Value.AddMonths(1).AddDays(-1);
                    _toDate = new DateTime(_toDate.Value.Year, _toDate.Value.Month, _toDate.Value.Day, 23, 59, 59, 999);
                    break;
                case (int)Period.ThangTruoc:
                    if (DateTime.Now.Month == 1)
                    {
                        _fromDate = new DateTime(DateTime.Now.Year - 1, 12, 1);
                        _toDate = new DateTime(DateTime.Now.Year - 1, 12, 31, 23, 59, 59, 999);
                    }
                    else
                    {
                        _fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
                        _toDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, GetTotalDayOfMonth(DateTime.Now.AddMonths(1)), 23, 59, 59, 999);
                    }

                    break;
                case (int)Period.T1:
                    _fromDate = new DateTime(currentDate.Year, 1, 1);
                    _toDate = new DateTime(currentDate.Year, 1, 31, 23, 59, 59, 999);
                    break;
                case (int)Period.T2:
                    int totalDay = 28;
                    if (((currentDate.Year % 4 == 0) && (currentDate.Year % 100 != 0)) || (currentDate.Year % 400 == 0))
                    {
                        totalDay = 29;
                    }
                    _fromDate = new DateTime(currentDate.Year, 2, 1);
                    _toDate = new DateTime(currentDate.Year, 2, totalDay, 23, 59, 59, 999);

                    break;
                case (int)Period.T3:
                    _fromDate = new DateTime(currentDate.Year, 3, 1);
                    _toDate = new DateTime(currentDate.Year, 3, 31, 23, 59, 59, 999);

                    break;
                case (int)Period.T4:
                    _fromDate = new DateTime(currentDate.Year, 4, 1);
                    _toDate = new DateTime(currentDate.Year, 4, 30, 23, 59, 59, 999);
                    break;
                case (int)Period.T5:
                    _fromDate = new DateTime(currentDate.Year, 5, 1);
                    _toDate = new DateTime(currentDate.Year, 5, 31, 23, 59, 59, 999);
                    break;
                case (int)Period.T6:
                    _fromDate = new DateTime(currentDate.Year, 6, 1);
                    _toDate = new DateTime(currentDate.Year, 6, 30, 23, 59, 59, 999);
                    break;
                case (int)Period.T7:
                    _fromDate = new DateTime(currentDate.Year, 7, 1);
                    _toDate = new DateTime(currentDate.Year, 7, 31, 23, 59, 59, 999);
                    break;
                case (int)Period.T8:
                    _fromDate = new DateTime(currentDate.Year, 8, 1);
                    _toDate = new DateTime(currentDate.Year, 8, 31, 23, 59, 59, 999);
                    break;
                case (int)Period.T9:
                    _fromDate = new DateTime(currentDate.Year, 9, 1);
                    _toDate = new DateTime(currentDate.Year, 9, 30, 23, 59, 59, 999);
                    break;
                case (int)Period.T10:
                    _fromDate = new DateTime(currentDate.Year, 10, 1);
                    _toDate = new DateTime(currentDate.Year, 10, 31, 23, 59, 59, 999);
                    break;
                case (int)Period.T11:
                    _fromDate = new DateTime(currentDate.Year, 11, 1);
                    _toDate = new DateTime(currentDate.Year, 11, 30, 23, 59, 59, 999);

                    break;
                case (int)Period.T12:
                    _fromDate = new DateTime(currentDate.Year, 12, 1);
                    _toDate = new DateTime(currentDate.Year, 12, 31, 23, 59, 59, 999);

                    break;
                case (int)Period.Q1:
                    _fromDate = new DateTime(currentDate.Year, 1, 1);
                    _toDate = new DateTime(currentDate.Year, 3, 31, 23, 59, 59, 999);
                    break;
                case (int)Period.Q2:
                    _fromDate = new DateTime(currentDate.Year, 4, 1);
                    _toDate = new DateTime(currentDate.Year, 6, 30, 23, 59, 59, 999);

                    break;
                case (int)Period.Q3:
                    _fromDate = new DateTime(currentDate.Year, 7, 1);
                    _toDate = new DateTime(currentDate.Year, 9, 30, 23, 59, 59, 999);
                    break;
                case (int)Period.Q4:
                    _fromDate = new DateTime(currentDate.Year, 10, 1);
                    _toDate = new DateTime(currentDate.Year, 12, 31, 23, 59, 59, 999);

                    break;
                case (int)Period.SauThangDauNam:
                    _fromDate = new DateTime(currentDate.Year, 1, 1);
                    _toDate = new DateTime(currentDate.Year, 6, 30, 23, 59, 59, 999);

                    break;
                case (int)Period.SauThangCuoiNam:
                    _fromDate = new DateTime(currentDate.Year, 7, 1);
                    _toDate = new DateTime(currentDate.Year, 12, 31, 23, 59, 59, 999);
                    break;
                case (int)Period.NamTruoc:
                    _fromDate = new DateTime(currentDate.Year - 1, 1, 1);
                    _toDate = new DateTime(currentDate.Year - 1, 12, 31, 23, 59, 59, 999);
                    break;
                case (int)Period.NamNay:
                    _fromDate = new DateTime(currentDate.Year, 1, 1);
                    _toDate = new DateTime(currentDate.Year, 12, 31, 23, 59, 59, 999);
                    break;
                case (int)Period.DauNamDenHT:
                    _fromDate = new DateTime(currentDate.Year, 1, 1);
                    _toDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 23, 59, 59, 999);
                    break;
                case (int)Period.ToanThoiGian:
                    _fromDate = null;
                    _toDate = null;
                    break;
                default:
                    _fromDate = null;
                    _toDate = null;
                    break;

            }

            return Tuple.Create(_fromDate, _toDate);
        }

        /// <summary>
        /// Lấy về tổng số ngày của tháng
        /// </summary>
        /// <param name="currentDate">Ngày hiện tại</param>
        public static int GetTotalDayOfMonth(DateTime currentDate)
        {
            switch (currentDate.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if (((currentDate.Year % 4 == 0) && (currentDate.Year % 100 != 0)) || (currentDate.Year % 400 == 0))
                    {
                        return 29;
                    }
                    return 28;

            }

            return 0;
        }

        /// <summary>
        /// Hàm chuyển chuỗi mã vạch thành đối tượng
        /// </summary>
        /// <param name="sMaVach">Chuỗi mã vạch</param>
        /// <returns>Đối tượng chứa các thông tin trong mã vạch</returns>
        public static (string sNguon,string sNhaCungCap,string sMaNhomTrangBi,string sMaSanPham,
            string sSoSeries,string sNam) ConvertsMaVachToObject(string sMaVach)
        {

            /*
             * Mã vạch gồm 15 số (Nguồn(1) -->Nhà cung cấp (1)--> Mã nhóm trang bị (2) --> Mã sản phẩm (4) --> Số series (5) -->năm sx (2))
             */
            if (string.IsNullOrWhiteSpace(sMaVach))
            {
                throw new Exception("Thông tin mã vạch không được trống");
            }

            if (sMaVach.Trim().Length != 15)
            {
                throw new Exception("Mã vạch không đúng định dạng 15 số");
            }
            sMaVach = sMaVach.Trim();
            string sNguon = sMaVach.Substring(0, 1);
            string sNhaCungCap = sMaVach.Substring(1, 1);
            string sMaNhomTrangBi = sMaVach.Substring(2, 2);
            string sMaSanPham = sMaVach.Substring(4, 4);
            string sSoSeries = sMaVach.Substring(8, 5);
            string sNam = sMaVach.Substring(13);
            return (sNguon, sNhaCungCap, sMaNhomTrangBi, sMaSanPham, sSoSeries, sNam);
        }

    }
}
