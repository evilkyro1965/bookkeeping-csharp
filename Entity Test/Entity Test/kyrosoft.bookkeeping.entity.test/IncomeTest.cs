using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace kyrosoft.bookkeeping.entity.test
{
    [TestFixture]
    class IncomeTest
    {
        [Test]
        public void CreateIncomeTest()
        {
            var context = new DaoContext();

            User user = context.Users.Find(1);
            IncomeCategory incomeCategory = context.IncomeCategories.Find(1);

            Income income = new Income();
            income.name = "Income1";
            income.date = new DateTime(2008, 3, 9, 16, 5, 7, 123);
            income.description = "lorem ipsum";
            income.incomeCategory = incomeCategory;
            income.amount = 10.01;
            income.user = user;
            context.Incomes.Add(income);
            context.SaveChanges();

        }
    }
}
