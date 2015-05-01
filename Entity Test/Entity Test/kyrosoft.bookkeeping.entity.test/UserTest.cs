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
        /*
        [Test]
        public void test1()
        {
            var context = new DaoContext();

            User user = new User();
            user.username = "fahrur";
            user.password = "drowssap";
            context.Users.Add(user);
            context.SaveChanges();
        }
        */

        [Test]
        public void test2()
        {
            var context = new DaoContext();

            Client client = new Client();
            User user = context.Users.Find(1);
            Country country = context.Countries.Find(1);
            client.user = user;
            client.clientName = "Fahrur Razi";
            client.address = "Jalan Eka warni";
            client.addressLine2 = "test";
            client.city = "Medan";
            client.state = "Sumut";
            client.zip = "20143";
            client.websiteAddress = "Website";
            client.email = "evilkyro1965@yahoo.com";
            client.clientNotes = "lorem ipsum notes";
            client.hourlyRate = 100.00;
            client.country = country;

            context.Clients.Add(client);
            context.SaveChanges();
        }

    }
}
