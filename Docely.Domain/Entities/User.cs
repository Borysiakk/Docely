using Docely.Domain.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace Docely.Domain.Entity
{
    public class User : BaseEntity
    {

        public string Name { get; set; }
        public string SurName { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        [JsonIgnore]
        public string PasswordSalt { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

    }
}
