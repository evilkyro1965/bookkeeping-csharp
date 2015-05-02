using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace kyrosoft.bookkeeping.entity
{
    [Table("expense_category")]
    public class ExpenseCategory:DisableEntity
    {
        [Required]
        public IncomeExpenseType expenseType { get; set; }
        [Required]
        public TaxCategory taxCategory { get; set; }
    }
}
