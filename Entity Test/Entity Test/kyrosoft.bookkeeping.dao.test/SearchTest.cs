using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using kyrosoft.bookkeeping.entity;

namespace kyrosoft.bookkeeping.dao.test
{
    [TestFixture]
    class SearchTest:BaseTest
    {

        [Test]
        public void searchTest()
        {
            SearchResult<User> searchResult = new SearchResult<User>();
        }

    }
}
