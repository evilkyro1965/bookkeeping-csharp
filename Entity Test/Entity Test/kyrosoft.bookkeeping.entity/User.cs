using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kyrosoft.bookkeeping.entity
{
    [Table("user")]
    public class User:IdentifiableEntity
    {
        [Required]
        public String username { get; set; }
        
        [Required]
        public String password { get; set; }
    }
}
