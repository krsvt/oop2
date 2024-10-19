using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Dto;

public record AlbumAndCollectionSearchResultDto
{

  [Column("id")]
  public int Id { get; set; }

  public string? Title { get; set; }

  public string? Type { get; set; }
}
