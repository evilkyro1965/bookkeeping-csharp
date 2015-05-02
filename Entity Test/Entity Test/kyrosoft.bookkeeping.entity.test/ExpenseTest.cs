using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace kyrosoft.bookkeeping.entity.test
{
    [TestFixture]
    class ExpenseTest
    {

        [Test]
        public void CreateExpenseTest()
        {
            var context = new DaoContext();

            User user = context.Users.Find(1);
            ExpenseCategory expenseCategory = context.ExpenseCategories.Find(2);

            Expense expense = new Expense();
            expense.name = "expense1";
            expense.date = new DateTime(2008, 3, 9, 16, 5, 7, 123);
            expense.description = "lorem ipsum";
            expense.expenseCategory = expenseCategory;
            expense.amount = 10.01;
            expense.user = user;
            context.Expenses.Add(expense);
            context.SaveChanges();
        }

    }
}
