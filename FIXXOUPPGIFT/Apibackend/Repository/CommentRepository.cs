using Apibackend.Context;
using Apibackend.Models;
using Apibackend.Repositories;
using Apibackend.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apibackend.Repository
{
    public class CommentRepository : BaseRepository<CommentEntity>
    {
        public CommentRepository(DataContext context) : base(context)
        {
        }
    }
}
