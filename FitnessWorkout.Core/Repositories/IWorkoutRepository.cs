using FitnessWorkout.Core.Entities;

namespace FitnessWorkout.Core.Repositories;

public interface IWorkoutRepository
{
    Task<List<Workout>> GetWorkouts();
    Task<Workout?> GetWorkoutById(int workoutId);
    Task AddUserWorkout(UserWorkout userWorkout);
    Task<List<UserWorkout>> GetUserWorkouts(int userId);
    Task UpdateUserWorkout(UserWorkout userWorkout);
    Task<UserWorkout?> GetUserWorkoutById(int userWorkoutId);
}