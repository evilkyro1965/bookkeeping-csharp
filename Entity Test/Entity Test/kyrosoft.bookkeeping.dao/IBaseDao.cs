using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrosoft.bookkeeping.dao
{
    public interface IBaseDao<T>
    {
        void create(T entity);
        void update(T entity);
        void delete(int[] ids);
        T get(int id);
    }
}
