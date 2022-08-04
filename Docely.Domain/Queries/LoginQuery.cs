using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docely.Domain.Query
{
    public class LoginCommand : IRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
