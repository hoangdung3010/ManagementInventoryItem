using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class DuLieuGanNhatTrenFormRepository : MT.Data.Rep.BaseRepository<DuLieuGanNhatTrenForm>
    {
        #region "Constructor"
        public DuLieuGanNhatTrenFormRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        /// <summary>
        /// Xử lý lưu dữ liệu nhập gần nhất trên form
        /// </summary>
        /// <param name="entity"></param>
        protected override void PreSaveData(BaseEntity entity)
        {
            base.PreSaveData(entity);
            DuLieuGanNhatTrenForm duLieuGanNhatTrenForm = (DuLieuGanNhatTrenForm)entity;
            string query = $@"DELETE FROM dbo.DuLieuGanNhatTrenForm WHERE sUserId='{MT.Library.SessionData.UserId}' AND sTableName=@sTableName";

            _unitOfWork.Execute(query, new { sTableName = duLieuGanNhatTrenForm.sTableName });

        }


        /// <summary>
        /// Lấy dữ liệu gần nhất trên form
        /// </summary>
        /// <param name="tableName">Tên bảng</param>
        public DuLieuGanNhatTrenForm GetNhatTrenForm(string tableName)
        {
            string query = $@"SELECT sFormData FROM dbo.DuLieuGanNhatTrenForm WHERE sUserId='{MT.Library.SessionData.UserId}' AND sTableName=@sTableName";

           return _unitOfWork.QueryFirstOrDefault<DuLieuGanNhatTrenForm>(query, new { sTableName = tableName });
        }
    }
}
