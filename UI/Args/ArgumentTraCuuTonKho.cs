using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI
{
    class ArgumentTraCuuTonKho
    {
        public Guid OrganizationUnitId { get; set; }
        
        public List<Guid> sDM_SanPham_Ids { get; set; }

        public string sMaVach { get; set; }

        /// <summary>
        /// Chỉ hiển thị hàng còn tồn
        /// </summary>
        public bool IsExistssMaVachPositive { get; set; }

        /// <summary>
        /// Chỉ xem tồn tại kho
        /// </summary>
        public bool IsExistsAtStock { get; set; }

        /// <summary>
        /// Mã vạch thực tế tồn trong kho
        /// </summary>
        public bool IsExistsRealInStock { get; set; }
    }
}
