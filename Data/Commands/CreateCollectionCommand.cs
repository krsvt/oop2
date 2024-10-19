using Lab2.Exceptions;
using Lab2.Services;

namespace Lab2.Data.Commands;

public class CreateCollectionCommand : ICommand
{

  private ICreateService Create;

  public CreateCollectionCommand(ICreateService receiver)
  {
    Create = receiver;
  }

  public void Execute()

  {
    Console.WriteLine("Добавление нового сборника песен");
    Console.WriteLine("Введите <имя нового сборника песен>");
    var collection = Parsing.ParseOne();
    try
    {
      var col = Create.CreateSongsCollection(collection);
      Console.WriteLine($"Создана коллекция {col}");
    }
    catch (NoSuchRecordException e)
    {
      Console.WriteLine(e.Message);
    }

    Console.WriteLine();
  }


  public string Info()
  {
    return "Добавить сборник песен";
  }
}
