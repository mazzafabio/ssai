using SSAI.Data;
using SSAI.Entity.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.UOW
{
    public class UnitOfWorkOrder : IUnitOfWorkOrder
    {
        private readonly SSAIDBOrderContext _context;
        public IOrderRepository Orders { get; }
        public IOrderProductRepository OrderProducts { get; }


        public UnitOfWorkOrder(SSAIDBOrderContext context, IOrderRepository orderRepository, IOrderProductRepository orderProductRepository)
        {
            this._context = context;
            this.Orders = orderRepository;
            this.OrderProducts = orderProductRepository;
        }


        public int Save()
        {
            return _context.SaveChanges();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }


    }
}
