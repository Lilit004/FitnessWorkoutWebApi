using FitnessWorkout.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessWorkout.Infrastructure.MsSql;

public class SeedStatuses : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.HasData(new List<Status>(){
        new Status()
        {
            Id = 1,
            Name = "Active"
        },
        new Status()
        {
            Id = 2,
            Name = "Pending"
        },
        new Status()
        {
            Id = 3,
            Name = "Paused"
        },
        new Status()
        {
            Id = 4,
            Name = "Completed"
        },
        new Status()
        {
            Id = 5,
            Name = "Canceled"
        },
        new Status()
        {
            Id = 6,
            Name = "Expired"
        }
        });
    }
}