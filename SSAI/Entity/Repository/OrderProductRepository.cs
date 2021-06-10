using Microsoft.EntityFrameworkCore;
using SSAI.Data;
using SSAI.Entity.DB;
using SSAI.Entity.IRepository;
using SSAI.Helpers.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.Entity.Repository
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly SSAIDBOrderContext _context;


        public OrderProductRepository(SSAIDBOrderContext context)
        {
            _context = context;
        }


        public async Task<OrderProduct> Get(int id)
        {
            return _context.OrderProducts.FirstOrDefault(x => x.Id == id);
        }


        public async Task<IEnumerable<OrderProduct>> GetAll()
        {
            return await _context.OrderProducts.ToListAsync();
        }

        public List<OrderProduct> GetAll(int page, int rowsPerPage)
        {
            return _context.OrderProducts.GetRows(page, rowsPerPage).ToList();
        }


        public async Task<bool> Add(OrderProduct entity)
        {
            await _context.OrderProducts.AddAsync(entity);

            return true;
        }


        public async Task<bool> Update(OrderProduct entity)
        {
            var _entity = _context.OrderProducts.FirstOrDefault(x => x.Id == entity.Id);
            this._context.Entry(_entity).CurrentValues.SetValues(entity);

            return true;
        }


        public async Task<bool> Delete(int id)
        {
            var entity = _context.OrderProducts.FirstOrDefault(x => x.Id == id);
            _context.OrderProducts.Remove(entity);

            return true;
        }
    }
}
