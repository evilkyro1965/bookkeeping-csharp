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
    class IncomeDaoTest:BaseTest
    {
    
        protected IncomeDao incomeDao;
        protected IncomeCategoryDao incomeCategoryDao;
        protected TaxCategoryDao taxCategoryDao;
        protected UserDao userDao;

        public IncomeDaoTest()
        {
            DaoContext daoContext = new DaoContext();
            incomeCategoryDao = new IncomeCategoryDao();
            incomeCategoryDao.daoContext = daoContext;
            taxCategoryDao = new TaxCategoryDao();
            taxCategoryDao.daoContext = daoContext;
            userDao = new UserDao();
            userDao.daoContext = daoContext;
            incomeDao = new IncomeDao();
            incomeDao.daoContext = daoContext;
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
            IncomeCategory incomeCategory = incomeCategoryDao.get(1);
            
            Income income = new Income();
            income.name = "Income1";
            income.description = "lorem ipsum";
            income.incomeCategory = incomeCategory;
            income.user = user;
            income.amount = 1.0;
            income.date = new DateTime(2008, 3, 9, 1, 2, 3);

            incomeDao.create(income);
            Assert.AreNotEqual(0, income.id);
        }

        [Test]
        public void updateIncome()
        {
            Income income = incomeDao.get(1);
            income.name = "test";
            income.description = "lorem ipsum";
            int incomeCatId = income.incomeCategory.id;
            int userId = income.user.id;
            income.amount = 2.0;
            income.date = new DateTime(2008, 3, 9, 1, 2, 3);

            incomeDao.update(income);

            Income temp = incomeDao.get(1);
            Assert.AreEqual("test", temp.name);
            Assert.AreEqual(2.0, temp.amount);
        }

        [Test]
        public void deleteIncome()
        {
            int[] deleteIds = new int[] { 1 };
            incomeDao.delete(deleteIds);

            Income income = incomeDao.get(1);
            Assert.Null(income);
        }

    }
}
