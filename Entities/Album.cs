
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Entities;

[Table("album")]
public class Album : BaseIdIdentity
{

  [Column("title")]
  public string Title { set; get; } = "abc";

  public List<Song> Songs { set; get; } = new List<Song>();

  // public class Album() : base() { }
  // public class Album(int id, string title) : base(id)
  // { Title = title; }

}
