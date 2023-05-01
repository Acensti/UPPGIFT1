using Apibackend.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apibackend.Repository
{
    public class Repository<T> where T : class
    {
        protected readonly DataContext _context;
        private readonly DbSet<T> _entities;

        public Repository(DataContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

       
    }
}
