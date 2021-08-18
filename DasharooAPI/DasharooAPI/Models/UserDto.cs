﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using JetBrains.Annotations;

namespace DasharooAPI.Models
{
    public class LoginUserDto
    {
        [Required]
        [MaxLength(320)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string Password { get; set; } = null!;
    }

    public class SignupUserDto : LoginUserDto
    {
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }

    public class UserDto : SignupUserDto
    {
        public ICollection<string> Roles { get; set; }
    }
}