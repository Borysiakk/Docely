
using Docely.Domain.Contract.Result;
using Docely.Infrastructure.Converters;
using Docely.Infrastructure.Queries;
using Docely.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Docely.Infrastructure.Service
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthenticateResult> LoginAsync(LoginQuery loginQuery)
        {
            var user = await _userRepository.GetUserByLoginAsync(loginQuery.Login);
            if (user == null)
            {
                return new AuthenticateResult()
                {
                    Succeeded = false,
                    AuthDate = DateTime.Now,
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                };
            }

            var resultCheckPassword = BC.Verify(loginQuery.Password, user.PasswordHash);
            if(!resultCheckPassword)
            {
                return new AuthenticateResult()
                {
                    Succeeded = false,
                    AuthDate = DateTime.Now,
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                };
            }

            return new AuthenticateResult()
            {
                Succeeded = true,
                AuthDate = DateTime.Now,
                User = user.ToUserDto(),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
    }
}
