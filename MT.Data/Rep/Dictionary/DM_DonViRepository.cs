using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.BO;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class DM_DonViRepository : MT.Data.Rep.BaseRepository<DM_DonVi>
    {
        #region "Constructor"
        public DM_DonViRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"
        /// <summary>
        /// Lấy về danh sách đơn vị con cấp 1 và đơn vị cùng cấp với đơn vị đăng nhập 
        /// </summary>
        /// <param name="id">Id đơn vị muốn xem</param>
        public IList<DM_DonVi> GetDonViConCap1VaDonViCungCap(Guid id)
        {
            return _unitOfWork.Query<DM_DonVi>("Proc_LayDonViConCap1VaDonViCungCap", new { Id = id, Level = 1 }, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Lấy về mức truy cập dữ liệu của nhân viên
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        public IList<DM_DonVi> GetEmployeeAccessLevel(Guid employeeId)
        {
            string query = $"select * from FN_GetEmployeeAccessLevel('{employeeId}') ORDER BY sMaDonvi";
            return _unitOfWork.Query<DM_DonVi>(query, new { EmployeeId = employeeId});
        }

        /// <summary>
        /// Lấy về danh sách đơn vị con cấp 1 và đơn vị cùng cấp với đơn vị đăng nhập 
        /// và Nhà cung cấp
        /// </summary>
        /// <param name="id">Id đơn vị muốn xem</param>
        public IList<DM_DonVi> GetDonViConCap1VaDonViCungCapVaNhaCungCap(Guid id, bool uuTienNhaCC)
        {
            var lsDM_DonVi = (List<DM_DonVi>)GetDonViConCap1VaDonViCungCap(id);
            var lsDM_NhaCC = _unitOfWork.Query<DM_DonVi>("SELECT Id, sMaNCC AS sMaDonVi, sTenNCC AS sTenDonVi, N'Nhà CC' AS sLoai FROM DM_NhaCC ORDER BY sMaNCC,sTenNCC, SortOrder", null);
            if (uuTienNhaCC)
            {
                lsDM_NhaCC.AddRange(lsDM_DonVi);
                return lsDM_NhaCC;
            }
            else
            {
                lsDM_DonVi.AddRange(lsDM_NhaCC);
                return lsDM_DonVi;
            }
        }

        /// <summary>
        /// Hàm sinh mã đơn vị theo đơn vị cha được chọn
        /// </summary>
        /// <param name="orgId">Id đơn vị cha</param>
        /// <returns>Mã đơn vị</returns>
        public string SinhMaDonVi(Guid? orgId, MT.Library.Enummation.MTEntityState entityState)
        {
            string query = string.Empty;
            string sMaDonVi = string.Empty;
            string maxCode = string.Empty;

            switch (entityState)
            {
                case Enummation.MTEntityState.Add:
                    if (!orgId.HasValue || orgId.Value.ToString().Equals("00000000-0000-0000-0000-000000000000", StringComparison.OrdinalIgnoreCase))
                    {
                        query = $"select top 1 sMaDonvi  from DM_DonVi where LEN(sMaDonVi)=2 order by sMaDonvi DESC";
                        maxCode = _unitOfWork.ExecuteScalar<string>(query);
                        if (string.IsNullOrWhiteSpace(maxCode))
                        {
                            sMaDonVi = "01";
                        }
                        else
                        {
                            sMaDonVi = (int.Parse(maxCode) + 1).ToString().PadLeft(2, '0');
                        }
                    }
                    else
                    {
                        query = $"select sMaDonvi  from DM_DonVi WHERE Id='{orgId.Value}'";
                        string codeParent = _unitOfWork.ExecuteScalar<string>(query);
                        query = $"select top 1 sMaDonvi  from DM_DonVi where sParentId='{orgId.Value}' order by sMaDonvi DESC";
                        maxCode = _unitOfWork.ExecuteScalar<string>(query);
                        if (string.IsNullOrWhiteSpace(maxCode))
                        {
                            sMaDonVi = $"{codeParent}01";
                        }
                        else
                        {

                            sMaDonVi = (int.Parse(maxCode) + 1).ToString().PadLeft(maxCode.ToCharArray().Length, '0');
                        }
                    }
                    break;
                case Enummation.MTEntityState.Duplicate:
                    query = $"select sMaDonvi  from DM_DonVi WHERE Id='{orgId.Value}'";
                    string codeDuplicate = _unitOfWork.ExecuteScalar<string>(query);
                    query = $"select top 1 sMaDonvi  from DM_DonVi where LEN(sMaDonVi)={codeDuplicate.ToCharArray().Length} order by sMaDonvi DESC";
                    maxCode = _unitOfWork.ExecuteScalar<string>(query);
                    sMaDonVi = (int.Parse(maxCode) + 1).ToString().PadLeft(maxCode.ToCharArray().Length, '0');
                    break;
            }


            return sMaDonVi;
        }

        /// <summary>
        /// Thực hiện validate dữ liệu trước khi xóa
        /// </summary>
        /// <param name="id">Id của bản ghi xóa</param>
        /// <param name="deleteError"></param>
        protected override void ValidateBeforeDelete(DM_DonVi entity, DeleteError deleteError)
        {
            base.ValidateBeforeDelete(entity, deleteError);
            string query = $"IF EXISTS(SELECT TOP 1 Id FROM dbo.DM_DonVi WHERE sParentId='{entity.Id}') SELECT 1 ELSE SELECT 0;";

            bool exists = _unitOfWork.ExecuteScalar<bool>(query);

            if (exists)
            {
                deleteError.Msg = "Bạn phải thực hiện xóa hết các đơn vị con thì mới được xóa đơn vị cha.";
            }

        }

        protected override void AfterCommitSave(BaseEntity entity)
        {
            base.AfterCommitSave(entity);

            DM_DonVi dM_DonVi=(DM_DonVi)entity;

            if (!string.IsNullOrWhiteSpace(dM_DonVi.sTenCotBC))
            {
                //Kiểm tra tên cột có trong picklist không, nếu không có thì thêm mới
                DM_PickList dM_PickList = _unitOfWork.QueryFirstOrDefault<DM_PickList>("select * from DM_PickList WHERE sTen=@sTen AND PickListType=1", new { sTen = dM_DonVi.sTenCotBC });

                if(dM_PickList==null || string.IsNullOrWhiteSpace(dM_PickList.sTen))
                {
                    int sortOrder= _unitOfWork.QueryFirstOrDefault<int>("select count(*) from DM_PickList WHERE PickListType=1");
                    var now = SysDateTime.Instance.Now();
                    _unitOfWork.SaveEntity(new DM_PickList
                    {
                        Id = Guid.NewGuid(),
                        sTen = dM_DonVi.sTenCotBC,
                        PickListType = 1,
                        SortOrder = sortOrder + 3,
                        dCreatedDate=now,
                        dModifiedDate=now,
                        sCreatedBy=MT.Library.SessionData.UserName,
                        sModifiedBy= MT.Library.SessionData.UserName
                    }, "DM_PickList",Enummation.MTEntityState.Add);
                }
            }

        }
        #endregion

        #region "Phuong Thuc"
        public List<DM_DonVi> GetAllByCondition(string searchValue)
        {
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchValue))
            {
                query = $"SELECT * FROM dbo.[View_DM_DonVi]  ORDER BY sMaDonVi ASC";

            }
            else
            {
                query = $@"DECLARE @CMD NVARCHAR(MAX);
                               DECLARE @SearchValue NVARCHAR(1000) = N'{searchValue}'; 
                               SELECT * FROM dbo.[View_DM_DonVi]
                               WHERE [sTenDonVi] LIKE N'%' + @SearchValue + '%'" +
                          $" OR [sMaDonVi] LIKE N'%' + @SearchValue + '%'" +
                          $" OR [sTenDonViRutGon] LIKE N'%' + @SearchValue + '%'" +
                          $" ORDER BY sMaDonVi ASC;" +
                          $" EXEC sp_executesql @CMD, N'@SearchValue NVARCHAR(1000)', @SearchValue;";

            }

            return this._unitOfWork.Query<DM_DonVi>(query);
        }

        /// <summary>
        /// Lấy đề quy danh sách cơ cấu tổ chức
        /// </summary>
        /// <param name="orgId">ID Cơ chấu tổ chức cần lấy</param>
        public List<DM_DonVi> GetRecursiveOrgById(Guid orgId)
        {
            return this._unitOfWork.Query<DM_DonVi>("Proc_GetRecursiveOrgById",new { OrgId= orgId },CommandType.StoredProcedure);
        }
        #endregion
    }
}
