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
### Поиск
```
*[master][~/dev/itmo/oops/lab2]$ dotnet run
0) выход
1) искать по имени артиста
2) искать по названию альбомы и сборники
3) искать песни по критериям имя артиста + имя песни

=>лозы
Ошибка: введено не число. Попробуйте снова.
=>1

Введите имя артиста
=>лозы

Найдено:
Имя артиста: Юрий Лоза

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
Имя песни: Счастье

0) выход
1) искать по имени артиста
2) искать по названию альбомы и сборники
3) искать песни по критериям имя артиста + имя песни

=>0

*[master][~/dev/itmo/oops/lab2]$ 
```
### Создание
```
*[master][~/dev/itmo/oops/lab2]$ dotnet run
0) выход
1) искать по имени артиста
2) искать по названию альбомы и сборники
3) искать песни по критериям имя артиста + имя песни
4) добавить исполнителя
5) добавить альбом исполнителя
6) добавить новую песню исполнителя в альбом
7) добавить сборник песен
8) добавить существующую песню исполнителя в сборник песен

=>4

Введите <имя артиста>, <имя жанра>
=>дора, рэп


Созданный артист: Name: дора Genge: РЭП, Albums 0: 

0) выход
1) искать по имени артиста
2) искать по названию альбомы и сборники
3) искать песни по критериям имя артиста + имя песни
4) добавить исполнителя
5) добавить альбом исполнителя
6) добавить новую песню исполнителя в альбом
7) добавить сборник песен
8) добавить существующую песню исполнителя в сборник песен

=>5

Добавление альбом исполнителя
Введите <имя артиста>, <имя альбома>
=>дора, дура


Создан альбом артиста Name: дора Genge: РЭП, Albums 1: 
Альбом: Title: дура, Songs: 0  

0) выход
1) искать по имени артиста
2) искать по названию альбомы и сборники
3) искать песни по критериям имя артиста + имя песни
4) добавить исполнителя
5) добавить альбом исполнителя
6) добавить новую песню исполнителя в альбом
7) добавить сборник песен
8) добавить существующую песню исполнителя в сборник песен

=>6

Добавление новой песни исполнителя в альбом
Введите <имя артиста>, <имя существующего альбома>, <имя новой песни>
=>дора, дура, дора-дура

Для альбома Title: дура, Songs: 1 
артиста: Name: дора Genge: РЭП, Albums 1: 
Создана песня: дора-дура

0) выход
1) искать по имени артиста
2) искать по названию альбомы и сборники
3) искать песни по критериям имя артиста + имя песни
4) добавить исполнителя
5) добавить альбом исполнителя
6) добавить новую песню исполнителя в альбом
7) добавить сборник песен
8) добавить существующую песню исполнителя в сборник песен
=>7

Добавление нового сборника песен
Введите <имя нового сборника песен>
=>попс

Создана коллекция попс

0) выход
1) искать по имени артиста
2) искать по названию альбомы и сборники
3) искать песни по критериям имя артиста + имя песни
4) добавить исполнителя
5) добавить альбом исполнителя
6) добавить новую песню исполнителя в альбом
7) добавить сборник песен
8) добавить существующую песню исполнителя в сборник песен

=>8

Добавлаение существующей песни исполнителя в сборник песен
Введите <имя существующего артиста>, <имя песни>, <имя существующего сборника песен>
=>дора, дора-дура, попс

В сборник песен: попс
Артиста: Name: дора Genge: РЭП, Albums 1: 
Добавлена песня: дора-дура

0) выход
1) искать по имени артиста
2) искать по названию альбомы и сборники
3) искать песни по критериям имя артиста + имя песни
4) добавить исполнителя
5) добавить альбом исполнителя
6) добавить новую песню исполнителя в альбом
7) добавить сборник песен
8) добавить существующую песню исполнителя в сборник песен
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
