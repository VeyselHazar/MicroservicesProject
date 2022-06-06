using AuthServer.Core.Configurations;
using AuthServer.Core.Dtos;
using AuthServer.Core.Models;
using AuthServer.Core.Repositories;
using AuthServer.Core.Services;
using AuthServer.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IAuthenticationService
    {
        Tbl_UserTokens CreateToken(LoginInfo userApp);

        Task<Response<Tbl_UserTokens>> CreateTokenAsync(LoginInfo loginDto);
    }
    public class AuthenticationService : IAuthenticationService
    {
 
        private readonly IGenericRepository<Tbl_Users> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Tbl_UserTokens> _userRefreshTokenService;
        private readonly CustomTokenOption _tokenOption;

        public AuthenticationService(IGenericRepository<Tbl_Users> userManager, IUnitOfWork unitOfWork, IGenericRepository<Tbl_UserTokens> userRefreshTokenService, IOptions<CustomTokenOption> options)
        {
         
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userRefreshTokenService = userRefreshTokenService;
            _tokenOption = options.Value;
        }



        public async Task<Response<Tbl_UserTokens>> CreateTokenAsync(LoginInfo loginDto)
        {
            if (loginDto == null) throw new ArgumentNullException(nameof(loginDto));
            var user = await _userManager.GetSingleAsync(x => x.Email == loginDto.Email && x.Password == loginDto.Password);
            if (user == null) return Response<Tbl_UserTokens>.Fail("Email or Password is wrong", 400, true);

            var token = CreateToken(loginDto);

            var userRefreshToken = await _userRefreshTokenService.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();

            if (userRefreshToken == null)
            {
                await _userRefreshTokenService.AddAsync(new Tbl_UserTokens { UserId = user.Id, Token = token.Token, Expiration = token.Expiration });
            }
            else
            {
                userRefreshToken.Token = token.Token;
                userRefreshToken.Expiration = token.Expiration;
            }
            await _unitOfWork.CommitAsync();

            return Response<Tbl_UserTokens>.Success(token, 200);
        }

        private IEnumerable<Claim> GetClaim(Tbl_Users userApp, List<String> audiences)
        {
            var userList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,userApp.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, userApp.Email),
                new Claim(ClaimTypes.Name, userApp.Name_Surname),
                //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };
            userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
            return userList;
        }

        public Tbl_UserTokens CreateToken(LoginInfo loginDto)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.AccessTokenExpiration);
            var securityKey = SignService.GetSymmetricSecurityKey(_tokenOption.SecurityKey);

            var userApp = _userManager.GetSingleAsync(x => x.Email == loginDto.Email && x.Password == loginDto.Password);
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateIssuer = true,
                ValidIssuer = _tokenOption.Issuer,
                ValidateAudience = true,
                ValidAudience = _tokenOption.Audience[0],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true
            };

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenOption.Issuer,
                expires: DateTime.Now.Add(TimeSpan.FromDays(2)),
                notBefore: DateTime.Now,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
                claims: GetClaim(userApp.Result, _tokenOption.Audience)
                );
            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new Tbl_UserTokens
            {
                Token = token,
                UserId = userApp.Result.Id,
                Expiration = DateTime.Now.Add(TimeSpan.FromDays(2))
            };
            return tokenDto;
        }

    }
}
