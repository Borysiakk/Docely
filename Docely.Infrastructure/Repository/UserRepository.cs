using Docely.Domain.Entity;
using Docely.Persistence;
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

        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByLoginAsync(string login)
        {
            throw new NotImplementedException();
        }
    }
}
