using System;

namespace SecureServer.Models.Domain
{
    public class AuthResultModel
    {
        public bool IsSuccess { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}