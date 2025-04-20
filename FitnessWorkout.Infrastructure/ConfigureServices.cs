using System.Reflection;
using FitnessWorkout.Core.Entities;
using FitnessWorkout.Core.Repositories;
using FitnessWorkout.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        services.AddTransient<IWorkoutRepository, WorkoutRepository>();
        return services;
    }
}