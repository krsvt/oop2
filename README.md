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
*[master][~/dev/itmo/oops/lab2/Lab2]$ dotnet run
0) выход
1) искать по имени артиста
2) искать по названию альбомы и сборники
3) искать песни по критериям имя артиста + имя песни

=>1

Введите имя артиста
=>лозы   

Найдено:
Имя: Юрий Лоза

0) выход
1) искать по имени артиста
2) искать по названию альбомы и сборники
3) искать песни по критериям имя артиста + имя песни

=>2

Введите имя альбома или коллекции
=>лозы

Найдено:
Название: Лоза на волне, тип: album

0) выход
1) искать по имени артиста
2) искать по названию альбомы и сборники
3) искать песни по критериям имя артиста + имя песни

=>3

Введите <имя артиста> <имя песни>
=>юрий лоза, счастье


Найдено:
Название: Счастье

0) выход
1) искать по имени артиста
2) искать по названию альбомы и сборники
3) искать песни по критериям имя артиста + имя песни

=>0

*[master][~/dev/itmo/oops/lab2/Lab2]$ 
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

## Фабричный метод
```c#
public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
{
  public MyDbContext CreateDbContext(string[] args)
  {
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

    var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
    optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

    return new MyDbContext(configuration);
  }
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
