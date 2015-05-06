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
    class TaxCategoryDaoTest:BaseTest
    {
        protected TaxCategoryDao taxCategoryDao;
        protected UserDao userDao;

        [SetUp]
        public void setup()
        {
            DaoContext daoContext = new DaoContext();
            taxCategoryDao = new TaxCategoryDao();
            taxCategoryDao.daoContext = daoContext;
            userDao = new UserDao();
            userDao.daoContext = daoContext;
            setupDB();
        }

        [Test]
        public void createTaxCategory()
        {
            User user = userDao.get(1);

            TaxCategory taxCategory = new TaxCategory();
            taxCategory.name = "Tax1";
            taxCategory.user = user;
            taxCategory.isDisabled = false;

            taxCategoryDao.create(taxCategory);

            Assert.AreNotEqual(0, taxCategory.id);
        }

        [Test]
        public void updateTaxCategory()
        {
            User user = new User();
            user.username = "test";
            user.password = "12345";
            userDao.create(user);

            TaxCategory taxCat = taxCategoryDao.get(1);
            taxCat.name = "test";
            taxCat.user = user;
            taxCat.isDisabled = true;
            taxCategoryDao.update(taxCat);

            TaxCategory temp = taxCategoryDao.get(1);
            Assert.AreEqual("test", temp.name);
            Assert.AreEqual(user.id, temp.user.id);
            Assert.True(temp.isDisabled);
        }

        [Test]
        public void deleteTaxCategory()
        {
            int[] deleteIds = new int[] { 2 };
            taxCategoryDao.delete(deleteIds);

            TaxCategory temp = taxCategoryDao.get(2);
            Assert.IsNull(temp);
        }

        [Test]
        public void searchTaxCategory()
        {
            BaseSearchParameter searchParam = new BaseSearchParameter();
            searchParam.pageSize = 2;
            searchParam.page = 1;
            Dictionary<String, String> filter = new Dictionary<string, string>();
            filter.Add("name", "Tax1");
            searchParam.filter = filter;
            SearchResult<TaxCategory> searchResult = taxCategoryDao.search(searchParam);
            int count = searchResult.total;
        }

    }
}
