using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.UW;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class Phieu_NhapSanPhamMoi_CT_PhuKienRepository : MT.Data.Rep.BaseRepository<Phieu_NhapSanPhamMoi_CT_PhuKien>
    {
        #region "Constructor"
        public Phieu_NhapSanPhamMoi_CT_PhuKienRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion
    }
}
