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
    class ClientDaoTest : BaseTest
    {
        protected ClientDao clientDao;

        public ClientDaoTest()
        {
            DaoContext daoContext = new DaoContext();
            clientDao = new ClientDao();
            clientDao.daoContext = daoContext;
        }
        
        [SetUp]
        public void setup()
        {
            setupDB();
        }

        [Test]
        public void createClient()
        {

            ClientContact contact1 = new ClientContact();
            contact1.contactName = "John Doe";
            contact1.contactEmail = "john.doe@lorem.com";
            contact1.contactPhone = "01421313";
            contact1.isPrimary = true;

            Client client = new Client();
            User user = clientDao.daoContext.Users.Find(1);
            Country country = clientDao.daoContext.Countries.Find(1);
            client.user = user;
            client.clientName = "John Doe";
            client.address = "Fifth Avenue";
            client.addressLine2 = "test";
            client.city = "New York";
            client.state = "Arizona";
            client.zip = "123";
            client.websiteAddress = "johndoe.com";
            client.email = "john.doe@test.com";
            client.clientNotes = "lorem ipsum notes";
            client.hourlyRate = 100.00;
            client.country = country;
            client.contacts.Add(contact1);

            clientDao.create(client);
            Assert.AreNotEqual(0, client.id);
        }

        [Test]
        public void updateClient()
        {
            Client client = clientDao.get(1);
            int userId = client.user.id;
            int countryId = client.country.id;
            client.clientName = "test";

            clientDao.update(client);

            Client temp = clientDao.get(1);
            Assert.AreEqual("test", temp.clientName);
        }

        [Test]
        public void deleteClient()
        {
            int[] deleteIds = new int[] { 2 };
            clientDao.delete(deleteIds);

            Client client = clientDao.get(2);
            Assert.Null(client);
        }

    }
}
