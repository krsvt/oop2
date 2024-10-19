using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Entities;

[Table("artist")]
public class Artist : BaseIdIdentity
{
  [Column("name")]
  public string Name { set; get; } = "abc";

  [Column("genre")]
  public Genre? Genre { set; get; }

  public List<Album> Albums { set; get; } = new List<Album>();


  public override string ToString()
  {
    return $"Name: {Name} Genge: {Genre?.Name}, Albums {Albums.Count}: ";
  }


}
