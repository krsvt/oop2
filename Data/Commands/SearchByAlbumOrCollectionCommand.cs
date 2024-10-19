using Lab2.Services;

namespace Lab2.Data.Commands;

public class SearchByAlbumOrCollectionCommand : ICommand
{

  private ISearchService Search;

  public SearchByAlbumOrCollectionCommand(ISearchService receiver)
  {
    Search = receiver;
  }

  public void Execute()
  {
    Console.WriteLine("Введите имя альбома или коллекции");
    var line = Parsing.ParseLine();
    var albumAndCollectionResults = Search.FuzzySearchByAlbumsAndSongsCollections(line);
    if (albumAndCollectionResults.Count == 0)
    {
      Console.WriteLine("Нет таких!");
    }
    else
    {
      Console.WriteLine("Найдено:");
      foreach (var col in albumAndCollectionResults)
      {
        Console.WriteLine($"Название: {col.Title}, тип: {col.Type}");
      }
    }
    Console.WriteLine();

  }

  public string Info()
  {
    return "Искать по названию альбомы и сборники";
  }
}
