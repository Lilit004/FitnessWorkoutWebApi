using AutoMapper;
using FitnessWorkout.Application.Commands.User;
using FitnessWorkout.Application.Commands.Workout;
using FitnessWorkout.Application.DTO.Workout;
using FitnessWorkout.Core.Entities;

namespace FitnessWorkout.Infrastructure;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddUser,User>();
        CreateMap<Workout, WorkoutDto>();
        CreateMap<AddUserWorkout, UserWorkout>();
        CreateMap<UpdateUserWorkout,UserWorkout>();
    }
}