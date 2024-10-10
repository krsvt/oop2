namespace Lab2.Dto;

public record AlbumAndCollectionSearchResultDto
{
  public int Id { get; set; }

  public string? Title { get; set; }

  public string? Type { get; set; }
}
