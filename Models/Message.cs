using System;
using System.ComponentModel.DataAnnotations;

namespace NewFolder.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string? SenderName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Content { get; set; }

        public DateTime SentAt { get; set; } = DateTime.Now;
    }
}
