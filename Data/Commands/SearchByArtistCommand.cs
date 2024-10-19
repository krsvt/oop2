using Lab2.Entities;
using Lab2.Services;

namespace Lab2.Data.Commands;

public class SearchByArtistCommand : ICommand
{

  private ISearchService Search;

  public SearchByArtistCommand(ISearchService receiver)
  {
    Search = receiver;
  }

  public void Execute()
  {
    Console.WriteLine("Введите имя артиста");
    var line = Parsing.ParseLine();
    List<Artist> artists = Search.FuzzySearchByArtist(line);
    if (artists.Count == 0)
    {
      Console.WriteLine("Нет таких!");
    }
    else
    {
      Console.WriteLine("Найдено:");
      foreach (var art in artists)
      {
        Console.WriteLine($"Имя артиста: {art.Name}");
      }
    }

  }

  public string Info()
  {
    return "Искать по имени артиста";
  }
}
