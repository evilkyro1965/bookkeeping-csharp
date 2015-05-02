using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kyrosoft.bookkeeping.entity
{
    [Table("expense")]
    public class Expense:LookupEntity
    {
        public DateTime date { get; set; }
        public string description { get; set; }
        public ExpenseCategory expenseCategory { get; set; }
        public double amount { get; set; }
    }
}
