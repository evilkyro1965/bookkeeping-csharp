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
    class UserDaoTest:BaseTest
    {
        protected UserDao userDao;

        [SetUp]
        public void setup()
        {
            IUnityContainer container = new UnityContainer();
            DaoContext daoContext = new DaoContext();
            userDao = new UserDao();
            userDao.daoContext = daoContext;
            setupDB();
        }

        [Test]
        public void createUser()
        {
            User user = new User();
            user.username = "john.doe";
            user.password = "12345";
            userDao.create(user);
            Assert.AreNotEqual(0, user.id);
        }

        [Test]
        public void updateUser()
        {
            User user = userDao.get(1);
            user.username = "test";
            user.password = "test";
            userDao.update(user);

            User temp = userDao.get(1);
            Assert.AreEqual("test", temp.username);
            Assert.AreEqual("test", temp.password);
        }

        [Test]
        public void deleteUser()
        {
            User user = new User();
            user.username = "test";
            user.password = "12345";
            userDao.create(user);

            int[] deleteIds = new int[] { user.id };
            userDao.delete(deleteIds);

            User temp = userDao.get(user.id);
            Assert.IsNull(temp);
        }





    }
}
