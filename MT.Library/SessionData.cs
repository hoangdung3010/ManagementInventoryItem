using Microsoft.Win32;
using MT.Library.BO;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Library
{
    public class SessionData
    {
        private static string _dataBaseName = string.Empty;

        private static string _userData = "sa";

        private static string _serverName = "(local)";

        private static string _passData = string.Empty;
        // Fields
        public static string DataBaseName
        {
            get {
                if (MT.Library.Utility.CheckForSQLInjection(_dataBaseName))
                {
                    throw new Exception($"Detect SQL Injection: {_dataBaseName}");
                }
                return  _dataBaseName;
            }
            set
            {
                if (MT.Library.Utility.CheckForSQLInjection(value))
                {
                    throw new Exception($"Detect SQL Injection: {value}");
                }
                _dataBaseName = value;
            }
        }

        public static string ServerName
        {
            get
            {
                if (MT.Library.Utility.CheckForSQLInjection(_serverName))
                {
                    throw new Exception($"Detect SQL Injection: {_serverName}");
                }
                return _serverName;
            }
            set
            {
                if (MT.Library.Utility.CheckForSQLInjection(value))
                {
                    throw new Exception($"Detect SQL Injection: {value}");
                }
                _serverName = value;
            }
        }


        public static string UserData
        {
            get
            {
                if (MT.Library.Utility.CheckForSQLInjection(_userData))
                {
                    throw new Exception($"Detect SQL Injection: {_userData}");
                }
                return _userData;
            }
            set
            {
                if (MT.Library.Utility.CheckForSQLInjection(value))
                {
                    throw new Exception($"Detect SQL Injection: {value}");
                }
                _userData = value;
            }
        }

        public static string PassData
        {
            get
            {
                if (MT.Library.Utility.CheckForSQLInjection(_passData))
                {
                    throw new Exception($"Detect SQL Injection: {_passData}");
                }
                return _passData;
            }
            set
            {
                if (MT.Library.Utility.CheckForSQLInjection(value))
                {
                    throw new Exception($"Detect SQL Injection: {value}");
                }
                _passData = value;
            }
        }
        public static string Factory = "System.Data.SqlClient";
        public static int iCheDoXacThuc = 2;
        private static string _connectString;



        //public static string VersionName = "Phiên bản V6, phát hành ngày 24/10/2022";
        //public static string VersionName = "Phiên bản V7, phát hành ngày 3/2/2023";
        // public static string VersionName = "Phiên bản V8, phát hành ngày 18/5/2023";
        public static string VersionName = "Phiên bản V9 phát hành ngày 12/6/2023";

        /// <summary>
        /// Tên app
        /// </summary>
        public static readonly string AppName = "PMQLVT";


        public static string ERROR = "Đã có lỗi xảy ra.";

        public static string ConnectString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectString))
                {
                    Read();
                }
                var builder = new SqlConnectionStringBuilder();
                builder.DataSource = ServerName;
                builder.InitialCatalog = DataBaseName;
                builder.UserID = UserData;
                builder.Password = PassData;
               
                if (iCheDoXacThuc == 2)
                {
                    builder.IntegratedSecurity = false;
                }
                else
                {
                    builder.IntegratedSecurity = true;
                }
                _connectString = builder.ToString();
                return _connectString;
            }
            set
            {
                _connectString = value;
            }
        }

        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        public static string UserName = "";

        /// <summary>
        /// Tên đầy đủ
        /// </summary>
        public static string FullName = "";

        /// <summary>
        /// Đơn vị đăng nhập
        /// </summary>
        public static Guid OrganizationUnitId;

        /// <summary>
        /// Mã Đơn vị đăng nhập
        /// </summary>
        public static string OrganizationUnitCode;

        /// <summary>
        /// Tên Đơn vị đăng nhập
        /// </summary>
        public static string OrganizationUnitName;

        /// <summary>
        /// 1: BCY;2QĐ;3:CA;4:ĐCQ
        /// </summary>
        public static int OrganizationUnitType;

        public static Guid RoleId;
        public static byte[] Picture = null;
        public static Guid UserId;

        public static readonly Guid AdministratorId = Guid.Parse("65301DBE-9371-471C-B94E-D60BB05B5B05");

        // Methods
        public static void Read()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(AppName);
            string str = null;
            try
            {
                str = (string)key.GetValue("ServerName");
                if (str != null)
                {
                    ServerName = str;
                }
                str = (string)key.GetValue("DatabaseName");
                if (str != null)
                {
                    DataBaseName = str;
                }
                str = (string)key.GetValue("UserData");
                if (str != null)
                {
                    UserData = str;
                }
                str = (string)key.GetValue("PassData");
                if (str != null)
                {
                    PassData = str;
                }
                str = (string)key.GetValue("ConnectString");
                if (str != null)
                {
                    ConnectString = str;
                }
                str = (string)key.GetValue("Factory");
                if (str != null)
                {
                    Factory = str;
                }
                str = (string)key.GetValue("UserName");
                if (str != null)
                {
                    UserName = str;
                }
                str = key.GetValue("iCheDoXacThuc")!= null? key.GetValue("iCheDoXacThuc").ToString():null;
                if (str != null)
                {
                    iCheDoXacThuc = Convert.ToInt16(str); ;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString(), exception.InnerException);
            }
        }

        public static void Save()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(AppName);
                key.SetValue("DatabaseName", DataBaseName);
                key.SetValue("ServerName", ServerName);
                key.SetValue("UserData", UserData);
                key.SetValue("PassData", PassData);
                key.SetValue("ConnectString", ConnectString);
                key.SetValue("Factory", Factory);
                key.SetValue("UserName", UserName);
                key.SetValue("iCheDoXacThuc", iCheDoXacThuc);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message.ToString(), exception.InnerException);
            }
        }

        public static Dictionary<int, string> DicPermissionName = new Dictionary<int, string>
        {
            {1,"Xem" },
            {2,"Thêm" },
            {4,"Nhân bản" },
            {8,"Sửa" },
            {16,"Xóa" },
            {32,"Phê duyệt" },
            {64,"Từ chối" },
            {128,"In" },
            {256,"Nhập khẩu" },
            {512,"Xuất khẩu" },
            {1024,"Phân quyền" },
            {2048,"Xem quyền" },
            {4096,"Xem chi tiết" },
            {8192,"Mức truy cập dữ liệu" },
        };

        public static List<RolePermission> RolePermissions = new List<RolePermission>();

        /// <summary>
        /// Thông tin thiết lập hệ thống
        /// </summary>
        public static List<DBOption> DBOptions { get; set; }

        /// <summary>
        /// Từ điển mapping giữa tên bảng và danh sách column
        /// </summary>
        public static ConcurrentDictionary<string, List<Columns>> MappingTableWithCols = new ConcurrentDictionary<string, List<Columns>>();

        /// <summary>
        /// Danh sách resource
        /// </summary>
        public static ConcurrentDictionary<string, string> Resources = new ConcurrentDictionary<string, string>();
    }

}
