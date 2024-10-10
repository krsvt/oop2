using Lab2.Entities;

namespace Lab2.Services;

public interface SearchService
{
  public List<ArtistSearchResult> SearchByArtist(string query);
  public List<AlbumAndCollectionSearchResult> SearchByAlbumsAndSongsCollections(string query);
  public List<Song> SearchSongsByCriterias(string artistName, string songName);
}
