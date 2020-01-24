using System;

namespace SecureServer.Models.DTO
{
    public class AuthResultDTO
    {
        public bool IsSuccess { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
    }
}