using SSAI.Entity.DB;
using SSAI.Helpers.ComputationTotalAmount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.Model.Response
{
    public class OrderResponse
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string companyCode { get; set; }
        public decimal totalAmount { get; set; }
        public List<OrderProductResponse> orderProducts { get; set; }


        public static explicit operator OrderResponse(Order order)
        {
            if (order == null) return new OrderResponse();

            TotalAmountContext _tacontext = new TotalAmountContext(MappingCompanyCodeToClass.GetClassFromCompanyCode(order.CompanyCode));
            var totalAmount = _tacontext.Compute(order.OrderProducts);

            return new OrderResponse
            {
                id = order.Id,
                companyCode = order.CompanyCode,
                date = order.Date,
                totalAmount = totalAmount,
                orderProducts = order.OrderProducts.Select(x => (OrderProductResponse)x).ToList()
            };
        }
    }

}
