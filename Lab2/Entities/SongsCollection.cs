using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Entities;

[Table("songs_collection")]
public class SongsCollection
{
  [Column("id")]
  public int Id { get; set; }

  [Column("title")]
  public string? Title { get; set; }

  // Связь с Song через промежуточную таблицу
  public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
