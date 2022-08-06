using Docely.Domain.Entity;
using Docely.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docely.Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _entities.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<User> GetUserByLoginAsync(string login)
        {
            return await _entities.FirstOrDefaultAsync(a => a.Login == login);
        }
    }
}
