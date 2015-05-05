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
    [Table("client")]
    public class Client:OwnedEntity
    {
        public Client()
        {
            contacts = new List<ClientContact>();
        }

        [Required]
        public string clientName { get; set; }
        
        [Required]
        public string address { get; set; }
        public string addressLine2 { get; set; }
        
        [Required]
        public string city { get; set; }

        [Required]
        public string state { get; set; }
        public string zip { get; set; }

        [Required]
        public virtual Country country { get; set; }
        public string websiteAddress { get; set; }

        [Required]
        public string email { get; set; }
        public string clientNotes { get; set; }
        public double hourlyRate { get; set; }

        public virtual List<ClientContact> contacts { get; set; }

    }
}
