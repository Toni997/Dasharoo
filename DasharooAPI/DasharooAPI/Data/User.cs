#nullable enable
using Microsoft.AspNetCore.Identity;

namespace DasharooAPI.Data
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
