using Lab2.Data;
using Lab2.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var serviceProvider = new ServiceCollection()
    .AddSingleton<IConfiguration>(configuration) // Добавляем IConfiguration
    .BuildServiceProvider();

using (var scope = serviceProvider.CreateScope())
{
    var dbContext = new MyDbContext(configuration);

    // Создание новой сущности Song
    // var song1 = new Song
    // {
    //     Title = "My Song Title"
    // };
    //
    // var song2 = new Song
    // {
    //     Title = "My Song2 Title"
    // };
    // var songs1 = new List<Song>();
    // songs1.Add(song1);
    // songs1.Add(song2);
    //
    //
    // var song3 = new Song
    // {
    //     Title = "My Song3 Title"
    // };
    //
    // var song4 = new Song
    // {
    //     Title = "My Song4 Title"
    // };
    //
    // var songs2 = new List<Song>();
    // songs2.Add(song3);
    // songs2.Add(song4);
    //
    // // Создание новой сущности Album
    // var album1 = new Album
    // {
    //     Title = "My Album Title",
    //     Songs = songs1
    // };
    //
    // var album2 = new Album
    // {
    //     Title = "My Album2 Title",
    //     Songs = songs2
    // };
    //
    // // Создание новой сущности SongsCollection
    // var songsCollection = new SongsCollection
    // {
    //     Title = "My Songs Collection"
    // };
    //
    // songsCollection.Songs.Add(song1);
    // song1.SongsCollections.Add(songsCollection);
    //
    // songsCollection.Songs.Add(song3);
    // song3.SongsCollections.Add(songsCollection);
    //
    //
    // var songsCollection2 = new SongsCollection
    // {
    //     Title = "My Songs Collection2"
    // };
    //
    // songsCollection2.Songs.Add(song2);
    // song2.SongsCollections.Add(songsCollection2);
    // songsCollection2.Songs.Add(song4);
    // song4.SongsCollections.Add(songsCollection2);
    //
    // var albums1 = new List<Album>();
    // albums1.Add(album1);
    //
    // var albums2 = new List<Album>();
    // albums2.Add(album2);
    //
    // var genre1 = new Genre { Name = "RAP"};
    // var genre2 = new Genre { Name = "POP"};
    //
    // var artist1 = new Artist
    // {
    //     Name = "A",
    //     Genre = genre1,
    //     Albums = albums1
    // };
    //
    // var artist2 = new Artist
    // {
    //     Name = "B",
    //     Genre = genre2,
    //     Albums = albums2
    // };
    //
    // dbContext.Albums.Add(album1);
    // dbContext.Albums.Add(album2);
    // dbContext.SongsCollections.Add(songsCollection);
    // dbContext.SongsCollections.Add(songsCollection2);
    // dbContext.Artists.Add(artist1);
    // dbContext.Artists.Add(artist2);
    //
    //
    // Сохранение в базу данных
    //
    //
    var artistResults = dbContext.ArtistSearchResults
        .FromSqlRaw("SELECT * FROM SearchByArtist({0})", "А")
        .ToList();

    // Вызов функции SearchByAlbumsAndSongsCollections
    var albumAndCollectionResults = dbContext.AlbumAndCollectionSearchResults
        .FromSqlRaw("SELECT * FROM SearchByAlbumsAndSongsCollections({0})", "музыка")
        .ToList();

    Console.WriteLine("Результаты поиска по артистам:");
    foreach (var artist in artistResults)
    {
        Console.WriteLine($"ID: {artist.ArtistId}, Имя: {artist.ArtistName}");
    }
    Console.WriteLine("\nРезультаты поиска по альбомам и коллекциям:");
    foreach (var albumOrCollection in albumAndCollectionResults)
    {
        Console.WriteLine($"ID: {albumOrCollection.Id}, Название: {albumOrCollection.Title}, Тип: {albumOrCollection.Type}");
    }
    dbContext.SaveChanges();
}
//
// class Program
// {
//     static void Main(string[] args)
//     {
//         // Создаем конфигурацию и загружаем настройки из appsettings.json
//         var builder = new ConfigurationBuilder()
//             .SetBasePath(Directory.GetCurrentDirectory())  // Устанавливаем базовый путь
//             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);  // Добавляем JSON файл конфигурации
//
//         IConfiguration config = builder.Build();
//
//         // Получаем настройку ApplicationName из конфигурации
//         string appName = config["AppSettings:ApplicationName"] ?? "DefaultAppName";
//         Console.WriteLine($"Application Name: {appName}");
//
//         using (var context = new MyDbContext(configuration))
//         {
//             var song = new Song
//             {
//                 Title = "My Song Title",
//                       GenreId = 1, // Укажите правильный ID жанра
//                       AlbumId = 1  // Укажите правильный ID альбома
//             };
//
//             context.Songs.Add(song);
//             context.SaveChanges();
//         }
//
//     }
// }
