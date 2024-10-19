using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Entities;

[Table("songs_collection")]
public class SongsCollection : BaseIdIdentity
{

  [Column("title")]
  public string Title { get; set; } = "";

  // Связь с Song через промежуточную таблицу
  public virtual ICollection<Song> Songs { get; set; } = new List<Song>();


  public override string ToString()
  {
    return $"{Title}";
  }
}
