using Gate.Configurations;
using Gate.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gate.Extensions
{

    //public static class CustomTokenAuth
    //{
    //    public static void AddCustomTokenAuth(this IServiceCollection services, CustomTokenOption tokenOptions)
    //    {
    //        string authenticationProviderKey = "TestKey";
    //        services.AddAuthentication(options => {
    //            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    //            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //        }).AddJwtBearer(authenticationProviderKey, opts =>
    //        {
    //            opts.RequireHttpsMetadata = false;
    //            opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    //            {
    //                ValidateIssuerSigningKey = true,
    //                IssuerSigningKey = SignService.GetSymmetricSecurityKey(tokenOptions.SecurityKey),
    //                ValidateIssuer = true,
    //                ValidIssuer = tokenOptions.Issuer,
    //                ValidateAudience = true,
    //                ValidAudience = tokenOptions.Audience[0],
    //                ValidateLifetime = true,
    //                ClockSkew = TimeSpan.Zero,
    //                RequireExpirationTime=true
    //            };
    //        });
    //    }
    //}

}
