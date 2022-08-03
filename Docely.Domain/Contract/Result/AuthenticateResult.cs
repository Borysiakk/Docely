using Docely.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docely.Domain.Contract.Result
{
    public class AuthenticateResult : Result
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
        public DateTime AuthDate { get; set; }
    }
}
