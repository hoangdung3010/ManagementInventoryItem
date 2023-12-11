using MT.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.BO
{
    public class Resources 
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Tên resource
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
    }
}
