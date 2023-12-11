using MT.Data.BO;
using MT.Library.UW;
using System.Collections.Generic;

namespace MT.Data.Rep
{
    public class SysRoleRepository : MT.Data.Rep.BaseRepository<SysRole>
    {
        #region"ThuocTinh"

        #endregion
        #region "Constructor"
        public SysRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion
        #region"PhuongThuc"

        //Lay Toan Bo Du Lieu Va sap xep theo ma
        public System.Data.DataTable GetAll()
        {
            string query = $"SELECT * FROM dbo.[View_Roles]  ORDER BY RoleName ASC";

            return this._unitOfWork.QueryDataTable(query);
        }

        //Lay Toan Bo Du Lieu Va sap xep theo ma
        public System.Data.DataTable GetAllByCondition(string searchValue)
        {
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchValue))
            {
                query = $"SELECT * FROM dbo.[View_Roles]  ORDER BY RoleName ASC";

            }
            else
            {
                query = $@"DECLARE @CMD NVARCHAR(MAX);
                               DECLARE @SearchValue NVARCHAR(1000) = '{searchValue}'; 
                               SELECT * FROM dbo.SysRoles
                               WHERE [RoleName] LIKE N'%' + @SearchValue + '%'" +
                          $" ORDER BY RoleName ASC;" +
                          $" EXEC sp_executesql @CMD, N'@SearchValue NVARCHAR(1000)', @SearchValue;";

            }

            return this._unitOfWork.QueryDataTable(query);
        }


        //Lay Toan Bo Du Lieu Va sap xep theo ma
        public System.Data.DataTable GetRoles()
        {
            string query = "SELECT * FROM dbo.SysRoles WHERE Active=1 ORDER BY Id";
            return this._unitOfWork.QueryDataTable(query);
        }

        /// <summary>
        /// Kiểm tra mã đã tồn tại thì không cho thêm nữa
        /// </summary>
        /// <param name="userName">Tên đăng nhập</param>
        /// <param name="id">Id phòng</param>
        /// <returns></returns>
        public bool CheckExists(string userName, object id)
        {
            string query = string.Empty;
            Dictionary<string, object> paraList = new Dictionary<string, object>()
            {
                { "RoleName",userName }
            };

            if (id != null)
            {
                query = "IF EXISTS(SELECT top 1 Id from dbo.SysRoles where RoleName=@RoleName AND Id<>@Id) SELECT 1 ELSE SELECT 0";
                paraList.Add("Id", id);
            }
            else
            {
                query = "IF EXISTS(SELECT top 1 Id from  dbo.SysRoles where RoleName=@RoleName) SELECT 1 ELSE SELECT 0";
            }

            return this._unitOfWork.ExecuteScalar<bool>(query, paraList);
        }


        #endregion"PhuongThuc"
    }
}
