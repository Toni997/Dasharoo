using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DasharooAPI.Controllers;
using DasharooAPI.Data;
using DasharooAPI.IRepository;
using DasharooAPI.Models;
using DasharooAPI.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DasharooAPI.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper,
            IFileService fileService, IAuthManager authManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authManager = authManager;
        }

        public async Task<ResponseDetails> TryLogin([FromBody] LoginUserDto userDto)
        {
            var user = await _authManager.ValidateAndReturnUser(userDto);

            if (user == null)
                return new Error(
                    StatusCodes.Status401Unauthorized, "Wrong credentials."
                );

            if (!user.EmailConfirmed)
                return new Error(
                    StatusCodes.Status401Unauthorized, "Account not confirmed."
                );

            var refreshToken = await _authManager.CreateToken(TokenTypes.RefreshToken);

            await _unitOfWork.RefreshTokens.Insert(
                new RefreshToken
                {
                    UserId = user.Id,
                    Token = refreshToken,
                    Expires = DateTime.Now.AddMonths(6)
                });

            await _unitOfWork.Save();

            var authorizationTokens = new AuthorizationTokens
            {
                AccessToken = await _authManager.CreateToken(TokenTypes.AccessToken),
                RefreshToken = refreshToken
            };

            return new Success(StatusCodes.Status202Accepted, authorizationTokens);
        }

        public async Task DeleteRefreshToken(string id)
        {
            var activeRefreshTokens = await _unitOfWork.RefreshTokens.GetAll(x => x.UserId == id);
            _unitOfWork.RefreshTokens.DeleteRange(activeRefreshTokens);
            await _unitOfWork.Save();
        }


        public async Task<ResponseDetails> RefreshAccessToken(RefreshTokenDto refreshTokenDto)
        {
            var refreshToken = await _unitOfWork.RefreshTokens.Get(
                x => x.Token == refreshTokenDto.Token
                     && x.UserId == refreshTokenDto.UserId);

            if (refreshToken == null)
                return new Error(StatusCodes.Status401Unauthorized,
                    "Refresh token is not valid.");

            // check if the refresh token has expired
            if (DateTime.Compare(refreshToken.Expires, DateTime.Now) < 0)
                return new Error(StatusCodes.Status401Unauthorized,
                    "Refresh token has expired.");

            return new Success(StatusCodes.Status202Accepted,
                await _authManager.CreateToken(TokenTypes.AccessToken, refreshTokenDto.UserId));
        }
    }
}
