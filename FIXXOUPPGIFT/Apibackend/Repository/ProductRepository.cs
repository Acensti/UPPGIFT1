using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Apibackend.Context;
using Apibackend.Models;
using Apibackend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiBackend.Repositories
{
    public class ProductRepository : BaseRepository<ProductEntity>
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<ProductEntity>> RetrieveAllAsync()
        {
            try
            {
                var result = await _context.Products.Include("Category").ToListAsync();
                return result;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }


        public virtual async Task<IEnumerable<ProductEntity>> RetrieveAllAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            try
            {
                var result = await _context.Products.Include("Category").Where(expression).ToListAsync();

                return result;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }


        public virtual async Task<ProductEntity> FindAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            try
            {
                var result = await _context.Products.Include("Category").FirstOrDefaultAsync(expression);
                if (result != null)
                    return result;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }
    }
}
