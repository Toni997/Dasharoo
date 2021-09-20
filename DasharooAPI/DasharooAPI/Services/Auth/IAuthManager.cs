using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using DasharooAPI.Models;
using DasharooAPI.Services.Auth;

namespace DasharooAPI.Services
{
    public interface IAuthManager
    {
        Task<User> ValidateAndReturnUser(LoginUserDto userDto);
        Task<string> CreateToken(TokenTypes tokenType, string userId = null);
    }
}
