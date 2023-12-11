using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library.Extensions;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class EmployeeAccessLevelRepository : MT.Data.Rep.BaseRepository<EmployeeAccessLevel>
    {
        #region "Constructor"
        public EmployeeAccessLevelRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        /// <summary>
        /// Lưu mức truy cập dữ liệu
        /// </summary>
        /// <param name="employeeId">Nhân viên id</param>
        /// <param name="orgIds">Danh sách cơ cấu tổ chức</param>
        /// <returns>true thành công, ngược lại thất bại</returns>
        public bool SaveEmployeeAccessLevel(Guid employeeId,List<Guid> orgIds) 
        {
            string query = $"DELETE FROM EmployeeAccessLevel WHERE EmployeeId='{employeeId}'";

            _unitOfWork.Execute(query);
            if (orgIds?.Count > 0)
            {
                var now = SysDateTime.Instance.Now();
                foreach (var item in orgIds)
                {
                    _unitOfWork.SaveEntity(new EmployeeAccessLevel
                    {
                        Id=Guid.NewGuid(),
                        EmployeeId = employeeId,
                        OrganizationUnitId = item,
                        CreatedBy = MT.Library.SessionData.FullName,
                        CreatedDate = now
                    }, "EmployeeAccessLevel", Library.Enummation.MTEntityState.Add);
                }
            }
            return true;
        }


        /// <summary>
        /// Lấy về mức truy cập của nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên</param>
        /// <returns></returns>
        public List<Guid> GetAccessLevelByEmployeeId(Guid employeeId)
        {
            string query = $"SELECT OrganizationUnitId FROM EmployeeAccessLevel WHERE EmployeeId='{employeeId}'";

           return _unitOfWork.Query<Guid>(query);
        }
    }
}
