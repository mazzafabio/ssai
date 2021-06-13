using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.Helpers.Pagination
{
    public static class Pagination
    {
        /// <summary>
        /// Extension method for all ieumerable that paginate them.
        /// </summary>
        /// <param name="page">
        /// Number of page that you want to get
        /// </param>
        /// <param name="rowsPerPage">
        /// Number of rows per each page that you want to get
        /// </param>
        /// <returns>
        /// Return only rowsPerPage rows from page from ienumerable.
        /// </returns>
        public static IEnumerable<T> GetRows<T>(this IEnumerable<T> iList, int page, int rowsPerPage)
        {
            return iList.Skip((page - 1) * rowsPerPage).Take(rowsPerPage);
        }
    }
}
