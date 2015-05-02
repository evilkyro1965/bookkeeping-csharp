using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kyrosoft.bookkeeping.entity;

namespace kyrosoft.bookkeeping.dao
{
    public class UserDao : BaseDao<User>,IUserDao
    {
        public void add(User user)
        {
            daoContext.Users.Add(user);
            daoContext.SaveChanges();
        }
    }
}
