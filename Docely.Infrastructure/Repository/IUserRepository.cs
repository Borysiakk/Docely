using Docely.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docely.Infrastructure.Repository
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByLoginAsync(string login);
    }
}
