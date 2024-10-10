using Lab2.Entities;
using Lab2.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Services;

public class PostgreSQlSearchService : SearchService
{
    private readonly MyDbContext _dbContext;

    public PostgreSQlSearchService(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<ArtistSearchResult> SearchByArtist(string query)
    {
        var artistResults = _dbContext.ArtistSearchResults
            .FromSqlRaw("SELECT * FROM SearchByArtist({0})", query)
            .ToList();

        return artistResults.Cast<ArtistSearchResult>().ToList();
    }

    public List<AlbumAndCollectionSearchResult> SearchByAlbumsAndSongsCollections(string query)
    {
        var albumAndCollectionResults = _dbContext.AlbumAndCollectionSearchResults
            .FromSqlRaw("SELECT * FROM SearchByAlbumsAndSongsCollections({0})", query)
            .ToList();

        return albumAndCollectionResults.Cast<AlbumAndCollectionSearchResult>().ToList();
    }

    private List<Song> SongsStartsWith(Artist artist, string songName)
    {
        var allSongs = artist
            .Albums
            .SelectMany(album => album.Songs)
            .ToList();
        return allSongs.Where(s => s.Title.ToLower().StartsWith(songName.ToLower())).ToList();
    }

    private List<Song> SongsStartsWith(DbSet<Artist> artists, string songName)
    {
        return artists
            .Include(a => a.Albums)
            .ThenInclude(album => album.Songs)
            .SelectMany(artist => artist.Albums)
            .SelectMany(album => album.Songs)
            .Where(song => song.Title.ToLower().StartsWith(songName.ToLower())).ToList();
    }

    // исполнитель найден -> ищем только его песни
    // исполнитель не найден -> ищем имя песни по всем
    public List<Song> SearchSongsByCriterias(string artistName, string songName)
    {
        var artist = _dbContext.Artists
            .Include(a => a.Albums)
            .ThenInclude(album => album.Songs)
            .FirstOrDefault(a => a.Name.ToLower() == artistName.ToLower());

        if (artist != null)
        {
            return SongsStartsWith(artist, songName);
        }

        return SongsStartsWith(_dbContext.Artists, songName);

    }
}
