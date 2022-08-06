using Docely.Domain.Dto;
using Docely.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docely.Infrastructure.Converters
{
    public static class UserConverter
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Login = user.Login,
                Email = user.Email,
                Name = user.Name,
                SurName = user.SurName
            };
        }
    }
}
