using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrosoft.bookkeeping.entity
{
    public class DisableEntity:AuditableEntity
    {
        public bool isDisabled { get; set; }
    }
}
