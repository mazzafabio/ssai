using SSAI.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.Entity.IRepository
{
    public interface IOrderRepository
    {
        bool AlreadyPlaced(string companyCode, DateTime date);
        Task<Order> Get(int id);
        Task<IEnumerable<Order>> GetAll();
        List<Order> GetAll(int page, int rowsPerPage);
        Task<bool> Add(Order entity);
        Task<bool> Update(Order entity);
        Task<bool> Delete(int id);
    }
}
