using SSAI.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.Model.Response
{
    public class ProductResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal unitPrice { get; set; }
        public decimal stockQty { get; set; }


        public static explicit operator ProductResponse(Product product)
        {
            if (product == null) return new ProductResponse();

            return new ProductResponse
            {
                id = product.Id,
                name = product.Name,
                description = product.Description,
                unitPrice = product.UnitPrice,
                stockQty = product.StockQty,
            };
        }
    }
}
