using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
namespace MTControl
{
    public class MCommon
    {
        #region"Declare"
        public static string DecimalSeparator = ",";
        public static string GroupSeparator = ".";

        /// <summary>
        /// NamespaceResource Combo
        /// </summary>
        public static string ResourceComboLooUp = "";
        public static string AssemblyNameFormUI = "";
        public static string AssemblyNameModels = "";
        public static string AssemblyNameEnum = "";

        public static int QuanlityInt = 0;
        public static int QuanlityFloat = 0;
        public static int QuanlityFloat_0 = 0;
        public static int QuanlityFloat_1 = 0;
        public static int UnitPrice = 0;
        public static int Amount = 0;
        public static int Coefficient = 2;
        /// <summary>
        /// Đối tượng Assemply của UI
        /// </summary>
        internal static Assembly AssemblyUI = null;

        /// <summary>
        /// Đối tượng Assemply của Models
        /// </summary>
        internal static Assembly AssemblyModels = null;

        /// <summary>
        /// Đối tượng Assemply chứa enum
        /// </summary>
        internal static Assembly AssemblyEnum = null;

        /// <summary>
        /// Đối tượng Assemply của Project 
        /// </summary>
        internal static Assembly AssemblyCurrent = null;

        /// <summary>
        /// Đối tượng đọc resource của Control
        /// </summary>
        internal static ResourceManager ResourceMGControl = null;

        /// <summary>
        /// Thông tin quốc gia, phục vụ việc localize
        /// </summary>
        public static CultureInfo Culture = null;

        /// <summary>
        /// Đối tượng dùng để lưu danh sách data enum,
        /// để lần sau không phải load lại
        /// </summary>
        /// Create by: dvthang:09.04.2017
        public static Dictionary<string, List<DisplayEnum>> ShareEnum = null;

        /// <summary>
        /// Danh sách các column không so sánh
        /// Create by: dvthang:21.05.2017
        /// </summary>
        public static List<string> ListColumnUnCheck = new List<string> { "sCreatedBy", "sModifiedBy", "sIPAddress", "dModifiedDate", "dCreatedDate","Item" };
        #endregion
        /// <summary>
        /// Lấy về giá trị của resource
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetLocalResources(string name)
        {
            if (AssemblyCurrent == null)
            {
                AssemblyCurrent = Assembly.Load("MTControl");
                if (ResourceMGControl == null)
                {
                    ResourceMGControl = new ResourceManager("MTControl.Properties.Resources", AssemblyCurrent);
                }
            }

            if (ResourceMGControl != null)
            {
                return ResourceMGControl.GetString(name, Culture);
            }
            return "";
        }

        /// <summary>
        /// Lấy về ảnh trong resources
        /// </summary>
        /// <param name="nameImg"></param>
        /// <returns></returns>
        public static Bitmap GetImageLocalResouces(string nameImg)
        {
            if (AssemblyCurrent == null)
            {
                AssemblyCurrent = Assembly.Load("MTControl");
                if (ResourceMGControl == null)
                {
                    ResourceMGControl = new ResourceManager("MTControl.Properties.Resources", AssemblyCurrent);
                }
            }

            if (ResourceMGControl != null)
            {
                return (Bitmap)ResourceMGControl.GetObject(nameImg, Culture);
            }
            return null;
        }

        /// <summary>
        /// Lấy về type hiện tại của enumresources
        /// </summary>
        /// <param name="name"></param>
        /// Create by: dvthang:09.03.2017
        public static Type GetEnumType(string name)
        {
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    if (AssemblyEnum == null)
                    {
                        AssemblyEnum = Assembly.Load(AssemblyNameEnum);
                    }
                    return AssemblyEnum.GetType(string.Format("{0}.{1}", AssemblyNameEnum, name));
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        /// <summary>
        /// Lấy về giá trị của resource
        /// </summary>
        /// <param name="name">Tên file Resource của Models</param>
        /// Create by: dvthang:09.03.2017
        public static string GetGlobalResources(Assembly assembly, string resourceName, string name)
        {
            try
            {
                ResourceManager rm = new ResourceManager(resourceName, assembly);
                if (rm != null)
                {
                    return rm.GetString(name);
                }
            }
            catch (Exception)
            {
                return "";
            }
            return "";
        }

        /// <summary>
        /// Thiết lập them mặc định cho form
        /// </summary>
        public static void SetSkins()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Visual Studio 2013 Blue");
        }

        /// <summary>
        /// Căn chỉnh vị trí các text trong column grid(Giữa, trái , phải)
        /// </summary>
        public static void SetDefaultAlignGridLookUp(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit grdLookUp)
        {

            if (grdLookUp.View != null)
            {

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdLookUp.View.Columns)
                {
                    Type t = col.ColumnType.GetType();
                    if (col.FieldName == "STT" || col.FieldName == "Rownum")
                    {
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        continue;
                    }
                    if (t.Equals(typeof(string)))
                    {
                        //Căn trái dữ liệu
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    }
                    else if (t.Equals(typeof(DateTime)) || t.Equals(typeof(DateTime?)))
                    {
                        //Căn Giữa dữ liệu
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    }
                    else if (t.Equals(typeof(Decimal)) || t.Equals(typeof(Decimal?)))
                    {
                        //Căn Phải dữ liệu
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    }
                    else if (t.Equals(typeof(Int32)) || t.Equals(typeof(Int32?)))
                    {
                        //Căn Phải dữ liệu
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    }
                    else if (t.Equals(typeof(float)) || t.Equals(typeof(float?)))
                    {
                        //Căn Phải dữ liệu
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    }
                    else if (t.Equals(typeof(decimal)) || t.Equals(typeof(decimal?)))
                    {
                        //Căn Phải dữ liệu
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    }

                    else if (t.Equals(typeof(int)) || t.Equals(typeof(int?)))
                    {
                        //Căn Phải dữ liệu
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    }

                    //Nếu column có dạng ComboLookup thì style lại cho combo và định nghĩa thêm 1 số thông tin config
                    if (col.ColumnEdit != null && col.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
                    {
                        DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit comboLookup = col.ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;
                        comboLookup.TextEditStyle = TextEditStyles.Standard;
                    }
                    //Căn giữa header
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
            }

        }

        /// <summary>
        /// Đọc giá trị của properties
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        internal static object GetValueObject(object entity, string propertyName)
        {
            PropertyInfo property = entity.GetType().GetProperty(propertyName, BindingFlags.SetProperty
                | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property != null)
            {
                return property.GetValue(entity, null);
            }
            return null;
        }

        /// <summary>
        /// Kiểm tra property tồn tại
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        internal static bool ExistsProperty(object entity, string propertyName)
        {
            PropertyInfo property = entity.GetType().GetProperty(propertyName, BindingFlags.SetProperty
                | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gán giá trị cho object
        /// </summary>
        internal static void SetValue(object entity, string propertyName, object value)
        {
            PropertyInfo info = entity.GetType().GetProperty(propertyName, BindingFlags.SetProperty
                | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (info != null)
            {
                info.SetValue(entity, ChangeType(value,info.PropertyType), null);
            }
        }

        /// <summary>
        /// CHuyển kiểu dữ liệu cho object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns>Trả về giá trị</returns>
        /// Create by: dvthang:23.10.2017
        internal static object ChangeType(object value, Type conversion)
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
                    Guid resultGuid;
                    Guid.TryParse(value.ToString(), out resultGuid);
                    return resultGuid;
                }

                if (!(value is IConvertible))
                {
                    return value;
                }

                return Convert.ChangeType(value, type);
            }
            catch (FormatException ex)
            {
                return GetDefaultValue(type);
            }
        }

        /// <summary>
        /// hàm lấy giá trị default theo kiểu giữ liệu
        /// </summary>
        /// <typeparam name="T">Kiểu giữ liệu</typeparam>
        /// Create by: dvthang:16.08.2019
        internal static object GetDefaultValue(Type type)
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
        /// Clone object tránh bị byref khi sửa đổi
        /// </summary>
        /// <returns></returns>
        internal static object GetIdentity(object entity)
        {
            Type type = entity.GetType();
            MethodInfo method = type.GetMethod("GetIdentity");
            return method.Invoke(entity, null); ;
        }

        /// <summary>
        /// Kiểm tra chuỗi có phải là kiểu số không
        /// </summary>
        /// <param name="input"></param>
        /// Create by: dvthang:09.03.2017
        public static bool IsNumeric(string input)
        {
            decimal vValue = 0;
            return decimal.TryParse(input, out vValue);
        }

        /// <summary>
        /// Thiết lập từ ngày và đến ngày theo kỳ báo báo
        /// </summary>
        public static void SetDateRangeByPeriod(int period, MDateEdit dteFromDate, MDateEdit dteToDate)
        {
            DateTime toDay = DateTime.Now;
            DayOfWeek firstDay = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = toDay.Date;
            switch (period)
            {
                case 0:
                    //Hôm nay
                    dteFromDate.EditValue = toDay;
                    dteToDate.EditValue = toDay;
                    break;
                case 1:
                    //Hôm qua
                    dteFromDate.EditValue = toDay.AddDays(-1);
                    dteToDate.EditValue = dteFromDate.EditValue;
                    break;
                case 2:
                    while (firstDayInWeek.DayOfWeek != firstDay)
                    {
                        firstDayInWeek = firstDayInWeek.AddDays(-1);
                    }
                    //Tuần này
                    dteFromDate.EditValue = firstDayInWeek;
                    dteToDate.EditValue = firstDayInWeek.AddDays(6);
                    break;
                case 3:
                    DateTime endDate = StartOfWeek(toDay).AddDays(-1);
                    //Tuần này
                    dteFromDate.EditValue = endDate.AddDays(-6);
                    dteToDate.EditValue = endDate;
                    break;
                case 4:
                    //Tháng này
                    dteFromDate.EditValue = GetFirstDayOfMonth(toDay);
                    dteToDate.EditValue = GetLastDayOfMonth(toDay.Month);
                    break;
                case 5:
                    //Tháng trước
                    dteFromDate.EditValue = GetFirstDayOfMonth(toDay.AddMonths(-1));
                    dteToDate.EditValue = GetLastDayOfMonth(toDay.AddMonths(-1));
                    break;
            }
        }

        /// <summary>
        /// Lấy ra ngày đầu tiên trong tháng có chứa
        /// 1 ngày bất kỳ được truyền vào
        /// </summary>
        /// <param name="dtDate">Ngày nhập vào</param>
        /// <returns>Ngày đầu tiên trong tháng</returns>
        public static DateTime GetFirstDayOfMonth(DateTime dtInput)
        {
            DateTime dtResult = dtInput;
            dtResult = dtResult.AddDays((-dtResult.Day) + 1);
            return dtResult;
        }
        /// <summary>
        /// Lấy ra ngày đầu tiên trong tháng được truyền vào
        /// là 1 số nguyên từ 1 đến 12
        /// </summary>
        /// <param name="iMonth">Thứ tự của tháng trong năm</param>
        /// <returns>Ngày đầu tiên trong tháng</returns>
        public static DateTime GetFirstDayOfMonth(int iMonth)
        {
            DateTime dtResult = new DateTime(DateTime.Now.Year, iMonth, 1);
            dtResult = dtResult.AddDays((-dtResult.Day) + 1);
            return dtResult;
        }

        /// <summary>
        /// Lấy ra ngày cuối cùng trong tháng có chứa
        /// 1 ngày bất kỳ được truyền vào
        /// </summary>
        /// <param name="dtInput">Ngày nhập vào</param>
        /// <returns>Ngày cuối cùng trong tháng</returns>
        public static DateTime GetLastDayOfMonth(DateTime dtInput)
        {
            DateTime dtResult = dtInput;
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }
        /// <summary>
        /// Lấy ra ngày cuối cùng trong tháng được truyền vào
        /// là 1 số nguyên từ 1 đến 12
        /// </summary>
        /// <param name="iMonth"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(int iMonth)
        {
            DateTime dtResult = new DateTime(DateTime.Now.Year, iMonth, 1);
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }

        /// <summary>
        /// Lấy ngày kết thúc của tuần hiện tại
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime EndOfWeek(DateTime dateTime)
        {
            DateTime start = StartOfWeek(dateTime);

            return start.AddDays(6);
        }

        /// <summary>
        /// Lấy ngày đầu tiên của tuần hiện tại
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime StartOfWeek(DateTime dateTime)
        {
            int days = dateTime.DayOfWeek - DayOfWeek.Monday;

            if (days < 0)
                days += 7;

            return dateTime.AddDays(-1 * days).Date;
        }

        /// <summary>
        /// Lấy về culture hiện tại theo thiết lập hệ thống
        /// </summary>
        /// <returns></returns>
        public static CultureInfo GetCurrentCultureInfo()
        {
            CultureInfo oCultureInfo = new CultureInfo("vi-VN");
            oCultureInfo.NumberFormat.CurrencyDecimalSeparator = DecimalSeparator;
            oCultureInfo.NumberFormat.CurrencyGroupSeparator = GroupSeparator;
            oCultureInfo.NumberFormat.CurrencyNegativePattern = 0;

            oCultureInfo.NumberFormat.NumberDecimalSeparator = DecimalSeparator;
            oCultureInfo.NumberFormat.NumberGroupSeparator = GroupSeparator;
            oCultureInfo.NumberFormat.NumberNegativePattern = 0;

            oCultureInfo.NumberFormat.PercentDecimalSeparator = DecimalSeparator;
            oCultureInfo.NumberFormat.PercentGroupSeparator = GroupSeparator;
            oCultureInfo.NumberFormat.PercentNegativePattern = 0;
            return oCultureInfo;
        }

        /// <summary>
        /// Trả về chuỗi format định dạng số
        /// Quy ước số âm 0:(n), 1:-n, 2:- n,3: n-, 4: n -
        /// </summary>
        /// <param name="iFormatType"></param>
        /// <returns></returns>
        /// Trả về định dạng số 
        public static string GetFormatStringCustom(FormatType iFormatType, byte decimalCount = 0)
        {
            string sResult = "###,###,###,###,#0{0}";

            int iDecimalCount = 0;
            string sDecimalGroup = "";
            if (decimalCount <= 0)
            {
                switch (iFormatType)
                {
                    case FormatType.QuanlityInt:
                        iDecimalCount = QuanlityInt;
                        break;
                    case FormatType.QuanlityFloat:
                        iDecimalCount = QuanlityFloat;//Đọc từ hệ thống ra
                        break;
                    case FormatType.UnitPrice:
                        iDecimalCount = UnitPrice;//Đọc từ hệ thống ra
                        break;
                    case FormatType.Amount:
                        iDecimalCount = Amount;//Đọc từ hệ thống ra
                        break;
                    case FormatType.Coefficient:
                        iDecimalCount = Coefficient;//Đọc từ hệ thống ra
                        break;
                    case FormatType.Year:
                        return "###############";
                }
            }
            else
            {
                iDecimalCount = decimalCount;
            }
            if (iDecimalCount > 0)
            {
                sDecimalGroup = ".";
                for (int i = 1; i <= iDecimalCount; i++)
                {
                    sDecimalGroup += "#";
                }
            }
            return string.Format(sResult, sDecimalGroup);
        }

        /// <summary>
        /// Lấy về thể hiện của from
        /// </summary>
        /// <param name="strEntityName">Tên form </param>
        /// <returns>dvthang-05.08.2016</returns>
        public static MFormBase FindFormByName(string strDictionaryName)
        {
            if (!string.IsNullOrEmpty(strDictionaryName))
            {
                if (AssemblyUI == null)
                {
                    AssemblyUI = Assembly.Load(AssemblyNameFormUI);

                }
                Type formType = null;
                if (AssemblyUI != null)
                {
                    formType = AssemblyUI.GetType(string.Format("{0}.frm{1}Detail", AssemblyNameFormUI, strDictionaryName));
                }
                if (formType == null)
                {
                    return null;
                }
                return (MFormBase)Activator.CreateInstance(formType);
            }
            return null;
        }

        /// <summary>
        /// Khởi tạo Assembly của Models
        /// </summary>
        /// Create by: dvthang:09.03.2017
        public static void SetAssemblyModels()
        {
            if (!string.IsNullOrEmpty(AssemblyNameModels))
            {
                if (AssemblyModels == null)
                {
                    AssemblyModels = Assembly.Load(AssemblyNameModels);
                }
            }
        }

        /// <summary>
        /// Khởi tạo Assembly của UI
        /// </summary>
        /// Create by: dvthang:09.03.2017
        public static void SetAssemblyUI()
        {
            if (!string.IsNullOrEmpty(AssemblyNameFormUI))
            {
                if (AssemblyUI == null)
                {
                    AssemblyUI = Assembly.Load(AssemblyNameFormUI);
                }
            }
        }

        /// <summary>
        /// Thực hiện giải phải vùng nhớ cho các Đối tượng không sử dụng đến
        /// khi đóng form để tránh lỗi memmorik
        /// </summary>
        /// Create by: dvthang:09.03.2017
        public static void Dispose()
        {
            if (AssemblyUI != null)
            {
                AssemblyUI = null;
            }
            if (AssemblyModels != null)
            {
                AssemblyModels = null;
            }
            if (AssemblyCurrent != null)
            {
                AssemblyCurrent = null;
            }
            if (AssemblyEnum != null)
            {
                AssemblyEnum = null;
            }
            if (Culture != null)
            {
                Culture = null;
            }
            if (ShareEnum != null)
            {
                ShareEnum = null;
            }
        }

        /// <summary>
        /// Lấy về thông tin của enum
        /// </summary>
        /// <param name="enumName">Tên enum</param>
        /// <param name="value">Giá trị hiển thị</param>
        public static DisplayEnum GetDisplayEnum(string enumName,int value)
        {
            DisplayEnum displayEnum = null;
            List<DisplayEnum> lstDisplayEnum = null;
            //Nếu đã tồn tại giá trị enum roh thì ko load lại nữa
            if (MCommon.ShareEnum != null && MCommon.ShareEnum.ContainsKey(enumName))
            {
                lstDisplayEnum = MCommon.ShareEnum[enumName];
                displayEnum = lstDisplayEnum.Find(m => m.Value == value);
            }
            else
            {
                MCommon.SetAssemblyModels();
                Type t = MCommon.GetEnumType(enumName);
                if (t != null)
                {
                    System.Array arrValue = Enum.GetValues(t);
                    System.Array arrName = Enum.GetNames(t);
                    Dictionary<int, string> itemEnum = new Dictionary<int, string>();
                    lstDisplayEnum = new List<DisplayEnum>();
                    for (int i = 0; i < arrValue.Length; i++)
                    {
                        DisplayEnum objEnum = new DisplayEnum();
                        objEnum.Value = Convert.ToInt32(arrValue.GetValue(i));
                        string nameEnum = string.Format("{0}_{1}", enumName, Convert.ToString(arrName.GetValue(i)));
                        objEnum.Text = MCommon.GetGlobalResources(MCommon.AssemblyEnum, string.Format("{0}.EnumResources", MCommon.AssemblyNameEnum), nameEnum);
                       
                        lstDisplayEnum.Add(objEnum);
                    }

                    //Nếu có ENum thì lưu lại
                    if (lstDisplayEnum.Count > 0)
                    {
                        displayEnum = lstDisplayEnum.Find(m => m.Value == value);
                        if (MCommon.ShareEnum == null)
                        {
                            MCommon.ShareEnum = new Dictionary<string, List<DisplayEnum>>();
                        }
                        MCommon.ShareEnum.Add(enumName, lstDisplayEnum);
                    }
                }
            }

            return displayEnum;
        }

        /// <summary>
        /// Lấy về danh sách giá trị enum
        /// </summary>
        /// <param name="enumName">Tên enum</param>
        public static List<DisplayEnum> GetDisplayEnums(string enumName)
        {
            List<DisplayEnum> lstDisplayEnum = null;
            //Nếu đã tồn tại giá trị enum roh thì ko load lại nữa
            if (MCommon.ShareEnum != null && MCommon.ShareEnum.ContainsKey(enumName))
            {
                return MCommon.ShareEnum[enumName];
            }
            else
            {
                MCommon.SetAssemblyModels();
                Type t = MCommon.GetEnumType(enumName);
                if (t != null)
                {
                    System.Array arrValue = Enum.GetValues(t);
                    System.Array arrName = Enum.GetNames(t);
                    Dictionary<int, string> itemEnum = new Dictionary<int, string>();
                    lstDisplayEnum = new List<DisplayEnum>();
                    for (int i = 0; i < arrValue.Length; i++)
                    {
                        DisplayEnum objEnum = new DisplayEnum();
                        objEnum.Value = Convert.ToInt32(arrValue.GetValue(i));
                        string nameEnum = string.Format("{0}_{1}", enumName, Convert.ToString(arrName.GetValue(i)));
                        objEnum.Text = MCommon.GetGlobalResources(MCommon.AssemblyEnum, string.Format("{0}.EnumResources", MCommon.AssemblyNameEnum), nameEnum);

                        lstDisplayEnum.Add(objEnum);
                    }

                    //Nếu có ENum thì lưu lại
                    if (lstDisplayEnum.Count > 0)
                    {
                        if (MCommon.ShareEnum == null)
                        {
                            MCommon.ShareEnum = new Dictionary<string, List<DisplayEnum>>();
                        }
                        MCommon.ShareEnum.Add(enumName, lstDisplayEnum);
                    }
                }
            }
            return lstDisplayEnum;
        }

        #region"Contextmenu"
        /// <summary>
        /// Tạo danh sách context menu cho grid
        /// </summary>
        /// <param name="menu"></param>
        public static void CreateContextMenu(GridView grdView, ContextMenuStrip menu, MButtonName[] mButtonNames, EventHandler eventHanbler)
        {
            if (menu != null && mButtonNames!=null)
            {
                try
                {
                    foreach (MButtonName mButtonName in mButtonNames)
                    {
                        var toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        toolStripMenuItem.Name = mButtonName.CommandName.ToString();
                        toolStripMenuItem.Tag = (int)mButtonName.CommandName;

                        toolStripMenuItem.Text = MCommon.GetCommandTextButtonItem(typeof(MCommandName), (int)mButtonName.CommandName);
                        toolStripMenuItem.Image = MCommon.GetImageButton(mButtonName);
                        if (eventHanbler != null)
                        {
                            toolStripMenuItem.Click += eventHanbler;
                        }
                        menu.Items.Add(toolStripMenuItem);

                    }
                }
                catch (Exception e)
                {
                    MMessage.ShowError(e.StackTrace);
                }
            }
        }

        /// <summary>
        /// Lấy về text enum
        /// </summary>
        /// <param name="enumType">Kiểu enum</param>
        /// <param name="value">Giá trị enum</param>
        /// Create by: dvthang:12.04.2021
        public static string GetCommandTextButtonItem(Type enumType, int value)
        {
            var memInfo = enumType.GetMember(enumType.GetEnumName(value));
            var descriptionAttribute = memInfo[0]
            .GetCustomAttributes(typeof(DescriptionAttribute), false)
            .FirstOrDefault() as DescriptionAttribute;
            string text = string.Empty;
            if (descriptionAttribute != null && !string.IsNullOrEmpty((text = descriptionAttribute.Description)))
            {
                return text;
            }
            return string.Empty;
        }

        /// <summary>
        /// Thiết lập icon cho button
        /// </summary>
        /// <param name="mButtonName"></param>
        /// <param name="barButtonItem"></param>
        public static Image GetImageButton(MButtonName mButtonName)
        {
            try
            {
                if (mButtonName.Icon != null)
                {
                    return mButtonName.Icon;
                }
                else
                {
                    return (System.Drawing.Bitmap)global::MTControl.Properties.Resources.ResourceManager.GetObject(mButtonName.CommandName.ToString().ToLower(), Properties.Resources.Culture);

                }
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region"Add column trên grid"
        /// <summary>
        /// Add column dạng text vào grid
        /// </summary>
        /// <param name="grd">Tên grid</param>
        /// <param name="fieldName">Tên cột</param>
        /// <param name="caption">Tiêu đề cột</param>
        /// <param name="width">Độ rộng cột</param>
        /// dvthang-08.07.2016
        public static MGridColumn AddColumnText(GridView grd, string fieldName, string caption, int width = 50, DataTypeColumn dataType = DataTypeColumn.None)
        {
            MGridColumn col = new MGridColumn();
            col.FieldName = fieldName;
            col.Caption = caption;
            col.Visible = true;
            switch (dataType)
            {
                case DataTypeColumn.MemoEdit:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
                    break;
                case DataTypeColumn.SpinEdit:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
                    break;
                case DataTypeColumn.TimeEdit:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
                    break;
                case DataTypeColumn.DateEdit:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
                    break;
                case DataTypeColumn.ComboBox:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                    break;
                case DataTypeColumn.GridLookUpEdit:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
                    break;
                case DataTypeColumn.HyperLinkEdit:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
                    break;
                case DataTypeColumn.LookUpEdit:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                    break;
                case DataTypeColumn.ImageComboBox:
                    col.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
                    break;
            }
            if (width > 0)
            {
                col.Width = width;
            }

            grd.Columns.Add(col);
            return col;
        }
        #endregion

        /// <summary>
        /// So sánh giá trị các thuộc tính của 2 đối tượng
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// Create by: dvthang:20.04.2017
        public static bool CompareObject(object obj1, object obj2)
        {
            bool isEqual = true;
            if (obj1 == null && obj2 == null)
            {
                return true;
            }

            if (obj1 == null || obj2 == null)
            {
                return false;
            }

            //Lấy tất cả các thuộc tính của object để compare
            PropertyInfo[] props = obj1.GetType().GetProperties();
            foreach (var property in props)
            {
                if (ListColumnUnCheck.IndexOf(property.Name) == -1)
                {
                    var objValue = property.GetValue(obj1);
                    var anotherValue = property.GetValue(obj2);

                    if (!object.Equals(objValue, anotherValue))
                    {
                        isEqual = false;
                        return isEqual;
                    }
                }

            }
            return isEqual;
        }

        /// <summary>
        /// Hàm làm tròn số theo kiểu dữ liệu
        /// </summary>
        /// <param name="dValue">Giá trị cần làm trong</param>
        /// <param name="iFormatType">Kiểu làm trong</param>
        /// <returns>Trả về giá trị sau khi làm tròn</returns>
        /// Create by: dvthang:10.05.2017
        public static decimal Round(decimal dValue, FormatType iFormatType)
        {
            decimal dResult = dValue;
            if (dValue == 0)
            {
                return dResult;
            }
            else
            {
                switch (iFormatType)
                {
                    case FormatType.QuanlityFloat:
                        dResult = Math.Round(dValue, QuanlityFloat);
                        break;
                    case FormatType.QuanlityFloat_0:
                        dResult = Math.Round(dValue, QuanlityFloat_0);
                        break;
                    case FormatType.QuanlityFloat_1:
                        dResult = Math.Round(dValue, QuanlityFloat_1);
                        break;
                    case FormatType.UnitPrice:
                        dResult = Math.Round(dValue, UnitPrice);
                        break;
                    case FormatType.Amount:
                        dResult = Math.Round(dValue, Amount);
                        break;
                    case FormatType.Coefficient:
                        dResult = Math.Round(dValue, Coefficient);
                        break;
                }
            }

            return dResult;
        }

        /// <summary>
        /// Hàm làm tròn số theo kiểu dữ liệu
        /// </summary>
        /// <param name="dValue">Giá trị cần làm trong</param>
        /// <param name="decimals">Số chữ số sau phần thập phân</param>
        /// <returns>Trả về giá trị sau khi làm tròn</returns>
        /// Create by: dvthang:10.05.2017
        public static decimal Round(decimal dValue, int decimals)
        {
            if (dValue == 0)
            {
                return dValue;
            }
            return Math.Round(dValue, decimals);
        }

        /// <summary>
        /// Đăng ký event show form QuichSearch hoặc form danh mục thêm nhanh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Create by: dvthang:16.10.2016
        internal static void ShowForm(string quickSearchName, string aliasFormQuickAdd, string dictionaryName, object control, object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            EditorButton button = e.Button;
            if (button != null && button.Tag != null)
            {
                MFormBase frm = null;
                switch (button.Tag.ToString())
                {
                    case "QuickSearch":
                        frm = MCommon.FindFormByName(quickSearchName);
                        if (frm != null)
                        {
                            frm.ControlCallForm = control;
                            frm.Show();
                        }
                        break;
                    case "AddDictionnary":
                        if (!string.IsNullOrEmpty(aliasFormQuickAdd))
                        {
                            frm = MCommon.FindFormByName(aliasFormQuickAdd);
                        }
                        else
                        {
                            frm = MCommon.FindFormByName(dictionaryName);
                        }

                        if (frm != null)
                        {
                            frm.ControlCallForm = control;
                            frm.IsQuickAdd = true;
                            frm.BringToFront();
                            frm.FormAction = (int)FormAction.Add;
                            frm.EntityName = dictionaryName;
                            frm.ShowDialog();
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Hàm thực hiện next cell control
        /// </summary>
        /// <param name="mGridControl">Grid</param>
        public static void GridControlNextCell(MGridControl mGridControl)
        {
            var gridView = mGridControl.FirstView;
            if (gridView.FocusedColumn.VisibleIndex == gridView.VisibleColumns.Count - 1)
            {
                if (gridView.FocusedRowHandle == gridView.RowCount - 1)
                {
                    gridView.FocusedRowHandle = 0;
                }
                else
                {
                    gridView.FocusedRowHandle++;
                }
                gridView.FocusedColumn = gridView.Columns[0];
                gridView.ShowEditor();
            }
            else
            {
                int i = 0;
                while (true)
                {
                    i++;
                    if (gridView.FocusedColumn.VisibleIndex + i >= gridView.Columns.Count)
                    {
                        break;
                    }
                    var col = gridView.Columns[gridView.FocusedColumn.VisibleIndex + i];
                    if (col.Visible)
                    {
                        gridView.FocusedColumn = col;
                        gridView.ShowEditor();
                        break;
                    }

                }
            }
        }

        /// <summary>
        /// Hàm thực hiện previous cell control
        /// </summary>
        /// <param name="mGridControl">Grid</param>
        public static void GridControlPreviousCell(MGridControl mGridControl)
        {
            var gridView = mGridControl.FirstView;
            if (gridView.FocusedColumn.VisibleIndex==0)
            {
                int columnIndex = gridView.Columns.Count;
                while (columnIndex>0)
                {
                    columnIndex--;
                    var col = gridView.Columns[columnIndex];
                    if (col.Visible)
                    {
                        gridView.FocusedColumn = col;
                        gridView.ShowEditor();
                        break;
                    }

                }

            }
            else
            {
                if (gridView.FocusedColumn.VisibleIndex > 0)
                {
                    gridView.FocusedColumn = gridView.Columns[gridView.FocusedColumn.VisibleIndex-1];
                    gridView.ShowEditor();
                }
            }
        }

        /// <summary>
        /// Hàm thực hiện next cell control
        /// </summary>
        /// <param name="mGridControl">Grid</param>
        public static void GridControlUpDownCell(MGridControl mGridControl,bool isDown)
        {
            var gridView = mGridControl.FirstView;
            var colFocus = gridView.FocusedColumn;
            if (isDown)
            {
                if (gridView.FocusedRowHandle >= gridView.DataRowCount - 1)
                {
                    gridView.FocusedRowHandle = 0;
                }
                else
                {
                    gridView.FocusedRowHandle++;
                }
            }
            else
            {
                if (gridView.FocusedRowHandle == 0)
                {
                    gridView.FocusedRowHandle = gridView.DataRowCount-1;
                }
                else
                {
                    gridView.FocusedRowHandle--;
                }
            }
            gridView.FocusedColumn = colFocus;
            gridView.ShowEditor();
        }
    }
}
