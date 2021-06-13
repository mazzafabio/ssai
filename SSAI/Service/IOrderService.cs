using SSAI.Entity.DB;
using SSAI.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.Service
{
    public interface IOrderService
    {
        Task<GenericResponse<List<OrderResponse>>> GetAll(int page, int rowsPerPage);
        Task<GenericResponse<OrderResponse>> Add(Order order, List<OrderProduct> orderProducts);
    }
}
