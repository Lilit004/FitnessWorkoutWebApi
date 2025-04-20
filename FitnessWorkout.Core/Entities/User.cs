using Microsoft.AspNetCore.Identity;

namespace FitnessWorkout.Core.Entities;

public class User : IdentityUser<int>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? Age { get; set; }
    
    public List<UserWorkout> UserWorkouts { get; set; }
    public List<UserExercise> UserExercises { get; set; }
}