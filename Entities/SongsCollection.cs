using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Entities;

[Table("songs_collection")]
public class SongsCollection : BaseIdIdentity
{

  [Column("title")]
  public string Title { get; set; } = "abc";

  // Связь с Song через промежуточную таблицу
  public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
