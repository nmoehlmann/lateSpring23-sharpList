using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sharpList.Models
{
  public class House
  {
    public int Id { get; set; }
    public string name { get; set; }
    public int? levels { get; set; }
    public int? bathrooms { get; set; }
    public int? bedrooms { get; set; }
    public double? price { get; set; }
    public string description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}