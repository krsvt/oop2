using System.Reflection;
using Lab2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lab2.Data;

public class MyDbContext : DbContext
{
  private readonly IConfiguration configuration;

  // Свойство DbSet для сущности Song
  // public DbSet<Song> Songs { get; set; }
  // public DbSet<Album> Albums { get; set; }
  // public DbSet<Artist> Artists { get; set; }
  // public DbSet<Genre> Genres { get; set; }
  // public DbSet<SongsCollection> SongsCollection { get; set; }

  // Конструктор для DI (внедрения зависимостей)
  public MyDbContext(IConfiguration configuration) : base()
  {
    this.configuration = configuration;
  }

  // Метод для настройки подключения к базе данных
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      // Используем строку подключения из конфигурации
      optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Получаем все классы в пространстве имен Lab2.Entities
    var entityTypes = Assembly.GetExecutingAssembly().GetTypes()
      .Where(t => t.Namespace == "Lab2.Entities" && t.IsClass && !t.IsAbstract);

    // Добавляем каждую сущность в модель
    foreach (var entityType in entityTypes)
    {
      modelBuilder.Entity(entityType);
    }
    // Настраиваем многие ко многим отношения между Song и SongsCollection
    modelBuilder.Entity<Song>()
        .HasMany(s => s.SongsCollections) // Указываем, что Song имеет много SongsCollections
        .WithMany(sc => sc.Songs) // И SongsCollection имеет много Songs
        .UsingEntity(j => j.ToTable("song_songs_collection")); // Имя промежуточной таблицы
  }

}
