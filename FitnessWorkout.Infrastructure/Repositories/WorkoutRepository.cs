using FitnessWorkout.Application.DTO.Workouts;
using FitnessWorkout.Core.Entities;
using FitnessWorkout.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkout.Infrastructure.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly FitnessWorkoutDbContext _context;
    public WorkoutRepository(FitnessWorkoutDbContext context)
    {
        _context = context;
    }
    public async Task<List<Workout>> GetWorkouts()
    {
        var workouts = await _context.Workouts
            .Include(x => x.Exercises)
            .ToListAsync();
        return workouts;
    }

    public async Task<Workout?> GetWorkoutById(int workoutId)
    {
        var workout = await _context.Workouts.FirstOrDefaultAsync(x => x.Id == workoutId);
        return workout;
    }

    public async Task AddUserWorkout(UserWorkout userWorkout)
    {
        await _context.UserWorkouts.AddAsync(userWorkout);
        await _context.SaveChangesAsync();
    }

    public async Task<List<UserWorkout>> GetUserWorkouts(int userId)
    {
        var userWorkouts = await _context.UserWorkouts.Where(x => x.UserId == userId)
            .Include(x => x.Workout)
            .Include(x => x.Status)
            .ToListAsync();
        return userWorkouts;
    }

    public async Task UpdateUserWorkout(UserWorkout userWorkout)
    {
        _context.UserWorkouts.Update(userWorkout);
        await _context.SaveChangesAsync();
    }

    public async Task<UserWorkout?> GetUserWorkoutById(int userWorkoutId)
    {
        var userWorkout = await _context.UserWorkouts.FirstOrDefaultAsync(x => x.Id == userWorkoutId);
        return userWorkout;
    }
}