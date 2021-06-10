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
    public class OrderRepository : IOrderRepository
    {
        private readonly SSAIDBOrderContext _context;


        public OrderRepository(SSAIDBOrderContext context)
        {
            _context = context;
        }


        public bool AlreadyPlaced(string companyCode, DateTime date)
        {
            return _context.Orders.Any(x => x.CompanyCode == companyCode && x.Date.Date == date);
        }


        public async Task<Order> Get(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == id);
        }


        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.Include(x => x.OrderProducts).ToListAsync();
        }


        public List<Order> GetAll(int page, int rowsPerPage)
        {
            return _context.Orders.Include(x => x.OrderProducts).GetRows(page, rowsPerPage).ToList();
        }


        public async Task<bool> Add(Order entity)
        {
            await _context.Orders.AddAsync(entity);

            return true;
        }


        public async Task<bool> Update(Order entity)
        {
            var _entity = _context.Orders.FirstOrDefault(x => x.Id == entity.Id);
            this._context.Entry(_entity).CurrentValues.SetValues(entity);

            return true;
        }


        public async Task<bool> Delete(int id)
        {
            var entity = _context.Orders.FirstOrDefault(x => x.Id == id);
            _context.Orders.Remove(entity);

            return true;
        }
    }
}
