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
        public void add(User user)
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
    }
}
