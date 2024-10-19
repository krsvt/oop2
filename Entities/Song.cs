using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Entities;

[Table("song")]
public class Song : BaseIdIdentity
{

  [Column("title")]
  public string Title { get; set; } = "abc";

  // Связь с SongsCollection через промежуточную таблицу
  public virtual ICollection<SongsCollection> SongsCollections { get; set; } = new List<SongsCollection>();
}
