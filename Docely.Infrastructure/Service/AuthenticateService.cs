using Docely.Domain.Contract.Result;
using Docely.Domain.Query;
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
            var resultFindLogin = await _userRepository.GetUserByLoginAsync(loginQuery.Login);
            if (resultFindLogin == null)
            {
                return new AuthenticateResult()
                {
                    Succeeded = false,
                    AuthDate = DateTime.Now,
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                };
            }

            var resultCheckPassword = BC.Verify(loginQuery.Password, resultFindLogin.PasswordHash);
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
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
    }
}
