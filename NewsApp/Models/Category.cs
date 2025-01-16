using System.ComponentModel.DataAnnotations;

namespace NewsApp.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    // Navigation property for many-to-many
    public ICollection<News>? NewsItems { get; set; }
}