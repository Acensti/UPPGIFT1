using Apibackend.Context;
using Apibackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apibackend.Repository
{
    
    public class CategoryRepository : Repository<CategoryEntity>
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
