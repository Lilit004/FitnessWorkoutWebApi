﻿namespace FitnessWorkout.Core.Entities;

public class Status
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<UserWorkout> UserWorkouts { get; set; }
}