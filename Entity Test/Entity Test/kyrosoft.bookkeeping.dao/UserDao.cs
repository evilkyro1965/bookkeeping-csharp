using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kyrosoft.bookkeeping.entity;
using System.Data.SqlClient;

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
                daoContext.Users.Add(user);
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
    }
}
