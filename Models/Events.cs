using System.ComponentModel.DataAnnotations;

namespace NewFolder.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; } = string.Empty;

        [Required]
        public string? Description { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string? ImageUrl { get; set; }  // optional for event posters
    }
}
