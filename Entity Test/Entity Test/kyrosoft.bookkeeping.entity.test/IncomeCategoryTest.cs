using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace kyrosoft.bookkeeping.entity.test
{
    [TestFixture]
    class IncomeCategoryTest
    {
        [Test]
        public void createIncomeCategoryTest()
        {
            var context = new DaoContext();

            User user = context.Users.Find(1);
            TaxCategory tax = context.TaxCategories.Find(1);

            IncomeCategory incomeCategory = new IncomeCategory();
            incomeCategory.name = "income1";
            incomeCategory.user = user;
            incomeCategory.taxCategory = tax;
            incomeCategory.incomeType = IncomeExpenseType.BUSINESS;
            incomeCategory.createdBy = "john.doe";
            incomeCategory.createdDate = new DateTime(2008, 3, 9, 1, 2, 3);
            incomeCategory.updatedBy = "john.doe2";
            incomeCategory.updatedDate = new DateTime(2008, 3, 9, 1, 2, 3);
            incomeCategory.isDisabled = false;
            context.IncomeCategories.Add(incomeCategory);
            context.SaveChanges();
        }
    }
}
