
using Lab2.Exceptions;
using Lab2.Services;

namespace Lab2.Data.Commands;

public class CreateSongCommand : ICommand
{

  private ICreateService Create;

  public CreateSongCommand(ICreateService receiver)
  {
    Create = receiver;
  }

  public void Execute()
  {
    Console.WriteLine("Добавление новой песни исполнителя в альбом");
    Console.WriteLine("Введите <имя артиста>, <имя существующего альбома>, <имя новой песни>");
    var (artist, album, song) = Parsing.ParseThree();
    try
    {
      var (alb, art, s) = Create.CreateSongToAlbum(artist, album, song);
      Console.WriteLine($"Для альбома {alb}\nартиста: {art}\nСоздана песня: {song}");
    }
    catch (NoSuchRecordException e)
    {
      Console.WriteLine(e.Message);
    }

    Console.WriteLine();
  }

  public string Info()
  {
    return "Добавить новую песню исполнителя в альбом";
  }
}
