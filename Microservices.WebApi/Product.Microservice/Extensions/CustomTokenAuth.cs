using Product.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Extensions
{

    //public static class CustomTokenAuth
    //{
    //    public static void AddCustomTokenAuth(this IServiceCollection services, CustomTokenOption tokenOptions)
    //    {
    //        string authenticationProviderKey = "Bearer";
    //        services.AddAuthentication(options =>
    //        {
    //            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    //            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //        }).AddJwtBearer(authenticationProviderKey, opts =>
    //        {
    //            opts.RequireHttpsMetadata = false;
    //            opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    //            {
    //                ValidIssuer = tokenOptions.Issuer,
    //                ValidAudience = tokenOptions.Audience[0],
    //                IssuerSigningKey = Product.Services.SignService.GetSymmetricSecurityKey(tokenOptions.SecurityKey),

    //                ValidateIssuerSigningKey = true,
    //                ValidateAudience = true,
    //                ValidateIssuer = true,
    //                ValidateLifetime = true,
    //                ClockSkew = TimeSpan.Zero
    //            };
    //        });
    //    }
    //}

}
