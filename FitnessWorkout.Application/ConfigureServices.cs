using System.Reflection;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace FitnessWorkout.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddConvey();
        services.AddConvey().AddCommandHandlers().AddInMemoryCommandDispatcher();
        services.AddConvey().AddQueryHandlers().AddInMemoryQueryDispatcher();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation(config =>
        {
            config.DisableDataAnnotationsValidation = true;
        });
        services.AddFluentValidationClientsideAdapters();
        return services;
    }
}