using MT.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class NHATKY:BaseEntity
    {
        [Key]
        public long Id { get; set; }

        public string Username { get; set; }

        public string Program { get; set; }

        public string Timein { get; set; }

        public DateTime Datein { get; set; }

        public string Timeout { get; set; }

        public DateTime Dateout { get; set; }

        public long Timeuse { get; set; }

        public DateTime Dateuse { get; set; }

        public string handle { get; set; }
    }
}
