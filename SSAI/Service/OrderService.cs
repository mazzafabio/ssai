using SSAI.Entity.DB;
using SSAI.Helpers.ComputationTotalAmount;
using SSAI.Helpers.Pagination;
using SSAI.Model.Response;
using SSAI.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWorkProduct _unitOfWorkProduct;
        private readonly IUnitOfWorkOrder _unitOfWorkOrder;


        public OrderService(IUnitOfWorkProduct unitOfWorkProduct, IUnitOfWorkOrder unitOfWorkOrder)
        {
            _unitOfWorkProduct = unitOfWorkProduct;
            _unitOfWorkOrder = unitOfWorkOrder;
        }


        public async Task<GenericResponse<List<OrderResponse>>> GetAll(int page, int rowsPerPage)
        {
            var result = _unitOfWorkOrder.Orders.GetAll(page, rowsPerPage).ToList();
            var modelRes = result.Select(x => (OrderResponse)x).ToList();

            var resultRes = new GenericResponse<List<OrderResponse>>
            {
                error = false,
                message = "",
                model = modelRes
            };

            return resultRes;
        }


        public async Task<GenericResponse<OrderResponse>> Add(Order order, List<OrderProduct> orderProducts)
        {
            bool result = false;
            var resultRes = new GenericResponse<OrderResponse>
            {
                error = false,
                message = "",
            };

            try
            {
                var date = DateTime.Now.Date;
                order.Date = date;

                var alreadyPlaced = _unitOfWorkOrder.Orders.AlreadyPlaced(order.CompanyCode, date);

                if (alreadyPlaced)
                    throw new Exception("Order already placed by thi company.");

                orderProducts = orderProducts.GroupBy(x => x.FkProduct).Select(x => x.FirstOrDefault()).ToList();
                List<int> orderProductsToRemove = new List<int>();
                List<Product> productsToUpdate = new List<Product>();

                foreach (var orderProduct in orderProducts)
                {
                    var product = await _unitOfWorkProduct.Products.Get(orderProduct.FkProduct);
                    if (product == null)
                        orderProductsToRemove.Add(orderProduct.FkProduct);
                    else
                    {
                        if (product.StockQty < orderProduct.StockQty) 
                            throw new Exception("Quantity in stock is insufficient for product id " + product.Id + ".");

                        productsToUpdate.Add(product);
                    }
                }

                orderProducts = orderProducts.Where(x => !orderProductsToRemove.Any(y => y == x.FkProduct)).ToList();

                if (orderProducts.Count == 0)
                    throw new Exception("Products ordered must be at least 1.");

                TotalAmountContext _tacontext = new TotalAmountContext(MappingCompanyCodeToClass.GetClassFromCompanyCode(order.CompanyCode));
                var totalAmount = _tacontext.Compute(orderProducts);

                if (totalAmount < 100)
                    throw new Exception("Total amount must be at least 100.");

                result = await _unitOfWorkOrder.Orders.Add(order);

                if (result)
                {
                    _unitOfWorkOrder.Save();

                    foreach (var orderProduct in orderProducts)
                    {
                        orderProduct.FkOrder = order.Id;
                        var resultOP = await _unitOfWorkOrder.OrderProducts.Add(orderProduct);

                        if (resultOP)
                        {
                            var productToUpdate = productsToUpdate.FirstOrDefault(x => x.Id == orderProduct.FkProduct);
                            productToUpdate.StockQty -= orderProduct.StockQty;
                            var resultP = await _unitOfWorkProduct.Products.Update(productToUpdate);
                        }
                    }

                    _unitOfWorkOrder.Save();
                    _unitOfWorkProduct.Save();
                }
            }
            catch (Exception ex)
            {
                resultRes.error = true;
                resultRes.message = ex.Message;
            }

            resultRes.model = result ? (OrderResponse)order : null;

            return resultRes;
        }
    }
}
