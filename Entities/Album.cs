
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Entities;

[Table("album")]
public class Album : BaseIdIdentity
{

  [Column("title")]
  public string Title { set; get; } = "";

  public List<Song> Songs { set; get; } = new List<Song>();

  public override string ToString()
  {
    return $"Title: {Title}, Songs: {Songs.Count} ";
  }

}
