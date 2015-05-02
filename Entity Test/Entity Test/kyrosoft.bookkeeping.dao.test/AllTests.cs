using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Core;
using Microsoft.Practices.Unity;

namespace kyrosoft.bookkeeping.dao.test
{
    class AllTests
    {
        [Suite]
        public static TestSuite Suite
        {
            get
            {
                var unityContainer = new UnityContainer();

                // Register IGame so when dependecy is detected
                // it provides a TrivialPursuit instance
                unityContainer.RegisterType<IUserDao, UserDao>();
                var userDaoTest = unityContainer.Resolve<UserDaoTest>();

                TestSuite suite = new TestSuite("All Tests");
                suite.Add(userDaoTest);
                return suite;
            }
        }
    }
}
