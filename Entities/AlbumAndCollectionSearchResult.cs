using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Entities;

public class AlbumAndCollectionSearchResult
{
  [Column("id")]
  public int Id { get; set; }

  [Column("title")]
  public string? Title { get; set; }

  [Column("type")]
  public string? Type { get; set; }
}
