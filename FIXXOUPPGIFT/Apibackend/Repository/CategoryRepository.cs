using Apibackend.Context;
using Apibackend.Models;
using Apibackend.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apibackend.Repository
{

    public class CategoryRepository : BaseRepository<CategoryEntity>
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
