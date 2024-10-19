using Lab2.Entities;
using Lab2.Dto;

namespace Lab2.Services;

public interface ISearchService
{
  public List<Artist> FuzzySearchByArtist(string artistName);
  public List<Artist> ExactSearchByArtist(string artistName);
  public List<AlbumAndCollectionSearchResultDto> FuzzySearchByAlbumsAndSongsCollections(string query);
  public List<Album> ExactSearchByAlbum(string album);
  public List<Song> SearchSongsByCriterias(string artistName, string songName);
  public Genre? SearchGenre(string genre);
}
