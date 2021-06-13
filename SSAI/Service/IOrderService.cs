using SSAI.Entity.DB;
using SSAI.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.Service
{
    /// <summary>
    /// Service for manage order
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Method for get a list of order paginated
        /// </summary>
        /// <param name="page">
        /// Number of page that you want to get
        /// </param>
        /// <param name="rowsPerPage">
        /// Number of rows per each page that you want to get
        /// </param>
        /// <returns>
        /// The method returns a list of order and optional error message.
        /// </returns>
        Task<GenericResponse<List<OrderResponse>>> GetAll(int page, int rowsPerPage);


        /// <summary>
        /// Method for add a order and its products ordered
        /// </summary>
        /// <param name="order">
        /// Object where you can set username and password
        /// </param>
        /// <param name="orderProducts">
        /// Object where you can set username and password
        /// </param>
        /// <returns>
        /// The method returns the order created and optional error message.
        /// </returns>
        Task<GenericResponse<OrderResponse>> Add(Order order, List<OrderProduct> orderProducts);
    }
}
