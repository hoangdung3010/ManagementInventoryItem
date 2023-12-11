using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class ReportData : BaseEntity
    {
        #region Instance Properties

        public int Id { get; set; }

        public string ReportName { get; set; }

        public string StoreName { get; set; }

        public int? DictionaryKey { get; set; }

        public string FileName { get; set; }

        public int SortOrder { get; set; }

        public int StartRow { get; set; }

        /// <summary>
        /// Đánh dấu là mẫu in phiếu
        /// </summary>
        public bool IsPrintVoucher { get; set; }
        #endregion Instance Properties
    }

}
