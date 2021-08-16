using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DasharooAPI.Models
{
    public class LoginUserDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Password has to be between {2} and {1} characters", MinimumLength = 5)]
        public string Password { get; set; } = null!;
    }

    public class UserDto : LoginUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public ICollection<string> Roles { get; set; }
    }
}
