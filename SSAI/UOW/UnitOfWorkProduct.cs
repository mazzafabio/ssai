using SSAI.Data;
using SSAI.Entity.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.UOW
{
    public class UnitOfWorkProduct : IUnitOfWorkProduct
    {
        private readonly SSAIDBProductContext _context;
        public IProductRepository Products { get; }


        public UnitOfWorkProduct(SSAIDBProductContext context, IProductRepository productRepository)
        {
            this._context = context;
            this.Products = productRepository;
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
