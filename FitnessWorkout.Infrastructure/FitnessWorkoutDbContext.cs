using FitnessWorkout.Core.Entities;
using FitnessWorkout.Infrastructure.MsSql;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkout.Infrastructure;

public class FitnessWorkoutDbContext : IdentityDbContext<User,Role,int>
{
    public FitnessWorkoutDbContext(DbContextOptions<FitnessWorkoutDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<UserWorkout> UserWorkouts { get; set; }
    public DbSet<UserExercise> UserExercises { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>()
            .Property(x => x.Id)
            .UseIdentityColumn();
        
        modelBuilder.Entity<Exercise>().HasOne(x => x.Workout)
            .WithMany(x => x.Exercises)
            .HasForeignKey(x => x.WorkoutId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserWorkout>().HasOne(x => x.User)
            .WithMany(x => x.UserWorkouts)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<UserWorkout>().HasOne(x => x.Workout)
            .WithMany(x => x.UserWorkouts)
            .HasForeignKey(x => x.WorkoutId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<UserWorkout>().HasOne(x => x.Status)
            .WithMany(x => x.UserWorkouts)
            .HasForeignKey(x => x.StatusId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<UserExercise>().HasOne(x => x.UserWorkout)
            .WithMany(x => x.UserEx)
            .HasForeignKey(x => x.UserWorkoutId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserExercise>().HasOne(x => x.Exercise)
            .WithMany(x => x.UserEx)
            .HasForeignKey(x => x.ExerciseId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.ApplyConfiguration(new SeedStatuses());
        modelBuilder.ApplyConfiguration(new SeedWorkouts());
        modelBuilder.ApplyConfiguration(new SeedExercises());
    }
}