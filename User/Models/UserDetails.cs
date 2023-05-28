using System.ComponentModel.DataAnnotations;

namespace User.Models
{
    public class UserDetails
    {
        [Key]
        [MinLength(3, ErrorMessage = " Username should be minimum 3 chars long")]

        public string Username { get; set; }

        public byte[]? Password { get; set; }

        public byte[]? HashKey { get; set; }
        [MinLength(10, ErrorMessage = " PhoneNumber should be minimum 10 chars long")]
        public string? PhoneNumber { get; set; }

        public string Name { get; set; }
        [Range(18, 80, ErrorMessage = "Invalid Age Range ")]

        public int Age { get; set; }
        public string Role { get; set; }
    }
}
