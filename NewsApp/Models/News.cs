using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsApp.Models;

public class News
{
    [Key]
    public int NewsId { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    public DateTime PublishedDate { get; set; }

    [StringLength(100)]
    public string Author { get; set; }

    // Navigation property for many-to-many
    public ICollection<Category> Categories { get; set; }
}