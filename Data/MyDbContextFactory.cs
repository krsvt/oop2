using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Lab2.Data;

public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
{
  public MyDbContext CreateDbContext(string[] args)
  {
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

    var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
    optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

    return new MyDbContext(configuration);
  }
}
