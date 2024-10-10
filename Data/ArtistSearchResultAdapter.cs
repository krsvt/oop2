using Lab2.Entities;
using Lab2.Dto;

namespace Lab2.Data;

public class ArtistSearchResultAdapter : Artist
{
  public ArtistSearchResultAdapter() { }
  public ArtistSearchResultAdapter(ArtistSearchResultDto searchResult)
  {
    Id = searchResult.ArtistId;
    Name = searchResult.ArtistName;
    Genre = null;
    Albums = new List<Album>();
  }
}
