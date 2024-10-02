using CBTPreparation.Application.Abstractions;
using CBTPreparation.Application.Abstractions.Repositories;
using CBTPreparation.Infrastructure.Authentication;
using CBTPreparation.Infrastructure.Jwt;
using CBTPreparation.Infrastructure.Persistence;
using CBTPreparation.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace CBTPreparation_Infrastructure.Extensions
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

        public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
            services.AddScoped<ICbtSessionRepository, CbtSessionRepository>();
            services.AddScoped<IFreeQuestionRepository, FreeQuestionRepository>();
            services.AddScoped<ISessionQuestionRepository, SessionQuestionRepository>();

            return services;
        }
    }
}
