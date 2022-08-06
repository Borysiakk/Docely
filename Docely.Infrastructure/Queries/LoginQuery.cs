using Docely.Domain.Contract.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docely.Infrastructure.Queries
{
    public class LoginQuery : IRequest<AuthenticateResult>
    {
        public LoginQuery(string login,string password)
        {
            Login = login;
            Password = password;
        }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
