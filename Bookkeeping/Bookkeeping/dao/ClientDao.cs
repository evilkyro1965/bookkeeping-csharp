using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kyrosoft.bookkeeping.entity;
using kyrosoft.bookkeeping.entity.dto;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq.Expressions;
using PredicateExtensions;

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

        public SearchResult<Client> search(ClientSearchParameter parameter)
        {
            int page = parameter.page;
            int total = parameter.pageSize;

            var predicat = PredicateExtensions.PredicateExtensions.Begin<Client>();

            if (parameter.clientName != null && parameter.clientName != "")
            {
                string clientName = parameter.clientName.ToLower();
                Expression<Func<Client, bool>> filterName = c => c.clientName.ToLower().Contains(clientName);
                predicat = predicat.And(filterName);
            }
            if (parameter.userId != 0)
            {
                int userId = parameter.userId;
                Expression<Func<Client, bool>> filterUser = c => c.user.id == userId;
                predicat = predicat.And(filterUser);
            }

            if (parameter.address != null && parameter.address != "")
            {
                string address = parameter.address.ToLower();
                Expression<Func<Client, bool>> filter = c => c.address.ToLower().Contains(address);
                predicat = predicat.And(filter);
            }
            if (parameter.addressLine2 != null && parameter.addressLine2 != "")
            {
                string addressLine2 = parameter.addressLine2.ToLower();
                Expression<Func<Client, bool>> filter = c => c.addressLine2.ToLower().Contains(addressLine2);
                predicat = predicat.And(filter);
            }
            if (parameter.city != null && parameter.city != "")
            {
                string city = parameter.city.ToLower();
                Expression<Func<Client, bool>> filter = c => c.city.ToLower().Contains(city);
                predicat = predicat.And(filter);
            }
            if (parameter.state != null && parameter.state != "")
            {
                string state = parameter.state.ToLower();
                Expression<Func<Client, bool>> filter = c => c.state.ToLower().Contains(state);
                predicat = predicat.And(filter);
            }
            if (parameter.zip != null && parameter.zip != "")
            {
                string zip = parameter.zip.ToLower();
                Expression<Func<Client, bool>> filter = c => c.zip.ToLower().Contains(zip);
                predicat = predicat.And(filter);
            }
            if (parameter.countryId != 0)
            {
                int countryId = parameter.countryId;
                Expression<Func<Client, bool>> filter = c => c.country.id == countryId;
                predicat = predicat.And(filter);
            }
            if (parameter.websiteAddress != null && parameter.websiteAddress != "")
            {
                string websiteAddress = parameter.websiteAddress.ToLower();
                Expression<Func<Client, bool>> filter = c => c.websiteAddress.ToLower().Contains(websiteAddress);
                predicat = predicat.And(filter);
            }
            if (parameter.email != null && parameter.email != "")
            {
                string email = parameter.email.ToLower();
                Expression<Func<Client, bool>> filter = c => c.email.ToLower().Contains(email);
                predicat = predicat.And(filter);
            }
            if (parameter.clientNotes != null && parameter.clientNotes != "")
            {
                string clientNotes = parameter.clientNotes.ToLower();
                Expression<Func<Client, bool>> filter = c => c.clientNotes.ToLower().Contains(clientNotes);
                predicat = predicat.And(filter);
            }
            if (parameter.hourlyRate != null)
            {
                Double? hourlyRate = parameter.hourlyRate;
                Expression<Func<Client, bool>> filter = c => c.hourlyRate == hourlyRate;
                predicat = predicat.And(filter);
            }




            SearchResult<Client> ret = null;
            try
            {
                var query = daoContext.Clients.Where(predicat)
                    .OrderBy(t => t.clientName)
                    .Skip((page - 1) * total)
                    .Take(total);

                List<Client> result = query.ToList<Client>();
                ret = new SearchResult<Client>();
                ret.result = result;
                ret.total = result.Count;
                ret.page = page;
            }
            catch (SqlException e)
            {
                throw e;
            }
            return ret;
        }

    }
}
