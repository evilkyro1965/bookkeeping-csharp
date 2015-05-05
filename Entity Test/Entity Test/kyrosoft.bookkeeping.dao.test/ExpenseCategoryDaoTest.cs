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
    class ExpenseCategoryDaoTest : BaseTest
    {
        protected ExpenseCategoryDao expenseCategoryDao;
        protected TaxCategoryDao taxCategoryDao;
        protected UserDao userDao;

        public ExpenseCategoryDaoTest()
        {
            DaoContext daoContext = new DaoContext();
            expenseCategoryDao = new ExpenseCategoryDao();
            expenseCategoryDao.daoContext = daoContext;
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
        public void createExpenseCategory()
        {
            User user = userDao.get(1);
            TaxCategory taxCategory = taxCategoryDao.get(1);

            ExpenseCategory expenseCategory = new ExpenseCategory();
            expenseCategory.name = "Expense1";
            expenseCategory.user = user;
            expenseCategory.taxCategory = taxCategory;
            expenseCategory.expenseType = IncomeExpenseType.BUSINESS;
            expenseCategory.isDisabled = false;

            expenseCategoryDao.create(expenseCategory);

            Assert.AreNotEqual(0, expenseCategory.id);
        }

        [Test]
        public void updateExpenseCategory()
        {
            ExpenseCategory expenseCategory = expenseCategoryDao.get(1);
            expenseCategory.name = "test";
            expenseCategory.expenseType = IncomeExpenseType.NON_BUSINESS;
            expenseCategory.isDisabled = false;
            int userId = expenseCategory.user.id;
            int taxId = expenseCategory.taxCategory.id;

            expenseCategoryDao.update(expenseCategory);

            ExpenseCategory temp = expenseCategoryDao.get(1);
            Assert.AreEqual("test", temp.name);
            Assert.AreEqual(IncomeExpenseType.NON_BUSINESS, temp.expenseType);
        }

        [Test]
        public void deleteExpenseCategory()
        {
            int[] deleteIds = new int[] {2};
            expenseCategoryDao.delete(deleteIds);

            ExpenseCategory expenseCategory = expenseCategoryDao.get(2);
            Assert.Null(expenseCategory);
        }

    }
}
