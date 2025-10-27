using System.ComponentModel.DataAnnotations;

namespace NewFolder.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? ServiceName { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
