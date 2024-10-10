using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Entities;

[Table("genre")]
public record Genre
{
  [Column("id")]
  public int Id { set; get; }

  [Column("name")]
  public string? Name { set; get; } = "abc";

}
