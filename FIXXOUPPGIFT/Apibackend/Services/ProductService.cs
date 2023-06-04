using Apibackend.Context;
using Apibackend.Models;
using ApiBackend.Repositories;
using Apibackend.Repository;
using System.Diagnostics;
using System.Linq.Expressions;
using Apibackend.Models.Dtos;

namespace Apibackend.Services
{
    public class ProductService
    {
        private readonly DataContext _context;
        private readonly ProductRepository _productRepo;
        private readonly CategoryRepository _categoryRepo;

        public ProductService(DataContext context, ProductRepository productRepo, CategoryRepository categoryRepo)
        {
            _context = context;
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<ProductEntity> CreateAsync(Product product)
        {
            ProductEntity entity = product;
            return await _productRepo.AddAsync(entity);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            try
            {
                var result = await _productRepo.RetrieveAllAsync(expression);
                var products = new List<Product>();
                if (result != null)
                {
                    foreach (var entity in result)
                    {
                        Product product = entity;
                        products.Add(product);
                    }
                }

                return products;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                var result = await _productRepo.RetrieveAllAsync();
                var products = new List<Product>();
                if (result != null)
                {
                    foreach (var entity in result)
                    {
                        Product product = entity;
                        products.Add(product);
                    }
                }

                return products;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<Product> FindAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            var entity = await _productRepo.FindAsync(expression);
            Product product = entity;
            return product;
        }
    }
}
