using SSAI.Entity.DB;
using SSAI.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.Service
{
    /// <summary>
    /// Service for manage product
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Method for get a product
        /// </summary>
        /// <param name="id">
        /// id of product that you want to retrieve
        /// </param>
        /// <returns>
        /// The method returns a product and optional error message.
        /// </returns>
        Task<GenericResponse<ProductResponse>> Get(int id);


        /// <summary>
        /// Method for get a list of product paginated
        /// </summary>
        /// <param name="page">
        /// Number of page that you want to get
        /// </param>
        /// <param name="rowsPerPage">
        /// Number of rows per each page that you want to get
        /// </param>
        /// <returns>
        /// The method returns a list of product and optional error message.
        /// </returns>
        Task<GenericResponse<List<ProductResponse>>> GetAll(int page, int rowsPerPage);


        /// <summary>
        /// Method for add a product
        /// </summary>
        /// <param name="product">
        /// Object where you can set username and password
        /// </param>
        /// <returns>
        /// The method returns the product created and optional error message.
        /// </returns>
        Task<GenericResponse<ProductResponse>> Add(Product product);
    }
}
