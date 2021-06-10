using SSAI.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.Entity.IRepository
{
    public interface IOrderProductRepository
    {
        Task<OrderProduct> Get(int id);
        Task<IEnumerable<OrderProduct>> GetAll();
        List<OrderProduct> GetAll(int page, int rowsPerPage);
        Task<bool> Add(OrderProduct entity);
        Task<bool> Update(OrderProduct entity);
        Task<bool> Delete(int id);
    }
}
