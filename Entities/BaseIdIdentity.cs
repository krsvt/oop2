using System.ComponentModel.DataAnnotations.Schema;
namespace Lab2.Entities;


public class BaseIdIdentity
{

  [Column("id")]
  public int Id { set; get; }

  public BaseIdIdentity() {}
  public BaseIdIdentity(int id) { Id = id; }
}
