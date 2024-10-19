using Lab2.Entities;
using Lab2.Data;
using Lab2.Exceptions;

namespace Lab2.Services;

public class PostgreSQLCreateService : ICreateService
{
  public ISearchService Search;
  private readonly MyDbContext _dbContext;

  public PostgreSQLCreateService(ISearchService search, MyDbContext dbContext)
  {
    Search = search;
    _dbContext = dbContext;
  }

  public Artist CreateArtist(string name, string genre)
  {

    var g = Search.SearchGenre(genre);

    if (g != null)
    {
      var a = new Artist
      {
        Name = name,
        Genre = g
      };
      _dbContext.Artists.Add(a);
      _dbContext.SaveChanges();
      return a;
    }
    else
    {
      throw new NoSuchRecordException("не могу найти жанр " + genre);
    }
  }


  public (Album, Artist) CreateAlbum(string artist, string album)
  {
    var arts = Search.FuzzySearchByArtist(artist);

    if (arts.First() != null)
    {
      var alb = new Album { Title = album };
      var art = arts.First();
      _dbContext.Albums.Add(alb);
      art.Albums.Add(alb);
      _dbContext.SaveChanges();
      return (alb, art);
    }
    else
    {
      throw new NoSuchRecordException("не могу найти артиста " + artist);
    }
  }

  public (Album, Artist, Song) CreateSongToAlbum(string artist, string album, string song)
  {
    var art = Search.FuzzySearchByArtist(artist).FirstOrDefault();

    if (art == null)
      throw new NoSuchRecordException("не могу найти артиста " + artist);

    var alb = Search.FuzzySearchByAlbumsAndSongsCollections(album)
      .Where(a => a.Type != null)
      .Where(a => a.Type == "album")
      .FirstOrDefault();

    if (alb == null)
      throw new NoSuchRecordException("не могу найти альбом " + album);

    var dbAlb =
    _dbContext.Albums.Where(a => alb.Id == a.Id)
    .FirstOrDefault();

    if (dbAlb == null)
      throw new NoSuchRecordException("не могу найти альбом " + album);

    var newSong = new Song { Title = song };
    _dbContext.Songs.Add(newSong);
    dbAlb.Songs.Add(newSong);
    _dbContext.SaveChanges();
    return (dbAlb, art, newSong);
  }


  public SongsCollection CreateSongsCollection(string collection)
  {
    var c = new SongsCollection { Title = collection };
    _dbContext.SongsCollections.Add(c);
    _dbContext.SaveChanges();
    return c;
  }

  public (Artist, Song, SongsCollection) AddSongToSongCollection(string artist, string songName, string collectionName)
  {
    var art = Search.FuzzySearchByArtist(artist).FirstOrDefault();
    if (art == null)
      throw new NoSuchRecordException("не могу найти артиста " + artist);

    var song = Search.SearchSongsByCriterias(art.Name, songName).FirstOrDefault();

    if (song == null)
      throw new NoSuchRecordException("не могу найти песню " + songName + " артиста " + art.Name);

    var collection = _dbContext.SongsCollections.Where(c => c.Title.ToLower().Trim() == collectionName.ToLower().Trim())
      .FirstOrDefault();
    if (collection == null)
      throw new NoSuchRecordException("не могу найти коллекцию " + collectionName);

    collection.Songs.Add(song);
    _dbContext.SaveChanges();
    return (art, song, collection);
  }

}
