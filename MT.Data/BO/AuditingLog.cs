using MT.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class AuditingLog:BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Tên chức năng
        /// </summary>
        public string FunctionName { get; set; }
        /// <summary>
        /// Thời điểm log
        /// </summary>
        public DateTime LogTime { get; set; }

        /// <summary>
        /// Id của người ghi log
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Hành động
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// Tham chiếu
        /// </summary>
        public string EntityInfo { get; set; }
        /// <summary>
        /// Mô tả hành động
        /// </summary>
        public string Description { get; set; }
    }
}
