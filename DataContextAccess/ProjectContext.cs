using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess;

public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {

    }
    public ProjectContext()
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlite("Data Source=database.db");
        //optionsBuilder.UseOracle(connectionString: Environment.GetEnvironmentVariable("UdemyWebApiOracle"));
        optionsBuilder.UseOracle(Environment.GetEnvironmentVariable("ORACLE_CONNECTION_STRING"));
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
}
