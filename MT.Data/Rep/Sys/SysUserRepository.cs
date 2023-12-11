using MT.Data.BO;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MT.Data.Rep
{
    public class SysUserRepository : MT.Data.Rep.BaseRepository<SysUser>
    {
        #region"ThuocTinh"

        #endregion
        #region "Constructor"
        public SysUserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion
        #region"PhuongThuc"


        //Lay Toan Bo Du Lieu Va sap xep theo ma
        public System.Data.DataTable GetAll()
        {
            string query = $"SELECT * FROM dbo.SysUser  ORDER BY FullName ASC";

            return this._unitOfWork.QueryDataTable(query);
        }

        //Lay Toan Bo Du Lieu Va sap xep theo ma
        public DataTable GetAllByCondition(Guid? roleId, Guid? orgId,string searchValue)
        {
            string sWhere = string.Empty;

            if (MT.Library.Utility.CheckForSQLInjection(searchValue))
            {
                return null;
            }
            if (roleId.HasValue)
            {
                sWhere += $" RoleId='{roleId.Value}'";
            }
            List<Guid> sDM_DonVi_Ids = new List<Guid>();
            if (orgId.HasValue && !"00000000-0000-0000-0000-000000000000".Equals(orgId.Value))
            {
                sDM_DonVi_Ids.Add(orgId.Value);
                //Nếu là đơn vị cha và có con theo cơ cấu tổ chức thì cộng tồn kho cho cả cha và con theo cơ cấu tổ chức
                string queryDonVi = $@"select ID from DM_DonVi where sParentId='{orgId.Value}'
                                         AND iType = 1";

                var donviIds = this._unitOfWork.Query<Guid>(queryDonVi);

                if (donviIds?.Count > 0)
                {
                    sDM_DonVi_Ids.AddRange(donviIds);
                }

            }

            if (sDM_DonVi_Ids.Count>0)
            {
                sWhere += $" OrganizationUnitId IN({string.Join(",", sDM_DonVi_Ids.Select(m => "'" + m + "'"))})";
            }
            if (!string.IsNullOrWhiteSpace(searchValue))
            {
                if (string.IsNullOrWhiteSpace(sWhere))
                {
                    sWhere = $" (UserName LIKE N'%{searchValue}%' OR [Fullname] LIKE N'%{searchValue}%' OR [Email] LIKE N'%{searchValue}%')";
                }
                else
                {
                    sWhere += $" AND (UserName LIKE N'%{searchValue}%' OR [Fullname] LIKE N'%{searchValue}%' OR [Email] LIKE N'%{searchValue}%')";
                }
            }
            if (string.IsNullOrWhiteSpace(sWhere))
            {
                sWhere = " 1=1 ";
            }
            if (sWhere.StartsWith("AND"))
            {
                sWhere = " 1=1 "+ sWhere;
            }
            var dt = this._unitOfWork.QueryDataTable("Proc_GetUserByOrgId",
                new Dictionary<string, object>
                {
                    ["OrganizationUnitId"] = MT.Library.SessionData.OrganizationUnitId,
                    ["sWhere"] = sWhere,
                    ["sColumns"] = "U.*"
                }, CommandType.StoredProcedure);
            return dt;
        }


        //Lay Toan Bo Du Lieu Va sap xep theo ma
        public System.Data.DataTable GetRoles()
        {
            string query = "SELECT Id,RoleName FROM dbo.SysRoles ORDER BY RoleName";
            return this._unitOfWork.QueryDataTable(query);
        }

        /// <summary>
        /// Kiểm tra mã đã tồn tại thì không cho thêm nữa
        /// </summary>
        /// <param name="userName">Tên đăng nhập</param>
        /// <param name="id">Id phòng</param>
        /// <returns></returns>
        public bool CheckExists(string userName, Guid? id)
        {
            string query = string.Empty;
            Dictionary<string, object> paraList = new Dictionary<string, object>()
            {
                { "UserName",userName }
            };

            if (id != null)
            {
                query = "IF EXISTS(SELECT top 1 Id from dbo.SysUser where UserName=@UserName AND Id<>@Id) SELECT 1 ELSE SELECT 0";
                paraList.Add("Id", id);
            }
            else
            {
                query = "IF EXISTS(SELECT top 1 Id from  dbo.SysUser where UserName=@UserName) SELECT 1 ELSE SELECT 0";
            }
            return this._unitOfWork.ExecuteScalar<bool>(query, paraList);
        }

        public bool CheckPass(string username, string oldpass)
        {
            oldpass = MT.Library.Utility.Encrypt(oldpass);

            Dictionary<string, object> arrayList = new Dictionary<string, object>()
                {
                    {"UserName",username },
                    {"Password",oldpass }
                };

            string query = "SELECT COUNT(*) FROM dbo.SysUser WHERE Username=@UserName AND Password=@Password ";
            return this._unitOfWork.ExecuteScalar<int>(query, arrayList) > 0;
        }

        public void ChangePass(string username, string oldpass, string newPass)
        {
            oldpass = MT.Library.Utility.Encrypt(oldpass);
            newPass = MT.Library.Utility.Encrypt(newPass);
            Dictionary<string, object> arrayList = new Dictionary<string, object>()
                {
                    {"UserName",username },
                    {"Oldpass",oldpass },
                    {"Newpass",newPass }
                };

            string query = @"UPDATE dbo.SysUser
		                        SET Password = @Newpass,ChangePass=GETDATE()
	                            WHERE UserName = @Username  And Password = @Oldpass";
            this._unitOfWork.Execute(query, arrayList);
        }

        public SysUser Login(string userName, string passWord)
        {
            passWord = MT.Library.Utility.Encrypt(passWord);
            Dictionary<string, object> arrayList = new Dictionary<string, object>()
                {
                    {"UserName",userName },
                    {"Password",passWord }
                };

            string query = @"select S.Id,S.UserName,S.FullName,S.RoleId,S.OrganizationUnitId, DV.sMaDonvi as OrganizationUnitCode,DV.sTenDonVi as OrganizationUnitName
	                        from dbo.SysUser S JOIN dbo.DM_DonVi DV ON S.OrganizationUnitId=DV.Id
	                        where s.Username = @Username and s.Password = @Password AND s.Active=1";

            return _unitOfWork.QueryFirstOrDefault<SysUser>(query, arrayList);
        }
        public SysUser LoginWithUSB(string userName)
        {
            Dictionary<string, object> arrayList = new Dictionary<string, object>()
                {
                    {"UserName",userName },
                };

            string query = @"select S.Id,S.UserName,S.Password,S.FullName,S.RoleId,S.OrganizationUnitId, DV.sMaDonvi as OrganizationUnitCode,DV.sTenDonVi as OrganizationUnitName
	                        from dbo.SysUser S JOIN dbo.DM_DonVi DV ON S.OrganizationUnitId=DV.Id
	                        where s.Username = @Username AND s.Active=1";

            return _unitOfWork.QueryFirstOrDefault<SysUser>(query, arrayList);
        }
        /// <summary>
        /// Lấy về danh sách Tài khoản đăng nhập
        /// </summary>
        public List<MT.Data.ViewModels.SelectedItem> GetUsers()
        {
            return  _unitOfWork.Query<MT.Data.ViewModels.SelectedItem>("SELECT Id as GuidId,Username as Text FROM dbo.SysUser ORDER BY Username");
        }


        /// <summary>
        /// Lấy về thời điểm đổi mật khẩu
        /// </summary>
        public DateTime GetPasswordChangeTime()
        {
            string query = $"SELECT ISNULL(ChangePass,dCreatedDate) FROM dbo.SysUser WHERE Id='{MT.Library.SessionData.UserId}'";

            return _unitOfWork.ExecuteScalar<DateTime>(query);
        }


        /// <summary>
        /// Lấy về quyền của người dùng
        /// </summary>
        public List<RolePermission> GetRolePermissionsByUser()
        {
           return _unitOfWork.Query<RolePermission>("Proc_GetPermissionUser", new
            {
                UserId = MT.Library.SessionData.UserId
            }, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Lấy về quyền của người dùng
        /// </summary>
        public bool IsAdministrator(Guid userId)
        {
            string query = $@"IF EXISTS(SELECT TOP 1 1 FROM dbo.SysUser S 
                            JOIN SysRoles SR ON S.RoleId=SR.ID WHERE SR.DictionaryKey=1  AND S.Id<>'{userId}') SELECT 1 ELSE SELECT 0";
            return _unitOfWork.ExecuteScalar<bool>(query);
        }

        /// <summary>
        /// Đếm số người dùng thuộc vai trò
        /// </summary>
        public int CountUserByRoleId(Guid roleId)
        {
            string query = $"SELECT count(*) FROM dbo.SysUser WHERE RoleId='{roleId}'";

            return _unitOfWork.ExecuteScalar<int>(query);
        }
        
        #endregion"PhuongThuc"
    }
}
