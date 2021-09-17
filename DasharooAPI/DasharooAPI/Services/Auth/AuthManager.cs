using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DasharooAPI.Data;
using DasharooAPI.Models;
using DasharooAPI.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DasharooAPI.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User _user;

        public AuthManager(UserManager<User> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }



        public async Task<string> CreateToken(TokenTypes tokenType)
        {
            var signingCredentials = GetSigningCredentials(tokenType);
            var claims = await GetClaims();
            var token = GenerateTokenOptions(signingCredentials, claims, tokenType);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, IEnumerable<Claim> claims, TokenTypes tokenType)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            DateTime? expiration = tokenType == TokenTypes.AccessToken
                ? DateTime.Now.AddMinutes(Convert.ToDouble(
                    jwtSettings.GetSection("lifetime").Value))
                : null;

            var token = new JwtSecurityToken(
                jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
            );

            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new("id", _user.Id),
                new("userName", _user.UserName),
                new("firstName",_user.Name),
                new("artistName",_user.ArtistName)

            };

            var roles = await _userManager.GetRolesAsync(_user);

            claims.AddRange(roles.Select(role => new Claim("role", role)));

            return claims;
        }

        private static SigningCredentials GetSigningCredentials(TokenTypes tokenType)
        {
            var envVariableName = tokenType switch
            {
                TokenTypes.AccessToken => "ACCESS_TOKEN_KEY",
                TokenTypes.RefreshToken => "REFRESH_TOKEN_KEY",
                _ => throw new ArgumentOutOfRangeException(nameof(tokenType), tokenType, null)
            };

            var key = Environment.GetEnvironmentVariable(envVariableName);
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<User> ValidateAndReturnUser(LoginUserDto userDto)
        {
            _user = await _userManager.FindByEmailAsync(userDto.Email)
                    ?? await _userManager.FindByNameAsync(userDto.Email);

            if (_user == null || !await _userManager.CheckPasswordAsync(_user, userDto.Password)) return null;

            return _user;
        }
    }
}