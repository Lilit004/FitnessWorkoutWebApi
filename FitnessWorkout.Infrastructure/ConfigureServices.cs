using System.Reflection;
using System.Text;
using FitnessWorkout.Application;
using FitnessWorkout.Core.Entities;
using FitnessWorkout.Core.Repositories;
using FitnessWorkout.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FitnessWorkout.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FitnessWorkoutDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
        services.AddIdentity<User, Role>().AddEntityFrameworkStores<FitnessWorkoutDbContext>()
            .AddDefaultTokenProviders();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["AuthConfiguration:Issuer"],
                    ValidAudience = configuration["AuthConfiguration:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthConfiguration:Key"]))
                };
            });

        services.AddTransient<IWorkoutRepository, WorkoutRepository>();
        services.AddTransient<IJwtService, JwtService>();
        return services;
    }
}