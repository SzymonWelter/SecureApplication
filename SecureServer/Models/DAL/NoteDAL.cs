using System;

namespace SecureServer.Models.DAL
{
    public class NoteDAL
    {
        public Guid NoteId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsPublic { get; set; }
        public Guid UserId {get;set;}
        public UserDAL User { get; set; }
    }
}