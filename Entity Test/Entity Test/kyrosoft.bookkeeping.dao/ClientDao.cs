using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kyrosoft.bookkeeping.entity;
using System.Data.SqlClient;
using System.Data.Entity;

namespace kyrosoft.bookkeeping.dao
{
    public class ClientDao:BaseDao<Client>,IClientDao
    {
        public void create(Client client)
        {
            try
            {
                daoContext.Clients.Add(client);
                daoContext.SaveChanges();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void update(Client client)
        {
            try
            {
                var entry = daoContext.Entry<Client>(client);
                entry.State = EntityState.Modified;
                daoContext.SaveChanges();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void delete(int[] ids)
        {
            try
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    Client client = daoContext.Clients.Find(ids[i]);
                    if (client == null)
                        throw new Exception("Client with id:" + ids[i] + " is not found!");
                    daoContext.Clients.Remove(client);
                    daoContext.SaveChanges();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public Client get(int id)
        {
            try
            {
                Client client = daoContext.Clients.Find(id);
                return client;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
    }
}
