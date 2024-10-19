
namespace Lab2.Data.Commands;

public interface ICommand
{
  public void Execute();
  public string Info();
}
