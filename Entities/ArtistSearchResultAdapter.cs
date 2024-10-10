namespace Lab2.Entities;

public class ArtistSearchResultAdapter : Artist
{
  public ArtistSearchResultAdapter(ArtistSearchResult searchResult)
  {
    Id = searchResult.ArtistId;
    Name = searchResult.ArtistName;
    Genre = null;
    Albums = new List<Album>();
  }
}
