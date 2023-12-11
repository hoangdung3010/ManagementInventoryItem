using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.Rep
{
   public class RolePermissionRepository:MT.Data.Rep.BaseRepository<BaseEntity>
    {
        public RolePermissionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Lấy về giá trị quyển theo vai trò và id của form
        /// </summary>
        /// <param name="roleId">Id vai trò</param>
        /// <param name="formId">Id của form</param>
        public int GetPermissionValue(Guid roleId, string formId)
        {
            string query = $"SELECT Permission FROM dbo.RolePermission WHERE RoleId='{roleId}' AND FormId='{formId}'";

           return  _unitOfWork.ExecuteScalar<int>(query);
        }

        /// <summary>
        /// Lấy về giá trị quyển theo vai trò và id của form
        /// </summary>
        /// <param name="formId">Id form</param>
        /// <param name="permission">Quyền</param>
        /// <param name="roleId">Id vai trò</param>
        public bool SaveRolePemission(string formId,int permission,Guid roleId)
        {
           return _unitOfWork.Execute("Proc_SavePermissionRole", new
            { Formid = formId, Permission = permission, RoleId = roleId }, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Lấy về giá trị quyển theo vai trò và id của form
        /// </summary>
        /// <param name="formId">Id form</param>
        /// <param name="permission">Quyền</param>
        /// <param name="roleId">Id vai trò</param>
        public List<MT.Library.RolePermission> GetRolePemissions(Guid roleId)
        {
            return _unitOfWork.Query<MT.Library.RolePermission>("[Proc_GetPermissionRole]", new
            { RoleId = roleId }, CommandType.StoredProcedure);

        }
    }
}
