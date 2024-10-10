using Lab2.Data;
using Lab2.Entities;
using Lab2.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var serviceProvider = new ServiceCollection()
    .AddSingleton<IConfiguration>(configuration)
    .AddDbContext<MyDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")))
    .AddScoped<PostgreSQlSearchService>()
    .BuildServiceProvider();

using (var scope = serviceProvider.CreateScope())
{
    var searchService = scope.ServiceProvider.GetRequiredService<PostgreSQlSearchService>();

    var songsLetov = searchService.SearchSongsByCriterias("Юрий Лоза", "РЭП");

    var notExit = true;
    while (notExit)
    {

        // 0 выход
        // 1 искать по артисту
        // 2 искать по названию
        // 3 искать по критериям имя артиста + жанр
        //

        Console.WriteLine("0) выход");
        Console.WriteLine("1) искать по артисту");
        Console.WriteLine("2) искать по названию");
        Console.WriteLine("3) искать по критериям имя артиста + жанр");
        int choice = Parsing.ParseInt(0, 3);
        if (choice == 0) notExit = false;
        else if (choice == 1)
        {
            Console.WriteLine("Введите имя артиста");
            var line = Parsing.ParseLine();
            var artistResults = searchService.SearchByArtist(line);
            Console.WriteLine("Найдено:");
            foreach (var art in artistResults)
            {
                Console.WriteLine($"Имя: {art.ArtistName}");
            }
            Console.WriteLine();
        }
        else if (choice == 2)
        {
            Console.WriteLine("Введите имя альбома или коллекции");
            var line = Parsing.ParseLine();
            var albumAndCollectionResults = searchService.SearchByAlbumsAndSongsCollections(line);

            Console.WriteLine("Найдено:");
            foreach (var col in albumAndCollectionResults)
            {
                Console.WriteLine($"Название: {col.Title}, тип: {col.Type}");
            }
            Console.WriteLine();
        }
        else if (choice == 3)
        {
            Console.WriteLine("Введите <имя артиста> <жанр>");
            var (artist, genre) = Parsing.ParseTwo();
            var songs = searchService.SearchSongsByCriterias(artist, genre);

            Console.WriteLine("Найдено:");
            foreach (var son in songs)
            {
                Console.WriteLine($"Название: {son.Title}");
            }
            Console.WriteLine();
        }

    }

}


