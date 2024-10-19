using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Entities;

[Table("genre")]
public class Genre : BaseIdIdentity
{

  [Column("name")]
  public string Name { set; get; } = "abc";

}
