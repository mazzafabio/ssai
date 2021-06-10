using SSAI.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SSAI.Helpers.ComputationTotalAmount
{
    public class TotalAmountContext
    {
        private ITotalAmount _totalAmount;


        public TotalAmountContext(ITotalAmount totalAmount)
        {
            _totalAmount = totalAmount;
        }


        public void SetStrategy(ITotalAmount totalAmount)
        {
            _totalAmount = totalAmount;
        }


        public decimal Compute(List<OrderProduct> OrderProducts)
        {
            return _totalAmount.GetTotalAmount(OrderProducts);
        }
    }
}
