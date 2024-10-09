using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Entities;


public class ArtistSearchResult
{
  // public ArtistSearchResult(int id, string name)
  // {
  //   ArtistId = id;
  //   ArtistName = name;
  // }

  [Column("artist_id")]
  public int ArtistId { get; set; }

  [Column("artist_name")]
  public string? ArtistName { get; set; }
}
