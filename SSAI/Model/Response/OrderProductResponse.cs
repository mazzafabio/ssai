using SSAI.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.Model.Response
{
    public class OrderProductResponse
    {
        public int id { get; set; }
        public int idOrder { get; set; }
        public int idProduct { get; set; }
        public decimal unitPrice { get; set; }
        public decimal stockQty { get; set; }


        public static explicit operator OrderProductResponse(OrderProduct orderProduct)
        {
            if (orderProduct == null) return new OrderProductResponse();

            return new OrderProductResponse
            {
                id = orderProduct.Id,
                idOrder = orderProduct.FkOrder,
                idProduct = orderProduct.FkProduct,
                unitPrice = orderProduct.UnitPrice,
                stockQty = orderProduct.StockQty,
            };
        }
    }
}
