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
        public string contactName { get; set; }
        public string contactEmail { get; set; }
        public string contactPhone { get; set; }
        public bool isPrimary { get; set; }

    }
}
