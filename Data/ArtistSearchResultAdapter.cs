using Lab2.Entities;
using Lab2.Dto;

namespace Lab2.Data;

public class ArtistSearchResultAdapter : Artist
{

  public Artist Artist { get; private set; }
  public ArtistSearchResultAdapter(ArtistSearchResultDto searchResult)
  {
    Artist = new()
    {
      Id = searchResult.ArtistId,
      Name = searchResult.ArtistName,
      Genre = null,
      Albums = new List<Album>()
    };
  }
}
