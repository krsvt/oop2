using Lab2.Exceptions;
using Lab2.Services;

namespace Lab2.Data.Commands;

public class CreateArtistCommand : ICommand
{

  private ICreateService Create;

  public CreateArtistCommand(ICreateService receiver)
  {
    Create = receiver;
  }

  public void Execute()
  {
    Console.WriteLine("Введите <имя артиста>, <имя жанра>");
    var (artist, genre) = Parsing.ParseTwo();
    try
    {
      var ar = Create.CreateArtist(artist, genre);
      Console.WriteLine("Созданный артист: " + ar);
    }
    catch (NoSuchRecordException e)
    {
      Console.WriteLine(e.Message);
    }

    Console.WriteLine();
  }

  public string Info()
  {
    return "Добавить исполнителя";
  }
}
