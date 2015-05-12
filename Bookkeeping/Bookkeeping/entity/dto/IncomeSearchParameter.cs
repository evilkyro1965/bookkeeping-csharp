using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrosoft.bookkeeping.entity.dto
{
    public class IncomeSearchParameter:BaseSearchParameter
    {
        public DateTime? date { get; set; }
        public string description { get; set; }
        public int incomeCategoryId { get; set; }
        public Double? amount { get; set; }
    }
}
