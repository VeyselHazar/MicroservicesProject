using Gate.Configurations;
using Gate.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CustomTokenOption>(_configuration.GetSection("JWT"));

            SymmetricSecurityKey signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:securityKey"]));

            string authenticationProviderKey = "Bearer";
            services.AddAuthentication()
                .AddJwtBearer(authenticationProviderKey, options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signInKey,
                        ValidateIssuer = true,
                        ValidIssuer = _configuration["JWT:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = _configuration["JWT:Audience"],
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        RequireExpirationTime = true
                    };
                });
            

            services.AddOcelot();
            services.AddControllers();
            //services.AddAuthentication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        async public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            await app.UseOcelot();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
