using Lab2.Exceptions;
using Lab2.Services;

namespace Lab2.Data.Commands;

public class AddSongToCollectionCommand : ICommand
{

  private ICreateService Create;

  public AddSongToCollectionCommand(ICreateService receiver)
  {
    Create = receiver;
  }

  public void Execute()
  {
    Console.WriteLine("Добавлаение существующей песни исполнителя в сборник песен");
    Console.WriteLine("Введите <имя существующего артиста>, <имя песни>, <имя существующего сборника песен>");
    var (artist, songName, collectionName) = Parsing.ParseThree();
    try
    {
      var (art, song, collection) = Create.AddSongToSongCollection(artist, songName, collectionName);
      Console.WriteLine($"В сборник песен: {collection}\nАртиста: {art}\nДобавлена песня: {song}");
    }
    catch (NoSuchRecordException e)
    {
      Console.WriteLine(e.Message);
    }

    Console.WriteLine();
  }

  public string Info()
  {
    return "Добавить песню исполнителя в сборник песен";
  }
}
