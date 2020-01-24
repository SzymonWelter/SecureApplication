using System.ComponentModel.DataAnnotations;

namespace SecureServer.Models.DTO
{
    public class SignInDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}