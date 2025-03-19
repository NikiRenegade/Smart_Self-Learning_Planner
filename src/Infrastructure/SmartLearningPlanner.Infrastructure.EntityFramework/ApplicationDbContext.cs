using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SmartLearningPlanner.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace SmartLearningPlanner.Infrastructure.EntityFramework;


// TODO: postgresql
public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
{
    public DbSet<Tag> Tags => Set<Tag>();
    
     public DbSet<AnswerOption> AnswerOptions => Set<AnswerOption>();
     public DbSet<Quiz> Quizs => Set<Quiz>();
     public DbSet<QuizQuestion> QuizQuestions => Set<QuizQuestion>();
     public DbSet<Roadmap> Roadmaps => Set<Roadmap>();
     public DbSet<Mission> Tasks => Set<Mission>();
     public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}