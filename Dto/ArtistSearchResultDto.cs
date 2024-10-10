using System.ComponentModel.DataAnnotations.Schema;
namespace Lab2.Dto;

public record ArtistSearchResultDto
{
  [Column("artist_id")]
  public int ArtistId { get; set; }

  [Column("artist_name")]
  public string ArtistName { get; set; } = "";
}
