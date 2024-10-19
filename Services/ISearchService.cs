using Lab2.Entities;
using Lab2.Dto;

namespace Lab2.Services;

public interface ISearchService
{
  public List<Artist> FuzzySearchByArtist(string query);
  public List<AlbumAndCollectionSearchResultDto> FuzzySearchByAlbumsAndSongsCollections(string query);
  public List<Song> SearchSongsByCriterias(string artistName, string songName);
  public Genre? SearchGenre(string genre);
}
