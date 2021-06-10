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
    public class ProductRepository : IProductRepository
    {
        private readonly SSAIDBProductContext _context;


        public ProductRepository(SSAIDBProductContext context)
        {
            _context = context;
        }


        public bool Exists(Product entity)
        {
            return _context.Products.Any(x => x.Name == entity.Name && x.Description == entity.Description);
        }


        public bool Exists(int id)
        {
            return _context.Products.Any(x => x.Id == id);
        }


        public async Task<Product> Get(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }


        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }


        public List<Product> GetAll(int page, int rowsPerPage)
        {
            return _context.Products.GetRows(page, rowsPerPage).ToList();
        }


        public async Task<bool> Add(Product entity)
        {
            await _context.Products.AddAsync(entity);

            return true;
        }


        public async Task<bool> Update(Product entity)
        {
            var _entity = _context.Products.FirstOrDefault(x => x.Id == entity.Id);
            this._context.Entry(_entity).CurrentValues.SetValues(entity);

            return true;
        }


        public async Task<bool> Delete(int id)
        {
            var entity = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Products.Remove(entity);

            return true;
        }
    }
}
