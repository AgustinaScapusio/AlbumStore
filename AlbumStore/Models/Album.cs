using System.ComponentModel.DataAnnotations;

namespace AlbumStore.Models;

public class Album
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Artist { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Genre { get; set; }
    
    public DateTime ReleaseDate { get; set; }
    
    [Range(50, 10000)]
    public decimal Price { get; set; }
}