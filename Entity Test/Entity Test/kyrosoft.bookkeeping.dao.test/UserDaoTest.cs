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
    class UserDaoTest
    {
        protected UserDao userDao;

        [SetUp]
        public void setup()
        {
            userDao = new UserDao();
            setupDB();
        }

        public void setupDB()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["bookkeeping"].ConnectionString;
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string[] schemaSql = getDBSchemaSql();
                    String queryStr = "";
                    for (int i = 0; i < schemaSql.Length; i++) 
                    {
                        MySqlCommand command = new MySqlCommand(schemaSql[i], conn);
                        command.ExecuteNonQuery();
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string[] getDBSchemaSql()
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, "schema.sql");

            string[] lines = System.IO.File.ReadAllLines(path);
            return lines;
        }


        [Test]
        public void createUser()
        {
            /*
            User user = new User();
            user.username = "john.doe";
            user.password = "12345";
            userDao.create(user);
            */
        }

    }
}
