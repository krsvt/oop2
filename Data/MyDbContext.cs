using Lab2.Entities;
using Lab2.Dto;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Data;

public class MyDbContext : DbContext
{
  public MyDbContext(DbContextOptions<MyDbContext> options)
      : base(options)
  {
  }

  public DbSet<Song> Songs { get; set; } = null!;
  public DbSet<SongsCollection> SongsCollections { get; set; } = null!;
  public DbSet<Album> Albums { get; set; } = null!;
  public DbSet<Artist> Artists { get; set; } = null!;
  public DbSet<Genre> Genres { get; set; } = null!;
  public DbSet<ArtistSearchResultDto> ArtistSearchResults { get; set; }
  public DbSet<AlbumAndCollectionSearchResultDto> AlbumAndCollectionSearchResultDto { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Song>()
      .HasMany(s => s.SongsCollections)
      .WithMany(sc => sc.Songs)
      .UsingEntity(j => j.ToTable("song_songs_collection"));

    // Определяем ArtistSearchResultDto как безключевую сущность
    modelBuilder.Entity<ArtistSearchResultDto>()
      .HasNoKey();

    modelBuilder.Entity<AlbumAndCollectionSearchResultDto>()
      .HasNoKey();

  }
}
