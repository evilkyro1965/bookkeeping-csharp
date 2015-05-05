using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kyrosoft.bookkeeping.entity;
using kyrosoft.bookkeeping.dao;
using NUnit.Framework;
using Microsoft.Practices.Unity;
using System.Configuration;

using System.IO;
using System.Reflection;
using MySql.Data.MySqlClient; 

namespace kyrosoft.bookkeeping.dao.test
{
    [TestFixture]
    class IncomeCategoryDaoTest:BaseTest
    {
        protected IncomeCategoryDao incomeCategoryDao;
        protected TaxCategoryDao taxCategoryDao;
        protected UserDao userDao;

        public IncomeCategoryDaoTest()
        {
            DaoContext daoContext = new DaoContext();
            incomeCategoryDao = new IncomeCategoryDao();
            incomeCategoryDao.daoContext = daoContext;
            taxCategoryDao = new TaxCategoryDao();
            taxCategoryDao.daoContext = daoContext;
            userDao = new UserDao();
            userDao.daoContext = daoContext;
        }

        [SetUp]
        public void setup()
        {
            setupDB();
        }

        [Test]
        public void createIncomeCategory()
        {
            User user = userDao.get(1);
            TaxCategory taxCategory = taxCategoryDao.get(1);

            IncomeCategory incomeCategory = new IncomeCategory();
            incomeCategory.name = "Income2";
            incomeCategory.user = user;
            incomeCategory.taxCategory = taxCategory;
            incomeCategory.incomeType = IncomeExpenseType.BUSINESS;
            incomeCategory.isDisabled = false;

            incomeCategoryDao.create(incomeCategory);

            Assert.AreNotEqual(0, incomeCategory.id);
        }

        [Test]
        public void updateIncomeCategory()
        {
            IncomeCategory incomeCategory = incomeCategoryDao.get(1);
            incomeCategory.name = "test";
            incomeCategory.incomeType = IncomeExpenseType.NON_BUSINESS;
            incomeCategory.isDisabled = false;
            int userId = incomeCategory.user.id;
            int taxId = incomeCategory.taxCategory.id;

            incomeCategoryDao.update(incomeCategory);

            IncomeCategory temp = incomeCategoryDao.get(1);
            Assert.AreEqual("test", temp.name);
            Assert.AreEqual(IncomeExpenseType.NON_BUSINESS, temp.incomeType);
        }

        [Test]
        public void deleteIncomeCategory()
        {
            int[] deleteIds = new int[] {1};
            incomeCategoryDao.delete(deleteIds);

            IncomeCategory incomeCategory = incomeCategoryDao.get(1);
            Assert.Null(incomeCategory);
        }

    }
}
