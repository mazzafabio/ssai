using SSAI.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.Entity.IRepository
{
    public interface IProductRepository
    {
        bool Exists(Product entity);
        bool Exists(int id);
        Task<Product> Get(int id);
        Task<IEnumerable<Product>> GetAll();
        List<Product> GetAll(int page, int rowsPerPage);
        Task<bool> Add(Product entity);
        Task<bool> Update(Product entity);
        Task<bool> Delete(int id);
    }
}
