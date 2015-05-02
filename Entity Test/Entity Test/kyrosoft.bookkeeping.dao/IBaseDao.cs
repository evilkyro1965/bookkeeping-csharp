using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrosoft.bookkeeping.dao
{
    public interface IBaseDao<T>
    {
        void add(T entity);
    }
}
