using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kyrosoft.bookkeeping.entity
{
    public class AuditableEntity : LookupEntity
    {
        [Required]
        public string createdBy { get; set; }
        [Required]
        public DateTime createdDate { get; set; }
        [Required]
        public string updatedBy { get; set; }
        [Required]
        public DateTime updatedDate { get; set; }

    }
}
