using SSAI.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.Model.Request
{
    public class OrderRequest
    {
        public string companyCode { get; set; }
        public List<OrderProductRequest> orderProducts { get; set; }


        public static explicit operator Order(OrderRequest orderRequest)
        {
            return new Order
            {
                CompanyCode = orderRequest.companyCode,
            };
        }
    }
}
