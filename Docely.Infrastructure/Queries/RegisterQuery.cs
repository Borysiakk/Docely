using Docely.Domain.Contract.Result;
using MediatR;

namespace Docely.Infrastructure.Queries
{
    public class RegisterQuery: IRequest<RegisterResult>
    {
        public RegisterQuery(string password, string name, string surName, string email)
        {
            Password = password;
            Name = name;
            SurName = surName;
            Email = email;
        }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}