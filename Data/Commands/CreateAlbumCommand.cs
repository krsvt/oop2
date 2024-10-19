using Lab2.Exceptions;
using Lab2.Services;

namespace Lab2.Data.Commands;

public class CreateAlbumCommand : ICommand
{

  private ICreateService Create;

  public CreateAlbumCommand(ICreateService receiver)
  {
    Create = receiver;
  }

  public void Execute()
  {
    Console.WriteLine("Добавление альбом исполнителя");
    Console.WriteLine("Введите <имя артиста>, <имя альбома>");
    var (artist, album) = Parsing.ParseTwo();
    try
    {
      var (alb, art) = Create.CreateAlbum(artist, album);
      Console.WriteLine($"Создан альбом артиста {art}\nАльбом: {alb} ");
    }
    catch (NoSuchRecordException e)
    {

      Console.WriteLine(e.Message);
    }
    Console.WriteLine();
  }

  public string Info()
  {
    return "Добавить альбом исполнителя";
  }
}
