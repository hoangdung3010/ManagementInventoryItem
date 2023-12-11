using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class TepDinhKemRepository : MT.Data.Rep.BaseRepository<TepDinhKem>
    {
        #region "Constructor"
        public TepDinhKemRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Region"
        /// <summary>
        /// Lấy chi tiết sản phẩm theo kế hoạch nhập mới
        /// </summary>
        /// <param name="refId">ID cuar bảng chứa đính kèm</param>
        /// <param name="tableName">Tên bảng chứa đính kèm</param>
        public List<TepDinhKem> GetDataByRefId(Guid refId, string tableName)
        {
            string query = $@" SELECT ROW_NUMBER() over(order by SortOrder,dCreatedDate) as iSTT,
                               Id,sRefId,sTableName,sTen,sTenGoc,sExtention,fSize,sGhiChu,dCreatedDate,sCreatedBy
                               FROM TepDinhKem WHERE sRefId=@sRefId AND sTableName=@sTableName";

            return _unitOfWork.Query<TepDinhKem>(query, new { sRefId = refId, sTableName = tableName });
        }

        /// <summary>
        /// Lấy dữ liệu binary lưu trong database
        /// </summary>
        /// <param name="id">ID của bảng chứa đính kèm</param>
        public byte[] GetBinaryData(Guid id)
        {
            byte[] binaryData = null;
            string query = $@" SELECT byBinaryData FROM TepDinhKem WHERE Id=@Id";
            _unitOfWork.ProcessIDataReader(query, rd =>
             {
                 if (rd.Read() && !rd.IsDBNull(0))
                 {
                     binaryData = (byte[])rd.GetValue(0);
                 }
             }, new { Id = id });
            return binaryData;
        }
        #endregion
    }
}
