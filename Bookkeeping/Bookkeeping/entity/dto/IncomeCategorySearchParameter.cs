using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrosoft.bookkeeping.entity.dto
{
    public class IncomeCategorySearchParameter:BaseSearchParameter
    {
        public Boolean? isDisabled { get; set; }

        public IncomeExpenseType? incomeType { get; set; }

        public int taxCategoryId { get; set; }

    }
}
