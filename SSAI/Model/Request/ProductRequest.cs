using SSAI.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.Model.Request
{
    public class ProductRequest
    {
        public string name { get; set; }
        public string description { get; set; }
        public decimal unitPrice { get; set; }
        public decimal stockQty { get; set; }


        public static explicit operator Product(ProductRequest productRequest)
        {
            return new Product
            {
                Name = productRequest.name,
                Description = productRequest.description,
                UnitPrice = productRequest.unitPrice,
                StockQty = productRequest.stockQty,
            };
        }
    }
}
