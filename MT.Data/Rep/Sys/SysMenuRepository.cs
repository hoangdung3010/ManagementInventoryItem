using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library.Extensions;
using MT.Library.UW;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class SysMenuRepository : MT.Data.Rep.BaseRepository<SysMenu>
    {
        #region "Constructor"
        public SysMenuRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Sub/Func"
        /// <summary>
        /// Lấy về danh sách menu
        /// </summary>
        public List<SysMenu> GetSysMenus()
        {
            string query = "SELECT * FROM SysMenu WHERE Active=1 ORDER BY SortOrder";
            var sysMenus = _unitOfWork.Query<SysMenu>(query);
            return (List<SysMenu>)sysMenus.ToTreeInt();
        }
        #endregion
    }
}
