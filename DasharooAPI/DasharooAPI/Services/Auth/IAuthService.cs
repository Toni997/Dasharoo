using DasharooAPI.Models;
using DasharooAPI.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DasharooAPI.Services.Auth
{
    public interface IAuthService
    {
        Task<ResponseDetails> TryLogin([FromBody] LoginUserDto userDto);
        Task DeleteRefreshToken(string userId);
        Task<ResponseDetails> RefreshAccessToken(RefreshTokenDto refreshTokenDto);
    }
}