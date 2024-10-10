using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Entities;

[Table("artist")]
public class Artist
{
  [Column("id")]
  public int Id { set; get; }

  [Column("name")]
  public string Name { set; get; } = "abc";

  [Column("genre")]
  public Genre? Genre { set; get; }

  public List<Album> Albums { set; get; } = new List<Album>();

}
