using System;
using Microsoft.AspNetCore.Identity;
namespace SmartLearningPlanner.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public List<Quiz> CreatedQuizzes { get; set; } = new();
}
