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
    class ExpenseDaoTest:BaseTest
    {
        protected ExpenseDao expenseDao;
        protected ExpenseCategoryDao expenseCategoryDao;
        protected TaxCategoryDao taxCategoryDao;
        protected UserDao userDao;

        public ExpenseDaoTest()
        {
            DaoContext daoContext = new DaoContext();
            expenseCategoryDao = new ExpenseCategoryDao();
            expenseCategoryDao.daoContext = daoContext;
            taxCategoryDao = new TaxCategoryDao();
            taxCategoryDao.daoContext = daoContext;
            userDao = new UserDao();
            userDao.daoContext = daoContext;
            expenseDao = new ExpenseDao();
            expenseDao.daoContext = daoContext;
        }

        [SetUp]
        public void setup()
        {
            setupDB();
        }

        [Test]
        public void createIncome()
        {
            User user = userDao.get(1);
            ExpenseCategory expenseCategory = expenseCategoryDao.get(1);

            Expense expense = new Expense();
            expense.name = "Expense1";
            expense.description = "lorem ipsum";
            expense.expenseCategory = expenseCategory;
            expense.user = user;
            expense.amount = 1.0;
            expense.date = new DateTime(2008, 3, 9, 1, 2, 3);

            expenseDao.create(expense);
            Assert.AreNotEqual(0, expense.id);
        }

        [Test]
        public void updateIncome()
        {
            Expense expense = expenseDao.get(1);
            expense.name = "test";
            expense.description = "lorem ipsum";
            int expenseCatId = expense.expenseCategory.id;
            int userId = expense.user.id;
            expense.amount = 2.0;
            expense.date = new DateTime(2008, 3, 9, 1, 2, 3);

            expenseDao.update(expense);

            Expense temp = expenseDao.get(1);
            Assert.AreEqual("test", temp.name);
            Assert.AreEqual(2.0, temp.amount);
        }

        [Test]
        public void deleteIncome()
        {
            int[] deleteIds = new int[] { 1 };
            expenseDao.delete(deleteIds);

            Expense expense = expenseDao.get(1);
            Assert.Null(expense);
        }
    }
}
