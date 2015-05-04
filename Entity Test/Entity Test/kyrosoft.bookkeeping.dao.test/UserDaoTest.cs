using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kyrosoft.bookkeeping.entity;
using kyrosoft.bookkeeping.dao;
using NUnit.Framework;
using Microsoft.Practices.Unity;

namespace kyrosoft.bookkeeping.dao.test
{
    [TestFixture]
    class UserDaoTest
    {
        protected UserDao userDao;

        [SetUp]
        public void setup()
        {
            userDao = new UserDao();
        }

        [Test]
        public void createUser()
        {
            User user = new User();
            user.username = "john.doe";
            user.password = "12345";
            userDao.add(user);
        }

    }
}
