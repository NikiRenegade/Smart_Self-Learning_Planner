using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SmartLearningPlanner.Domain.Entities;

namespace SmartLearningPlanner.Infrastructure.EntityFramework;


// TODO: postgresql
public class ApplicationDbContext: DbContext
{
   
    
    // public DbSet<AnswerOption> AnswerOptions => Set<AnswerOption>();
    // public DbSet<Quiz> Quizs => Set<Quiz>();
    // public DbSet<QuizQuestion> QuizQuestions => Set<QuizQuestion>();
    // public DbSet<Roadmap> Roadmaps => Set<Roadmap>();
    // public DbSet<Task> Tasks => Set<Task>();
    public DbSet<Tag> Tags => Set<Tag>();
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}