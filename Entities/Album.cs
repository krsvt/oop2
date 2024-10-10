
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Entities;

[Table("album")]
public record Album
{
  [Column("id")]
  public int Id { set; get; }

  [Column("title")]
  public string? Title { set; get; }

  public List<Song> Songs { set; get; } = new List<Song>();

}
