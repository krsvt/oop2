1. Считаем, что артисты не могут выпустить альбом вместе (один альбом - один артист).
2. Можно считать, что трек не существует вне альбома. То есть если трек выпущен, он должен присутствовать хотя бы в одном альбоме, даже если там этот трек - единственный (такие альбомы называются синглами).
3. Можем считать, что Сборник - это произвольный набор треков, имеющих что-то общее, из вышедших ранее альбомов (разных исполнителей).


# Использование

## PostgreSQL
```shell
docker compose up
```

## Миграции
```shell
make migration-up
```

## Исполнение
```
0) Выход
1) Искать по имени артиста
2) Искать по названию альбомы и сборники
3) Искать песни по критериям имя артиста + имя песни
4) Добавить исполнителя
5) Добавить альбом исполнителя
6) Добавить новую песню исполнителя в альбом
7) Добавить сборник песен
8) Добавить песню исполнителя в сборник песен

=>1

Введите имя артиста
=>лозы

Найдено:
Имя артиста: Юрий Лоза
0) Выход
1) Искать по имени артиста
2) Искать по названию альбомы и сборники
3) Искать песни по критериям имя артиста + имя песни
4) Добавить исполнителя
5) Добавить альбом исполнителя
6) Добавить новую песню исполнителя в альбом
7) Добавить сборник песен
8) Добавить песню исполнителя в сборник песен

=>2

Введите имя альбома или коллекции
=>лозы

Найдено:
Название: Лоза на волне, тип: album

0) Выход
1) Искать по имени артиста
2) Искать по названию альбомы и сборники
3) Искать песни по критериям имя артиста + имя песни
4) Добавить исполнителя
5) Добавить альбом исполнителя
6) Добавить новую песню исполнителя в альбом
7) Добавить сборник песен
8) Добавить песню исполнителя в сборник песен

=>3

Введите <имя артиста>, <имя песни>
=>лоза, счастье


Найдено:
Имя песни: Счастье

0) Выход
1) Искать по имени артиста
2) Искать по названию альбомы и сборники
3) Искать песни по критериям имя артиста + имя песни
4) Добавить исполнителя
5) Добавить альбом исполнителя
6) Добавить новую песню исполнителя в альбом
7) Добавить сборник песен
8) Добавить песню исполнителя в сборник песен

=>4

Введите <имя артиста>, <имя жанра>
=>мой исполнитель, рэп


Созданный артист: Name: мой исполнитель Genge: РЭП, Albums 0: 

0) Выход
1) Искать по имени артиста
2) Искать по названию альбомы и сборники
3) Искать песни по критериям имя артиста + имя песни
4) Добавить исполнителя
5) Добавить альбом исполнителя
6) Добавить новую песню исполнителя в альбом
7) Добавить сборник песен
8) Добавить песню исполнителя в сборник песен

=>5

Добавление альбом исполнителя
Введите <имя артиста>, <имя альбома>
=>мой исполнитель, мой альбом


Создан альбом артиста Name: мой исполнитель Genge: РЭП, Albums 1: 
Альбом: Title: мой альбом, Songs: 0  

0) Выход
1) Искать по имени артиста
2) Искать по названию альбомы и сборники
3) Искать песни по критериям имя артиста + имя песни
4) Добавить исполнителя
5) Добавить альбом исполнителя
6) Добавить новую песню исполнителя в альбом
7) Добавить сборник песен
8) Добавить песню исполнителя в сборник песен

=>6

Добавление новой песни исполнителя в альбом
Введите <имя артиста>, <имя существующего альбома>, <имя новой песни>
=>мой исполнитель, мой альбом, моя песня

Для альбома Title: мой альбом, Songs: 1 
артиста: Name: мой исполнитель Genge: РЭП, Albums 1: 
Создана песня: моя песня

0) Выход
1) Искать по имени артиста
2) Искать по названию альбомы и сборники
3) Искать песни по критериям имя артиста + имя песни
4) Добавить исполнителя
5) Добавить альбом исполнителя
6) Добавить новую песню исполнителя в альбом
7) Добавить сборник песен
8) Добавить песню исполнителя в сборник песен

=>7

Добавление нового сборника песен
Введите <имя нового сборника песен>
=>мой сборник песен

Создана коллекция мой сборник песен

0) Выход
1) Искать по имени артиста
2) Искать по названию альбомы и сборники
3) Искать песни по критериям имя артиста + имя песни
4) Добавить исполнителя
5) Добавить альбом исполнителя
6) Добавить новую песню исполнителя в альбом
7) Добавить сборник песен
8) Добавить песню исполнителя в сборник песен

=>8

Добавлаение существующей песни исполнителя в сборник песен
Введите <имя существующего артиста>, <имя песни>, <имя существующего сборника песен>
=>мой исполнитель, моя песня, мой сборник песен

В сборник песен: мой сборник песен
Артиста: Name: мой исполнитель Genge: РЭП, Albums 1: 
Добавлена песня: моя песня

0) Выход
1) Искать по имени артиста
2) Искать по названию альбомы и сборники
3) Искать песни по критериям имя артиста + имя песни
4) Добавить исполнителя
5) Добавить альбом исполнителя
6) Добавить новую песню исполнителя в альбом
7) Добавить сборник песен
8) Добавить песню исполнителя в сборник песен

=>0

*[master][~/dev/itmo/oop/oop2]$ 
```

# БД
```
postgres=# \d
                   List of relations
 Schema |          Name           |   Type   |  Owner   
--------+-------------------------+----------+----------
 public | __EFMigrationsHistory   | table    | postgres
 public | album                   | table    | postgres
 public | album_id_seq            | sequence | postgres
 public | artist                  | table    | postgres
 public | artist_id_seq           | sequence | postgres
 public | genre                   | table    | postgres
 public | genre_id_seq            | sequence | postgres
 public | song                    | table    | postgres
 public | song_id_seq             | sequence | postgres
 public | song_songs_collection   | table    | postgres
 public | songs_collection        | table    | postgres
 public | songs_collection_id_seq | sequence | postgres
(12 rows)
```

# Поиск

```sql
CREATE OR REPLACE FUNCTION SearchByArtist(query TEXT)
RETURNS TABLE(artist_id INT, artist_name TEXT) AS $$
BEGIN
RETURN QUERY
SELECT a.id, a.name
FROM artist a
WHERE to_tsvector('russian', a.name) @@ plainto_tsquery('russian', query)
OR SIMILARITY(a.name, query) > 0.3
OR a.name ILIKE '%' || query || '%'
ORDER BY ts_rank(to_tsvector('russian', a.name), plainto_tsquery('russian', query)) DESC,
SIMILARITY(a.name, query) DESC
LIMIT 5;
END;
$$ LANGUAGE plpgsql;
```

```sql
CREATE OR REPLACE FUNCTION SearchByAlbumsAndSongsCollections(query TEXT)
RETURNS TABLE(id INT, title TEXT, type TEXT) AS $$
BEGIN
RETURN QUERY
SELECT a.id AS id, a.title AS title, 'album' AS type
FROM album a
WHERE to_tsvector('russian', a.title) @@ plainto_tsquery('russian', query)
OR SIMILARITY(a.title, query) > 0.3

UNION ALL

SELECT sc.id AS id, sc.title AS title, 'songs_collection' AS type
FROM songs_collection sc
WHERE to_tsvector('russian', sc.title) @@ plainto_tsquery('russian', query)
OR SIMILARITY(sc.title, query) > 0.3

ORDER BY title
LIMIT 5;
END;
$$ LANGUAGE plpgsql;
```

# Паттерны

## Команда

### Команда
```c#
namespace Lab2.Data.Commands;

public interface ICommand
{
  public void Execute();
  public string Info();
}
```
### Конкретная команда
```c#
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
```

### Инвокер
```c#
using Lab2.Data.Commands;

namespace Lab2.Services;

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

```

### использование
```c#
    commandExecutorService.RegisterCommand(new Lab2.Data.Commands.SearchByArtistCommand(searchService));
    commandExecutorService.RegisterCommand(new Lab2.Data.Commands.SearchByAlbumOrCollectionCommand(searchService));
    commandExecutorService.RegisterCommand(new Lab2.Data.Commands.SearchSongsByCriteriaCommand(searchService));
    commandExecutorService.RegisterCommand(new Lab2.Data.Commands.CreateArtistCommand(createService));
    commandExecutorService.RegisterCommand(new Lab2.Data.Commands.CreateAlbumCommand(createService));
    commandExecutorService.RegisterCommand(new Lab2.Data.Commands.CreateSongCommand(createService));
    commandExecutorService.RegisterCommand(new Lab2.Data.Commands.CreateCollectionCommand(createService));
    commandExecutorService.RegisterCommand(new Lab2.Data.Commands.AddSongToCollectionCommand(createService));

    var isDone = false;
    while (!isDone)
    {
        commandExecutorService.PrintAbout();
        commandExecutorService.Handle();
        isDone = commandExecutorService.IsDone;
    }

```

## Адаптер
```c#
public class ArtistSearchResultAdapter : Artist
{
  public ArtistSearchResultAdapter(ArtistSearchResult searchResult)
  {
    Id = searchResult.ArtistId;
    Name = searchResult.ArtistName;
    Genre = null;
    Albums = new List<Album>();
  }
}
```
```
List<ArtistSearchResult> results = searchService.SearchByArtist(line);
List<ArtistSearchResultAdapter> artists = results.Select(a => new ArtistSearchResultAdapter(a))
.ToList();
// ...

foreach (var art in artists)
{
  Console.WriteLine($"Имя: {art.Name}");
}
```
