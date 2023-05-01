using Apibackend.Models;
using Apibackend.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Apibackend.Repositories
{
    // Generic Repository pattern for handling basic database operations
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _dataContext;

        // Constructor that receives a DataContext instance
        protected BaseRepository(DataContext context)
        {
            _dataContext = context;
        }

        // Adds an entity to the database
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                _dataContext.Set<TEntity>().Add(entity);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return entity;
        }

        // Searches for an entity that matches the given expression
        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return await _dataContext.Set<TEntity>().AnyAsync(expression);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

        // Retrieves an entity that matches the given expression
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var result = await _dataContext.Set<TEntity>().FirstOrDefaultAsync(expression);
                if (result != null)
                    return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null!;
        }

        // Retrieves all entities from the database
        public async Task<IEnumerable<TEntity>> RetrieveAllAsync()
        {
            try
            {
                var result = await _dataContext.Set<TEntity>().ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null!;
        }

        // Retrieves all entities that match the given expression
        public async Task<IEnumerable<TEntity>> RetrieveAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var result = await _dataContext.Set<TEntity>().Where(expression).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null!;
        }

        // Updates an existing entity in the database
        public async Task<TEntity> ModifyAsync(TEntity entity)
        {
            try
            {
                _dataContext.Set<TEntity>().Update(entity);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return entity;
        }

        // Deletes an entity from the database
        public async Task<bool> RemoveAsync(TEntity entity)
        {
            try
            {
                _dataContext.Set<TEntity>().Remove(entity);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
