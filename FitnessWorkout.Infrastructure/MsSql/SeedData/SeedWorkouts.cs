using FitnessWorkout.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessWorkout.Infrastructure.MsSql;

public class SeedWorkouts : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.HasData(new List<Workout>()
        {
            new Workout()
            {
                Id = 1,
                Name = "Power Surge"
            },
            new Workout()
            {
                Id = 2,
                Name = "Total Body Blast"
            },
            new Workout()
            {
                Id = 3,
                Name = "Iron Warrior"
            },
            new Workout()
            {
                Id = 4,
                Name = "Core Fusion"
            },
            new Workout()
            {
                Id = 5,
                Name = "Muscle Mayhem"
            }
        });
    }
}