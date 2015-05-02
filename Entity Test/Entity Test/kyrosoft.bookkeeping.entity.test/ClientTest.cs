using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace kyrosoft.bookkeeping.entity.test
{
    [TestFixture]
    public class ClientTest
    {
        [Test]
        public void createClient()
        {
            var context = new DaoContext();

            ClientContact contact1 = new ClientContact();
            contact1.contactName = "John Doe";
            contact1.contactEmail = "john.doe@lorem.com";
            contact1.contactPhone = "01421313";

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
            client.contacts.Add(contact1);

            context.Clients.Add(client);
            context.SaveChanges();
        }
    }
}
