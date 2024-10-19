using Lab2.Entities;
using Lab2.Dto;

namespace Lab2.Services;

public interface ISearchService
{
  public List<ArtistSearchResultDto> SearchByArtist(string query);
  public List<AlbumAndCollectionSearchResultDto> SearchByAlbumsAndSongsCollections(string query);
  public List<Song> SearchSongsByCriterias(string artistName, string songName);
}
