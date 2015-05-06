using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrosoft.bookkeeping.entity
{
    public class BaseSearchParameter
    {
        public Dictionary<string, string> filter { get; set; }
        public int pageSize { get; set; }
        public int page { get; set; }

        public BaseSearchParameter()
        {
            filter = new Dictionary<string, string>();
        }

    }
}
