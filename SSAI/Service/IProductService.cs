using SSAI.Entity.DB;
using SSAI.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.Service
{
    public interface IProductService
    {
        Task<GenericResponse<ProductResponse>> Get(int id);
        Task<GenericResponse<List<ProductResponse>>> GetAll(int page, int rowsPerPage);
        Task<GenericResponse<ProductResponse>> Add(Product product);
    }
}
