using Lab2.Entities;
using Lab2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

    private List<Song> AllSongsByArtist(Artist artist)
    {
        return artist.Albums
            .SelectMany(album => album.Songs ?? Enumerable.Empty<Song>())
            .ToList() ?? new List<Song>();
    }

    // если артист найден, у него такой жанр - вернем все его песни
    // в любых других случаях ничего не вернем
    // тупые критерии, но в теории может быть использовано с одинаковыми никнеймами но разными жанрами
    public List<Song> SearchSongsByCriterias(string artistName, string genreName)
    {
        var artist = _dbContext.Artists
            .Include(a => a.Genre)
            .Include(a => a.Albums)
            .ThenInclude(album => album.Songs)
            .FirstOrDefault(a => a.Name != null && a.Name.ToLower() == artistName.ToLower());

        // Если артист не найден, пустой список
        if (artist == null)
        {
            return new List<Song>();
        }

        var genre = _dbContext.Genres
            .FirstOrDefault(g => g.Name != null && (g.Name.ToLower() == genreName.ToLower()));

        if (genre == null)
        {
            return new List<Song>();
        }
        else if (artist.Genre != null && artist.Genre.Name != null && artist.Genre.Name.Equals(genre.Name))
        {
            return AllSongsByArtist(artist);
        }
        else
        {
            return new List<Song>();
        }

    }
}
