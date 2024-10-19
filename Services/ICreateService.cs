using Lab2.Entities;
namespace Lab2.Services;

public interface ICreateService
{
  public Artist CreateArtist(string name, string genre);


  public (Album, Artist) CreateAlbum(string artist, string album);


  public (Album, Artist, Song) CreateSongToAlbum(string artist, string album, string song);



  public SongsCollection CreateSongsCollection(string collection);


  public (Artist, Song, SongsCollection) AddSongToSongCollection(string artist, string songName, string collectionName);


}
