using FitnessWorkout.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessWorkout.Infrastructure.MsSql;

public class SeedExercises : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.HasData(new List<Exercise>()
        {
            new Exercise() { Id = 1, Name = "Deadlifts", WorkoutId = 1, ComplexityLevel = "Hard" },
            new Exercise() { Id = 2, Name = "Barbell Squats", WorkoutId = 1, ComplexityLevel = "Hard" },
            new Exercise() { Id = 3, Name = "Bench Press", WorkoutId = 1, ComplexityLevel = "Medium" },
            new Exercise() { Id = 4, Name = "Pull-Ups", WorkoutId = 1, ComplexityLevel = "Hard" },
            new Exercise() { Id = 5, Name = "Jump Squats", WorkoutId = 2, ComplexityLevel = "Medium" },
            new Exercise() { Id = 6, Name = "Burpees", WorkoutId = 2, ComplexityLevel = "Hard" },
            new Exercise() { Id = 7, Name = "Plank Rows", WorkoutId = 2, ComplexityLevel = "Hard" },
            new Exercise() { Id = 8, Name = "Bicep Curls", WorkoutId = 3, ComplexityLevel = "Easy" },
            new Exercise() { Id = 9, Name = "Tricep Dips", WorkoutId = 3, ComplexityLevel = "Medium" },
            new Exercise() { Id = 10, Name = "Bulgarian Split Squats", WorkoutId = 3, ComplexityLevel = "Medium" },
            new Exercise() { Id = 11, Name = "Bent-Over Rows", WorkoutId = 3, ComplexityLevel = "Medium" },
            new Exercise() { Id = 12, Name = "Barbell Deadlifts", WorkoutId = 3, ComplexityLevel = "Hard" },
            new Exercise() { Id = 13, Name = "Plank Variations", WorkoutId = 4, ComplexityLevel = "Medium" },
            new Exercise() { Id = 14, Name = "Bicycle Crunches", WorkoutId = 4, ComplexityLevel = "Easy" },
            new Exercise() { Id = 15, Name = "Leg Raises", WorkoutId = 4, ComplexityLevel = "Medium" },
            new Exercise() { Id = 16, Name = "Cable Woodchoppers", WorkoutId = 4, ComplexityLevel = "Hard" },
            new Exercise() { Id = 17, Name = "Squat to Press", WorkoutId = 5, ComplexityLevel = "Hard" },
            new Exercise() { Id = 18, Name = "Chest Flys", WorkoutId = 5, ComplexityLevel = "Easy" },
            new Exercise() { Id = 19, Name = "Dumbbell Rows", WorkoutId = 5, ComplexityLevel = "Medium" },
            new Exercise() { Id = 20, Name = "Leg Press", WorkoutId = 5, ComplexityLevel = "Medium" },
            new Exercise() { Id = 21, Name = "Leg Press2", WorkoutId = 5, ComplexityLevel = "Easy" },
        });
    }
}