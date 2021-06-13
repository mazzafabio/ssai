using SSAI.Entity.DB;
using SSAI.Helpers.Pagination;
using SSAI.Model.Response;
using SSAI.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWorkProduct _unitOfWorkProduct;
        private readonly IUnitOfWorkOrder _unitOfWorkOrder;


        public ProductService(IUnitOfWorkProduct unitOfWorkProduct, IUnitOfWorkOrder unitOfWorkOrder)
        {
            _unitOfWorkProduct = unitOfWorkProduct;
            _unitOfWorkOrder = unitOfWorkOrder;
        }


        public async Task<GenericResponse<ProductResponse>> Get(int id)
        {
            var result = await _unitOfWorkProduct.Products.Get(id);
            var modelRes = (ProductResponse)result;

            var resultRes = new GenericResponse<ProductResponse>
            {
                error = false,
                message = "",
                model = modelRes
            };

            return resultRes;
        }


        public async Task<GenericResponse<List<ProductResponse>>> GetAll(int page, int rowsPerPage)
        {
            var result = _unitOfWorkProduct.Products.GetAll(page, rowsPerPage).ToList();
            var modelRes = result.Select(x => (ProductResponse)x).ToList();

            var resultRes = new GenericResponse<List<ProductResponse>>
            {
                error = false,
                message = "",
                model = modelRes
            };

            return resultRes;
        }


        public async Task<GenericResponse<ProductResponse>> Add(Product product)
        {
            bool result = false;
            var resultRes = new GenericResponse<ProductResponse>
            {
                error = false,
                message = "",
            };

            try
            {
                var exists = _unitOfWorkProduct.Products.Exists(product);

                if (exists)
                    throw new Exception("Product already exists with the same name and description.");

                if (product.UnitPrice > 1000)
                    throw new Exception("Product must have unit price minor than 1000");

                result = await _unitOfWorkProduct.Products.Add(product);

                if (result)
                    _unitOfWorkProduct.Save();
            }
            catch (Exception ex) {
                resultRes.error = true;
                resultRes.message = ex.Message;
            }

            resultRes.model = result ? (ProductResponse)product : null;

            return resultRes;
        }
    }
}
