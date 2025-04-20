using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FitnessWorkout.Infrastructure;

public class DbContextFactory : IDesignTimeDbContextFactory<FitnessWorkoutDbContext>
{
    public FitnessWorkoutDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FitnessWorkoutDbContext>();
        optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-ICI6R6K; Database=FitnessWorkoutDb; Integrated Security=True; TrustServerCertificate=true");
        return new FitnessWorkoutDbContext(optionsBuilder.Options);
    }
}