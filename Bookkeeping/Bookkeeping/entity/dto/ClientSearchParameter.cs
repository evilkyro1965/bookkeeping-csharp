using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrosoft.bookkeeping.entity.dto
{
    public class ClientSearchParameter:BaseSearchParameter
    {

        public string clientName { get; set; }
        public string address { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public int countryId { get; set; }
        public string websiteAddress { get; set; }
        public string email { get; set; }
        public string clientNotes { get; set; }
        public Double? hourlyRate { get; set; }

    }
}
