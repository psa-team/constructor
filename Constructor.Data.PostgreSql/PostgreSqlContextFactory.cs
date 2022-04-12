using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Constructor.Data.PostgreSql;

public class PostgreSqlContextFactory : IDesignTimeDbContextFactory<ConstructorDbContext>
{
    public ConstructorDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ConstructorDbContext>();

        ConfigurationBuilder builder = new();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");
        IConfigurationRoot config = builder.Build();

        string connectionString = config.GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString);

        //optionsBuilder.UseNpgsql("Host=localhost;Database=prototype;Username=dev;Password=dev");
        return new ConstructorDbContext(optionsBuilder.Options);
    }
}