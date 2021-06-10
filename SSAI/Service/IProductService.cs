using SSAI.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.Service
{
    public interface IProductService
    {
        Task<Product> Get(int id);
        Task<List<Product>> GetAll(int page, int rowsPerPage);
        Task<Product> Add(Product product);
    }
}
