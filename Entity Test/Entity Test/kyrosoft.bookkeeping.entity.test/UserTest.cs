using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using kyrosoft.bookkeeping.entity;

namespace kyrosoft.bookkeeping.entity.test
{
    [TestFixture]
    class UserTest
    {

        [Test]
        public void createUser()
        {
            var context = new DaoContext();

            User user = new User();
            user.username = "john.doe";
            user.password = "password";
            context.Users.Add(user);
            context.SaveChanges();
        }


    }
}
