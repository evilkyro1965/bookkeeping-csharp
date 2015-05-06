using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kyrosoft.bookkeeping.entity;
using kyrosoft.bookkeeping.entity.dto;
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

        public User searchByUsername(String username)
        {
            IQueryable<User> query;
            query = daoContext.Users;
            query.Where(u => u.username == username);

            User ret = query.Single<User>();
            return ret;
        }


        public SearchResult<User> searchAll(BaseSearchParameter parameter)
        {
            int page = parameter.page;
            int total = parameter.pageSize;

            IQueryable<User> query;
            query = daoContext.Users.OrderBy(u=>u.username)
                .Skip((page - 1) * total)
                .Take(total);

            List<User> result = query.ToList<User>();
            SearchResult<User> ret = new SearchResult<User>();
            ret.result = result;
            ret.total = result.Count;
            ret.page = page;

            return ret;
        }

    }
}
