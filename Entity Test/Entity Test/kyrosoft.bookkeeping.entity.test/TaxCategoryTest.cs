using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace kyrosoft.bookkeeping.entity.test
{
    [TestFixture]
    class TaxCategoryTest
    {
        [Test]
        public void createCategoryTest()
        {
            var context = new DaoContext();

            User user = context.Users.Find(1);

            TaxCategory taxCategory = new TaxCategory();
            taxCategory.name = "Tax1";
            taxCategory.user = user;
            taxCategory.createdBy = "john.doe";
            taxCategory.createdDate = new DateTime(2008, 3, 9, 1, 2, 3);
            taxCategory.updatedBy = "john.doe";
            taxCategory.updatedDate = new DateTime(2008, 3, 9, 1, 2, 3);
            taxCategory.isDisabled = false;
            context.TaxCategories.Add(taxCategory);
            context.SaveChanges();

        }
    }
}
