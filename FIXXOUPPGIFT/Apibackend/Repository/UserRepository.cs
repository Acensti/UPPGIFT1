using Apibackend.Context;
using Apibackend.Models;
using System.Diagnostics;

namespace Apibackend.Repository
{
    public class UserRepository
    {
        private readonly IdentityContext _context;

        public UserRepository(IdentityContext context)
        {
            _context = context;
        }


        public async Task<UserEntity> AddAsync(UserEntity entity)
        {
            try
            {
                _context.UserProfile.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return entity;
        }
    }
}
