using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Jwt;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddJWTAuth(this IServiceCollection services, IConfiguration config)
        {
            services.AddOptions<JwtSettings>()
           .BindConfiguration(nameof(JwtSettings))
           .ValidateDataAnnotations()
           .ValidateOnStart();

            services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>();

            return services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, null!)
                .Services;
        }
        public static void ConfigureDbContext(this IServiceCollection services,
          IConfiguration configuration) =>
          services.AddDbContext<CBTDbContext>(opts =>
              opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    }
}
