using MT.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class TransferData
    {
        public Guid Id { get; set; }

        public bool IsDictionary { get; set; }

        /// <summary>
        /// Đơn vị nhận
        /// </summary>
        public Guid? sDM_DonVi_Id_Nhap { get; set; }

        /// <summary>
        /// Đơn vị xuất
        /// </summary>
        public Guid sDM_DonVi_Id_Xuat { get; set; }

        public object Master { get; set; }

        public IList Details { get; set; }

        public Dictionary<string,IList> DicPK_Details { get; set; }
        public Dictionary<string,List<TransferData>> RelatedTableDatas { get; set; }
    }
}
