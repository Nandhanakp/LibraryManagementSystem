using System.ComponentModel.DataAnnotations;

namespace NewFolder.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        // For storing image path or URL
        public string ImageUrl { get; set; } = string.Empty;
         public int Year { get; set; }
         public string ISBN { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
