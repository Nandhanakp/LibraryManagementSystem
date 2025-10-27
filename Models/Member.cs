using System;
using System.ComponentModel.DataAnnotations;

namespace NewFolder.Models
{
    public class Member
    {
        public int MemberID { get; set; }

        [Required, StringLength(100)]
        public string? Name { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required, Phone]
        public string? PhoneNo { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [DataType(DataType.Date)]
        public DateTime MembershipDate { get; set; }

        [Required]
        public string? MembershipType { get; set; } // "Free" or "Paid"

        public int? DurationInMonths { get; set; }

        [Required, DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        public string? Role { get; set; }
    }
}
