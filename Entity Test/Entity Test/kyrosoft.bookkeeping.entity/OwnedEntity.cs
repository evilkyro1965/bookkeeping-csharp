using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kyrosoft.bookkeeping.entity
{
    public abstract class OwnedEntity:IdentifiableEntity
    {
        [Required]
        public User user { get; set; }
    }
}
