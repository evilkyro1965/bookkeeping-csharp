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
            taxCategory.name = "test";
            taxCategory.user = user;
            taxCategory.createdBy = "john.doe";
            taxCategory.createdDate = new DateTime(2008, 3, 9, 16, 5, 7, 123);
            taxCategory.updatedBy = "john.doe2";
            taxCategory.updatedDate = new DateTime(2011, 3, 9, 16, 5, 7, 123); 
            context.TaxCategories.Add(taxCategory);
            context.SaveChanges();

        }
    }
}
