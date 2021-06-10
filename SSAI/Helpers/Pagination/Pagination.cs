using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.Helpers.Pagination
{
    public static class Pagination
    {
        public static IEnumerable<T> GetRows<T>(this IEnumerable<T> iList, int page, int rowsPerPage)
        {
            return iList.Skip((page - 1) * rowsPerPage).Take(rowsPerPage);
        }
    }
}
