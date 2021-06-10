using SSAI.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.Helpers.ComputationTotalAmount
{
    public class TotalAmountCCode1 : ITotalAmount
    {
        public decimal GetTotalAmount(List<OrderProduct> OrderProducts)
        {
            decimal result = 0;

            OrderProducts.ForEach(x =>
            {
                result += x.UnitPrice * x.StockQty;
            });

            result += result * 0.02m;

            return result;
        }
    }
}
