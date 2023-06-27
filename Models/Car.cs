namespace sharpList.Models;

public class Car
{
  public int Id { get; set; }
  public string Make { get; set; }
  public string Model { get; set; }
  public int? Year { get; set; }
  public double? Price { get; set; }
  public string Color { get; set; }
  public string Description { get; set; }

  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}
