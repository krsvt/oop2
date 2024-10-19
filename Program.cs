
using Lab2.Data;
using Lab2.Dto;
using Lab2.Entities;
using Lab2.Exceptions;
using Lab2.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var serviceProvider = new ServiceCollection()
    .AddDbContext<MyDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")))
    .AddScoped<ISearchService, PostgreSQlSearchService>()
    .AddScoped<ICreateService, PostgreSQLCreateService>()
    .BuildServiceProvider();

using (var scope = serviceProvider.CreateScope())
{
    var searchService = scope.ServiceProvider.GetRequiredService<ISearchService>();
    var createService = scope.ServiceProvider.GetRequiredService<ICreateService>();

    var notExit = true;
    while (notExit)
    {
        Console.WriteLine("0) выход");
        Console.WriteLine("1) искать по имени артиста");
        Console.WriteLine("2) искать по названию альбомы и сборники");
        Console.WriteLine("3) искать песни по критериям имя артиста + имя песни");
        Console.WriteLine("4) добавить исполнителя");
        Console.WriteLine("5) добавить альбом исполнителя");
        Console.WriteLine("6) добавить новую песню исполнителя в альбом");
        Console.WriteLine("7) добавить сборник песен");
        Console.WriteLine("8) добавить существующую песню исполнителя в сборник песен");
        Console.WriteLine();
        int choice = Parsing.ParseInt(0, 8);
        if (choice == 0) notExit = false;
        else if (choice == 1)
        {
            Console.WriteLine("Введите имя артиста");
            var line = Parsing.ParseLine();
            List<Artist> artists = searchService.FuzzySearchByArtist(line);
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
            Console.WriteLine();
        }
        else if (choice == 2)
        {
            Console.WriteLine("Введите имя альбома или коллекции");
            var line = Parsing.ParseLine();
            var albumAndCollectionResults = searchService.FuzzySearchByAlbumsAndSongsCollections(line);
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
        else if (choice == 3)
        {
            Console.WriteLine("Введите <имя артиста>, <имя песни>");
            var (artist, song) = Parsing.ParseTwo();
            var songs = searchService.SearchSongsByCriterias(artist, song);

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
        else if (choice == 4)
        {
            Console.WriteLine("Введите <имя артиста>, <имя жанра>");
            var (artist, genre) = Parsing.ParseTwo();
            try
            {
                var ar = createService.CreateArtist(artist, genre);
                Console.WriteLine("Созданный артист: " + ar);
            }
            catch (NoSuchRecordException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
        }
        else if (choice == 5)
        {
            Console.WriteLine("Добавление альбом исполнителя");
            Console.WriteLine("Введите <имя артиста>, <имя альбома>");
            var (artist, album) = Parsing.ParseTwo();
            try
            {
                var (alb, art) = createService.CreateAlbum(artist, album);
                Console.WriteLine($"Создан альбом артиста {art}\nАльбом: {alb} ");
            }
            catch (NoSuchRecordException e)
            {

                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
        }

        else if (choice == 6)
        {
            Console.WriteLine("Добавление новой песни исполнителя в альбом");
            Console.WriteLine("Введите <имя артиста>, <имя существующего альбома>, <имя новой песни>");
            var (artist, album, song) = Parsing.ParseThree();
            try
            {
                var (alb, art, s) = createService.CreateSongToAlbum(artist, album, song);
                Console.WriteLine($"Для альбома {alb}\nартиста: {art}\nСоздана песня: {song}");
            }
            catch (NoSuchRecordException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
        }
        else if (choice == 7)
        {
            Console.WriteLine("Добавление нового сборника песен");
            Console.WriteLine("Введите <имя нового сборника песен>");
            var collection = Parsing.ParseOne();
            try
            {
                var col = createService.CreateSongsCollection(collection);
                Console.WriteLine($"Создана коллекция {col}");
            }
            catch (NoSuchRecordException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
        }
        else if (choice == 8)
        {
            Console.WriteLine("Добавлаение существующей песни исполнителя в сборник песен");
            Console.WriteLine("Введите <имя существующего артиста>, <имя песни>, <имя существующего сборника песен>");
            var (artist, songName, collectionName) = Parsing.ParseThree();
            try
            {
                var (art, song, collection) = createService.AddSongToSongCollection(artist, songName, collectionName);
                Console.WriteLine($"В сборник песен: {collection}\nАртиста: {art}\nДобавлена песня: {song}");
            }
            catch (NoSuchRecordException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
        }

    }
}
