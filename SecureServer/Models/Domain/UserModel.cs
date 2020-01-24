using System;

namespace SecureServer.Models.Domain
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}