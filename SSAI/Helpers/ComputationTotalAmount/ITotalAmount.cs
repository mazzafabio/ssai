using SSAI.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.Helpers.ComputationTotalAmount
{
    public interface ITotalAmount
    {
        decimal GetTotalAmount(List<OrderProduct> OrderProducts);
    }
}
