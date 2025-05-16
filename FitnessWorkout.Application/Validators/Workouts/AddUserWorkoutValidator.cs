using FitnessWorkout.Application.Commands.Workout;
using FitnessWorkout.Core.Entities;
using FitnessWorkout.Core.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace FitnessWorkout.Application.Validators.Workouts;

public class AddUserWorkoutValidator : AbstractValidator<AddUserWorkout>
{
    public AddUserWorkoutValidator(UserManager<User> userManager,
         IWorkoutRepository workoutRepository,
         IStatusRepository statusRepository)
    {
        RuleFor(c => c.UserId).NotNull().NotEmpty().WithMessage("User id is required")
            .Must(x =>
            {
                var result = userManager.FindByIdAsync(x.ToString()).Result;
                return result != null;
            }).WithMessage("User not found");

        RuleFor(c => c.WorkoutId).NotNull().NotEmpty().WithMessage("Workout id is required")
            .Must(x =>
            {
                var result = workoutRepository.GetWorkoutById(x).Result;
                return result != null;
            }).WithMessage("Workout not found");

        RuleFor(c => c.StatusId).NotNull().NotEmpty().WithMessage("Status id is required")
            .Must(x =>
            {
                var result = statusRepository.GetStatusById(x).Result;
                return result != null;
            }).WithMessage("Status not found");

        RuleFor(c => c.StartDate).Must(d => d >= DateTime.Now)
            .WithMessage("Start date cannot be in the past");
        
        RuleFor(c => c.EndDate).Must((model, endDate) => endDate > model.StartDate)
            .WithMessage("End date must be greater than start date");
    }
}