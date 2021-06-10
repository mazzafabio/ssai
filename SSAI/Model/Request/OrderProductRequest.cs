using SSAI.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.Model.Request
{
    public class OrderProductRequest
    {
        public int idProduct { get; set; }
        public decimal unitPrice { get; set; }
        public decimal stockQty { get; set; }


        public static explicit operator OrderProduct(OrderProductRequest orderProductRequest)
        {
            return new OrderProduct
            {
                FkProduct = orderProductRequest.idProduct,
                UnitPrice = orderProductRequest.unitPrice,
                StockQty = orderProductRequest.stockQty,
            };
        }
    }
}
