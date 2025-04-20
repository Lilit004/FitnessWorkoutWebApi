using FitnessWorkout.Core.Entities;

namespace FitnessWorkout.Core.Repositories;

public interface IWorkoutRepository
{
    Task<List<Workout>> GetWorkouts();
    Task AddUserWorkout(UserWorkout userWorkout);
    Task<List<UserWorkout>> GetUserWorkouts(int userId);
}