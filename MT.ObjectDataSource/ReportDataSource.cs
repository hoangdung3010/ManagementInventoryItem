using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.ObjectDataSource
{
    public class ReportDataSource
    {
        private IUnitOfWork _unitOfWork;

        private string _connectionString;

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = MT.Library.SessionData.ConnectString;
                }
                if (_unitOfWork == null)
                {
                    _unitOfWork = new UnitOfWork(_connectionString);
                }
                return _unitOfWork;
            }
        }

        public string ReportTitle { get; set; }

        /// <summary>
        /// Khởi tạo dữ liệu cho đối tượng
        /// </summary>
        /// <param name="id">Id của bản ghi master</param>
        /// <param name="tableName">Tên bảng</param>
        public virtual void InitData(object id, string tableName)
        {

        }
    }
}
