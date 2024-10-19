
using Lab2.Services;

namespace Lab2.Data.Commands;

public class SearchSongsByCriteriaCommand : ICommand
{

  private ISearchService Search;

  public SearchSongsByCriteriaCommand(ISearchService receiver)
  {
    Search = receiver;
  }

  public void Execute()
  {
    Console.WriteLine("Введите <имя артиста>, <имя песни>");
    var (artist, song) = Parsing.ParseTwo();
    var songs = Search.SearchSongsByCriterias(artist, song);

    if (songs.Count == 0)
    {
      Console.WriteLine("Нет таких!");
    }
    else
    {
      Console.WriteLine("Найдено:");
      foreach (var son in songs)
      {
        Console.WriteLine($"Имя песни: {son.Title}");
      }
    }
    Console.WriteLine();
  }

  public string Info()
  {
    return "Искать песни по критериям имя артиста + имя песни";
  }
}
