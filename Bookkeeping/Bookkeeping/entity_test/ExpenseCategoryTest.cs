using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace kyrosoft.bookkeeping.entity.test
{
    [TestFixture]
    class ExpenseCategoryTest
    {
        [Test]
        public void createExpenseCategoryTest()
        {
            var context = new DaoContext();

            User user = context.Users.Find(1);
            TaxCategory tax = context.TaxCategories.Find(1);

            ExpenseCategory expenseCategory = new ExpenseCategory();
            expenseCategory.name = "Expense1";
            expenseCategory.user = user;
            expenseCategory.taxCategory = tax;
            expenseCategory.expenseType = IncomeExpenseType.BUSINESS;
            expenseCategory.createdBy = "john.doe";
            expenseCategory.createdDate = new DateTime(2008, 3, 9, 16, 5, 7, 123);
            expenseCategory.updatedBy = "john.doe";
            expenseCategory.updatedDate = new DateTime(2011, 3, 9, 16, 5, 7, 123);
            context.ExpenseCategories.Add(expenseCategory);
            context.SaveChanges();
        }
    }
}
