namespace Lab2.Services;

public interface SearchService
{
  public void SearchByArtist(string query);
  public void SearchByAlbumsAndSongsCollections(string query);
  public void SearchSongsByCriterias(string query);
}
