using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kyrosoft.bookkeeping.entity
{
    [Table("income_category")]
    public class IncomeCategory:DisableEntity
    {
        [Column("incomeType")]
        public IncomeExpenseType incomeType { get; set; }

        public virtual TaxCategory taxCategory { get; set; }
    }
}
