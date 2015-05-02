using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kyrosoft.bookkeeping.entity
{
    [Table("client_contact")]
    public class ClientContact:IdentifiableEntity
    {
        [Required]
        public string contactName { get; set; }
        
        [Required]
        public string contactEmail { get; set; }
        
        [Required]
        public string contactPhone { get; set; }
        
        [Required]
        public bool isPrimary { get; set; }
        public int clientId { get; set; }

        public virtual Client client { get; set; }
    }
}
