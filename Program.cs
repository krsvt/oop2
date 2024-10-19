using Lab2.Services;
using Lab2.Data;
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
    .AddScoped<CommandExecutorService>()
    .BuildServiceProvider();

using (var scope = serviceProvider.CreateScope())
{
    var searchService = scope.ServiceProvider.GetRequiredService<ISearchService>();
    var createService = scope.ServiceProvider.GetRequiredService<ICreateService>();
    var commandExecutorService = scope.ServiceProvider.GetRequiredService<CommandExecutorService>();

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
}
