using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SmartLearningPlanner.Infrastructure.EntityFramework;
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Database=SmartLearningPlannerDB; Username=postgres; Password=P@$$w0rd");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
