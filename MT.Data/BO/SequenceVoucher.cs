using MT.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class SequenceVoucher:BaseEntity
    {
        public long Id { get; set; }

        public string sSo { get; set; }

        public string sChu { get; set; }

        public string sTenBang { get; set; }

        public Guid sDM_DonVi_Id { get; set; }

        public Guid sNguoiDung_Id { get; set; }

        public string sSuffix { get; set; }

        public bool bUsed { get; set; }

        public int iNam { get; set; }
    }
}
