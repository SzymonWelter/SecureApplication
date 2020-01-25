using System;
using System.Collections.Generic;

namespace SecureServer.Models.DAL
{
    public class UserDAL
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Attempt { get; set; }
        public Nullable<DateTime> Blockade { get; set; }
        public ICollection<NoteDAL> Notes { get; set; }
    }
}