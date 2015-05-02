using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kyrosoft.bookkeeping.entity;

namespace kyrosoft.bookkeeping.dao
{
    public abstract class BaseDao<T>
    {
        protected DaoContext daoContext;

        public BaseDao()
        {
            daoContext = new DaoContext();
        }

    }
}
