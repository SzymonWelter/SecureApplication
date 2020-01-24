using System.ComponentModel.DataAnnotations;

namespace SecureServer.Models.DTO
{
    public class UserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}