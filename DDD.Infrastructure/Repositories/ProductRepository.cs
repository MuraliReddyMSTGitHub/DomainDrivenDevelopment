using DDD.Domain.Models;
using DDD.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DDDApplicationDbContext _dbDDContext;

        public ProductRepository(DDDApplicationDbContext dbDDContext)
        {
            _dbDDContext = dbDDContext;
        }
        public async Task<IEnumerable<Product>> GetItems()
        {
            return await _dbDDContext.Producuts.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Product?> GetProduct(int Id)
        {
            return await _dbDDContext.Producuts.FirstOrDefaultAsync(x => x.Id == Id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            return await _dbDDContext.ProductCategories.ToListAsync().ConfigureAwait(false);
        }

        public async Task<ProductCategory?> GetProductCategory(int Id)
        {
            return await _dbDDContext.ProductCategories.FirstOrDefaultAsync(x=>x.Id == Id).ConfigureAwait(false);
        }
    }
}
