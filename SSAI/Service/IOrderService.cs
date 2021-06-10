using SSAI.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.Service
{
    public interface IOrderService
    {
        Task<List<Order>> GetAll(int page, int rowsPerPage);
        Task<Order> Add(Order order, List<OrderProduct> orderProducts);
    }
}
