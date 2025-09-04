using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SmartLearningPlanner.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace SmartLearningPlanner.Infrastructure.EntityFramework;

// TODO: postgresql
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Tag> Tags => Set<Tag>();

    public DbSet<QuizQuestionAnswerOption> AnswerOptions => Set<QuizQuestionAnswerOption>();

    public DbSet<Quiz> Quizzes => Set<Quiz>();

    public DbSet<QuizQuestion> QuizQuestions => Set<QuizQuestion>();

    public DbSet<UserNodeProgress> UserNodeProgresses => Set<UserNodeProgress>();

    public DbSet<MindmapNode> MindmapNodes => Set<MindmapNode>();

    public DbSet<MindmapEdge> MindmapEdges => Set<MindmapEdge>();

    public DbSet<Mission> Missions => Set<Mission>();

    public DbSet<QuizQuestionType> QuizQuestionTypes => Set<QuizQuestionType>();


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}