using FitnessWorkout.Core.Entities;
using FitnessWorkout.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkout.Infrastructure.Repositories;

public class StatusRepository : IStatusRepository
{
    private readonly FitnessWorkoutDbContext _context;

    public StatusRepository(FitnessWorkoutDbContext context)
    {
        _context = context;
    }
    public async Task<Status?> GetStatusById(int statusId)
    {
        var status = await _context.Statuses.FirstOrDefaultAsync(x => x.Id == statusId);
        return status;
    }
}