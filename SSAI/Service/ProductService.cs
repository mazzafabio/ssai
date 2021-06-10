using SSAI.Entity.DB;
using SSAI.Helpers.Pagination;
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


        public async Task<Product> Get(int id)
        {
            var result = await _unitOfWorkProduct.Products.Get(id);

            return result;
        }


        public async Task<List<Product>> GetAll(int page, int rowsPerPage)
        {
            return _unitOfWorkProduct.Products.GetAll(page, rowsPerPage).ToList();
        }


        public async Task<Product> Add(Product product)
        {
            bool result = false;
            
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
            catch (Exception) { }

            return result ? product : null;
        }
    }
}
