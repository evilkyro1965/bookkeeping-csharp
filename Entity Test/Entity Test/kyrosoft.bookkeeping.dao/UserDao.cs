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
    public class UserDao : BaseDao<User>,IUserDao
    {
        public void create(User user)
        {
            try { 
                daoContext.Users.Add(user);
                daoContext.SaveChanges();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void update(User user)
        {
            try
            {
                var entry = daoContext.Entry(user);
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
                    User user = daoContext.Users.Find(ids[i]);
                    if(user==null)
                        throw new Exception("User with id:"+ids[i]+" is not found!");
                    daoContext.Users.Remove(user);
                    daoContext.SaveChanges();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public User get(int id)
        {
            try
            {
                User user = daoContext.Users.Find(id);
                return user;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public SearchResult<User> search(BaseSearchParameter parameter)
        {
            var query = from u in daoContext.Users
                        where u.username == "john.doe"
                        select u;
            List<User> result = query.ToList<User>();
            SearchResult<User> ret = new SearchResult<User>();
            ret.result = result;
            return ret;
        }

    }
}
