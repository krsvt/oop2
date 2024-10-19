using Lab2.Data.Commands;

namespace Lab2.Services;

// command(invoker)
public class CommandExecutorService
{

  private List<ICommand> Commands;
  public bool IsDone { get; private set; }
  public CommandExecutorService()
  {
    Commands = new List<ICommand>();
    IsDone = false;
  }


  public int CommandsCount()
  {
    return Commands.Count;
  }


  public void RegisterCommand(ICommand command)
  {
    Commands.Add(command);
  }

  public void PrintAbout()
  {
    Console.WriteLine("0) Выход");
    for (var i = 0; i < Commands.Count; i++)
    {
      Console.WriteLine($"{i + 1}) {Commands[i].Info()}");
    }
    Console.WriteLine();
  }

  public void Handle()
  {
    // 0 is exit, it is custom non-command
    int choice = Parsing.ParseInt(0, Commands.Count);
    if (choice == 0)
    {
      IsDone = true;
    }
    else
    {
      Commands[choice - 1].Execute();
    }
  }
}
