using System.ComponentModel.DataAnnotations;

namespace Streaming.Models;

public class Product
{
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
}
