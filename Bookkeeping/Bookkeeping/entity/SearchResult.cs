using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrosoft.bookkeeping.entity
{
    public class SearchResult<T>
    {
        public List<T> result { get; set; }
        public int page { get; set; }
        public int total { get; set; }

        public SearchResult()
        {
            result = new List<T>();
        }
    }
}
