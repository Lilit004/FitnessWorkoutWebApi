using FitnessWorkout.Core.Entities;

namespace FitnessWorkout.Core.Repositories;

public interface IStatusRepository
{
    Task<Status?> GetStatusById(int statusId);
}