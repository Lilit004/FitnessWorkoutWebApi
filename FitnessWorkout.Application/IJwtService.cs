using FitnessWorkout.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace FitnessWorkout.Application;

public interface IJwtService
{
    string GenerateToken(User user);
}