using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Entities;

[Table("song")]
public class Song
{
  [Column("id")]
  public int Id { get; set; }

  [Column("title")]
  public string Title { get; set; } = "";

  // Связь с SongsCollection через промежуточную таблицу
  public virtual ICollection<SongsCollection> SongsCollections { get; set; } = new List<SongsCollection>();
}
