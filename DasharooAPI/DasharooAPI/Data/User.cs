#nullable enable
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DasharooAPI.Data
{
    public class User : IdentityUser
    {
        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Surname { get; set; }
    }
}
